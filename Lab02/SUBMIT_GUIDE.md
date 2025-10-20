# HƯỚNG DẪN NỘP BÀI - LAB02
## Phạm Tấn Gia Quốc - 23521308

---

## ⚠️ QUAN TRỌNG: CẦN NỘP GÌ?

### ❌ **KHÔNG** chỉ nộp file .exe
File `.exe` là file thực thi, giáo viên cần xem **source code** để chấm điểm!

### ✅ **CẦN NỘP** toàn bộ project

---

## 📦 CÁC CÁCH NỘP BÀI

### CÁCH 1: NỘP TOÀN BỘ THỦ MỤC PROJECT (Khuyến nghị)

#### Bước 1: Dọn dẹp project
```bash
# Xóa các file tạm, giữ lại source code
# QUAN TRỌNG: Làm điều này trước khi nén!
```

Xóa các thư mục/file không cần thiết:
- ✅ **Xóa:** `bin/` folder (file biên dịch)
- ✅ **Xóa:** `obj/` folder (file tạm)
- ✅ **Xóa:** `.vs/` folder (Visual Studio cache)
- ✅ **Xóa:** `packages/` folder (NuGet packages - sẽ restore lại được)
- ❌ **GIỮ LẠI:** Tất cả file `.cs`, `.csproj`, `.sln`
- ❌ **GIỮ LẠI:** Tất cả file `.resx`, `.config`
- ❌ **GIỮ LẠI:** File `input5.txt`
- ❌ **GIỮ LẠI:** Tất cả file `.md` (documentation)

#### Bước 2: Nén thư mục
```
1. Nhấp chuột phải vào thư mục Lab02
2. Chọn "Send to" → "Compressed (zipped) folder"
3. Đặt tên: 23521308_PhamTanGiaQuoc_Lab02.zip
```

#### Bước 3: Kiểm tra file nén
```
Mở file .zip và đảm bảo có:
✅ Lab02.sln
✅ Lab02.csproj
✅ Tất cả file .cs (ServerForm.cs, ClientForm.cs, etc.)
✅ Tất cả file .Designer.cs
✅ Tất cả file .resx
✅ input5.txt
✅ README.md và các tài liệu
✅ Properties/AssemblyInfo.cs
❌ KHÔNG có bin/, obj/, .vs/, packages/
```

---

### CÁCH 2: NỘP CHỈ FILES CẦN THIẾT (Nếu giới hạn dung lượng)

Tạo thư mục mới và copy các file sau:

#### Files bắt buộc:
```
Lab02_Submit/
├── Lab02.sln
├── Lab02.csproj
├── App.config
├── packages.config
├── input5.txt
│
├── Source Code (.cs files):
│   ├── Program.cs
│   ├── NetworkMessage.cs
│   ├── Phim.cs
│   ├── ServerForm.cs
│   ├── ClientForm.cs
│   ├── StartupForm.cs
│   └── Form5.cs (bài cũ - để tham khảo)
│
├── Designer Files (.Designer.cs):
│   ├── ServerForm.Designer.cs
│   ├── ClientForm.Designer.cs
│   ├── StartupForm.Designer.cs
│   └── Form5.Designer.cs
│
├── Resource Files (.resx):
│   ├── ServerForm.resx
│   ├── ClientForm.resx
│   ├── StartupForm.resx
│   └── Form5.resx
│
├── Properties/
│   ├── AssemblyInfo.cs
│   ├── Resources.Designer.cs
│   ├── Resources.resx
│   ├── Settings.Designer.cs
│   └── Settings.settings
│
└── Documentation/
    ├── README.md
    ├── HUONG_DAN_SU_DUNG.md
    └── TOM_TAT_DU_AN.md
```

Sau đó nén thư mục `Lab02_Submit` thành file `.zip`

---

### CÁCH 3: NỘP QUA GIT (Nếu được phép)

```bash
# 1. Tạo .gitignore
cat > .gitignore << EOL
bin/
obj/
.vs/
packages/
*.user
*.suo
*.cache
EOL

# 2. Init git repository
git init
git add .
git commit -m "Lab02 - Server-Client Ticket Management System"

# 3. Push lên GitHub (nếu được phép)
git remote add origin <your-repo-url>
git push -u origin main

# 4. Nộp link GitHub hoặc export .zip từ GitHub
```

---

## 📋 CHECKLIST TRƯỚC KHI NỘP

### Kiểm tra nội dung:
- [ ] File nén có tên đúng format: `MSSV_HoTen_Lab02.zip`
- [ ] Có đầy đủ file `.cs` (source code)
- [ ] Có file `.sln` và `.csproj`
- [ ] Có file `input5.txt` (dữ liệu test)
- [ ] Có file `README.md` (hướng dẫn)
- [ ] KHÔNG có thư mục `bin/`, `obj/`, `.vs/`
- [ ] KHÔNG có thư mục `packages/` (quá lớn, có thể restore lại)

### Kiểm tra build:
- [ ] Giải nén file .zip ra thư mục mới
- [ ] Mở Lab02.sln
- [ ] Restore NuGet Packages
- [ ] Build thành công
- [ ] Chạy được ứng dụng

### Kiểm tra tài liệu:
- [ ] README.md giải thích rõ ràng
- [ ] Có hướng dẫn build và chạy
- [ ] Có giải thích các tính năng
- [ ] Có tên, MSSV trong code và tài liệu

---

## 📝 NỘI DUNG FILE README.md (Tối thiểu)

