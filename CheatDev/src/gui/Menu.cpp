#include "gui/Menu.h"
#include "features/Visuals.h"
#include "features/Combat.h"
#include "features/Exploits.h"
#include "core/Config.h"
#include "sdk/GameSDK.h"

// ─── Custom Styled Material Navigation Pill Button ───────────────────────────
static bool DrawMaterialNavButton(const char* label, bool active, const char* icon = nullptr) {
    ImGui::PushID(label);
    if (active) {
        ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.18f, 0.32f, 0.56f, 0.95f));
        ImGui::PushStyleColor(ImGuiCol_ButtonHovered, ImVec4(0.24f, 0.40f, 0.68f, 1.0f));
        ImGui::PushStyleColor(ImGuiCol_ButtonActive, ImVec4(0.15f, 0.28f, 0.50f, 1.0f));
        ImGui::PushStyleColor(ImGuiCol_Text, ImVec4(1.0f, 1.0f, 1.0f, 1.0f));
    } else {
        ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.10f, 0.11f, 0.16f, 0.70f));
        ImGui::PushStyleColor(ImGuiCol_ButtonHovered, ImVec4(0.15f, 0.18f, 0.26f, 0.95f));
        ImGui::PushStyleColor(ImGuiCol_ButtonActive, ImVec4(0.12f, 0.14f, 0.20f, 1.0f));
        ImGui::PushStyleColor(ImGuiCol_Text, ImVec4(0.75f, 0.78f, 0.86f, 1.0f));
    }

    char displayBuf[128];
    if (icon && icon[0]) {
        snprintf(displayBuf, sizeof(displayBuf), "  %s  %s", icon, label);
    } else {
        snprintf(displayBuf, sizeof(displayBuf), "    %s", label);
    }

    bool clicked = ImGui::Button(displayBuf, ImVec2(-1, 38));
    ImGui::PopStyleColor(4);
    ImGui::PopID();
    return clicked;
}

