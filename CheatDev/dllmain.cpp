#include <windows.h>
#include <thread>
#include <vector>
#include <string>
#include <fstream>
#include <sstream>
#include <cmath>
#include <cstring>
#include <algorithm>
#include <d3d11.h>

#include "imgui.h"
#include "backends/imgui_impl_win32.h"
#include "backends/imgui_impl_dx11.h"
#include "MinHook.h"
#include "Il2Cpp.h"

Il2CppResolver g_Il2Cpp;
HMODULE g_hDllModule = NULL;

// ─── Thread-Safe Diagnostic Logging & Crash Telemetry ────────────────────────
static CRITICAL_SECTION g_LogCs;
static bool g_LogCsInitialized = false;

static std::string GetLogPath(const char* filename = "XUYBYA_Cheat.log") {
    char path[MAX_PATH];
    if (g_hDllModule && GetModuleFileNameA(g_hDllModule, path, MAX_PATH)) {
        std::string s(path);
        size_t pos = s.find_last_of("\\/");
        if (pos != std::string::npos) {
            return s.substr(0, pos + 1) + filename;
        }
    }
    return filename;
}

static void CheatLog(const char* fmt, ...) {
    if (!g_LogCsInitialized) {
        InitializeCriticalSection(&g_LogCs);
        g_LogCsInitialized = true;
    }

    EnterCriticalSection(&g_LogCs);

    SYSTEMTIME st;
    GetLocalTime(&st);

    char timeBuf[32];
    snprintf(timeBuf, sizeof(timeBuf), "[%02d:%02d:%02d.%03d] ",
             st.wHour, st.wMinute, st.wSecond, st.wMilliseconds);

    char msgBuf[1024];
    va_list args;
    va_start(args, fmt);
    vsnprintf(msgBuf, sizeof(msgBuf), fmt, args);
    va_end(args);

    std::string path = GetLogPath("XUYBYA_Cheat.log");
    FILE* f = fopen(path.c_str(), "a");
    if (f) {
        fprintf(f, "%s%s\n", timeBuf, msgBuf);
        fflush(f);
        fclose(f);
    }

    LeaveCriticalSection(&g_LogCs);
}

// ─── Vectored Exception Handler (Automatic Crash Logger) ─────────────────────
static LONG WINAPI CrashHandler(PEXCEPTION_POINTERS pExc) {
    if (!pExc || !pExc->ExceptionRecord) return EXCEPTION_CONTINUE_SEARCH;
    DWORD code = pExc->ExceptionRecord->ExceptionCode;

    if (code == 0xC0000005 || code == 0xC000001D || code == 0xC0000094 || code == 0x80000003) {
        void* crashAddr = pExc->ExceptionRecord->ExceptionAddress;
        HMODULE hMod = NULL;
        char modName[MAX_PATH] = "Unknown Module";
        if (GetModuleHandleExA(GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS | GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT, (LPCSTR)crashAddr, &hMod)) {
            GetModuleFileNameA(hMod, modName, MAX_PATH);
            char* p = strrchr(modName, '\\');
            if (p) memmove(modName, p + 1, strlen(p + 1) + 1);
        }
        uintptr_t offset = hMod ? ((uintptr_t)crashAddr - (uintptr_t)hMod) : (uintptr_t)crashAddr;

        CheatLog("\n========================================================");
        CheatLog("!!! CRASH EXCEPTION DETECTED (Code: 0x%08X) !!!", code);
        CheatLog("Crash Location   : 0x%p (%s + 0x%llX)", crashAddr, modName, (unsigned long long)offset);

        if (code == 0xC0000005 && pExc->ExceptionRecord->NumberParameters >= 2) {
            ULONG_PTR accessType = pExc->ExceptionRecord->ExceptionInformation[0];
            ULONG_PTR targetAddr = pExc->ExceptionRecord->ExceptionInformation[1];
            CheatLog("Memory Violation : Attempted %s at address 0x%p",
                     accessType == 0 ? "READ" : (accessType == 1 ? "WRITE" : "EXECUTE"), (void*)targetAddr);
        }

        if (pExc->ContextRecord) {
            CheatLog("CPU Registers:");
            CheatLog("  RIP: 0x%016llX  RSP: 0x%016llX  RBP: 0x%016llX",
                     (unsigned long long)pExc->ContextRecord->Rip,
                     (unsigned long long)pExc->ContextRecord->Rsp,
                     (unsigned long long)pExc->ContextRecord->Rbp);
            CheatLog("  RAX: 0x%016llX  RBX: 0x%016llX  RCX: 0x%016llX  RDX: 0x%016llX",
                     (unsigned long long)pExc->ContextRecord->Rax,
                     (unsigned long long)pExc->ContextRecord->Rbx,
                     (unsigned long long)pExc->ContextRecord->Rcx,
                     (unsigned long long)pExc->ContextRecord->Rdx);
            CheatLog("  RSI: 0x%016llX  RDI: 0x%016llX  R8:  0x%016llX  R9:  0x%016llX",
                     (unsigned long long)pExc->ContextRecord->Rsi,
                     (unsigned long long)pExc->ContextRecord->Rdi,
                     (unsigned long long)pExc->ContextRecord->R8,
                     (unsigned long long)pExc->ContextRecord->R9);
        }
        CheatLog("========================================================\n");
    }

    return EXCEPTION_CONTINUE_SEARCH;
}

// ─── Cached game class handles ───────────────────────────────────────────────
Il2CppClass* g_PlayerClass              = nullptr;
Il2CppClass* g_PlayerMovementClass      = nullptr;
Il2CppClass* g_HealthClass              = nullptr;
Il2CppClass* g_SharedRefClass           = nullptr;
Il2CppClass* g_RagdollCamClass          = nullptr;
Il2CppClass* g_WeaponClass              = nullptr;
Il2CppClass* g_WeaponManagerClass       = nullptr;
Il2CppClass* g_DataPackerClass          = nullptr;
MethodInfo*  g_GetCurrentHealth         = nullptr;
MethodInfo*  g_IsDeadMethod             = nullptr;
MethodInfo*  g_CMDChangeCurrentHealth   = nullptr;
MethodInfo*  g_ClientTryShoot           = nullptr;
MethodInfo*  g_CMDShoot                 = nullptr;
MethodInfo*  g_PickUpMethod             = nullptr;
MethodInfo*  g_StartPickUpMethod        = nullptr;
MethodInfo*  g_PackDirectionMethod      = nullptr;
MethodInfo*  g_UnpackShortMethod        = nullptr;
MethodInfo*  g_PackVector3Method        = nullptr;
MethodInfo*  g_UnpackDirectionMethod    = nullptr;

// ─── Per-bone screen coordinates ──────────────────────────────────────────────
struct BonePoint {
    Vector3 world{};
    Vector3 screen{};
    bool    valid = false;
};

// ─── Per-frame ESP snapshot ──────────────────────────────────────────────────
struct PlayerESPData {
    BonePoint head;
    BonePoint chest;
    BonePoint spine;
    BonePoint root;
    BonePoint lShoulder, lUpperArm, lElbow, lHand;
    BonePoint rShoulder, rUpperArm, rElbow, rHand;
    BonePoint lKnee, lFoot;
    BonePoint rKnee, rFoot;

    float boxMinX = 0.0f, boxMaxX = 0.0f;
    float boxMinY = 0.0f, boxMaxY = 0.0f;
    bool  hasBox  = false;

    Vector3 aimScreenPos{};
    float   distance = 0.0f;

    int  hp       = 100;
    int  maxHp    = 100;
    bool isDead   = false;
    bool awayTeam = false;
    bool isEnemy  = true;
    bool isLocal  = false;
};

std::vector<PlayerESPData> g_ESPData;

// ─── Globals ──────────────────────────────────────────────────────────────────
bool g_ShowMenu  = false;
HWND g_hWnd      = NULL;

ID3D11Device*            g_pd3dDevice            = nullptr;
ID3D11DeviceContext*     g_pd3dDeviceContext      = nullptr;
ID3D11RenderTargetView*  g_mainRenderTargetView   = nullptr;
volatile bool            g_IsInitialized          = false;
volatile bool            g_Uninjecting            = false;

// ─── Menu Navigation State ───────────────────────────────────────────────────
int g_CurrentTab = 0; // 0: ESP, 1: Combat, 2: Colors, 3: Configs, 4: Diagnostics

// ─── Keybind Definition Table ────────────────────────────────────────────────
const char* const g_KeyNames[] = {
    "Left Alt [DEFAULT]",
    "Right Mouse [RMB]",
    "Left Shift",
    "Left Ctrl",
    "[X] Key",
    "[C] Key",
    "[V] Key",
    "[F] Key",
    "[CAPS LOCK]",
    "[Mouse 4] (Thumb 1)",
    "[Mouse 5] (Thumb 2)",
    "Always Active [Toggle]"
};

static bool IsKeyActive(int keyIndex) {
    switch (keyIndex) {
        case 0: return (GetAsyncKeyState(VK_MENU) & 0x8000) || (GetAsyncKeyState(VK_LMENU) & 0x8000);
        case 1: return (GetAsyncKeyState(VK_RBUTTON) & 0x8000) != 0;
        case 2: return (GetAsyncKeyState(VK_SHIFT) & 0x8000) || (GetAsyncKeyState(VK_LSHIFT) & 0x8000);
        case 3: return (GetAsyncKeyState(VK_CONTROL) & 0x8000) || (GetAsyncKeyState(VK_LCONTROL) & 0x8000);
        case 4: return (GetAsyncKeyState('X') & 0x8000) != 0;
        case 5: return (GetAsyncKeyState('C') & 0x8000) != 0;
        case 6: return (GetAsyncKeyState('V') & 0x8000) != 0;
        case 7: return (GetAsyncKeyState('F') & 0x8000) != 0;
        case 8: return (GetAsyncKeyState(VK_CAPITAL) & 0x8000) != 0;
        case 9: return (GetAsyncKeyState(VK_XBUTTON1) & 0x8000) != 0;
        case 10: return (GetAsyncKeyState(VK_XBUTTON2) & 0x8000) != 0;
        case 11: return true;
        default: return (GetAsyncKeyState(VK_MENU) & 0x8000) != 0;
    }
}

// ─── Cheat Settings (ALL DISABLED BY DEFAULT) ─────────────────────────────────
// ESP Settings
bool  bEnableESP        = false;
bool  bEnableGlow       = false;   // Neon Bloom / Glow effect
float fGlowIntensity    = 1.0f;    // Glow intensity multiplier
bool  bDrawBoxes        = false;
float fBoxThickness     = 1.8f;
bool  bDrawSkeleton     = false;
float fSkeletonThickness= 1.8f;
bool  bDrawHeadCircle   = false;
float fHeadCircleSize   = 1.0f;
bool  bDrawTracers      = false;
int   iTracerOrigin     = 0;       // 0: Bottom, 1: Crosshair, 2: Top
float fTracerThickness  = 1.8f;
bool  bDrawHealthBar    = false;
bool  bDrawInfoText     = false;
bool  bIgnoreTeammates  = false;   // Enemies only
bool  bIgnoreLocal      = true;    // Hide self
bool  bIgnoreDead       = true;    // Hide dead / spawn ghosts
float fMaxDistance      = 500.0f;  // Max render distance

// Colors (Customizable)
float colEnemy[4]     = { 1.0f, 0.22f, 0.35f, 1.0f }; // Vibrant Neon Red/Pink
float colTeam[4]      = { 0.20f, 0.70f, 1.00f, 1.0f }; // Electric Blue
float colSkeleton[4]  = { 0.95f, 0.95f, 0.98f, 0.90f };// Clean White
float colTracers[4]   = { 1.0f, 0.85f, 0.20f, 0.80f }; // Bright Amber
float colHeadCircle[4]= { 1.0f, 0.35f, 0.50f, 1.0f }; // Neon Crimson

// Silent Aim Settings (Hit Any Shot Anywhere)
bool  bEnableSilentAim    = false;
int   iSilentAimTarget    = 1;       // 0: Chest, 1: Head
float fSilentAimFOV       = 180.0f;  // pixel radius from crosshair
bool  bDrawSilentAimFOV   = false;
bool  bSilentAimFull360   = true;    // True: Hit from anywhere on map, False: Within FOV circle

// Aimbot Settings (Default Key: Left Alt)
bool  bEnableAimbot     = false;
int   iAimbotKey        = 0;       // 0: Left Alt [DEFAULT]
bool  bDrawAimbotFOV    = false;
int   iAimbotTarget     = 0;       // 0: Chest, 1: Head
float aimbotFOV         = 150.0f;  // pixel radius from crosshair
float aimbotSmooth      = 6.0f;
float aimbotMaxSpeed    = 35.0f;   // Max pixel movement step per frame

// Teleportation & Auto-Shoot Kill Aura
bool  bEnableTeleportKill = false;
bool  bTeleportHoldKey    = false;   // False: Always active when toggled, True: Hold hotkey
int   iTeleportKey        = 4;       // Default [X] Key
int   iTeleportPosition   = 0;       // 0: Behind Target (Backstab), 1: Above Target, 2: In Front, 3: Directly on Target
int   iTeleportTargetMode = 0;       // 0: Random / Cycle Target, 1: Closest Distance, 2: Lowest HP
float fTeleportDistance   = 1.2f;    // Distance from target in meters
float fTeleportHeight     = 0.3f;    // Height offset in meters
bool  bTeleportAutoShoot  = true;    // Fire weapon automatically while teleporting
bool  bTeleportLookAt     = true;    // Auto-aim/orient body and camera at enemy
float fTeleportShootRate  = 45.0f;   // Shooting interval in milliseconds

// Mass Kill (Server-Wide Instant Annihilation Aura)
bool  bEnableMassKill     = false;
float fMassKillInterval   = 80.0f;   // Interval in milliseconds (e.g. 80ms)
int   iMassKillMode       = 1;       // 0: Direct Server Health Zero RPC, 1: Multi-Raycast CMDShoot, 2: Hybrid

// God Mode (Invulnerability)
bool  bGodMode            = false;

// Weapon Spawner & Stat Modifiers
int   iSelectedWeaponIndex= 0;
bool  bInfiniteAmmo       = true;
bool  bOneHitKillDamage   = true;
bool  bRapidFire          = true;
bool  bInfiniteRange      = true;

// ─── Config System ────────────────────────────────────────────────────────────
static char g_ConfigStatus[128] = "";
static ULONGLONG g_ConfigStatusTime = 0;

static void SetConfigStatus(const char* msg) {
    strncpy(g_ConfigStatus, msg, sizeof(g_ConfigStatus) - 1);
    g_ConfigStatusTime = GetTickCount64();
}

static std::string GetConfigPath() {
    char path[MAX_PATH];
    if (g_hDllModule && GetModuleFileNameA(g_hDllModule, path, MAX_PATH)) {
        std::string s(path);
        size_t pos = s.find_last_of("\\/");
        if (pos != std::string::npos) {
            return s.substr(0, pos + 1) + "XUYBYA_Config.ini";
        }
    }
    return "XUYBYA_Config.ini";
}

