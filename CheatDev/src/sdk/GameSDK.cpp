#include "sdk/GameSDK.h"

// IL2CPP Classes
Il2CppClass* SDK::PlayerClass              = nullptr;
Il2CppClass* SDK::PlayerMovementClass      = nullptr;
Il2CppClass* SDK::HealthClass              = nullptr;
Il2CppClass* SDK::SharedRefClass           = nullptr;
Il2CppClass* SDK::RagdollCamClass          = nullptr;
Il2CppClass* SDK::WeaponClass              = nullptr;
Il2CppClass* SDK::WeaponManagerClass       = nullptr;
Il2CppClass* SDK::DataPackerClass          = nullptr;
Il2CppClass* SDK::GameCountdownClass       = nullptr;
Il2CppClass* SDK::LevelLoaderClass         = nullptr;
Il2CppClass* SDK::PlayerEndGameClass       = nullptr;
Il2CppClass* SDK::HealthGracePeriodClass   = nullptr;
Il2CppClass* SDK::BarrelClass              = nullptr;
Il2CppClass* SDK::QualitySettingsClass     = nullptr;

// IL2CPP Methods
MethodInfo*  SDK::DisableCountdownMethod   = nullptr;
MethodInfo*  SDK::DestroyPlayerMethod      = nullptr;
MethodInfo*  SDK::GetCurrentHealth         = nullptr;
MethodInfo*  SDK::IsDeadMethod             = nullptr;
MethodInfo*  SDK::CMDChangeCurrentHealth   = nullptr;
MethodInfo*  SDK::ClientTryShoot           = nullptr;
MethodInfo*  SDK::CMDShoot                 = nullptr;
MethodInfo*  SDK::PickUpMethod             = nullptr;
MethodInfo*  SDK::StartPickUpMethod        = nullptr;
MethodInfo*  SDK::PackDirectionMethod      = nullptr;
MethodInfo*  SDK::UnpackShortMethod        = nullptr;
MethodInfo*  SDK::PackVector3Method        = nullptr;
MethodInfo*  SDK::UnpackDirectionMethod    = nullptr;
MethodInfo* SDK::StartSharedEffectsMethod      = nullptr;
MethodInfo* SDK::TryUpdateGunGameWeaponMethod   = nullptr;
MethodInfo* SDK::SetQualityLevelMethod          = nullptr;
MethodInfo* SDK::SetVSyncCountMethod            = nullptr;
MethodInfo* SDK::SetTargetFrameRateMethod       = nullptr;

static ULONGLONG g_LastScanTime = 0;
static void*     g_CachedCamera = nullptr;
static ULONGLONG g_LastCameraCheckTime = 0;

