#include "hooks/Hooks.h"
#include "sdk/GameSDK.h"
#include "features/Visuals.h"
#include "features/Combat.h"
#include "features/Exploits.h"
#include "gui/Menu.h"
#include "backends/imgui_impl_win32.h"
#include "backends/imgui_impl_dx11.h"

extern IMGUI_IMPL_API LRESULT ImGui_ImplWin32_WndProcHandler(HWND, UINT, WPARAM, LPARAM);

typedef HRESULT (__stdcall *Present_t)(IDXGISwapChain*, UINT, UINT);
typedef HRESULT (__stdcall *ResizeBuffers_t)(IDXGISwapChain*, UINT, UINT, UINT, DXGI_FORMAT, UINT);

static Present_t                      oPresent                      = nullptr;
static ResizeBuffers_t                oResizeBuffers                = nullptr;
static WNDPROC                        oWndProc                      = nullptr;

static void CreateRTV(IDXGISwapChain* pSwapChain) {
    ID3D11Texture2D* pBackBuffer = nullptr;
    if (SUCCEEDED(pSwapChain->GetBuffer(0, __uuidof(ID3D11Texture2D), (void**)&pBackBuffer))) {
        g_pd3dDevice->CreateRenderTargetView(pBackBuffer, NULL, &g_mainRenderTargetView);
        pBackBuffer->Release();
    }
}

static void CleanupRTV() {
    if (g_mainRenderTargetView) {
        g_mainRenderTargetView->Release();
        g_mainRenderTargetView = nullptr;
    }
}

static DWORD_PTR* GetSwapChainVTable() {
    HWND hWndDummy = CreateWindowA("BUTTON", "DummyD3D", WS_OVERLAPPED, 0, 0, 100, 100, NULL, NULL, NULL, NULL);
    if (!hWndDummy) return nullptr;

    DXGI_SWAP_CHAIN_DESC sd = {};
    sd.BufferCount        = 1;
    sd.BufferDesc.Format  = DXGI_FORMAT_R8G8B8A8_UNORM;
    sd.BufferDesc.Width   = 100;
    sd.BufferDesc.Height  = 100;
    sd.BufferUsage        = DXGI_USAGE_RENDER_TARGET_OUTPUT;
    sd.OutputWindow       = hWndDummy;
    sd.SampleDesc.Count   = 1;
    sd.Windowed           = TRUE;
    sd.SwapEffect         = DXGI_SWAP_EFFECT_DISCARD;

    const D3D_FEATURE_LEVEL levels[] = { D3D_FEATURE_LEVEL_11_0, D3D_FEATURE_LEVEL_10_0 };
    D3D_FEATURE_LEVEL       level;
    IDXGISwapChain*         sc  = nullptr;
    ID3D11Device*           dev = nullptr;
    ID3D11DeviceContext*    ctx = nullptr;
    DWORD_PTR*              vtable = nullptr;

    if (SUCCEEDED(D3D11CreateDeviceAndSwapChain(NULL, D3D_DRIVER_TYPE_HARDWARE,
        NULL, 0, levels, 2, D3D11_SDK_VERSION, &sd, &sc, &dev, &level, &ctx))) {
        vtable = *(DWORD_PTR**)sc;
        sc->Release();
        dev->Release();
        ctx->Release();
    }

    DestroyWindow(hWndDummy);
    return vtable;
}

bool Hooks::Initialize() {
    DWORD_PTR* vtable = GetSwapChainVTable();
    if (!vtable) return false;

    MH_Initialize();
    MH_CreateHook((void*)vtable[8],  (LPVOID)&hkPresent,       (void**)&oPresent);
    MH_CreateHook((void*)vtable[13], (LPVOID)&hkResizeBuffers, (void**)&oResizeBuffers);

    MH_EnableHook(MH_ALL_HOOKS);
    CheatLog("[+] Hooks: DirectX SwapChain hooks initialized successfully!");
    return true;
}

void Hooks::Shutdown() {
    if (g_hWnd && oWndProc) {
        SetWindowLongPtr(g_hWnd, GWLP_WNDPROC, (LONG_PTR)oWndProc);
    }
    MH_DisableHook(MH_ALL_HOOKS);
    MH_Uninitialize();
    CleanupRTV();
}

LRESULT __stdcall Hooks::WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam) {
    if (g_Uninjecting || !oWndProc)
        return DefWindowProc(hWnd, uMsg, wParam, lParam);

    __try {
        if (uMsg == WM_KEYDOWN || uMsg == WM_SYSKEYDOWN) {
            if (wParam == VK_INSERT || wParam == VK_F1) {
                g_ShowMenu = !g_ShowMenu;
                if (g_ShowMenu) {
                    ClipCursor(NULL);
                }
                return 0;
            }
            if (wParam == VK_ESCAPE && g_ShowMenu) {
                g_ShowMenu = false;
                return 0;
            }
        }

        if (g_IsInitialized) {
            if (ImGui_ImplWin32_WndProcHandler(hWnd, uMsg, wParam, lParam)) {
                return 1;
            }

            if (g_ShowMenu) {
                if (uMsg >= WM_MOUSEFIRST && uMsg <= WM_MOUSELAST) {
                    return 1;
                }
            }
        }
    }
    __except (EXCEPTION_EXECUTE_HANDLER) {}

    return CallWindowProc(oWndProc, hWnd, uMsg, wParam, lParam);
}

