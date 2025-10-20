# 📦 HƯỚNG DẪN NỘP BÀI LAB 3

## 📋 Danh sách file cần nộp

### 🎯 **Phương án 1: Nộp đầy đủ (Khuyến nghị)**

Nén toàn bộ thư mục `Lab3` thành file `.zip` hoặc `.rar`:

```
Lab3.zip
└── Lab3/
    ├── Bai6_HomNayAnGi_SQLite/     (Toàn bộ project)
    ├── Bai7_Server/                (Toàn bộ project)
    ├── Bai7_Client/                (Toàn bộ project)
    ├── Bai8_ChatRoom_Server/       (Toàn bộ project)
    ├── Bai8_ChatRoom_Client/       (Toàn bộ project)
    ├── README.md
    ├── LAB3_TONG_HOP.md
    ├── BAI8_CHATROOM_README.md
    ├── HUONG_DAN_HINH_ANH.md
    ├── build-all.bat
    ├── run-*.bat                   (Các file script)
    └── HUONG_DAN_NOP_BAI.md       (File này)
```

**⚠️ QUAN TRỌNG - Loại bỏ các thư mục sau trước khi nén:**
- `bin/` (trong mỗi project)
- `obj/` (trong mỗi project)
- `.vs/` (nếu có)
- `*.user` files

---

### 🎯 **Phương án 2: Nộp từng bài riêng**

#### **Bài 6: Hôm nay ăn gì? (SQLite)**

**Nén thành:** `Bai6_HomNayAnGi.zip`

**Bao gồm:**
```
Bai6_HomNayAnGi_SQLite/
├── Database/
│   └── DatabaseHelper.cs
├── Models/
│   ├── MonAn.cs
│   └── NguoiDung.cs
├── MainForm.cs
├── MainForm.Designer.cs
├── MainForm.resx
├── NguoiDungForm.cs
├── NguoiDungForm.Designer.cs
├── NguoiDungForm.resx
├── Program.cs
└── Bai6_HomNayAnGi_SQLite.csproj
```

#### **Bài 7: Server-Client Hôm nay ăn gì?**

**Nén thành:** `Bai7_ServerClient.zip`

**Bao gồm:**
```
Bai7_Server/
├── Database/
│   └── DatabaseHelper.cs
├── Models/
│   ├── MonAn.cs
│   ├── NguoiDung.cs
│   └── Message.cs
├── TcpServer.cs
├── ServerForm.cs
├── ServerForm.Designer.cs
├── ServerForm.resx
├── Program.cs
└── Bai7_Server.csproj

Bai7_Client/
├── Network/
│   └── TcpClientHelper.cs
├── Models/
│   ├── MonAn.cs
│   ├── NguoiDung.cs
│   └── Message.cs
├── ClientForm.cs
├── ClientForm.Designer.cs
├── ClientForm.resx
├── DangKyForm.cs
├── DangKyForm.Designer.cs
├── DangKyForm.resx
├── Program.cs
└── Bai7_Client.csproj
```

#### **Bài 8: Chat Room**

**Nén thành:** `Bai8_ChatRoom.zip`

**Bao gồm:**
```
Bai8_ChatRoom_Server/
├── Models/
│   └── ChatMessage.cs
├── ChatServer.cs
├── ServerForm.cs
├── ServerForm.Designer.cs
├── ServerForm.resx
├── Program.cs
└── Bai8_ChatRoom_Server.csproj

Bai8_ChatRoom_Client/
├── Models/
│   └── ChatMessage.cs
├── ChatForm.cs
├── ChatForm.Designer.cs
├── ChatForm.resx
├── Program.cs
└── Bai8_ChatRoom_Client.csproj
```

---

### 📄 **File tài liệu bổ sung (nếu yêu cầu)**

```
- README.md                     (Tổng quan)
- LAB3_TONG_HOP.md             (Tổng hợp cả 3 bài)
- BAI8_CHATROOM_README.md      (Hướng dẫn Bài 8)
- HUONG_DAN_HINH_ANH.md        (Hướng dẫn hình ảnh Bài 7)
- TESTING.md                    (Test cases)
- CHANGELOG.md                  (Lịch sử thay đổi)
```

---

## 🚀 Cách tạo file nộp bài

### **Windows - Sử dụng File Explorer:**

1. Mở thư mục `Lab3`
2. **XÓA các thư mục không cần:**
   - Tìm tất cả thư mục `bin` → Xóa
   - Tìm tất cả thư mục `obj` → Xóa
   - Xóa thư mục `.vs` (nếu có)

3. **Nén thư mục:**
   - Click phải vào thư mục `Lab3`
   - Chọn "Send to" → "Compressed (zipped) folder"
   - Hoặc dùng WinRAR/7-Zip → "Add to archive..."

4. **Đặt tên file:**
   - `HoTen_MSSV_Lab3.zip`
   - Ví dụ: `NguyenVanA_22520001_Lab3.zip`

### **Windows - Sử dụng PowerShell:**

```powershell
# Di chuyển vào thư mục chứa Lab3
cd "D:\HK1_2025-2026\NT106.Q11.ANTT - LTM căn bản\Thực hành"

# Xóa bin, obj folders
Get-ChildItem -Path Lab3 -Include bin,obj,.vs -Recurse -Directory | Remove-Item -Recurse -Force

# Nén thư mục
Compress-Archive -Path Lab3 -DestinationPath Lab3_Submit.zip
```

### **Linux/Mac - Sử dụng terminal:**

```bash
# Di chuyển vào thư mục chứa Lab3
cd ~/NT106/ThucHanh

# Xóa bin, obj folders
find Lab3 -type d -name "bin" -exec rm -rf {} +
find Lab3 -type d -name "obj" -exec rm -rf {} +
find Lab3 -type d -name ".vs" -exec rm -rf {} +

# Nén thư mục
zip -r Lab3_Submit.zip Lab3 -x "*/bin/*" "*/obj/*" "*/.vs/*"
```

