# BÀI 5: HÔM NAY ĂN GÌ? - SERVER-CLIENT

**Họ tên:** Phạm Tấn Gia Quốc 
**MSSV:** 23521308
**Lớp:** NT106.Q11.ANTT  
**Ngày nộp:** 20/10/2025

---

## 📋 MÔ TẢ BÀI TẬP

Xây dựng ứng dụng **Server-Client** quản lý món ăn với các tính năng:
- Server quản lý database SQLite tập trung
- Nhiều Client có thể kết nối đồng thời
- Đăng ký/Đăng nhập người dùng
- Thêm món ăn có hình ảnh
- Random món ăn (cá nhân và cộng đồng)
- Hiển thị hình ảnh món ăn

---

## 🎯 TÍNH NĂNG ĐÃ TRIỂN KHAI

### **Server:**
1. ✅ Quản lý database SQLite tập trung
2. ✅ Xử lý nhiều client đồng thời (Multi-threading)
3. ✅ Các thao tác CRUD:
   - `GET_ALL_MONAN` - Lấy tất cả món ăn
   - `GET_MY_MONAN` - Lấy món ăn của user
   - `ADD_MONAN` - Thêm món ăn mới
   - `GET_ALL_NGUOIDUNG` - Lấy danh sách người dùng
   - `ADD_NGUOIDUNG` - Thêm người dùng mới
4. ✅ Logging hoạt động real-time
5. ✅ Hiển thị số client đang kết nối

### **Client:**
1. ✅ Kết nối đến Server (TCP/IP)
2. ✅ Đăng ký người dùng mới (không cần server restart)
3. ✅ Đăng nhập bằng tên người dùng
4. ✅ Thêm món ăn với hình ảnh:
   - Chọn ảnh từ máy tính
   - Preview ảnh trước khi thêm
5. ✅ Xem danh sách món ăn (ListView)
6. ✅ Hiển thị hình ảnh món ăn:
   - Click vào món ăn trong list → hiển thị ảnh
   - Random món ăn → hiển thị ảnh
7. ✅ Random món ăn:
   - Random của tôi (món ăn cá nhân)
   - Random cộng đồng (tất cả món ăn)

---

## 💻 CÔNG NGHỆ SỬ DỤNG

- **Ngôn ngữ:** C# 12
- **Framework:** .NET 9.0
- **UI:** Windows Forms
- **Database:** SQLite (System.Data.SQLite.Core v1.0.118)
- **Networking:** TCP/IP (System.Net.Sockets)
- **Serialization:** JSON (System.Text.Json)
- **Multi-threading:** Thread class

---

## 📊 CẤU TRÚC DATABASE

### **Bảng NguoiDung:**
| Cột | Kiểu | Mô tả |
|-----|------|-------|
| IDNCC | INTEGER PRIMARY KEY AUTOINCREMENT | ID người dùng |
| HoVaTen | TEXT NOT NULL | Tên người dùng |
| QuyenHan | TEXT | Quyền hạn (User/Admin) |

### **Bảng MonAn:**
| Cột | Kiểu | Mô tả |
|-----|------|-------|
| IDMA | INTEGER PRIMARY KEY AUTOINCREMENT | ID món ăn |
| TenMonAn | TEXT NOT NULL | Tên món ăn |
| HinhAnh | TEXT | Đường dẫn file ảnh |
| IDNCC | INTEGER FOREIGN KEY | ID người đóng góp |

---

## 🚀 HƯỚNG DẪN CHẠY

### **Bước 1: Chạy Server**
```bash
cd Server
dotnet run
```
- Mặc định port: **8888**
- Bấm nút **"Start Server"**
- Server sẵn sàng nhận kết nối

### **Bước 2: Chạy Client (có thể chạy nhiều Client)**
```bash
cd Client
dotnet run
```
- Server IP: **127.0.0.1** (localhost)
- Port: **8888**
- Nhập tên người dùng hoặc bấm **"Đăng ký mới"**
- Bấm **"Connect"**

### **Bước 3: Sử dụng**

#### **Đăng ký người dùng mới:**
1. Bấm nút **"Đăng ký mới"**
2. Nhập họ và tên
3. Chọn quyền hạn (User/Admin)
4. Bấm **"Đăng ký"**
5. Tự động đăng nhập

#### **Thêm món ăn:**
1. Nhập tên món ăn
2. Bấm **"Chọn ảnh..."** để chọn hình ảnh
3. Xem preview ảnh
4. Bấm **"Thêm"**

