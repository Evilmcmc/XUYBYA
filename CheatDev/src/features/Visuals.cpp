#include "features/Visuals.h"

static ImU32 MakeGlowColor(float* baseCol, float alphaMultiplier) {
    float a = baseCol[3] * alphaMultiplier;
    if (a > 1.0f) a = 1.0f;
    if (a < 0.0f) a = 0.0f;
    return ImGui::ColorConvertFloat4ToU32(ImVec4(baseCol[0], baseCol[1], baseCol[2], a));
}

void Visuals::DrawChamsSegment(const BonePoint& a, const BonePoint& b, float* color, float alpha, float jointRadius, int style, ImDrawList* dl, float sw, float sh) {
    if (!a.valid || !b.valid) return;

    ImVec2 p1(a.screen.x, sh - a.screen.y);
    ImVec2 p2(b.screen.x, sh - b.screen.y);

    if ((p1.x < -120.0f && p2.x < -120.0f) || (p1.x > sw + 120.0f && p2.x > sw + 120.0f) ||
        (p1.y < -120.0f && p2.y < -120.0f) || (p1.y > sh + 120.0f && p2.y > sh + 120.0f)) {
        return;
    }

    float radiusA  = (jointRadius * 80.0f / (a.screen.z + 1.0f));
    float radiusB  = (jointRadius * 80.0f / (b.screen.z + 1.0f));
    if (radiusA < 2.0f) radiusA = 2.0f;
    if (radiusA > 40.0f) radiusA = 40.0f;
    if (radiusB < 2.0f) radiusB = 2.0f;
    if (radiusB > 40.0f) radiusB = 40.0f;

    float effectiveAlpha = alpha;
    if (style == 3) {
        static float pulseTimer = 0.0f;
        pulseTimer += 0.02f;
        effectiveAlpha *= (0.60f + 0.40f * sinf(pulseTimer * 3.0f));
    }

    ImU32 fillCol   = ImGui::ColorConvertFloat4ToU32(ImVec4(color[0], color[1], color[2], effectiveAlpha));
    ImU32 borderCol = ImGui::ColorConvertFloat4ToU32(ImVec4(color[0] * 1.3f, color[1] * 1.3f, color[2] * 1.3f, 1.0f));

    float dx = p2.x - p1.x;
    float dy = p2.y - p1.y;
    float len = sqrtf(dx * dx + dy * dy);
    if (len < 0.001f) return;
    float nx = -dy / len;
    float ny =  dx / len;

    ImVec2 q1(p1.x + nx * radiusA, p1.y + ny * radiusA);
    ImVec2 q2(p1.x - nx * radiusA, p1.y - ny * radiusA);
    ImVec2 q3(p2.x - nx * radiusB, p2.y - ny * radiusB);
    ImVec2 q4(p2.x + nx * radiusB, p2.y + ny * radiusB);

    if (style == 0 || style == 1 || style == 3) {
        dl->AddQuadFilled(q1, q2, q3, q4, fillCol);
        dl->AddCircleFilled(p1, radiusA, fillCol);
        dl->AddCircleFilled(p2, radiusB, fillCol);
    }

    if (style == 2 || style == 3 || style == 1) {
        float borderThick = (style == 2) ? 2.0f : 1.2f;
        dl->AddQuad(q1, q2, q3, q4, borderCol, borderThick);
        dl->AddCircle(p1, radiusA, borderCol, 0, borderThick);
        dl->AddCircle(p2, radiusB, borderCol, 0, borderThick);
    }
}

void Visuals::DrawFullSkeletonChams(const PlayerESPData& data, float* color, float alpha, float jointRadius, int style, ImDrawList* dl, float sw, float sh) {
    DrawChamsSegment(data.head,      data.chest,     color, alpha, jointRadius * 1.3f, style, dl, sw, sh);
    DrawChamsSegment(data.chest,     data.spine,     color, alpha, jointRadius * 1.1f, style, dl, sw, sh);
    DrawChamsSegment(data.spine,     data.root,      color, alpha, jointRadius * 1.0f, style, dl, sw, sh);
    DrawChamsSegment(data.chest,     data.lShoulder, color, alpha, jointRadius * 0.9f, style, dl, sw, sh);
    DrawChamsSegment(data.lShoulder, data.lUpperArm, color, alpha, jointRadius * 0.8f, style, dl, sw, sh);
    DrawChamsSegment(data.lUpperArm, data.lElbow,    color, alpha, jointRadius * 0.8f, style, dl, sw, sh);
    DrawChamsSegment(data.lElbow,    data.lHand,     color, alpha, jointRadius * 0.7f, style, dl, sw, sh);
    DrawChamsSegment(data.chest,     data.rShoulder, color, alpha, jointRadius * 0.9f, style, dl, sw, sh);
    DrawChamsSegment(data.rShoulder, data.rUpperArm, color, alpha, jointRadius * 0.8f, style, dl, sw, sh);
    DrawChamsSegment(data.rUpperArm, data.rElbow,    color, alpha, jointRadius * 0.8f, style, dl, sw, sh);
    DrawChamsSegment(data.rElbow,    data.rHand,     color, alpha, jointRadius * 0.7f, style, dl, sw, sh);
    DrawChamsSegment(data.root,      data.lKnee,     color, alpha, jointRadius * 0.9f, style, dl, sw, sh);
    DrawChamsSegment(data.lKnee,     data.lFoot,     color, alpha, jointRadius * 0.8f, style, dl, sw, sh);
    DrawChamsSegment(data.root,      data.rKnee,     color, alpha, jointRadius * 0.9f, style, dl, sw, sh);
    DrawChamsSegment(data.rKnee,     data.rFoot,     color, alpha, jointRadius * 0.8f, style, dl, sw, sh);
}

