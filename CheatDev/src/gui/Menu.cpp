#include "gui/Menu.h"
#include "features/Visuals.h"
#include "features/Combat.h"
#include "features/Exploits.h"
#include "core/Config.h"
#include "sdk/GameSDK.h"

// ─── Custom Styled Material Navigation Pill Button ───────────────────────────
static bool DrawSidebarCategory(const char* label, bool active, const char* icon = nullptr) {
    ImGui::PushID(label);
    
    ImVec2 size(180, 42); // Wider for sidebar
    if (active) {
        ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.23f, 0.51f, 0.96f, 0.15f)); // Highlight with opacity 0.15
        ImGui::PushStyleColor(ImGuiCol_ButtonHovered, ImVec4(0.23f, 0.51f, 0.96f, 0.25f));
        ImGui::PushStyleColor(ImGuiCol_ButtonActive, ImVec4(0.23f, 0.51f, 0.96f, 0.35f));
        ImGui::PushStyleColor(ImGuiCol_Text, ImVec4(0.23f, 0.51f, 0.96f, 1.0f)); // Blue text for active tab
    } else {
        ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.0f, 0.0f, 0.0f, 0.0f));
        ImGui::PushStyleColor(ImGuiCol_ButtonHovered, ImVec4(0.12f, 0.16f, 0.23f, 0.8f));
        ImGui::PushStyleColor(ImGuiCol_ButtonActive, ImVec4(0.20f, 0.25f, 0.33f, 1.0f));
        ImGui::PushStyleColor(ImGuiCol_Text, ImVec4(0.58f, 0.64f, 0.72f, 1.0f)); // Descriptions color for inactive
    }

    char displayBuf[128];
    if (icon) {
        snprintf(displayBuf, sizeof(displayBuf), " %s   %s", icon, label);
    } else {
        snprintf(displayBuf, sizeof(displayBuf), "  %s", label);
    }

    bool clicked = ImGui::Button(displayBuf, size);
    ImGui::PopStyleColor(4);
    ImGui::PopID();
    return clicked;
}

// ─── Custom Module Card Header ──────────────────────────────────────────────
static bool BeginModuleCard(const char* label, bool* toggle_val, float height = 0) {
    ImGui::PushStyleColor(ImGuiCol_ChildBg, ImVec4(0.12f, 0.16f, 0.23f, 1.0f)); // #1e293b
    ImGui::PushStyleVar(ImGuiStyleVar_ChildRounding, 12.0f);
    
    ImGuiWindowFlags win_flags = ImGuiWindowFlags_NoScrollbar | ImGuiWindowFlags_NoScrollWithMouse;
    ImGuiChildFlags child_flags = ImGuiChildFlags_Borders | ImGuiChildFlags_AlwaysUseWindowPadding | ImGuiChildFlags_AutoResizeY;
    bool expanded = ImGui::BeginChild(label, ImVec2(0, 0), child_flags, win_flags);
    
    // Header Row
    ImGui::PushFont(ImGui::GetIO().Fonts->Fonts.Size > 1 ? ImGui::GetIO().Fonts->Fonts[1] : ImGui::GetFont());
    ImGui::TextColored(ImVec4(0.97f, 0.98f, 0.99f, 1.0f), "%s", label);
    ImGui::PopFont();
    
    // Actions on the right
    float width = ImGui::GetWindowWidth();
    
    // Toggle
    ImGui::SameLine(width - 45);
    ImGui::PushID(label);
    
    // Draw custom toggle switch
    ImVec2 p = ImGui::GetCursorScreenPos();
    ImDrawList* draw_list = ImGui::GetWindowDrawList();
    float toggle_height = 20.0f;
    float toggle_width = 36.0f;
    float radius = toggle_height * 0.5f;
    
    if (ImGui::InvisibleButton("##toggle", ImVec2(toggle_width, toggle_height))) {
        if (toggle_val) *toggle_val = !*toggle_val;
    }
    
    bool is_on = toggle_val ? *toggle_val : false;
    bool hovered = ImGui::IsItemHovered();
    ImU32 bg_col = is_on ? IM_COL32(59,130,246,255) : (hovered ? IM_COL32(80,90,110,255) : IM_COL32(51,65,85,255));
    draw_list->AddRectFilled(p, ImVec2(p.x + toggle_width, p.y + toggle_height), bg_col, radius);
    
    float circle_x = p.x + (is_on ? toggle_width - radius : radius);
    draw_list->AddCircleFilled(ImVec2(circle_x, p.y + radius), radius - 2.0f, IM_COL32(255, 255, 255, 255));
    
    ImGui::PopID();
    
    // Keybind
    ImGui::SameLine(width - 75);
    ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.20f, 0.25f, 0.33f, 1.0f));
    if (ImGui::Button("...", ImVec2(24, 20))) {
        // Open keybind assigner logic
    }
    ImGui::PopStyleColor();

    ImGui::Separator();
    ImGui::Spacing();
    
    return expanded;
}

