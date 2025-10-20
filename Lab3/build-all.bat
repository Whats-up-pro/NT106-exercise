@echo off
echo ================================================
echo   LAB 3 - BUILD ALL PROJECTS
echo   Hom Nay An Gi? - SQLite ^& Server-Client
echo ================================================
echo.

echo [1/3] Building Bai6_HomNayAnGi_SQLite...
cd Bai6_HomNayAnGi_SQLite
dotnet restore
dotnet build -c Release
if %errorlevel% neq 0 (
    echo ERROR: Bai6 build failed!
    pause
    exit /b 1
)
echo [SUCCESS] Bai6 built successfully!
echo.
cd ..

echo [2/3] Building Bai7_Server...
cd Bai7_Server
dotnet restore
dotnet build -c Release
if %errorlevel% neq 0 (
    echo ERROR: Server build failed!
    pause
    exit /b 1
)
echo [SUCCESS] Server built successfully!
echo.
cd ..

echo [3/3] Building Bai7_Client...
cd Bai7_Client
dotnet restore
dotnet build -c Release
if %errorlevel% neq 0 (
    echo ERROR: Client build failed!
    pause
    exit /b 1
)
echo [SUCCESS] Client built successfully!
echo.
cd ..

echo ================================================
echo   ALL PROJECTS BUILT SUCCESSFULLY!
echo ================================================
echo.
echo Executables location:
echo   Bai6: Bai6_HomNayAnGi_SQLite\bin\Release\net9.0-windows\
echo   Server: Bai7_Server\bin\Release\net9.0-windows\
echo   Client: Bai7_Client\bin\Release\net9.0-windows\
echo.
pause
