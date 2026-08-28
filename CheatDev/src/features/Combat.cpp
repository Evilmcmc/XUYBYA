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

        if (!g_LocalPlayerInfo.weaponManager || !IsValidUnityObj(g_LocalPlayerInfo.weaponManager)) return;
        void* activeWeapon = *(void**)((char*)g_LocalPlayerInfo.weaponManager + 0x120);
        if (!activeWeapon || !IsValidUnityObj(activeWeapon)) return;

        // Ensure max stats on active weapon
        __try {
            *(bool*)((char*)activeWeapon + 0x120) = true;
            *(int*)((char*)activeWeapon + 0x114)  = 999;
            *(float*)((char*)activeWeapon + 0x110) = 0.0f;
        }
        __except (EXCEPTION_EXECUTE_HANDLER) { return; }

        void* wData = *(void**)((char*)activeWeapon + 0x100);
        if (wData && IsValidUnityObj(wData)) {
            __try {
                *(int*)((char*)wData + 0x18)   = 1000;
                *(int*)((char*)wData + 0x1C)   = 1000;
                *(float*)((char*)wData + 0x20) = 500.0f;
                *(float*)((char*)wData + 0x24) = 0.05f;
            }
            __except (EXCEPTION_EXECUTE_HANDLER) {}
        }

        for (const auto& pl : g_CachedPlayers) {
            if (!pl.isEnemy || pl.isDead || pl.hp <= 0 || !IsValidUnityObj(pl.playerObj)) continue;

            if (pl.healthComp && SDK::CMDChangeCurrentHealth && IsValidUnityObj(pl.healthComp)) {
                int deadHealth = 0;
                void* hArgs[1] = { &deadHealth };
                void* excH = nullptr;
                g_Il2Cpp.il2cpp_runtime_invoke(SDK::CMDChangeCurrentHealth, pl.healthComp, hArgs, &excH);
            }
        }

        if (SDK::ClientTryShoot) {
            void* excShoot = nullptr;
            g_Il2Cpp.il2cpp_runtime_invoke(SDK::ClientTryShoot, activeWeapon, nullptr, &excShoot);
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
            // Сначала обнуляем скорость для предотвращения инерции
            g_Il2Cpp.SetRigidbodyLinearVelocity(myRootRb, Vector3(0.0f, 0.0f, 0.0f));
            g_Il2Cpp.SetRigidbodyAngularVelocity(myRootRb, Vector3(0.0f, 0.0f, 0.0f));
            
            // Затем телепортируем
            g_Il2Cpp.MoveRigidbodyPosition(myRootRb, destPos);
            
            // Финальное обнуление скорости
            Sleep(1); // Микропауза для синхронизации физики
            g_Il2Cpp.SetRigidbodyLinearVelocity(myRootRb, Vector3(0.0f, 0.0f, 0.0f));
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
