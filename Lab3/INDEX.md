# 📚 INDEX - TÀI LIỆU LAB 3

## 🎯 Bắt đầu nhanh

**Lần đầu sử dụng? Đọc theo thứ tự:**

1. **[README.md](README.md)** ⭐ - BẮT ĐẦU TỪ ĐÂY
   - Tổng quan dự án
   - Cấu trúc thư mục
   - Yêu cầu hệ thống
   - Hướng dẫn cài đặt

2. **[QUICKSTART.md](QUICKSTART.md)** 🚀 - CHẠY NGAY
   - Hướng dẫn chạy từng bước
   - Demo scenarios
   - Troubleshooting
   - Checklist

3. **[SUMMARY.md](SUMMARY.md)** 📝 - TÓM TẮT
   - Tổng kết dự án
   - Tính năng
   - Technologies
   - Checklist nộp bài

---

## 📖 Tài liệu chuyên sâu

**Muốn hiểu code? Đọc theo thứ tự:**

4. **[ARCHITECTURE.md](ARCHITECTURE.md)** 🏗️ - KIẾN TRÚC
   - Cấu trúc code chi tiết
   - Design patterns
   - Luồng dữ liệu
   - Database schema
   - Best practices
   - Customization guide

5. **[TESTING.md](TESTING.md)** 🧪 - KIỂM THỬ
   - Test cases đầy đủ
   - Demo scripts
   - Common issues
   - Performance metrics
   - Acceptance criteria

---

## 🚀 Scripts tiện ích

### Windows Batch Files:

- **`build-all.bat`** - Build tất cả 3 projects
  ```bash
  # Double-click hoặc chạy:
  build-all.bat
  ```

- **`run-bai6.bat`** - Chạy Bài 6 (SQLite)
  ```bash
  run-bai6.bat
  ```

- **`run-server.bat`** - Chạy Server (Bài 7)
  ```bash
  run-server.bat
  ```

- **`run-client.bat`** - Chạy Client (Bài 7)
  ```bash
  run-client.bat
  ```

---

## 📁 Source Code

### Bài 6 - Standalone SQLite App
```
Bai6_HomNayAnGi_SQLite/
├── Models/           → Data models
├── Database/         → SQLite operations
├── MainForm.cs       → UI logic
└── Program.cs        → Entry point
```

### Bài 7 - Server
```
Bai7_Server/
├── Models/           → Serializable models
├── Database/         → Server database
├── TcpServer.cs      → Network logic
├── ServerForm.cs     → UI
└── Program.cs        → Entry point
```

### Bài 7 - Client
```
Bai7_Client/
├── Models/           → Serializable models
├── Network/          → TCP client helper
├── ClientForm.cs     → UI logic
└── Program.cs        → Entry point
```

---

## 🎓 Sử dụng tài liệu

### Scenario 1: "Tôi muốn chạy thử ngay"
→ Đọc **QUICKSTART.md** → Chạy `run-bai6.bat` hoặc `run-server.bat` + `run-client.bat`

### Scenario 2: "Tôi muốn hiểu code hoạt động thế nào"
→ Đọc **ARCHITECTURE.md** → Xem source code với giải thích

### Scenario 3: "Tôi cần test và demo"
→ Đọc **TESTING.md** → Follow test scenarios

### Scenario 4: "Tôi cần overview cho báo cáo"
→ Đọc **SUMMARY.md** → Lấy thông tin tổng hợp

### Scenario 5: "Tôi gặp lỗi"
→ **QUICKSTART.md** → Section "Troubleshooting"  
→ **TESTING.md** → Section "Common Issues"

---

## 📊 Bảng so sánh tài liệu

| File | Mục đích | Độ dài | Độ khó | Khi nào đọc |
|------|----------|--------|--------|-------------|
| **README.md** | Tổng quan | ⭐⭐⭐⭐ | ⭐ | Đầu tiên |
| **QUICKSTART.md** | Hướng dẫn nhanh | ⭐⭐⭐ | ⭐ | Muốn chạy ngay |
| **SUMMARY.md** | Tóm tắt | ⭐⭐ | ⭐ | Cần overview |
| **ARCHITECTURE.md** | Kiến trúc code | ⭐⭐⭐⭐⭐ | ⭐⭐⭐ | Hiểu code |
| **TESTING.md** | Test & Demo | ⭐⭐⭐⭐ | ⭐⭐ | Test/Demo |

---

