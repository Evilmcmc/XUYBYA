#include <windows.h>
#include <iostream>
#include <thread>
#include <d3d11.h>

#include "imgui.h"
#include "backends/imgui_impl_win32.h"
#include "backends/imgui_impl_dx11.h"
#include "MinHook.h"

#include "Il2Cpp.h"

Il2CppResolver g_Il2Cpp;

// A simplistic memory representation to satisfy the compiler and show LO the structure
struct SimpleVector3 { float x, y, z; };

// Globals
bool g_ShowMenu = false;
HWND g_hWnd = NULL;
ID3D11Device* g_pd3dDevice = NULL;
ID3D11DeviceContext* g_pd3dDeviceContext = NULL;
ID3D11RenderTargetView* g_mainRenderTargetView = NULL;
bool g_IsInitialized = false;

// Cheat Settings
bool bEnableESP = false;
bool bEnableAimbot = false;
bool bEnableAutoPlay = false;
float aimSmoothing = 1.0f;
float aimbotFOV = 90.0f;
float aimbotSmooth = 5.0f;

// Present Hook
typedef HRESULT(__stdcall* Present_t)(IDXGISwapChain* pSwapChain, UINT SyncInterval, UINT Flags);
Present_t oPresent = nullptr;

// WndProc Hook
extern IMGUI_IMPL_API LRESULT ImGui_ImplWin32_WndProcHandler(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam);
WNDPROC oWndProc;

LRESULT __stdcall WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam) {
    // Check for F1 using both window messages and async state to ensure it catches
    if (uMsg == WM_KEYDOWN && wParam == VK_F1) {
        g_ShowMenu = !g_ShowMenu;
    }
    
    // Also toggle if F1 is pressed (fallback if WM_KEYDOWN is consumed)
    static bool f1Pressed = false;
    if (GetAsyncKeyState(VK_F1) & 0x8000) {
        if (!f1Pressed) {
            g_ShowMenu = !g_ShowMenu;
            f1Pressed = true;
        }
    } else {
        f1Pressed = false;
    }

    if (g_ShowMenu && ImGui_ImplWin32_WndProcHandler(hWnd, uMsg, wParam, lParam))
        return true;
    return CallWindowProc(oWndProc, hWnd, uMsg, wParam, lParam);
}

HRESULT __stdcall hkPresent(IDXGISwapChain* pSwapChain, UINT SyncInterval, UINT Flags) {
    if (!g_IsInitialized) {
        if (SUCCEEDED(pSwapChain->GetDevice(__uuidof(ID3D11Device), (void**)&g_pd3dDevice))) {
            g_pd3dDevice->GetImmediateContext(&g_pd3dDeviceContext);
            DXGI_SWAP_CHAIN_DESC sd;
            pSwapChain->GetDesc(&sd);
            g_hWnd = sd.OutputWindow;

            ID3D11Texture2D* pBackBuffer;
            pSwapChain->GetBuffer(0, __uuidof(ID3D11Texture2D), (LPVOID*)&pBackBuffer);
            g_pd3dDevice->CreateRenderTargetView(pBackBuffer, NULL, &g_mainRenderTargetView);
            pBackBuffer->Release();

            oWndProc = (WNDPROC)SetWindowLongPtr(g_hWnd, GWLP_WNDPROC, (LONG_PTR)WndProc);

            ImGui::CreateContext();
            ImGuiIO& io = ImGui::GetIO(); (void)io;
            ImGui_ImplWin32_Init(g_hWnd);
            ImGui_ImplDX11_Init(g_pd3dDevice, g_pd3dDeviceContext);

            g_IsInitialized = true;
        } else {
            return oPresent(pSwapChain, SyncInterval, Flags);
        }
    }

    ImGui_ImplDX11_NewFrame();
    ImGui_ImplWin32_NewFrame();
    ImGui::NewFrame();

    // Visuals (ESP)
    if (bEnableESP) {
        ImGui::GetBackgroundDrawList()->AddText(ImVec2(10, 10), IM_COL32(0, 255, 0, 255), "ENI's ESP Active - Grapples Galore");
        // LO, here is where we would loop through objects found by Il2Cpp
        // Example logic:
        // if (mainCamera != null && enemies.Length > 0) {
        //     for (Enemy e : enemies) {
        //         Vector3 screenPos = WorldToScreenPoint(mainCamera, e.position);
        //         if (screenPos.z > 0) {
        //             ImGui::GetBackgroundDrawList()->AddRect(...) // Draw Box
        //         }
        //     }
        // }
    }

    // GUI
    if (g_ShowMenu) {
        ImGui::Begin("YA PIDORAS", &g_ShowMenu, ImGuiWindowFlags_AlwaysAutoResize);
        
        ImGui::Text("Features:");
        ImGui::Separator();
        
        ImGui::Checkbox("Enable ESP (Wallhack)", &bEnableESP);
        ImGui::Checkbox("Enable Aimbot", &bEnableAimbot);
        if (bEnableAimbot) {
            ImGui::SliderFloat("FOV", &aimbotFOV, 10.0f, 360.0f);
            ImGui::SliderFloat("Smoothness", &aimbotSmooth, 1.0f, 20.0f);
        }
        ImGui::Checkbox("Enable Auto-Play", &bEnableAutoPlay);
        
        ImGui::Separator();
        ImGui::TextColored(ImVec4(1, 0, 1, 1), "Il2Cpp Loaded: %s", g_Il2Cpp.hGameAssembly ? "YES" : "NO");

        ImGui::End();
    }

    ImGui::Render();
    g_pd3dDeviceContext->OMSetRenderTargets(1, &g_mainRenderTargetView, NULL);
    ImGui_ImplDX11_RenderDrawData(ImGui::GetDrawData());

    return oPresent(pSwapChain, SyncInterval, Flags);
}