bool SDK::Initialize() {
    if (!g_Il2Cpp.Init()) {
        CheatLog("[-] SDK: IL2CPP initialization failed!");
        return false;
    }

    g_Il2Cpp.EnsureThreadAttached();

    Il2CppImage* asmCS = g_Il2Cpp.GetImage("Assembly-CSharp");
    Il2CppImage* coreMod = g_Il2Cpp.GetImage("UnityEngine.CoreModule");

    if (coreMod) {
        QualitySettingsClass = g_Il2Cpp.il2cpp_class_from_name(coreMod, "UnityEngine", "QualitySettings");
        if (QualitySettingsClass) {
            SetQualityLevelMethod    = g_Il2Cpp.FindMethod(QualitySettingsClass, "SetQualityLevel", 2);
            SetVSyncCountMethod      = g_Il2Cpp.FindMethod(QualitySettingsClass, "set_vSyncCount", 1);
            SetTargetFrameRateMethod = g_Il2Cpp.FindMethod(QualitySettingsClass, "set_targetFrameRate", 1);
            CheatLog("[+] QualitySettings resolved: VSync=%p, FPS=%p", SetVSyncCountMethod, SetTargetFrameRateMethod);
        }
    }

    if (asmCS) {
        PlayerClass            = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "Player");
        PlayerMovementClass    = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "PlayerMovement");
        HealthClass            = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "Health");
        SharedRefClass         = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "SharedReferences");
        RagdollCamClass        = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "RagdollCameraController");
        WeaponClass            = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "Weapon");
        WeaponManagerClass     = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "WeaponManager");
        DataPackerClass        = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "DataPacker");
        GameCountdownClass     = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "GameCountdown");
        LevelLoaderClass       = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "LevelLoader");
        PlayerEndGameClass     = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "PlayerEndGame");
        HealthGracePeriodClass = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "HealthGracePeriod");
        BarrelClass            = g_Il2Cpp.il2cpp_class_from_name(asmCS, "", "Barrel");

        if (HealthClass) {
            GetCurrentHealth       = g_Il2Cpp.FindMethod(HealthClass, "GetCurrentHealth", 0);
            IsDeadMethod           = g_Il2Cpp.FindMethod(HealthClass, "IsDead", 0);
            CMDChangeCurrentHealth = g_Il2Cpp.FindMethod(HealthClass, "CMDChangeCurrentHealth", 1);
        }

        if (WeaponClass) {
            ClientTryShoot         = g_Il2Cpp.FindMethod(WeaponClass, "ClientTryShoot", 0);
            CMDShoot               = g_Il2Cpp.FindMethod(WeaponClass, "CMDShoot", 3);
        }

        if (WeaponManagerClass) {
            PickUpMethod           = g_Il2Cpp.FindMethod(WeaponManagerClass, "PickUp", 1);
            StartPickUpMethod      = g_Il2Cpp.FindMethod(WeaponManagerClass, "StartPickUp", 1);
        }

        if (DataPackerClass) {
            PackDirectionMethod    = g_Il2Cpp.FindMethod(DataPackerClass, "PackDirection", 1);
            UnpackShortMethod      = g_Il2Cpp.FindMethod(DataPackerClass, "UnpackShort", 1);
            PackVector3Method      = g_Il2Cpp.FindMethod(DataPackerClass, "PackVector3", 1);
            UnpackDirectionMethod  = g_Il2Cpp.FindMethod(DataPackerClass, "UnpackDirection", 1);
        }

        if (GameCountdownClass) {
            DisableCountdownMethod = g_Il2Cpp.FindMethod(GameCountdownClass, "DisableCountdown", 0);
        }

        if (PlayerEndGameClass) {
            DestroyPlayerMethod    = g_Il2Cpp.FindMethod(PlayerEndGameClass, "DestroyPlayer", 1);
        }

        CheatLog("[+] SDK: All Game Classes & Methods resolved successfully!");
        return true;
    }
    return false;
}

void SDK::ResetCache() {
    g_CachedCamera = nullptr;
    g_HasLocalPlayer = false;
    g_CachedPlayers.clear();
    g_ESPData.clear();
}

void* SDK::GetCurrentCamera() {
    ULONGLONG now = GetTickCount64();
    if (g_CachedCamera && IsValidUnityObj(g_CachedCamera) && (now - g_LastCameraCheckTime < 250)) {
        return g_CachedCamera;
    }
    g_LastCameraCheckTime = now;

    void* cam = nullptr;
    if (g_HasLocalPlayer && g_LocalPlayerInfo.playerMovement && IsValidUnityObj(g_LocalPlayerInfo.playerMovement)) {
        void* camCtrl = *(void**)((char*)g_LocalPlayerInfo.playerMovement + 0x220); // _cam
        if (camCtrl && IsValidUnityObj(camCtrl)) {
            cam = *(void**)((char*)camCtrl + 0x140); // cam
        }
    }
    if (!cam || !IsValidUnityObj(cam)) {
        cam = g_Il2Cpp.GetMainCamera();
    }
    if (cam && IsValidUnityObj(cam)) {
        g_CachedCamera = cam;
    }
    return g_CachedCamera;
}

