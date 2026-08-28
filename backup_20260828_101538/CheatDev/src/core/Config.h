#pragma once
#include "core/Common.h"

class Config {
public:
    static void Save();
    static void Load();
    static void LoadHvHPreset();
    static void ResetDefaults();
    static const char* GetStatus();
};
