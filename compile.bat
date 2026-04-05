@echo off
echo Compiling OpenClaw C# Service...
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /out:OpenClawService.exe Program.cs
if exist OpenClawService.exe (
    echo ✅ Service compiled successfully!
    echo.
    echo To start: OpenClawService.exe
) else (
    echo ❌ Compilation failed!
)
pause
