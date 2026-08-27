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

    for (const auto& data : g_ESPData) {
        if (!data.isEnemy) continue;
        if (data.isDead || data.hp <= 0) continue;
        if (data.aimScreenPos.z <= 0.3f) continue;

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
        if (!pl.isEnemy || pl.isDead || pl.hp <= 0) continue;
        if (!IsValidUnityObj(pl.playerObj)) continue;

        void* targetRb = pl.chestRb ? pl.chestRb : pl.rootRb;
        if (!targetRb || !IsValidUnityObj(targetRb)) continue;

        Vector3 bonePos{};
        if (!g_Il2Cpp.GetRigidbodyPosition(targetRb, &bonePos)) continue;
        if (fabsf(bonePos.x) < 0.001f && fabsf(bonePos.y) < 0.001f && fabsf(bonePos.z) < 0.001f) continue;

        if (iSilentAimTarget == 1) {
            bonePos = bonePos + Vector3(0.0f, 0.40f, 0.0f); // Head offset
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

void Combat::DoMassKill() {
    if (!bEnableMassKill || !g_HasLocalPlayer) return;

    __try {
        ULONGLONG now = GetTickCount64();
        if (now - g_LastMassKillTime < (ULONGLONG)fMassKillInterval) return;
        g_LastMassKillTime = now;

        if (!g_LocalPlayerInfo.weaponManager || !IsValidUnityObj(g_LocalPlayerInfo.weaponManager)) return;
        void* activeWeapon = *(void**)((char*)g_LocalPlayerInfo.weaponManager + 0x120);
        if (!activeWeapon || !IsValidUnityObj(activeWeapon)) return;

        // Ensure max stats on active weapon
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
        void* activeCam = SDK::GetCurrentCamera();
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

            if (SDK::PackDirectionMethod && SDK::PackVector3Method && SDK::CMDShoot) {
                Vector3 aimDir = targetHeadPos - localCamPos;
                float len = aimDir.Length();
                if (len > 0.001f) aimDir = aimDir * (1.0f / len);
                else aimDir = Vector3(0.0f, 1.0f, 0.0f);

                void* posArgs[1] = { &localCamPos };
                void* fwdArgs[1] = { &aimDir };
                void* exc1 = nullptr;
                void* exc2 = nullptr;

                Il2CppObject* packedPos = g_Il2Cpp.il2cpp_runtime_invoke(SDK::PackVector3Method, nullptr, posArgs, &exc1);
                Il2CppObject* packedFwd = g_Il2Cpp.il2cpp_runtime_invoke(SDK::PackDirectionMethod, nullptr, fwdArgs, &exc2);

                if (packedPos && packedFwd && !exc1 && !exc2) {
                    uint32_t tick = 0;
                    void* shootArgs[3] = { packedPos, packedFwd, &tick };
                    void* exc3 = nullptr;
                    g_Il2Cpp.il2cpp_runtime_invoke(SDK::CMDShoot, activeWeapon, shootArgs, &exc3);
                }
            }

            if (SDK::ClientTryShoot) {
                void* excShoot = nullptr;
                g_Il2Cpp.il2cpp_runtime_invoke(SDK::ClientTryShoot, activeWeapon, nullptr, &excShoot);
            }

            killedCount++;
        }

        if (killedCount > 0) {
            CheatLog("Mass Kill Aura: annihilated %d target(s)", killedCount);
        }
    }
    __except(EXCEPTION_EXECUTE_HANDLER) {}
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

        Vector3 destPos = targetPos;
        if (iTeleportPosition == 0) destPos = targetPos + Vector3(0.0f, fTeleportHeight, -fTeleportDistance);
        else if (iTeleportPosition == 1) destPos = targetPos + Vector3(0.0f, fTeleportDistance + 1.0f, 0.0f);
        else if (iTeleportPosition == 2) destPos = targetPos + Vector3(0.0f, fTeleportHeight, fTeleportDistance);

        void* myRootRb = g_LocalPlayerInfo.rootRb;
        if (myRootRb && IsValidUnityObj(myRootRb)) {
            g_Il2Cpp.MoveRigidbodyPosition(myRootRb, destPos);
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
    __except(EXCEPTION_EXECUTE_HANDLER) {}
}

void Combat::DoTriggerbot() {
    if (!bTriggerbot || !g_HasLocalPlayer || !g_LocalPlayerInfo.weaponManager) return;

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