static void SaveConfig() {
    std::string path = GetConfigPath();
    std::ofstream f(path);
    if (!f.is_open()) {
        SetConfigStatus("Error: Unable to create config file!");
        return;
    }

    f << "[Visuals]\n";
    f << "bEnableESP=" << bEnableESP << "\n";
    f << "bEnableGlow=" << bEnableGlow << "\n";
    f << "fGlowIntensity=" << fGlowIntensity << "\n";
    f << "bDrawBoxes=" << bDrawBoxes << "\n";
    f << "fBoxThickness=" << fBoxThickness << "\n";
    f << "bDrawSkeleton=" << bDrawSkeleton << "\n";
    f << "fSkeletonThickness=" << fSkeletonThickness << "\n";
    f << "bDrawHeadCircle=" << bDrawHeadCircle << "\n";
    f << "fHeadCircleSize=" << fHeadCircleSize << "\n";
    f << "bDrawTracers=" << bDrawTracers << "\n";
    f << "iTracerOrigin=" << iTracerOrigin << "\n";
    f << "fTracerThickness=" << fTracerThickness << "\n";
    f << "bDrawHealthBar=" << bDrawHealthBar << "\n";
    f << "bDrawInfoText=" << bDrawInfoText << "\n";
    f << "bIgnoreTeammates=" << bIgnoreTeammates << "\n";
    f << "bIgnoreLocal=" << bIgnoreLocal << "\n";
    f << "bIgnoreDead=" << bIgnoreDead << "\n";
    f << "fMaxDistance=" << fMaxDistance << "\n";

    f << "\n[Colors]\n";
    f << "colEnemy=" << colEnemy[0] << "," << colEnemy[1] << "," << colEnemy[2] << "," << colEnemy[3] << "\n";
    f << "colTeam=" << colTeam[0] << "," << colTeam[1] << "," << colTeam[2] << "," << colTeam[3] << "\n";
    f << "colSkeleton=" << colSkeleton[0] << "," << colSkeleton[1] << "," << colSkeleton[2] << "," << colSkeleton[3] << "\n";
    f << "colTracers=" << colTracers[0] << "," << colTracers[1] << "," << colTracers[2] << "," << colTracers[3] << "\n";
    f << "colHeadCircle=" << colHeadCircle[0] << "," << colHeadCircle[1] << "," << colHeadCircle[2] << "," << colHeadCircle[3] << "\n";

    f << "\n[SilentAim]\n";
    f << "bEnableSilentAim=" << bEnableSilentAim << "\n";
    f << "iSilentAimTarget=" << iSilentAimTarget << "\n";
    f << "fSilentAimFOV=" << fSilentAimFOV << "\n";
    f << "bDrawSilentAimFOV=" << bDrawSilentAimFOV << "\n";
    f << "bSilentAimFull360=" << bSilentAimFull360 << "\n";

    f << "\n[Combat]\n";
    f << "bEnableAimbot=" << bEnableAimbot << "\n";
    f << "iAimbotKey=" << iAimbotKey << "\n";
    f << "bDrawAimbotFOV=" << bDrawAimbotFOV << "\n";
    f << "iAimbotTarget=" << iAimbotTarget << "\n";
    f << "aimbotFOV=" << aimbotFOV << "\n";
    f << "aimbotSmooth=" << aimbotSmooth << "\n";
    f << "aimbotMaxSpeed=" << aimbotMaxSpeed << "\n";

    f << "\n[Teleport]\n";
    f << "bEnableTeleportKill=" << bEnableTeleportKill << "\n";
    f << "bTeleportHoldKey=" << bTeleportHoldKey << "\n";
    f << "iTeleportKey=" << iTeleportKey << "\n";
    f << "iTeleportPosition=" << iTeleportPosition << "\n";
    f << "iTeleportTargetMode=" << iTeleportTargetMode << "\n";
    f << "fTeleportDistance=" << fTeleportDistance << "\n";
    f << "fTeleportHeight=" << fTeleportHeight << "\n";
    f << "bTeleportAutoShoot=" << bTeleportAutoShoot << "\n";
    f << "bTeleportLookAt=" << bTeleportLookAt << "\n";
    f << "fTeleportShootRate=" << fTeleportShootRate << "\n";

    f << "\n[MassKill]\n";
    f << "bEnableMassKill=" << bEnableMassKill << "\n";
    f << "fMassKillInterval=" << fMassKillInterval << "\n";
    f << "iMassKillMode=" << iMassKillMode << "\n";

    f << "\n[Weapons]\n";
    f << "iSelectedWeaponIndex=" << iSelectedWeaponIndex << "\n";
    f << "bInfiniteAmmo=" << bInfiniteAmmo << "\n";
    f << "bOneHitKillDamage=" << bOneHitKillDamage << "\n";
    f << "bRapidFire=" << bRapidFire << "\n";
    f << "bInfiniteRange=" << bInfiniteRange << "\n";

    f << "\n[Misc]\n";
    f << "bGodMode=" << bGodMode << "\n";

    f.close();
    SetConfigStatus("Config saved successfully to XUYBYA_Config.ini");
}

static void LoadConfig() {
    std::string path = GetConfigPath();
    std::ifstream f(path);
    if (!f.is_open()) {
        SetConfigStatus("No existing config file found.");
        return;
    }

    std::string line;
    while (std::getline(f, line)) {
        if (line.empty() || line[0] == '[' || line[0] == ';' || line[0] == '#') continue;
        size_t eq = line.find('=');
        if (eq == std::string::npos) continue;

        std::string key = line.substr(0, eq);
        std::string val = line.substr(eq + 1);

        auto ParseBool = [](const std::string& s) { return s == "1" || s == "true" || s == "True"; };
        auto ParseFloat = [](const std::string& s) { return std::stof(s); };
        auto ParseInt = [](const std::string& s) { return std::stoi(s); };
        auto ParseColor = [](const std::string& s, float* col) {
            std::stringstream ss(s);
            std::string item;
            int i = 0;
            while (std::getline(ss, item, ',') && i < 4) {
                col[i++] = std::stof(item);
            }
        };

        try {
            if (key == "bEnableESP") bEnableESP = ParseBool(val);
            else if (key == "bEnableGlow") bEnableGlow = ParseBool(val);
            else if (key == "fGlowIntensity") fGlowIntensity = ParseFloat(val);
            else if (key == "bDrawBoxes") bDrawBoxes = ParseBool(val);
            else if (key == "fBoxThickness") fBoxThickness = ParseFloat(val);
            else if (key == "bDrawSkeleton") bDrawSkeleton = ParseBool(val);
            else if (key == "fSkeletonThickness") fSkeletonThickness = ParseFloat(val);
            else if (key == "bDrawHeadCircle") bDrawHeadCircle = ParseBool(val);
            else if (key == "fHeadCircleSize") fHeadCircleSize = ParseFloat(val);
            else if (key == "bDrawTracers") bDrawTracers = ParseBool(val);
            else if (key == "iTracerOrigin") iTracerOrigin = ParseInt(val);
            else if (key == "fTracerThickness") fTracerThickness = ParseFloat(val);
            else if (key == "bDrawHealthBar") bDrawHealthBar = ParseBool(val);
            else if (key == "bDrawInfoText") bDrawInfoText = ParseBool(val);
            else if (key == "bIgnoreTeammates") bIgnoreTeammates = ParseBool(val);
            else if (key == "bIgnoreLocal") bIgnoreLocal = ParseBool(val);
            else if (key == "bIgnoreDead") bIgnoreDead = ParseBool(val);
            else if (key == "fMaxDistance") fMaxDistance = ParseFloat(val);

            else if (key == "colEnemy") ParseColor(val, colEnemy);
            else if (key == "colTeam") ParseColor(val, colTeam);
            else if (key == "colSkeleton") ParseColor(val, colSkeleton);
            else if (key == "colTracers") ParseColor(val, colTracers);
            else if (key == "colHeadCircle") ParseColor(val, colHeadCircle);

            else if (key == "bEnableSilentAim") bEnableSilentAim = ParseBool(val);
            else if (key == "iSilentAimTarget") iSilentAimTarget = ParseInt(val);
            else if (key == "fSilentAimFOV") fSilentAimFOV = ParseFloat(val);
            else if (key == "bDrawSilentAimFOV") bDrawSilentAimFOV = ParseBool(val);
            else if (key == "bSilentAimFull360") bSilentAimFull360 = ParseBool(val);

            else if (key == "bEnableAimbot") bEnableAimbot = ParseBool(val);
            else if (key == "iAimbotKey") iAimbotKey = ParseInt(val);
            else if (key == "bDrawAimbotFOV") bDrawAimbotFOV = ParseBool(val);
            else if (key == "iAimbotTarget") iAimbotTarget = ParseInt(val);
            else if (key == "aimbotFOV") aimbotFOV = ParseFloat(val);
            else if (key == "aimbotSmooth") aimbotSmooth = ParseFloat(val);
            else if (key == "aimbotMaxSpeed") aimbotMaxSpeed = ParseFloat(val);

            else if (key == "bEnableTeleportKill") bEnableTeleportKill = ParseBool(val);
            else if (key == "bTeleportHoldKey") bTeleportHoldKey = ParseBool(val);
            else if (key == "iTeleportKey") iTeleportKey = ParseInt(val);
            else if (key == "iTeleportPosition") iTeleportPosition = ParseInt(val);
            else if (key == "iTeleportTargetMode") iTeleportTargetMode = ParseInt(val);
            else if (key == "fTeleportDistance") fTeleportDistance = ParseFloat(val);
            else if (key == "fTeleportHeight") fTeleportHeight = ParseFloat(val);
            else if (key == "bTeleportAutoShoot") bTeleportAutoShoot = ParseBool(val);
            else if (key == "bTeleportLookAt") bTeleportLookAt = ParseBool(val);
            else if (key == "fTeleportShootRate") fTeleportShootRate = ParseFloat(val);

            else if (key == "bEnableMassKill") bEnableMassKill = ParseBool(val);
            else if (key == "fMassKillInterval") fMassKillInterval = ParseFloat(val);
            else if (key == "iMassKillMode") iMassKillMode = ParseInt(val);

            else if (key == "iSelectedWeaponIndex") iSelectedWeaponIndex = ParseInt(val);
            else if (key == "bInfiniteAmmo") bInfiniteAmmo = ParseBool(val);
            else if (key == "bOneHitKillDamage") bOneHitKillDamage = ParseBool(val);
            else if (key == "bRapidFire") bRapidFire = ParseBool(val);
            else if (key == "bInfiniteRange") bInfiniteRange = ParseBool(val);

            else if (key == "bGodMode") bGodMode = ParseBool(val);
        } catch (...) {}
    }
    f.close();
    SetConfigStatus("Config loaded successfully from XUYBYA_Config.ini");
}

static void ResetConfigToDefaults() {
    bEnableESP        = false;
    bEnableGlow       = false;
    fGlowIntensity    = 1.0f;
    bDrawBoxes        = false;
    fBoxThickness     = 1.8f;
    bDrawSkeleton     = false;
    fSkeletonThickness= 1.8f;
    bDrawHeadCircle   = false;
    fHeadCircleSize   = 1.0f;
    bDrawTracers      = false;
    iTracerOrigin     = 0;
    fTracerThickness  = 1.8f;
    bDrawHealthBar    = false;
    bDrawInfoText     = false;
    bIgnoreTeammates  = false;
    bIgnoreLocal      = true;
    bIgnoreDead       = true;
    fMaxDistance      = 500.0f;

    colEnemy[0] = 1.0f; colEnemy[1] = 0.22f; colEnemy[2] = 0.35f; colEnemy[3] = 1.0f;
    colTeam[0]  = 0.20f; colTeam[1] = 0.70f; colTeam[2] = 1.00f; colTeam[3] = 1.0f;
    colSkeleton[0] = 0.95f; colSkeleton[1] = 0.95f; colSkeleton[2] = 0.98f; colSkeleton[3] = 0.90f;
    colTracers[0]  = 1.0f; colTracers[1] = 0.85f; colTracers[2] = 0.20f; colTracers[3] = 0.80f;
    colHeadCircle[0]= 1.0f; colHeadCircle[1]= 0.35f; colHeadCircle[2]= 0.50f; colHeadCircle[3]= 1.0f;

    bEnableSilentAim  = false;
    iSilentAimTarget  = 1;
    fSilentAimFOV     = 180.0f;
    bDrawSilentAimFOV = false;
    bSilentAimFull360 = true;

    bEnableAimbot     = false;
    iAimbotKey        = 0; // Alt
    bDrawAimbotFOV    = false;
    iAimbotTarget     = 0;
    aimbotFOV         = 150.0f;
    aimbotSmooth      = 6.0f;
    aimbotMaxSpeed    = 35.0f;

    bEnableTeleportKill = false;
    bTeleportHoldKey    = false;
    iTeleportKey        = 4; // [X]
    iTeleportPosition   = 0;
    iTeleportTargetMode = 0;
    fTeleportDistance   = 1.2f;
    fTeleportHeight     = 0.3f;
    bTeleportAutoShoot  = true;
    bTeleportLookAt     = true;
    fTeleportShootRate  = 45.0f;

    bEnableMassKill     = false;
    fMassKillInterval   = 80.0f;
    iMassKillMode       = 0;

    iSelectedWeaponIndex= 0;
    bInfiniteAmmo       = true;
    bOneHitKillDamage   = true;
    bRapidFire          = true;
    bInfiniteRange      = true;

    bGodMode            = false;
    SetConfigStatus("Reset all settings to default disabled state.");
}

// ─── D3D11 hooks ──────────────────────────────────────────────────────────────
typedef HRESULT(__stdcall* Present_t)(IDXGISwapChain*, UINT, UINT);
typedef HRESULT(__stdcall* ResizeBuffers_t)(IDXGISwapChain*, UINT, UINT, UINT, DXGI_FORMAT, UINT);
Present_t       oPresent       = nullptr;
ResizeBuffers_t oResizeBuffers = nullptr;

static void CleanupRTV() {
    if (g_mainRenderTargetView) {
        g_mainRenderTargetView->Release();
        g_mainRenderTargetView = nullptr;
    }
}

static void CreateRTV(IDXGISwapChain* pSwapChain) {
    if (!g_pd3dDevice) return;
    ID3D11Texture2D* pBB = nullptr;
    if (SUCCEEDED(pSwapChain->GetBuffer(0, __uuidof(ID3D11Texture2D), (LPVOID*)&pBB))) {
        g_pd3dDevice->CreateRenderTargetView(pBB, NULL, &g_mainRenderTargetView);
        pBB->Release();
    }
}

HRESULT __stdcall hkResizeBuffers(IDXGISwapChain* pSC, UINT bc, UINT w, UINT h, DXGI_FORMAT fmt, UINT flags) {
    CleanupRTV();
    HRESULT hr = oResizeBuffers(pSC, bc, w, h, fmt, flags);
    if (SUCCEEDED(hr)) {
        CreateRTV(pSC);
    }
    return hr;
}

extern IMGUI_IMPL_API LRESULT ImGui_ImplWin32_WndProcHandler(HWND, UINT, WPARAM, LPARAM);
WNDPROC oWndProc = nullptr;

// ─── WndProc Hook (Clean pass-through when menu is closed) ───────────────────
LRESULT __stdcall WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam) {
    if (!g_IsInitialized || !oWndProc || g_Uninjecting)
        return DefWindowProc(hWnd, uMsg, wParam, lParam);

    if (uMsg == WM_KEYDOWN || uMsg == WM_SYSKEYDOWN) {
        if (wParam == VK_INSERT || wParam == VK_F1) {
            g_ShowMenu = !g_ShowMenu;
            return 0;
        }
    }
    if (uMsg == WM_KEYUP || uMsg == WM_SYSKEYUP) {
        if (wParam == VK_INSERT || wParam == VK_F1) {
            return 0;
        }
    }

    if (g_ShowMenu) {
        if (ImGui_ImplWin32_WndProcHandler(hWnd, uMsg, wParam, lParam))
            return 0;

        ImGuiIO& io = ImGui::GetIO();
        if (io.WantCaptureMouse && (uMsg >= WM_MOUSEFIRST && uMsg <= WM_MOUSELAST))
            return 0;
        if (io.WantCaptureKeyboard && (uMsg >= WM_KEYFIRST && uMsg <= WM_KEYLAST))
            return 0;
    }

    return CallWindowProc(oWndProc, hWnd, uMsg, wParam, lParam);
}

// ─── Clean Uninject Routine ─────────────────────────────────────────────────
static DWORD WINAPI UninjectThread(LPVOID /*lpParam*/) {
    g_Uninjecting = true;
    g_ShowMenu = false;
    bEnableESP = false;
    bEnableAimbot = false;
    bEnableTeleportKill = false;
    bGodMode = false;

    Sleep(120);

    // 1. Restore WndProc
    if (g_hWnd && oWndProc) {
        SetWindowLongPtr(g_hWnd, GWLP_WNDPROC, (LONG_PTR)oWndProc);
    }

    // 2. Remove hooks
    MH_DisableHook(MH_ALL_HOOKS);
    MH_Uninitialize();

    Sleep(80);

    // 3. Destroy ImGui
    if (g_IsInitialized) {
        ImGui_ImplDX11_Shutdown();
        ImGui_ImplWin32_Shutdown();
        ImGui::DestroyContext();
    }

    // 4. Release D3D11 resources
    CleanupRTV();

    Sleep(100);

    // 5. Unload DLL from process memory
    if (g_hDllModule) {
        FreeLibraryAndExitThread(g_hDllModule, 0);
    }
    return 0;
}

void RequestUninject() {
    CreateThread(nullptr, 0, UninjectThread, nullptr, 0, nullptr);
}