void SDK::OptimizePerformance() {
    static bool s_Optimized = false;
    if (bFpsBoostUltra && !s_Optimized) {
        g_Il2Cpp.EnsureThreadAttached();
        if (QualitySettingsClass && SetVSyncCountMethod && g_Il2Cpp.il2cpp_runtime_invoke) {
            int vsync = 0; // Disable VSync for unconstrained framerates
            void* args1[1] = { &vsync };
            void* exc = nullptr;
            g_Il2Cpp.il2cpp_runtime_invoke(SetVSyncCountMethod, nullptr, args1, &exc);

            int targetFps = 1000; // Unlimited target FPS
            void* args2[1] = { &targetFps };
            if (SetTargetFrameRateMethod) {
                g_Il2Cpp.il2cpp_runtime_invoke(SetTargetFrameRateMethod, nullptr, args2, &exc);
            }
            s_Optimized = true;
            CheatLog("[+] Ultra Performance FPS Optimizer Applied (VSync=0, MaxFPS=1000)");
        }
    } else if (!bFpsBoostUltra && s_Optimized) {
        s_Optimized = false;
    }
}

void SDK::ScanEntities() {
    ULONGLONG now = GetTickCount64();
    if (now - g_LastScanTime < 45) return; // ~22Hz background entity query
    g_LastScanTime = now;

    if (!PlayerClass) return;

    __try {
        g_Il2Cpp.EnsureThreadAttached();
        Il2CppArray* arr = g_Il2Cpp.FindObjectsOfType(PlayerClass);
        if (!arr || !IsValidMemPtr(arr, 0x28)) {
            ResetCache();
            return;
        }

        uintptr_t count = *(uintptr_t*)((char*)arr + 0x18);
        if (count == 0 || count > 64) {
            g_HasLocalPlayer = false;
            g_CachedPlayers.clear();
            return;
        }

        void** items = (void**)((char*)arr + 0x20);
        if (!IsValidMemPtr(items, count * sizeof(void*))) return;

        std::vector<CachedPlayerInfo> newPlayers;
        newPlayers.reserve(count);

        bool foundLocal = false;
        CachedPlayerInfo localInfo{};

        for (uintptr_t i = 0; i < count; i++) {
            void* p = items[i];
            if (!IsValidUnityObj(p)) continue;
            if (!g_Il2Cpp.IsGameObjectActiveInHierarchy(p)) continue;

            CachedPlayerInfo info{};
            info.playerObj = p;
            info.isLocal = g_Il2Cpp.IsLocalPlayer(p);

            if (HealthClass) {
                info.healthComp = g_Il2Cpp.GetComponent(p, HealthClass);
                if (info.healthComp && IsValidUnityObj(info.healthComp)) {
                    info.maxHp = *(int*)((char*)info.healthComp + 0xF8);
                    void* curHpObj = *(void**)((char*)info.healthComp + 0x100);
                    if (curHpObj && IsValidMemPtr(curHpObj, 0x90)) {
                        info.hp = *(int*)((char*)curHpObj + 0x84);
                    } else {
                        info.hp = info.maxHp;
                    }
                    if (IsDeadMethod) {
                        void* exc = nullptr;
                        Il2CppObject* res = g_Il2Cpp.il2cpp_runtime_invoke(IsDeadMethod, info.healthComp, nullptr, &exc);
                        if (!exc && res && IsValidMemPtr(res, 0x18)) {
                            info.isDead = *(bool*)((char*)res + 0x10);
                        }
                    }
                }
            }

            if (HealthGracePeriodClass) {
                info.graceComp = g_Il2Cpp.GetComponent(p, HealthGracePeriodClass);
            }

            if (PlayerMovementClass) {
                info.playerMovement = g_Il2Cpp.GetComponent(p, PlayerMovementClass);
                if (info.playerMovement && IsValidUnityObj(info.playerMovement)) {
                    info.awayTeam = *(bool*)((char*)info.playerMovement + 0x1C4);
                }
            }

            if (WeaponManagerClass) {
                info.weaponManager = g_Il2Cpp.GetComponent(p, WeaponManagerClass);
            }

            // Bone Rigidbodies (Exact offsets from Player TypeDefIndex 7869)
            info.spineRb     = *(void**)((char*)p + 0x100);
            info.rootRb      = *(void**)((char*)p + 0x108);
            info.lFootRb     = *(void**)((char*)p + 0x110);
            info.rFootRb     = *(void**)((char*)p + 0x118);
            info.lKneeRb     = *(void**)((char*)p + 0x120);
            info.rKneeRb     = *(void**)((char*)p + 0x128);
            info.lHandRb     = *(void**)((char*)p + 0x130);
            info.rHandRb     = *(void**)((char*)p + 0x138);
            info.lElbowRb    = *(void**)((char*)p + 0x140);
            info.rElbowRb    = *(void**)((char*)p + 0x148);
            info.lUpperArmRb = *(void**)((char*)p + 0x150);
            info.rUpperArmRb = *(void**)((char*)p + 0x158);
            info.lShoulderRb = *(void**)((char*)p + 0x160);
            info.rShoulderRb = *(void**)((char*)p + 0x168);
            info.chestRb     = *(void**)((char*)p + 0x170);

            if (info.isLocal) {
                foundLocal = true;
                localInfo = info;
            }
            newPlayers.push_back(info);
        }

        if (foundLocal) {
            g_HasLocalPlayer = true;
            g_LocalPlayerInfo = localInfo;
            for (auto& pl : newPlayers) {
                if (pl.isLocal) {
                    pl.isEnemy = false;
                } else {
                    // If both players have false/default awayTeam, or different teams -> they are targets
                    pl.isEnemy = true;
                }
            }
        } else {
            g_HasLocalPlayer = false;
            for (auto& pl : newPlayers) pl.isEnemy = true;
        }

        g_CachedPlayers = newPlayers;
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {
        ResetCache();
    }
}

void SDK::ResolveBoneSafe(void* mainCam, void* rbPtr, BonePoint& outBone) {
    outBone.valid = false;
    if (!rbPtr || !mainCam || !IsValidUnityObj(rbPtr) || !IsValidUnityObj(mainCam)) return;

    __try {
        if (g_Il2Cpp.GetRigidbodyPosition(rbPtr, &outBone.world)) {
            if (fabsf(outBone.world.x) < 0.001f && fabsf(outBone.world.y) < 0.001f && fabsf(outBone.world.z) < 0.001f)
                return;

            if (g_Il2Cpp.WorldToScreen(mainCam, outBone.world, &outBone.screen)) {
                if (outBone.screen.z > 0.3f && outBone.screen.z < 500.0f &&
                    !std::isnan(outBone.screen.z) && !std::isinf(outBone.screen.z) &&
                    !std::isnan(outBone.screen.x) && !std::isnan(outBone.screen.y)) {

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

void SDK::UpdateESPData() {
    void* activeCam = GetCurrentCamera();
    if (!activeCam || !IsValidUnityObj(activeCam)) {
        g_ESPData.clear();
        return;
    }

    __try {
        std::vector<PlayerESPData> newData;
        newData.reserve(g_CachedPlayers.size());

        for (const auto& pl : g_CachedPlayers) {
            if (bIgnoreLocal && pl.isLocal) continue;
            if (bIgnoreDead && (pl.isDead || pl.hp <= 0)) continue;
            if (bIgnoreTeammates && !pl.isEnemy) continue;
            if (!IsValidUnityObj(pl.playerObj)) continue;

            PlayerESPData data{};
            data.hp       = pl.hp;
            data.maxHp    = pl.maxHp;
            data.isDead   = pl.isDead;
            data.awayTeam = pl.awayTeam;
            data.isEnemy  = pl.isEnemy;
            data.isLocal  = pl.isLocal;

            ResolveBoneSafe(activeCam, pl.chestRb,     data.chest);
            ResolveBoneSafe(activeCam, pl.rootRb,      data.root);
            ResolveBoneSafe(activeCam, pl.spineRb,     data.spine);
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

            if (data.chest.valid) {
                Vector3 headWorld = data.chest.world + Vector3(0.0f, 0.40f, 0.0f);
                data.head.world   = headWorld;
                if (g_Il2Cpp.WorldToScreen(activeCam, headWorld, &data.head.screen)) {
                    if (data.head.screen.z > 0.3f && data.head.screen.z < 500.0f &&
                        !std::isnan(data.head.screen.x) && !std::isnan(data.head.screen.y)) {
                        data.head.valid = true;
                    }
                }
            }

            if (data.root.valid) data.distance = data.root.screen.z;
            else if (data.chest.valid) data.distance = data.chest.screen.z;

            if (data.distance > fMaxDistance || data.distance <= 0.0f) continue;

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
