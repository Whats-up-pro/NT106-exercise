# 📚 LAB 3 - Tổng hợp Bài tập Thực hành

## 🎯 Danh sách bài tập đã hoàn thành

### ✅ Bài 6: Hôm nay ăn gì? (SQLite - Standalone)
**Mô tả:** Ứng dụng quản lý món ăn sử dụng SQLite database  
**Công nghệ:** C# 12, .NET 9.0, Windows Forms, SQLite  
**Tính năng:**
- Quản lý người dùng (CRUD)
- Quản lý món ăn với hình ảnh
- Random món ăn cá nhân
- Random món ăn cộng đồng
- Lưu trữ local với SQLite

**Chạy:**
```bash
./run-bai6.bat
# hoặc
cd Bai6_HomNayAnGi_SQLite && dotnet run
```

---

### ✅ Bài 7: Hôm nay ăn gì? (Server-Client)
**Mô tả:** Phiên bản multi-client với Server quản lý tập trung  
**Công nghệ:** TCP/IP, JSON Serialization, Multi-threading  
**Tính năng:**

#### Server:
- Quản lý database SQLite tập trung
- Xử lý nhiều client đồng thời
- CRUD operations (MonAn, NguoiDung)
- Logging hoạt động

#### Client:
- Kết nối đến Server
- Đăng nhập/Đăng ký người dùng
- Thêm món ăn với hình ảnh
- Xem danh sách món ăn (của tôi + cộng đồng)
- Random món ăn
- Hiển thị hình ảnh món ăn

**Chạy:**
```bash
# Terminal 1: Server
./run-server.bat

# Terminal 2+: Client(s)
./run-client.bat
```

**Đã fix:**
- ✅ Chuyển từ BinaryFormatter sang JSON
- ✅ Sửa warning CA2022 (NetworkStream.Read)
- ✅ Thêm chức năng đăng ký user từ client
- ✅ Hiển thị hình ảnh món ăn

---

### ✅ Bài 8: Chat Room (Multi-Client)
**Mô tả:** Ứng dụng chat real-time với nhiều tính năng  
**Công nghệ:** TCP/IP, JSON, Multi-threading, RichTextBox  
**Tính năng:**

#### Server:
- Accept nhiều client đồng thời
- Broadcast tin nhắn public
- Forward tin nhắn private
- Chuyển tiếp file và hình ảnh
- Quản lý danh sách user online
- Real-time logging

#### Client:
**3 Tabs chính:**
1. **Public Chat**: Chat công khai với mọi người
2. **Private Chat**: Chat riêng 1-1
3. **Send Files/Images**: Gửi file .txt và ảnh .jpg/.png

**Tính năng đặc biệt:**
- Danh sách user online (real-time)
- Chọn user để chat riêng
- Gửi file công khai hoặc riêng tư
- Preview hình ảnh nhận được
- Lưu file/ảnh về máy
- Màu sắc phân biệt loại tin nhắn
- Enter để gửi tin nhắn

**Chạy:**
```bash
# Terminal 1: Chat Server
./run-chat-server.bat

# Terminal 2, 3, 4...: Chat Clients (nhiều client)
./run-chat-client.bat
```

---

## 📊 So sánh các bài

| Tiêu chí | Bài 6 | Bài 7 | Bài 8 |
|----------|-------|-------|-------|
| **Kiến trúc** | Standalone | Client-Server | Client-Server |
| **Database** | SQLite Local | SQLite Server | Không |
| **Networking** | Không | TCP/IP | TCP/IP |
| **Multi-client** | N/A | ✅ | ✅ |
| **Serialization** | N/A | JSON | JSON |
| **Real-time** | Không | Không | ✅ |
| **File transfer** | Không | Không | ✅ |
| **Private message** | N/A | N/A | ✅ |

---

## 🚀 Quick Start

### Build tất cả:
```bash
./build-all.bat
```

### Chạy từng bài:
```bash
# Bài 6
./run-bai6.bat

# Bài 7
./run-server.bat  # Terminal 1
./run-client.bat  # Terminal 2

# Bài 8
./run-chat-server.bat  # Terminal 1
./run-chat-client.bat  # Terminal 2, 3, 4...
```

---

## 📁 Cấu trúc thư mục

```
Lab3/
├── Bai6_HomNayAnGi_SQLite/
│   ├── Database/
│   │   └── DatabaseHelper.cs
│   ├── Models/
│   │   ├── MonAn.cs
│   │   └── NguoiDung.cs
│   ├── MainForm.cs
│   ├── NguoiDungForm.cs
│   └── Bai6_HomNayAnGi_SQLite.csproj
│
├── Bai7_Server/
│   ├── Database/
│   │   └── DatabaseHelper.cs
│   ├── Models/
│   │   ├── MonAn.cs
│   │   ├── NguoiDung.cs
│   │   └── Message.cs
│   ├── TcpServer.cs
│   ├── ServerForm.cs
│   └── Bai7_Server.csproj
│
├── Bai7_Client/
│   ├── Network/
│   │   └── TcpClientHelper.cs
│   ├── Models/
│   │   ├── MonAn.cs
│   │   ├── NguoiDung.cs
│   │   └── Message.cs
│   ├── ClientForm.cs
│   ├── DangKyForm.cs
│   └── Bai7_Client.csproj
│
├── Bai8_ChatRoom_Server/
│   ├── Models/
│   │   └── ChatMessage.cs
│   ├── ChatServer.cs
│   ├── ServerForm.cs
│   └── Bai8_ChatRoom_Server.csproj
│
├── Bai8_ChatRoom_Client/
│   ├── Models/
│   │   └── ChatMessage.cs
│   ├── ChatForm.cs
│   └── Bai8_ChatRoom_Client.csproj
│
├── *.bat                    # Scripts chạy nhanh
├── *.md                     # Tài liệu
└── README.md               # File này
```

