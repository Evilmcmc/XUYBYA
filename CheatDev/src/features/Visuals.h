#pragma once
#include "core/Common.h"
#include "sdk/GameSDK.h"

class Visuals {
public:
    static void Render(ImGuiIO& io);

private:
    static void DrawChamsSegment(const BonePoint& a, const BonePoint& b, float* color, float alpha, float jointRadius, int style, ImDrawList* dl, float sw, float sh);
    static void DrawFullSkeletonChams(const PlayerESPData& data, float* color, float alpha, float jointRadius, int style, ImDrawList* dl, float sw, float sh);
};