// ─── Helper to resolve bone world & screen position ──────────────────────────
static void ResolveBoneSafe(void* mainCam, void* rbPtr, BonePoint& outBone) {
    outBone.valid = false;
    if (!rbPtr || !mainCam) return;

    if (g_Il2Cpp.GetRigidbodyPosition(rbPtr, &outBone.world)) {
        if (fabsf(outBone.world.x) < 0.001f && fabsf(outBone.world.y) < 0.001f && fabsf(outBone.world.z) < 0.001f)
            return;

        if (g_Il2Cpp.WorldToScreen(mainCam, outBone.world, &outBone.screen)) {
            if (outBone.screen.z > 0.5f && outBone.screen.z < 600.0f &&
                !std::isnan(outBone.screen.z) && !std::isinf(outBone.screen.z) &&
                !std::isnan(outBone.screen.x) && !std::isnan(outBone.screen.y)) {

                ImGuiIO& io = ImGui::GetIO();
                float sw = io.DisplaySize.x;
                float sh = io.DisplaySize.y;
                if (outBone.screen.x >= -300.0f && outBone.screen.x <= sw + 300.0f &&
                    outBone.screen.y >= -300.0f && outBone.screen.y <= sh + 300.0f) {
                    outBone.valid = true;
                }
            }
        }
    }
}

// ─── Helper to get the currently active camera (Alive or Dead) ───────────────
static void* GetCurrentGameCamera() {
    // 1. Prioritize Local PlayerMovement -> _cam -> cam
    if (g_PlayerMovementClass) {
        Il2CppArray* pmArr = g_Il2Cpp.FindObjectsOfType(g_PlayerMovementClass);
        if (pmArr) {
            uintptr_t cnt = *(uintptr_t*)((char*)pmArr + 0x18);
            void** items = (void**)((char*)pmArr + 0x20);
            for (uintptr_t i = 0; i < cnt; i++) {
                if (items[i] && g_Il2Cpp.IsLocalPlayer(items[i])) {
                    void* rCamCtrl = *(void**)((char*)items[i] + 0x220);
                    if (rCamCtrl) {
                        void* rCam = *(void**)((char*)rCamCtrl + 0x140);
                        if (rCam) return rCam;
                    }
                }
            }
        }
    }

    // 2. Prioritize Local RagdollCameraController -> cam
    if (g_RagdollCamClass) {
        Il2CppArray* camArr = g_Il2Cpp.FindObjectsOfType(g_RagdollCamClass);
        if (camArr) {
            uintptr_t cnt = *(uintptr_t*)((char*)camArr + 0x18);
            void** items = (void**)((char*)camArr + 0x20);
            for (uintptr_t i = 0; i < cnt; i++) {
                if (items[i] && g_Il2Cpp.IsLocalPlayer(items[i])) {
                    void* rCam = *(void**)((char*)items[i] + 0x140);
                    if (rCam) return rCam;
                }
            }
        }
    }

    // 3. Prioritize Local Player -> PlayerMovement -> _cam -> cam
    if (g_PlayerClass && g_PlayerMovementClass) {
        Il2CppArray* pArr = g_Il2Cpp.FindObjectsOfType(g_PlayerClass);
        if (pArr) {
            uintptr_t cnt = *(uintptr_t*)((char*)pArr + 0x18);
            void** items = (void**)((char*)pArr + 0x20);
            for (uintptr_t i = 0; i < cnt; i++) {
                if (items[i] && g_Il2Cpp.IsLocalPlayer(items[i])) {
                    void* pm = g_Il2Cpp.GetComponent(items[i], g_PlayerMovementClass);
                    if (pm) {
                        void* rCamCtrl = *(void**)((char*)pm + 0x220);
                        if (rCamCtrl) {
                            void* rCam = *(void**)((char*)rCamCtrl + 0x140);
                            if (rCam) return rCam;
                        }
                    }
                }
            }
        }
    }

    // 4. Fallback to Camera.main / current / allCameras (only when dead, spectating, or in menu)
    return g_Il2Cpp.GetMainCamera();
}

// ─── Safe Frame Update (Executes on Render Thread — No Multithreading Crashes)
static void UpdateFrameESPData() {
    if (!bEnableESP && !bEnableAimbot) {
        g_ESPData.clear();
        return;
    }

    void* activeCam = GetCurrentGameCamera();
    if (!activeCam) return;

    std::vector<PlayerESPData> newData;

    Il2CppArray* arr = nullptr;
    if (g_PlayerClass) {
        arr = g_Il2Cpp.FindObjectsOfType(g_PlayerClass);
    }

    if (arr) {
        uintptr_t count = *(uintptr_t*)((char*)arr + 0x18);
        void**    items = (void**)    ((char*)arr + 0x20);

        // 1. Identify local player and their real team
        bool localAwayTeam = false;
        bool foundLocal = false;

        for (uintptr_t i = 0; i < count; i++) {
            void* playerObj = items[i];
            if (!playerObj) continue;

            if (g_Il2Cpp.IsLocalPlayer(playerObj)) {
                foundLocal = true;
                if (g_PlayerMovementClass) {
                    void* pm = g_Il2Cpp.GetComponent(playerObj, g_PlayerMovementClass);
                    if (pm) {
                        localAwayTeam = *(bool*)((char*)pm + 0x1C4);
                    }
                }
                break;
            }
        }

        for (uintptr_t i = 0; i < count; i++) {
            void* playerObj = items[i];
            if (!playerObj) continue;

            // Filter out inactive game objects in hierarchy
            if (!g_Il2Cpp.IsGameObjectActiveInHierarchy(playerObj))
                continue;

            // Filter out despawned/dormant network objects
            if (!g_Il2Cpp.IsSpawned(playerObj))
                continue;

            PlayerESPData data{};
            data.isLocal = g_Il2Cpp.IsLocalPlayer(playerObj);

            // Read Health & Team first
            data.maxHp = 100;
            data.hp    = 100;
            data.isDead= false;

            if (g_HealthClass) {
                void* healthComp = g_Il2Cpp.GetComponent(playerObj, g_HealthClass);
                if (healthComp) {
                    data.maxHp = *(int*)((char*)healthComp + 0xF8);
                    if (g_GetCurrentHealth) {
                        void* exc = nullptr;
                        Il2CppObject* res = g_Il2Cpp.il2cpp_runtime_invoke(
                            g_GetCurrentHealth, healthComp, nullptr, &exc);
                        if (res && !exc) {
                            data.hp = *(int*)((char*)res + 0x10);
                        }
                    }
                    if (g_IsDeadMethod) {
                        void* exc = nullptr;
                        Il2CppObject* res = g_Il2Cpp.il2cpp_runtime_invoke(
                            g_IsDeadMethod, healthComp, nullptr, &exc);
                        if (res && !exc) {
                            data.isDead = *(bool*)((char*)res + 0x10);
                        }
                    }
                }
            }

            if (bIgnoreDead && (data.isDead || data.hp <= 0)) {
                continue;
            }

            // Accurate Team resolution from PlayerMovement primitive bool
            if (g_PlayerMovementClass) {
                void* pm = g_Il2Cpp.GetComponent(playerObj, g_PlayerMovementClass);
                if (pm) {
                    data.awayTeam = *(bool*)((char*)pm + 0x1C4);
                }
            } else if (g_SharedRefClass) {
                void* sharedRef = g_Il2Cpp.GetComponent(playerObj, g_SharedRefClass);
                if (sharedRef) {
                    data.awayTeam = *(bool*)((char*)sharedRef + 0x108);
                }
            }

            // In Deathmatch / FFA: treat everyone as enemy unless teammates filter is explicitly enabled
            if (bIgnoreTeammates && foundLocal && (data.awayTeam == localAwayTeam) && !data.isLocal) {
                continue;
            }

            data.isEnemy = foundLocal ? (data.awayTeam != localAwayTeam) : true;

            // Read all 15 physics Rigidbody pointers
            void* spineRb     = *(void**)((char*)playerObj + 0x100);
            void* rootRb      = *(void**)((char*)playerObj + 0x108);
            void* lFootRb     = *(void**)((char*)playerObj + 0x110);
            void* rFootRb     = *(void**)((char*)playerObj + 0x118);
            void* lKneeRb     = *(void**)((char*)playerObj + 0x120);
            void* rKneeRb     = *(void**)((char*)playerObj + 0x128);
            void* lHandRb     = *(void**)((char*)playerObj + 0x130);
            void* rHandRb     = *(void**)((char*)playerObj + 0x138);
            void* lElbowRb    = *(void**)((char*)playerObj + 0x140);
            void* rElbowRb    = *(void**)((char*)playerObj + 0x148);
            void* lUpperArmRb = *(void**)((char*)playerObj + 0x150);
            void* rUpperArmRb = *(void**)((char*)playerObj + 0x158);
            void* lShoulderRb = *(void**)((char*)playerObj + 0x160);
            void* rShoulderRb = *(void**)((char*)playerObj + 0x168);
            void* chestRb     = *(void**)((char*)playerObj + 0x170);

            ResolveBoneSafe(activeCam, chestRb,     data.chest);
            ResolveBoneSafe(activeCam, spineRb,     data.spine);
            ResolveBoneSafe(activeCam, rootRb,      data.root);
            ResolveBoneSafe(activeCam, lShoulderRb, data.lShoulder);
            ResolveBoneSafe(activeCam, lUpperArmRb, data.lUpperArm);
            ResolveBoneSafe(activeCam, lElbowRb,    data.lElbow);
            ResolveBoneSafe(activeCam, lHandRb,     data.lHand);
            ResolveBoneSafe(activeCam, rShoulderRb, data.rShoulder);
            ResolveBoneSafe(activeCam, rUpperArmRb, data.rUpperArm);
            ResolveBoneSafe(activeCam, rElbowRb,    data.rElbow);
            ResolveBoneSafe(activeCam, rHandRb,     data.rHand);
            ResolveBoneSafe(activeCam, lKneeRb,     data.lKnee);
            ResolveBoneSafe(activeCam, lFootRb,     data.lFoot);
            ResolveBoneSafe(activeCam, rKneeRb,     data.rKnee);
            ResolveBoneSafe(activeCam, rFootRb,     data.rFoot);

            if (!data.chest.valid && !data.root.valid)
                continue;

            // Synthesize Head point from Chest position (+0.40m up)
            if (data.chest.valid) {
                data.head.world = data.chest.world + Vector3(0.0f, 0.40f, 0.0f);
                if (g_Il2Cpp.WorldToScreen(activeCam, data.head.world, &data.head.screen)) {
                    if (data.head.screen.z > 0.3f) data.head.valid = true;
                }
            }

            std::vector<Vector3> validPoints;
            auto AddPoint = [&](const BonePoint& b) {
                if (b.valid) validPoints.push_back(b.screen);
            };

            AddPoint(data.head);
            AddPoint(data.chest);
            AddPoint(data.spine);
            AddPoint(data.root);
            AddPoint(data.lShoulder);
            AddPoint(data.lUpperArm);
            AddPoint(data.lElbow);
            AddPoint(data.lHand);
            AddPoint(data.rShoulder);
            AddPoint(data.rUpperArm);
            AddPoint(data.rElbow);
            AddPoint(data.rHand);
            AddPoint(data.lKnee);
            AddPoint(data.lFoot);
            AddPoint(data.rKnee);
            AddPoint(data.rFoot);

            if (validPoints.size() >= 2) {
                float minX = 999999.0f, maxX = -999999.0f;
                float minY = 999999.0f, maxY = -999999.0f;
                float totalZ = 0.0f;

                ImGuiIO& io = ImGui::GetIO();
                float sh = io.DisplaySize.y;

                for (const auto& pt : validPoints) {
                    float sx = pt.x;
                    float sy = sh - pt.y;

                    if (sx < minX) minX = sx;
                    if (sx > maxX) maxX = sx;
                    if (sy < minY) minY = sy;
                    if (sy > maxY) maxY = sy;

                    totalZ += pt.z;
                }

                data.distance = totalZ / (float)validPoints.size();
                if (data.distance > fMaxDistance || data.distance < 0.2f) continue;

                if ((maxX - minX) < 3.0f && (maxY - minY) < 3.0f)
                    continue;

                float padX = (data.distance > 0.1f) ? (14.0f / data.distance * 2.0f) : 10.0f;
                float padY = (data.distance > 0.1f) ? (10.0f / data.distance * 2.0f) : 8.0f;
                if (padX < 6.0f) padX = 6.0f;
                if (padX > 30.0f) padX = 30.0f;
                if (padY < 6.0f) padY = 6.0f;
                if (padY > 25.0f) padY = 25.0f;

                data.boxMinX = minX - padX;
                data.boxMaxX = maxX + padX;
                data.boxMinY = minY - padY;
                data.boxMaxY = maxY + padY;

                float boxW = data.boxMaxX - data.boxMinX;
                float boxH = data.boxMaxY - data.boxMinY;

                float sw = io.DisplaySize.x;
                if (boxW < 4.0f || boxH < 4.0f || boxW > sw * 0.75f || boxH > sh * 0.85f)
                    continue;

                if (data.boxMaxX < -50.0f || data.boxMinX > sw + 50.0f || data.boxMaxY < -50.0f || data.boxMinY > sh + 50.0f)
                    continue;

                data.hasBox  = true;

                if (data.chest.valid) {
                    data.aimScreenPos = data.chest.screen;
                } else if (data.head.valid) {
                    data.aimScreenPos = data.head.screen;
                } else {
                    data.aimScreenPos = validPoints[0];
                }

                newData.push_back(data);
            }
        }
    }

    g_ESPData = std::move(newData);
}

