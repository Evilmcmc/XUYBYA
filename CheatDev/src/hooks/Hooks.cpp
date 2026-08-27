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

typedef void (*tCMDShoot)(void* __this, void* _cameraPosition, void* _cameraForward, uint32_t tick, const MethodInfo* method);
static tCMDShoot oCMDShoot = nullptr;

static void hkCMDShoot(void* __this, void* _cameraPosition, void* _cameraForward, uint32_t tick, const MethodInfo* method) {
    if (!__this || !g_IsInitialized || g_Uninjecting) {
        if (oCMDShoot) oCMDShoot(__this, _cameraPosition, _cameraForward, tick, method);
        return;
    }

    __try {
        if (bEnableSilentAim) {
            Vector3 targetPos{};
            if (Combat::GetSilentAimTargetPosition(&targetPos)) {
                Vector3 camPos{};
                void* activeCam = SDK::GetCurrentCamera();
                if (activeCam && IsValidUnityObj(activeCam)) {
                    void* camTr = g_Il2Cpp.GetComponentTransform(activeCam);
                    if (camTr && IsValidUnityObj(camTr)) {
                        g_Il2Cpp.GetTransformPosition(camTr, &camPos);
                    }
                }

                if (camPos.LengthSq() < 0.001f && SDK::UnpackShortMethod && SDK::UnpackDirectionMethod) {
                    void* args[1] = { _cameraPosition };
                    void* exc = nullptr;
                    Il2CppObject* res = g_Il2Cpp.il2cpp_runtime_invoke(SDK::UnpackDirectionMethod, nullptr, args, &exc);
                    if (!exc && res && IsValidMemPtr(res, 0x1C)) {
                        camPos = *(Vector3*)((char*)res + 0x10);
                    }
                }

                Vector3 aimDir = targetPos - camPos;
                float len = aimDir.Length();
                if (len > 0.001f) {
                    aimDir = aimDir * (1.0f / len);
                    if (SDK::PackDirectionMethod) {
                        void* pArgs[1] = { &aimDir };
                        void* exc = nullptr;
                        Il2CppObject* newPackedFwd = g_Il2Cpp.il2cpp_runtime_invoke(SDK::PackDirectionMethod, nullptr, pArgs, &exc);
                        if (!exc && newPackedFwd && IsValidMemPtr(newPackedFwd, 0x18)) {
                            _cameraForward = newPackedFwd;
                        }
                    }
                }
            }
        }
    }
    __except (EXCEPTION_EXECUTE_HANDLER) {}

    if (oCMDShoot) {
        oCMDShoot(__this, _cameraPosition, _cameraForward, tick, method);
    }
}

bool Hooks::Initialize() {
    DWORD_PTR* vtable = GetSwapChainVTable();
    if (!vtable) return false;

    MH_Initialize();
    MH_CreateHook((void*)vtable[8],  (LPVOID)&hkPresent,       (void**)&oPresent);
    MH_CreateHook((void*)vtable[13], (LPVOID)&hkResizeBuffers, (void**)&oResizeBuffers);

    if (SDK::CMDShoot) {
        void* methodPtr = *(void**)SDK::CMDShoot;
        if (methodPtr) {
            MH_CreateHook(methodPtr, (LPVOID)&hkCMDShoot, (void**)&oCMDShoot);
            CheatLog("[+] Weapon::CMDShoot hooked at %p for Silent Aim!", methodPtr);
        }
    }

    MH_EnableHook(MH_ALL_HOOKS);
    CheatLog("[+] Hooks: DirectX SwapChain & Game methods hooked successfully!");
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
    if (!g_IsInitialized || !oWndProc || g_Uninjecting)
        return DefWindowProc(hWnd, uMsg, wParam, lParam);

    if (uMsg == WM_KEYDOWN || uMsg == WM_SYSKEYDOWN) {
        if (wParam == VK_INSERT || wParam == VK_F1) {
            g_ShowMenu = !g_ShowMenu;
            if (g_ShowMenu) {
                ClipCursor(NULL);
                g_Il2Cpp.SetCursorState(true);
            }
            ImGui::GetIO().MouseDrawCursor = g_ShowMenu;
            return 0;
        }
        if (wParam == VK_ESCAPE && g_ShowMenu) {
            g_ShowMenu = false;
            ImGui::GetIO().MouseDrawCursor = false;
            return 0;
        }
    }

    if (g_ShowMenu) {
        ImGui_ImplWin32_WndProcHandler(hWnd, uMsg, wParam, lParam);

        if (uMsg == WM_SETCURSOR) {
            SetCursor(NULL);
            return 1;
        }

        if ((uMsg >= WM_MOUSEFIRST && uMsg <= WM_MOUSELAST) ||
            (uMsg >= WM_KEYFIRST && uMsg <= WM_KEYLAST) ||
            uMsg == WM_CHAR || uMsg == WM_INPUT) {
            return 0;
        }
    }

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
            if (GetFileAttributesA("C:\\Windows\\Fonts\\segoeui.ttf") != INVALID_FILE_ATTRIBUTES) {
                io.Fonts->AddFontFromFileTTF("C:\\Windows\\Fonts\\segoeui.ttf", 16.5f);
            } else if (GetFileAttributesA("C:\\Windows\\Fonts\\arial.ttf") != INVALID_FILE_ATTRIBUTES) {
                io.Fonts->AddFontFromFileTTF("C:\\Windows\\Fonts\\arial.ttf", 16.0f);
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
        SDK::ScanEntities();
        SDK::UpdateESPData();
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

    return oPresent(pSwapChain, SyncInterval, Flags);
}