static void EndModuleCard() {
    ImGui::EndChild();
    ImGui::PopStyleVar();
    ImGui::PopStyleColor();
    ImGui::Spacing();
}


// ─── Custom Figma Widgets ───────────────────────────────────────────────────
static bool CustomCheckbox(const char* label, bool* v) {
    ImVec2 p = ImGui::GetCursorScreenPos();
    ImDrawList* draw_list = ImGui::GetWindowDrawList();
    float height = 20.0f;
    float width = 20.0f;
    
    ImGui::PushID(label);
    bool clicked = false;
    if (ImGui::InvisibleButton("##cb", ImVec2(width, height))) {
        *v = !*v;
        clicked = true;
    }
    bool hovered = ImGui::IsItemHovered();
    ImU32 bg_col = *v ? IM_COL32(59, 130, 246, 255) : (hovered ? IM_COL32(80, 90, 110, 255) : IM_COL32(15, 23, 42, 255));
    draw_list->AddRectFilled(p, ImVec2(p.x + width, p.y + height), bg_col, 6.0f);
    
    if (*v) {
        draw_list->AddLine(ImVec2(p.x + 5, p.y + 10), ImVec2(p.x + 9, p.y + 14), IM_COL32(255,255,255,255), 2.0f);
        draw_list->AddLine(ImVec2(p.x + 9, p.y + 14), ImVec2(p.x + 15, p.y + 5), IM_COL32(255,255,255,255), 2.0f);
    }
    
    ImGui::SameLine();
    ImGui::SetCursorPosY(ImGui::GetCursorPosY() + 2.0f);
    ImGui::TextColored(ImVec4(0.97f, 0.98f, 0.99f, 1.0f), "%s", label);
    ImGui::PopID();
    
    return clicked;
}

static bool CustomSliderFloat(const char* label, float* v, float v_min, float v_max, const char* format) {
    ImGui::PushID(label);
    
    // Top row: Label | Value
    ImGui::TextColored(ImVec4(0.97f, 0.98f, 0.99f, 1.0f), "%s", label);
    
    char val_buf[32];
    snprintf(val_buf, sizeof(val_buf), format, *v);
    
    float val_width = ImGui::CalcTextSize(val_buf).x;
    ImGui::SameLine(ImGui::GetWindowWidth() - val_width - 30.0f);
    ImGui::TextColored(ImVec4(0.58f, 0.64f, 0.72f, 1.0f), "%s", val_buf);
    
    // Bottom row: Slider bar
    ImVec2 p = ImGui::GetCursorScreenPos();
    ImDrawList* draw_list = ImGui::GetWindowDrawList();
    float width = ImGui::GetWindowWidth() - 40.0f;
    float height = 6.0f; 
    
    ImGui::InvisibleButton("##slider", ImVec2(width, 16.0f));
    bool hovered = ImGui::IsItemHovered();
    bool active = ImGui::IsItemActive();
    
    if (active) {
        float mouse_x = ImGui::GetIO().MousePos.x;
        float normalized = (mouse_x - p.x) / width;
        if (normalized < 0.0f) normalized = 0.0f;
        if (normalized > 1.0f) normalized = 1.0f;
        *v = v_min + normalized * (v_max - v_min);
    }
    
    float normalized_val = (*v - v_min) / (v_max - v_min);
    if (normalized_val < 0.0f) normalized_val = 0.0f;
    if (normalized_val > 1.0f) normalized_val = 1.0f;
    float fill_width = normalized_val * width;
    
    // Background track
    draw_list->AddRectFilled(ImVec2(p.x, p.y + 5.0f), ImVec2(p.x + width, p.y + 5.0f + height), IM_COL32(15, 23, 42, 255), 3.0f);
    
    // Fill track
    if (fill_width > 0) {
        draw_list->AddRectFilled(ImVec2(p.x, p.y + 5.0f), ImVec2(p.x + fill_width, p.y + 5.0f + height), IM_COL32(59, 130, 246, 255), 3.0f);
    }
    
    // Knob
    float knob_x = p.x + fill_width;
    float knob_y = p.y + 5.0f + (height * 0.5f);
    draw_list->AddCircleFilled(ImVec2(knob_x, knob_y), 7.0f, IM_COL32(255, 255, 255, 255));
    if (hovered || active) {
        draw_list->AddCircleFilled(ImVec2(knob_x, knob_y), 10.0f, IM_COL32(255, 255, 255, 50));
    }
    
    ImGui::PopID();
    ImGui::Spacing();
    
    return active;
}

