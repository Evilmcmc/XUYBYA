#pragma once
#include "core/Common.h"

class Hooks {
public:
    static bool Initialize();
    static void Shutdown();

    static HRESULT __stdcall hkPresent(IDXGISwapChain* pSwapChain, UINT SyncInterval, UINT Flags);
    static HRESULT __stdcall hkResizeBuffers(IDXGISwapChain* pSwapChain, UINT BufferCount, UINT Width, UINT Height, DXGI_FORMAT NewFormat, UINT SwapChainFlags);
    static LRESULT __stdcall WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam);

    static void hkCMDShoot(void* __this, Il2CppArray* _cameraPosition, Il2CppArray* _cameraForward, uint32_t tick, const MethodInfo* method);
    static void hkInternal_Log(int logType, int logOption, Il2CppString* msg, void* obj, const MethodInfo* method);
    static void hkInternal_LogException(Il2CppObject* exc, void* obj, const MethodInfo* method);
    static void hkOnLobbyEntered(void* __this, void* callback, const MethodInfo* method);
    static void hkOnLobbyCreated(void* __this, void* callback, const MethodInfo* method);
    static void hkOnLobbyKicked(void* __this, void* callback, const MethodInfo* method);
};
