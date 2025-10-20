# HƯỚNG DẪN BUILD PROJECT - CÁCH ĐƠN GIẢN NHẤT

## CÁCH 1: SỬ DỤNG VISUAL STUDIO (KHUYẾN NGHỊ) ⭐

### Bước 1: Mở Solution
```
1. Nhấn đúp vào file: Lab02.sln
2. Visual Studio sẽ tự động mở
3. Đợi Visual Studio load xong
```

### Bước 2: Restore NuGet Packages
```
Cách A (Tự động):
- Visual Studio thường tự động restore packages
- Nếu thấy thông báo "Some NuGet packages are missing", 
  click "Restore"

Cách B (Thủ công):
- Nhấp chuột phải vào Solution trong Solution Explorer
- Chọn "Restore NuGet Packages"
- Đợi quá trình hoàn tất (xem Output window)
```

### Bước 3: Build Solution
```
Cách A: Phím tắt
- Nhấn: Ctrl + Shift + B

Cách B: Menu
- Build → Build Solution

Cách C: Toolbar
- Click nút "Build Solution" trên toolbar
```

### Bước 4: Kiểm tra kết quả
```
- Nếu thành công, Output window hiển thị:
  "Build succeeded"
  "0 Error(s)"
  
- File thực thi tạo ra:
  bin\Debug\Lab02.exe
```

---

## CÁCH 2: SỬ DỤNG DEVELOPER COMMAND PROMPT

Nếu bạn muốn dùng command line:

### Bước 1: Mở Developer Command Prompt
```
1. Nhấn Windows + S
2. Tìm: "Developer Command Prompt for VS"
3. Click để mở
```

### Bước 2: Di chuyển đến thư mục project
```cmd
cd "d:\HK1_2025-2026\NT106.Q11.ANTT - LTM căn bản\Thực hành\Lab02"
```

### Bước 3: Restore packages
```cmd
msbuild /t:restore
```

### Bước 4: Build solution
```cmd
msbuild Lab02.sln /p:Configuration=Debug /p:Platform="Any CPU"
```

---

## CÁCH 3: SỬ DỤNG DOTNET CLI (Nếu có)

### Kiểm tra dotnet CLI
```bash
dotnet --version
```

### Nếu có dotnet:
```bash
cd "d:\HK1_2025-2026\NT106.Q11.ANTT - LTM căn bản\Thực hành\Lab02"
dotnet restore Lab02.sln
dotnet build Lab02.sln --configuration Debug
```

---

## XỬ LÝ LỖI THƯỜNG GẶP

### Lỗi: "Newtonsoft.Json not found"
```
Giải pháp:
1. Mở Package Manager Console trong Visual Studio
   (Tools → NuGet Package Manager → Package Manager Console)
2. Chạy lệnh:
   Install-Package Newtonsoft.Json -Version 13.0.3
3. Build lại
```

### Lỗi: "MSBuild not found" trong bash
```
Giải pháp:
- Không dùng bash/PowerShell thông thường
- Phải dùng "Developer Command Prompt for VS"
- Hoặc dùng Visual Studio trực tiếp
```

### Lỗi: "Target framework not found"
```
Giải pháp:
- Cài đặt .NET Framework 4.7.2 SDK
- Hoặc sửa targetFramework trong Lab02.csproj thành version đã cài
```

---

## SAU KHI BUILD THÀNH CÔNG

### Kiểm tra file output:
```bash
ls bin/Debug/
```

Bạn sẽ thấy:
- Lab02.exe (file chính)
- Lab02.pdb (debug symbols)
- Newtonsoft.Json.dll
- System.Data.SQLite.dll
- Các file khác

### Chạy ứng dụng:
```bash
# Cách 1: Double-click
bin/Debug/Lab02.exe

# Cách 2: Từ command line
cd bin/Debug
./Lab02.exe

# Cách 3: Từ Visual Studio
Nhấn F5 hoặc Ctrl+F5
```

---

## CHECKLIST TRƯỚC KHI BUILD

✅ Visual Studio đã được cài đặt
✅ .NET Framework 4.7.2 (hoặc cao hơn) đã được cài
✅ File Lab02.sln tồn tại
✅ File input5.txt đã sẵn sàng (sẽ copy sau)
✅ Đủ dung lượng đĩa (~100MB cho build output)

---

## KHUYẾN NGHỊ

🎯 **Nên dùng CÁCH 1 (Visual Studio)**:
- Dễ dàng nhất
- Tự động restore packages
- Có IntelliSense và debugging
- Hiển thị lỗi rõ ràng
- Không cần lo về PATH environment

❌ **Không nên dùng bash thông thường**:
- MSBuild không có trong PATH
- Cần config phức tạp
- Dễ gặp lỗi

---

**Nếu gặp vấn đề, hãy:**
1. Chụp màn hình lỗi
2. Copy toàn bộ thông báo lỗi
3. Hỏi lại với thông tin chi tiết

**Author:** Phạm Tấn Gia Quốc - 23521308
