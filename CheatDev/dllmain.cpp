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

// ─── Thread-Safe Diagnostic Logging & Tracing Telemetry ────────────────────────
static CRITICAL_SECTION g_LogCs;
static bool g_LogCsInitialized = false;

struct GameLogEntry {
    std::string timeStr;
    int type; // 0: Error, 1: Assert, 2: Warning, 3: Log, 4: Exception, 5: Trace
    std::string message;
};
static std::vector<GameLogEntry> g_GameLogs;
static std::mutex g_GameLogMutex;
static const size_t MAX_GAME_LOGS = 350;

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

static void TraceLog(const char* category, const char* fmt, ...) {
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

    char fullMsg[1200];
    snprintf(fullMsg, sizeof(fullMsg), "[%s] %s", category, msgBuf);

    std::string path = GetLogPath("XUYBYA_Cheat.log");
    FILE* f = fopen(path.c_str(), "a");
    if (f) {
        fprintf(f, "%s%s\n", timeBuf, fullMsg);
        fflush(f);
        fclose(f);
    }

    LeaveCriticalSection(&g_LogCs);

    // Stream into live in-game diagnostic telemetry UI
    std::lock_guard<std::mutex> lock(g_GameLogMutex);
    char timeOnly[32];
    snprintf(timeOnly, sizeof(timeOnly), "%02d:%02d:%02d.%03d", st.wHour, st.wMinute, st.wSecond, st.wMilliseconds);
    int logType = 3; // Log
    if (strcmp(category, "CRASH") == 0 || strcmp(category, "EXCEPTION") == 0 || strcmp(category, "ERROR") == 0) logType = 4;
    else if (strcmp(category, "WARNING") == 0) logType = 2;
    else if (strcmp(category, "LOBBY") == 0 || strcmp(category, "NETWORK") == 0) logType = 5;

    g_GameLogs.push_back({ timeOnly, logType, std::string("[") + category + "] " + msgBuf });
    if (g_GameLogs.size() > MAX_GAME_LOGS) {
        g_GameLogs.erase(g_GameLogs.begin());
    }
}

static void CheatLog(const char* fmt, ...) {
    char msgBuf[1024];
    va_list args;
    va_start(args, fmt);
    vsnprintf(msgBuf, sizeof(msgBuf), fmt, args);
    va_end(args);
    TraceLog("CHEAT", "%s", msgBuf);
}