HRESULT __stdcall Hooks::hkResizeBuffers(IDXGISwapChain* pSwapChain, UINT BufferCount, UINT Width, UINT Height, DXGI_FORMAT NewFormat, UINT SwapChainFlags) {
    CleanupRTV();
    HRESULT hr = oResizeBuffers(pSwapChain, BufferCount, Width, Height, NewFormat, SwapChainFlags);
    CreateRTV(pSwapChain);
    return hr;
}

HRESULT __stdcall Hooks::hkPresent(IDXGISwapChain* pSwapChain, UINT SyncInterval, UINT Flags) {
    if (g_Uninjecting) return oPresent(pSwapChain, SyncInterval, Flags);

    __try {
        if (!g_IsInitialized) {
            if (SUCCEEDED(pSwapChain->GetDevice(__uuidof(ID3D11Device), (void**)&g_pd3dDevice))) {
                g_pd3dDevice->GetImmediateContext(&g_pd3dDeviceContext);

                DXGI_SWAP_CHAIN_DESC sd;
                pSwapChain->GetDesc(&sd);
                g_hWnd = sd.OutputWindow;

                CreateRTV(pSwapChain);

                oWndProc = (WNDPROC)SetWindowLongPtr(g_hWnd, GWLP_WNDPROC, (LONG_PTR)WndProc);

                ImGui::CreateContext();
                ImGuiIO& io = ImGui::GetIO();
                io.ConfigFlags &= ~ImGuiConfigFlags_NoMouseCursorChange;
                io.IniFilename  = nullptr;
                io.FontGlobalScale = 1.0f;

                // Load Google Sans / Segoe UI modern font
                ImFontConfig fontCfg;
                fontCfg.OversampleH = 2;
                fontCfg.OversampleV = 2;
                
                if (GetFileAttributesA("C:\\Windows\\Fonts\\segoeui.ttf") != INVALID_FILE_ATTRIBUTES) {
                    io.Fonts->AddFontFromFileTTF("C:\\Windows\\Fonts\\segoeui.ttf", 16.0f, &fontCfg);
                    // Load second font for PRO badge (larger)
                    if (GetFileAttributesA("C:\\Windows\\Fonts\\segoeuib.ttf") != INVALID_FILE_ATTRIBUTES) {
                        io.Fonts->AddFontFromFileTTF("C:\\Windows\\Fonts\\segoeuib.ttf", 22.0f, &fontCfg); 
                    } else {
                        io.Fonts->AddFontFromFileTTF("C:\\Windows\\Fonts\\segoeui.ttf", 22.0f, &fontCfg); 
                    }
                } else if (GetFileAttributesA("C:\\Windows\\Fonts\\arial.ttf") != INVALID_FILE_ATTRIBUTES) {
                    io.Fonts->AddFontFromFileTTF("C:\\Windows\\Fonts\\arial.ttf", 16.0f, &fontCfg);
                    if (GetFileAttributesA("C:\\Windows\\Fonts\\arialbd.ttf") != INVALID_FILE_ATTRIBUTES) {
                        io.Fonts->AddFontFromFileTTF("C:\\Windows\\Fonts\\arialbd.ttf", 22.0f, &fontCfg);
                    } else {
                        io.Fonts->AddFontFromFileTTF("C:\\Windows\\Fonts\\arial.ttf", 22.0f, &fontCfg);
                    }
                }

                Menu::InitializeTheme();

                ImGui_ImplWin32_Init(g_hWnd);
                ImGui_ImplDX11_Init(g_pd3dDevice, g_pd3dDeviceContext);

                g_IsInitialized = true;
            } else {
                return oPresent(pSwapChain, SyncInterval, Flags);
            }
        }

        if (!g_mainRenderTargetView) CreateRTV(pSwapChain);

        if (g_pd3dDeviceContext && g_mainRenderTargetView && !g_Uninjecting) {
            ImGui_ImplDX11_NewFrame();
            ImGui_ImplWin32_NewFrame();
            ImGui::NewFrame();

            ImGuiIO& io = ImGui::GetIO();

            // 1. Entities and ESP snapshot
            if (g_Il2Cpp.il2cpp_runtime_invoke && SDK::PlayerClass) {
                SDK::ScanEntities();
                SDK::UpdateESPData();
            }
            SDK::OptimizePerformance();

            // 2. Feature dispatchers
            Exploits::Update();
            Combat::Update(io);

            // 3. Render overlays
            Visuals::Render(io);

            // 4. Render Menu
            io.MouseDrawCursor = g_ShowMenu;
            if (g_ShowMenu) {
                Menu::Render();
            }

            ImGui::Render();
            g_pd3dDeviceContext->OMSetRenderTargets(1, &g_mainRenderTargetView, NULL);
            ImGui_ImplDX11_RenderDrawData(ImGui::GetDrawData());
        }
    }
    __except (EXCEPTION_EXECUTE_HANDLER) {}

    return oPresent(pSwapChain, SyncInterval, Flags);
}