void Menu::InitializeTheme() {
    ImGuiStyle& style = ImGui::GetStyle();
    
    style.WindowRounding    = 12.0f;
    style.ChildRounding     = 12.0f;
    style.FrameRounding     = 8.0f;
    style.PopupRounding     = 10.0f;
    style.ScrollbarRounding = 8.0f;
    style.GrabRounding      = 6.0f;
    style.TabRounding       = 8.0f;

    style.WindowBorderSize  = 1.0f;
    style.ChildBorderSize   = 1.0f;
    style.FrameBorderSize   = 1.0f;
    style.PopupBorderSize   = 1.0f;

    style.WindowPadding     = ImVec2(18.0f, 18.0f);
    style.FramePadding      = ImVec2(12.0f, 8.0f);
    style.ItemSpacing       = ImVec2(12.0f, 12.0f);
    style.ItemInnerSpacing  = ImVec2(8.0f, 6.0f);

    ImVec4* colors = style.Colors;
    
    // Backgrounds: Window #0f172a, Panels #1e293b
    colors[ImGuiCol_WindowBg]              = ImVec4(0.06f, 0.09f, 0.16f, 1.00f);
    colors[ImGuiCol_ChildBg]               = ImVec4(0.12f, 0.16f, 0.23f, 1.00f);
    colors[ImGuiCol_PopupBg]               = ImVec4(0.12f, 0.16f, 0.23f, 1.00f);
    
    // Borders: #334155
    colors[ImGuiCol_Border]                = ImVec4(0.20f, 0.25f, 0.33f, 1.00f);
    colors[ImGuiCol_BorderShadow]          = ImVec4(0.00f, 0.00f, 0.00f, 0.00f);

    // Text: Headers #F8FAFC, Descriptions #94A3B8
    colors[ImGuiCol_Text]                  = ImVec4(0.97f, 0.98f, 0.99f, 1.00f);
    colors[ImGuiCol_TextDisabled]          = ImVec4(0.58f, 0.64f, 0.72f, 1.00f);

    // Frame (Input fields, checkboxes, etc)
    colors[ImGuiCol_FrameBg]               = ImVec4(0.06f, 0.09f, 0.16f, 1.00f);
    colors[ImGuiCol_FrameBgHovered]        = ImVec4(0.20f, 0.25f, 0.33f, 1.00f);
    colors[ImGuiCol_FrameBgActive]         = ImVec4(0.23f, 0.51f, 0.96f, 0.50f);

    colors[ImGuiCol_TitleBg]               = ImVec4(0.06f, 0.09f, 0.16f, 1.00f);
    colors[ImGuiCol_TitleBgActive]         = ImVec4(0.06f, 0.09f, 0.16f, 1.00f);
    colors[ImGuiCol_TitleBgCollapsed]      = ImVec4(0.06f, 0.09f, 0.16f, 1.00f);
    colors[ImGuiCol_MenuBarBg]             = ImVec4(0.12f, 0.16f, 0.23f, 1.00f);

    colors[ImGuiCol_ScrollbarBg]           = ImVec4(0.06f, 0.09f, 0.16f, 1.00f);
    colors[ImGuiCol_ScrollbarGrab]         = ImVec4(0.20f, 0.25f, 0.33f, 1.00f);
    colors[ImGuiCol_ScrollbarGrabHovered]  = ImVec4(0.30f, 0.35f, 0.45f, 1.00f);
    colors[ImGuiCol_ScrollbarGrabActive]   = ImVec4(0.23f, 0.51f, 0.96f, 1.00f);

    // Accents (Buttons, Checks, Sliders): #3B82F6 -> #2563EB hover
    colors[ImGuiCol_CheckMark]             = ImVec4(0.23f, 0.51f, 0.96f, 1.00f);
    colors[ImGuiCol_SliderGrab]            = ImVec4(0.23f, 0.51f, 0.96f, 1.00f);
    colors[ImGuiCol_SliderGrabActive]      = ImVec4(0.15f, 0.39f, 0.92f, 1.00f);

    colors[ImGuiCol_Button]                = ImVec4(0.23f, 0.51f, 0.96f, 1.00f);
    colors[ImGuiCol_ButtonHovered]         = ImVec4(0.15f, 0.39f, 0.92f, 1.00f);
    colors[ImGuiCol_ButtonActive]          = ImVec4(0.12f, 0.30f, 0.70f, 1.00f);

    colors[ImGuiCol_Header]                = ImVec4(0.23f, 0.51f, 0.96f, 0.30f);
    colors[ImGuiCol_HeaderHovered]         = ImVec4(0.23f, 0.51f, 0.96f, 0.50f);
    colors[ImGuiCol_HeaderActive]          = ImVec4(0.23f, 0.51f, 0.96f, 0.80f);

    colors[ImGuiCol_Separator]             = ImVec4(0.20f, 0.25f, 0.33f, 1.00f);
    colors[ImGuiCol_SeparatorHovered]      = ImVec4(0.23f, 0.51f, 0.96f, 0.60f);
    colors[ImGuiCol_SeparatorActive]       = ImVec4(0.23f, 0.51f, 0.96f, 1.00f);

    colors[ImGuiCol_ResizeGrip]            = ImVec4(0.23f, 0.51f, 0.96f, 0.20f);
    colors[ImGuiCol_ResizeGripHovered]     = ImVec4(0.23f, 0.51f, 0.96f, 0.50f);
    colors[ImGuiCol_ResizeGripActive]      = ImVec4(0.23f, 0.51f, 0.96f, 0.80f);

    colors[ImGuiCol_Tab]                   = ImVec4(0.12f, 0.16f, 0.23f, 1.00f);
    colors[ImGuiCol_TabHovered]            = ImVec4(0.23f, 0.51f, 0.96f, 0.80f);
    colors[ImGuiCol_TabActive]             = ImVec4(0.23f, 0.51f, 0.96f, 1.00f);
    colors[ImGuiCol_TabUnfocused]          = ImVec4(0.06f, 0.09f, 0.16f, 1.00f);
    colors[ImGuiCol_TabUnfocusedActive]    = ImVec4(0.12f, 0.16f, 0.23f, 1.00f);
}