// ─── ESP Drawing (With Glow & Dynamic Custom Colors) ─────────────────────────
static void DrawESP(ImGuiIO& io) {
    auto* dl = ImGui::GetBackgroundDrawList();
    float sw = io.DisplaySize.x;
    float sh = io.DisplaySize.y;

    auto MakeGlowColor = [](float* baseCol, float alphaMultiplier) -> ImU32 {
        float a = baseCol[3] * alphaMultiplier;
        if (a > 1.0f) a = 1.0f;
        if (a < 0.0f) a = 0.0f;
        return ImGui::ColorConvertFloat4ToU32(ImVec4(baseCol[0], baseCol[1], baseCol[2], a));
    };

    auto DrawBoneLine = [&](const BonePoint& a, const BonePoint& b, float* baseCol, float thick) {
        if (a.valid && b.valid) {
            ImVec2 p1(a.screen.x, sh - a.screen.y);
            ImVec2 p2(b.screen.x, sh - b.screen.y);

            if ((p1.x < -100.0f && p2.x < -100.0f) || (p1.x > sw + 100.0f && p2.x > sw + 100.0f) ||
                (p1.y < -100.0f && p2.y < -100.0f) || (p1.y > sh + 100.0f && p2.y > sh + 100.0f)) {
                return;
            }

            if (bEnableGlow) {
                ImU32 glowColOuter = MakeGlowColor(baseCol, 0.18f * fGlowIntensity);
                ImU32 glowColMid   = MakeGlowColor(baseCol, 0.35f * fGlowIntensity);
                dl->AddLine(p1, p2, glowColOuter, thick + 4.0f);
                dl->AddLine(p1, p2, glowColMid,   thick + 2.0f);
            }

            ImU32 coreCol = MakeGlowColor(baseCol, 1.0f);
            dl->AddLine(p1, p2, coreCol, thick);
        }
    };

    for (const auto& p : g_ESPData) {
        if (!p.hasBox) continue;
        if (p.isLocal && bIgnoreLocal) continue;

        float* pCol = p.isEnemy ? colEnemy : colTeam;

        ImU32 colMain = MakeGlowColor(pCol, 1.0f);
        ImU32 colTrac = MakeGlowColor(colTracers, 1.0f);

        // 1. Dynamic Skeleton ESP
        if (bDrawSkeleton) {
            DrawBoneLine(p.head, p.chest, colSkeleton, fSkeletonThickness + 0.5f);
            DrawBoneLine(p.chest, p.spine, colSkeleton, fSkeletonThickness + 0.5f);
            DrawBoneLine(p.spine, p.root, colSkeleton, fSkeletonThickness + 0.5f);

            // Left Arm
            DrawBoneLine(p.chest, p.lShoulder, colSkeleton, fSkeletonThickness);
            DrawBoneLine(p.lShoulder, p.lUpperArm, colSkeleton, fSkeletonThickness);
            DrawBoneLine(p.lUpperArm, p.lElbow, colSkeleton, fSkeletonThickness);
            DrawBoneLine(p.lElbow, p.lHand, colSkeleton, fSkeletonThickness);

            // Right Arm
            DrawBoneLine(p.chest, p.rShoulder, colSkeleton, fSkeletonThickness);
            DrawBoneLine(p.rShoulder, p.rUpperArm, colSkeleton, fSkeletonThickness);
            DrawBoneLine(p.rUpperArm, p.rElbow, colSkeleton, fSkeletonThickness);
            DrawBoneLine(p.rElbow, p.rHand, colSkeleton, fSkeletonThickness);

            // Left Leg
            DrawBoneLine(p.root, p.lKnee, colSkeleton, fSkeletonThickness);
            DrawBoneLine(p.lKnee, p.lFoot, colSkeleton, fSkeletonThickness);

            // Right Leg
            DrawBoneLine(p.root, p.rKnee, colSkeleton, fSkeletonThickness);
            DrawBoneLine(p.rKnee, p.rFoot, colSkeleton, fSkeletonThickness);
        }

        // 2. Head Circle ESP
        if (bDrawHeadCircle && p.head.valid) {
            float headRadius = (p.distance > 0.1f) ? (18.0f / p.distance * fHeadCircleSize) : 8.0f;
            if (headRadius < 3.0f) headRadius = 3.0f;
            if (headRadius > 35.0f) headRadius = 35.0f;

            ImVec2 headPos(p.head.screen.x, sh - p.head.screen.y);

            if (bEnableGlow) {
                ImU32 glowHead1 = MakeGlowColor(colHeadCircle, 0.15f * fGlowIntensity);
                ImU32 glowHead2 = MakeGlowColor(colHeadCircle, 0.35f * fGlowIntensity);
                dl->AddCircle(headPos, headRadius + 3.0f, glowHead1, 16, 3.0f);
                dl->AddCircle(headPos, headRadius + 1.5f, glowHead2, 16, 2.0f);
            }

            ImU32 colHead = MakeGlowColor(colHeadCircle, 1.0f);
            dl->AddCircle(headPos, headRadius, colHead, 16, 1.8f);
        }

        // 3. Dynamic 2D Hitbox Bounding Box
        if (bDrawBoxes) {
            ImVec2 bMin(p.boxMinX, p.boxMinY);
            ImVec2 bMax(p.boxMaxX, p.boxMaxY);

            if (bEnableGlow) {
                ImU32 glowBoxOuter = MakeGlowColor(pCol, 0.15f * fGlowIntensity);
                ImU32 glowBoxMid   = MakeGlowColor(pCol, 0.30f * fGlowIntensity);
                dl->AddRect(ImVec2(bMin.x - 3.0f, bMin.y - 3.0f), ImVec2(bMax.x + 3.0f, bMax.y + 3.0f), glowBoxOuter, 4.0f, 0, fBoxThickness + 3.0f);
                dl->AddRect(ImVec2(bMin.x - 1.5f, bMin.y - 1.5f), ImVec2(bMax.x + 1.5f, bMax.y + 1.5f), glowBoxMid,   3.0f, 0, fBoxThickness + 1.5f);
            }

            dl->AddRect(bMin, bMax, colMain, 2.0f, 0, fBoxThickness);
        }

        // 4. Tracers (Snaplines)
        if (bDrawTracers) {
            ImVec2 originPos;
            if (iTracerOrigin == 0)      originPos = ImVec2(sw * 0.5f, sh);
            else if (iTracerOrigin == 1) originPos = ImVec2(sw * 0.5f, sh * 0.5f);
            else                         originPos = ImVec2(sw * 0.5f, 0.0f);

            ImVec2 targetPos;
            if (p.chest.valid) {
                targetPos = ImVec2(p.chest.screen.x, sh - p.chest.screen.y);
            } else {
                targetPos = ImVec2((p.boxMinX + p.boxMaxX) * 0.5f, p.boxMaxY);
            }

            if (bEnableGlow) {
                ImU32 glowTracOuter = MakeGlowColor(colTracers, 0.20f * fGlowIntensity);
                dl->AddLine(originPos, targetPos, glowTracOuter, fTracerThickness + 2.5f);
            }

            dl->AddLine(originPos, targetPos, colTrac, fTracerThickness);
        }

        // 5. Health Bar
        if (bDrawHealthBar && p.maxHp > 0) {
            float ratio = (float)p.hp / (float)p.maxHp;
            if (ratio < 0.0f) ratio = 0.0f;
            if (ratio > 1.0f) ratio = 1.0f;

            float boxH   = p.boxMaxY - p.boxMinY;
            float barX   = p.boxMinX - 7.0f;
            float barTop = p.boxMinY;
            float barBot = p.boxMaxY;

            dl->AddRectFilled(
                ImVec2(barX - 4.0f, barTop),
                ImVec2(barX, barBot),
                IM_COL32(10, 12, 16, 200)
            );

            ImU32 hpCol = ratio > 0.6f
                ? IM_COL32(50,  230, 80,  255)
                : ratio > 0.3f
                    ? IM_COL32(250, 210, 40,  255)
                    : IM_COL32(255, 45,  45,  255);

            dl->AddRectFilled(
                ImVec2(barX - 4.0f, barBot - boxH * ratio),
                ImVec2(barX, barBot),
                hpCol
            );
        }

        // 6. Distance & Info Text
        if (bDrawInfoText) {
            char buf[48];
            snprintf(buf, sizeof(buf), "%s | %d HP [%.0fm]", p.isEnemy ? "ENEMY" : "TEAM", p.hp, p.distance);

            dl->AddText(ImVec2(p.boxMinX + 1.0f, p.boxMinY - 17.0f + 1.0f), IM_COL32(0, 0, 0, 220), buf);
            dl->AddText(ImVec2(p.boxMinX, p.boxMinY - 17.0f), colMain, buf);
        }
    }

    // Draw Aimbot FOV circle if enabled
    if (bEnableAimbot && bDrawAimbotFOV) {
        if (bEnableGlow) {
            dl->AddCircle(
                ImVec2(sw * 0.5f, sh * 0.5f),
                aimbotFOV,
                IM_COL32(120, 180, 255, (int)(45 * fGlowIntensity)),
                64,
                3.0f
            );
        }
        dl->AddCircle(
            ImVec2(sw * 0.5f, sh * 0.5f),
            aimbotFOV,
            IM_COL32(255, 255, 255, 120),
            64,
            1.5f
        );
    }

    // Draw Silent Aim FOV circle if enabled
    if (bEnableSilentAim && bDrawSilentAimFOV && !bSilentAimFull360) {
        if (bEnableGlow) {
            dl->AddCircle(
                ImVec2(sw * 0.5f, sh * 0.5f),
                fSilentAimFOV,
                IM_COL32(255, 90, 140, (int)(45 * fGlowIntensity)),
                64,
                3.0f
            );
        }
        dl->AddCircle(
            ImVec2(sw * 0.5f, sh * 0.5f),
            fSilentAimFOV,
            IM_COL32(255, 120, 170, 140),
            64,
            1.5f
        );
    }
}

// ─── Configurable & Smooth Aimbot (Default Key: Left Alt) ───────────────────
static void DoAimbot(ImGuiIO& io) {
    if (g_ShowMenu) return;
    if (!bEnableAimbot) return;
    if (!IsKeyActive(iAimbotKey)) return;

    float cx = io.DisplaySize.x * 0.5f;
    float cy = io.DisplaySize.y * 0.5f;
    float sh = io.DisplaySize.y;

    float bestDist = aimbotFOV;
    float tgtX = -1.0f, tgtY = -1.0f;

    for (const auto& p : g_ESPData) {
        if (!p.hasBox || (p.isLocal && bIgnoreLocal))
            continue;
        if (bIgnoreDead && (p.isDead || p.hp <= 0))
            continue;
        if (bIgnoreTeammates && !p.isEnemy)
            continue;

        Vector3 targetBone = (iAimbotTarget == 1 && p.head.valid) ? p.head.screen : p.aimScreenPos;
        if (targetBone.z <= 0.5f || std::isnan(targetBone.x) || std::isnan(targetBone.y))
            continue;

        float sx = targetBone.x;
        float sy = sh - targetBone.y;

        float dist = sqrtf((sx - cx) * (sx - cx) + (sy - cy) * (sy - cy));
        if (dist < bestDist) {
            bestDist = dist;
            tgtX = sx;
            tgtY = sy;
        }
    }

    if (tgtX > 0.0f && tgtY > 0.0f) {
        float smooth = (aimbotSmooth < 1.0f) ? 1.0f : aimbotSmooth;
        float dx = (tgtX - cx) / smooth;
        float dy = (tgtY - cy) / smooth;

        if (!std::isnan(dx) && !std::isinf(dx) && !std::isnan(dy) && !std::isinf(dy)) {
            if (dx >  aimbotMaxSpeed) dx =  aimbotMaxSpeed;
            if (dx < -aimbotMaxSpeed) dx = -aimbotMaxSpeed;
            if (dy >  aimbotMaxSpeed) dy =  aimbotMaxSpeed;
            if (dy < -aimbotMaxSpeed) dy = -aimbotMaxSpeed;

            mouse_event(MOUSEEVENTF_MOVE, (DWORD)(long)dx, (DWORD)(long)dy, 0, 0);
        }
    }
}

// ─── Silent Aim Hook & Logic (100% Hit Any Shot Anywhere) ────────────────────
static bool GetSilentAimTargetPosition(Vector3* outTargetPos) {
    if (!outTargetPos || !g_PlayerClass) return false;

    Il2CppArray* arr = g_Il2Cpp.FindObjectsOfType(g_PlayerClass);
    if (!arr) return false;

    uintptr_t count = *(uintptr_t*)((char*)arr + 0x18);
    void** items = (void**)((char*)arr + 0x20);

    void* localPlayer = nullptr;
    bool localAwayTeam = false;
    bool foundLocal = false;

    for (uintptr_t i = 0; i < count; i++) {
        void* p = items[i];
        if (p && g_Il2Cpp.IsLocalPlayer(p)) {
            localPlayer = p;
            foundLocal = true;
            if (g_PlayerMovementClass) {
                void* pm = g_Il2Cpp.GetComponent(p, g_PlayerMovementClass);
                if (pm) localAwayTeam = *(bool*)((char*)pm + 0x1C4);
            }
            break;
        }
    }

    void* activeCam = GetCurrentGameCamera();
    ImGuiIO& io = ImGui::GetIO();
    float cx = io.DisplaySize.x * 0.5f;
    float cy = io.DisplaySize.y * 0.5f;
    float sh = io.DisplaySize.y;

    float bestScore = 9999999.0f;
    Vector3 bestPos{};
    bool found = false;

    for (uintptr_t i = 0; i < count; i++) {
        void* p = items[i];
        if (!p || p == localPlayer || g_Il2Cpp.IsLocalPlayer(p)) continue;
        if (!g_Il2Cpp.IsGameObjectActiveInHierarchy(p) || !g_Il2Cpp.IsSpawned(p)) continue;

        // Health / Dead check
        int enemyHp = 100;
        if (g_HealthClass) {
            void* hComp = g_Il2Cpp.GetComponent(p, g_HealthClass);
            if (hComp) {
                if (g_IsDeadMethod) {
                    void* exc = nullptr;
                    Il2CppObject* res = g_Il2Cpp.il2cpp_runtime_invoke(g_IsDeadMethod, hComp, nullptr, &exc);
                    if (res && !exc && *(bool*)((char*)res + 0x10)) continue;
                }
                if (g_GetCurrentHealth) {
                    void* exc = nullptr;
                    Il2CppObject* res = g_Il2Cpp.il2cpp_runtime_invoke(g_GetCurrentHealth, hComp, nullptr, &exc);
                    if (res && !exc) enemyHp = *(int*)((char*)res + 0x10);
                    if (enemyHp <= 0) continue;
                }
            }
        }

        // Team check
        bool enemyAwayTeam = false;
        void* enemyPM = g_PlayerMovementClass ? g_Il2Cpp.GetComponent(p, g_PlayerMovementClass) : nullptr;
        if (enemyPM) {
            enemyAwayTeam = *(bool*)((char*)enemyPM + 0x1C4);
        } else if (g_SharedRefClass) {
            void* sr = g_Il2Cpp.GetComponent(p, g_SharedRefClass);
            if (sr) enemyAwayTeam = *(bool*)((char*)sr + 0x108);
        }

        if (bIgnoreTeammates && foundLocal && (enemyAwayTeam == localAwayTeam)) continue;

        // Target bone position
        void* chestRb = *(void**)((char*)p + 0x170);
        void* rootRb  = *(void**)((char*)p + 0x108);
        void* targetRb = chestRb ? chestRb : rootRb;
        if (!targetRb) continue;

        Vector3 bonePos{};
        if (!g_Il2Cpp.GetRigidbodyPosition(targetRb, &bonePos)) continue;
        if (fabsf(bonePos.x) < 0.001f && fabsf(bonePos.y) < 0.001f && fabsf(bonePos.z) < 0.001f) continue;

        if (iSilentAimTarget == 1) {
            // Head position (Chest + 0.40m up)
            bonePos = bonePos + Vector3(0.0f, 0.40f, 0.0f);
        }

        float score = 0.0f;
        if (!bSilentAimFull360 && activeCam) {
            Vector3 screenPos{};
            if (!g_Il2Cpp.WorldToScreen(activeCam, bonePos, &screenPos) || screenPos.z <= 0.3f) {
                continue;
            }
            float sx = screenPos.x;
            float sy = sh - screenPos.y;
            float distFromCenter = sqrtf((sx - cx) * (sx - cx) + (sy - cy) * (sy - cy));
            if (distFromCenter > fSilentAimFOV) continue;
            score = distFromCenter;
        } else {
            // Full 360 map aimbot: prioritize nearest target
            score = 1.0f;
        }

        if (score < bestScore) {
            bestScore = score;
            bestPos = bonePos;
            found = true;
        }
    }

    if (found) {
        *outTargetPos = bestPos;
        return true;
    }
    return false;
}

typedef void (*CMDShoot_t)(void* __this, Il2CppArray* _cameraPosition, Il2CppArray* _cameraForward, uint32_t tick, const MethodInfo* method);
CMDShoot_t oCMDShoot = nullptr;

void hkCMDShoot(void* __this, Il2CppArray* _cameraPosition, Il2CppArray* _cameraForward, uint32_t tick, const MethodInfo* method) {
    if (bEnableSilentAim && _cameraPosition && _cameraForward) {
        Vector3 targetWorldPos{};
        if (GetSilentAimTargetPosition(&targetWorldPos)) {
            Vector3 camPos{};
            if (g_UnpackShortMethod) {
                void* args[1] = { _cameraPosition };
                void* exc = nullptr;
                Il2CppObject* res = g_Il2Cpp.il2cpp_runtime_invoke(g_UnpackShortMethod, nullptr, args, &exc);
                if (!exc && res) {
                    camPos = *(Vector3*)((char*)res + 0x10);
                }
            }

            if (camPos.LengthSq() < 0.0001f) {
                void* activeCam = GetCurrentGameCamera();
                if (activeCam) {
                    void* camTr = g_Il2Cpp.GetComponentTransform(activeCam);
                    if (camTr) g_Il2Cpp.GetTransformPosition(camTr, &camPos);
                }
            }

            Vector3 aimDir = targetWorldPos - camPos;
            float len = aimDir.Length();
            if (len > 0.001f) {
                aimDir = aimDir * (1.0f / len);

                if (g_PackDirectionMethod) {
                    void* args[1] = { &aimDir };
                    void* exc = nullptr;
                    Il2CppObject* packedArr = g_Il2Cpp.il2cpp_runtime_invoke(g_PackDirectionMethod, nullptr, args, &exc);
                    if (!exc && packedArr) {
                        _cameraForward = (Il2CppArray*)packedArr;
                    }
                }
            }
        }
    }

    if (oCMDShoot) {
        oCMDShoot(__this, _cameraPosition, _cameraForward, tick, method);
    }
}

// ─── Instant Teleportation & Auto-Shoot Kill Aura (Auto-Cycle Targets) ───────
static uintptr_t g_CurrentTeleportTarget = 0;
static ULONGLONG g_LastTeleShootTime = 0;

