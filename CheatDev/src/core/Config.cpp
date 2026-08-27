#include "core/Config.h"

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

const char* Config::GetStatus() {
    if (g_ConfigStatus[0] != '\0' && (GetTickCount64() - g_ConfigStatusTime < 6000)) {
        return g_ConfigStatus;
    }
    return "";
}

void Config::Save() {
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
    f << "bNoClip=" << bNoClip << "\n";
    f << "fNoClipSpeed=" << fNoClipSpeed << "\n";
    f << "bAntiKnockback=" << bAntiKnockback << "\n";
    f << "bInfiniteGrappleRange=" << bInfiniteGrappleRange << "\n";
    f << "bSuperGrappleSpeed=" << bSuperGrappleSpeed << "\n";
    f << "fGrappleSpeedMult=" << fGrappleSpeedMult << "\n";
    f << "bInstantGrappleBoost=" << bInstantGrappleBoost << "\n";
    f << "bGrappleMagnetAim=" << bGrappleMagnetAim << "\n";
    f << "bCustomFOV=" << bCustomFOV << "\n";
    f << "fCustomFOVValue=" << fCustomFOVValue << "\n";
    f << "bFastLoadingOptimizer=" << bFastLoadingOptimizer << "\n";
    f << "bFpsBoostUltra=" << bFpsBoostUltra << "\n";

    f << "\n[Misc]\n";
    f << "bGodMode=" << bGodMode << "\n";

    f.close();
    SetConfigStatus("Config saved successfully to XUYBYA_Config.ini");
}

void Config::Load() {
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
            else if (key == "bNoClip") bNoClip = ParseBool(val);
            else if (key == "fNoClipSpeed") fNoClipSpeed = ParseFloat(val);
            else if (key == "bAntiKnockback") bAntiKnockback = ParseBool(val);
            else if (key == "bInfiniteGrappleRange") bInfiniteGrappleRange = ParseBool(val);
            else if (key == "bSuperGrappleSpeed") bSuperGrappleSpeed = ParseBool(val);
            else if (key == "fGrappleSpeedMult") fGrappleSpeedMult = ParseFloat(val);
            else if (key == "bInstantGrappleBoost") bInstantGrappleBoost = ParseBool(val);
            else if (key == "bGrappleMagnetAim") bGrappleMagnetAim = ParseBool(val);
            else if (key == "bCustomFOV") bCustomFOV = ParseBool(val);
            else if (key == "fCustomFOVValue") fCustomFOVValue = ParseFloat(val);
            else if (key == "bFastLoadingOptimizer") bFastLoadingOptimizer = ParseBool(val);
            else if (key == "bFpsBoostUltra") bFpsBoostUltra = ParseBool(val);
            else if (key == "bGodMode") bGodMode = ParseBool(val);
        } catch (...) {}
    }
    f.close();
    SetConfigStatus("Config loaded successfully from XUYBYA_Config.ini");
}

void Config::LoadHvHPreset() {
    bEnableESP            = true;
    bEnableGlow           = true;
    fGlowIntensity        = 1.4f;
    bDrawBoxes            = true;
    bDrawSkeleton         = true;
    bDrawHeadCircle       = true;
    bDrawTracers          = true;
    bDrawHealthBar        = true;
    bDrawInfoText         = true;
    bEnableChams          = true;
    iChamsStyle           = 3; // Neon Pulse
    fChamsAlpha           = 0.85f;

    bEnableSilentAim      = true;
    iSilentAimTarget      = 1;
    bSilentAimFull360     = true;
    fSilentAimFOV         = 360.0f;
    bDrawSilentAimFOV     = false;

    bEnableAimbot         = true;
    bAimbotAutoFire       = true;
    aimbotSmooth          = 1.0f; // Instant snap
    aimbotFOV             = 360.0f;

    bEnableMassKill       = true;
    fMassKillInterval     = 60.0f;

    bGodMode              = true;
    bInfiniteAmmo         = true;
    bOneHitKillDamage     = true;
    bRapidFire            = true;
    bInfiniteRange        = true;

    bEnableSpeedhack      = true;
    fSpeedMultiplier      = 3.2f;
    bEnableSuperJump      = true;
    fJumpMultiplier       = 2.2f;
    bAntiKnockback        = true;
    bInfiniteGrappleRange = true;
    bSuperGrappleSpeed    = true;
    fGrappleSpeedMult     = 3.0f;

    bFpsBoostUltra        = true;

    SetConfigStatus("HvH Rage Preset Loaded! 100% Annihilation Active!");
}

void Config::ResetDefaults() {
    bEnableESP            = false;
    bEnableGlow           = false;
    fGlowIntensity        = 1.0f;
    bDrawBoxes            = false;
    bDrawSkeleton         = false;
    bDrawHeadCircle       = false;
    bDrawTracers          = false;
    bDrawHealthBar        = false;
    bDrawInfoText         = false;
    bEnableChams          = false;
    bEnableSilentAim      = false;
    bEnableAimbot         = false;
    bEnableTeleportKill   = false;
    bEnableMassKill       = false;
    bGodMode              = false;
    bInfiniteAmmo         = true;
    bOneHitKillDamage     = true;
    bRapidFire            = true;
    bInfiniteRange        = true;
    bEnableSpeedhack      = false;
    bEnableSuperJump      = false;
    bZeroGravity          = false;
    bNoClip               = false;
    bAntiKnockback        = false;
    bInfiniteGrappleRange = false;
    bSuperGrappleSpeed    = false;
    bFpsBoostUltra        = true;

    SetConfigStatus("Reset all settings to defaults.");
}
