// XUYBYA Cyberpunk Styled Injector — Grapples Galore
// Dynamic status UI, UTF-8 borders, VT100 colors, process crash telemetry & file logging

#include <windows.h>
#include <tlhelp32.h>
#include <cstdio>
#include <cstring>
#include <string>
#include <cstdarg>

// ─── Thread-Safe File Logging ────────────────────────────────────────────────
static std::string GetInjectorLogPath() {
    char path[MAX_PATH] = {};
    GetModuleFileNameA(NULL, path, MAX_PATH);
    char* slash = strrchr(path, '\\');
    if (slash) *(slash + 1) = '\0';
    strncat(path, "XUYBYA_Injector.log", sizeof(path) - strlen(path) - 1);
    return path;
}

static void InjectorLog(const char* fmt, ...) {
    SYSTEMTIME st;
    GetLocalTime(&st);

    char timeBuf[32];
    snprintf(timeBuf, sizeof(timeBuf), "[%02d:%02d:%02d.%03d] ",
             st.wHour, st.wMinute, st.wSecond, st.wMilliseconds);

    char msgBuf[1024];
    va_list args;
    va_start(args, fmt);
    vsnprintf(msgBuf, sizeof(msgBuf), fmt, args);
    va_end(args);

    std::string logPath = GetInjectorLogPath();
    FILE* f = fopen(logPath.c_str(), "a");
    if (f) {
        fprintf(f, "%s%s\n", timeBuf, msgBuf);
        fflush(f);
        fclose(f);
    }
}

// ─── Setup Console for Virtual Terminal (ANSI / RGB) ─────────────────────────
static void InitConsole() {
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);

    HANDLE hOut = GetStdHandle(STD_OUTPUT_HANDLE);
    DWORD dwMode = 0;
    GetConsoleMode(hOut, &dwMode);
    dwMode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING;
    SetConsoleMode(hOut, dwMode);

    SetConsoleTitleA("XUYBYA // Internal Injector Suite");

    // Resize console window for a clean dashboard look
    HWND console = GetConsoleWindow();
    if (console) {
        RECT r;
        GetWindowRect(console, &r);
        MoveWindow(console, r.left, r.top, 820, 560, TRUE);
    }
}

// ─── ANSI Colors & Styles ───────────────────────────────────────────────────
#define C_RESET     "\033[0m"
#define C_BOLD      "\033[1m"
#define C_DIM       "\033[2m"
#define C_RED       "\033[38;2;255;85;85m"
#define C_GREEN     "\033[38;2;80;250;123m"
#define C_YELLOW    "\033[38;2;241;250;140m"
#define C_BLUE      "\033[38;2;98;114;164m"
#define C_PURPLE    "\033[38;2;189;147;249m"
#define C_CYAN      "\033[38;2;139;233;253m"
#define C_MAGENTA   "\033[38;2;255;121;198m"
#define C_WHITE     "\033[38;2;248;248;242m"
#define C_GRAY      "\033[38;2;90;90;110m"

static void PrintHeader() {
    system("cls");
    printf(C_CYAN C_BOLD
        "\n"
        "  ┌────────────────────────────────────────────────────────────────────────┐\n"
        "  │                                                                        │\n"
        "  │   ██╗  ██╗██╗   ██╗██╗   ██╗██████╗ ██╗   ██╗ █████╗                   │\n"
        "  │   ╚██╗██╔╝██║   ██║╚██╗ ██╔╝██╔══██╗╚██╗ ██╔╝██╔══██╗                  │\n"
        "  │    ╚███╔╝ ██║   ██║ ╚████╔╝ ██████╔╝ ╚████╔╝ ███████║                  │\n"
        "  │    ██╔██╗ ██║   ██║  ╚██╔╝  ██╔══██╗  ╚██╔╝  ██╔══██║                  │\n"
        "  │   ██╔╝ ██╗╚██████╔╝   ██║   ██████╔╝   ██║   ██║  ██║                  │\n"
        "  │   ╚═╝  ╚═╝ ╚═════╝    ╚═╝   ╚═════╝    ╚═╝   ╚═╝  ╚═╝                  │\n"
        "  │                                                                        │\n"
        "  │   " C_PURPLE "► GRAPPLES GALORE // ADVANCED INTERNAL INJECTOR SUITE" C_CYAN "               │\n"
        "  └────────────────────────────────────────────────────────────────────────┘\n"
        C_RESET "\n"
    );
}

