$cxx = "C:\Program Files\Windhawk\Compiler\bin\clang++.exe"

if (-not (Test-Path $cxx)) {
    Write-Host "[-] Clang compiler not found at: $cxx" -ForegroundColor Red
    Exit 1
}

$argsDll = @(
    "-fuse-ld=lld",
    "-target", "x86_64-w64-mingw32",
    "-shared",
    "-static-libgcc",
    "-static-libstdc++",
    "-O2",
    "-std=c++17",
    "-fms-extensions",
    "-Wno-deprecated",
    "-Iimgui",
    "-Iimgui/backends",
    "-Iminhook/include",
    "dllmain.cpp",
    "imgui/imgui.cpp",
    "imgui/imgui_draw.cpp",
    "imgui/imgui_tables.cpp",
    "imgui/imgui_widgets.cpp",
    "imgui/backends/imgui_impl_win32.cpp",
    "imgui/backends/imgui_impl_dx11.cpp",
    "minhook/src/buffer.c",
    "minhook/src/hde/hde32.c",
    "minhook/src/hde/hde64.c",
    "minhook/src/hook.c",
    "minhook/src/trampoline.c",
    "-o", "Cheat.dll",
    "-ld3d11",
    "-ldxgi",
    "-lgdi32",
    "-ldwmapi",
    "-ld3dcompiler"
)

Write-Host "[*] Compiling Cheat.dll..." -ForegroundColor Cyan
& $cxx $argsDll
if ($LASTEXITCODE -eq 0) {
    Write-Host "[+] Cheat.dll built successfully!" -ForegroundColor Green
} else {
    Write-Host "[-] Cheat.dll compilation failed!" -ForegroundColor Red
    Exit 1
}

$argsInj = @(
    "-fuse-ld=lld",
    "-target", "x86_64-w64-mingw32",
    "-static-libgcc",
    "-static-libstdc++",
    "-O2",
    "-std=c++17",
    "-mconsole",
    "injector.cpp",
    "-o", "Injector.exe",
    "-lkernel32",
    "-luser32"
)

Write-Host "[*] Compiling Injector.exe..." -ForegroundColor Cyan
& $cxx $argsInj
if ($LASTEXITCODE -eq 0) {
    Write-Host "[+] Injector.exe built successfully!" -ForegroundColor Green
} else {
    Write-Host "[-] Injector.exe compilation failed!" -ForegroundColor Red
    Exit 1
}

# Auto-sync to root folder
Copy-Item "Cheat.dll" "..\Cheat.dll" -Force -ErrorAction SilentlyContinue
Copy-Item "Injector.exe" "..\Injector.exe" -Force -ErrorAction SilentlyContinue

Write-Host "`n=== Build Complete ===" -ForegroundColor Green
