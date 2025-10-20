# HƯỚNG DẪN SỬ DỤNG CHI TIẾT
## Hệ thống quản lý phòng vé Server-Client

### Tác giả: Phạm Tấn Gia Quốc - 23521308

---

## 1. GIỚI THIỆU

Đây là phiên bản nâng cấp của bài 5 Lab02, chuyển đổi từ ứng dụng standalone sang kiến trúc Server-Client. Hệ thống cho phép nhiều quầy bán vé (clients) kết nối đồng thời và đặt vé, với dữ liệu được đồng bộ hóa theo thời gian thực.

### Tính năng chính:
- ✅ Server quản lý tập trung dữ liệu vé
- ✅ Nhiều client kết nối đồng thời
- ✅ Đặt vé với kiểm tra tính khả dụng
- ✅ Đồng bộ hóa thời gian thực
- ✅ Thread-safe booking
- ✅ Log hoạt động chi tiết

---

## 2. CÀI ĐẶT

### Bước 1: Mở project trong Visual Studio
```
1. Mở file Lab02.sln bằng Visual Studio
2. Chọn Configuration: Debug
3. Platform: Any CPU
```

### Bước 2: Restore NuGet Packages
```
Cách 1 (Khuyến nghị):
- Nhấp chuột phải vào Solution trong Solution Explorer
- Chọn "Restore NuGet Packages"
- Đợi Visual Studio tải xuống các packages

Cách 2: Package Manager Console
- Tools → NuGet Package Manager → Package Manager Console
- Chạy lệnh: Install-Package Newtonsoft.Json -Version 13.0.3

Cách 3: Build script
- Chạy file build.bat (yêu cầu Visual Studio Developer Command Prompt)
```

### Bước 3: Build Solution
```
1. Nhấn Ctrl+Shift+B hoặc Build → Build Solution
2. Kiểm tra không có lỗi trong Output window
3. File thực thi: bin\Debug\Lab02.exe
```

### Bước 4: Chuẩn bị dữ liệu
```
1. Copy file input5.txt vào thư mục bin\Debug\
2. Kiểm tra định dạng file đúng (xem mục 3)
```

---

## 3. ĐỊNH DẠNG FILE INPUT5.TXT

File input5.txt chứa thông tin các phim, mỗi phim 5 dòng:

```
<Dòng 1: Tên phim>
<Dòng 2: Giá vé (số)>
<Dòng 3: Phòng chiếu (các số ngăn cách bởi dấu phẩy)>
<Dòng 4: Số vé đã bán (số, có thể để trống)>
<Dòng 5: Số vé còn lại (số, có thể để trống)>
```

### Ví dụ:
```
Mai
100000
2,3
80
20
Đào, phở và piano
45000
1,2,3
60
15
Gặp lại chị bầu
70000
1
50
10
Tarot
90000
3
0
50
```

**Lưu ý:**
- Dòng 4 và 5 có thể để trống (hệ thống sẽ đặt = 0)
- Giá vé là số nguyên hoặc số thực
- Phòng chiếu là danh sách số ngăn cách bởi dấu phẩy

---

## 4. HƯỚNG DẪN CHẠY CHƯƠNG TRÌNH

### 4.1. Khởi động Server

**Bước 1:** Chạy Lab02.exe
- Nhấp đúp vào bin\Debug\Lab02.exe
- Hoặc nhấn F5 trong Visual Studio

**Bước 2:** Chọn "Khởi động Server"
- Màn hình StartupForm xuất hiện
- Click nút "Khởi động Server"

**Bước 3:** Khởi động Server
- Form Server hiển thị
- Click nút "Khởi động Server"
- Server bắt đầu lắng nghe trên cổng 8888
- Danh sách phim được load từ input5.txt
- Nhật ký hiển thị: "Server đã khởi động trên cổng 8888"

**Giao diện Server:**
```
┌─────────────────────────────────────────┐
│ [Khởi động Server] [Dừng Server]       │
├─────────────────────────────────────────┤
│ Danh sách phim/vé:                      │
│ ┌─────────────────────────────────────┐ │
│ │ DataGridView - Hiển thị phim        │ │
│ │ - Tên phim                          │ │
│ │ - Giá vé                            │ │
│ │ - Phòng chiếu                       │ │
│ │ - Số vé bán / tồn                   │ │
│ │ - Doanh thu / Tỉ lệ bán             │ │
│ └─────────────────────────────────────┘ │
├─────────────────────────────────────────┤
│ Nhật ký Server:                         │
│ ┌─────────────────────────────────────┐ │
│ │ [12:30:45] Server đã khởi động...  │ │
│ │ [12:31:20] Client mới kết nối...   │ │
│ │ [12:32:10] Client-1234 đã đặt...   │ │
│ └─────────────────────────────────────┘ │
└─────────────────────────────────────────┘
```