void Menu::InitializeTheme() {
    ImGuiStyle& style = ImGui::GetStyle();
    
    style.WindowRounding    = 14.0f;
    style.ChildRounding     = 10.0f;
    style.FrameRounding     = 8.0f;
    style.PopupRounding     = 10.0f;
    style.ScrollbarRounding = 8.0f;
    style.GrabRounding      = 6.0f;
    style.TabRounding       = 8.0f;

    style.WindowBorderSize  = 1.0f;
    style.FrameBorderSize   = 1.0f;
    style.PopupBorderSize   = 1.0f;

    style.WindowPadding     = ImVec2(18.0f, 18.0f);
    style.FramePadding      = ImVec2(10.0f, 7.0f);
    style.ItemSpacing       = ImVec2(10.0f, 10.0f);
    style.ItemInnerSpacing  = ImVec2(8.0f, 6.0f);

    ImVec4* colors = style.Colors;
    colors[ImGuiCol_WindowBg]              = ImVec4(0.06f, 0.07f, 0.09f, 0.96f);
    colors[ImGuiCol_ChildBg]               = ImVec4(0.09f, 0.10f, 0.13f, 0.80f);
    colors[ImGuiCol_PopupBg]               = ImVec4(0.08f, 0.09f, 0.12f, 0.98f);
    colors[ImGuiCol_Border]                = ImVec4(0.18f, 0.20f, 0.26f, 0.65f);
    colors[ImGuiCol_BorderShadow]          = ImVec4(0.00f, 0.00f, 0.00f, 0.00f);

    colors[ImGuiCol_Text]                  = ImVec4(0.92f, 0.94f, 0.98f, 1.00f);
    colors[ImGuiCol_TextDisabled]          = ImVec4(0.48f, 0.52f, 0.60f, 1.00f);

    colors[ImGuiCol_FrameBg]               = ImVec4(0.12f, 0.14f, 0.19f, 0.90f);
    colors[ImGuiCol_FrameBgHovered]        = ImVec4(0.18f, 0.22f, 0.30f, 1.00f);
    colors[ImGuiCol_FrameBgActive]         = ImVec4(0.22f, 0.26f, 0.36f, 1.00f);

    colors[ImGuiCol_TitleBg]               = ImVec4(0.07f, 0.08f, 0.10f, 1.00f);
    colors[ImGuiCol_TitleBgActive]         = ImVec4(0.08f, 0.09f, 0.12f, 1.00f);
    colors[ImGuiCol_TitleBgCollapsed]      = ImVec4(0.07f, 0.08f, 0.10f, 0.80f);
    colors[ImGuiCol_MenuBarBg]             = ImVec4(0.09f, 0.10f, 0.13f, 1.00f);

    colors[ImGuiCol_ScrollbarBg]           = ImVec4(0.07f, 0.08f, 0.10f, 0.50f);
    colors[ImGuiCol_ScrollbarGrab]         = ImVec4(0.18f, 0.21f, 0.28f, 1.00f);
    colors[ImGuiCol_ScrollbarGrabHovered]  = ImVec4(0.25f, 0.30f, 0.40f, 1.00f);
    colors[ImGuiCol_ScrollbarGrabActive]   = ImVec4(0.30f, 0.55f, 1.00f, 1.00f);

    colors[ImGuiCol_CheckMark]             = ImVec4(0.30f, 0.55f, 1.00f, 1.00f);
    colors[ImGuiCol_SliderGrab]            = ImVec4(0.30f, 0.55f, 1.00f, 1.00f);
    colors[ImGuiCol_SliderGrabActive]      = ImVec4(0.48f, 0.70f, 1.00f, 1.00f);

    colors[ImGuiCol_Button]                = ImVec4(0.14f, 0.16f, 0.22f, 0.90f);
    colors[ImGuiCol_ButtonHovered]         = ImVec4(0.20f, 0.35f, 0.60f, 0.95f);
    colors[ImGuiCol_ButtonActive]          = ImVec4(0.16f, 0.28f, 0.50f, 1.00f);

    colors[ImGuiCol_Header]                = ImVec4(0.16f, 0.25f, 0.40f, 0.75f);
    colors[ImGuiCol_HeaderHovered]         = ImVec4(0.20f, 0.32f, 0.52f, 0.90f);
    colors[ImGuiCol_HeaderActive]          = ImVec4(0.25f, 0.40f, 0.65f, 1.00f);

    colors[ImGuiCol_Separator]             = ImVec4(0.18f, 0.20f, 0.27f, 0.70f);
    colors[ImGuiCol_SeparatorHovered]      = ImVec4(0.30f, 0.55f, 1.00f, 0.60f);
    colors[ImGuiCol_SeparatorActive]       = ImVec4(0.30f, 0.55f, 1.00f, 1.00f);

    colors[ImGuiCol_ResizeGrip]            = ImVec4(0.18f, 0.20f, 0.27f, 0.40f);
    colors[ImGuiCol_ResizeGripHovered]     = ImVec4(0.30f, 0.55f, 1.00f, 0.70f);
    colors[ImGuiCol_ResizeGripActive]      = ImVec4(0.30f, 0.55f, 1.00f, 1.00f);

    colors[ImGuiCol_Tab]                   = ImVec4(0.09f, 0.10f, 0.14f, 1.00f);
    colors[ImGuiCol_TabHovered]            = ImVec4(0.20f, 0.35f, 0.60f, 0.60f);
    colors[ImGuiCol_TabActive]             = ImVec4(0.18f, 0.32f, 0.55f, 0.90f);
    colors[ImGuiCol_TabUnfocused]          = ImVec4(0.08f, 0.09f, 0.12f, 1.00f);
    colors[ImGuiCol_TabUnfocusedActive]    = ImVec4(0.12f, 0.14f, 0.20f, 1.00f);
}

