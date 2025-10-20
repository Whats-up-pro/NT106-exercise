@echo off
echo ================================================
echo   LAB 3 - RUN BAI 6 (SQLite Version)
echo ================================================
echo.

cd Bai6_HomNayAnGi_SQLite

echo Restoring dependencies...
dotnet restore

echo Running application...
dotnet run

cd ..
pause