static void DoTeleportKill(ImGuiIO& io) {
    if (g_ShowMenu) return;
    if (!bEnableTeleportKill) return;
    if (bTeleportHoldKey && !IsKeyActive(iTeleportKey)) return;
    if (!g_PlayerClass) return;

    __try {
        ULONGLONG now = GetTickCount64();

        Il2CppArray* arr = g_Il2Cpp.FindObjectsOfType(g_PlayerClass);
        if (!arr) return;

        uintptr_t count = *(uintptr_t*)((char*)arr + 0x18);
        void** items = (void**)((char*)arr + 0x20);

        void* localPlayer = nullptr;
        void* localPlayerMovement = nullptr;
        bool localAwayTeam = false;
        bool foundLocal = false;

        for (uintptr_t i = 0; i < count; i++) {
            void* p = items[i];
            if (p && g_Il2Cpp.IsLocalPlayer(p)) {
                localPlayer = p;
                foundLocal = true;
                if (g_PlayerMovementClass) {
                    localPlayerMovement = g_Il2Cpp.GetComponent(p, g_PlayerMovementClass);
                    if (localPlayerMovement) {
                        localAwayTeam = *(bool*)((char*)localPlayerMovement + 0x1C4);
                    }
                }
                break;
            }
        }

        if (!localPlayer || !foundLocal) return;

        // Check if local player is dead
        if (g_HealthClass) {
            void* hComp = g_Il2Cpp.GetComponent(localPlayer, g_HealthClass);
            if (hComp && g_IsDeadMethod) {
                void* exc = nullptr;
                Il2CppObject* res = g_Il2Cpp.il2cpp_runtime_invoke(g_IsDeadMethod, hComp, nullptr, &exc);
                if (res && !exc && *(bool*)((char*)res + 0x10)) {
                    return;
                }
            }
        }

        // Helper lambda to check if a player pointer is valid and alive
        auto IsValidAliveEnemy = [&](void* p, int& outHp, Vector3& outPos, Vector3& outFwd) -> bool {
            if (!p || p == localPlayer || g_Il2Cpp.IsLocalPlayer(p)) return false;
            if (!g_Il2Cpp.IsGameObjectActiveInHierarchy(p) || !g_Il2Cpp.IsSpawned(p)) return false;

            outHp = 100;
            if (g_HealthClass) {
                void* hComp = g_Il2Cpp.GetComponent(p, g_HealthClass);
                if (hComp) {
                    if (g_IsDeadMethod) {
                        void* exc = nullptr;
                        Il2CppObject* res = g_Il2Cpp.il2cpp_runtime_invoke(g_IsDeadMethod, hComp, nullptr, &exc);
                        if (res && !exc && *(bool*)((char*)res + 0x10)) return false;
                    }
                    if (g_GetCurrentHealth) {
                        void* exc = nullptr;
                        Il2CppObject* res = g_Il2Cpp.il2cpp_runtime_invoke(g_GetCurrentHealth, hComp, nullptr, &exc);
                        if (res && !exc) outHp = *(int*)((char*)res + 0x10);
                        if (outHp <= 0) return false;
                    }
                }
            }

            bool enemyAwayTeam = false;
            void* enemyPM = g_PlayerMovementClass ? g_Il2Cpp.GetComponent(p, g_PlayerMovementClass) : nullptr;
            if (enemyPM) {
                enemyAwayTeam = *(bool*)((char*)enemyPM + 0x1C4);
            } else if (g_SharedRefClass) {
                void* sr = g_Il2Cpp.GetComponent(p, g_SharedRefClass);
                if (sr) enemyAwayTeam = *(bool*)((char*)sr + 0x108);
            }

            if (bIgnoreTeammates && foundLocal && (enemyAwayTeam == localAwayTeam)) return false;

            void* chestRb = *(void**)((char*)p + 0x170);
            void* rootRb  = *(void**)((char*)p + 0x108);
            void* targetRb = chestRb ? chestRb : rootRb;
            if (!targetRb) return false;

            if (!g_Il2Cpp.GetRigidbodyPosition(targetRb, &outPos)) return false;
            if (fabsf(outPos.x) < 0.001f && fabsf(outPos.y) < 0.001f && fabsf(outPos.z) < 0.001f) return false;

            outFwd = Vector3(0.0f, 0.0f, 1.0f);
            if (enemyPM) {
                void* orientTr = *(void**)((char*)enemyPM + 0x100);
                if (orientTr) g_Il2Cpp.GetTransformForward(orientTr, &outFwd);
            }

            return true;
        };

        // Get current local root position
        Vector3 localRootPos{};
        void* localRootRb = *(void**)((char*)localPlayer + 0x108);
        void* localChestRb = *(void**)((char*)localPlayer + 0x170);
        void* localMainRb = localRootRb ? localRootRb : localChestRb;
        if (!localMainRb || !g_Il2Cpp.GetRigidbodyPosition(localMainRb, &localRootPos)) return;

        // Verify current target or find next target
        void* chosenEnemy = nullptr;
        Vector3 chosenEnemyPos{};
        Vector3 chosenEnemyFwd(0.0f, 0.0f, 1.0f);
        int chosenEnemyHp = 100;

        if (g_CurrentTeleportTarget != 0) {
            bool targetStillValid = false;
            for (uintptr_t i = 0; i < count; i++) {
                if ((uintptr_t)items[i] == g_CurrentTeleportTarget) {
                    if (IsValidAliveEnemy(items[i], chosenEnemyHp, chosenEnemyPos, chosenEnemyFwd)) {
                        chosenEnemy = items[i];
                        targetStillValid = true;
                    }
                    break;
                }
            }
            if (!targetStillValid) {
                g_CurrentTeleportTarget = 0;
                chosenEnemy = nullptr;
            }
        }

        // If no active target, find the best/random/next alive enemy
        if (!chosenEnemy) {
            std::vector<void*> validEnemies;
            std::vector<Vector3> validPositions;
            std::vector<Vector3> validForwards;
            std::vector<int> validHps;

            for (uintptr_t i = 0; i < count; i++) {
                void* p = items[i];
                Vector3 ePos, eFwd;
                int eHp;
                if (IsValidAliveEnemy(p, eHp, ePos, eFwd)) {
                    validEnemies.push_back(p);
                    validPositions.push_back(ePos);
                    validForwards.push_back(eFwd);
                    validHps.push_back(eHp);
                }
            }

            if (validEnemies.empty()) return;

            size_t selectedIndex = 0;
            if (iTeleportTargetMode == 0) {
                selectedIndex = (size_t)(rand() % validEnemies.size());
            } else if (iTeleportTargetMode == 1) {
                float bestDist = 999999.0f;
                for (size_t i = 0; i < validEnemies.size(); i++) {
                    float d = (validPositions[i] - localRootPos).Length();
                    if (d < bestDist) {
                        bestDist = d;
                        selectedIndex = i;
                    }
                }
            } else if (iTeleportTargetMode == 2) {
                int lowestHp = 999999;
                for (size_t i = 0; i < validEnemies.size(); i++) {
                    if (validHps[i] < lowestHp) {
                        lowestHp = validHps[i];
                        selectedIndex = i;
                    }
                }
            }

            chosenEnemy = validEnemies[selectedIndex];
            chosenEnemyPos = validPositions[selectedIndex];
            chosenEnemyFwd = validForwards[selectedIndex];
            chosenEnemyHp = validHps[selectedIndex];
            g_CurrentTeleportTarget = (uintptr_t)chosenEnemy;
        }

        if (!chosenEnemy) return;

        // Normalize forward vector
        float fwdLen = chosenEnemyFwd.Length();
        if (fwdLen > 0.001f) {
            chosenEnemyFwd = chosenEnemyFwd * (1.0f / fwdLen);
        } else {
            chosenEnemyFwd = Vector3(0.0f, 0.0f, 1.0f);
        }

        // Calculate destination position based on offset mode
        Vector3 destPos = chosenEnemyPos;
        if (iTeleportPosition == 0) {
            // Behind Enemy (Backstab)
            destPos = chosenEnemyPos - chosenEnemyFwd * fTeleportDistance + Vector3(0.0f, fTeleportHeight, 0.0f);
        } else if (iTeleportPosition == 1) {
            // Above Enemy (Sky Drop)
            destPos = chosenEnemyPos + Vector3(0.0f, fTeleportDistance + 1.2f, 0.0f);
        } else if (iTeleportPosition == 2) {
            // In Front of Enemy
            destPos = chosenEnemyPos + chosenEnemyFwd * fTeleportDistance + Vector3(0.0f, fTeleportHeight, 0.0f);
        } else {
            // Directly on Target
            destPos = chosenEnemyPos + Vector3(0.0f, fTeleportHeight, 0.0f);
        }

        // Safe Root & Torso Movement (Crash-Proof for PhysX)
        if (localRootRb) {
            g_Il2Cpp.MoveRigidbodyPosition(localRootRb, destPos);
            g_Il2Cpp.SetRigidbodyLinearVelocity(localRootRb, Vector3(0.0f, 0.0f, 0.0f));
            g_Il2Cpp.SetRigidbodyAngularVelocity(localRootRb, Vector3(0.0f, 0.0f, 0.0f));
            void* tr = g_Il2Cpp.GetComponentTransform(localRootRb);
            if (tr) g_Il2Cpp.SetTransformPosition(tr, destPos);
        }

        if (localChestRb && localChestRb != localRootRb) {
            g_Il2Cpp.MoveRigidbodyPosition(localChestRb, destPos + Vector3(0.0f, 0.35f, 0.0f));
            g_Il2Cpp.SetRigidbodyLinearVelocity(localChestRb, Vector3(0.0f, 0.0f, 0.0f));
            g_Il2Cpp.SetRigidbodyAngularVelocity(localChestRb, Vector3(0.0f, 0.0f, 0.0f));
        }

        // Sync root GameObject transform and orientation
        if (localPlayerMovement) {
            void* rootGo = *(void**)((char*)localPlayerMovement + 0x178);
            if (rootGo) {
                void* rootTr = g_Il2Cpp.GetComponentTransform(rootGo);
                if (rootTr) g_Il2Cpp.SetTransformPosition(rootTr, destPos);
            }
            void* orientTr = *(void**)((char*)localPlayerMovement + 0x100);
            if (orientTr) {
                g_Il2Cpp.SetTransformPosition(orientTr, destPos);
            }
            void* rCamCtrl = *(void**)((char*)localPlayerMovement + 0x220);
            if (rCamCtrl) {
                void* camTarget = *(void**)((char*)rCamCtrl + 0x100);
                if (camTarget) g_Il2Cpp.SetTransformPosition(camTarget, destPos + Vector3(0.0f, 0.5f, 0.0f));
                void* orientTarget = *(void**)((char*)rCamCtrl + 0x110);
                if (orientTarget) g_Il2Cpp.SetTransformPosition(orientTarget, destPos);
            }
        }

        // Auto-Aim Snap to Target Screen Position
        void* activeCam = GetCurrentGameCamera();
        if (bTeleportLookAt && activeCam) {
            float cx = io.DisplaySize.x * 0.5f;
            float cy = io.DisplaySize.y * 0.5f;
            float sh = io.DisplaySize.y;
            Vector3 aimSc{};
            if (g_Il2Cpp.WorldToScreen(activeCam, chosenEnemyPos + Vector3(0.0f, 0.25f, 0.0f), &aimSc) && aimSc.z > 0.3f) {
                float sx = aimSc.x;
                float sy = sh - aimSc.y;
                float dx = sx - cx;
                float dy = sy - cy;
                if (!std::isnan(dx) && !std::isnan(dy) && (fabsf(dx) > 1.0f || fabsf(dy) > 1.0f)) {
                    mouse_event(MOUSEEVENTF_MOVE, (DWORD)(long)dx, (DWORD)(long)dy, 0, 0);
                }
            }
        }

        // Auto-Shooting
        if (bTeleportAutoShoot && (now - g_LastTeleShootTime >= (ULONGLONG)fTeleportShootRate)) {
            g_LastTeleShootTime = now;

            if (g_WeaponManagerClass && g_ClientTryShoot) {
                void* wm = g_Il2Cpp.GetComponent(localPlayer, g_WeaponManagerClass);
                if (wm) {
                    void* activeWeapon = *(void**)((char*)wm + 0x120);
                    if (activeWeapon) {
                        void* exc = nullptr;
                        g_Il2Cpp.il2cpp_runtime_invoke(g_ClientTryShoot, activeWeapon, nullptr, &exc);
                    }
                }
            }

            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {
        // Protected from any physics exception
    }
}

// ─── God Mode Routine (Infinite Health & Health Restoration) ─────────────────
static void DoGodMode() {
    if (!bGodMode || !g_PlayerClass || !g_HealthClass) return;

    __try {
        Il2CppArray* arr = g_Il2Cpp.FindObjectsOfType(g_PlayerClass);
        if (!arr) return;

        uintptr_t count = *(uintptr_t*)((char*)arr + 0x18);
        void** items = (void**)((char*)arr + 0x20);

        for (uintptr_t i = 0; i < count; i++) {
            void* p = items[i];
            if (p && g_Il2Cpp.IsLocalPlayer(p)) {
                void* hComp = g_Il2Cpp.GetComponent(p, g_HealthClass);
                if (hComp) {
                    *(int*)((char*)hComp + 0xF8) = 99999; // maxHealth

                    int currentHp = 100;
                    if (g_GetCurrentHealth) {
                        void* exc = nullptr;
                        Il2CppObject* res = g_Il2Cpp.il2cpp_runtime_invoke(g_GetCurrentHealth, hComp, nullptr, &exc);
                        if (res && !exc) currentHp = *(int*)((char*)res + 0x10);
                    }

                    if (currentHp < 90000 && g_CMDChangeCurrentHealth) {
                        int newHp = 99999;
                        void* args[1] = { &newHp };
                        void* exc = nullptr;
                        g_Il2Cpp.il2cpp_runtime_invoke(g_CMDChangeCurrentHealth, hComp, args, &exc);
                    }
                }
                break;
            }
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {
    }
}

// ─── Weapon Spawner & Stat Modifiers ─────────────────────────────────────────
const char* g_WeaponNames[] = {
    "Burst Rifle",
    "Crossbow",
    "Machete (Melee)",
    "Railgun",
    "Rocket Launcher",
    "Shotgun",
    "Sniper Rifle",
    "Standard Blaster"
};

static void GiveWeapon(int weaponIndex) {
    if (!g_PlayerClass || !g_WeaponManagerClass) return;

    __try {
        Il2CppArray* arr = g_Il2Cpp.FindObjectsOfType(g_PlayerClass);
        if (!arr) return;

        uintptr_t count = *(uintptr_t*)((char*)arr + 0x18);
        void** items = (void**)((char*)arr + 0x20);

        for (uintptr_t i = 0; i < count; i++) {
            void* p = items[i];
            if (p && g_Il2Cpp.IsLocalPlayer(p)) {
                void* wm = g_Il2Cpp.GetComponent(p, g_WeaponManagerClass);
                if (wm) {
                    if (g_PickUpMethod) {
                        void* args[1] = { &weaponIndex };
                        void* exc = nullptr;
                        g_Il2Cpp.il2cpp_runtime_invoke(g_PickUpMethod, wm, args, &exc);
                    }
                    if (g_StartPickUpMethod) {
                        void* args[1] = { &weaponIndex };
                        void* exc = nullptr;
                        g_Il2Cpp.il2cpp_runtime_invoke(g_StartPickUpMethod, wm, args, &exc);
                    }

                    void* weaponsList = *(void**)((char*)wm + 0x110);
                    if (weaponsList) {
                        Il2CppArray* wArr = *(Il2CppArray**)((char*)weaponsList + 0x10);
                        int wCount = *(int*)((char*)weaponsList + 0x18);
                        if (wArr && weaponIndex >= 0 && weaponIndex < wCount) {
                            void** wItems = (void**)((char*)wArr + 0x20);
                            for (int w = 0; w < wCount; w++) {
                                void* wObj = wItems[w];
                                if (!wObj) continue;
                                void* gunGo = *(void**)((char*)wObj + 0xF8);
                                if (w == weaponIndex) {
                                    *(void**)((char*)wm + 0x120) = wObj; // latestActiveWeapon
                                    *(bool*)((char*)wObj + 0x120) = true; // canShoot
                                    *(int*)((char*)wObj + 0x114)  = 99999;// currentAmmo
                                    *(float*)((char*)wObj + 0x110) = 0.0f; // nextTimeToFire
                                    if (gunGo) g_Il2Cpp.SetGameObjectActive(gunGo, true);
                                } else {
                                    if (gunGo) g_Il2Cpp.SetGameObjectActive(gunGo, false);
                                }
                            }
                        }
                    }
                    CheatLog("GiveWeapon: Equipped weapon index %d (%s)", weaponIndex,
                             (weaponIndex >= 0 && weaponIndex < 8) ? g_WeaponNames[weaponIndex] : "Custom");
                }
                break;
            }
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {
    }
}

static void ApplyWeaponStatMods() {
    if (!g_PlayerClass || !g_WeaponManagerClass) return;

    __try {
        Il2CppArray* arr = g_Il2Cpp.FindObjectsOfType(g_PlayerClass);
        if (!arr) return;

        uintptr_t count = *(uintptr_t*)((char*)arr + 0x18);
        void** items = (void**)((char*)arr + 0x20);

        for (uintptr_t i = 0; i < count; i++) {
            void* p = items[i];
            if (p && g_Il2Cpp.IsLocalPlayer(p)) {
                void* wm = g_Il2Cpp.GetComponent(p, g_WeaponManagerClass);
                if (wm) {
                    void* activeWeapon = *(void**)((char*)wm + 0x120);
                    if (activeWeapon) {
                        *(bool*)((char*)activeWeapon + 0x120) = true; // canShoot

                        if (bInfiniteAmmo) {
                            *(int*)((char*)activeWeapon + 0x114) = 99999;
                        }
                        if (bRapidFire) {
                            *(float*)((char*)activeWeapon + 0x110) = 0.0f;
                        }

                        void* wData = *(void**)((char*)activeWeapon + 0x100);
                        if (wData) {
                            if (bOneHitKillDamage) {
                                *(int*)((char*)wData + 0x18) = 99999; // minimumDamage
                                *(int*)((char*)wData + 0x1C) = 99999; // maximumDamage
                            }
                            if (bInfiniteRange) {
                                *(float*)((char*)wData + 0x20) = 9999.0f; // range
                            }
                            if (bRapidFire) {
                                *(float*)((char*)wData + 0x24) = 0.005f; // attackRate
                            }
                            if (bInfiniteAmmo) {
                                *(int*)((char*)wData + 0x30) = 99999; // maximumAttacks
                            }
                        }
                    }
                }
                break;
            }
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {
    }
}

// ─── Mass Kill Aura (Instantly Annihilate All Enemies Anywhere Without Moving) ───
static ULONGLONG g_LastMassKillTime = 0;

static void DoMassKill() {
    if (!bEnableMassKill || !g_PlayerClass) return;

    __try {
        ULONGLONG now = GetTickCount64();
        if (now - g_LastMassKillTime < (ULONGLONG)fMassKillInterval) return;
        g_LastMassKillTime = now;

        Il2CppArray* arr = g_Il2Cpp.FindObjectsOfType(g_PlayerClass);
        if (!arr) return;

        uintptr_t count = *(uintptr_t*)((char*)arr + 0x18);
        void** items = (void**)((char*)arr + 0x20);

        void* localPlayer = nullptr;
        bool localAwayTeam = false;
        bool foundLocal = false;

        for (uintptr_t i = 0; i < count; i++) {
            void* p = items[i];
            if (p && g_Il2Cpp.IsLocalPlayer(p)) {
                localPlayer = p;
                foundLocal = true;
                if (g_PlayerMovementClass) {
                    void* pm = g_Il2Cpp.GetComponent(p, g_PlayerMovementClass);
                    if (pm) localAwayTeam = *(bool*)((char*)pm + 0x1C4);
                }
                break;
            }
        }

        if (!localPlayer || !foundLocal) return;

        // Active weapon on local player
        void* activeWeapon = nullptr;
        if (g_WeaponManagerClass) {
            void* wm = g_Il2Cpp.GetComponent(localPlayer, g_WeaponManagerClass);
            if (wm) {
                activeWeapon = *(void**)((char*)wm + 0x120);
            }
        }

        // Apply 99,999 DMG and infinite stats to active weapon
        if (activeWeapon) {
            *(bool*)((char*)activeWeapon + 0x120) = true; // canShoot
            *(int*)((char*)activeWeapon + 0x114)  = 99999; // currentAmmo
            *(float*)((char*)activeWeapon + 0x110) = 0.0f; // nextTimeToFire

            void* wData = *(void**)((char*)activeWeapon + 0x100);
            if (wData) {
                *(int*)((char*)wData + 0x18) = 99999; // minimumDamage
                *(int*)((char*)wData + 0x1C) = 99999; // maximumDamage
                *(float*)((char*)wData + 0x20) = 9999.0f; // range
                *(float*)((char*)wData + 0x24) = 0.001f; // attackRate
                *(int*)((char*)wData + 0x30) = 99999; // maximumAttacks
            }
        }

        // Camera position
        Vector3 localCamPos{};
        void* activeCam = GetCurrentGameCamera();
        if (activeCam) {
            void* camTr = g_Il2Cpp.GetComponentTransform(activeCam);
            if (camTr) g_Il2Cpp.GetTransformPosition(camTr, &localCamPos);
        }

        int killedCount = 0;

        for (uintptr_t i = 0; i < count; i++) {
            void* p = items[i];
            if (!p || p == localPlayer || g_Il2Cpp.IsLocalPlayer(p)) continue;
            if (!g_Il2Cpp.IsGameObjectActiveInHierarchy(p) || !g_Il2Cpp.IsSpawned(p)) continue;

            void* hComp = g_HealthClass ? g_Il2Cpp.GetComponent(p, g_HealthClass) : nullptr;
            if (!hComp) continue;

            if (g_IsDeadMethod) {
                void* exc = nullptr;
                Il2CppObject* res = g_Il2Cpp.il2cpp_runtime_invoke(g_IsDeadMethod, hComp, nullptr, &exc);
                if (res && !exc && *(bool*)((char*)res + 0x10)) continue;
            }

            int currentHp = 100;
            if (g_GetCurrentHealth) {
                void* exc = nullptr;
                Il2CppObject* res = g_Il2Cpp.il2cpp_runtime_invoke(g_GetCurrentHealth, hComp, nullptr, &exc);
                if (res && !exc) currentHp = *(int*)((char*)res + 0x10);
                if (currentHp <= 0) continue;
            }

            bool enemyAwayTeam = false;
            void* enemyPM = g_PlayerMovementClass ? g_Il2Cpp.GetComponent(p, g_PlayerMovementClass) : nullptr;
            if (enemyPM) {
                enemyAwayTeam = *(bool*)((char*)enemyPM + 0x1C4);
            } else if (g_SharedRefClass) {
                void* sr = g_Il2Cpp.GetComponent(p, g_SharedRefClass);
                if (sr) enemyAwayTeam = *(bool*)((char*)sr + 0x108);
            }

            if (bIgnoreTeammates && foundLocal && (enemyAwayTeam == localAwayTeam)) continue;

            void* chestRb = *(void**)((char*)p + 0x170);
            void* rootRb  = *(void**)((char*)p + 0x108);
            void* targetRb = chestRb ? chestRb : rootRb;
            Vector3 targetHeadPos{};
            if (targetRb && g_Il2Cpp.GetRigidbodyPosition(targetRb, &targetHeadPos)) {
                targetHeadPos = targetHeadPos + Vector3(0.0f, 0.40f, 0.0f);
            }

            // CMDShoot Raycast with 99,999 Damage
            if (activeWeapon && g_PackDirectionMethod && g_PackVector3Method && g_CMDShoot) {
                Vector3 aimDir = targetHeadPos - localCamPos;
                float len = aimDir.Length();
                if (len > 0.001f) aimDir = aimDir * (1.0f / len);
                else aimDir = Vector3(0.0f, 1.0f, 0.0f);

                void* posArgs[1] = { &localCamPos };
                void* fwdArgs[1] = { &aimDir };
                void* exc1 = nullptr;
                void* exc2 = nullptr;

                Il2CppObject* packedPos = g_Il2Cpp.il2cpp_runtime_invoke(g_PackVector3Method, nullptr, posArgs, &exc1);
                Il2CppObject* packedFwd = g_Il2Cpp.il2cpp_runtime_invoke(g_PackDirectionMethod, nullptr, fwdArgs, &exc2);

                if (packedPos && packedFwd) {
                    uint32_t tick = 0;
                    void* shootArgs[3] = { packedPos, packedFwd, &tick };
                    void* exc3 = nullptr;
                    g_Il2Cpp.il2cpp_runtime_invoke(g_CMDShoot, activeWeapon, shootArgs, &exc3);
                }
            }

            // Also call ClientTryShoot to trigger hit effect & animations
            if (activeWeapon && g_ClientTryShoot) {
                void* excShoot = nullptr;
                g_Il2Cpp.il2cpp_runtime_invoke(g_ClientTryShoot, activeWeapon, nullptr, &excShoot);
            }

            // Direct Server Health Zero RPC
            if (g_CMDChangeCurrentHealth) {
                int zeroHp = 0;
                void* args[1] = { &zeroHp };
                void* exc = nullptr;
                g_Il2Cpp.il2cpp_runtime_invoke(g_CMDChangeCurrentHealth, hComp, args, &exc);
            }

            killedCount++;
        }

        if (killedCount > 0) {
            CheatLog("Mass Kill Aura: hit %d target(s)", killedCount);
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {
        // Safe exception guard
    }
}

// ─── Luxury High-End Dark Theme (Scaled & Spaced) ───────────────────────────
static void ApplyModernTheme() {
    ImGuiStyle& style = ImGui::GetStyle();
    style.WindowPadding     = ImVec2(22, 22);
    style.FramePadding      = ImVec2(14, 9);
    style.ItemSpacing       = ImVec2(14, 12);
    style.ItemInnerSpacing  = ImVec2(10, 8);
    style.IndentSpacing     = 24.0f;
    style.ScrollbarSize     = 12.0f;
    style.GrabMinSize       = 16.0f;

    style.WindowRounding    = 14.0f;
    style.ChildRounding     = 10.0f;
    style.FrameRounding     = 8.0f;
    style.PopupRounding     = 10.0f;
    style.ScrollbarRounding = 8.0f;
    style.GrabRounding      = 8.0f;
    style.TabRounding       = 8.0f;

    style.WindowBorderSize  = 1.5f;
    style.ChildBorderSize   = 1.0f;
    style.FrameBorderSize   = 0.0f;

    ImVec4* colors = style.Colors;
    colors[ImGuiCol_Text]                  = ImVec4(0.96f, 0.97f, 0.99f, 1.00f);
    colors[ImGuiCol_TextDisabled]          = ImVec4(0.50f, 0.54f, 0.64f, 1.00f);
    colors[ImGuiCol_WindowBg]              = ImVec4(0.06f, 0.07f, 0.11f, 0.97f);
    colors[ImGuiCol_ChildBg]               = ImVec4(0.09f, 0.10f, 0.16f, 0.88f);
    colors[ImGuiCol_PopupBg]               = ImVec4(0.08f, 0.09f, 0.14f, 0.98f);
    colors[ImGuiCol_Border]                = ImVec4(0.24f, 0.28f, 0.42f, 0.65f);
    colors[ImGuiCol_BorderShadow]          = ImVec4(0.00f, 0.00f, 0.00f, 0.00f);
    colors[ImGuiCol_FrameBg]               = ImVec4(0.13f, 0.15f, 0.23f, 0.95f);
    colors[ImGuiCol_FrameBgHovered]        = ImVec4(0.22f, 0.26f, 0.40f, 1.00f);
    colors[ImGuiCol_FrameBgActive]         = ImVec4(0.30f, 0.35f, 0.54f, 1.00f);
    colors[ImGuiCol_TitleBg]               = ImVec4(0.05f, 0.06f, 0.09f, 1.00f);
    colors[ImGuiCol_TitleBgActive]         = ImVec4(0.08f, 0.10f, 0.16f, 1.00f);
    colors[ImGuiCol_TitleBgCollapsed]      = ImVec4(0.05f, 0.06f, 0.09f, 0.75f);
    colors[ImGuiCol_MenuBarBg]             = ImVec4(0.08f, 0.09f, 0.14f, 1.00f);
    colors[ImGuiCol_ScrollbarBg]           = ImVec4(0.06f, 0.07f, 0.10f, 0.60f);
    colors[ImGuiCol_ScrollbarGrab]         = ImVec4(0.26f, 0.30f, 0.45f, 1.00f);
    colors[ImGuiCol_ScrollbarGrabHovered]  = ImVec4(0.38f, 0.44f, 0.65f, 1.00f);
    colors[ImGuiCol_ScrollbarGrabActive]   = ImVec4(0.48f, 0.55f, 0.80f, 1.00f);
    colors[ImGuiCol_CheckMark]             = ImVec4(0.35f, 0.80f, 1.00f, 1.00f);
    colors[ImGuiCol_SliderGrab]            = ImVec4(0.35f, 0.80f, 1.00f, 1.00f);
    colors[ImGuiCol_SliderGrabActive]      = ImVec4(0.55f, 0.90f, 1.00f, 1.00f);
    colors[ImGuiCol_Button]                = ImVec4(0.16f, 0.19f, 0.30f, 1.00f);
    colors[ImGuiCol_ButtonHovered]         = ImVec4(0.28f, 0.34f, 0.54f, 1.00f);
    colors[ImGuiCol_ButtonActive]          = ImVec4(0.38f, 0.46f, 0.70f, 1.00f);
    colors[ImGuiCol_Header]                = ImVec4(0.18f, 0.22f, 0.36f, 1.00f);
    colors[ImGuiCol_HeaderHovered]         = ImVec4(0.28f, 0.34f, 0.54f, 1.00f);
    colors[ImGuiCol_HeaderActive]          = ImVec4(0.36f, 0.44f, 0.68f, 1.00f);
    colors[ImGuiCol_Separator]             = ImVec4(0.22f, 0.25f, 0.38f, 0.65f);
    colors[ImGuiCol_SeparatorHovered]      = ImVec4(0.36f, 0.42f, 0.62f, 1.00f);
    colors[ImGuiCol_SeparatorActive]       = ImVec4(0.48f, 0.56f, 0.82f, 1.00f);
    colors[ImGuiCol_ResizeGrip]            = ImVec4(0.18f, 0.22f, 0.34f, 0.50f);
    colors[ImGuiCol_ResizeGripHovered]     = ImVec4(0.36f, 0.42f, 0.62f, 0.75f);
    colors[ImGuiCol_ResizeGripActive]      = ImVec4(0.48f, 0.56f, 0.82f, 1.00f);
    colors[ImGuiCol_Tab]                   = ImVec4(0.10f, 0.12f, 0.18f, 1.00f);
    colors[ImGuiCol_TabHovered]            = ImVec4(0.28f, 0.34f, 0.54f, 1.00f);
    colors[ImGuiCol_TabActive]             = ImVec4(0.22f, 0.28f, 0.44f, 1.00f);
    colors[ImGuiCol_TabUnfocused]          = ImVec4(0.08f, 0.09f, 0.14f, 1.00f);
    colors[ImGuiCol_TabUnfocusedActive]    = ImVec4(0.14f, 0.17f, 0.26f, 1.00f);
}

// ─── Custom Styled Tab Button ────────────────────────────────────────────────
static bool DrawTabButton(const char* label, bool active, const ImVec2& size) {
    if (active) {
        ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.24f, 0.38f, 0.68f, 1.0f));
        ImGui::PushStyleColor(ImGuiCol_ButtonHovered, ImVec4(0.30f, 0.46f, 0.78f, 1.0f));
        ImGui::PushStyleColor(ImGuiCol_ButtonActive, ImVec4(0.20f, 0.32f, 0.60f, 1.0f));
        ImGui::PushStyleColor(ImGuiCol_Text, ImVec4(1.0f, 1.0f, 1.0f, 1.0f));
    } else {
        ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.11f, 0.13f, 0.20f, 0.88f));
        ImGui::PushStyleColor(ImGuiCol_ButtonHovered, ImVec4(0.18f, 0.23f, 0.35f, 1.0f));
        ImGui::PushStyleColor(ImGuiCol_ButtonActive, ImVec4(0.14f, 0.18f, 0.28f, 1.0f));
        ImGui::PushStyleColor(ImGuiCol_Text, ImVec4(0.72f, 0.76f, 0.88f, 1.0f));
    }

    bool clicked = ImGui::Button(label, size);
    ImGui::PopStyleColor(4);
    return clicked;
}

// ─── hkPresent ───────────────────────────────────────────────────────────────
HRESULT __stdcall hkPresent(IDXGISwapChain* pSwapChain, UINT SyncInterval, UINT Flags) {
    if (g_Uninjecting) {
        return oPresent(pSwapChain, SyncInterval, Flags);
    }

    if (!g_IsInitialized) {
        if (SUCCEEDED(pSwapChain->GetDevice(__uuidof(ID3D11Device), (void**)&g_pd3dDevice))) {
            g_pd3dDevice->GetImmediateContext(&g_pd3dDeviceContext);

            DXGI_SWAP_CHAIN_DESC sd;
            pSwapChain->GetDesc(&sd);
            g_hWnd = sd.OutputWindow;

            CreateRTV(pSwapChain);

            oWndProc = (WNDPROC)SetWindowLongPtr(g_hWnd, GWLP_WNDPROC, (LONG_PTR)WndProc);

            ImGui::CreateContext();
            ImGuiIO& io = ImGui::GetIO();
            io.ConfigFlags |= ImGuiConfigFlags_NoMouseCursorChange;
            io.IniFilename  = nullptr;
            io.FontGlobalScale = 1.35f;

            ApplyModernTheme();

            ImGui_ImplWin32_Init(g_hWnd);
            ImGui_ImplDX11_Init(g_pd3dDevice, g_pd3dDeviceContext);

            g_IsInitialized = true;
        } else {
            return oPresent(pSwapChain, SyncInterval, Flags);
        }
    }

    if (!g_mainRenderTargetView) {
        CreateRTV(pSwapChain);
    }

    if (g_pd3dDeviceContext && g_mainRenderTargetView && !g_Uninjecting) {
        // Run game logic hooks safely on render thread
        UpdateFrameESPData();
        DoGodMode();
        ApplyWeaponStatMods();
        DoMassKill();

        ImGui_ImplDX11_NewFrame();
        ImGui_ImplWin32_NewFrame();
        ImGui::NewFrame();

        ImGuiIO& io = ImGui::GetIO();

        // ── ESP Overlay ──
        if (bEnableESP) DrawESP(io);

        // ── Aimbot ──
        if (bEnableAimbot) DoAimbot(io);

        // ── Teleportation & Auto-Shoot Kill Aura ──
        if (bEnableTeleportKill) DoTeleportKill(io);

        // ── GUI Menu (EXTRA LARGE, CENTERED, LUXURY DASHBOARD) ──
        if (g_ShowMenu) {
            ImGui::SetNextWindowSize(ImVec2(1080.0f, 720.0f), ImGuiCond_FirstUseEver);
            ImGui::SetNextWindowPos(
                ImVec2(io.DisplaySize.x * 0.5f, io.DisplaySize.y * 0.5f),
                ImGuiCond_FirstUseEver,
                ImVec2(0.5f, 0.5f)
            );

            ImGuiWindowFlags winFlags = ImGuiWindowFlags_NoCollapse;
            ImGui::Begin("XUYBYA // Grapples Galore Suite", &g_ShowMenu, winFlags);

            // Top Header Bar
            ImGui::BeginChild("HeaderBar", ImVec2(0, 56), true);
            {
                ImGui::TextColored(ImVec4(0.35f, 0.85f, 1.0f, 1.0f), "XUYBYA");
                ImGui::SameLine();
                ImGui::TextDisabled("|  Grapples Galore Combat, Weapons & Visual Suite");

                ImGui::SameLine(ImGui::GetWindowWidth() - 240.0f);
                ImGui::TextColored(ImVec4(0.40f, 1.0f, 0.50f, 1.0f), "[ACTIVE]");
                ImGui::SameLine();
                ImGui::TextDisabled("Toggle Menu: [INSERT]");
            }
            ImGui::EndChild();

            ImGui::Spacing();

            // Left Navigation Sidebar
            ImGui::BeginChild("Sidebar", ImVec2(250, 0), true);
            {
                ImGui::TextDisabled("CATEGORIES");
                ImGui::Separator();
                ImGui::Spacing();

                if (DrawTabButton("Visuals / ESP",        g_CurrentTab == 0, ImVec2(-1, 44))) g_CurrentTab = 0;
                ImGui::Spacing();
                if (DrawTabButton("Combat & Aimbot",      g_CurrentTab == 1, ImVec2(-1, 44))) g_CurrentTab = 1;
                ImGui::Spacing();
                if (DrawTabButton("Weapons & Spawner",    g_CurrentTab == 2, ImVec2(-1, 44))) g_CurrentTab = 2;
                ImGui::Spacing();
                if (DrawTabButton("Teleport & Mass Kill", g_CurrentTab == 3, ImVec2(-1, 44))) g_CurrentTab = 3;
                ImGui::Spacing();
                if (DrawTabButton("Color Palette",        g_CurrentTab == 4, ImVec2(-1, 44))) g_CurrentTab = 4;
                ImGui::Spacing();
                if (DrawTabButton("Configs & Diagnostics",g_CurrentTab == 5, ImVec2(-1, 44))) g_CurrentTab = 5;

                ImGui::Spacing();
                ImGui::Separator();
                ImGui::Spacing();

                ImGui::TextDisabled("QUICK TOGGLES");
                ImGui::Checkbox("Master ESP",     &bEnableESP);
                ImGui::Checkbox("Neon Glow",      &bEnableGlow);
                ImGui::Checkbox("Silent Aim",     &bEnableSilentAim);
                ImGui::Checkbox("Mass Kill Aura", &bEnableMassKill);
                ImGui::Checkbox("Teleport Kill",  &bEnableTeleportKill);
                ImGui::Checkbox("Infinite Ammo",  &bInfiniteAmmo);
                ImGui::Checkbox("One-Hit Kill",   &bOneHitKillDamage);
                ImGui::Checkbox("God Mode",       &bGodMode);

                ImGui::Spacing();
                ImGui::Separator();
                ImGui::Spacing();

                ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.65f, 0.15f, 0.15f, 0.85f));
                ImGui::PushStyleColor(ImGuiCol_ButtonHovered, ImVec4(0.85f, 0.20f, 0.20f, 1.0f));
                ImGui::PushStyleColor(ImGuiCol_ButtonActive, ImVec4(0.50f, 0.10f, 0.10f, 1.0f));
                if (ImGui::Button("UNINJECT CHEAT", ImVec2(-1, 44))) {
                    RequestUninject();
                }
                ImGui::PopStyleColor(3);
            }
            ImGui::EndChild();

            ImGui::SameLine();

            // Main Content Area
            ImGui::BeginChild("MainContent", ImVec2(0, 0), true);
            {
                // ─── TAB 0: Visuals / ESP ────────────────────────────────────
                if (g_CurrentTab == 0) {
                    ImGui::TextColored(ImVec4(0.4f, 0.8f, 1.0f, 1.0f), "ESP VISUALS & WALLHACK");
                    ImGui::TextDisabled("Configure dynamic ragdoll hitboxes, skeletons, tracers, and neon glow effects.");
                    ImGui::Separator();
                    ImGui::Spacing();

                    ImGui::Columns(2, "ESPColumns", false);
                    ImGui::SetColumnWidth(0, 340.0f);

                    ImGui::TextColored(ImVec4(1.0f, 0.85f, 0.4f, 1.0f), "ESP Features");
                    ImGui::Spacing();
                    ImGui::Checkbox("Master ESP Enable",    &bEnableESP);
                    ImGui::Checkbox("Dynamic Hitbox Box",   &bDrawBoxes);
                    ImGui::Checkbox("Ragdoll Skeleton",     &bDrawSkeleton);
                    ImGui::Checkbox("Head Circle ESP",      &bDrawHeadCircle);
                    ImGui::Checkbox("Tracers (Snaplines)",  &bDrawTracers);
                    ImGui::Checkbox("Health Bars",          &bDrawHealthBar);
                    ImGui::Checkbox("Distance & Info Text", &bDrawInfoText);
                    ImGui::Checkbox("Neon Glow Bloom",      &bEnableGlow);

                    ImGui::NextColumn();

                    ImGui::TextColored(ImVec4(1.0f, 0.85f, 0.4f, 1.0f), "Visual Adjustments");
                    ImGui::Spacing();

                    if (bDrawBoxes) {
                        ImGui::SliderFloat("Box Thickness", &fBoxThickness, 1.0f, 5.0f, "%.1f px");
                    }
                    if (bDrawSkeleton) {
                        ImGui::SliderFloat("Skeleton Thickness", &fSkeletonThickness, 1.0f, 5.0f, "%.1f px");
                    }
                    if (bDrawHeadCircle) {
                        ImGui::SliderFloat("Head Circle Scale", &fHeadCircleSize, 0.5f, 2.5f, "%.1fx");
                    }
                    if (bDrawTracers) {
                        const char* origins[] = { "Bottom", "Crosshair", "Top" };
                        ImGui::Combo("Tracer Origin", &iTracerOrigin, origins, IM_ARRAYSIZE(origins));
                        ImGui::SliderFloat("Tracer Thickness", &fTracerThickness, 1.0f, 6.0f, "%.1f px");
                    }
                    if (bEnableGlow) {
                        ImGui::SliderFloat("Glow Intensity", &fGlowIntensity, 0.2f, 2.5f, "%.1fx");
                    }

                    ImGui::SliderFloat("Max Distance", &fMaxDistance, 50.0f, 1000.0f, "%.0f m");

                    ImGui::Spacing();
                    ImGui::Separator();
                    ImGui::Spacing();

                    ImGui::Checkbox("Ignore Teammates (Enemies Only)", &bIgnoreTeammates);
                    ImGui::Checkbox("Ignore Local Player (Self)",     &bIgnoreLocal);
                    ImGui::Checkbox("Ignore Dead / Spawn Ghosts",     &bIgnoreDead);

                    ImGui::Columns(1);
                }

                // ─── TAB 1: Combat & Aimbot ──────────────────────────────────
                else if (g_CurrentTab == 1) {
                    ImGui::TextColored(ImVec4(0.4f, 0.8f, 1.0f, 1.0f), "COMBAT, SILENT AIM & AIMBOT");
                    ImGui::TextDisabled("Silent Aim (shoot anywhere to hit), Smooth tracking aimbot, and God Mode.");
                    ImGui::Separator();
                    ImGui::Spacing();

                    ImGui::Columns(2, "CombatColumns", false);
                    ImGui::SetColumnWidth(0, 360.0f);

                    // Left Column: Silent Aim
                    ImGui::TextColored(ImVec4(1.0f, 0.35f, 0.65f, 1.0f), "Silent Aim (Hit Any Shot Anywhere)");
                    ImGui::Spacing();

                    ImGui::Checkbox("Enable Silent Aim", &bEnableSilentAim);
                    if (bEnableSilentAim) {
                        const char* sBones[] = { "Chest (Center Torso)", "Head (Upper Skull)" };
                        ImGui::Combo("Silent Aim Bone", &iSilentAimTarget, sBones, IM_ARRAYSIZE(sBones));
                        ImGui::Checkbox("360° Full Map (Anywhere)", &bSilentAimFull360);

                        if (!bSilentAimFull360) {
                            ImGui::SliderFloat("Silent FOV", &fSilentAimFOV, 30.0f, 600.0f, "%.0f px");
                            ImGui::Checkbox("Draw Silent FOV Circle", &bDrawSilentAimFOV);
                        }
                    } else {
                        ImGui::TextDisabled("Shoot anywhere on screen to hit enemies automatically.");
                    }

                    ImGui::Spacing();
                    ImGui::Separator();
                    ImGui::Spacing();

                    ImGui::TextColored(ImVec4(0.40f, 1.0f, 0.50f, 1.0f), "Player Invulnerability");
                    ImGui::Spacing();
                    ImGui::Checkbox("God Mode (Infinite Health)", &bGodMode);
                    ImGui::TextDisabled("Freezes health at 99,999 and auto-heals damage.");

                    ImGui::NextColumn();

                    // Right Column: Aimbot
                    ImGui::TextColored(ImVec4(1.0f, 0.85f, 0.4f, 1.0f), "Smooth Aimbot Tracking");
                    ImGui::Spacing();

                    ImGui::Checkbox("Enable Smooth Aimbot", &bEnableAimbot);
                    if (bEnableAimbot) {
                        ImGui::Combo("Aimbot Key", &iAimbotKey, g_KeyNames, IM_ARRAYSIZE(g_KeyNames));
                        ImGui::Checkbox("Draw Visual FOV Circle", &bDrawAimbotFOV);

                        const char* targetBones[] = { "Chest (Center Torso)", "Head (Upper Skull)" };
                        ImGui::Combo("Target Bone", &iAimbotTarget, targetBones, IM_ARRAYSIZE(targetBones));

                        ImGui::SliderFloat("FOV Radius",       &aimbotFOV,      20.0f, 500.0f, "%.0f px");
                        ImGui::SliderFloat("Smoothing Factor", &aimbotSmooth,   1.0f,  25.0f,  "%.1f");
                        ImGui::SliderFloat("Max Aim Speed",    &aimbotMaxSpeed, 5.0f,  80.0f,  "%.0f px/f");
                    }

                    ImGui::Columns(1);
                }

                // ─── TAB 2: Weapons & Spawner ────────────────────────────────
                else if (g_CurrentTab == 2) {
                    ImGui::TextColored(ImVec4(0.4f, 0.8f, 1.0f, 1.0f), "WEAPON SPAWNER & STAT MODIFIER");
                    ImGui::TextDisabled("Equip any weapon in the game on-demand, set infinite ammo, 99,999 damage, and rapid fire.");
                    ImGui::Separator();
                    ImGui::Spacing();

                    ImGui::Columns(2, "WeaponColumns", false);
                    ImGui::SetColumnWidth(0, 360.0f);

                    ImGui::TextColored(ImVec4(1.0f, 0.85f, 0.4f, 1.0f), "Weapon Selector");
                    ImGui::Spacing();

                    ImGui::Combo("Select Weapon", &iSelectedWeaponIndex, g_WeaponNames, IM_ARRAYSIZE(g_WeaponNames));
                    ImGui::Spacing();

                    ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.20f, 0.55f, 0.85f, 0.90f));
                    ImGui::PushStyleColor(ImGuiCol_ButtonHovered, ImVec4(0.28f, 0.65f, 0.98f, 1.0f));
                    ImGui::PushStyleColor(ImGuiCol_ButtonActive, ImVec4(0.15f, 0.45f, 0.75f, 1.0f));
                    if (ImGui::Button("EQUIP SELECTED WEAPON NOW", ImVec2(-1, 46))) {
                        GiveWeapon(iSelectedWeaponIndex);
                    }
                    ImGui::PopStyleColor(3);

                    ImGui::Spacing();
                    ImGui::Separator();
                    ImGui::Spacing();

                    ImGui::TextDisabled("Available Weapons:");
                    for (int w = 0; w < IM_ARRAYSIZE(g_WeaponNames); w++) {
                        ImGui::BulletText("[%d] %s", w, g_WeaponNames[w]);
                    }

                    ImGui::NextColumn();

                    ImGui::TextColored(ImVec4(1.0f, 0.35f, 0.45f, 1.0f), "Weapon Stat Overrides");
                    ImGui::Spacing();

                    ImGui::Checkbox("Infinite Ammo (99,999)", &bInfiniteAmmo);
                    ImGui::TextDisabled("Never runs out of ammo, no reload required.");
                    ImGui::Spacing();

                    ImGui::Checkbox("One-Hit Kill Damage (99,999 DMG)", &bOneHitKillDamage);
                    ImGui::TextDisabled("Overrides weapon minimum & maximum damage to 99,999.");
                    ImGui::Spacing();

                    ImGui::Checkbox("Rapid Fire / Instant Attack Rate", &bRapidFire);
                    ImGui::TextDisabled("Removes weapon firing delay for ultra-fast shooting.");
                    ImGui::Spacing();

                    ImGui::Checkbox("Infinite Range (9,999m)", &bInfiniteRange);
                    ImGui::TextDisabled("Allows hitting targets across the entire map.");

                    ImGui::Columns(1);
                }

                // ─── TAB 3: Teleport & Mass Kill ─────────────────────────────
                else if (g_CurrentTab == 3) {
                    ImGui::TextColored(ImVec4(0.4f, 0.8f, 1.0f, 1.0f), "MASS KILL AURA & TELEPORTATION");
                    ImGui::TextDisabled("Wipe the entire server instantly or auto-cycle teleport to every player.");
                    ImGui::Separator();
                    ImGui::Spacing();

                    ImGui::Columns(2, "TeleportColumns", false);
                    ImGui::SetColumnWidth(0, 360.0f);

                    // Left Column: Mass Kill
                    ImGui::TextColored(ImVec4(1.0f, 0.20f, 0.35f, 1.0f), "Mass Kill Aura (Kill All Enemies)");
                    ImGui::Spacing();

                    ImGui::Checkbox("Enable Mass Kill Aura", &bEnableMassKill);
                    if (bEnableMassKill) {
                        const char* mkModes[] = { "Direct Server Health Zero (RPC)", "Multi-Raycast Silent CMDShoot", "Hybrid (Combined Exploit)" };
                        ImGui::Combo("Kill Exploit Mode", &iMassKillMode, mkModes, IM_ARRAYSIZE(mkModes));
                        ImGui::SliderFloat("Kill Interval", &fMassKillInterval, 20.0f, 500.0f, "%.0f ms");
                    } else {
                        ImGui::TextDisabled("Remotely wipes all enemy players across the map without moving.");
                    }

                    ImGui::NextColumn();

                    // Right Column: Teleport Kill
                    ImGui::TextColored(ImVec4(1.0f, 0.35f, 0.45f, 1.0f), "Teleport Kill & Server Cycler");
                    ImGui::Spacing();

                    ImGui::Checkbox("Enable Teleport Kill", &bEnableTeleportKill);
                    ImGui::Spacing();

                    if (bEnableTeleportKill) {
                        ImGui::Checkbox("Hold Hotkey Only", &bTeleportHoldKey);
                        if (bTeleportHoldKey) {
                            ImGui::Combo("Teleport Key", &iTeleportKey, g_KeyNames, IM_ARRAYSIZE(g_KeyNames));
                        }

                        ImGui::Spacing();
                        const char* targetModes[] = { "Random / Auto-Cycle Server", "Closest Distance", "Lowest HP First" };
                        ImGui::Combo("Target Mode", &iTeleportTargetMode, targetModes, IM_ARRAYSIZE(targetModes));

                        const char* posModes[] = { "Behind Enemy (Backstab)", "Above Enemy (Sky Drop)", "In Front of Enemy", "Directly on Target" };
                        ImGui::Combo("Teleport Position", &iTeleportPosition, posModes, IM_ARRAYSIZE(posModes));

                        ImGui::Spacing();
                        ImGui::SliderFloat("Distance Offset", &fTeleportDistance, 0.2f, 5.0f, "%.1f m");
                        ImGui::SliderFloat("Height Offset",   &fTeleportHeight,   -1.0f, 3.0f, "%.1f m");

                        ImGui::Spacing();
                        ImGui::Checkbox("Auto-Shoot on Teleport", &bTeleportAutoShoot);
                        ImGui::Checkbox("Auto-Aim / LookAt Target", &bTeleportLookAt);

                        if (bTeleportAutoShoot) {
                            ImGui::SliderFloat("Shoot Interval", &fTeleportShootRate, 20.0f, 200.0f, "%.0f ms");
                        }
                    } else {
                        ImGui::TextDisabled("Instantly teleports to enemies, kills them, and cycles to the next.");
                    }

                    ImGui::Columns(1);
                }

                // ─── TAB 4: Color Palette ────────────────────────────────────
                else if (g_CurrentTab == 4) {
                    ImGui::TextColored(ImVec4(0.4f, 0.8f, 1.0f, 1.0f), "COLOR PALETTE & CUSTOMIZATION");
                    ImGui::TextDisabled("Personalize ESP overlay, tracers, skeletons, and entity highlighting colors.");
                    ImGui::Separator();
                    ImGui::Spacing();

                    ImGui::Columns(2, "ColorColumns", false);
                    ImGui::SetColumnWidth(0, 360.0f);

                    ImGui::TextColored(ImVec4(1.0f, 0.85f, 0.4f, 1.0f), "ESP Entity Colors");
                    ImGui::Spacing();
                    ImGui::ColorEdit4("Enemy / Target Color", colEnemy);
                    ImGui::Spacing();
                    ImGui::ColorEdit4("Teammate Color",      colTeam);
                    ImGui::Spacing();
                    ImGui::ColorEdit4("Head Circle Color",    colHeadCircle);

                    ImGui::NextColumn();

                    ImGui::TextColored(ImVec4(1.0f, 0.85f, 0.4f, 1.0f), "Lines & Bones");
                    ImGui::Spacing();
                    ImGui::ColorEdit4("Skeleton Bone Color",  colSkeleton);
                    ImGui::Spacing();
                    ImGui::ColorEdit4("Tracer Snapline Color",colTracers);

                    ImGui::Columns(1);

                    ImGui::Spacing();
                    ImGui::Separator();
                    ImGui::Spacing();

                    if (ImGui::Button("Reset Colors to Default", ImVec2(240, 38))) {
                        colEnemy[0] = 1.0f; colEnemy[1] = 0.22f; colEnemy[2] = 0.35f; colEnemy[3] = 1.0f;
                        colTeam[0]  = 0.20f; colTeam[1] = 0.70f; colTeam[2] = 1.00f; colTeam[3] = 1.0f;
                        colSkeleton[0] = 0.95f; colSkeleton[1] = 0.95f; colSkeleton[2] = 0.98f; colSkeleton[3] = 0.90f;
                        colTracers[0]  = 1.0f; colTracers[1] = 0.85f; colTracers[2] = 0.20f; colTracers[3] = 0.80f;
                        colHeadCircle[0]=1.0f; colHeadCircle[1]=0.35f; colHeadCircle[2]=0.50f; colHeadCircle[3]=1.0f;
                    }
                }

                // ─── TAB 5: Configs & Diagnostics ────────────────────────────
                else if (g_CurrentTab == 5) {
                    ImGui::TextColored(ImVec4(0.4f, 0.8f, 1.0f, 1.0f), "CONFIGS & SYSTEM DIAGNOSTICS");
                    ImGui::TextDisabled("Save/load configuration profiles, check system telemetry, and inspect logs.");
                    ImGui::Separator();
                    ImGui::Spacing();

                    if (g_ConfigStatus[0] != '\0' && (GetTickCount64() - g_ConfigStatusTime < 6000)) {
                        ImGui::TextColored(ImVec4(0.35f, 1.0f, 0.50f, 1.0f), "%s", g_ConfigStatus);
                        ImGui::Spacing();
                        ImGui::Separator();
                        ImGui::Spacing();
                    }

                    ImGui::Columns(2, "ConfigDiagColumns", false);
                    ImGui::SetColumnWidth(0, 360.0f);

                    ImGui::TextColored(ImVec4(1.0f, 0.85f, 0.4f, 1.0f), "Configuration System");
                    ImGui::Spacing();
                    ImGui::Text("File: XUYBYA_Config.ini");
                    ImGui::Spacing();

                    if (ImGui::Button("SAVE CONFIG TO DISK", ImVec2(-1, 42))) {
                        SaveConfig();
                    }
                    ImGui::Spacing();
                    if (ImGui::Button("LOAD CONFIG FROM DISK", ImVec2(-1, 42))) {
                        LoadConfig();
                    }
                    ImGui::Spacing();
                    if (ImGui::Button("RESET TO DEFAULTS", ImVec2(-1, 38))) {
                        ResetConfigToDefaults();
                    }

                    ImGui::NextColumn();

                    ImGui::TextColored(ImVec4(0.35f, 0.85f, 1.0f, 1.0f), "Engine Telemetry");
                    ImGui::Spacing();

                    bool il2cppOk  = (g_Il2Cpp.hGameAssembly != nullptr);
                    bool classesOk = (g_PlayerClass != nullptr);

                    ImGui::Text("DirectX 11 Overlay : ");
                    ImGui::SameLine();
                    ImGui::TextColored(ImVec4(0.3f, 1.0f, 0.4f, 1.0f), "HOOKED (Active)");

                    ImGui::Text("IL2CPP Engine API  : ");
                    ImGui::SameLine();
                    ImGui::TextColored(il2cppOk ? ImVec4(0.3f, 1.0f, 0.4f, 1.0f) : ImVec4(1.0f, 0.3f, 0.3f, 1.0f),
                                       il2cppOk ? "INITIALIZED (OK)" : "FAILED");

                    ImGui::Text("Player Ragdoll Class: ");
                    ImGui::SameLine();
                    ImGui::TextColored(classesOk ? ImVec4(0.3f, 1.0f, 0.4f, 1.0f) : ImVec4(1.0f, 0.6f, 0.2f, 1.0f),
                                       classesOk ? "BOUND (Assembly-CSharp)" : "Waiting for match spawn...");

                    ImGui::Spacing();
                    ImGui::Text("Live Tracked Entities : %d", (int)g_ESPData.size());
                    ImGui::Text("Framerate / Performance: %.1f FPS (%.2f ms/frame)", io.Framerate, 1000.0f / io.Framerate);
                    ImGui::Text("Viewport Resolution    : %.0f x %.0f", io.DisplaySize.x, io.DisplaySize.y);

                    ImGui::Columns(1);

                    ImGui::Spacing();
                    ImGui::Separator();
                    ImGui::Spacing();

                    ImGui::TextColored(ImVec4(0.35f, 0.85f, 1.0f, 1.0f), "Diagnostic Log Files:");
                    ImGui::TextDisabled("Log files are created automatically in the cheat directory:");
                    ImGui::BulletText("Cheat & Game Engine Log: XUYBYA_Cheat.log");
                    ImGui::BulletText("Crash & Access Violation: XUYBYA_Crash.log");
                    ImGui::BulletText("Injector Telemetry Log : XUYBYA_Injector.log");
                }
            }
            ImGui::EndChild();

            ImGui::End();
        }

        ImGui::Render();
        g_pd3dDeviceContext->OMSetRenderTargets(1, &g_mainRenderTargetView, NULL);
        ImGui_ImplDX11_RenderDrawData(ImGui::GetDrawData());
    }

    return oPresent(pSwapChain, SyncInterval, Flags);
}

// ─── Find SwapChain VTable using dummy HWND ──────────────────────────────────
DWORD_PTR* GetSwapChainVTable() {
    HWND hWndDummy = CreateWindowA("BUTTON", "DummyD3D", WS_OVERLAPPED, 0, 0, 100, 100, NULL, NULL, NULL, NULL);
    if (!hWndDummy) return nullptr;

    DXGI_SWAP_CHAIN_DESC sd = {};
    sd.BufferCount        = 1;
    sd.BufferDesc.Format  = DXGI_FORMAT_R8G8B8A8_UNORM;
    sd.BufferDesc.Width   = 100;
    sd.BufferDesc.Height  = 100;
    sd.BufferUsage        = DXGI_USAGE_RENDER_TARGET_OUTPUT;
    sd.OutputWindow       = hWndDummy;
    sd.SampleDesc.Count   = 1;
    sd.Windowed           = TRUE;
    sd.SwapEffect         = DXGI_SWAP_EFFECT_DISCARD;

    const D3D_FEATURE_LEVEL levels[] = { D3D_FEATURE_LEVEL_11_0, D3D_FEATURE_LEVEL_10_0 };
    D3D_FEATURE_LEVEL       level;
    IDXGISwapChain*         sc  = nullptr;
    ID3D11Device*           dev = nullptr;
    ID3D11DeviceContext*    ctx = nullptr;

    DWORD_PTR* vtable = nullptr;

    if (SUCCEEDED(D3D11CreateDeviceAndSwapChain(NULL, D3D_DRIVER_TYPE_HARDWARE,
        NULL, 0, levels, 2, D3D11_SDK_VERSION, &sd, &sc, &dev, &level, &ctx))) {
        
        vtable = *(DWORD_PTR**)sc;

        sc->Release();
        dev->Release();
        ctx->Release();
    }

    DestroyWindow(hWndDummy);
    return vtable;
}

// ─── Initializer Worker Thread ───────────────────────────────────────────────
DWORD WINAPI InitThread(LPVOID lpParam) {
    g_hDllModule = (HMODULE)lpParam;

    // Register Crash & Exception Telemetry Handler
    AddVectoredExceptionHandler(1, CrashHandler);

    CheatLog("========================================================");
    CheatLog("★ XUYBYA Cheat Logger Initialized");
    CheatLog("Target Process PID : %lu", GetCurrentProcessId());
    CheatLog("Cheat Module Base  : 0x%p", g_hDllModule);
    CheatLog("========================================================");

    CheatLog("[*] Waiting for DirectX runtime modules (dxgi.dll, d3d11.dll)...");
    while (!GetModuleHandleA("dxgi.dll") || !GetModuleHandleA("d3d11.dll")) {
        Sleep(200);
    }
    CheatLog("[+] DirectX modules acquired.");
    Sleep(500);

    CheatLog("[*] Waiting for GameAssembly.dll...");
    while (!GetModuleHandleA("GameAssembly.dll")) {
        Sleep(300);
    }
    CheatLog("[+] GameAssembly.dll detected at base 0x%p", GetModuleHandleA("GameAssembly.dll"));
    Sleep(500);

    CheatLog("[*] Initializing IL2CPP domain and metadata resolver...");
    if (g_Il2Cpp.Init()) {
        Il2CppImage* asmCS = g_Il2Cpp.GetImage("Assembly-CSharp");
        if (asmCS) {
            g_PlayerClass         = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "Player");
            g_PlayerMovementClass = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "PlayerMovement");
            g_HealthClass         = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "Health");
            g_SharedRefClass      = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "SharedReferences");
            g_RagdollCamClass     = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "RagdollCameraController");
            g_WeaponClass         = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "Weapon");
            g_WeaponManagerClass  = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "WeaponManager");
            g_DataPackerClass     = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "DataPacker");

            CheatLog("[+] Classes resolved: Player=%p, PM=%p, Health=%p, SharedRef=%p, RagdollCam=%p, Weapon=%p, DataPacker=%p",
                     g_PlayerClass, g_PlayerMovementClass, g_HealthClass, g_SharedRefClass, g_RagdollCamClass, g_WeaponClass, g_DataPackerClass);

            if (g_HealthClass) {
                g_GetCurrentHealth       = g_Il2Cpp.FindMethod(g_HealthClass, "GetCurrentHealth", 0);
                g_IsDeadMethod           = g_Il2Cpp.FindMethod(g_HealthClass, "IsDead", 0);
                g_CMDChangeCurrentHealth = g_Il2Cpp.FindMethod(g_HealthClass, "CMDChangeCurrentHealth", 1);
                CheatLog("[+] Health Methods: GetHp=%p, IsDead=%p, CMDChangeHp=%p", g_GetCurrentHealth, g_IsDeadMethod, g_CMDChangeCurrentHealth);
            }
            if (g_WeaponClass) {
                g_ClientTryShoot         = g_Il2Cpp.FindMethod(g_WeaponClass, "ClientTryShoot", 0);
                g_CMDShoot               = g_Il2Cpp.FindMethod(g_WeaponClass, "CMDShoot", 3);
                CheatLog("[+] Weapon Methods: ClientTryShoot=%p, CMDShoot=%p", g_ClientTryShoot, g_CMDShoot);
            }
            if (g_WeaponManagerClass) {
                g_PickUpMethod           = g_Il2Cpp.FindMethod(g_WeaponManagerClass, "PickUp", 1);
                g_StartPickUpMethod      = g_Il2Cpp.FindMethod(g_WeaponManagerClass, "StartPickUp", 1);
                CheatLog("[+] WeaponManager Methods: PickUp=%p, StartPickUp=%p", g_PickUpMethod, g_StartPickUpMethod);
            }
            if (g_DataPackerClass) {
                g_PackDirectionMethod    = g_Il2Cpp.FindMethod(g_DataPackerClass, "PackDirection", 1);
                g_UnpackShortMethod      = g_Il2Cpp.FindMethod(g_DataPackerClass, "UnpackShort", 1);
                g_PackVector3Method      = g_Il2Cpp.FindMethod(g_DataPackerClass, "PackVector3", 1);
                g_UnpackDirectionMethod  = g_Il2Cpp.FindMethod(g_DataPackerClass, "UnpackDirection", 1);
                CheatLog("[+] DataPacker Methods: PackDir=%p, UnpackShort=%p, PackV3=%p, UnpackDir=%p",
                         g_PackDirectionMethod, g_UnpackShortMethod, g_PackVector3Method, g_UnpackDirectionMethod);
            }
        }
    } else {
        CheatLog("[-] IL2CPP initialization failed!");
    }

    CheatLog("[*] Hooking DirectX 11 SwapChain VTable...");
    DWORD_PTR* vtable = GetSwapChainVTable();
    if (vtable) {
        MH_Initialize();
        MH_CreateHook((void*)vtable[8],  (LPVOID)&hkPresent,       (void**)&oPresent);
        MH_CreateHook((void*)vtable[13], (LPVOID)&hkResizeBuffers, (void**)&oResizeBuffers);

        // Hook Weapon::CMDShoot for 100% Server-Side Silent Aim
        void* cmdShootTarget = nullptr;
        if (g_CMDShoot) {
            cmdShootTarget = *(void**)g_CMDShoot;
        }
        if (!cmdShootTarget && g_Il2Cpp.hGameAssembly) {
            cmdShootTarget = (void*)((char*)g_Il2Cpp.hGameAssembly + 0x4BD500);
        }
        if (cmdShootTarget) {
            MH_CreateHook(cmdShootTarget, (LPVOID)&hkCMDShoot, (void**)&oCMDShoot);
            CheatLog("[+] Weapon::CMDShoot hooked at 0x%p", cmdShootTarget);
        }

        MH_EnableHook(MH_ALL_HOOKS);
        CheatLog("[+] All MinHook detours enabled successfully.");
    } else {
        CheatLog("[-] Failed to retrieve SwapChain VTable!");
    }

    CheatLog("=== Initialization complete. Cheat is active! ===");
    return 0;
}

// ─── DllMain ─────────────────────────────────────────────────────────────────
BOOL APIENTRY DllMain(HMODULE hModule, DWORD ul_reason_for_call, LPVOID /*lpReserved*/) {
    if (ul_reason_for_call == DLL_PROCESS_ATTACH) {
        g_hDllModule = hModule;
        DisableThreadLibraryCalls(hModule);
        CreateThread(nullptr, 0, InitThread, (LPVOID)hModule, 0, nullptr);
    }
    return TRUE;
}