### 4.2. Khởi động Client

**Bước 1:** Chạy Lab02.exe lần nữa (instance mới)
- Mở thêm cửa sổ Command Prompt hoặc Terminal
- Chạy: `start bin\Debug\Lab02.exe`
- Hoặc nhấp đúp vào Lab02.exe trong Explorer

**Bước 2:** Chọn "Khởi động Client"
- Click nút "Khởi động Client"

**Bước 3:** Kết nối tới Server
- Nhập địa chỉ IP của Server:
  - `127.0.0.1` nếu Server trên cùng máy
  - Địa chỉ IP thực nếu Server trên máy khác
- Click nút "Kết nối"
- Danh sách phim sẽ hiển thị

**Giao diện Client:**
```
┌─────────────────────────────────────────┐
│ Server IP: [127.0.0.1]                  │
│ [Kết nối] [Ngắt kết nối] [Làm mới]     │
├─────────────────────────────────────────┤
│ ┌─────────────────────────────────────┐ │
│ │ DataGridView - Danh sách phim       │ │
│ └─────────────────────────────────────┘ │
├─────────────────────────────────────────┤
│ ┌─ Đặt vé ──────────────────────────┐  │
│ │ Chọn phim: [Mai            ▼]     │  │
│ │ Số lượng:  [1          ]          │  │
│ │                                    │  │
│ │ Giá vé: 100,000 VNĐ               │  │
│ │ Phòng chiếu: 2,3                  │  │
│ │ Vé còn lại: 20                    │  │
│ │                                    │  │
│ │         [Đặt vé]                  │  │
│ └────────────────────────────────────┘  │
├─────────────────────────────────────────┤
│ Nhật ký:                                │
│ [12:31:20] Đã kết nối tới server!      │
│ [12:32:10] Đặt thành công 2 vé...      │
└─────────────────────────────────────────┘
```

### 4.3. Đặt vé

**Bước 1:** Chọn phim
- Click vào dropdown "Chọn phim"
- Chọn phim muốn đặt
- Thông tin phim hiển thị bên phải

**Bước 2:** Nhập số lượng vé
- Nhập số lượng vé (tối đa = số vé còn lại)
- NumericUpDown tự động giới hạn

**Bước 3:** Đặt vé
- Click nút "Đặt vé"
- Hộp thoại xác nhận hiển thị
- Danh sách tự động cập nhật

**Kết quả:**
- Server: Log hiển thị "[Client-1234] đã đặt 2 vé cho 'Mai'"
- Server: DataGridView cập nhật số vé
- Tất cả Clients: Tự động refresh danh sách

---

## 5. KIỂM THỬ HỆ THỐNG

### Test Case 1: Đặt vé thành công
```
Bước thực hiện:
1. Khởi động Server
2. Khởi động Client A
3. Client A đặt 5 vé cho phim "Mai"

Kết quả mong đợi:
- Client A: Hiển thị "Đặt thành công 5 vé cho phim 'Mai'"
- Server: Log "Client-XXXX đã đặt 5 vé cho 'Mai'"
- Server: Số vé tồn giảm 5, số vé bán tăng 5
```

### Test Case 2: Đồng bộ nhiều Clients
```
Bước thực hiện:
1. Khởi động Server
2. Khởi động Client A và Client B
3. Client A đặt 3 vé cho "Đào, phở và piano"
4. Quan sát Client B

Kết quả mong đợi:
- Client B tự động cập nhật
- Client B thấy số vé giảm từ 15 xuống 12
- Không cần nhấn "Làm mới"
```

### Test Case 3: Không đủ vé
```
Bước thực hiện:
1. Phim "Mai" còn 5 vé
2. Client A đặt 10 vé

Kết quả mong đợi:
- Hiển thị lỗi: "Không đủ vé! Chỉ còn 5 vé."
- Số vé không thay đổi
```

### Test Case 4: Đặt vé đồng thời
```
Bước thực hiện:
1. Khởi động Server
2. Khởi động 3 Clients (A, B, C)
3. Phim "Tarot" có 50 vé
4. Cùng lúc:
   - Client A đặt 20 vé
   - Client B đặt 20 vé
   - Client C đặt 20 vé

Kết quả mong đợi:
- Chỉ 2 trong 3 clients thành công
- Client thứ 3 nhận lỗi "Không đủ vé"
- Tổng vé bán = 40 (không vượt quá 50)
- Thread-safe locking hoạt động đúng
```

