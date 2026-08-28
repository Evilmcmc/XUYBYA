#include "features/Combat.h"

static ULONGLONG g_LastMassKillTime = 0;
static ULONGLONG g_LastTeleportShootTime = 0;
static size_t    g_TeleportTargetIdx = 0;

void Combat::Update(ImGuiIO& io) {
    if (bEnableAimbot) DoAimbot(io);
    if (bEnableTeleportKill) DoTeleportKill(io);
    if (bEnableMassKill) DoMassKill();
    if (bTriggerbot) DoTriggerbot();
}

void Combat::DoAimbot(ImGuiIO& io) {
    if (g_ShowMenu) return;
    if (!bEnableAimbot) return;
    if (!IsKeyActive(iAimbotKey)) return;

    float cx = io.DisplaySize.x * 0.5f;
    float cy = io.DisplaySize.y * 0.5f;
    float sh = io.DisplaySize.y;

    float bestDist = (aimbotFOV > 0.0f) ? aimbotFOV : 99999.0f;
    float tgtX = 0.0f, tgtY = 0.0f;

    // 1. Search ESP screen projected points
    for (const auto& data : g_ESPData) {
        if (!data.isEnemy || data.isLocal) continue;
        if (data.isDead || data.hp <= 0) continue;
        if (data.aimScreenPos.z <= 0.1f) continue;

        float sx = data.aimScreenPos.x;
        float sy = sh - data.aimScreenPos.y;

        float dist = sqrtf((sx - cx) * (sx - cx) + (sy - cy) * (sy - cy));
        if (dist < bestDist) {
            bestDist = dist;
            tgtX = sx;
            tgtY = sy;
        }
    }

    // 2. Direct fallback from CachedPlayers if ESP is inactive
    if (tgtX == 0.0f && tgtY == 0.0f) {
        void* activeCam = SDK::GetCurrentCamera();
        if (activeCam && IsValidUnityObj(activeCam)) {
            for (const auto& pl : g_CachedPlayers) {
                if (!pl.isEnemy || pl.isLocal || pl.isDead || pl.hp <= 0) continue;
                if (!IsValidUnityObj(pl.playerObj)) continue;

                Vector3 worldPos{};
                void* rb = pl.chestRb ? pl.chestRb : pl.rootRb;
                if (!rb || !g_Il2Cpp.GetRigidbodyPosition(rb, &worldPos)) {
                    void* tr = g_Il2Cpp.GetComponentTransform(pl.playerObj);
                    if (tr) g_Il2Cpp.GetTransformPosition(tr, &worldPos);
                    else continue;
                }

                if (iAimbotTarget == 1) worldPos = worldPos + Vector3(0.0f, 0.45f, 0.0f);

                Vector3 screenPos{};
                if (g_Il2Cpp.WorldToScreen(activeCam, worldPos, &screenPos) && screenPos.z > 0.1f) {
                    float sx = screenPos.x;
                    float sy = sh - screenPos.y;
                    float dist = sqrtf((sx - cx) * (sx - cx) + (sy - cy) * (sy - cy));
                    if (dist < bestDist) {
                        bestDist = dist;
                        tgtX = sx;
                        tgtY = sy;
                    }
                }
            }
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

            if (bAimbotAutoFire && g_HasLocalPlayer && g_LocalPlayerInfo.weaponManager) {
                void* activeWeapon = *(void**)((char*)g_LocalPlayerInfo.weaponManager + 0x120);
                if (activeWeapon && IsValidUnityObj(activeWeapon) && SDK::ClientTryShoot) {
                    void* exc = nullptr;
                    g_Il2Cpp.il2cpp_runtime_invoke(SDK::ClientTryShoot, activeWeapon, nullptr, &exc);
                }
            }
        }
    }
}