void Visuals::Render(ImGuiIO& io) {
    if (!bEnableESP && !bEnableChams && !bDrawAimbotFOV && !bDrawSilentAimFOV) return;

    auto* dl = ImGui::GetBackgroundDrawList();
    float sw = io.DisplaySize.x;
    float sh = io.DisplaySize.y;
    float cx = sw * 0.5f;
    float cy = sh * 0.5f;

    auto DrawBoneLine = [&](const BonePoint& a, const BonePoint& b, float* baseCol, float thick) {
        if (a.valid && b.valid) {
            ImVec2 p1(a.screen.x, sh - a.screen.y);
            ImVec2 p2(b.screen.x, sh - b.screen.y);

            if ((p1.x < -100.0f && p2.x < -100.0f) || (p1.x > sw + 100.0f && p2.x > sw + 100.0f) ||
                (p1.y < -100.0f && p2.y < -100.0f) || (p1.y > sh + 100.0f && p2.y > sh + 100.0f)) {
                return;
            }

            if (bEnableGlow) {
                ImU32 glowColOuter = MakeGlowColor(baseCol, 0.18f * fGlowIntensity);
                ImU32 glowColMid   = MakeGlowColor(baseCol, 0.35f * fGlowIntensity);
                dl->AddLine(p1, p2, glowColOuter, thick + 4.0f);
                dl->AddLine(p1, p2, glowColMid,   thick + 2.0f);
            }

            ImU32 coreCol = MakeGlowColor(baseCol, 1.0f);
            dl->AddLine(p1, p2, coreCol, thick);
        }
    };

    if (bEnableAimbot && bDrawAimbotFOV && aimbotFOV > 0.0f) {
        dl->AddCircle(ImVec2(cx, cy), aimbotFOV, IM_COL32(0, 230, 255, 120), 64, 1.5f);
        if (bEnableGlow) {
            dl->AddCircle(ImVec2(cx, cy), aimbotFOV, IM_COL32(0, 230, 255, 35), 64, 4.0f);
        }
    }

    if (bEnableSilentAim && bDrawSilentAimFOV && !bSilentAimFull360 && fSilentAimFOV > 0.0f) {
        dl->AddCircle(ImVec2(cx, cy), fSilentAimFOV, IM_COL32(255, 80, 120, 140), 64, 1.5f);
        if (bEnableGlow) {
            dl->AddCircle(ImVec2(cx, cy), fSilentAimFOV, IM_COL32(255, 80, 120, 40), 64, 4.0f);
        }
    }

    for (const auto& data : g_ESPData) {
        float* primaryCol = data.isEnemy ? colEnemy : colTeam;

        // Chams
        if (bEnableChams) {
            float* chamsCol = data.isEnemy ? colChamsEnemyVis : colChamsTeamVis;
            DrawFullSkeletonChams(data, chamsCol, fChamsAlpha, fChamsJointSize, iChamsStyle, dl, sw, sh);
        }

        if (!bEnableESP) continue;

        // Skeleton
        if (bDrawSkeleton) {
            DrawBoneLine(data.head,      data.chest,     colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.chest,     data.spine,     colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.spine,     data.root,      colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.chest,     data.lShoulder, colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.lShoulder, data.lUpperArm, colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.lUpperArm, data.lElbow,    colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.lElbow,    data.lHand,     colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.chest,     data.rShoulder, colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.rShoulder, data.rUpperArm, colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.rUpperArm, data.rElbow,    colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.rElbow,    data.rHand,     colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.root,      data.lKnee,     colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.lKnee,     data.lFoot,     colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.root,      data.rKnee,     colSkeleton, fSkeletonThickness);
            DrawBoneLine(data.rKnee,     data.rFoot,     colSkeleton, fSkeletonThickness);
        }

        // Head Circle
        if (bDrawHeadCircle && data.head.valid) {
            ImVec2 headCenter(data.head.screen.x, sh - data.head.screen.y);
            float radius = (18.0f * fHeadCircleSize) / (data.head.screen.z + 1.0f);
            if (radius < 2.5f)  radius = 2.5f;
            if (radius > 45.0f) radius = 45.0f;

            if (bEnableGlow) {
                ImU32 glowColOuter = MakeGlowColor(colHeadCircle, 0.20f * fGlowIntensity);
                ImU32 glowColMid   = MakeGlowColor(colHeadCircle, 0.40f * fGlowIntensity);
                dl->AddCircle(headCenter, radius, glowColOuter, 32, fSkeletonThickness + 4.0f);
                dl->AddCircle(headCenter, radius, glowColMid,   32, fSkeletonThickness + 2.0f);
            }
            ImU32 coreCol = MakeGlowColor(colHeadCircle, 1.0f);
            dl->AddCircle(headCenter, radius, coreCol, 32, fSkeletonThickness);
        }

        // 2D Bounding Boxes
        if (bDrawBoxes && data.hasBox) {
            ImVec2 bMin(data.boxMinX, sh - data.boxMaxY);
            ImVec2 bMax(data.boxMaxX, sh - data.boxMinY);

            if (bEnableGlow) {
                ImU32 glowColOuter = MakeGlowColor(primaryCol, 0.15f * fGlowIntensity);
                ImU32 glowColMid   = MakeGlowColor(primaryCol, 0.30f * fGlowIntensity);
                dl->AddRect(bMin, bMax, glowColOuter, 2.0f, 0, fBoxThickness + 4.0f);
                dl->AddRect(bMin, bMax, glowColMid,   2.0f, 0, fBoxThickness + 2.0f);
            }
            ImU32 coreCol = MakeGlowColor(primaryCol, 1.0f);
            dl->AddRect(bMin, bMax, coreCol, 2.0f, 0, fBoxThickness);
        }

        // Tracers
        if (bDrawTracers && (data.root.valid || data.chest.valid)) {
            const BonePoint& targetBone = data.root.valid ? data.root : data.chest;
            ImVec2 startPos;
            if (iTracerOrigin == 0)      startPos = ImVec2(cx, sh);
            else if (iTracerOrigin == 1) startPos = ImVec2(cx, cy);
            else                         startPos = ImVec2(cx, 0.0f);

            ImVec2 endPos(targetBone.screen.x, sh - targetBone.screen.y);

            if (bEnableGlow) {
                ImU32 glowColOuter = MakeGlowColor(colTracers, 0.15f * fGlowIntensity);
                ImU32 glowColMid   = MakeGlowColor(colTracers, 0.30f * fGlowIntensity);
                dl->AddLine(startPos, endPos, glowColOuter, fTracerThickness + 3.0f);
                dl->AddLine(startPos, endPos, glowColMid,   fTracerThickness + 1.5f);
            }
            ImU32 coreCol = MakeGlowColor(colTracers, 0.85f);
            dl->AddLine(startPos, endPos, coreCol, fTracerThickness);
        }

        // Health Bar & Info Text
        if ((bDrawHealthBar || bDrawInfoText) && data.hasBox) {
            float boxH = (data.boxMaxY - data.boxMinY);
            float boxTopY = sh - data.boxMaxY;

            if (bDrawHealthBar) {
                float barW = 4.0f;
                float barX = data.boxMinX - barW - 3.0f;
                float hpRatio = (data.maxHp > 0) ? ((float)data.hp / (float)data.maxHp) : 1.0f;
                if (hpRatio < 0.0f) hpRatio = 0.0f;
                if (hpRatio > 1.0f) hpRatio = 1.0f;

                ImU32 barBg = IM_COL32(20, 20, 25, 200);
                dl->AddRectFilled(ImVec2(barX, boxTopY), ImVec2(barX + barW, boxTopY + boxH), barBg);

                ImU32 hpColor;
                if (hpRatio > 0.60f)      hpColor = IM_COL32(50, 220, 90, 255);
                else if (hpRatio > 0.25f) hpColor = IM_COL32(240, 180, 30, 255);
                else                      hpColor = IM_COL32(240, 45, 45, 255);

                float filledH = boxH * hpRatio;
                dl->AddRectFilled(ImVec2(barX, boxTopY + (boxH - filledH)), ImVec2(barX + barW, boxTopY + boxH), hpColor);
            }

            if (bDrawInfoText) {
                char textBuf[128];
                const char* uname = (!data.username.empty()) ? data.username.c_str() : (data.isEnemy ? "ENEMY" : "TEAM");
                snprintf(textBuf, sizeof(textBuf), "%s | %dm | %d HP",
                         uname,
                         (int)data.distance, data.hp);

                ImVec2 textSize = ImGui::CalcTextSize(textBuf);
                float textX = data.boxMinX + ((data.boxMaxX - data.boxMinX) - textSize.x) * 0.5f;
                float textY = boxTopY - textSize.y - 3.0f;

                dl->AddRectFilled(ImVec2(textX - 4.0f, textY - 2.0f),
                                  ImVec2(textX + textSize.x + 4.0f, textY + textSize.y + 2.0f),
                                  IM_COL32(10, 12, 18, 200), 3.0f);

                dl->AddText(ImVec2(textX, textY), MakeGlowColor(primaryCol, 1.0f), textBuf);
            }
        }
    }
}