---

## 6. XỬ LÝ LỖI

### Lỗi 1: "Không tìm thấy file input5.txt"
```
Nguyên nhân: File input5.txt không ở đúng vị trí

Giải pháp:
1. Copy file input5.txt vào thư mục bin\Debug\
2. Hoặc chỉnh đường dẫn trong code (không khuyến nghị)
```

### Lỗi 2: "Could not load file or assembly 'Newtonsoft.Json'"
```
Nguyên nhân: Package Newtonsoft.Json chưa được cài đặt

Giải pháp:
1. Mở Visual Studio
2. Tools → NuGet Package Manager → Package Manager Console
3. Chạy: Install-Package Newtonsoft.Json -Version 13.0.3
4. Build lại solution
```

### Lỗi 3: "Lỗi kết nối: No connection could be made"
```
Nguyên nhân: Server chưa khởi động hoặc sai IP/port

Giải pháp:
1. Kiểm tra Server đã khởi động chưa
2. Kiểm tra IP address (127.0.0.1 cho localhost)
3. Kiểm tra port 8888 không bị chặn bởi firewall
4. Tạm tắt firewall hoặc cho phép ứng dụng
```

### Lỗi 4: "File không đúng định dạng! Mỗi phim cần 5 dòng."
```
Nguyên nhân: File input5.txt sai cấu trúc

Giải pháp:
1. Kiểm tra mỗi phim phải có đúng 5 dòng
2. Không được có dòng trống giữa các phim
3. Dòng 4 và 5 có thể để trống nhưng phải có dòng
```

### Lỗi 5: Server không nhận connections
```
Nguyên nhân: Port 8888 đã bị chiếm dụng

Giải pháp:
1. Kiểm tra ứng dụng nào đang dùng port 8888:
   netstat -ano | findstr :8888
2. Đóng ứng dụng đó hoặc thay đổi port trong code
3. Chạy ứng dụng với quyền Administrator
```

---

## 7. NETWORK PROTOCOL

### Message Types:
```csharp
Connect      - Kết nối ban đầu
GetMovies    - Lấy danh sách phim
BookTicket   - Đặt vé
RefreshData  - Yêu cầu cập nhật
Disconnect   - Ngắt kết nối
```

### Message Format (JSON):
```json
{
    "Type": "BookTicket",
    "Data": "{\"TenPhim\":\"Mai\",\"SoLuongVe\":2,\"ClientName\":\"Client-1234\"}",
    "Success": true,
    "ErrorMessage": null
}
```

### Booking Request:
```json
{
    "TenPhim": "Mai",
    "SoLuongVe": 2,
    "ClientName": "Client-1234"
}
```

### Movie Data Response:
```json
[
    {
        "TenPhim": "Mai",
        "GiaVeChuan": 100000,
        "PhongChieu": "2,3",
        "SoLuongVeBan": 80,
        "SoLuongVeTon": 20,
        "DoanhThu": 8000000,
        "TiLeBan": "80.00%"
    }
]
```

---

## 8. TIPS & TRICKS

### Tip 1: Chạy nhiều Clients trên cùng máy
```
1. Mở nhiều Command Prompt windows
2. Mỗi window chạy: bin\Debug\Lab02.exe
3. Tất cả kết nối tới 127.0.0.1
```

### Tip 2: Test với nhiều máy khác nhau
```
Server (Máy A):
1. Tìm địa chỉ IP: ipconfig
2. Khởi động Server
3. Mở port 8888 trên firewall

Client (Máy B, C, D...):
1. Nhập IP của Máy A
2. Kết nối và test
```

### Tip 3: Monitor network traffic
```
Sử dụng Wireshark:
1. Filter: tcp.port == 8888
2. Xem các JSON messages
3. Debug protocol issues
```

### Tip 4: Debug logging
```
Server log hiển thị:
- Số client đang kết nối
- Chi tiết các booking requests
- Thời gian mỗi transaction

Client log hiển thị:
- Trạng thái kết nối
- Kết quả đặt vé
- Cập nhật từ server
```

---

## 9. KẾT LUẬN

Hệ thống đã được hoàn thiện với đầy đủ tính năng:
- ✅ Server-Client architecture
- ✅ Multi-client support
- ✅ Real-time synchronization
- ✅ Thread-safe operations
- ✅ Error handling
- ✅ Comprehensive logging

**Liên hệ hỗ trợ:**
- Sinh viên: Phạm Tấn Gia Quốc
- MSSV: 23521308
- Môn: NT106.Q11.ANTT - Lập trình mạng căn bản
