#!/bin/bash
set -e

# ─── Clone dependencies if missing ───────────────────────────────────────────
if [ ! -d "imgui" ]; then
    echo "[*] Cloning ImGui (docking branch)..."
    git clone --depth 1 -b docking https://github.com/ocornut/imgui.git
fi

if [ ! -d "minhook" ]; then
    echo "[*] Cloning MinHook..."
    git clone --depth 1 https://github.com/TsudaKageyu/minhook.git
fi

# ─── Detect compiler ─────────────────────────────────────────────────────────
# On Windows: use Windhawk clang (AppLocker-safe, signed, in Program Files)
# On Linux:   use x86_64-w64-mingw32-g++ cross-compiler
WINDHAWK_CLANG="/c/Program Files/Windhawk/Compiler/bin/x86_64-w64-mingw32-g++.exe"
MINGW_GXX="x86_64-w64-mingw32-g++"

if [ -f "$WINDHAWK_CLANG" ]; then
    echo "[*] Using Windhawk clang (Windows)"
    CXX="clang++"
    TARGET_FLAGS="-fuse-ld=lld --target=x86_64-w64-windows-gnu"
    EXTRA_FLAGS=""
else
    echo "[*] Using MinGW cross-compiler (Linux)"
    CXX="$MINGW_GXX"
    TARGET_FLAGS=""
    EXTRA_FLAGS=""
fi

FLAGS="$TARGET_FLAGS -shared -static-libgcc -static-libstdc++ -O2 -std=c++17"
INCLUDES="-I. -Iimgui -Iimgui/backends -Iminhook/include"
LIBS="-ld3d11 -ldxgi -lgdi32 -ldwmapi -ld3dcompiler"

IMGUI_SRC="imgui/imgui.cpp \
           imgui/imgui_draw.cpp \
           imgui/imgui_tables.cpp \
           imgui/imgui_widgets.cpp \
           imgui/backends/imgui_impl_win32.cpp \
           imgui/backends/imgui_impl_dx11.cpp"

# MinHook C files — compile as C to avoid deprecation warnings
MINHOOK_SRC="minhook/src/buffer.c \
             minhook/src/hde/hde32.c \
             minhook/src/hde/hde64.c \
             minhook/src/hook.c \
             minhook/src/trampoline.c"

# ─── Build Cheat.dll ──────────────────────────────────────────────────────────
echo "[*] Compiling Cheat.dll..."
"$CXX" $FLAGS $INCLUDES -Isrc \
    dllmain.cpp \
    src/core/Config.cpp \
    src/sdk/GameSDK.cpp \
    src/hooks/Hooks.cpp \
    src/features/Combat.cpp \
    src/features/Exploits.cpp \
    src/features/Visuals.cpp \
    src/gui/Menu.cpp \
    $IMGUI_SRC \
    $MINHOOK_SRC \
    -o Cheat.dll \
    $LIBS
echo "[+] Cheat.dll built OK"

# ─── Build Injector.exe ───────────────────────────────────────────────────────
echo "[*] Compiling Injector.exe..."
if [ -f "$WINDHAWK_CLANG" ]; then
    "$CXX" $TARGET_FLAGS -static-libgcc -static-libstdc++ -O2 -std=c++17 -mconsole \
        injector.cpp -o Injector.exe -lkernel32 -luser32
else
    x86_64-w64-mingw32-g++ -static -static-libgcc -static-libstdc++ -O2 -std=c++17 \
        injector.cpp -o Injector.exe -lkernel32 -luser32
fi
echo "[+] Injector.exe built OK"

echo ""
echo "=== Build complete ==="
echo "  Cheat.dll    — inject into Grapples Galore.exe"
echo "  Injector.exe — run first, then launch the game (or vice versa)"
echo "  F1 in-game   — open menu"
