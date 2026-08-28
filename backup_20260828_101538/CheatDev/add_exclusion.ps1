# Run this script as Administrator to add this project folder to Windows Defender exclusions

$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Definition

# Check for Administrator privileges
$isAdmin = ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)

if (-not $isAdmin) {
    Write-Host "Elevating privileges to Administrator..." -ForegroundColor Yellow
    Start-Process powershell.exe -Verb RunAs -ArgumentList "-NoProfile -ExecutionPolicy Bypass -File `"$PSCommandPath`""
    Exit
}

try {
    Add-MpPreference -ExclusionPath $scriptDir
    Write-Host "[+] Successfully added folder exclusion to Windows Defender:" -ForegroundColor Green
    Write-Host "    $scriptDir" -ForegroundColor Cyan
} catch {
    Write-Host "[-] Failed to add exclusion: $_" -ForegroundColor Red
}

Write-Host "`nPress any key to close..."
[void][System.Console]::ReadKey()