bool Combat::GetSilentAimTargetPosition(Vector3* outTargetPos) {
    if (!outTargetPos) return false;

    void* activeCam = SDK::GetCurrentCamera();
    ImGuiIO& io = ImGui::GetIO();
    float cx = io.DisplaySize.x * 0.5f;
    float cy = io.DisplaySize.y * 0.5f;
    float sh = io.DisplaySize.y;

    float bestScore = 9999999.0f;
    Vector3 bestPos{};
    bool found = false;

    for (const auto& pl : g_CachedPlayers) {
        if (!pl.isEnemy || pl.isLocal || pl.isDead || pl.hp <= 0) continue;
        if (!IsValidUnityObj(pl.playerObj)) continue;

        void* targetRb = pl.chestRb ? pl.chestRb : pl.rootRb;
        Vector3 bonePos{};
        if (!targetRb || !g_Il2Cpp.GetRigidbodyPosition(targetRb, &bonePos)) {
            void* tr = g_Il2Cpp.GetComponentTransform(pl.playerObj);
            if (tr) {
                g_Il2Cpp.GetTransformPosition(tr, &bonePos);
                bonePos = bonePos + Vector3(0.0f, 0.85f, 0.0f);
            } else {
                continue;
            }
        }

        if (iSilentAimTarget == 1) {
            bonePos = bonePos + Vector3(0.0f, 0.45f, 0.0f); // Head
        }

        float score = 0.0f;
        if (!bSilentAimFull360 && activeCam && IsValidUnityObj(activeCam)) {
            Vector3 screenPos{};
            if (!g_Il2Cpp.WorldToScreen(activeCam, bonePos, &screenPos) || screenPos.z <= 0.1f) {
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

void Combat::DoMassKill() {
    if (!bEnableMassKill || !g_HasLocalPlayer) return;

    __try {
        ULONGLONG now = GetTickCount64();
        float interval = (fMassKillInterval < 150.0f) ? 150.0f : fMassKillInterval;
        if (now - g_LastMassKillTime < (ULONGLONG)interval) return;
        g_LastMassKillTime = now;

        // Mode selection: 0 = ExplodeRocket (AOE, powerful), 1 = CMDShoot (targeted), 2 = Both
        bool useExplodeRocket = (iMassKillMode == 0 || iMassKillMode == 2);
        bool useCMDShoot = (iMassKillMode == 1 || iMassKillMode == 2);

        // --- MODE A: ExplodeRocket (RequireOwnership = False — any client can trigger) ---
        if (useExplodeRocket && SDK::ExplodeRocketMethod) {
            // Find ANY RocketLauncher instance (doesn't need to be ours)
            void* rocketLauncher = nullptr;

            // Try local player's weapons first
            if (g_LocalPlayerInfo.weaponManager && IsValidUnityObj(g_LocalPlayerInfo.weaponManager)) {
                void* weaponsList = *(void**)((char*)g_LocalPlayerInfo.weaponManager + 0x110);
                if (weaponsList && IsValidMemPtr(weaponsList, 0x20)) {
                    Il2CppArray* wArr = *(Il2CppArray**)((char*)weaponsList + 0x10);
                    int wCount = *(int*)((char*)weaponsList + 0x18);
                    if (wArr && IsValidMemPtr(wArr, 0x28) && wCount > 0 && wCount <= 32) {
                        void** wItems = (void**)((char*)wArr + 0x20);
                        for (int w = 0; w < wCount && !rocketLauncher; w++) {
                            void* wObj = wItems[w];
                            if (!wObj || !IsValidUnityObj(wObj)) continue;
                            // Check if this weapon's class matches RocketLauncher
                            if (g_Il2Cpp.il2cpp_object_get_class && SDK::RocketLauncherClass) {
                                void* klass = g_Il2Cpp.il2cpp_object_get_class((Il2CppObject*)wObj);
                                if (klass == SDK::RocketLauncherClass) {
                                    rocketLauncher = wObj;
                                }
                            }
                        }
                    }
                }
            }

            // Fallback: try FindObjectsOfType for any RocketLauncher in the scene
            if (!rocketLauncher && SDK::RocketLauncherClass) {
                Il2CppArray* launchers = g_Il2Cpp.FindObjectsOfType(SDK::RocketLauncherClass);
                if (launchers && IsValidMemPtr(launchers, 0x28)) {
                    uintptr_t cnt = *(uintptr_t*)((char*)launchers + 0x18);
                    if (cnt > 0 && cnt <= 64) {
                        void** items = (void**)((char*)launchers + 0x20);
                        for (uintptr_t i = 0; i < cnt && !rocketLauncher; i++) {
                            if (items[i] && IsValidUnityObj(items[i])) {
                                rocketLauncher = items[i];
                            }
                        }
                    }
                }
            }

            if (rocketLauncher) {
                for (const auto& pl : g_CachedPlayers) {
                    if (!pl.isEnemy || pl.isDead || pl.hp <= 0 || !IsValidUnityObj(pl.playerObj)) continue;

                    Vector3 enemyPos{};
                    void* eRb = pl.chestRb ? pl.chestRb : pl.rootRb;
                    if (!eRb || !IsValidUnityObj(eRb)) continue;
                    if (!g_Il2Cpp.GetRigidbodyPosition(eRb, &enemyPos)) continue;

                    // ExplodeRocket(Vector3 position) — server-side AOE damage at this position
                    void* args[1] = { &enemyPos };
                    void* exc = nullptr;
                    g_Il2Cpp.il2cpp_runtime_invoke(SDK::ExplodeRocketMethod, rocketLauncher, args, &exc);
                }
                CheatLog("[MASS_KILL] ExplodeRocket sent for all enemies");
            }
        }

        // --- MODE B: CMDShoot with aimed vectors ---
        if (useCMDShoot) {
            if (!g_LocalPlayerInfo.weaponManager || !IsValidUnityObj(g_LocalPlayerInfo.weaponManager)) return;
            void* activeWeapon = *(void**)((char*)g_LocalPlayerInfo.weaponManager + 0x120);
            if (!activeWeapon || !IsValidUnityObj(activeWeapon)) return;

            // Ensure weapon can fire
            *(bool*)((char*)activeWeapon + 0x120) = true;  // canShoot
            *(int*)((char*)activeWeapon + 0x114)  = 999;   // currentAmmo
            *(float*)((char*)activeWeapon + 0x110) = 0.0f; // nextTimeToFire

            // Fire CMDShoot at each enemy through ClientTryShoot (which uses SilentAim targeting)
            if (SDK::ClientTryShoot) {
                void* excShoot = nullptr;
                g_Il2Cpp.il2cpp_runtime_invoke(SDK::ClientTryShoot, activeWeapon, nullptr, &excShoot);
            }
        }

        // Legacy fallback: CMDChangeCurrentHealth on own health (GodMode boost)
        if (g_LocalPlayerInfo.healthComp && SDK::CMDChangeCurrentHealth && IsValidUnityObj(g_LocalPlayerInfo.healthComp)) {
            int maxHp = 1000;
            void* hArgs[1] = { &maxHp };
            void* excH = nullptr;
            g_Il2Cpp.il2cpp_runtime_invoke(SDK::CMDChangeCurrentHealth, g_LocalPlayerInfo.healthComp, hArgs, &excH);
        }
    }
    __except (EXCEPTION_EXECUTE_HANDLER) {}
}

void Combat::DoTeleportKill(ImGuiIO& /*io*/) {
    if (!bEnableTeleportKill || !g_HasLocalPlayer) return;
    if (bTeleportHoldKey && !IsKeyActive(iTeleportKey)) return;

    __try {
        std::vector<const CachedPlayerInfo*> validEnemies;
        for (const auto& pl : g_CachedPlayers) {
            if (pl.isEnemy && !pl.isDead && pl.hp > 0 && IsValidUnityObj(pl.playerObj)) {
                validEnemies.push_back(&pl);
            }
        }
        if (validEnemies.empty()) return;

        const CachedPlayerInfo* target = nullptr;
        if (iTeleportTargetMode == 0) {
            if (g_TeleportTargetIdx >= validEnemies.size()) g_TeleportTargetIdx = 0;
            target = validEnemies[g_TeleportTargetIdx];
        } else if (iTeleportTargetMode == 1) {
            float minDist = 99999.0f;
            Vector3 myPos{};
            if (g_LocalPlayerInfo.rootRb && IsValidUnityObj(g_LocalPlayerInfo.rootRb)) {
                g_Il2Cpp.GetRigidbodyPosition(g_LocalPlayerInfo.rootRb, &myPos);
            }
            for (const auto* e : validEnemies) {
                Vector3 ePos{};
                if (e->rootRb && IsValidUnityObj(e->rootRb) && g_Il2Cpp.GetRigidbodyPosition(e->rootRb, &ePos)) {
                    float d = (ePos - myPos).Length();
                    if (d < minDist) {
                        minDist = d;
                        target = e;
                    }
                }
            }
        } else {
            int minHp = 999999;
            for (const auto* e : validEnemies) {
                if (e->hp < minHp) {
                    minHp = e->hp;
                    target = e;
                }
            }
        }

        if (!target) return;

        void* targetRb = target->chestRb ? target->chestRb : target->rootRb;
        if (!targetRb || !IsValidUnityObj(targetRb)) return;

        Vector3 targetPos{};
        if (!g_Il2Cpp.GetRigidbodyPosition(targetRb, &targetPos)) return;

        Vector3 targetFwd(0.0f, 0.0f, 1.0f);
        void* targetTr = g_Il2Cpp.GetComponentTransform(targetRb);
        if (!targetTr && target->playerObj) targetTr = g_Il2Cpp.GetComponentTransform(target->playerObj);
        if (targetTr && IsValidUnityObj(targetTr)) {
            g_Il2Cpp.GetTransformForward(targetTr, &targetFwd);
        }

        // Нормализация вектора направления для безопасности
        float fwdLen = sqrtf(targetFwd.x * targetFwd.x + targetFwd.z * targetFwd.z);
        if (fwdLen > 0.01f) {
            targetFwd.x /= fwdLen;
            targetFwd.z /= fwdLen;
            targetFwd.y = 0.0f; // Игнорируем вертикальную составляющую
        } else {
            targetFwd = Vector3(0.0f, 0.0f, 1.0f);
        }

        // БЕЗОПАСНАЯ высота над землёй — предотвращает застревание в текстурах
        float safeElevation = 0.25f; // Минимальная безопасная высота
        
        // Ограничение дистанции телепорта (предотвращает вылет в космос)
        float safeDist = fTeleportDistance;
        if (safeDist < 0.5f) safeDist = 0.5f;
        if (safeDist > 3.5f) safeDist = 3.5f; // Максимум 3.5 метра
        
        float safeHeight = fTeleportHeight;
        if (safeHeight < -0.5f) safeHeight = -0.5f;
        if (safeHeight > 2.0f) safeHeight = 2.0f;

        Vector3 destPos = targetPos;
        if (iTeleportPosition == 0) {
            // Сзади врага (Backstab)
            destPos = targetPos - (targetFwd * safeDist);
            destPos.y = targetPos.y + safeElevation + safeHeight;
        } else if (iTeleportPosition == 1) {
            // Над врагом (только небольшая высота)
            float aboveHeight = safeDist;
            if (aboveHeight > 2.5f) aboveHeight = 2.5f;
            destPos = targetPos + Vector3(0.0f, aboveHeight + 0.5f, 0.0f);
        } else if (iTeleportPosition == 2) {
            // Впереди врага
            destPos = targetPos + (targetFwd * safeDist);
            destPos.y = targetPos.y + safeElevation + safeHeight;
        } else {
            // Прямо на цель
            destPos = targetPos;
            destPos.y = targetPos.y + safeElevation + safeHeight;
        }

        // КРИТИЧЕСКИ ВАЖНО: Проверка координат на валидность (предотвращает вылет в космос)
        if (std::isnan(destPos.x) || std::isnan(destPos.y) || std::isnan(destPos.z) ||
            std::isinf(destPos.x) || std::isinf(destPos.y) || std::isinf(destPos.z)) {
            return; // Отмена телепорта при некорректных координатах
        }

        // Ограничение по высоте (предотвращает вылет в небо)
        if (destPos.y > targetPos.y + 10.0f) destPos.y = targetPos.y + 2.0f;
        if (destPos.y < targetPos.y - 5.0f) destPos.y = targetPos.y + 0.5f;

        void* myRootRb = g_LocalPlayerInfo.rootRb;
        if (myRootRb && IsValidUnityObj(myRootRb)) {
            // Get current position for delta calculation
            Vector3 myPos{};
            g_Il2Cpp.GetRigidbodyPosition(myRootRb, &myPos);
            Vector3 delta = destPos - myPos;

            // Teleport ALL ragdoll bones by the same delta (prevents space flyaway)
            void* boneList[] = {
                g_LocalPlayerInfo.rootRb, g_LocalPlayerInfo.spineRb, g_LocalPlayerInfo.chestRb,
                g_LocalPlayerInfo.lShoulderRb, g_LocalPlayerInfo.rShoulderRb,
                g_LocalPlayerInfo.lUpperArmRb, g_LocalPlayerInfo.rUpperArmRb,
                g_LocalPlayerInfo.lElbowRb, g_LocalPlayerInfo.rElbowRb,
                g_LocalPlayerInfo.lHandRb, g_LocalPlayerInfo.rHandRb,
                g_LocalPlayerInfo.lKneeRb, g_LocalPlayerInfo.rKneeRb,
                g_LocalPlayerInfo.lFootRb, g_LocalPlayerInfo.rFootRb
            };

            for (int i = 0; i < 15; i++) {
                void* bone = boneList[i];
                if (!bone || !IsValidUnityObj(bone)) continue;
                
                Vector3 bonePos{};
                if (g_Il2Cpp.GetRigidbodyPosition(bone, &bonePos)) {
                    Vector3 newBonePos = bonePos + delta;
                    g_Il2Cpp.MoveRigidbodyPosition(bone, newBonePos);
                }
                g_Il2Cpp.SetRigidbodyLinearVelocity(bone, Vector3(0.0f, 0.0f, 0.0f));
                g_Il2Cpp.SetRigidbodyAngularVelocity(bone, Vector3(0.0f, 0.0f, 0.0f));
            }
        }

        ULONGLONG now = GetTickCount64();
        if (bTeleportAutoShoot && (now - g_LastTeleportShootTime >= (ULONGLONG)fTeleportShootRate)) {
            g_LastTeleportShootTime = now;
            if (g_LocalPlayerInfo.weaponManager && IsValidUnityObj(g_LocalPlayerInfo.weaponManager)) {
                void* activeWeapon = *(void**)((char*)g_LocalPlayerInfo.weaponManager + 0x120);
                if (activeWeapon && IsValidUnityObj(activeWeapon) && SDK::ClientTryShoot) {
                    void* exc = nullptr;
                    g_Il2Cpp.il2cpp_runtime_invoke(SDK::ClientTryShoot, activeWeapon, nullptr, &exc);
                }
            }
        }
    }
    __except (EXCEPTION_EXECUTE_HANDLER) {}
}

void Combat::DoTriggerbot() {
    if (!bTriggerbot || !g_HasLocalPlayer || !g_LocalPlayerInfo.weaponManager) return;

    __try {
        static ULONGLONG s_LastTriggerTime = 0;
        ULONGLONG now = GetTickCount64();
        if (now - s_LastTriggerTime < (ULONGLONG)(fTriggerbotDelay * 1000.0f)) return;

        void* activeCam = SDK::GetCurrentCamera();
        if (!activeCam || !IsValidUnityObj(activeCam)) return;

        ImGuiIO& io = ImGui::GetIO();
        float cx = io.DisplaySize.x * 0.5f;
        float cy = io.DisplaySize.y * 0.5f;
        float sh = io.DisplaySize.y;

        for (const auto& data : g_ESPData) {
            if (!data.isEnemy || data.isDead || data.hp <= 0) continue;
            const BonePoint& targetBone = bTriggerbotHeadOnly ? data.head : (data.chest.valid ? data.chest : data.root);
            if (!targetBone.valid) continue;

            float sx = targetBone.screen.x;
            float sy = sh - targetBone.screen.y;
            float dist = sqrtf((sx - cx) * (sx - cx) + (sy - cy) * (sy - cy));

            if (dist <= 25.0f) {
                void* activeWeapon = *(void**)((char*)g_LocalPlayerInfo.weaponManager + 0x120);
                if (activeWeapon && IsValidUnityObj(activeWeapon) && SDK::ClientTryShoot) {
                    void* exc = nullptr;
                    g_Il2Cpp.il2cpp_runtime_invoke(SDK::ClientTryShoot, activeWeapon, nullptr, &exc);
                    s_LastTriggerTime = now;
                    break;
                }
            }
        }
    }
    __except (EXCEPTION_EXECUTE_HANDLER) {}
}
