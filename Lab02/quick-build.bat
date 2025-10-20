@echo off
REM Quick Build Script for Lab02
REM Author: Pham Tan Gia Quoc - 23521308

echo ========================================
echo Building Lab02 Project...
echo ========================================
echo.

"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" Lab02.sln /p:Configuration=Debug /p:Platform="Any CPU" /v:minimal

if %ERRORLEVEL% EQU 0 (
    echo.
    echo ========================================
    echo BUILD SUCCESS!
    echo ========================================
    echo.
    echo Executable: bin\Debug\Lab02.exe
    echo.
    echo Next steps:
    echo 1. Copy input5.txt to bin\Debug\
    echo 2. Run: bin\Debug\Lab02.exe
    echo.
) else (
    echo.
    echo ========================================
    echo BUILD FAILED!
    echo ========================================
    echo.
    echo Check the errors above.
    echo.
)

pause