// ─── Find PID by process name ─────────────────────────────────────────────────
static DWORD GetPIDByName(const wchar_t* name) {
    HANDLE snap = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
    if (snap == INVALID_HANDLE_VALUE) return 0;

    PROCESSENTRY32W pe = { sizeof(pe) };
    DWORD pid = 0;

    if (Process32FirstW(snap, &pe)) {
        do {
            if (_wcsicmp(pe.szExeFile, name) == 0) {
                pid = pe.th32ProcessID;
                break;
            }
        } while (Process32NextW(snap, &pe));
    }

    CloseHandle(snap);
    return pid;
}

// ─── Check if DLL is already loaded in target process ────────────────────────
static bool IsDLLLoaded(DWORD pid, const char* dllBasename) {
    HANDLE snap = CreateToolhelp32Snapshot(TH32CS_SNAPMODULE | TH32CS_SNAPMODULE32, pid);
    if (snap == INVALID_HANDLE_VALUE) return false;

    MODULEENTRY32 me = { sizeof(me) };
    bool found = false;

    if (Module32First(snap, &me)) {
        do {
            if (_stricmp(me.szModule, dllBasename) == 0) {
                found = true;
                break;
            }
        } while (Module32Next(snap, &me));
    }

    CloseHandle(snap);
    return found;
}

// ─── Enable SeDebugPrivilege so we can open protected processes ──────────────
static bool EnableDebugPrivilege() {
    HANDLE hToken;
    if (!OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, &hToken))
        return false;

    LUID luid;
    if (!LookupPrivilegeValueA(NULL, SE_DEBUG_NAME, &luid)) {
        CloseHandle(hToken);
        return false;
    }

    TOKEN_PRIVILEGES tp = {};
    tp.PrivilegeCount           = 1;
    tp.Privileges[0].Luid       = luid;
    tp.Privileges[0].Attributes = SE_PRIVILEGE_ENABLED;

    bool ok = AdjustTokenPrivileges(hToken, FALSE, &tp, sizeof(tp), NULL, NULL)
              && GetLastError() == ERROR_SUCCESS;
    CloseHandle(hToken);
    return ok;
}