```markdown
# LAB02 - SERVER-CLIENT TICKET MANAGEMENT SYSTEM
**Sinh viên:** Phạm Tấn Gia Quốc  
**MSSV:** 23521308  
**Lớp:** NT106.Q11.ANTT

## Mô tả
Hệ thống quản lý phòng vé với kiến trúc Server-Client...

## Cách build
1. Mở Lab02.sln trong Visual Studio
2. Restore NuGet Packages
3. Build Solution (Ctrl+Shift+B)

## Cách chạy
1. Chạy Server trước
2. Chạy Client(s)
3. Đặt vé và kiểm tra đồng bộ

## Tính năng
- Multi-client support
- Real-time synchronization
- Thread-safe booking
...
```

---

## 🎯 ĐỊNH DẠNG TÊN FILE NỘP

Theo chuẩn của trường/giáo viên:

### Format 1 (Chuẩn):
```
MSSV_HoTen_Lab02.zip
Ví dụ: 23521308_PhamTanGiaQuoc_Lab02.zip
```

### Format 2 (Nếu có yêu cầu khác):
```
Lab02_MSSV_HoTen.zip
Ví dụ: Lab02_23521308_PhamTanGiaQuoc.zip
```

### Format 3 (Nếu nộp nhiều file):
```
23521308_PhamTanGiaQuoc_Lab02/
├── SourceCode.zip
├── Documentation.pdf
└── BaoCao.docx
```

---

## ⚠️ LƯU Ý QUAN TRỌNG

### ❌ KHÔNG NÊN:
1. ❌ Chỉ nộp file `.exe` (giáo viên cần source code!)
2. ❌ Nộp cả thư mục `bin/`, `obj/` (quá lớn, không cần)
3. ❌ Nộp thư mục `packages/` (có thể restore lại)
4. ❌ Nộp file `.user`, `.suo` (settings cá nhân)
5. ❌ Code có lỗi biên dịch
6. ❌ Thiếu file `input5.txt` để test

### ✅ NÊN:
1. ✅ Nộp toàn bộ source code (.cs files)
2. ✅ Nộp file project (.sln, .csproj)
3. ✅ Có README.md hướng dẫn rõ ràng
4. ✅ Test lại sau khi giải nén
5. ✅ Có comment trong code
6. ✅ Có thông tin sinh viên (MSSV, họ tên)

---

## 📊 KÍCH THƯỚC FILE

### Nếu nộp đầy đủ (KHÔNG có bin/, obj/, packages/):
```
Dung lượng: ~500KB - 2MB
Bao gồm:
- Source code (.cs): ~100KB
- Designer files: ~50KB
- Resource files: ~50KB
- Documentation: ~100KB
- Project files: ~50KB
```

### Nếu có bin/ và packages/ (KHÔNG khuyến nghị):
```
Dung lượng: ~50MB - 100MB (QUÁ LỚN!)
Lý do: packages/Newtonsoft.Json + bin/Debug/
```

---

## 🛠️ SCRIPT TỰ ĐỘNG DọN DẸP VÀ NÉN

Tạo file `prepare-submit.bat`:

```batch
@echo off
echo ========================================
echo Chuẩn bị nộp bài Lab02
echo ========================================
echo.

echo Đang xóa các file tạm...
rmdir /s /q bin 2>nul
rmdir /s /q obj 2>nul
rmdir /s /q .vs 2>nul
rmdir /s /q packages 2>nul
del /q *.user 2>nul
del /q *.suo 2>nul

echo.
echo Hoàn tất! Project đã sẵn sàng để nén.
echo.
echo Bước tiếp theo:
echo 1. Nén thư mục Lab02 thành .zip
echo 2. Đặt tên: 23521308_PhamTanGiaQuoc_Lab02.zip
echo 3. Kiểm tra file .zip có đầy đủ source code
echo 4. Nộp file .zip
echo.
pause
```

Chạy script này trước khi nén!

---

## 📧 EMAIL NỘP BÀI (Nếu nộp qua email)

```
Tiêu đề: [NT106.Q11.ANTT] Lab02 - 23521308 - Phạm Tấn Gia Quốc

Nội dung:
Kính gửi Thầy/Cô,

Em là Phạm Tấn Gia Quốc - MSSV: 23521308

Em xin nộp bài Lab02 - Server-Client Ticket Management System.

Thông tin bài nộp:
- File đính kèm: 23521308_PhamTanGiaQuoc_Lab02.zip
- Nội dung: Source code + Documentation
- Ngôn ngữ: C# .NET Framework 4.7.2
- IDE: Visual Studio 2022

Hướng dẫn chạy:
1. Giải nén file .zip
2. Mở Lab02.sln trong Visual Studio
3. Restore NuGet Packages (Newtonsoft.Json)
4. Build và chạy

Em xin cảm ơn!

Trân trọng,
Phạm Tấn Gia Quốc
23521308
```

---

## ✅ FINAL CHECKLIST

Trước khi nộp, check lại:

- [ ] File có tên đúng format
- [ ] Đã xóa bin/, obj/, .vs/, packages/
- [ ] File .zip < 5MB
- [ ] Có đầy đủ source code
- [ ] Có README.md
- [ ] Có input5.txt
- [ ] Đã test: giải nén → build → chạy được
- [ ] Code có comment và thông tin sinh viên
- [ ] Không có lỗi biên dịch
- [ ] Đã đọc lại yêu cầu đề bài

---

## 🎓 KẾT LUẬN

**NỘP BÀI ĐÚNG CÁCH:**
```
23521308_PhamTanGiaQuoc_Lab02.zip
│
├── Lab02.sln
├── Lab02.csproj
├── Tất cả .cs files
├── Tất cả .Designer.cs files
├── Tất cả .resx files
├── input5.txt
├── README.md
└── Properties/...

KHÔNG có: bin/, obj/, .vs/, packages/
Dung lượng: < 5MB
```

**Chúc bạn nộp bài thành công!** 🎊

---

**Tác giả:** Phạm Tấn Gia Quốc - 23521308  
**Ngày:** October 20, 2025