#### **Xem hình ảnh món ăn:**
- **Cách 1:** Click vào món ăn trong danh sách → Ảnh hiển thị bên phải
- **Cách 2:** Bấm **"Random của tôi"** hoặc **"Random cộng đồng"** → Ảnh hiển thị

---

## 📁 CẤU TRÚC PROJECT

```
Server/
├── Database/
│   └── DatabaseHelper.cs       (Xử lý database SQLite)
├── Models/
│   ├── MonAn.cs               (Model món ăn)
│   ├── NguoiDung.cs           (Model người dùng)
│   └── Message.cs             (Model tin nhắn Client-Server)
├── TcpServer.cs               (Logic server TCP)
├── ServerForm.cs              (UI server)
├── ServerForm.Designer.cs
├── ServerForm.resx
├── Program.cs
└── Bai7_Server.csproj

Client/
├── Network/
│   └── TcpClientHelper.cs     (Helper kết nối TCP)
├── Models/
│   ├── MonAn.cs               (Model món ăn)
│   ├── NguoiDung.cs           (Model người dùng)
│   └── Message.cs             (Model tin nhắn)
├── ClientForm.cs              (UI chính)
├── ClientForm.Designer.cs
├── ClientForm.resx
├── DangKyForm.cs              (UI đăng ký)
├── DangKyForm.Designer.cs
├── DangKyForm.resx
├── Program.cs
└── Bai7_Client.csproj
```

---

## 🔄 FLOW HOẠT ĐỘNG

### **1. Kết nối:**
```
Client                          Server
  |                               |
  |-------- Connect TCP --------->|
  |<------- Accept Connection ----|
  |                               |
```

### **2. Lấy danh sách người dùng:**
```
Client                          Server                    Database
  |                               |                           |
  |-- GET_ALL_NGUOIDUNG --------->|                           |
  |                               |---- SELECT * FROM ------->|
  |                               |<----- Result -------------|
  |<----- User List --------------|                           |
```

### **3. Đăng ký người dùng:**
```
Client                          Server                    Database
  |                               |                           |
  |-- ADD_NGUOIDUNG (data) ------>|                           |
  |                               |---- INSERT INTO --------->|
  |                               |<----- New ID -------------|
  |<----- Success (ID) -----------|                           |
```

### **4. Thêm món ăn:**
```
Client                          Server                    Database
  |                               |                           |
  |-- ADD_MONAN (data) ---------->|                           |
  |                               |---- INSERT INTO --------->|
  |<----- Success ---------------|                           |
```

### **5. Random món ăn:**
```
Client                          Server                    Database
  |                               |                           |
  |-- GET_MY_MONAN (userID) ----->|                           |
  |                               |---- SELECT WHERE -------->|
  |<----- List<MonAn> -----------|<----- Result -------------|
  |                               |                           |
  [Random locally]
  [Display image]
```

---

## 🎨 GIAO DIỆN

### **Server:**
```
┌───────────────────────────────────────┐
│  Kết nối Server                       │
│  Port: [8888]  [Start] [Stop]         │
├───────────────────────────────────────┤
│  Status                               │
│  🟢 Running - Connected: 2 clients    │
├───────────────────────────────────────┤
│  Server Log                [Clear]    │
│  ┌─────────────────────────────────┐  │
│  │ [12:30:45] Client connected     │  │
│  │ [12:30:50] GET_ALL_NGUOIDUNG    │  │
│  │ [12:31:00] ADD_MONAN            │  │
│  └─────────────────────────────────┘  │
└───────────────────────────────────────┘
```

### **Client:**
```
┌────────────────────────────────────────────────────┐
│  Kết nối Server                                    │
│  IP: [127.0.0.1] Port: [8888]                      │
│  [Kết nối]                                         │
├────────────────────────────────────────────────────┤
│  Người dùng                                        │
│  [Chọn người dùng ▼] [Đăng nhập] [Đăng ký mới]    │
├────────────────────────────────────────────────────┤
│  Thêm món ăn                                       │
│  Tên món ăn: [___________]                         │
│  Hình ảnh: [__________] [Chọn ảnh...]             │
│  [Thêm] [Làm mới]                                  │
├────────────────────────────────────────────────────┤
│  Danh sách món ăn          │  Kết quả Random      │
│  ┌─────────────────────┐   │  ┌─────────────────┐ │
│  │ ID│Món ăn│Người     │   │  │                 │ │
│  │ 1 │Phở   │Minh      │   │  │   [Hình ảnh]    │ │
│  │ 2 │Cơm   │Lan       │   │  │                 │ │
│  └─────────────────────┘   │  │ 🍽️ Món ăn: Phở  │ │
│  [Random của tôi]          │  │ Người: Minh     │ │
│  [Random cộng đồng]        │  └─────────────────┘ │
└────────────────────────────────────────────────────┘
```