---

## 📖 Tài liệu chi tiết

- **Bài 6 + 7**: `README.md`, `QUICKSTART.md`, `TESTING.md`
- **Bài 7 (Hình ảnh)**: `HUONG_DAN_HINH_ANH.md`
- **Bài 8**: `BAI8_CHATROOM_README.md`
- **Đóng góp**: `NGUOI_DONG_GOP.md`
- **Changelog**: `CHANGELOG.md`

---

## 🔧 Yêu cầu hệ thống

- **.NET SDK**: 9.0 hoặc cao hơn
- **OS**: Windows (Windows Forms)
- **IDE**: Visual Studio 2022 / VS Code
- **Database**: SQLite (Bài 6, 7)

---

## 🎓 Kiến thức áp dụng

### Lập trình mạng:
- TCP/IP Socket programming
- Client-Server architecture
- Multi-threading
- Network protocols

### Database:
- SQLite CRUD operations
- Foreign key relationships
- Connection management

### Windows Forms:
- Event handling
- Controls (ListView, RichTextBox, TabControl)
- Form design patterns
- User interaction

### C# Advanced:
- JSON serialization
- File I/O
- Error handling
- Async patterns
- LINQ

---

## 🐛 Known Issues & Solutions

### Issue 1: Port already in use
**Lỗi:** "Only one usage of each socket address"  
**Giải pháp:** Đổi port hoặc kill process đang dùng port

### Issue 2: Hình ảnh không hiển thị
**Lỗi:** File không tồn tại  
**Giải pháp:** Kiểm tra đường dẫn absolute, không di chuyển file ảnh

### Issue 3: Client không kết nối được
**Lỗi:** Connection refused  
**Giải pháp:** Đảm bảo Server đã chạy trước, kiểm tra firewall

### Issue 4: Tên user trùng (Bài 8)
**Lỗi:** 2 client cùng tên  
**Giải pháp:** Dùng tên khác nhau cho mỗi client

---

## 🎯 Test Scenarios

### Bài 6:
1. Thêm người dùng mới
2. Thêm món ăn với ảnh
3. Random món ăn của tôi
4. Random món ăn cộng đồng

### Bài 7:
1. Server start → Client connect
2. Đăng ký user mới từ client
3. Thêm món ăn có hình ảnh
4. Click món ăn trong list → xem hình ảnh
5. Random → hiển thị hình ảnh

### Bài 8:
1. Server start → 3 clients connect (Alice, Bob, Charlie)
2. Alice gửi public message → tất cả thấy
3. Bob chọn Alice → gửi private → chỉ Alice thấy
4. Charlie gửi file .txt public → Alice, Bob nhận
5. Alice gửi ảnh .jpg private cho Bob → chỉ Bob thấy

---

## 🏆 Điểm nổi bật

### Bài 6:
- ✨ UI đơn giản, dễ sử dụng
- ✨ Database design tốt (Foreign Key)
- ✨ Form quản lý người dùng riêng

### Bài 7:
- ✨ Multi-client ổn định
- ✨ JSON serialization hiện đại
- ✨ Hiển thị hình ảnh tốt
- ✨ Đăng ký user từ client tiện lợi

### Bài 8:
- ✨ UI đẹp với TabControl
- ✨ Real-time chat mượt mà
- ✨ Private chat an toàn
- ✨ File/Image transfer hoàn hảo
- ✨ User list real-time

---

## 📈 Mở rộng trong tương lai

### Bài 6:
- [ ] Export/Import database
- [ ] Tìm kiếm món ăn
- [ ] Thống kê món ăn

### Bài 7:
- [ ] Upload ảnh lên server (không lưu local)
- [ ] Authentication with password
- [ ] Xóa/Sửa món ăn

### Bài 8:
- [ ] Lưu lịch sử chat (database)
- [ ] Group chat / Room
- [ ] Voice/Video call
- [ ] Encryption (SSL/TLS)

---

## 👨‍💻 Tác giả

**GitHub Copilot** 🤖  
NT106.Q11.ANTT - Lập Trình Mạng Căn Bản  
Học kỳ 1, Năm học 2025-2026

---

## 📞 Support

Nếu gặp vấn đề:
1. Đọc README.md của từng bài
2. Kiểm tra TESTING.md
3. Xem CHANGELOG.md
4. Check Known Issues ở trên

**Happy Coding!** 🚀💻
