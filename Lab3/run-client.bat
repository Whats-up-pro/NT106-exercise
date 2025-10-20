@echo off
echo ================================================
echo   LAB 3 - RUN BAI 7 CLIENT
echo ================================================
echo.

cd Bai7_Client

echo Restoring dependencies...
dotnet restore

echo Starting Client...
echo NOTE: Make sure Server is running first!
echo.
dotnet run

cd ..
pause
