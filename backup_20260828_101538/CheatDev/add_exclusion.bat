@echo off
:: Batch wrapper to launch PowerShell with Administrator privileges and add Defender exclusion
powershell -Command "Start-Process powershell -Verb RunAs -ArgumentList '-NoProfile -ExecutionPolicy Bypass -File \"\"%~dp0add_exclusion.ps1\"\"'"
