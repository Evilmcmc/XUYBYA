---
name: il2cpp-dll-cheating
description: Cross-compiling Windows game cheats (DLLs) on Linux using MinGW, hooking IDXGISwapChain, and using dynamic IL2CPP resolution.
---

# IL2CPP Game Cheat Development & Analysis

## Tooling & Cross-Compilation
When developing a Windows x64 DLL cheat inside a Linux workspace, use the MinGW cross-compiler:
```bash
x86_64-w64-mingw32-g++ -shared -o Cheat.dll dllmain.cpp -ld3d11 -ld3dcompiler -static -static-libgcc -static-libstdc++
```
- Ensure file headers use case-sensitive matching for Linux compatibility (e.g., `#include <windows.h>` instead of `<Windows.h>`).

## Running .NET Tools on Restricted Linux Systems
If `dotnet` or `wine` are unavailable or lack dependencies to run tools like `Il2CppDumper`:
1. Deploy a local portable .NET runtime using the official script:
   ```bash
   wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
   chmod +x dotnet-install.sh
   ./dotnet-install.sh -c 6.0 --install-dir ./dotnet_runtime
   ```
2. Run the tool assembly directly using the portable host:
   ```bash
   ./dotnet_runtime/dotnet Il2CppDumper/Il2CppDumper.dll <PathToGameAssembly.dll> <PathToMetadata.dat>
   ```

## Dynamic IL2CPP Resolution
Instead of using static structs which break during game updates, resolve internal engine calls dynamically:
1. Import `il2cpp_resolve_icall` from `GameAssembly.dll`.
2. Retrieve internal function pointers using string names:
   ```cpp
   typedef void* (*tCamera_get_main)();
   tCamera_get_main Camera_get_main = (tCamera_get_main)il2cpp_resolve_icall("UnityEngine.Camera::get_main()");
   ```

## VCS Management (Git LFS)
When working with heavy game engine assets and binary files in git:
1. Install and initialize Git LFS:
   ```bash
   git lfs install
   ```
2. Track assets to bypass GitHub's 100MB limitation:
   ```bash
   git lfs track "*.assets" "*.resS" "*.dll" "*.dat"
   git add .gitattributes
   ```
