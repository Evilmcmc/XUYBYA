# XUYBYA - Grapples Galore Internal Cheat

An internal cheat (DLL) developed for the Unity/IL2CPP game **Grapples Galore**.

## Features
- **ImGui Menu** (Toggle with `F1`)
- **Aimbot** (Configurable FOV and Smoothness)
- **ESP**
- **Auto-Play**
- **Dynamic IL2CPP Resolution**: Uses `il2cpp_resolve_icall` to dynamically fetch game engine functions (e.g., `Camera::get_main`, `WorldToScreenPoint`) without relying on hardcoded static offsets that break on game updates.

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

## Injection & Usage
1. Launch **Grapples Galore**.
2. Inject `Cheat.dll` into the `Grapples Galore.exe` process using your preferred injector.
3. Press **F1** to open the ImGui menu and configure the Aimbot/ESP settings.

## Repo Structure
- `CheatDev/`: Contains the cheat source code (`dllmain.cpp`, `Il2Cpp.h`), ImGui, MinHook, and build scripts.
- `CheatDev/Il2CppDumper/`: The dumper used to extract game metadata and offsets.
- `Grapples Galore_Data/`: Contains the game assets (tracked via Git LFS).

## Credits
- Built with ❤️ for LO.
- Powered by MinHook and ImGui.