---

## 📝 DEMO SCENARIOS

### **Scenario 1: Đăng ký và thêm món ăn**
1. Client 1 (Alice) kết nối → Bấm "Đăng ký mới"
2. Nhập tên "Alice" → Đăng ký thành công
3. Tự động đăng nhập
4. Thêm món "Phở bò" với ảnh → Thành công
5. Món ăn hiện trong danh sách

### **Scenario 2: Multi-client**
1. Client 1 (Alice) thêm "Phở"
2. Client 2 (Bob) kết nối
3. Bob thấy món "Phở" của Alice trong danh sách
4. Bob thêm món "Cơm rang"
5. Alice bấm "Làm mới" → Thấy món của Bob

### **Scenario 3: Xem hình ảnh**
1. Alice click vào món "Phở" trong list
2. Hình ảnh phở hiển thị bên phải
3. Thông tin người đóng góp hiển thị
4. Alice bấm "Random cộng đồng"
5. Random được món "Cơm rang" của Bob
6. Hình ảnh cơm rang hiển thị

---

## ⚠️ LƯU Ý QUAN TRỌNG

### **Về hình ảnh:**
- Đường dẫn file ảnh lưu **absolute path**
- Không di chuyển/xóa file ảnh sau khi đã thêm
- Khuyến nghị: Tạo thư mục riêng để lưu ảnh món ăn

### **Về kết nối:**
- Server phải chạy trước Client
- Mặc định port 8888 (có thể thay đổi)
- Có thể chạy nhiều Client cùng lúc

### **Về database:**
- File `MonAnDatabase.db` tự động tạo khi chạy Server lần đầu
- Không cần tạo thủ công
- Data được lưu giữa các lần chạy

---

## 🐛 XỬ LÝ LỖI

### **Lỗi 1: Không kết nối được Server**
**Triệu chứng:** Client báo "Không thể kết nối"  
**Giải pháp:**
1. Kiểm tra Server đã chạy chưa
2. Kiểm tra IP và Port đúng chưa
3. Kiểm tra Firewall

### **Lỗi 2: Hình ảnh không hiển thị**
**Triệu chứng:** Không thấy ảnh khi click món ăn  
**Giải pháp:**
1. Kiểm tra file ảnh còn tồn tại không
2. Kiểm tra đường dẫn có đúng không
3. Thử thêm lại món ăn với ảnh mới

### **Lỗi 3: Port đã được sử dụng**
**Triệu chứng:** Server không start được  
**Giải pháp:**
1. Đổi sang port khác (ví dụ: 9999)
2. Hoặc tắt ứng dụng đang dùng port 8888

---

## 🎓 KIẾN THỨC ÁP DỤNG

### **1. Lập trình mạng:**
- TCP/IP Socket programming
- Client-Server architecture
- Request-Response pattern
- Multi-threading

### **2. Database:**
- SQLite CRUD operations
- Foreign Key relationships
- Connection management
- Parameterized queries

### **3. C# Advanced:**
- JSON serialization
- File I/O (read images)
- Error handling (try-catch)
- Event handling

### **4. Windows Forms:**
- Form design
- Controls (ListView, PictureBox, ComboBox)
- Dialog forms
- User interaction

---

## 📚 YÊU CẦU HỆ THỐNG

- **OS:** Windows 10/11
- **.NET SDK:** 9.0 trở lên
- **IDE:** Visual Studio 2022 hoặc VS Code
- **Database:** SQLite (tự động cài qua NuGet)

---

## 🎉 KẾT LUẬN

Bài 7 đã hoàn thành đầy đủ các tính năng yêu cầu:
- ✅ Server quản lý database tập trung
- ✅ Multi-client kết nối đồng thời
- ✅ Đăng ký/Đăng nhập người dùng
- ✅ Thêm món ăn với hình ảnh
- ✅ Hiển thị hình ảnh món ăn
- ✅ Random món ăn (cá nhân và cộng đồng)

**Điểm mạnh:**
- Kiến trúc Client-Server rõ ràng
- Sử dụng JSON serialization hiện đại
- UI thân thiện, dễ sử dụng
- Xử lý multi-threading ổn định

**Có thể cải thiện:**
- Upload ảnh lên Server (không lưu local)
- Thêm authentication với password
- Thêm chức năng xóa/sửa món ăn

---

**Sinh viên thực hiện:** Phạm Tấn Gia Quốc
**MSSV:** 23521308  
**Ngày hoàn thành:** 20/10/2025