// ─── Vectored Exception Handler (Automatic Crash Logger & Tracer) ────────────
static LONG WINAPI CrashHandler(PEXCEPTION_POINTERS pExc) {
    if (!pExc || !pExc->ExceptionRecord) return EXCEPTION_CONTINUE_SEARCH;
    DWORD code = pExc->ExceptionRecord->ExceptionCode;

    static ULONGLONG s_LastCrashLogTime = 0;
    static void* s_LastCrashAddr = nullptr;

    if (code == 0xC0000005 || code == 0xC000001D || code == 0xC0000094 || code == 0x80000003) {
        void* crashAddr = pExc->ExceptionRecord->ExceptionAddress;
        ULONGLONG now = GetTickCount64();

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

        TraceLog("CRASH", "========================================================");
        TraceLog("CRASH", "!!! CRASH EXCEPTION DETECTED (Code: 0x%08X) !!!", code);
        TraceLog("CRASH", "Crash Location   : 0x%p (%s + 0x%llX)", crashAddr, modName, (unsigned long long)offset);

        if (code == 0xC0000005 && pExc->ExceptionRecord->NumberParameters >= 2) {
            ULONG_PTR accessType = pExc->ExceptionRecord->ExceptionInformation[0];
            ULONG_PTR targetAddr = pExc->ExceptionRecord->ExceptionInformation[1];
            TraceLog("CRASH", "Memory Violation : Attempted %s at address 0x%p",
                     accessType == 0 ? "READ" : (accessType == 1 ? "WRITE" : "EXECUTE"), (void*)targetAddr);
        }

        if (pExc->ContextRecord) {
            TraceLog("CRASH", "CPU Registers: RIP=0x%016llX RSP=0x%016llX RBP=0x%016llX RAX=0x%016llX RBX=0x%016llX RCX=0x%016llX RDX=0x%016llX",
                     (unsigned long long)pExc->ContextRecord->Rip,
                     (unsigned long long)pExc->ContextRecord->Rsp,
                     (unsigned long long)pExc->ContextRecord->Rbp,
                     (unsigned long long)pExc->ContextRecord->Rax,
                     (unsigned long long)pExc->ContextRecord->Rbx,
                     (unsigned long long)pExc->ContextRecord->Rcx,
                     (unsigned long long)pExc->ContextRecord->Rdx);
        }
        TraceLog("CRASH", "========================================================");
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
Il2CppClass* g_GameCountdownClass       = nullptr;
Il2CppClass* g_LevelLoaderClass         = nullptr;
Il2CppClass* g_PlayerEndGameClass       = nullptr;
Il2CppClass* g_HealthGracePeriodClass   = nullptr;
MethodInfo*  g_DisableCountdownMethod   = nullptr;
MethodInfo*  g_DestroyPlayerMethod      = nullptr;
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

    const char* typeStrs[] = { "ERROR", "ASSERT", "WARNING", "LOG", "EXCEPTION" };
    const char* tStr = (logType >= 0 && logType <= 4) ? typeStrs[logType] : "UNKNOWN";

    char formatted[1024];
    snprintf(formatted, sizeof(formatted), "[%s] [%s] %s", tBuf, tStr, msg.c_str());

    WriteGameEngineLogToFile(formatted);
    TraceLog("GAME", "[%s] %s", tStr, msg.c_str());
}

// Convert Il2CppString to std::string
static std::string Il2CppStringToStdString(Il2CppString* str) {
    if (!IsValidMemPtr(str, 0x18)) return "";
    int32_t len = *(int32_t*)((char*)str + 0x10);
    if (len <= 0 || len > 4096) return "";
    wchar_t* chars = (wchar_t*)((char*)str + 0x14);
    if (!IsValidMemPtr(chars, len * sizeof(wchar_t))) return "";
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
        if (msg && IsValidMemPtr(msg, 0x18)) {
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
        if (exc && IsValidMemPtr(exc, 0x20)) {
            Il2CppString* msgStr = *(Il2CppString**)((char*)exc + 0x18);
            if (msgStr && IsValidMemPtr(msgStr, 0x18)) {
                std::string str = Il2CppStringToStdString(msgStr);
                LogGameMessage(4, str.empty() ? "Uncaught Unity Game Exception" : str);
            }
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {}

    if (oInternal_LogException) {
        oInternal_LogException(exc, obj, method);
    }
}

// ─── Lobby Event Hook Definitions ────────────────────────────────────────────
typedef void (*OnLobbyEntered_t)(void* __this, void* callback, const MethodInfo* method);
OnLobbyEntered_t oOnLobbyEntered = nullptr;

void hkOnLobbyEntered(void* __this, void* callback, const MethodInfo* method) {
    uint64_t lId = g_Il2Cpp.GetCurrentLobbyID();
    TraceLog("LOBBY", "Entered game lobby! CurrentLobbyID=0x%llX", (unsigned long long)lId);
    if (oOnLobbyEntered) {
        oOnLobbyEntered(__this, callback, method);
    }
}

typedef void (*OnLobbyCreated_t)(void* __this, void* callback, const MethodInfo* method);
OnLobbyCreated_t oOnLobbyCreated = nullptr;

void hkOnLobbyCreated(void* __this, void* callback, const MethodInfo* method) {
    TraceLog("LOBBY", "Hosted new game lobby! Initializing room settings.");
    if (oOnLobbyCreated) {
        oOnLobbyCreated(__this, callback, method);
    }
}

typedef void (*OnLobbyKicked_t)(void* __this, void* callback, const MethodInfo* method);
OnLobbyKicked_t oOnLobbyKicked = nullptr;

void hkOnLobbyKicked(void* __this, void* callback, const MethodInfo* method) {
    TraceLog("LOBBY", "[!] Disconnected or kicked from lobby!");
    if (oOnLobbyKicked) {
        oOnLobbyKicked(__this, callback, method);
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

// ─── Fast Loading & End-Game Match Terminator Exploits ───────────────────────
bool  bFastLoadingOptimizer  = true;   // Instant countdown & level loading bypass
bool  bEndGameMatchTrigger   = false;  // Force match termination & victory trigger

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
    f << "bFastLoadingOptimizer=" << bFastLoadingOptimizer << "\n";

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
            else if (key == "bFastLoadingOptimizer") bFastLoadingOptimizer = ParseBool(val);

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
    if (g_pd3dDeviceContext) {
        ID3D11RenderTargetView* nullViews[] = { nullptr };
        g_pd3dDeviceContext->OMSetRenderTargets(1, nullViews, nullptr);
    }
    if (g_mainRenderTargetView) {
        g_mainRenderTargetView->Release();
        g_mainRenderTargetView = nullptr;
    }
}

static void CreateRTV(IDXGISwapChain* pSwapChain) {
    if (!g_pd3dDevice || !pSwapChain) return;
    ID3D11Texture2D* pBB = nullptr;
    if (SUCCEEDED(pSwapChain->GetBuffer(0, __uuidof(ID3D11Texture2D), (LPVOID*)&pBB))) {
        if (pBB) {
            g_pd3dDevice->CreateRenderTargetView(pBB, NULL, &g_mainRenderTargetView);
            pBB->Release();
        }
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

// ─── Unity Cursor Hooks (Prevents Unity from re-locking cursor while menu is open) ───
typedef void (*SetLockState_t)(int lockMode);
typedef void (*SetVisible_t)(bool visible);
SetLockState_t oSetLockState = nullptr;
SetVisible_t   oSetVisible   = nullptr;

void hkSetLockState(int lockMode) {
    if (g_ShowMenu) {
        if (oSetLockState) oSetLockState(0); // CursorLockMode.None
        return;
    }
    if (oSetLockState) oSetLockState(lockMode);
}

void hkSetVisible(bool visible) {
    if (g_ShowMenu) {
        if (oSetVisible) oSetVisible(true);
        return;
    }
    if (oSetVisible) oSetVisible(visible);
}

static void EnsureCursorUnlocked(bool menuOpen) {
    if (menuOpen) {
        ClipCursor(NULL);
        g_Il2Cpp.SetCursorState(true);
    }
}

// ─── WndProc Hook — Fixed input routing for ImGui interaction ────────────────
LRESULT __stdcall WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam) {
    if (!g_IsInitialized || !oWndProc || g_Uninjecting)
        return DefWindowProc(hWnd, uMsg, wParam, lParam);

    // ── Toggle menu with Insert or F1 ──
    if (uMsg == WM_KEYDOWN || uMsg == WM_SYSKEYDOWN) {
        if (wParam == VK_INSERT || wParam == VK_F1) {
            g_ShowMenu = !g_ShowMenu;
            EnsureCursorUnlocked(g_ShowMenu);
            ImGui::GetIO().MouseDrawCursor = g_ShowMenu;
            return 0;
        }
        // ESC closes cheat menu if open, otherwise let ESC pass to game pause menu!
        if (wParam == VK_ESCAPE && g_ShowMenu) {
            g_ShowMenu = false;
            ImGui::GetIO().MouseDrawCursor = false;
            return 0;
        }
    }

    if (g_ShowMenu) {
        // Pass events to ImGui handler
        ImGui_ImplWin32_WndProcHandler(hWnd, uMsg, wParam, lParam);

        // Windows cursor display: hide OS cursor since ImGui draws its own cursor (prevents double cursor)
        if (uMsg == WM_SETCURSOR) {
            SetCursor(NULL);
            return 1;
        }

        // Swallow mouse and keyboard input messages only, so the game doesn't process them while menu is open
        if ((uMsg >= WM_MOUSEFIRST && uMsg <= WM_MOUSELAST) ||
            (uMsg >= WM_KEYFIRST && uMsg <= WM_KEYLAST) ||
            uMsg == WM_CHAR || uMsg == WM_INPUT) {
            return 0;
        }
    }

    // Pass all other window messages to the game's original WndProc
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

// ─── Unified Crash-Proof Entity Cache & Memory Structure ─────────────────────
struct CachedPlayerInfo {
    void* playerObj     = nullptr;
    bool  isLocal       = false;
    bool  awayTeam      = false;
    bool  isEnemy       = true;
    bool  isDead        = false;
    int   hp            = 100;
    int   maxHp         = 100;

    void* spineRb       = nullptr;
    void* rootRb        = nullptr;
    void* lFootRb       = nullptr;
    void* rFootRb       = nullptr;
    void* lKneeRb       = nullptr;
    void* rKneeRb       = nullptr;
    void* lHandRb       = nullptr;
    void* rHandRb       = nullptr;
    void* lElbowRb      = nullptr;
    void* rElbowRb      = nullptr;
    void* lUpperArmRb   = nullptr;
    void* rUpperArmRb   = nullptr;
    void* lShoulderRb   = nullptr;
    void* rShoulderRb   = nullptr;
    void* chestRb       = nullptr;

    void* healthComp    = nullptr;
    void* graceComp     = nullptr;
    void* playerMovement= nullptr;
    void* weaponManager = nullptr;
};

static std::vector<CachedPlayerInfo> g_CachedPlayers;
static CachedPlayerInfo              g_LocalPlayerInfo;
static bool                          g_HasLocalPlayer      = false;
static ULONGLONG                     g_LastPlayerScanTime  = 0;

static void ScanGameEntities() {
    ULONGLONG now = GetTickCount64();
    if (now - g_LastPlayerScanTime < 60) return; // Throttle to ~16 Hz, eliminating GC allocation spam & memory corruption
    g_LastPlayerScanTime = now;

    if (!g_PlayerClass) return;

    __try {
        g_Il2Cpp.EnsureThreadAttached();
        Il2CppArray* arr = g_Il2Cpp.FindObjectsOfType(g_PlayerClass);
        if (!arr || !IsValidMemPtr(arr, 0x28)) return;

        uintptr_t count = *(uintptr_t*)((char*)arr + 0x18);
        if (count == 0 || count > 64) return;

        void** items = (void**)((char*)arr + 0x20);
        if (!IsValidMemPtr(items, count * sizeof(void*))) return;

        std::vector<CachedPlayerInfo> newPlayers;
        newPlayers.reserve(count);

        bool foundLocal = false;
        CachedPlayerInfo localInfo{};

        for (uintptr_t i = 0; i < count; i++) {
            void* p = items[i];
            if (!IsValidUnityObj(p)) continue;
            if (!g_Il2Cpp.IsGameObjectActiveInHierarchy(p) || !g_Il2Cpp.IsSpawned(p)) continue;

            CachedPlayerInfo info{};
            info.playerObj = p;
            info.isLocal = g_Il2Cpp.IsLocalPlayer(p);

            // Read Health: SyncVar<int> at Health+0x100 is a heap object, _value is at +0x84 inside it
            if (g_HealthClass) {
                info.healthComp = g_Il2Cpp.GetComponent(p, g_HealthClass);
                if (info.healthComp && IsValidUnityObj(info.healthComp)) {
                    info.maxHp = *(int*)((char*)info.healthComp + 0xF8);
                    if (info.maxHp <= 0 || info.maxHp > 10000) info.maxHp = 100;

                    // SyncVar<int> object ptr at +0x100; _value field at SyncVar_obj+0x84
                    void* curHpSyncVarObj = *(void**)((char*)info.healthComp + 0x100);
                    if (curHpSyncVarObj && IsValidMemPtr(curHpSyncVarObj, 0x90)) {
                        info.hp = *(int*)((char*)curHpSyncVarObj + 0x84);
                    } else {
                        info.hp = info.maxHp;
                    }

                    if (info.hp < 0 || info.hp > 10000) info.hp = info.maxHp;
                    info.isDead = (info.hp <= 0);
                }
            }

            // Read Team
            if (g_PlayerMovementClass) {
                info.playerMovement = g_Il2Cpp.GetComponent(p, g_PlayerMovementClass);
                if (info.playerMovement && IsValidUnityObj(info.playerMovement)) {
                    info.awayTeam = *(bool*)((char*)info.playerMovement + 0x1C4);
                }
            } else if (g_SharedRefClass) {
                void* sr = g_Il2Cpp.GetComponent(p, g_SharedRefClass);
                if (sr && IsValidUnityObj(sr)) {
                    info.awayTeam = *(bool*)((char*)sr + 0x108);
                }
            }

            if (g_WeaponManagerClass) {
                info.weaponManager = g_Il2Cpp.GetComponent(p, g_WeaponManagerClass);
            }
            if (g_HealthGracePeriodClass) {
                info.graceComp = g_Il2Cpp.GetComponent(p, g_HealthGracePeriodClass);
            }

            auto ReadRb = [](void* obj, size_t offset) -> void* {
                void* rb = *(void**)((char*)obj + offset);
                return (rb && IsValidUnityObj(rb)) ? rb : nullptr;
            };

            info.spineRb     = ReadRb(p, 0x100);
            info.rootRb      = ReadRb(p, 0x108);
            info.lFootRb     = ReadRb(p, 0x110);
            info.rFootRb     = ReadRb(p, 0x118);
            info.lKneeRb     = ReadRb(p, 0x120);
            info.rKneeRb     = ReadRb(p, 0x128);
            info.lHandRb     = ReadRb(p, 0x130);
            info.rHandRb     = ReadRb(p, 0x138);
            info.lElbowRb    = ReadRb(p, 0x140);
            info.rElbowRb    = ReadRb(p, 0x148);
            info.lUpperArmRb = ReadRb(p, 0x150);
            info.rUpperArmRb = ReadRb(p, 0x158);
            info.lShoulderRb = ReadRb(p, 0x160);
            info.rShoulderRb = ReadRb(p, 0x168);
            info.chestRb     = ReadRb(p, 0x170);

            if (info.isLocal) {
                foundLocal = true;
                localInfo = info;
            }

            newPlayers.push_back(info);
        }

        for (auto& pl : newPlayers) {
            pl.isEnemy = foundLocal ? (pl.awayTeam != localInfo.awayTeam) : true;
        }

        g_CachedPlayers  = newPlayers;
        g_HasLocalPlayer = foundLocal;
        if (foundLocal) {
            g_LocalPlayerInfo = localInfo;
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {}
}

// ─── Helper to resolve bone world & screen position ──────────────────────────
static void ResolveBoneSafe(void* mainCam, void* rbPtr, BonePoint& outBone) {
    outBone.valid = false;
    if (!rbPtr || !mainCam || !IsValidUnityObj(rbPtr) || !IsValidUnityObj(mainCam)) return;

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
        if (g_HasLocalPlayer) {
            if (g_LocalPlayerInfo.playerMovement && IsValidUnityObj(g_LocalPlayerInfo.playerMovement)) {
                void* rCamCtrl = *(void**)((char*)g_LocalPlayerInfo.playerMovement + 0x220);
                if (rCamCtrl && IsValidUnityObj(rCamCtrl)) {
                    void* rCam = *(void**)((char*)rCamCtrl + 0x140);
                    if (rCam && IsValidUnityObj(rCam)) return rCam;
                }
            }
        }
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
        if (!activeCam || !IsValidUnityObj(activeCam)) {
            g_ESPData.clear();
            return;
        }

        std::vector<PlayerESPData> newData;
        newData.reserve(g_CachedPlayers.size());

        for (const auto& pl : g_CachedPlayers) {
            if (!IsValidUnityObj(pl.playerObj)) continue;
            if (bIgnoreDead && (pl.isDead || pl.hp <= 0)) continue;
            if (bIgnoreTeammates && !pl.isEnemy && !pl.isLocal) continue;
            if (bIgnoreLocal && pl.isLocal) continue;

            PlayerESPData data{};
            data.isLocal  = pl.isLocal;
            data.hp       = pl.hp;
            data.maxHp    = pl.maxHp;
            data.isDead   = pl.isDead;
            data.awayTeam = pl.awayTeam;
            data.isEnemy  = pl.isEnemy;

            ResolveBoneSafe(activeCam, pl.chestRb,     data.chest);
            ResolveBoneSafe(activeCam, pl.spineRb,     data.spine);
            ResolveBoneSafe(activeCam, pl.rootRb,      data.root);
            ResolveBoneSafe(activeCam, pl.lShoulderRb, data.lShoulder);
            ResolveBoneSafe(activeCam, pl.lUpperArmRb, data.lUpperArm);
            ResolveBoneSafe(activeCam, pl.lElbowRb,    data.lElbow);
            ResolveBoneSafe(activeCam, pl.lHandRb,     data.lHand);
            ResolveBoneSafe(activeCam, pl.rShoulderRb, data.rShoulder);
            ResolveBoneSafe(activeCam, pl.rUpperArmRb, data.rUpperArm);
            ResolveBoneSafe(activeCam, pl.rElbowRb,    data.rElbow);
            ResolveBoneSafe(activeCam, pl.rHandRb,     data.rHand);
            ResolveBoneSafe(activeCam, pl.lKneeRb,     data.lKnee);
            ResolveBoneSafe(activeCam, pl.lFootRb,     data.lFoot);
            ResolveBoneSafe(activeCam, pl.rKneeRb,     data.rKnee);
            ResolveBoneSafe(activeCam, pl.rFootRb,     data.rFoot);

            // Compute head position
            if (data.chest.valid) {
                Vector3 headWorld = data.chest.world + Vector3(0.0f, 0.40f, 0.0f);
                data.head.world   = headWorld;
                if (g_Il2Cpp.WorldToScreen(activeCam, headWorld, &data.head.screen)) {
                    if (data.head.screen.z > 0.5f && data.head.screen.z < 500.0f &&
                        !std::isnan(data.head.screen.x) && !std::isnan(data.head.screen.y)) {
                        data.head.valid = true;
                    }
                }
            }

            // Distance
            if (data.root.valid) {
                data.distance = data.root.screen.z;
            } else if (data.chest.valid) {
                data.distance = data.chest.screen.z;
            }

            if (data.distance > fMaxDistance || data.distance <= 0.0f) continue;

            // Compute 2D bounding box
            float minX = 99999.0f, maxX = -99999.0f;
            float minY = 99999.0f, maxY = -99999.0f;
            int validCount = 0;

            const BonePoint* allBones[] = {
                &data.head, &data.chest, &data.spine, &data.root,
                &data.lShoulder, &data.lUpperArm, &data.lElbow, &data.lHand,
                &data.rShoulder, &data.rUpperArm, &data.rElbow, &data.rHand,
                &data.lKnee, &data.lFoot, &data.rKnee, &data.rFoot
            };

            for (const auto* b : allBones) {
                if (b->valid) {
                    if (b->screen.x < minX) minX = b->screen.x;
                    if (b->screen.x > maxX) maxX = b->screen.x;
                    if (b->screen.y < minY) minY = b->screen.y;
                    if (b->screen.y > maxY) maxY = b->screen.y;
                    validCount++;
                }
            }

            if (validCount >= 2) {
                float padX = (maxX - minX) * 0.20f;
                if (padX < 6.0f) padX = 6.0f;
                float padY = (maxY - minY) * 0.12f;
                if (padY < 6.0f) padY = 6.0f;

                data.boxMinX = minX - padX;
                data.boxMaxX = maxX + padX;
                data.boxMinY = minY - padY;
                data.boxMaxY = maxY + padY;
                data.hasBox  = true;
            }

            // Aimbot target selection point
            if (iAimbotTarget == 1 && data.head.valid) {
                data.aimScreenPos = data.head.screen;
            } else if (data.chest.valid) {
                data.aimScreenPos = data.chest.screen;
            } else if (data.root.valid) {
                data.aimScreenPos = data.root.screen;
            }

            newData.push_back(data);
        }

        g_ESPData = newData;
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

        float boneDist = (a.screen.z + b.screen.z) * 0.5f;
        float radiusA  = (jointRadius * 80.0f / (a.screen.z + 1.0f));
        float radiusB  = (jointRadius * 80.0f / (b.screen.z + 1.0f));
        if (radiusA < 2.0f) radiusA = 2.0f;
        if (radiusA > 40.0f) radiusA = 40.0f;
        if (radiusB < 2.0f) radiusB = 2.0f;
        if (radiusB > 40.0f) radiusB = 40.0f;

        float effectiveAlpha = alpha;
        if (style == 3) {
            static float pulseTimer = 0.0f;
            pulseTimer += 0.02f;
            effectiveAlpha *= (0.60f + 0.40f * sinf(pulseTimer * 3.0f));
        }

        ImU32 fillCol   = ImGui::ColorConvertFloat4ToU32(ImVec4(color[0], color[1], color[2], effectiveAlpha));
        ImU32 borderCol = ImGui::ColorConvertFloat4ToU32(ImVec4(color[0] * 1.3f, color[1] * 1.3f, color[2] * 1.3f, 1.0f));

        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float len = sqrtf(dx * dx + dy * dy);
        if (len < 0.001f) return;
        float nx = -dy / len;
        float ny =  dx / len;

        ImVec2 q1(p1.x + nx * radiusA, p1.y + ny * radiusA);
        ImVec2 q2(p1.x - nx * radiusA, p1.y - ny * radiusA);
        ImVec2 q3(p2.x - nx * radiusB, p2.y - ny * radiusB);
        ImVec2 q4(p2.x + nx * radiusB, p2.y + ny * radiusB);

        if (style == 0 || style == 1 || style == 3) {
            dl->AddQuadFilled(q1, q2, q3, q4, fillCol);
            dl->AddCircleFilled(p1, radiusA, fillCol);
            dl->AddCircleFilled(p2, radiusB, fillCol);
        }

        if (style == 2 || style == 3 || style == 1) {
            float borderThick = (style == 2) ? 2.0f : 1.2f;
            dl->AddQuad(q1, q2, q3, q4, borderCol, borderThick);
            dl->AddCircle(p1, radiusA, borderCol, 0, borderThick);
            dl->AddCircle(p2, radiusB, borderCol, 0, borderThick);
        }
    };

    auto DrawFullSkeletonChams = [&](const PlayerESPData& data, float* color, float alpha, float jointRadius, int style) {
        DrawChamsSegment(data.head,      data.chest,     color, alpha, jointRadius * 1.3f, style);
        DrawChamsSegment(data.chest,     data.spine,     color, alpha, jointRadius * 1.1f, style);
        DrawChamsSegment(data.spine,     data.root,      color, alpha, jointRadius * 1.0f, style);
        DrawChamsSegment(data.chest,     data.lShoulder, color, alpha, jointRadius * 0.9f, style);
        DrawChamsSegment(data.lShoulder, data.lUpperArm, color, alpha, jointRadius * 0.8f, style);
        DrawChamsSegment(data.lUpperArm, data.lElbow,    color, alpha, jointRadius * 0.8f, style);
        DrawChamsSegment(data.lElbow,    data.lHand,     color, alpha, jointRadius * 0.7f, style);
        DrawChamsSegment(data.chest,     data.rShoulder, color, alpha, jointRadius * 0.9f, style);
        DrawChamsSegment(data.rShoulder, data.rUpperArm, color, alpha, jointRadius * 0.8f, style);
        DrawChamsSegment(data.rUpperArm, data.rElbow,    color, alpha, jointRadius * 0.8f, style);
        DrawChamsSegment(data.rElbow,    data.rHand,     color, alpha, jointRadius * 0.7f, style);
        DrawChamsSegment(data.root,      data.lKnee,     color, alpha, jointRadius * 0.9f, style);
        DrawChamsSegment(data.lKnee,     data.lFoot,     color, alpha, jointRadius * 0.8f, style);
        DrawChamsSegment(data.root,      data.rKnee,     color, alpha, jointRadius * 0.9f, style);
        DrawChamsSegment(data.rKnee,     data.rFoot,     color, alpha, jointRadius * 0.8f, style);
    };

    // Draw FOV circles
    float cx = sw * 0.5f;
    float cy = sh * 0.5f;

    if (bEnableAimbot && bDrawAimbotFOV && aimbotFOV > 0.0f) {
        dl->AddCircle(ImVec2(cx, cy), aimbotFOV, IM_COL32(0, 230, 255, 120), 64, 1.5f);
        if (bEnableGlow) {
            dl->AddCircle(ImVec2(cx, cy), aimbotFOV, IM_COL32(0, 230, 255, 35), 64, 4.0f);
        }
    }

    if (bEnableSilentAim && bDrawSilentAimFOV && !bSilentAimFull360 && fSilentAimFOV > 0.0f) {
        dl->AddCircle(ImVec2(cx, cy), fSilentAimFOV, IM_COL32(255, 80, 120, 140), 64, 1.5f);
        if (bEnableGlow) {
            dl->AddCircle(ImVec2(cx, cy), fSilentAimFOV, IM_COL32(255, 80, 120, 40), 64, 4.0f);
        }
    }

    for (const auto& data : g_ESPData) {
        float* primaryCol = data.isEnemy ? colEnemy : colTeam;

        // Chams
        if (bEnableChams) {
            float* chamsCol = data.isEnemy ? colChamsEnemyVis : colChamsTeamVis;
            DrawFullSkeletonChams(data, chamsCol, fChamsAlpha, fChamsJointSize, iChamsStyle);
        }

        // Skeletons
        if (bDrawSkeleton) {
            DrawBoneLine(data.head,      data.chest,     colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.chest,     data.spine,     colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.spine,     data.root,      colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.chest,     data.lShoulder, colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.lShoulder, data.lUpperArm, colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.lUpperArm, data.lElbow,    colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.lElbow,    data.lHand,     colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.chest,     data.rShoulder, colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.rShoulder, data.rUpperArm, colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.rUpperArm, data.rElbow,    colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.rElbow,    data.rHand,     colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.root,      data.lKnee,     colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.lKnee,     data.lFoot,     colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.root,      data.rKnee,     colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.rKnee,     data.rFoot,     colSkeleton, fSkeletonThickness);
        }

        // Head Circle
        if (bDrawHeadCircle && data.head.valid) {
            ImVec2 headCenter(data.head.screen.x, sh - data.head.screen.y);
            float radius = (18.0f * fHeadCircleSize) / (data.head.screen.z + 1.0f);
            if (radius < 2.5f)  radius = 2.5f;
            if (radius > 45.0f) radius = 45.0f;

            if (bEnableGlow) {
                ImU32 glowColOuter = MakeGlowColor(colHeadCircle, 0.20f * fGlowIntensity);
                ImU32 glowColMid   = MakeGlowColor(colHeadCircle, 0.40f * fGlowIntensity);
                dl->AddCircle(headCenter, radius, glowColOuter, 32, fSkeletonThickness + 4.0f);
                dl->AddCircle(headCenter, radius, glowColMid,   32, fSkeletonThickness + 2.0f);
            }
            ImU32 coreCol = MakeGlowColor(colHeadCircle, 1.0f);
            dl->AddCircle(headCenter, radius, coreCol, 32, fSkeletonThickness);
        }

        // Bounding Boxes
        if (bDrawBoxes && data.hasBox) {
            ImVec2 bMin(data.boxMinX, sh - data.boxMaxY);
            ImVec2 bMax(data.boxMaxX, sh - data.boxMinY);

            if (bEnableGlow) {
                ImU32 glowColOuter = MakeGlowColor(primaryCol, 0.15f * fGlowIntensity);
                ImU32 glowColMid   = MakeGlowColor(primaryCol, 0.30f * fGlowIntensity);
                dl->AddRect(bMin, bMax, glowColOuter, 2.0f, 0, fBoxThickness + 4.0f);
                dl->AddRect(bMin, bMax, glowColMid,   2.0f, 0, fBoxThickness + 2.0f);
            }
            ImU32 coreCol = MakeGlowColor(primaryCol, 1.0f);
            dl->AddRect(bMin, bMax, coreCol, 2.0f, 0, fBoxThickness);
        }

        // Tracers
        if (bDrawTracers && (data.root.valid || data.chest.valid)) {
            const BonePoint& targetBone = data.root.valid ? data.root : data.chest;
            ImVec2 startPos;
            if (iTracerOrigin == 0)      startPos = ImVec2(cx, sh);
            else if (iTracerOrigin == 1) startPos = ImVec2(cx, cy);
            else                         startPos = ImVec2(cx, 0.0f);

            ImVec2 endPos(targetBone.screen.x, sh - targetBone.screen.y);

            if (bEnableGlow) {
                ImU32 glowColOuter = MakeGlowColor(colTracers, 0.15f * fGlowIntensity);
                ImU32 glowColMid   = MakeGlowColor(colTracers, 0.30f * fGlowIntensity);
                dl->AddLine(startPos, endPos, glowColOuter, fTracerThickness + 3.0f);
                dl->AddLine(startPos, endPos, glowColMid,   fTracerThickness + 1.5f);
            }
            ImU32 coreCol = MakeGlowColor(colTracers, 0.85f);
            dl->AddLine(startPos, endPos, coreCol, fTracerThickness);
        }

        // Health Bar & Info Text
        if ((bDrawHealthBar || bDrawInfoText) && data.hasBox) {
            float boxH = (data.boxMaxY - data.boxMinY);
            float boxTopY = sh - data.boxMaxY;

            if (bDrawHealthBar) {
                float barW = 4.0f;
                float barX = data.boxMinX - barW - 3.0f;
                float hpRatio = (data.maxHp > 0) ? ((float)data.hp / (float)data.maxHp) : 1.0f;
                if (hpRatio < 0.0f) hpRatio = 0.0f;
                if (hpRatio > 1.0f) hpRatio = 1.0f;

                ImU32 barBg = IM_COL32(20, 20, 25, 200);
                dl->AddRectFilled(ImVec2(barX, boxTopY), ImVec2(barX + barW, boxTopY + boxH), barBg);

                ImU32 hpColor;
                if (hpRatio > 0.60f)      hpColor = IM_COL32(50, 220, 90, 255);
                else if (hpRatio > 0.25f) hpColor = IM_COL32(240, 180, 30, 255);
                else                      hpColor = IM_COL32(240, 45, 45, 255);

                float filledH = boxH * hpRatio;
                dl->AddRectFilled(ImVec2(barX, boxTopY + (boxH - filledH)), ImVec2(barX + barW, boxTopY + boxH), hpColor);
            }

            if (bDrawInfoText) {
                char textBuf[128];
                snprintf(textBuf, sizeof(textBuf), "%s | %dm | %d HP",
                         data.isEnemy ? "ENEMY" : "TEAM",
                         (int)data.distance, data.hp);

                ImVec2 textSize = ImGui::CalcTextSize(textBuf);
                float textX = data.boxMinX + ((data.boxMaxX - data.boxMinX) - textSize.x) * 0.5f;
                float textY = boxTopY - textSize.y - 3.0f;

                dl->AddRectFilled(ImVec2(textX - 3.0f, textY - 1.0f),
                                  ImVec2(textX + textSize.x + 3.0f, textY + textSize.y + 1.0f),
                                  IM_COL32(10, 12, 18, 190), 3.0f);

                dl->AddText(ImVec2(textX, textY), MakeGlowColor(primaryCol, 1.0f), textBuf);
            }
        }
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

    float bestDist = (aimbotFOV > 0.0f) ? aimbotFOV : 99999.0f;
    float tgtX = 0.0f, tgtY = 0.0f;

    for (const auto& data : g_ESPData) {
        if (!data.isEnemy) continue;
        if (data.isDead || data.hp <= 0) continue;
        if (data.aimScreenPos.z <= 0.5f) continue;

        float sx = data.aimScreenPos.x;
        float sy = sh - data.aimScreenPos.y;

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
    if (!outTargetPos) return false;

    void* activeCam = GetCurrentGameCamera();
    ImGuiIO& io = ImGui::GetIO();
    float cx = io.DisplaySize.x * 0.5f;
    float cy = io.DisplaySize.y * 0.5f;
    float sh = io.DisplaySize.y;

    float bestScore = 9999999.0f;
    Vector3 bestPos{};
    bool found = false;

    for (const auto& pl : g_CachedPlayers) {
        if (!pl.isEnemy || pl.isDead || pl.hp <= 0) continue;
        if (!IsValidUnityObj(pl.playerObj)) continue;

        void* targetRb = pl.chestRb ? pl.chestRb : pl.rootRb;
        if (!targetRb || !IsValidUnityObj(targetRb)) continue;

        Vector3 bonePos{};
        if (!g_Il2Cpp.GetRigidbodyPosition(targetRb, &bonePos)) continue;
        if (fabsf(bonePos.x) < 0.001f && fabsf(bonePos.y) < 0.001f && fabsf(bonePos.z) < 0.001f) continue;

        if (iSilentAimTarget == 1) {
            bonePos = bonePos + Vector3(0.0f, 0.40f, 0.0f); // Head
        }

        float score = 0.0f;
        if (!bSilentAimFull360 && activeCam && IsValidUnityObj(activeCam)) {
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
    // Silent Aim: only redirect _cameraForward; always call original with valid arrays
    Il2CppArray* outPos = _cameraPosition;
    Il2CppArray* outFwd = _cameraForward;

    __try {
        if (bEnableSilentAim && outPos && outFwd && IsValidUnityObj(__this)) {
            Vector3 targetWorldPos{};
            if (GetSilentAimTargetPosition(&targetWorldPos)) {
                // Get camera origin from scene camera (safer than invoking UnpackShort on network data)
                Vector3 camPos{};
                void* activeCam = GetCurrentGameCamera();
                if (activeCam && IsValidUnityObj(activeCam)) {
                    void* camTr = g_Il2Cpp.GetComponentTransform(activeCam);
                    if (camTr && IsValidUnityObj(camTr)) g_Il2Cpp.GetTransformPosition(camTr, &camPos);
                }

                if (camPos.LengthSq() > 0.0001f) {
                    Vector3 aimDir = targetWorldPos - camPos;
                    float len = aimDir.Length();
                    if (len > 0.001f) {
                        aimDir = aimDir * (1.0f / len);
                        if (g_PackDirectionMethod) {
                            void* args[1] = { &aimDir };
                            void* exc = nullptr;
                            Il2CppObject* packedArr = g_Il2Cpp.il2cpp_runtime_invoke(g_PackDirectionMethod, nullptr, args, &exc);
                            // Only use packed result if it is a valid, non-null array object
                            if (!exc && packedArr && IsValidMemPtr(packedArr, 0x20)) {
                                // Pin the packed array from GC during this call by keeping it on stack
                                outFwd = (Il2CppArray*)packedArr;
                            }
                        }
                    }
                }
            }
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {
        // On any error revert to original arrays
        outPos = _cameraPosition;
        outFwd = _cameraForward;
    }

    if (oCMDShoot && __this && IsValidUnityObj(__this)
        && outPos && IsValidMemPtr(outPos, 0x20)
        && outFwd && IsValidMemPtr(outFwd, 0x20)) {
        oCMDShoot(__this, outPos, outFwd, tick, method);
    } else if (oCMDShoot && __this && IsValidUnityObj(__this)) {
        oCMDShoot(__this, _cameraPosition, _cameraForward, tick, method);
    }
}

// ─── Instant Teleportation & Auto-Shoot Kill Aura (Auto-Cycle Targets) ───────
static uintptr_t g_CurrentTeleportTarget = 0;
static ULONGLONG g_LastTeleShootTime    = 0;
static ULONGLONG g_LastTeleportTime     = 0;

static void DoTeleportKill(ImGuiIO& io) {
    if (g_ShowMenu) return;
    if (!bEnableTeleportKill) return;
    if (bTeleportHoldKey && !IsKeyActive(iTeleportKey)) return;
    if (!g_HasLocalPlayer) return;

    ULONGLONG now = GetTickCount64();
    if (now - g_LastTeleportTime < 200) return; // Rate-limit to prevent PhysX engine lockup
    g_LastTeleportTime = now;

    __try {
        if (!IsValidUnityObj(g_LocalPlayerInfo.playerObj) || g_LocalPlayerInfo.isDead) {
            g_CurrentTeleportTarget = 0;
            return;
        }

        void* localRootRb = g_LocalPlayerInfo.rootRb ? g_LocalPlayerInfo.rootRb : g_LocalPlayerInfo.chestRb;
        if (!localRootRb || !IsValidUnityObj(localRootRb)) return;

        Vector3 localRootPos{};
        if (!g_Il2Cpp.GetRigidbodyPosition(localRootRb, &localRootPos)) return;

        const CachedPlayerInfo* chosenEnemy = nullptr;
        for (const auto& pl : g_CachedPlayers) {
            if (pl.isEnemy && !pl.isDead && pl.hp > 0 && IsValidUnityObj(pl.playerObj)) {
                if (g_CurrentTeleportTarget != 0 && (uintptr_t)pl.playerObj == g_CurrentTeleportTarget) {
                    chosenEnemy = &pl;
                    break;
                }
            }
        }

        if (!chosenEnemy) {
            float closestDist = 99999.0f;
            for (const auto& pl : g_CachedPlayers) {
                if (!pl.isEnemy || pl.isDead || pl.hp <= 0 || !IsValidUnityObj(pl.playerObj)) continue;
                void* targetRb = pl.chestRb ? pl.chestRb : pl.rootRb;
                if (!targetRb || !IsValidUnityObj(targetRb)) continue;

                Vector3 tPos{};
                if (g_Il2Cpp.GetRigidbodyPosition(targetRb, &tPos)) {
                    float d = (tPos - localRootPos).Length();
                    if (d < closestDist) {
                        closestDist = d;
                        chosenEnemy = &pl;
                        g_CurrentTeleportTarget = (uintptr_t)pl.playerObj;
                    }
                }
            }
        }

        if (!chosenEnemy) {
            g_CurrentTeleportTarget = 0;
            return;
        }

        void* enemyRb = chosenEnemy->chestRb ? chosenEnemy->chestRb : chosenEnemy->rootRb;
        if (!enemyRb || !IsValidUnityObj(enemyRb)) return;

        Vector3 enemyPos{};
        if (!g_Il2Cpp.GetRigidbodyPosition(enemyRb, &enemyPos)) return;

        Vector3 enemyFwd(0.0f, 0.0f, 1.0f);
        if (chosenEnemy->playerMovement && IsValidUnityObj(chosenEnemy->playerMovement)) {
            void* orientTr = *(void**)((char*)chosenEnemy->playerMovement + 0x100);
            if (orientTr && IsValidUnityObj(orientTr)) g_Il2Cpp.GetTransformForward(orientTr, &enemyFwd);
        }

        Vector3 destPos = enemyPos - (enemyFwd * fTeleportDistance) + Vector3(0.0f, fTeleportHeight, 0.0f);

        // Move all local rigidbodies
        void* allLocalRbs[] = {
            g_LocalPlayerInfo.rootRb, g_LocalPlayerInfo.chestRb, g_LocalPlayerInfo.spineRb,
            g_LocalPlayerInfo.lFootRb, g_LocalPlayerInfo.rFootRb, g_LocalPlayerInfo.lKneeRb,
            g_LocalPlayerInfo.rKneeRb, g_LocalPlayerInfo.lHandRb, g_LocalPlayerInfo.rHandRb,
            g_LocalPlayerInfo.lElbowRb, g_LocalPlayerInfo.rElbowRb, g_LocalPlayerInfo.lUpperArmRb,
            g_LocalPlayerInfo.rUpperArmRb, g_LocalPlayerInfo.lShoulderRb, g_LocalPlayerInfo.rShoulderRb
        };

        for (void* rb : allLocalRbs) {
            if (rb && IsValidUnityObj(rb)) {
                g_Il2Cpp.MoveRigidbodyPosition(rb, destPos);
                g_Il2Cpp.SetRigidbodyLinearVelocity(rb, Vector3(0.0f, 0.0f, 0.0f));
            }
        }

        // Auto-shoot weapon
        if (bTeleportAutoShoot && g_LocalPlayerInfo.weaponManager && IsValidUnityObj(g_LocalPlayerInfo.weaponManager)) {
            if (now - g_LastTeleShootTime >= (ULONGLONG)fTeleportShootRate) {
                g_LastTeleShootTime = now;
                void* activeWep = *(void**)((char*)g_LocalPlayerInfo.weaponManager + 0x120);
                if (activeWep && IsValidUnityObj(activeWep) && g_ClientTryShoot) {
                    *(bool*)((char*)activeWep + 0x120) = true;
                    *(int*)((char*)activeWep + 0x114)  = 99999;
                    *(float*)((char*)activeWep + 0x110) = 0.0f;
                    void* exc = nullptr;
                    g_Il2Cpp.il2cpp_runtime_invoke(g_ClientTryShoot, activeWep, nullptr, &exc);
                }
            }
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {}
}

// ─── God Mode Routine (100% True Invulnerability & Instant Health) ───────────
// SyncVar<bool> canTakeDamage @ HealthGracePeriod+0x110 -> heap obj -> _value at +0x61
// SyncVar<int>  currentHealth @ Health+0x100            -> heap obj -> _value at +0x84
static void DoGodMode() {
    if (!bGodMode || !g_HasLocalPlayer) return;

    __try {
        if (!IsValidUnityObj(g_LocalPlayerInfo.playerObj)) return;

        // 1. Invincibility via HealthGracePeriod
        void* grace = g_LocalPlayerInfo.graceComp;
        if (!grace && g_HealthGracePeriodClass) {
            grace = g_Il2Cpp.GetComponent(g_LocalPlayerInfo.playerObj, g_HealthGracePeriodClass);
            g_LocalPlayerInfo.graceComp = grace;
        }

        if (grace && IsValidUnityObj(grace)) {
            // Write gracePeriod raw counter
            *(int*)((char*)grace + 0x11C) = 999999;

            // canTakeDamage is SyncVar<bool> obj at +0x110; write both direct fields & heap obj _value
            void* canTakeDmgSV = *(void**)((char*)grace + 0x110);
            if (canTakeDmgSV && IsValidMemPtr(canTakeDmgSV, 0x70)) {
                *(bool*)((char*)canTakeDmgSV + 0x61) = false; // _value = false => no damage
                *(bool*)((char*)canTakeDmgSV + 0x60) = false; // _initialValue = false
            }
        }

        // 2. Keep HP at max via SyncVar<int> _value field & direct fields
        void* hComp = g_LocalPlayerInfo.healthComp;
        if (!hComp && g_HealthClass) {
            hComp = g_Il2Cpp.GetComponent(g_LocalPlayerInfo.playerObj, g_HealthClass);
            g_LocalPlayerInfo.healthComp = hComp;
        }

        if (hComp && IsValidUnityObj(hComp)) {
            int maxHp = *(int*)((char*)hComp + 0xF8);
            if (maxHp <= 0 || maxHp > 10000) maxHp = 100;

            // Direct SyncVar object update
            void* hpSyncVarObj = *(void**)((char*)hComp + 0x100);
            if (hpSyncVarObj && IsValidMemPtr(hpSyncVarObj, 0x90)) {
                *(int*)((char*)hpSyncVarObj + 0x84) = maxHp; // _value
                *(int*)((char*)hpSyncVarObj + 0x80) = maxHp; // _initialValue
            }

            // Also invoke CMDChangeCurrentHealth to keep server state authoritative at max
            if (g_CMDChangeCurrentHealth) {
                int fullHp = maxHp;
                void* args[1] = { &fullHp };
                void* exc = nullptr;
                g_Il2Cpp.il2cpp_runtime_invoke(g_CMDChangeCurrentHealth, hComp, args, &exc);
            }
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {}
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
    if (!g_HasLocalPlayer || !g_LocalPlayerInfo.weaponManager) return;

    __try {
        void* wm = g_LocalPlayerInfo.weaponManager;
        if (!wm || !IsValidUnityObj(wm)) return;

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
        if (weaponsList && IsValidMemPtr(weaponsList, 0x20)) {
            Il2CppArray* wArr = *(Il2CppArray**)((char*)weaponsList + 0x10);
            int wCount = *(int*)((char*)weaponsList + 0x18);
            if (wArr && IsValidMemPtr(wArr, 0x28) && weaponIndex >= 0 && weaponIndex < wCount) {
                void** wItems = (void**)((char*)wArr + 0x20);
                for (int w = 0; w < wCount; w++) {
                    void* wObj = wItems[w];
                    if (!wObj || !IsValidUnityObj(wObj)) continue;
                    void* gunGo = *(void**)((char*)wObj + 0xF8);
                    if (w == weaponIndex) {
                        *(void**)((char*)wm + 0x120) = wObj;
                        *(bool*)((char*)wObj + 0x120) = true;
                        *(int*)((char*)wObj + 0x114)  = 99999;
                        *(float*)((char*)wObj + 0x110) = 0.0f;
                        if (gunGo && IsValidUnityObj(gunGo)) g_Il2Cpp.SetGameObjectActive(gunGo, true);
                    } else {
                        if (gunGo && IsValidUnityObj(gunGo)) g_Il2Cpp.SetGameObjectActive(gunGo, false);
                    }
                }
            }
        }
        CheatLog("GiveWeapon: Equipped weapon index %d (%s)", weaponIndex,
                 (weaponIndex >= 0 && weaponIndex < 8) ? g_WeaponNames[weaponIndex] : "Custom");
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {}
}

// ─── Server Crash: Flood RPC Queue safely ─────────────────────────────────────
static ULONGLONG g_LastServerCrashTime = 0;

static void DoServerCrash() {
    if (!g_HasLocalPlayer || !g_LocalPlayerInfo.healthComp || !g_CMDChangeCurrentHealth) return;
    ULONGLONG now = GetTickCount64();
    if (now - g_LastServerCrashTime < 250) return;
    g_LastServerCrashTime = now;

    __try {
        void* hComp = g_LocalPlayerInfo.healthComp;
        if (hComp && IsValidUnityObj(hComp)) {
            int val = 0x7FFFFFFF;
            void* args[1] = { &val };
            void* exc = nullptr;
            g_Il2Cpp.il2cpp_runtime_invoke(g_CMDChangeCurrentHealth, hComp, args, &exc);
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {}
}

// ─── Client/Player Crash: Send physics impulse to displace target ────────────
static void DoCrashTargetPlayer(void* targetPlayer) {
    if (!targetPlayer || !IsValidUnityObj(targetPlayer)) return;

    __try {
        void* rootRb = *(void**)((char*)targetPlayer + 0x108);
        if (rootRb && IsValidUnityObj(rootRb)) {
            Vector3 crashVel(0.0f, -99999.0f, 0.0f);
            g_Il2Cpp.SetRigidbodyLinearVelocity(rootRb, crashVel);
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {}
}

// ─── Crash All Players (except self) ─────────────────────────────────────────
static void DoCrashAllPlayers() {
    __try {
        int crashCount = 0;
        for (const auto& pl : g_CachedPlayers) {
            if (pl.isEnemy && IsValidUnityObj(pl.playerObj)) {
                DoCrashTargetPlayer(pl.playerObj);
                crashCount++;
            }
        }
        CheatLog("[CRASH] Crash-all triggered: %d players affected", crashCount);
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {}
}

// ─── Map Destruction ─────────────────────────────────────────────────────────
bool  bMapDestructionActive = false;
static ULONGLONG g_LastMapDestroyTime = 0;

static void DoMapDestruction() {
    if (!bMapDestructionActive) return;
    ULONGLONG now = GetTickCount64();
    if (now - g_LastMapDestroyTime < 500) return;
    g_LastMapDestroyTime = now;

    __try {
        for (const auto& pl : g_CachedPlayers) {
            if (pl.isEnemy && pl.rootRb && IsValidUnityObj(pl.rootRb)) {
                g_Il2Cpp.SetRigidbodyLinearVelocity(pl.rootRb, Vector3(0.0f, -9999.0f, 0.0f));
            }
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {}
}

bool bServerCrashActive  = false;
bool bCrashAllPlayersNow = false;

static void ApplyWeaponStatMods() {
    if (!g_HasLocalPlayer || !g_LocalPlayerInfo.weaponManager) return;
    if (!bInfiniteAmmo && !bRapidFire && !bOneHitKillDamage && !bInfiniteRange) return;

    __try {
        void* wm = g_LocalPlayerInfo.weaponManager;
        if (!wm || !IsValidUnityObj(wm)) return;

        void* activeWeapon = *(void**)((char*)wm + 0x120);
        if (activeWeapon && IsValidUnityObj(activeWeapon)) {
            *(bool*)((char*)activeWeapon + 0x120) = true; // canShoot

            if (bInfiniteAmmo) {
                *(int*)((char*)activeWeapon + 0x114) = 99999; // currentAmmo
            }
            if (bRapidFire) {
                *(float*)((char*)activeWeapon + 0x110) = 0.0f; // nextTimeToFire
            }

            void* wData = *(void**)((char*)activeWeapon + 0x100);
            if (wData && IsValidMemPtr(wData, 0x40)) {
                if (bOneHitKillDamage) {
                    *(int*)((char*)wData + 0x18) = 99999; // minimumDamage
                    *(int*)((char*)wData + 0x1C) = 99999; // maximumDamage
                    *(int*)((char*)wData + 0x30) = 99999; // maximumAttacks
                }
                if (bInfiniteRange) {
                    *(float*)((char*)wData + 0x20) = 9999.0f; // range
                }
            }
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {}
}

// ─── Mass Kill Aura (Instantly Annihilate All Enemies Anywhere Without Moving) ───
static ULONGLONG g_LastMassKillTime = 0;

static void DoMassKill() {
    if (!bEnableMassKill || !g_HasLocalPlayer) return;

    __try {
        ULONGLONG now = GetTickCount64();
        if (now - g_LastMassKillTime < (ULONGLONG)fMassKillInterval) return;
        g_LastMassKillTime = now;

        if (!g_LocalPlayerInfo.weaponManager || !IsValidUnityObj(g_LocalPlayerInfo.weaponManager)) return;
        void* activeWeapon = *(void**)((char*)g_LocalPlayerInfo.weaponManager + 0x120);
        if (!activeWeapon || !IsValidUnityObj(activeWeapon)) return;

        // Apply max damage stats to weapon
        *(bool*)((char*)activeWeapon + 0x120) = true;
        *(int*)((char*)activeWeapon + 0x114)  = 99999;
        *(float*)((char*)activeWeapon + 0x110) = 0.0f;

        void* wData = *(void**)((char*)activeWeapon + 0x100);
        if (wData && IsValidMemPtr(wData, 0x40)) {
            *(int*)((char*)wData + 0x18)   = 99999;
            *(int*)((char*)wData + 0x1C)   = 99999;
            *(float*)((char*)wData + 0x20) = 9999.0f;
            *(float*)((char*)wData + 0x24) = 0.001f;
            *(int*)((char*)wData + 0x30)   = 99999;
        }

        Vector3 localCamPos{};
        void* activeCam = GetCurrentGameCamera();
        if (activeCam && IsValidUnityObj(activeCam)) {
            void* camTr = g_Il2Cpp.GetComponentTransform(activeCam);
            if (camTr && IsValidUnityObj(camTr)) g_Il2Cpp.GetTransformPosition(camTr, &localCamPos);
        }

        int killedCount = 0;
        for (const auto& pl : g_CachedPlayers) {
            if (!pl.isEnemy || pl.isDead || pl.hp <= 0 || !IsValidUnityObj(pl.playerObj)) continue;

            void* targetRb = pl.chestRb ? pl.chestRb : pl.rootRb;
            if (!targetRb || !IsValidUnityObj(targetRb)) continue;

            Vector3 targetHeadPos{};
            if (!g_Il2Cpp.GetRigidbodyPosition(targetRb, &targetHeadPos)) continue;
            targetHeadPos = targetHeadPos + Vector3(0.0f, 0.40f, 0.0f);

            // Server-side weapon shoot hit registration
            if (g_PackDirectionMethod && g_PackVector3Method && g_CMDShoot) {
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

                if (packedPos && packedFwd && !exc1 && !exc2) {
                    uint32_t tick = 0;
                    void* shootArgs[3] = { packedPos, packedFwd, &tick };
                    void* exc3 = nullptr;
                    g_Il2Cpp.il2cpp_runtime_invoke(g_CMDShoot, activeWeapon, shootArgs, &exc3);
                }
            }

            if (g_ClientTryShoot) {
                void* excShoot = nullptr;
                g_Il2Cpp.il2cpp_runtime_invoke(g_ClientTryShoot, activeWeapon, nullptr, &excShoot);
            }

            killedCount++;
        }

        if (killedCount > 0) {
            CheatLog("Mass Kill Aura: hit %d target(s)", killedCount);
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {}
}

// ─── Fast Loading & Joining Optimizer (Skip Countdowns & Transitions) ────────
static ULONGLONG g_LastFastLoadTime = 0;

static void DoFastLoading() {
    if (!bFastLoadingOptimizer || !g_HasLocalPlayer) return;
    ULONGLONG now = GetTickCount64();
    if (now - g_LastFastLoadTime < 250) return;
    g_LastFastLoadTime = now;

    __try {
        // Bypass & disable pre-match countdown timer instantly during game spawn
        if (g_GameCountdownClass && g_DisableCountdownMethod) {
            Il2CppArray* cdArr = g_Il2Cpp.FindObjectsOfType(g_GameCountdownClass);
            if (cdArr && IsValidMemPtr(cdArr, 0x28)) {
                uintptr_t cnt = *(uintptr_t*)((char*)cdArr + 0x18);
                if (cnt > 0 && cnt <= 8) {
                    void** items = (void**)((char*)cdArr + 0x20);
                    for (uintptr_t i = 0; i < cnt; i++) {
                        void* cdObj = items[i];
                        if (cdObj && IsValidUnityObj(cdObj)) {
                            *(int*)((char*)cdObj + 0xF8) = 0; // duration
                            void* exc = nullptr;
                            g_Il2Cpp.il2cpp_runtime_invoke(g_DisableCountdownMethod, cdObj, nullptr, &exc);
                        }
                    }
                }
            }
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {}
}

// ─── Instant Match Terminator / End-Game Exploit ──────────────────────────────
static void DoEndGameExploit() {
    __try {
        CheatLog("[EXPLOIT] Force End-Game Exploit Triggered!");

        // 1. Wipe all remote enemy players via server-side damage
        DoMassKill();

        // 2. Signal PlayerEndGame DestroyPlayer on local player if available
        if (g_PlayerEndGameClass && g_DestroyPlayerMethod) {
            Il2CppArray* pegArr = g_Il2Cpp.FindObjectsOfType(g_PlayerEndGameClass);
            if (pegArr && IsValidMemPtr(pegArr, 0x28)) {
                uintptr_t cnt = *(uintptr_t*)((char*)pegArr + 0x18);
                if (cnt > 0 && cnt <= 16) {
                    void** items = (void**)((char*)pegArr + 0x20);
                    for (uintptr_t i = 0; i < cnt; i++) {
                        void* pegObj = items[i];
                        if (pegObj && IsValidUnityObj(pegObj) && g_Il2Cpp.IsLocalPlayer(pegObj)) {
                            int itemID = 0;
                            void* args[1] = { &itemID };
                            void* exc = nullptr;
                            g_Il2Cpp.il2cpp_runtime_invoke(g_DestroyPlayerMethod, pegObj, args, &exc);
                            CheatLog("[+] Local PlayerEndGame::DestroyPlayer invoked.");
                            break;
                        }
                    }
                }
            }
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {}
}

// ─── Powerful Movement, Grapple & Camera Exploits ────────────────────────────
// All offsets verified from Assembly-CSharp_Decompiled.cs dump
static void DoExploits() {
    if (!g_HasLocalPlayer || !g_LocalPlayerInfo.playerMovement) return;

    __try {
        void* pm = g_LocalPlayerInfo.playerMovement;
        if (!pm || !IsValidUnityObj(pm)) return;

        // 1. Speed (PlayerMovement fields from dump)
        // maxGroundSpeed=0x108, groundAcceleration=0x10C, maxGroundAccelForce=0x110
        // maxAirSpeed=0x114, airAcceleration=0x118
        if (bEnableSpeedhack) {
            *(float*)((char*)pm + 0x108) = 10.0f * fSpeedMultiplier;   // maxGroundSpeed
            *(float*)((char*)pm + 0x10C) = 80.0f * fSpeedMultiplier;   // groundAcceleration
            *(float*)((char*)pm + 0x110) = 60.0f * fSpeedMultiplier;   // maxGroundAccelForce
            *(float*)((char*)pm + 0x114) = 10.0f * fSpeedMultiplier;   // maxAirSpeed
            *(float*)((char*)pm + 0x118) = 40.0f * fSpeedMultiplier;   // airAcceleration
        }

        // 2. Super Jump: jumpForce=0x13C (single float, NOT forceScale Vector3 at 0x130)
        if (bEnableSuperJump) {
            *(float*)((char*)pm + 0x13C) = 8.0f * fJumpMultiplier;    // jumpForce
        }

        // 3. Reduced gravity: gravityForce=0x1A8 (NOT groundDrag at 0x140)
        if (bZeroGravity) {
            *(float*)((char*)pm + 0x1A8) = (9.81f * fGravityMultiplier); // gravityForce
        }

        // 4. Grapple Exploits - _LGrapple=0x210, _RGrapple=0x218
        void* lgrapple = *(void**)((char*)pm + 0x210);
        void* rgrapple = *(void**)((char*)pm + 0x218);
        void* hooks[2] = { lgrapple, rgrapple };
        for (void* hook : hooks) {
            if (!hook || !IsValidUnityObj(hook)) continue;
            // maxDistance=0x120, oneHookRetractForce=0x150, twoHookRetractForce=0x154
            if (bInfiniteGrappleRange) {
                *(float*)((char*)hook + 0x120) = 9999.0f;              // maxDistance
            }
            if (bSuperGrappleSpeed) {
                *(int*)((char*)hook + 0x150) = (int)(150.0f * fGrappleSpeedMult); // oneHookRetractForce
                *(int*)((char*)hook + 0x154) = (int)(250.0f * fGrappleSpeedMult); // twoHookRetractForce
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
        ImGui_ImplDX11_NewFrame();
        ImGui_ImplWin32_NewFrame();
        ImGui::NewFrame();

        ImGuiIO& io = ImGui::GetIO();

        // Run entity scan & game logic hooks safely on render thread
        ScanGameEntities();
        UpdateFrameESPData();
        DoGodMode();
        ApplyWeaponStatMods();
        DoExploits();
        DoMassKill();
        DoFastLoading();

        if (bEndGameMatchTrigger) {
            DoEndGameExploit();
            bEndGameMatchTrigger = false;
        }

        // Server & Player Crash Exploits
        if (bServerCrashActive) DoServerCrash();
        DoMapDestruction();

        // One-shot crash: triggered by button, reset after single pass
        if (bCrashAllPlayersNow) {
            DoCrashAllPlayers();
            bCrashAllPlayersNow = false;
        }

        // ── ESP Overlay ──
        if (bEnableESP) DrawESP(io);

        // ── Aimbot ──
        if (bEnableAimbot) DoAimbot(io);

        // ── Teleportation & Auto-Shoot Kill Aura ──
        if (bEnableTeleportKill) DoTeleportKill(io);

        // ── Cursor Synchronization (Eliminates ghost/duplicate cursor on menu close) ──
        io.MouseDrawCursor = g_ShowMenu;

        // ── Material UI 3 Menu ──
        if (g_ShowMenu) {
            EnsureCursorUnlocked(true);

            // Direct hardware mouse position & button sync — bypasses Unity's cursor lock
            POINT pt;
            if (GetCursorPos(&pt) && ScreenToClient(g_hWnd, &pt)) {
                io.AddMousePosEvent((float)pt.x, (float)pt.y);
            }
            io.AddMouseButtonEvent(0, (GetAsyncKeyState(VK_LBUTTON) & 0x8000) != 0);
            io.AddMouseButtonEvent(1, (GetAsyncKeyState(VK_RBUTTON) & 0x8000) != 0);

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

                        ImGui::Spacing();
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::PushStyleColor(ImGuiCol_Text, ImVec4(0.35f, 0.85f, 1.0f, 1.0f));
                        ImGui::Text("[*] LOADING & MATCH CONTROLS");
                        ImGui::PopStyleColor();
                        ImGui::Checkbox("Fast Loading & Auto-Join Optimizer", &bFastLoadingOptimizer);
                        ImGui::TextDisabled("Instantly skips pre-game countdowns & loading blocks.");

                        ImGui::Spacing();
                        ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.60f, 0.25f, 0.10f, 0.90f));
                        ImGui::PushStyleColor(ImGuiCol_ButtonHovered, ImVec4(0.85f, 0.35f, 0.15f, 1.0f));
                        ImGui::PushStyleColor(ImGuiCol_ButtonActive, ImVec4(0.50f, 0.20f, 0.08f, 1.0f));
                        if (ImGui::Button("FORCE END GAME & VICTORY EXPLOIT", ImVec2(-1, 38))) {
                            bEndGameMatchTrigger = true;
                        }
                        ImGui::PopStyleColor(3);
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
                // TAB 5: LIVE LOG CAPTURER & ENGINE DIAGNOSTICS & LOBBY CONTROL
                // ═════════════════════════════════════════════════════════════
                else if (iTopNavTab == 5) {
                    float halfWidth = (ImGui::GetContentRegionAvail().x - 12.0f) * 0.5f;

                    // ── CARD 1: Live Game Engine & Unity Debug Log Viewer ──
                    ImGui::BeginChild("CardGameLogs", ImVec2(halfWidth, 0), true);
                    {
                        ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Live Game & Cheat Tracing Console");
                        ImGui::Separator();
                        ImGui::Spacing();

                        static int s_LogCategoryFilter = 0; // 0: ALL, 1: CHEAT, 2: GAME, 3: LOBBY, 4: ERRORS
                        const char* filterLabels[] = { "All Logs", "Cheat", "Game/Unity", "Lobby/Net", "Errors Only" };
                        
                        ImGui::Text("Filter:");
                        ImGui::SameLine();
                        for (int f = 0; f < 5; f++) {
                            if (f > 0) ImGui::SameLine();
                            bool sel = (s_LogCategoryFilter == f);
                            if (sel) ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.20f, 0.40f, 0.70f, 1.0f));
                            if (ImGui::Button(filterLabels[f])) {
                                s_LogCategoryFilter = f;
                            }
                            if (sel) ImGui::PopStyleColor();
                        }

                        ImGui::Spacing();
                        {
                            std::lock_guard<std::mutex> lock(g_GameLogMutex);
                            ImGui::Text("Total Recorded Traces: %d", (int)g_GameLogs.size());
                        }

                        ImGui::SameLine(ImGui::GetWindowWidth() - 140.0f);
                        if (ImGui::Button("Clear Console", ImVec2(120, 24))) {
                            std::lock_guard<std::mutex> lock(g_GameLogMutex);
                            g_GameLogs.clear();
                        }

                        ImGui::Spacing();

                        // Scrollable log terminal window
                        ImGui::BeginChild("LogTerminal", ImVec2(0, 0), true, ImGuiWindowFlags_HorizontalScrollbar);
                        {
                            std::lock_guard<std::mutex> lock(g_GameLogMutex);
                            if (g_GameLogs.empty()) {
                                ImGui::TextDisabled("Waiting for cheat events, lobby joins, game logs or exceptions...");
                            } else {
                                for (const auto& entry : g_GameLogs) {
                                    if (s_LogCategoryFilter == 1 && entry.message.find("[CHEAT]") == std::string::npos) continue;
                                    if (s_LogCategoryFilter == 2 && entry.message.find("[GAME]") == std::string::npos) continue;
                                    if (s_LogCategoryFilter == 3 && (entry.message.find("[LOBBY]") == std::string::npos && entry.message.find("[NETWORK]") == std::string::npos)) continue;
                                    if (s_LogCategoryFilter == 4 && entry.type != 0 && entry.type != 4) continue;

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
                                    } else if (entry.type == 5) { // Lobby / Net
                                        col = ImVec4(0.35f, 0.85f, 1.00f, 1.0f);
                                        tag = "[NET/LOBBY]";
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

                    // ── CARD 2: Engine Telemetry, Lobby Controller & Profiles ──
                    ImGui::BeginChild("CardDiagnostics", ImVec2(halfWidth, 0), true);
                    {
                        ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Lobby Controls & Telemetry");
                        ImGui::Separator();
                        ImGui::Spacing();

                        uint64_t curLobby = g_Il2Cpp.GetCurrentLobbyID();
                        ImGui::Text("Active Steam Lobby: ");
                        ImGui::SameLine();
                        if (curLobby != 0) {
                            ImGui::TextColored(ImVec4(0.30f, 0.85f, 0.50f, 1.0f), "0x%llX (IN LOBBY)", (unsigned long long)curLobby);
                        } else {
                            ImGui::TextColored(ImVec4(0.7f, 0.7f, 0.7f, 1.0f), "None (Main Menu / Searching)");
                        }

                        ImGui::Spacing();
                        if (ImGui::Button("Host Public Lobby", ImVec2(170, 32))) {
                            TraceLog("LOBBY", "Requesting Host Public Lobby...");
                            g_Il2Cpp.HostLobby(false);
                        }
                        ImGui::SameLine();
                        if (ImGui::Button("Host Private Lobby", ImVec2(170, 32))) {
                            TraceLog("LOBBY", "Requesting Host Private Lobby...");
                            g_Il2Cpp.HostLobby(true);
                        }
                        
                        if (curLobby != 0) {
                            ImGui::SameLine();
                            if (ImGui::Button("Leave Lobby", ImVec2(130, 32))) {
                                TraceLog("LOBBY", "Requesting Leave Lobby...");
                                g_Il2Cpp.LeaveLobby();
                            }
                        }

                        ImGui::Spacing();
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

                        if (ImGui::Button("SAVE CONFIG TO DISK", ImVec2(-1, 36))) SaveConfig();
                        ImGui::Spacing();
                        if (ImGui::Button("LOAD CONFIG FROM DISK", ImVec2(-1, 36))) LoadConfig();
                        ImGui::Spacing();
                        if (ImGui::Button("LOAD HVH RAGE PRESET", ImVec2(-1, 36))) LoadHvHConfig();
                        ImGui::Spacing();
                        if (ImGui::Button("RESET TO DEFAULTS", ImVec2(-1, 32))) ResetConfigToDefaults();

                        ImGui::Spacing();
                        ImGui::Separator();
                        ImGui::Spacing();

                        ImGui::TextColored(ImVec4(0.35f, 0.65f, 1.00f, 1.0f), "Diagnostic Log Files:");
                        ImGui::BulletText("Game Engine Log : XUYBYA_GameEngine.log");
                        ImGui::BulletText("Cheat Engine Log: XUYBYA_Cheat.log");
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

            // Fast Loading & Joining Classes & Methods
            g_GameCountdownClass     = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "GameCountdown");
            g_LevelLoaderClass       = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "LevelLoader");
            g_PlayerEndGameClass     = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "PlayerEndGame");

            if (g_GameCountdownClass) {
                g_DisableCountdownMethod = g_Il2Cpp.FindMethod(g_GameCountdownClass, "DisableCountdown", 0);
                CheatLog("[+] GameCountdown resolved: Class=%p, DisableCountdown=%p", g_GameCountdownClass, g_DisableCountdownMethod);
            }
            if (g_PlayerEndGameClass) {
                g_DestroyPlayerMethod    = g_Il2Cpp.FindMethod(g_PlayerEndGameClass, "DestroyPlayer", 1);
                CheatLog("[+] PlayerEndGame resolved: Class=%p, DestroyPlayer=%p", g_PlayerEndGameClass, g_DestroyPlayerMethod);
            }

            g_HealthGracePeriodClass = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "HealthGracePeriod");
            if (g_HealthGracePeriodClass) {
                CheatLog("[+] HealthGracePeriod resolved: Class=%p", g_HealthGracePeriodClass);
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
        if (cmdShootTarget) {
            MH_CreateHook(cmdShootTarget, (LPVOID)&hkCMDShoot, (void**)&oCMDShoot);
            CheatLog("[+] Weapon::CMDShoot hooked at 0x%p", cmdShootTarget);
        }

        // Hook Unity DebugLogHandler to capture all engine events and exceptions
        Il2CppImage* coreMod = g_Il2Cpp.GetImage("UnityEngine.CoreModule");
        if (coreMod) {
            Il2CppClass* dlhClass = g_Il2Cpp.il2cpp_class_from_name(coreMod, "UnityEngine", "DebugLogHandler");
            if (dlhClass) {
                MethodInfo* mLog = g_Il2Cpp.FindMethod(dlhClass, "Internal_Log", 4);
                MethodInfo* mExc = g_Il2Cpp.FindMethod(dlhClass, "Internal_LogException", 2);
                if (mLog && *(void**)mLog) {
                    MH_CreateHook(*(void**)mLog, (LPVOID)&hkInternal_Log, (void**)&oInternal_Log);
                    TraceLog("UNITY", "[+] Unity DebugLogHandler::Internal_Log hooked at 0x%p", *(void**)mLog);
                }
                if (mExc && *(void**)mExc) {
                    MH_CreateHook(*(void**)mExc, (LPVOID)&hkInternal_LogException, (void**)&oInternal_LogException);
                    TraceLog("UNITY", "[+] Unity DebugLogHandler::Internal_LogException hooked at 0x%p", *(void**)mExc);
                }
            }
        }

        // Hook BootstrapManager Lobby Callbacks
        if (g_Il2Cpp.classBootstrapManager) {
            MethodInfo* mOnEnter = g_Il2Cpp.FindMethod(g_Il2Cpp.classBootstrapManager, "OnLobbyEntered", 1);
            MethodInfo* mOnCreate = g_Il2Cpp.FindMethod(g_Il2Cpp.classBootstrapManager, "OnLobbyCreated", 1);
            MethodInfo* mOnKick = g_Il2Cpp.FindMethod(g_Il2Cpp.classBootstrapManager, "OnLobbyKicked", 1);
            if (mOnEnter && *(void**)mOnEnter) {
                MH_CreateHook(*(void**)mOnEnter, (LPVOID)&hkOnLobbyEntered, (void**)&oOnLobbyEntered);
                TraceLog("LOBBY", "[+] BootstrapManager::OnLobbyEntered hooked at 0x%p", *(void**)mOnEnter);
            }
            if (mOnCreate && *(void**)mOnCreate) {
                MH_CreateHook(*(void**)mOnCreate, (LPVOID)&hkOnLobbyCreated, (void**)&oOnLobbyCreated);
                TraceLog("LOBBY", "[+] BootstrapManager::OnLobbyCreated hooked at 0x%p", *(void**)mOnCreate);
            }
            if (mOnKick && *(void**)mOnKick) {
                MH_CreateHook(*(void**)mOnKick, (LPVOID)&hkOnLobbyKicked, (void**)&oOnLobbyKicked);
                TraceLog("LOBBY", "[+] BootstrapManager::OnLobbyKicked hooked at 0x%p", *(void**)mOnKick);
            }
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
