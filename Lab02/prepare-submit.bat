@echo off
REM Script chuẩn bị nộp bài Lab02
REM Author: Pham Tan Gia Quoc - 23521308

echo ========================================
echo CHUẨN BỊ NỘP BÀI LAB02
echo 23521308 - Pham Tan Gia Quoc
echo ========================================
echo.

echo [1/5] Đang xóa thư mục bin/...
if exist bin rmdir /s /q bin
echo      ✓ Đã xóa bin/

echo [2/5] Đang xóa thư mục obj/...
if exist obj rmdir /s /q obj
echo      ✓ Đã xóa obj/

echo [3/5] Đang xóa thư mục .vs/...
if exist .vs rmdir /s /q .vs
echo      ✓ Đã xóa .vs/

echo [4/5] Đang xóa thư mục packages/...
if exist packages rmdir /s /q packages
echo      ✓ Đã xóa packages/
echo      (Packages sẽ được restore lại khi build)

echo [5/5] Đang xóa các file tạm...
del /q *.user 2>nul
del /q *.suo 2>nul
del /q *.cache 2>nul
echo      ✓ Đã xóa file tạm

echo.
echo ========================================
echo HOÀN TẤT!
echo ========================================
echo.

echo Các file/thư mục CÒN LẠI (cần nộp):
echo ✓ Lab02.sln
echo ✓ Lab02.csproj
echo ✓ Tất cả file .cs (source code)
echo ✓ Tất cả file .Designer.cs
echo ✓ Tất cả file .resx
echo ✓ App.config, packages.config
echo ✓ input5.txt
echo ✓ Properties/
echo ✓ Tất cả file .md (documentation)
echo.

echo Các thư mục ĐÃ XÓA (không cần nộp):
echo ✗ bin/ (file thực thi - sẽ build lại)
echo ✗ obj/ (file tạm)
echo ✗ .vs/ (Visual Studio cache)
echo ✗ packages/ (NuGet - sẽ restore lại)
echo.

echo ========================================
echo BƯỚC TIẾP THEO:
echo ========================================
echo.
echo 1. Nhấp chuột phải vào thư mục Lab02
echo 2. Chọn "Send to" ^> "Compressed (zipped) folder"
echo 3. Đặt tên: 23521308_PhamTanGiaQuoc_Lab02.zip
echo.
echo 4. Kiểm tra file .zip:
echo    - Mở file .zip
echo    - Đảm bảo có Lab02.sln
echo    - Đảm bảo có tất cả file .cs
echo    - Đảm bảo có input5.txt
echo    - Đảm bảo KHÔNG có bin/, obj/, .vs/
echo.
echo 5. Kích thước file .zip nên ^< 5MB
echo.
echo 6. NỘP file .zip cho giáo viên
echo.

echo ========================================
echo LƯU Ý:
echo ========================================
echo - KHÔNG CHỈ nộp file .exe!
echo - Phải nộp TOÀN BỘ source code
echo - Giáo viên sẽ build lại từ source code
echo - Đọc file SUBMIT_GUIDE.md để biết thêm chi tiết
echo.

pause
