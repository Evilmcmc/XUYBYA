#!/bin/bash
set -e

# Clone ImGui
if [ ! -d "imgui" ]; then
    echo "Cloning ImGui..."
    git clone --depth 1 -b docking https://github.com/ocornut/imgui.git
fi

# Clone MinHook
if [ ! -d "minhook" ]; then
    echo "Cloning MinHook..."
    git clone --depth 1 https://github.com/TsudaKageyu/minhook.git
fi

echo "Compiling Cheat.dll..."

# Compile everything using Mingw cross-compiler
x86_64-w64-mingw32-g++ -shared -static -static-libgcc -static-libstdc++ \
    -Iimgui -Iimgui/backends -Iminhook/include \
    dllmain.cpp \
    imgui/imgui.cpp \
    imgui/imgui_draw.cpp \
    imgui/imgui_tables.cpp \
    imgui/imgui_widgets.cpp \
    imgui/backends/imgui_impl_win32.cpp \
    imgui/backends/imgui_impl_dx11.cpp \
    minhook/src/buffer.c \
    minhook/src/hde/hde32.c \
    minhook/src/hde/hde64.c \
    minhook/src/hook.c \
    minhook/src/trampoline.c \
    -o Cheat.dll \
    -ld3d11 -ldxgi -lgdi32 -ldwmapi -ld3dcompiler

echo "Cheat.dll built successfully!"