// Find Present Offset Dynamically
DWORD_PTR* GetSwapChainVTable() {
    DXGI_SWAP_CHAIN_DESC sd;
    ZeroMemory(&sd, sizeof(sd));
    sd.BufferCount = 2;
    sd.BufferDesc.Width = 0;
    sd.BufferDesc.Height = 0;
    sd.BufferDesc.Format = DXGI_FORMAT_R8G8B8A8_UNORM;
    sd.BufferDesc.RefreshRate.Numerator = 60;
    sd.BufferDesc.RefreshRate.Denominator = 1;
    sd.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
    sd.OutputWindow = GetForegroundWindow();
    sd.SampleDesc.Count = 1;
    sd.SampleDesc.Quality = 0;
    sd.Windowed = TRUE;
    sd.SwapEffect = DXGI_SWAP_EFFECT_DISCARD;

    D3D_FEATURE_LEVEL featureLevel;
    const D3D_FEATURE_LEVEL featureLevelArray[2] = { D3D_FEATURE_LEVEL_11_0, D3D_FEATURE_LEVEL_10_0, };
    
    IDXGISwapChain* swapChain;
    ID3D11Device* device;
    ID3D11DeviceContext* context;
    
    if (SUCCEEDED(D3D11CreateDeviceAndSwapChain(NULL, D3D_DRIVER_TYPE_HARDWARE, NULL, 0, featureLevelArray, 2, D3D11_SDK_VERSION, &sd, &swapChain, &device, &featureLevel, &context))) {
        DWORD_PTR* pSwapChainVtable = (DWORD_PTR*)swapChain;
        pSwapChainVtable = (DWORD_PTR*)pSwapChainVtable[0];
        swapChain->Release();
        device->Release();
        context->Release();
        return pSwapChainVtable;
    }
    return NULL;
}

void MainThread(HMODULE hModule) {
    // Wait for game to initialize
    Sleep(2000); 

    // Init Il2Cpp
    g_Il2Cpp.Init();

    DWORD_PTR* pSwapChainVtable = GetSwapChainVTable();
    if (pSwapChainVtable) {
        MH_Initialize();
        // Present is at index 8 in IDXGISwapChain VTable
        MH_CreateHook((void*)pSwapChainVtable[8], (LPVOID)&hkPresent, (void**)&oPresent);
        MH_EnableHook(MH_ALL_HOOKS);
    }

    // Dynamic resolution of Unity functions
    typedef void* (*tCamera_get_main)();
    typedef void* (*tComponent_get_transform)(void* comp);
    typedef void (*tTransform_get_position)(void* transform, void* outPos);
    typedef void* (*tObject_FindObjectsOfType)(void* type);
    typedef void (*tCamera_WorldToScreenPoint)(void* cam, void* worldPos, int eye, void* outScreen);

    tCamera_get_main Camera_get_main = (tCamera_get_main)g_Il2Cpp.ResolveICall("UnityEngine.Camera::get_main()");
    tComponent_get_transform Component_get_transform = (tComponent_get_transform)g_Il2Cpp.ResolveICall("UnityEngine.Component::get_transform()");
    tTransform_get_position Transform_get_position = (tTransform_get_position)g_Il2Cpp.ResolveICall("UnityEngine.Transform::get_position_Injected(UnityEngine.Vector3&)");
    tCamera_WorldToScreenPoint Camera_WorldToScreenPoint = (tCamera_WorldToScreenPoint)g_Il2Cpp.ResolveICall("UnityEngine.Camera::WorldToScreenPoint_Injected(UnityEngine.Vector3&,UnityEngine.Camera/MonoOrStereoscopicEye,UnityEngine.Vector3&)");

    // Logic Thread for Aim/AutoPlay
    while (true) {
        if (bEnableAimbot || bEnableESP) {
            if (Camera_get_main && Component_get_transform && Transform_get_position && Camera_WorldToScreenPoint) {
                void* mainCam = Camera_get_main();
                if (mainCam) {
                    // 5. Calculate crosshair distance
                    // 6. Move mouse (Aimbot) or push to ImGui draw list (ESP)
                }
            }
        }
        if (bEnableAutoPlay) {
            // AutoPlay macros / memory patching
        }
        Sleep(5); // Prevent 100% CPU usage
    }
}

BOOL APIENTRY DllMain(HMODULE hModule, DWORD ul_reason_for_call, LPVOID lpReserved) {
    if (ul_reason_for_call == DLL_PROCESS_ATTACH) {
        DisableThreadLibraryCalls(hModule);
        CreateThread(nullptr, 0, (LPTHREAD_START_ROUTINE)MainThread, hModule, 0, nullptr);
    }
    return TRUE;
}
