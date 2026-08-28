#pragma once
#include "core/Common.h"
#include "sdk/GameSDK.h"

class Combat {
public:
    static void Update(ImGuiIO& io);
    static bool GetSilentAimTargetPosition(Vector3* outTargetPos);
    static void DoMassKill();
    static void DoTeleportKill(ImGuiIO& io);

private:
    static void DoAimbot(ImGuiIO& io);
    static void DoTriggerbot();
};
