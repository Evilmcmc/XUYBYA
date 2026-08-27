#pragma once
#include <windows.h>
#include <d3d11.h>
#include <vector>
#include <string>
#include <mutex>
#include <cmath>
#include <cstring>
#include <algorithm>
#include <fstream>
#include <sstream>

#include "imgui.h"
#include "MinHook.h"
#include "Il2Cpp.h"

// ─── Module Globals ─────────────────────────────────────────────────────────
extern Il2CppResolver g_Il2Cpp;
extern HMODULE g_hDllModule;
extern HWND g_hWnd;
extern ID3D11Device* g_pd3dDevice;
extern ID3D11DeviceContext* g_pd3dDeviceContext;
extern ID3D11RenderTargetView* g_mainRenderTargetView;
extern volatile bool g_IsInitialized;
extern volatile bool g_Uninjecting;
extern bool g_ShowMenu;

// ─── Math Structures ────────────────────────────────────────────────────────
struct BonePoint {
    Vector3 world{};
    Vector3 screen{};
    bool    valid = false;
};

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

struct CachedPlayerInfo {
    void* playerObj     = nullptr;
    bool  isLocal       = false;
    bool  isEnemy       = true;
    bool  awayTeam      = false;
    bool  isDead        = false;
    int   hp            = 100;
    int   maxHp         = 100;

    void* rootRb        = nullptr;
    void* spineRb       = nullptr;
    void* chestRb       = nullptr;
    void* lShoulderRb   = nullptr;
    void* rShoulderRb   = nullptr;
    void* lUpperArmRb   = nullptr;
    void* rUpperArmRb   = nullptr;
    void* lElbowRb      = nullptr;
    void* rElbowRb      = nullptr;
    void* lHandRb       = nullptr;
    void* rHandRb       = nullptr;
    void* lKneeRb       = nullptr;
    void* rKneeRb       = nullptr;
    void* lFootRb       = nullptr;
    void* rFootRb       = nullptr;

    void* healthComp    = nullptr;
    void* graceComp     = nullptr;
    void* playerMovement= nullptr;
    void* weaponManager = nullptr;
    void* inputManager  = nullptr;
};

// ─── Shared Thread-Safe States ──────────────────────────────────────────────
extern std::vector<CachedPlayerInfo> g_CachedPlayers;
extern CachedPlayerInfo              g_LocalPlayerInfo;
extern bool                          g_HasLocalPlayer;
extern std::vector<PlayerESPData>    g_ESPData;

// ─── Settings Globals ───────────────────────────────────────────────────────
// Visuals / ESP
extern bool  bEnableESP;
extern bool  bEnableGlow;
extern float fGlowIntensity;
extern bool  bDrawBoxes;
extern float fBoxThickness;
extern bool  bDrawSkeleton;
extern float fSkeletonThickness;
extern bool  bDrawHeadCircle;
extern float fHeadCircleSize;
extern bool  bDrawTracers;
extern int   iTracerOrigin;
extern float fTracerThickness;
extern bool  bDrawHealthBar;
extern bool  bDrawInfoText;
extern bool  bIgnoreTeammates;
extern bool  bIgnoreLocal;
extern bool  bIgnoreDead;
extern float fMaxDistance;

// Colors
extern float colEnemy[4];
extern float colTeam[4];
extern float colSkeleton[4];
extern float colTracers[4];
extern float colHeadCircle[4];

// Chams
extern bool  bEnableChams;
extern int   iChamsStyle;
extern float fChamsAlpha;
extern float fChamsJointSize;
extern bool  bChamsVisibleOnly;
extern float colChamsEnemyVis[4];
extern float colChamsEnemyOcc[4];
extern float colChamsTeamVis[4];
extern float colChamsTeamOcc[4];

// Silent Aim
extern bool  bEnableSilentAim;
extern int   iSilentAimTarget;
extern float fSilentAimFOV;
extern bool  bDrawSilentAimFOV;
extern bool  bSilentAimFull360;

// Aimbot
extern bool  bEnableAimbot;
extern int   iAimbotKey;
extern bool  bDrawAimbotFOV;
extern int   iAimbotTarget;
extern float aimbotFOV;
extern float aimbotSmooth;
extern float aimbotMaxSpeed;
extern bool  bAimbotAutoFire;
extern bool  bAimbotWhileFlashed;
extern bool  bAimbotThroughSmoke;
extern float fKillDelay;
extern float fMouseLockX;
extern float fMouseLockY;

// RCS & Triggerbot
extern bool  bRecoilCompensation;
extern int   iRecoilStartBullet;
extern float fRecoilX;
extern float fRecoilY;
extern float fRecoilSmooth;
extern bool  bTriggerbot;
extern bool  bTriggerbotHeadOnly;
extern float fTriggerbotDelay;

// Teleport & MassKill
extern bool  bEnableTeleportKill;
extern bool  bTeleportHoldKey;
extern int   iTeleportKey;
extern int   iTeleportPosition;
extern int   iTeleportTargetMode;
extern float fTeleportDistance;
extern float fTeleportHeight;
extern bool  bTeleportAutoShoot;
extern bool  bTeleportLookAt;
extern float fTeleportShootRate;

extern bool  bEnableMassKill;
extern float fMassKillInterval;
extern int   iMassKillMode;

// Weapons
extern int   iSelectedWeaponIndex;
extern bool  bInfiniteAmmo;
extern bool  bOneHitKillDamage;
extern bool  bRapidFire;
extern bool  bInfiniteRange;
extern bool  bWeaponSpawnBypass;

// Movement & Exploits
extern bool  bEnableSpeedhack;
extern float fSpeedMultiplier;
extern bool  bEnableSuperJump;
extern float fJumpMultiplier;
extern bool  bInfiniteAirJump;
extern bool  bZeroGravity;
extern float fGravityMultiplier;
extern bool  bBunnyhop;
extern bool  bNoClip;
extern float fNoClipSpeed;
extern bool  bAntiKnockback;

extern bool  bInfiniteGrappleRange;
extern bool  bSuperGrappleSpeed;
extern float fGrappleSpeedMult;
extern bool  bInstantGrappleBoost;
extern bool  bGrappleMagnetAim;

// Visuals Tweaks & Performance
extern bool  bCustomFOV;
extern float fCustomFOVValue;
extern bool  bFastLoadingOptimizer;
extern bool  bFpsBoostUltra;
extern bool  bDisableGameShadows;
extern bool  bDisableFogAndBlur;

// Match & Destruction Exploits
extern bool  bGodMode;
extern bool  bEndGameMatchTrigger;
extern bool  bServerCrashActive;
extern bool  bCrashAllPlayersNow;
extern bool  bMapDestroyerActive;

// UI & Nav
extern int   iTopNavTab;
extern int   iSidebarCategory;
extern char  szSearchQuery[64];

// Keybind Checker
extern const char* const g_KeyNames[12];
extern const int g_KeyNamesCount;
bool IsKeyActive(int keyIndex);

// Logging
void TraceLog(const char* category, const char* fmt, ...);
void CheatLog(const char* fmt, ...);