void Menu::Render() {
    if (!g_ShowMenu) return;

    ImGuiIO& io = ImGui::GetIO();

    POINT pt;
    if (GetCursorPos(&pt) && ScreenToClient(g_hWnd, &pt)) {
        io.AddMousePosEvent((float)pt.x, (float)pt.y);
    }
    io.AddMouseButtonEvent(0, (GetAsyncKeyState(VK_LBUTTON) & 0x8000) != 0);
    io.AddMouseButtonEvent(1, (GetAsyncKeyState(VK_RBUTTON) & 0x8000) != 0);

    ImGui::SetNextWindowSize(ImVec2(1000.0f, 650.0f), ImGuiCond_FirstUseEver);
    ImGui::SetNextWindowPos(
        ImVec2(io.DisplaySize.x * 0.5f, io.DisplaySize.y * 0.5f),
        ImGuiCond_FirstUseEver,
        ImVec2(0.5f, 0.5f)
    );

    ImGuiWindowFlags winFlags = ImGuiWindowFlags_NoCollapse | ImGuiWindowFlags_NoTitleBar;
    ImGui::Begin("MATERIAL_MAIN_WINDOW", &g_ShowMenu, winFlags);

    // Bottom gradient bar (drawn via WindowDrawList)
    ImVec2 p_min = ImGui::GetWindowPos();
    ImVec2 p_max = ImVec2(p_min.x + ImGui::GetWindowSize().x, p_min.y + ImGui::GetWindowSize().y);
    ImGui::GetWindowDrawList()->AddRectFilledMultiColor(
        ImVec2(p_min.x, p_max.y - 8.0f), p_max,
        IM_COL32(124, 58, 237, 255),  // #7C3AED
        IM_COL32(59, 130, 246, 255),  // #3B82F6
        IM_COL32(59, 130, 246, 255),
        IM_COL32(124, 58, 237, 255)
    );

    // ── LEFT NAVIGATION SIDEBAR ──
    ImGui::BeginChild("Sidebar", ImVec2(220, 0), false);
    {
        ImGui::SetCursorPosY(ImGui::GetCursorPosY() + 10.0f);
        ImGui::SetCursorPosX(ImGui::GetCursorPosX() + 10.0f);
        
        // PRO badge
        ImGui::PushFont(ImGui::GetIO().Fonts->Fonts.Size > 1 ? ImGui::GetIO().Fonts->Fonts[1] : ImGui::GetFont());
        ImGui::TextColored(ImVec4(0.94f, 0.27f, 0.27f, 1.0f), "PRO");
        ImGui::PopFont();
        
        ImGui::SameLine();
        ImGui::SetCursorPosY(ImGui::GetCursorPosY() + 3.0f);
        ImGui::TextColored(ImVec4(0.97f, 0.98f, 0.99f, 1.0f), "MIDNIGHT");
        
        ImGui::Spacing();
        ImGui::Spacing();
        ImGui::Spacing();
        ImGui::Separator();
        ImGui::Spacing();
        ImGui::Spacing();

        if (DrawSidebarCategory("Combat",       iTopNavTab == 0, "[+]")) iTopNavTab = 0;
        if (DrawSidebarCategory("Movement",     iTopNavTab == 1, "[>]")) iTopNavTab = 1;
        if (DrawSidebarCategory("Visuals",      iTopNavTab == 2, "[o]")) iTopNavTab = 2;
        if (DrawSidebarCategory("Weapons",      iTopNavTab == 3, "[~]")) iTopNavTab = 3;
        if (DrawSidebarCategory("Exploits",     iTopNavTab == 4, "[X]")) iTopNavTab = 4;
        if (DrawSidebarCategory("Misc",         iTopNavTab == 5, "[!]")) iTopNavTab = 5;

        // Bottom Avatar area
        ImGui::SetCursorPosY(ImGui::GetWindowHeight() - 70.0f);
        ImGui::Separator();
        ImGui::Spacing();
        ImGui::SetCursorPosX(ImGui::GetCursorPosX() + 10.0f);
        
        // Green online status dot
        ImVec2 p = ImGui::GetCursorScreenPos();
        ImGui::GetWindowDrawList()->AddCircleFilled(ImVec2(p.x + 10, p.y + 10), 6.0f, IM_COL32(34, 197, 94, 255));
        
        ImGui::SetCursorPos(ImVec2(ImGui::GetCursorPosX() + 25, ImGui::GetCursorPosY() + 3));
        ImGui::TextColored(ImVec4(0.97f, 0.98f, 0.99f, 1.0f), "LO_Pro_Hacker");
        
        ImGui::SetCursorPos(ImVec2(ImGui::GetCursorPosX() + 25, ImGui::GetCursorPosY()));
        ImGui::TextColored(ImVec4(0.58f, 0.64f, 0.72f, 1.0f), "Online (%.0f FPS)", io.Framerate);
    }
    ImGui::EndChild();

    ImGui::SameLine();

    // ── MAIN CONTENT AREA ──
    ImGui::BeginChild("MainContent", ImVec2(0, 0), false);
    {
        float columnWidth = (ImGui::GetContentRegionAvail().x - 18.0f) * 0.5f;

        if (iTopNavTab == 0) { // COMBAT
            ImGui::Columns(2, nullptr, false);
            
            // Left Column
            if (BeginModuleCard("Aimbot", &bEnableAimbot, 200)) {
                CustomCheckbox("Visible Only", &bChamsVisibleOnly);
                CustomSliderFloat("Smoothness", &aimbotSmooth, 1.0f, 10.0f, "%.1f");
                CustomSliderFloat("FOV Radius", &aimbotFOV, 10.0f, 500.0f, "%.0f px");
                
                CustomCheckbox("Auto Fire", &bAimbotAutoFire);
            }
            EndModuleCard();

            if (BeginModuleCard("Silent Aim", &bEnableSilentAim, 180)) {
                CustomCheckbox("Full 360° Hit", &bSilentAimFull360);
                CustomCheckbox("Draw FOV Circle", &bDrawSilentAimFOV);
                if (!bSilentAimFull360) {
                    CustomSliderFloat("FOV Radius", &fSilentAimFOV, 20.0f, 800.0f, "%.0f px");
                }
                const char* targetBonesSilent[] = { "Chest / Torso", "Head", "Root / Pelvis" };
                ImGui::Combo("Target Hit Bone", &iSilentAimTarget, targetBonesSilent, IM_ARRAYSIZE(targetBonesSilent));
            }
            EndModuleCard();
            
            ImGui::NextColumn(); // Right Column
            
            if (BeginModuleCard("Mass Kill Aura", &bEnableMassKill, 100)) {
                ImGui::TextColored(ImVec4(0.58f, 0.64f, 0.72f, 1.0f), "Hits all players instantly");
            }
            EndModuleCard();
            
            if (BeginModuleCard("Teleport Kill", &bEnableTeleportKill, 100)) {
                ImGui::TextColored(ImVec4(0.58f, 0.64f, 0.72f, 1.0f), "Teleports you behind enemies");
            }
            EndModuleCard();
            
            if (BeginModuleCard("God Mode", &bGodMode, 100)) {
                ImGui::TextColored(ImVec4(0.58f, 0.64f, 0.72f, 1.0f), "Invincibility (Server-sided)");
            }
            EndModuleCard();
            
            ImGui::Columns(1);
        }
        else if (iTopNavTab == 1) { // MOVEMENT
            ImGui::Columns(2, nullptr, false);
            
            if (BeginModuleCard("Speedhack", &bEnableSpeedhack, 140)) {
                CustomSliderFloat("Speed Multiplier", &fSpeedMultiplier, 1.0f, 10.0f, "%.1fx");
            }
            EndModuleCard();
            
            if (BeginModuleCard("Flight & Gravity", &bZeroGravity, 200)) {
                CustomCheckbox("Noclip Fly", &bNoClip);
                CustomSliderFloat("Fly Speed", &fNoClipSpeed, 1.0f, 20.0f, "%.1f");
                CustomSliderFloat("Gravity Modifier", &fGravityMultiplier, -2.0f, 2.0f, "%.2fx");
            }
            EndModuleCard();
            
            ImGui::NextColumn();
            
            if (BeginModuleCard("Anti-Knockback", &bAntiKnockback, 100)) {
                ImGui::TextColored(ImVec4(0.58f, 0.64f, 0.72f, 1.0f), "Prevents taking knockback");
            }
            EndModuleCard();

            if (BeginModuleCard("Jump Mods", &bEnableSuperJump, 160)) {
                CustomCheckbox("Infinite Air Jumps", &bInfiniteAirJump);
                CustomCheckbox("Bunnyhop (Auto-Jump)", &bBunnyhop);
                CustomSliderFloat("Jump Power", &fJumpMultiplier, 1.0f, 5.0f, "%.1fx");
            }
            EndModuleCard();
            
            ImGui::Columns(1);
        }
        else if (iTopNavTab == 2) { // VISUALS
            ImGui::Columns(2, nullptr, false);
            
            if (BeginModuleCard("Player ESP", &bEnableESP, 100)) {
                CustomSliderFloat("Max Render Distance", &fMaxDistance, 50.0f, 2000.0f, "%.0f m");
            }
            EndModuleCard();
            
            ImGui::NextColumn();
            
            if (BeginModuleCard("Chams", &bEnableChams, 160)) {
                ImGui::ColorEdit4("Visible Color", colChamsEnemyVis);
                ImGui::ColorEdit4("Hidden Color", colChamsEnemyOcc);
            }
            EndModuleCard();
            
            if (BeginModuleCard("World FX", &bCustomFOV, 160)) {
                CustomSliderFloat("Camera FOV", &fCustomFOVValue, 60.0f, 150.0f, "%.0f");
                CustomCheckbox("Disable Shadows", &bDisableGameShadows);
                CustomCheckbox("Disable Fog", &bDisableFogAndBlur);
            }
            EndModuleCard();
            
            ImGui::Columns(1);
        }
        else if (iTopNavTab == 3) { // WEAPONS
            ImGui::Columns(2, nullptr, false);
            
            if (BeginModuleCard("Gun Mods", &bInfiniteAmmo, 200)) {
                CustomCheckbox("99,999 Damage", &bOneHitKillDamage);
                CustomCheckbox("Rapid Fire", &bRapidFire);
                CustomCheckbox("Infinite Range", &bInfiniteRange);
                CustomCheckbox("Bypass Spawn Delay", &bWeaponSpawnBypass);
            }
            EndModuleCard();
            
            ImGui::NextColumn();
            
            if (BeginModuleCard("Grappling Hook", &bInfiniteGrappleRange, 200)) {
                CustomCheckbox("Super Speed", &bSuperGrappleSpeed);
                CustomSliderFloat("Speed Multiplier", &fGrappleSpeedMult, 1.0f, 5.0f, "%.1fx");
                CustomCheckbox("Instant Boost", &bInstantGrappleBoost);
                CustomCheckbox("Magnet Aim", &bGrappleMagnetAim);
            }
            EndModuleCard();
            
            ImGui::Columns(1);
        }
        else if (iTopNavTab == 4) { // EXPLOITS
            ImGui::Columns(2, nullptr, false);
            
            if (BeginModuleCard("Server Crashers", &bServerCrashActive, 140)) {
                if (ImGui::Button("Execute Mass Crash (Lag)", ImVec2(-1, 32))) bCrashAllPlayersNow = true;
            }
            EndModuleCard();
            
            ImGui::NextColumn();
            
            if (BeginModuleCard("Map Destroyer", &bMapDestroyerActive, 140)) {
                if (ImGui::Button("Destroy All Objects", ImVec2(-1, 32))) bEndGameMatchTrigger = true;
            }
            EndModuleCard();
            
            ImGui::Columns(1);
        }
        else if (iTopNavTab == 5) { // MISC
            ImGui::Columns(2, nullptr, false);
            
            bool config_t = true;
            if (BeginModuleCard("Configuration", &config_t, 220)) {
                if (ImGui::Button("SAVE CONFIG", ImVec2(-1, 32))) Config::Save();
                if (ImGui::Button("LOAD CONFIG", ImVec2(-1, 32))) Config::Load();
                if (ImGui::Button("LOAD HVH PRESET", ImVec2(-1, 32))) Config::LoadHvHPreset();
                if (ImGui::Button("RESET DEFAULTS", ImVec2(-1, 32))) Config::ResetDefaults();
            }
            EndModuleCard();
            
            ImGui::NextColumn();
            
            bool diag_t = true;
            if (BeginModuleCard("Diagnostics", &diag_t, 220)) {
                ImGui::Text("Tracked Players : %d", (int)g_CachedPlayers.size());
                ImGui::Text("ESP Objects     : %d", (int)g_ESPData.size());
                ImGui::Text("Local Player    : %s", g_HasLocalPlayer ? "YES" : "NO");
                ImGui::Spacing();
                
                ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0.55f, 0.12f, 0.12f, 0.85f));
                ImGui::PushStyleColor(ImGuiCol_ButtonHovered, ImVec4(0.80f, 0.18f, 0.18f, 1.0f));
                ImGui::PushStyleColor(ImGuiCol_ButtonActive, ImVec4(0.40f, 0.08f, 0.08f, 1.0f));
                if (ImGui::Button("UNINJECT CHEAT", ImVec2(-1, 32))) g_Uninjecting = true;
                ImGui::PopStyleColor(3);
            }
            EndModuleCard();
            
            ImGui::Columns(1);
        }
    }
    ImGui::EndChild();

    ImGui::End();
}
