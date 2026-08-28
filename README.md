# XUYBYA - Grapples Galore Modding & Cheat Framework

A comprehensive reverse engineering, modding, and cheat development framework for the Unity/IL2CPP game **Grapples Galore**. This repository contains the full game environment, decompiled source code, dumper tools, and a custom internal C++ cheat (DLL).

## Features
- **Internal Cheat (C++)**:
  - **ImGui Menu** (Toggle with `F1`)
  - **Aimbot** (Configurable FOV and Smoothness)
  - **ESP**
  - **Auto-Play**
  - **Dynamic IL2CPP Resolution**: Uses `il2cpp_resolve_icall` to dynamically fetch game engine functions (e.g., `Camera::get_main`, `WorldToScreenPoint`) without relying on hardcoded static offsets that break on game updates.
- **Decompiled Game Source**: Full decompiled C# source of the game's `Assembly-CSharp` located in `SRC/` for easy reference and modding.
- **Cross-Platform Tooling**: Includes portable .NET runtime and IL2CPP dumpers to extract game metadata directly on Linux.

## Repo Structure
- `CheatDev/`: Contains the internal cheat source code (`dllmain.cpp`, `Il2Cpp.h`, features), ImGui, MinHook, and build scripts.
- `SRC/`: The decompiled Unity C# source code (`Assembly-CSharp.dll`) of Grapples Galore. Perfect for finding function signatures and understanding game logic (e.g., `PlayerMovement.cs`, `GrapplingHook.cs`).
- `DumpedSrc/` & `dumper/`: Il2CppDumper and output files used to extract game metadata and offsets.
- `Grapples Galore.exe` & `Grapples Galore_Data/`: The target game client and tracked assets (via Git LFS).
- `ilspy_win/` & `dotnet_runtime/`: Local tooling for decompilation and executing .NET tools on Linux.

## Development & Compilation
This cheat is designed to be cross-compiled on Linux for Windows x64.

### Requirements (Linux)
- `x86_64-w64-mingw32-g++` (MinGW)
- `bash`

### Build Instructions
Run the build script in the `CheatDev` directory to compile the cheat:
```bash
cd CheatDev
bash build.sh
```
This will generate `Cheat.dll`.

### Codebase Graph Setup
This project uses `codebase-memory-mcp` for structural knowledge graphs. We have persisted the graph in `.codebase-memory/`. To use it on a new machine, install the MCP server:

**Linux/macOS:**
```bash
curl -fsSL https://raw.githubusercontent.com/DeusData/codebase-memory-mcp/main/install.sh | bash
```

**Windows (PowerShell):**
```powershell
Invoke-WebRequest -Uri https://raw.githubusercontent.com/DeusData/codebase-memory-mcp/main/install.ps1 -OutFile install.ps1; Unblock-File .\install.ps1; .\install.ps1
```

## Injection & Usage
1. Launch **Grapples Galore**.
2. Run `Injector.exe` (built via `build.sh`) to inject `Cheat.dll` into the `Grapples Galore.exe` process.
3. Press **F1** to open the ImGui menu and configure the Aimbot/ESP settings.

## Credits
- Built with ❤️ for LO.
- Powered by MinHook and ImGui.