## 🎯 Roadmap sử dụng

### Tuần 1: Setup & Run
- [ ] Đọc README.md
- [ ] Chạy build-all.bat
- [ ] Test Bài 6 với run-bai6.bat
- [ ] Test Bài 7 với run-server.bat + run-client.bat

### Tuần 2: Understanding
- [ ] Đọc ARCHITECTURE.md
- [ ] Review source code
- [ ] Hiểu luồng dữ liệu
- [ ] Thử customize code

### Tuần 3: Testing & Demo
- [ ] Đọc TESTING.md
- [ ] Chạy tất cả test cases
- [ ] Chuẩn bị demo script
- [ ] Practice demo

### Tuần 4: Documentation & Submission
- [ ] Đọc SUMMARY.md
- [ ] Hoàn thiện báo cáo
- [ ] Checklist nộp bài
- [ ] Submit

---

## 🔍 Quick Reference

### Commands thường dùng:
```bash
# Build all
dotnet build

# Run Bài 6
cd Bai6_HomNayAnGi_SQLite && dotnet run

# Run Server
cd Bai7_Server && dotnet run

# Run Client
cd Bai7_Client && dotnet run

# Clean all
dotnet clean
```

### File quan trọng:
- `Lab3.sln` - Visual Studio solution
- `.gitignore` - Git ignore rules
- `*.csproj` - Project files
- `*.db` - SQLite databases (auto-generated)

### Thư mục quan trọng:
- `bin/` - Compiled binaries (ignored by git)
- `obj/` - Build objects (ignored by git)
- `Models/` - Data models
- `Database/` - Data access layer
- `Network/` - Network layer (Client only)

---

## 📞 Support & Resources

### Documentation:
1. **README.md** - Main documentation
2. **QUICKSTART.md** - Quick start guide
3. **ARCHITECTURE.md** - Code architecture
4. **TESTING.md** - Testing guide
5. **SUMMARY.md** - Project summary

### External Resources:
- [SQLite Documentation](https://www.sqlite.org/docs.html)
- [System.Data.SQLite](https://system.data.sqlite.org/)
- [TCP/IP in C#](https://docs.microsoft.com/en-us/dotnet/api/system.net.sockets.tcpclient)
- [Windows Forms](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/)

---

## ✅ Checklist tổng hợp

### Cài đặt:
- [ ] .NET 9.0 SDK installed
- [ ] SQLite NuGet package restored
- [ ] All projects build successfully

### Chạy thử:
- [ ] Bài 6 chạy được
- [ ] Server start được
- [ ] Client connect được
- [ ] Multi-client hoạt động

### Hiểu code:
- [ ] Hiểu cấu trúc Models
- [ ] Hiểu DatabaseHelper
- [ ] Hiểu TcpServer logic
- [ ] Hiểu TcpClient logic

### Testing:
- [ ] Đã test tất cả features Bài 6
- [ ] Đã test tất cả features Bài 7
- [ ] Đã test multi-client
- [ ] Đã test edge cases

### Documentation:
- [ ] Đã đọc README
- [ ] Đã đọc QUICKSTART
- [ ] Đã đọc ARCHITECTURE
- [ ] Đã đọc TESTING

### Submission:
- [ ] Code chạy được
- [ ] Tài liệu đầy đủ
- [ ] Demo script sẵn sàng
- [ ] Báo cáo hoàn thành

---

## 🎉 Next Steps

**Bạn đang ở đâu?**

### Bước 1: Mới bắt đầu
→ Đọc [README.md](README.md)  
→ Chạy `build-all.bat`  
→ Test với `run-bai6.bat`

### Bước 2: Đã chạy được
→ Đọc [ARCHITECTURE.md](ARCHITECTURE.md)  
→ Review source code  
→ Thử modify code

### Bước 3: Đã hiểu code
→ Đọc [TESTING.md](TESTING.md)  
→ Chạy tất cả test cases  
→ Chuẩn bị demo

### Bước 4: Sẵn sàng nộp
→ Đọc [SUMMARY.md](SUMMARY.md)  
→ Check checklist  
→ Submit!

---

## 📝 Notes

- Tất cả tài liệu đều ở định dạng Markdown (.md)
- Có thể xem trong Visual Studio Code với Markdown preview
- Hoặc xem trực tiếp trên GitHub nếu push lên
- Code có comments để dễ hiểu

---

**Happy Learning! 🚀**

*Last updated: October 20, 2025*