---

## ✅ Checklist trước khi nộp

### **1. Kiểm tra file code:**
- [ ] Tất cả file `.cs` có đầy đủ
- [ ] File `.csproj` có đầy đủ
- [ ] File `.Designer.cs` và `.resx` (cho Windows Forms) có đầy đủ
- [ ] Không có file `.user` (file cá nhân VS)

### **2. Kiểm tra thư mục:**
- [ ] **ĐÃ XÓA** thư mục `bin/`
- [ ] **ĐÃ XÓA** thư mục `obj/`
- [ ] **ĐÃ XÓA** thư mục `.vs/`
- [ ] Không có file database `.db` (sẽ tự tạo khi chạy)

### **3. Kiểm tra chạy được:**
- [ ] Build tất cả projects thành công
- [ ] Bài 6 chạy được standalone
- [ ] Bài 7 Server + Client kết nối được
- [ ] Bài 8 Server + nhiều Client chat được

### **4. Kiểm tra tài liệu:**
- [ ] Có file README.md giải thích
- [ ] Có hướng dẫn chạy
- [ ] Có giải thích chức năng

---

## 📝 Mẫu file README.md tối thiểu

Nếu giáo viên yêu cầu, tạo file `README.md` với nội dung:

```markdown
# LAB 3 - LẬP TRÌNH MẠNG CĂN BẢN

**Họ tên:** [Tên của bạn]  
**MSSV:** [MSSV của bạn]  
**Lớp:** NT106.Q11.ANTT

## Danh sách bài tập

### Bài 6: Hôm nay ăn gì? (SQLite)
- Quản lý món ăn và người dùng
- Sử dụng SQLite database
- Random món ăn

**Chạy:**
```
cd Bai6_HomNayAnGi_SQLite
dotnet run
```

### Bài 7: Server-Client Hôm nay ăn gì?
- Server quản lý database tập trung
- Client kết nối và thao tác
- Đăng ký user, thêm món ăn, random

**Chạy:**
```
# Terminal 1
cd Bai7_Server
dotnet run

# Terminal 2
cd Bai7_Client
dotnet run
```

### Bài 8: Chat Room
- Multi-client chat
- Public và private chat
- Gửi file và hình ảnh

**Chạy:**
```
# Terminal 1
cd Bai8_ChatRoom_Server
dotnet run

# Terminal 2, 3, 4...
cd Bai8_ChatRoom_Client
dotnet run
```

## Yêu cầu hệ thống
- .NET SDK 9.0
- Windows OS
```

---

## 📊 Kích thước file dự kiến

| Bài | Kích thước (đã nén) | Kích thước (chưa nén) |
|-----|---------------------|------------------------|
| Bài 6 | ~50-100 KB | ~200-300 KB |
| Bài 7 | ~100-150 KB | ~400-600 KB |
| Bài 8 | ~100-150 KB | ~400-600 KB |
| **Tổng cả 3 bài** | ~250-400 KB | ~1-1.5 MB |

**⚠️ Nếu file > 10 MB:** Có thể chưa xóa `bin/obj` folders!

---

## 📤 Cách nộp bài (theo hướng dẫn của giáo viên)

### **Phương án A: Nộp qua LMS/Moodle**
1. Đăng nhập LMS
2. Vào môn học NT106
3. Tìm Assignment "Lab 3"
4. Upload file `HoTen_MSSV_Lab3.zip`
5. Bấm Submit

### **Phương án B: Nộp qua Email**
1. Email đến: [email giáo viên]
2. Subject: `[NT106] Lab 3 - HoTen - MSSV`
3. Attach file `HoTen_MSSV_Lab3.zip`
4. Nội dung: Tóm tắt ngắn gọn

### **Phương án C: Nộp qua Google Drive**
1. Upload lên Drive
2. Share link (cho phép View)
3. Gửi link theo hướng dẫn của GV

---

## ⚠️ Lưu ý quan trọng

### **CẤM nộp:**
- ❌ Thư mục `bin/` và `obj/`
- ❌ File `.user` (cá nhân Visual Studio)
- ❌ File `.db` (database, sẽ tự tạo)
- ❌ Thư mục `.vs/` (Visual Studio cache)
- ❌ File có dung lượng > 5MB mỗi file

### **BẮT BUỘC có:**
- ✅ Tất cả file `.cs`
- ✅ File `.csproj` (project file)
- ✅ File `.Designer.cs` và `.resx` (cho Forms)
- ✅ File README hoặc hướng dẫn

### **Kiểm tra lại:**
1. **Extract file nén ra** → Thử build lại
2. **Chạy từng bài** → Đảm bảo hoạt động
3. **Xem lại code** → Không có thông tin nhạy cảm

---

## 🎯 Điểm cộng (nếu có)

- ✨ Code clean, có comment
- ✨ Tài liệu đầy đủ, rõ ràng
- ✨ UI đẹp, thân thiện
- ✨ Xử lý lỗi tốt
- ✨ Tính năng mở rộng (bonus)

---

## 📞 Hỗ trợ

Nếu có vấn đề khi nộp bài:
1. Kiểm tra lại checklist ở trên
2. Build lại project sau khi extract
3. Đọc kỹ hướng dẫn của giáo viên
4. Hỏi trợ giảng/bạn cùng lớp

---

## 🎉 Chúc bạn nộp bài thành công!

**Lưu ý cuối:** Nên nộp trước deadline ít nhất 1-2 giờ để tránh sự cố!

---

**File này được tạo bởi:** GitHub Copilot 🤖  
**Ngày:** 20/10/2025