void Menu::Render() {
    if (!g_ShowMenu) return;

    ImGuiIO& io = ImGui::GetIO();

    // Direct hardware mouse position & button sync — bypasses Unity's cursor lock
    POINT pt;
    if (GetCursorPos(&pt) && ScreenToClient(g_hWnd, &pt)) {
        io.AddMousePosEvent((float)pt.x, (float)pt.y);
    }
    io.AddMouseButtonEvent(0, (GetAsyncKeyState(VK_LBUTTON) & 0x8000) != 0);
    io.AddMouseButtonEvent(1, (GetAsyncKeyState(VK_RBUTTON) & 0x8000) != 0);

    ImGui::SetNextWindowSize(ImVec2(1160.0f, 750.0f), ImGuiCond_FirstUseEver);
    ImGui::SetNextWindowPos(
        ImVec2(io.DisplaySize.x * 0.5f, io.DisplaySize.y * 0.5f),
        ImGuiCond_FirstUseEver,
        ImVec2(0.5f, 0.5f)
    );

    ImGuiWindowFlags winFlags = ImGuiWindowFlags_NoCollapse | ImGuiWindowFlags_NoTitleBar;
    ImGui::Begin("MATERIAL_MAIN_WINDOW", &g_ShowMenu, winFlags);

    // ── TOP MATERIAL APP BAR ──
    ImGui::BeginChild("TopNavBar", ImVec2(0, 52), false, ImGuiWindowFlags_NoScrollbar);
    {
        ImGui::SetCursorPosY(ImGui::GetCursorPosY() + 5.0f);
        ImGui::TextColored(ImVec4(0.35f, 0.65f, 1.00f, 1.0f), "MIDNIGHT");
        ImGui::SameLine();
        ImGui::TextDisabled("|");
        ImGui::SameLine();

        const char* navTabs[] = {
            "  [>] COMBAT  ",
            "  [o] VISUALS & CHAMS  ",
            "  [~] WEAPONS  ",
            "  [X] EXPLOITS  ",
            "  [*] COLORS  ",
            "  [!] LOGS & ENGINE  "
        };

        for (int t = 0; t < IM_ARRAYSIZE(navTabs); t++) {
            bool isActive = (iTopNavTab == t);
            if (isActive) {
                ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.18f, 0.32f, 0.56f, 0.95f));
                ImGui::PushStyleColor(ImGuiCol_Text, ImVec4(1.0f, 1.0f, 1.0f, 1.0f));
            } else {
                ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.10f, 0.11f, 0.16f, 0.65f));
                ImGui::PushStyleColor(ImGuiCol_Text, ImVec4(0.72f, 0.76f, 0.85f, 1.0f));
            }

            if (ImGui::Button(navTabs[t], ImVec2(0, 32))) {
                iTopNavTab = t;
            }
            ImGui::PopStyleColor(2);

            if (t < IM_ARRAYSIZE(navTabs) - 1) {
                ImGui::SameLine(0, 6.0f);
            }
        }

        ImGui::SameLine(ImGui::GetWindowWidth() - 210.0f);
        ImGui::SetCursorPosY(ImGui::GetCursorPosY() + 4.0f);
        ImGui::TextColored(ImVec4(0.20f, 0.85f, 0.40f, 1.0f), "[*] ACTIVE (%.0f FPS)", io.Framerate);
    }
    ImGui::EndChild();

    ImGui::Separator();
    ImGui::Spacing();

    // ── LEFT NAVIGATION SIDEBAR ──
    ImGui::BeginChild("Sidebar", ImVec2(240, 0), true);
    {
        ImGui::TextColored(ImVec4(0.35f, 0.65f, 1.00f, 1.0f), "QUICK SWITCHES");
        ImGui::Separator();
        ImGui::Spacing();

        ImGui::Checkbox("Silent Aim",     &bEnableSilentAim);
        ImGui::Checkbox("Smooth Aimbot",  &bEnableAimbot);
        ImGui::Checkbox("Player ESP",     &bEnableESP);
        ImGui::Checkbox("Player Chams",   &bEnableChams);
        ImGui::Checkbox("Infinite Ammo",  &bInfiniteAmmo);
        ImGui::Checkbox("99,999 Damage",  &bOneHitKillDamage);
        ImGui::Checkbox("Teleport Kill",  &bEnableTeleportKill);
        ImGui::Checkbox("Mass Kill Aura", &bEnableMassKill);
        ImGui::Checkbox("God Mode",       &bGodMode);
        ImGui::Checkbox("Noclip Fly",     &bNoClip);
        ImGui::Checkbox("Anti-Knockback", &bAntiKnockback);
        ImGui::Checkbox("Ultra FPS Boost",&bFpsBoostUltra);

        ImGui::Spacing();
        ImGui::Separator();
        ImGui::Spacing();

        ImGui::TextColored(ImVec4(0.35f, 0.65f, 1.00f, 1.0f), "MODULE SHORTCUTS");
        ImGui::Spacing();

        if (DrawMaterialNavButton("Silent Aim & Combat", iTopNavTab == 0, "[>]")) iTopNavTab = 0;
        if (DrawMaterialNavButton("ESP & Chams",        iTopNavTab == 1, "[o]")) iTopNavTab = 1;
        if (DrawMaterialNavButton("Weapon Spawner",     iTopNavTab == 2, "[~]")) iTopNavTab = 2;
        if (DrawMaterialNavButton("Exploits & Teleport",iTopNavTab == 3, "[X]")) iTopNavTab = 3;
        if (DrawMaterialNavButton("Colors & Palette",   iTopNavTab == 4, "[*]")) iTopNavTab = 4;
        if (DrawMaterialNavButton("Game Engine Logs",   iTopNavTab == 5, "[!]")) iTopNavTab = 5;

        ImGui::Spacing();
        ImGui::Separator();
        ImGui::Spacing();

        ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.20f, 0.45f, 0.85f, 0.90f));
        ImGui::PushStyleColor(ImGuiCol_ButtonHovered, ImVec4(0.30f, 0.60f, 1.00f, 1.0f));
        ImGui::PushStyleColor(ImGuiCol_ButtonActive, ImVec4(0.15f, 0.35f, 0.75f, 1.0f));
        if (ImGui::Button("⚡ LOAD HVH RAGE PRESET", ImVec2(-1, 38))) {
            Config::LoadHvHPreset();
        }
        ImGui::PopStyleColor(3);

        ImGui::Spacing();

        ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.55f, 0.12f, 0.12f, 0.85f));
        ImGui::PushStyleColor(ImGuiCol_ButtonHovered, ImVec4(0.80f, 0.18f, 0.18f, 1.0f));
        ImGui::PushStyleColor(ImGuiCol_ButtonActive, ImVec4(0.40f, 0.08f, 0.08f, 1.0f));
        if (ImGui::Button("UNINJECT CHEAT", ImVec2(-1, 38))) {
            g_Uninjecting = true;
        }
        ImGui::PopStyleColor(3);
    }
    ImGui::EndChild();

    ImGui::SameLine();

    // ── MAIN CONTENT AREA ──
    ImGui::BeginChild("MainContent", ImVec2(0, 0), false);
    {
        float halfWidth = (ImGui::GetContentRegionAvail().x - 12.0f) * 0.5f;

        // TAB 0: COMBAT
        if (iTopNavTab == 0) {
            ImGui::BeginChild("CardSilentAim", ImVec2(halfWidth, 440), true);
            {
                ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "%s", "Silent Aim (100% Hit Any Shot)");
                ImGui::SameLine(ImGui::GetWindowWidth() - 95.0f);
                ImGui::TextColored(bEnableSilentAim ? ImVec4(0.30f, 0.85f, 0.50f, 1.0f) : ImVec4(0.5f, 0.5f, 0.5f, 1.0f),
                                   bEnableSilentAim ? "[ACTIVE]" : "[OFF]");
                ImGui::Separator();
                ImGui::Spacing();

                ImGui::Checkbox("Enable Silent Aim", &bEnableSilentAim);
                ImGui::Checkbox("Full 360° Hit (Anywhere on Map)", &bSilentAimFull360);
                ImGui::Checkbox("Draw Silent Aim FOV Circle", &bDrawSilentAimFOV);
                ImGui::Spacing();

                const char* targetBones[] = { "Chest / Torso", "Head", "Root / Pelvis" };
                ImGui::Combo("Target Hit Bone", &iSilentAimTarget, targetBones, IM_ARRAYSIZE(targetBones));
                ImGui::Spacing();

                if (!bSilentAimFull360) {
                    ImGui::SliderFloat("Silent Aim FOV", &fSilentAimFOV, 20.0f, 800.0f, "%.0f px");
                }

                ImGui::Spacing();
                ImGui::Separator();
                ImGui::Spacing();

                ImGui::TextColored(ImVec4(0.35f, 0.65f, 1.00f, 1.0f), "Silent Aim Mechanics:");
                ImGui::BulletText("Directly reroutes weapon raycasts in CMDShoot.");
                ImGui::BulletText("Bullets hit the target instantly regardless of crosshair pos.");
            }
            ImGui::EndChild();

            ImGui::SameLine();

            ImGui::BeginChild("CardAimbot", ImVec2(halfWidth, 440), true);
            {
                ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Smooth Aimbot & RCS");
                ImGui::SameLine(ImGui::GetWindowWidth() - 95.0f);
                ImGui::TextColored(bEnableAimbot ? ImVec4(0.30f, 0.85f, 0.50f, 1.0f) : ImVec4(0.5f, 0.5f, 0.5f, 1.0f),
                                   bEnableAimbot ? "[ACTIVE]" : "[OFF]");
                ImGui::Separator();
                ImGui::Spacing();

                ImGui::Checkbox("Enable Smooth Aimbot", &bEnableAimbot);
                ImGui::Checkbox("Auto-fire on Target Lock", &bAimbotAutoFire);
                ImGui::Checkbox("Draw Aimbot FOV circle", &bDrawAimbotFOV);
                ImGui::Combo("Aimbot Hotkey", &iAimbotKey, g_KeyNames, IM_ARRAYSIZE(g_KeyNames));

                ImGui::SliderFloat("FOV Radius", &aimbotFOV, 20.0f, 500.0f, "%.1f px");
                ImGui::SliderFloat("Smoothing",  &aimbotSmooth, 1.0f, 25.0f, "%.1f");

                ImGui::Spacing();
                ImGui::Separator();
                ImGui::Spacing();

                ImGui::Checkbox("Triggerbot (Auto Shoot Crosshair)", &bTriggerbot);
                if (bTriggerbot) {
                    ImGui::Checkbox("Head Only", &bTriggerbotHeadOnly);
                    ImGui::SliderFloat("Trigger Delay", &fTriggerbotDelay, 0.01f, 0.30f, "%.2f s");
                }
            }
            ImGui::EndChild();
        }

        // TAB 1: VISUALS
        else if (iTopNavTab == 1) {
            ImGui::BeginChild("CardESP", ImVec2(halfWidth, 0), true);
            {
                ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Player Visuals (ESP)");
                ImGui::Separator();
                ImGui::Spacing();

                ImGui::Checkbox("Enable Player ESP", &bEnableESP);
                ImGui::Checkbox("2D Bounding Boxes", &bDrawBoxes);
                ImGui::Checkbox("Full Bone Skeletons", &bDrawSkeleton);
                ImGui::Checkbox("Head Hitbox Circle", &bDrawHeadCircle);
                ImGui::Checkbox("Snaplines / Tracers", &bDrawTracers);
                ImGui::Combo("Tracer Origin", &iTracerOrigin, "Screen Bottom\0Screen Center (Crosshair)\0Screen Top\0\0");
                ImGui::Checkbox("Dynamic Health Bars", &bDrawHealthBar);
                ImGui::Checkbox("Player Info & Distance Text", &bDrawInfoText);

                ImGui::Spacing();
                ImGui::Separator();
                ImGui::Spacing();

                ImGui::Checkbox("Glow / Neon Bloom FX", &bEnableGlow);
                if (bEnableGlow) {
                    ImGui::SliderFloat("Glow Intensity", &fGlowIntensity, 0.5f, 3.0f, "%.1fx");
                }

                ImGui::SliderFloat("Max ESP Distance", &fMaxDistance, 50.0f, 1500.0f, "%.0f m");
                ImGui::Checkbox("Hide Teammates (Enemies Only)", &bIgnoreTeammates);
                ImGui::Checkbox("Hide Dead Players", &bIgnoreDead);
            }
            ImGui::EndChild();

            ImGui::SameLine();

            ImGui::BeginChild("CardChams", ImVec2(halfWidth, 0), true);
            {
                ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Player Chams & Wallhacks");
                ImGui::Separator();
                ImGui::Spacing();

                ImGui::Checkbox("Enable Player Chams", &bEnableChams);
                const char* chamsStyles[] = { "Solid Fill", "Glass Translucent", "Wireframe Skeleton", "Neon Pulse" };
                ImGui::Combo("Chams Material Style", &iChamsStyle, chamsStyles, IM_ARRAYSIZE(chamsStyles));
                ImGui::SliderFloat("Chams Opacity", &fChamsAlpha, 0.1f, 1.0f, "%.2f");
                ImGui::SliderFloat("Joint Bone Radius", &fChamsJointSize, 0.4f, 3.0f, "%.2fx");
            }
            ImGui::EndChild();
        }

        // TAB 2: WEAPONS
        else if (iTopNavTab == 2) {
            ImGui::BeginChild("CardSpawner", ImVec2(halfWidth, 0), true);
            {
                ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Instant Weapon Spawner (Server-Synced)");
                ImGui::Separator();
                ImGui::Spacing();

                ImGui::Combo("Select Weapon", &iSelectedWeaponIndex, Exploits::WeaponNames, IM_ARRAYSIZE(Exploits::WeaponNames));
                ImGui::Spacing();

                if (ImGui::Button("EQUIP SELECTED WEAPON NOW", ImVec2(-1, 46))) {
                    Exploits::GiveWeapon(iSelectedWeaponIndex);
                }

                ImGui::Spacing();
                ImGui::Separator();
                ImGui::Spacing();

                ImGui::TextDisabled("Quick Equip Grid:");
                ImGui::Spacing();

                for (int w = 0; w < IM_ARRAYSIZE(Exploits::WeaponNames); w++) {
                    char btnLabel[64];
                    snprintf(btnLabel, sizeof(btnLabel), "Equip %s", Exploits::WeaponNames[w]);
                    if (ImGui::Button(btnLabel, ImVec2(-1, 32))) {
                        iSelectedWeaponIndex = w;
                        Exploits::GiveWeapon(w);
                    }
                    ImGui::Spacing();
                }
            }
            ImGui::EndChild();

            ImGui::SameLine();

            ImGui::BeginChild("CardMods", ImVec2(halfWidth, 0), true);
            {
                ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Weapon Power Overrides");
                ImGui::Separator();
                ImGui::Spacing();

                ImGui::Checkbox("Infinite Ammo (99,999 in Clip)", &bInfiniteAmmo);
                ImGui::Checkbox("One-Hit Kill Damage (99,999 DMG)", &bOneHitKillDamage);
                ImGui::Checkbox("Rapid Fire Rate (Instant Firing)", &bRapidFire);
                ImGui::Checkbox("Infinite Range (9,999m)", &bInfiniteRange);
            }
            ImGui::EndChild();
        }

        // TAB 3: EXPLOITS
        else if (iTopNavTab == 3) {
            ImGui::BeginChild("CardMovementExploits", ImVec2(halfWidth, 310), true);
            {
                ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Movement & Physics Exploits");
                ImGui::Separator();
                ImGui::Spacing();

                ImGui::Checkbox("Speedhack Multiplier", &bEnableSpeedhack);
                if (bEnableSpeedhack) {
                    ImGui::SliderFloat("Speed Factor", &fSpeedMultiplier, 1.2f, 8.0f, "%.1fx");
                }
                ImGui::Spacing();

                ImGui::Checkbox("Super High Jump", &bEnableSuperJump);
                if (bEnableSuperJump) {
                    ImGui::SliderFloat("Jump Force", &fJumpMultiplier, 1.2f, 6.0f, "%.1fx");
                }
                ImGui::Spacing();

                ImGui::Checkbox("Noclip Fly (WASD + Space/Ctrl)", &bNoClip);
                if (bNoClip) {
                    ImGui::SliderFloat("Noclip Speed", &fNoClipSpeed, 0.5f, 6.0f, "%.1fx");
                }
                ImGui::Spacing();

                ImGui::Checkbox("Anti-Knockback (Immune to pulls/explosions)", &bAntiKnockback);
                ImGui::Checkbox("Zero Gravity (Float / Moon Physics)", &bZeroGravity);
                if (!bZeroGravity) {
                    ImGui::SliderFloat("Gravity Scale", &fGravityMultiplier, 0.1f, 3.0f, "%.2fx");
                }
            }
            ImGui::EndChild();

            ImGui::SameLine();

            ImGui::BeginChild("CardGrappleExploits", ImVec2(halfWidth, 310), true);
            {
                ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Grappling Hook Exploits");
                ImGui::Separator();
                ImGui::Spacing();

                ImGui::Checkbox("Infinite Grapple Range (9,999m)", &bInfiniteGrappleRange);
                ImGui::Checkbox("Super Grapple Reel Speed", &bSuperGrappleSpeed);
                if (bSuperGrappleSpeed) {
                    ImGui::SliderFloat("Pull Speed Factor", &fGrappleSpeedMult, 1.5f, 8.0f, "%.1fx");
                }
            }
            ImGui::EndChild();

            ImGui::Spacing();

            ImGui::BeginChild("CardTeleportKill", ImVec2(halfWidth, 340), true);
            {
                ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Teleport Kill & Target Cycler");
                ImGui::Separator();
                ImGui::Spacing();

                ImGui::Checkbox("Enable Teleport Kill", &bEnableTeleportKill);
                ImGui::Checkbox("Hold Hotkey Only", &bTeleportHoldKey);
                if (bTeleportHoldKey) {
                    ImGui::Combo("Teleport Key", &iTeleportKey, g_KeyNames, IM_ARRAYSIZE(g_KeyNames));
                }

                const char* targetModes[] = { "Random / Auto-Cycle Server", "Closest Distance", "Lowest HP First" };
                ImGui::Combo("Target Mode", &iTeleportTargetMode, targetModes, IM_ARRAYSIZE(targetModes));

                const char* posModes[] = { "Behind Enemy (Backstab)", "Above Enemy", "In Front", "Directly on Target" };
                ImGui::Combo("Teleport Position", &iTeleportPosition, posModes, IM_ARRAYSIZE(posModes));

                ImGui::SliderFloat("Distance Offset", &fTeleportDistance, 0.2f, 5.0f, "%.1f m");
                ImGui::SliderFloat("Height Offset",   &fTeleportHeight,   -1.0f, 3.0f, "%.1f m");
                ImGui::Checkbox("Auto-Shoot on Teleport", &bTeleportAutoShoot);
            }
            ImGui::EndChild();

            ImGui::SameLine();

            ImGui::BeginChild("CardServerKill", ImVec2(halfWidth, 340), true);
            {
                ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Server & Map Destruction");
                ImGui::Separator();
                ImGui::Spacing();

                ImGui::Checkbox("Enable Mass Kill Aura", &bEnableMassKill);
                ImGui::SliderFloat("Kill Interval Rate", &fMassKillInterval, 20.0f, 500.0f, "%.0f ms");
                ImGui::Spacing();

                ImGui::Checkbox("Server RPC Flood (Crash)", &bServerCrashActive);
                ImGui::Checkbox("Map Destroyer (Continuous Explosions)", &bMapDestroyerActive);
                ImGui::Spacing();

                if (ImGui::Button("WIPE ENTIRE SERVER (MASS KILL)", ImVec2(-1, 34))) {
                    Combat::DoMassKill();
                }
                ImGui::Spacing();
                if (ImGui::Button("CRASH ALL PLAYERS (OUT OF BOUNDS)", ImVec2(-1, 34))) {
                    bCrashAllPlayersNow = true;
                }
            }
            ImGui::EndChild();
        }

        // TAB 4: COLORS
        else if (iTopNavTab == 4) {
            ImGui::BeginChild("CardColorPicker", ImVec2(halfWidth, 0), true);
            {
                ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Interactive Color Customization");
                ImGui::Separator();
                ImGui::Spacing();

                ImGuiColorEditFlags miniEditFlags = ImGuiColorEditFlags_AlphaBar | ImGuiColorEditFlags_AlphaPreviewHalf;
                ImGui::ColorEdit4("Enemy / Target",        colEnemy, miniEditFlags);
                ImGui::ColorEdit4("Teammate",              colTeam, miniEditFlags);
                ImGui::ColorEdit4("Skeleton Bones",        colSkeleton, miniEditFlags);
                ImGui::ColorEdit4("Snaplines / Tracers",   colTracers, miniEditFlags);
                ImGui::ColorEdit4("Head Hitbox",           colHeadCircle, miniEditFlags);
                ImGui::ColorEdit4("Chams Enemy (Visible)", colChamsEnemyVis, miniEditFlags);
                ImGui::ColorEdit4("Chams Enemy (Occluded)",colChamsEnemyOcc, miniEditFlags);
                ImGui::ColorEdit4("Chams Team (Visible)",  colChamsTeamVis, miniEditFlags);
                ImGui::ColorEdit4("Chams Team (Occluded)", colChamsTeamOcc, miniEditFlags);
            }
            ImGui::EndChild();

            ImGui::SameLine();

            ImGui::BeginChild("CardConfigControls", ImVec2(halfWidth, 0), true);
            {
                ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Configuration Profiles");
                ImGui::Separator();
                ImGui::Spacing();

                const char* status = Config::GetStatus();
                if (status[0] != '\0') {
                    ImGui::TextColored(ImVec4(0.35f, 0.65f, 1.00f, 1.0f), "%s", status);
                    ImGui::Spacing();
                }

                if (ImGui::Button("SAVE CONFIG TO DISK", ImVec2(-1, 36))) Config::Save();
                ImGui::Spacing();
                if (ImGui::Button("LOAD CONFIG FROM DISK", ImVec2(-1, 36))) Config::Load();
                ImGui::Spacing();
                if (ImGui::Button("LOAD HVH RAGE PRESET", ImVec2(-1, 36))) Config::LoadHvHPreset();
                ImGui::Spacing();
                if (ImGui::Button("RESET TO DEFAULTS", ImVec2(-1, 32))) Config::ResetDefaults();
            }
            ImGui::EndChild();
        }

        // TAB 5: LOGS
        else if (iTopNavTab == 5) {
            ImGui::BeginChild("CardDiagnostics", ImVec2(0, 0), true);
            {
                ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 1.0f), "Diagnostic Telemetry & Game State");
                ImGui::Separator();
                ImGui::Spacing();

                ImGui::Text("Active Tracked Players : %d", (int)g_CachedPlayers.size());
                ImGui::Text("ESP Screen Objects     : %d", (int)g_ESPData.size());
                ImGui::Text("Local Player In Game   : %s", g_HasLocalPlayer ? "YES" : "NO");
                ImGui::Text("Render Performance     : %.0f FPS", io.Framerate);
                ImGui::Spacing();
                ImGui::Separator();
                ImGui::Spacing();

                ImGui::TextColored(ImVec4(0.35f, 0.65f, 1.00f, 1.0f), "Diagnostic Log Files:");
                ImGui::BulletText("Game Engine Log : XUYBYA_GameEngine.log");
                ImGui::BulletText("Cheat Engine Log: XUYBYA_Cheat.log");
            }
            ImGui::EndChild();
        }
    }
    ImGui::EndChild();

    ImGui::End();
}