// ─── Core injection with stepped visual output and error logging ─────────────
static bool Inject(DWORD pid, const char* dllPath, HANDLE* outProcessHandle) {
    InjectorLog("Starting injection into PID %lu with DLL '%s'", pid, dllPath);

    printf(C_GRAY "  ├─ " C_WHITE "Acquiring process handle (PID: %lu)... " C_RESET, pid);
    HANDLE hProc = OpenProcess(
        PROCESS_CREATE_THREAD | PROCESS_VM_OPERATION |
        PROCESS_VM_WRITE | PROCESS_VM_READ | PROCESS_QUERY_INFORMATION | SYNCHRONIZE,
        FALSE, pid);

    if (!hProc) {
        DWORD err = GetLastError();
        printf(C_RED "[FAILED] (Error %lu)\n" C_RESET, err);
        InjectorLog("[-] OpenProcess failed with error %lu", err);
        return false;
    }
    printf(C_GREEN "[OK]\n" C_RESET);
    InjectorLog("[+] OpenProcess handle acquired (0x%p)", hProc);

    // Allocate memory for the DLL path string
    printf(C_GRAY "  ├─ " C_WHITE "Allocating remote memory in target... " C_RESET);
    SIZE_T pathLen = strlen(dllPath) + 1;
    LPVOID remotePath = VirtualAllocEx(hProc, NULL, pathLen,
                                       MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
    if (!remotePath) {
        DWORD err = GetLastError();
        printf(C_RED "[FAILED] (Error %lu)\n" C_RESET, err);
        InjectorLog("[-] VirtualAllocEx failed with error %lu", err);
        CloseHandle(hProc);
        return false;
    }
    printf(C_GREEN "[OK] (Addr: 0x%p)\n" C_RESET, remotePath);
    InjectorLog("[+] VirtualAllocEx allocated buffer at 0x%p (size: %zu)", remotePath, pathLen);

    // Write DLL path into target process
    printf(C_GRAY "  ├─ " C_WHITE "Writing payload path to target space... " C_RESET);
    if (!WriteProcessMemory(hProc, remotePath, dllPath, pathLen, NULL)) {
        DWORD err = GetLastError();
        printf(C_RED "[FAILED] (Error %lu)\n" C_RESET, err);
        InjectorLog("[-] WriteProcessMemory failed with error %lu", err);
        VirtualFreeEx(hProc, remotePath, 0, MEM_RELEASE);
        CloseHandle(hProc);
        return false;
    }
    printf(C_GREEN "[OK]\n" C_RESET);
    InjectorLog("[+] WriteProcessMemory wrote DLL path string successfully");

    // CreateRemoteThread → LoadLibraryA(dllPath)
    printf(C_GRAY "  ├─ " C_WHITE "Spawning remote execution thread... " C_RESET);
    LPTHREAD_START_ROUTINE loadLib = (LPTHREAD_START_ROUTINE)
        GetProcAddress(GetModuleHandleA("kernel32.dll"), "LoadLibraryA");

    HANDLE hThread = CreateRemoteThread(hProc, NULL, 0, loadLib, remotePath, 0, NULL);
    if (!hThread) {
        DWORD err = GetLastError();
        printf(C_RED "[FAILED] (Error %lu)\n" C_RESET, err);
        InjectorLog("[-] CreateRemoteThread failed with error %lu", err);
        VirtualFreeEx(hProc, remotePath, 0, MEM_RELEASE);
        CloseHandle(hProc);
        return false;
    }
    printf(C_GREEN "[OK]\n" C_RESET);
    InjectorLog("[+] Remote thread spawned (Handle: 0x%p)", hThread);

    // Wait for LoadLibrary to return
    printf(C_GRAY "  ├─ " C_WHITE "Awaiting DLL initialization... " C_RESET);
    WaitForSingleObject(hThread, 8000);

    DWORD exitCode = 0;
    GetExitCodeThread(hThread, &exitCode);

    CloseHandle(hThread);
    VirtualFreeEx(hProc, remotePath, 0, MEM_RELEASE);

    // Verify DLL was loaded via module snapshot (handles full 64-bit base addresses)
    if (!IsDLLLoaded(pid, "Cheat.dll") && exitCode == 0) {
        printf(C_RED "[FAILED] (LoadLibrary returned NULL / 0x0)\n" C_RESET);
        InjectorLog("[-] LoadLibrary returned NULL in target process!");
        CloseHandle(hProc);
        return false;
    }
    printf(C_GREEN "[OK] (Module Loaded Successfully)\n" C_RESET);
    InjectorLog("[+] Injection successful! Cheat.dll active in target PID %lu", pid);

    if (outProcessHandle) {
        *outProcessHandle = hProc;
    } else {
        CloseHandle(hProc);
    }
    return true;
}

// ─── Build absolute DLL path relative to this .exe ───────────────────────────
static void GetDLLPath(char* out, SIZE_T outLen) {
    GetModuleFileNameA(NULL, out, (DWORD)outLen);
    char* slash = strrchr(out, '\\');
    if (slash) *(slash + 1) = '\0';
    strncat(out, "Cheat.dll", outLen - strlen(out) - 1);
}

// ─── Entry Point ─────────────────────────────────────────────────────────────
int main() {
    InitConsole();
    PrintHeader();

    InjectorLog("========================================================");
    InjectorLog("★ XUYBYA Injector Suite Launched");
    InjectorLog("========================================================");

    const wchar_t* TARGET_PROCESS = L"Grapples Galore.exe";
    const char*    DLL_BASENAME   = "Cheat.dll";

    char dllPath[MAX_PATH] = {};
    GetDLLPath(dllPath, MAX_PATH);

    // Dashboard Info Card
    printf(C_CYAN "  [ SYSTEM STATUS ]\n" C_RESET);
    printf(C_GRAY "  ├─ " C_WHITE "Target App    : " C_YELLOW "%ls\n" C_RESET, TARGET_PROCESS);
    printf(C_GRAY "  ├─ " C_WHITE "Architecture  : " C_PURPLE "x86_64 (DirectX 11 / IL2CPP)\n" C_RESET);
    printf(C_GRAY "  ├─ " C_WHITE "Privileges    : " C_GREEN "%s\n" C_RESET, EnableDebugPrivilege() ? "SeDebugPrivilege [ACTIVE]" : "Standard");
    printf(C_GRAY "  ├─ " C_WHITE "Logs Target   : " C_CYAN "XUYBYA_Injector.log & XUYBYA_Cheat.log\n" C_RESET);
    printf(C_GRAY "  └─ " C_WHITE "Binary Module : " C_CYAN "%s\n\n" C_RESET, dllPath);

    // Verify DLL exists on disk
    if (GetFileAttributesA(dllPath) == INVALID_FILE_ATTRIBUTES) {
        printf(C_RED "  [!] ERROR: Cheat.dll not found in directory!\n" C_RESET);
        printf(C_GRAY "      Please compile it first via build.ps1\n\n" C_RESET);
        InjectorLog("[-] Cheat.dll not found at '%s'", dllPath);
        goto done;
    }

    printf(C_YELLOW "  [*] Waiting for game instance to launch...\n" C_RESET);

    // Animated spinner
    {
        const char spinner[] = { '|', '/', '-', '\\' };
        int spinIdx = 0;
        HANDLE hGameProcess = NULL;

        while (true) {
            DWORD pid = GetPIDByName(TARGET_PROCESS);

            if (pid == 0) {
                printf("\r  " C_CYAN "[%c]" C_WHITE " Searching active processes...  " C_RESET, spinner[spinIdx % 4]);
                fflush(stdout);
                spinIdx++;
                Sleep(200);
                continue;
            }

            printf("\r  " C_GREEN "[✔] Game Process Detected!  PID: " C_WHITE "%lu          \n\n" C_RESET, pid);
            InjectorLog("[+] Game process found: PID %lu", pid);

            // Progress bar while D3D initializes
            printf(C_YELLOW "  [*] Initializing DirectX & IL2CPP Runtime Hooks:\n" C_RESET);
            for (int i = 1; i <= 25; i++) {
                printf("\r  [");
                for (int j = 0; j < i; j++) printf(C_CYAN "=" C_RESET);
                for (int j = i; j < 25; j++) printf(C_GRAY " " C_RESET);
                printf("] " C_WHITE "%d%%" C_RESET, i * 4);
                fflush(stdout);
                Sleep(80);
            }
            printf("\n\n");

            // Check if already injected
            if (IsDLLLoaded(pid, DLL_BASENAME)) {
                printf(C_YELLOW "  [!] Module 'Cheat.dll' is already active in target process.\n" C_RESET);
                InjectorLog("[!] Module 'Cheat.dll' already present in PID %lu", pid);
                goto done;
            }

            printf(C_CYAN "  [ INJECTION SEQUENCE ]\n" C_RESET);
            if (Inject(pid, dllPath, &hGameProcess)) {
                printf(C_GREEN C_BOLD
                    "\n"
                    "  ┌────────────────────────────────────────────────────────────────────────┐\n"
                    "  │                                                                        │\n"
                    "  │   ★ INJECTION SUCCESSFUL! CHEAT IS NOW FULLY ACTIVE!                   │\n"
                    "  │                                                                        │\n"
                    "  │   • Press " C_YELLOW "[INSERT]" C_GREEN " or " C_YELLOW "[F1]" C_GREEN " in-game to toggle GUI Menu                  │\n"
                    "  │   • Mass Kill Aura & Silent Aim are ready to obliterate enemies        │\n"
                    "  │   • Live logs active: XUYBYA_Cheat.log & XUYBYA_Crash.log              │\n"
                    "  │                                                                        │\n"
                    "  └────────────────────────────────────────────────────────────────────────┘\n"
                    C_RESET
                );

                // Telemetry / Crash Watcher loop
                printf(C_CYAN "\n  [*] Monitoring game process telemetry and crash state in background...\n" C_RESET);
                while (hGameProcess) {
                    DWORD waitRes = WaitForSingleObject(hGameProcess, 1000);
                    if (waitRes == WAIT_OBJECT_0) {
                        DWORD exitCode = 0;
                        GetExitCodeProcess(hGameProcess, &exitCode);
                        InjectorLog("========================================================");
                        InjectorLog("Game process PID %lu terminated with Exit Code: 0x%08lX", pid, exitCode);

                        if (exitCode != 0 && exitCode != 1) {
                            printf(C_RED C_BOLD "\n  [!] ALERT: Game process crashed or terminated with code: 0x%08lX\n" C_RESET, exitCode);
                            printf(C_YELLOW "      Please check 'XUYBYA_Crash.log' and 'XUYBYA_Cheat.log' for detailed crash dump.\n\n" C_RESET);
                        } else {
                            printf(C_GRAY "\n  [*] Game process closed normally (Exit Code: 0x%08lX).\n\n" C_RESET, exitCode);
                        }
                        CloseHandle(hGameProcess);
                        hGameProcess = NULL;
                        break;
                    }
                }
            } else {
                printf(C_RED C_BOLD "\n  [-] Injection failed. Ensure game is not running as another user.\n" C_RESET);
            }
            break;
        }
    }

done:
    printf(C_GRAY "\n  Press any key to close this console...\n" C_RESET);
    getchar();
    return 0;
}
