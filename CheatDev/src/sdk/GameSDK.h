#pragma once
#include "core/Common.h"

class SDK {
public:
    static bool Initialize();
    static void ResetCache();

    static void* GetCurrentCamera();
    static void ScanEntities();
    static void UpdateESPData();

    static void OptimizePerformance();

    // IL2CPP Classes
    static Il2CppClass* PlayerClass;
    static Il2CppClass* PlayerMovementClass;
    static Il2CppClass* PlayerBountyUpdateClass;
    static Il2CppClass* PhysicalOutlineClass;
    static Il2CppClass* TextMeshProClass;
    static Il2CppClass* HealthClass;
    static Il2CppClass* SharedRefClass;
    static Il2CppClass* RagdollCamClass;
    static Il2CppClass* WeaponClass;
    static Il2CppClass* WeaponManagerClass;
    static Il2CppClass* DataPackerClass;
    static Il2CppClass* GameCountdownClass;
    static Il2CppClass* LevelLoaderClass;
    static Il2CppClass* PlayerEndGameClass;
    static Il2CppClass* HealthGracePeriodClass;
    static Il2CppClass* BarrelClass;
    static Il2CppClass* BillboardClass;
    static Il2CppClass* QualitySettingsClass;
    static Il2CppClass* WeaponSpawnClass;
    static Il2CppClass* SpeedBoostSpawnPointClass;

    // IL2CPP Methods
    static MethodInfo* DisableCountdownMethod;
    static MethodInfo* DestroyPlayerMethod;
    static MethodInfo* GetCurrentHealth;
    static MethodInfo* IsDeadMethod;
    static MethodInfo* CMDChangeCurrentHealth;
    static MethodInfo* ClientTryShoot;
    static MethodInfo* CMDShoot;
    static MethodInfo* PickUpMethod;
    static MethodInfo* StartPickUpMethod;
    static MethodInfo* PackDirectionMethod;
    static MethodInfo* UnpackShortMethod;
    static MethodInfo* PackVector3Method;
    static MethodInfo* UnpackDirectionMethod;
    static MethodInfo* StartSharedEffectsMethod;
    static MethodInfo* TryUpdateGunGameWeaponMethod;
    static MethodInfo* SetQualityLevelMethod;
    static MethodInfo* SetVSyncCountMethod;
    static MethodInfo* SetTargetFrameRateMethod;

private:
    static void ResolveBoneSafe(void* mainCam, void* rbPtr, BonePoint& outBone);
};
