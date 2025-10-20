@echo off
echo ================================================
echo   LAB 3 - RUN BAI 7 SERVER
echo ================================================
echo.

cd Bai7_Server

echo Restoring dependencies...
dotnet restore

echo Starting Server...
echo NOTE: Click "Start Server" button after the window opens
echo.
dotnet run

cd ..
pause
