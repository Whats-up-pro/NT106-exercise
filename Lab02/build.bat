@echo off
echo ========================================
echo Lab02 - Build Script
echo 23521308 - Pham Tan Gia Quoc
echo ========================================
echo.

echo Checking for Visual Studio...
where msbuild >nul 2>&1
if %ERRORLEVEL% NEQ 0 (
    echo Error: MSBuild not found. Please run this from Visual Studio Developer Command Prompt
    echo Or install Visual Studio Build Tools
    pause
    exit /b 1
)

echo.
echo Step 1: Restoring NuGet packages...
echo Note: If this fails, please open the solution in Visual Studio
echo and right-click on Solution -> Restore NuGet Packages

:: Try to restore packages
msbuild Lab02.sln /t:restore /p:Configuration=Debug
if %ERRORLEVEL% NEQ 0 (
    echo.
    echo Warning: Package restore failed. You may need to:
    echo 1. Open Lab02.sln in Visual Studio
    echo 2. Right-click on Solution and select "Restore NuGet Packages"
    echo 3. Or install Newtonsoft.Json manually via Package Manager Console:
    echo    Install-Package Newtonsoft.Json -Version 13.0.3
    echo.
)

echo.
echo Step 2: Building solution...
msbuild Lab02.sln /p:Configuration=Debug /p:Platform="Any CPU"

if %ERRORLEVEL% EQU 0 (
    echo.
    echo ========================================
    echo Build successful!
    echo ========================================
    echo.
    echo Executable location: bin\Debug\Lab02.exe
    echo.
    echo To run the application:
    echo 1. Make sure input5.txt is in bin\Debug\ folder
    echo 2. Run bin\Debug\Lab02.exe
    echo 3. Choose Server or Client mode
    echo.
) else (
    echo.
    echo ========================================
    echo Build failed!
    echo ========================================
    echo.
    echo Please check the error messages above.
    echo Common issues:
    echo - Missing Newtonsoft.Json package
    echo - Missing .NET Framework 4.7.2
    echo.
    echo Try opening Lab02.sln in Visual Studio and building from there.
    echo.
)

pause
