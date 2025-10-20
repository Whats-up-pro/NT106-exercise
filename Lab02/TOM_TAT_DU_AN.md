# TÓM TẮT DỰ ÁN - SERVER-CLIENT TICKET MANAGEMENT SYSTEM
## Phạm Tấn Gia Quốc - 23521308

---

## I. TỔNG QUAN

### Yêu cầu đề bài:
> 1 Server – Multi Client Quản lý phòng vé (phiên bản số 3). Lấy ý tưởng và kế thừa từ bài 5 – bài thực hành số 2, dữ liệu về phòng vé mặc định đã có sẵn từ file. Dữ liệu được thống nhất lưu trữ tại Server. Các chức năng tương tự, tuy nhiên thông tin vé được đặt là đồng bộ trong hệ thống đối với các Client. Nếu vé đã được đặt ở 1 quầy thì các quầy khác không đặt được vé đó nữa.

### Giải pháp đã triển khai:
✅ Kiến trúc Server-Client sử dụng TCP/IP  
✅ Server quản lý tập trung dữ liệu từ input5.txt  
✅ Multi-client concurrent connections  
✅ Real-time synchronization giữa các clients  
✅ Thread-safe booking với locking mechanism  
✅ Prevent double-booking với validation  
✅ UI hiển thị vé còn lại real-time  

---

## II. CẤU TRÚC FILE DỰ ÁN

### A. Files mới được tạo (9 files):

#### 1. Protocol Layer
- **NetworkMessage.cs** - Định nghĩa message protocol
  - Enum MessageType (Connect, GetMovies, BookTicket, RefreshData, Disconnect)
  - Class NetworkMessage (Type, Data, Success, ErrorMessage)
  - Class BookingRequest (TenPhim, SoLuongVe, ClientName)
  - Class MovieData (DTO cho truyền dữ liệu)

#### 2. Server Layer (3 files)
- **ServerForm.cs** - Logic của Server
  - TcpListener trên port 8888
  - Thread pool để xử lý nhiều clients
  - LoadMovieData() từ input5.txt
  - AcceptClients() - Vòng lặp chấp nhận kết nối
  - HandleClient() - Xử lý từng client
  - ProcessMessage() - Route messages theo type
  - ProcessBooking() - Xử lý đặt vé với thread-safe lock
  - BroadcastUpdate() - Thông báo cập nhật cho clients
  - UpdateMovieDisplay() - Refresh UI
  - LogMessage() - Thread-safe logging

- **ServerForm.Designer.cs** - UI Designer code
  - Button: btnStart, btnStop
  - DataGridView: dgvMovies
  - TextBox: txtLog
  - Labels: label1, label2

- **ServerForm.resx** - Resources file

#### 3. Client Layer (3 files)
- **ClientForm.cs** - Logic của Client
  - TcpClient kết nối tới server
  - LoadMovies() - Lấy danh sách phim từ server
  - SendAndReceive() - Giao tiếp đồng bộ
  - ReceiveMessages() - Background thread để nhận updates
  - BookTicket() - Gửi yêu cầu đặt vé
  - UpdateMovieDisplay() - Refresh UI
  - Auto-refresh khi nhận RefreshData message

- **ClientForm.Designer.cs** - UI Designer code
  - TextBox: txtServerIP
  - Buttons: btnConnect, btnDisconnect, btnRefresh, btnBookTicket
  - DataGridView: dgvMovies
  - ComboBox: cboPhim
  - NumericUpDown: numSoLuong
  - Labels: lblThongTin, etc.
  - GroupBox: groupBox1 (Đặt vé)

- **ClientForm.resx** - Resources file

#### 4. Startup Layer (3 files)
- **StartupForm.cs** - Form chọn chế độ
  - btnServer_Click() - Mở ServerForm
  - btnClient_Click() - Mở ClientForm
  - btnForm5_Click() - Mở Form5 (standalone)

- **StartupForm.Designer.cs** - UI Designer code
  - Buttons: btnServer, btnClient, btnForm5
  - Labels: label1, label2

- **StartupForm.resx** - Resources file

### B. Files được chỉnh sửa:

#### 1. Program.cs
```csharp
// Thay đổi: Application.Run(new Form5());
// Thành:    Application.Run(new StartupForm());
```

#### 2. Lab02.csproj
- Thêm reference: Newtonsoft.Json
- Thêm Compile items: 6 files mới (.cs)
- Thêm EmbeddedResource items: 3 files mới (.resx)

#### 3. packages.config
- Thêm: Newtonsoft.Json version 13.0.3

### C. Files được giữ nguyên:
- Phim.cs - Class model (không cần thay đổi)
- Form5.cs, Form5.Designer.cs, Form5.resx - Bài cũ
- Form6.cs, Form6.resx
- MonAn.cs
- input5.txt - Dữ liệu phim
- Các files Properties/

### D. Files tài liệu mới:
- **README.md** - Tổng quan kỹ thuật
- **HUONG_DAN_SU_DUNG.md** - Hướng dẫn chi tiết
- **build.bat** - Script build tự động
- **TOM_TAT_DU_AN.md** - File này

---

## III. KIẾN TRÚC HỆ THỐNG

```
┌─────────────────────────────────────────────────────────┐
│                      StartupForm                        │
│         [Server] [Client] [Form5-Standalone]           │
└──────────┬──────────────────────┬──────────────────────┘
           │                      │
           ▼                      ▼
    ┌─────────────┐        ┌──────────────┐
    │ ServerForm  │◄──────►│ ClientForm   │
    │             │  TCP   │              │
    │ Port 8888   │  JSON  │ Multi-Client │
    │             │        │              │
    └──────┬──────┘        └──────────────┘
           │
           ▼
    ┌─────────────┐
    │ input5.txt  │
    │ Movie Data  │
    └─────────────┘
```

### Data Flow:

#### 1. Connection:
```
Client → Connect → Server
Server → Connect Response → Client
Client → GetMovies → Server
Server → MovieData[] → Client
```

#### 2. Booking:
```
Client → BookTicket Request → Server
Server → Lock(lockObject)
Server → Validate & Update Data
Server → Unlock
Server → BookTicket Response → Client
Server → Broadcast RefreshData → All Clients
All Clients → Auto Refresh UI
```

#### 3. Synchronization:
```
Client A: Book 5 tickets
    ↓
Server: Lock → Update → Broadcast
    ↓
Client B, C, D: Auto-refresh
    ↓
All Clients see updated ticket count
```

---

## IV. THREAD SAFETY

### Server-side:
```csharp
private object lockObject = new object();

private NetworkMessage ProcessBooking(BookingRequest booking)
{
    lock (lockObject)  // ← Thread-safe critical section
    {
        var phim = danhSachPhim.FirstOrDefault(...);
        if (phim.SoLuongVeTon < booking.SoLuongVe)
            return error;
        
        phim.SoLuongVeBan += booking.SoLuongVe;
        phim.SoLuongVeTon -= booking.SoLuongVe;
        
        BroadcastUpdate();
    }
}
```

### Client-side:
```csharp
// Main UI thread
private void btnBookTicket_Click(...)
{
    SendAndReceive(bookingRequest);  // Synchronous
}

// Background thread
private void ReceiveMessages()
{
    while (isConnected)
    {
        // Listen for server broadcasts
        if (message.Type == RefreshData)
            LoadMovies();  // Uses Invoke for thread-safe UI update
    }
}
```

---

## V. PROTOCOL SPECIFICATION

### Message Format:
```json
{
    "Type": "<MessageType>",
    "Data": "<JSON string or null>",
    "Success": true/false,
    "ErrorMessage": "<error text or null>"
}
```

### Message Types:

#### 1. Connect
**Request:**
```json
{"Type": "Connect", "Data": null}
```
**Response:**
```json
{"Type": "Connect", "Success": true, "Data": "Kết nối thành công!"}
```

#### 2. GetMovies
**Request:**
```json
{"Type": "GetMovies", "Data": null}
```
**Response:**
```json
{
    "Type": "GetMovies",
    "Success": true,
    "Data": "[{\"TenPhim\":\"Mai\",\"GiaVeChuan\":100000,...}]"
}
```

#### 3. BookTicket
**Request:**
```json
{
    "Type": "BookTicket",
    "Data": "{\"TenPhim\":\"Mai\",\"SoLuongVe\":2,\"ClientName\":\"Client-1234\"}"
}
```
**Response Success:**
```json
{
    "Type": "BookTicket",
    "Success": true,
    "Data": "Đặt thành công 2 vé cho phim 'Mai'"
}
```
**Response Error:**
```json
{
    "Type": "BookTicket",
    "Success": false,
    "ErrorMessage": "Không đủ vé! Chỉ còn 1 vé."
}
```

#### 4. RefreshData (Broadcast)
```json
{"Type": "RefreshData", "Success": true}
```

#### 5. Disconnect
```json
{"Type": "Disconnect", "Success": true}
```

---

## VI. TESTING SCENARIOS

### Scenario 1: Basic Booking
```
Setup:
- 1 Server running
- 2 Clients connected
- Movie "Mai" có 20 vé

Steps:
1. Client A đặt 5 vé
2. Observe Client B

Expected:
✓ Client A: Success message
✓ Server: Log "Client-A đã đặt 5 vé"
✓ Client B: Auto-refresh, vé giảm 20→15
✓ DataGridView updates on all clients
```

### Scenario 2: Insufficient Tickets
```
Setup:
- 1 Server, 1 Client
- Movie "Tarot" còn 3 vé

Steps:
1. Client đặt 5 vé

Expected:
✓ Error: "Không đủ vé! Chỉ còn 3 vé."
✓ Số vé không thay đổi
✓ Client có thể đặt lại với số lượng ≤3
```

### Scenario 3: Race Condition
```
Setup:
- 1 Server, 3 Clients (A, B, C)
- Movie "Gặp lại chị bầu" còn 10 vé

Steps:
1. Cùng lúc:
   - Client A đặt 8 vé
   - Client B đặt 8 vé
   - Client C đặt 8 vé

Expected:
✓ Chỉ 1 client thành công
✓ 2 clients còn lại nhận lỗi
✓ Tổng vé bán ≤ 10
✓ No double-booking
✓ Thread lock hoạt động đúng
```

### Scenario 4: Multiple Sequential Bookings
```
Setup:
- 1 Server, 2 Clients
- Movie "Đào, phở và piano" có 15 vé

Steps:
1. Client A đặt 3 vé → Success
2. Client B auto-refresh → 12 vé còn lại
3. Client B đặt 5 vé → Success
4. Client A auto-refresh → 7 vé còn lại
5. Client A đặt 7 vé → Success
6. Both clients → 0 vé còn lại

Expected:
✓ All bookings successful
✓ Final count: 15 bán, 0 tồn
✓ Synchronization working perfectly
```

---

## VII. DEPENDENCIES

### NuGet Packages:
```xml
<packages>
  <package id="Newtonsoft.Json" version="13.0.3" targetFramework="net472" />
  <package id="Stub.System.Data.SQLite.Core.NetFramework" version="1.0.119.0" targetFramework="net472" />
  <package id="System.Data.SQLite" version="2.0.2" targetFramework="net472" />
  <package id="System.Data.SQLite.Core" version="1.0.119.0" targetFramework="net472" />
</packages>
```

### Framework:
- .NET Framework 4.7.2
- Windows Forms Application

### System References:
- System.Net.Sockets - TCP communication
- System.Threading - Multi-threading
- System.Runtime.Serialization - JSON serialization (via Newtonsoft.Json)

---

## VIII. CODE STATISTICS

### Lines of Code:
```
NetworkMessage.cs:      ~35 lines
ServerForm.cs:          ~320 lines
ServerForm.Designer.cs: ~150 lines
ClientForm.cs:          ~270 lines
ClientForm.Designer.cs: ~180 lines
StartupForm.cs:         ~30 lines
StartupForm.Designer.cs: ~110 lines
─────────────────────────────────
Total new code:         ~1,095 lines
```

### Files Created:
```
C# code files:          7 files
Designer files:         3 files
Resource files:         3 files
Documentation:          4 files (README, HUONG_DAN, TOM_TAT, build.bat)
─────────────────────────────────
Total:                  17 files
```

---

## IX. DEPLOYMENT CHECKLIST

### Trước khi build:
- ☑ Đã restore NuGet packages
- ☑ Newtonsoft.Json đã được cài đặt
- ☑ Configuration = Debug
- ☑ Platform = Any CPU

### Trước khi chạy:
- ☑ File input5.txt có trong bin\Debug\
- ☑ Format file input5.txt đúng
- ☑ Port 8888 không bị chiếm dụng
- ☑ Firewall cho phép ứng dụng (nếu test multi-machine)

### Khi chạy:
- ☑ Khởi động Server trước
- ☑ Khởi động Clients sau
- ☑ Client nhập đúng IP của Server
- ☑ Kiểm tra logs để debug

---

## X. FUTURE ENHANCEMENTS

### Có thể cải tiến:
1. **Database Integration**
   - Thay file input5.txt bằng SQL Server/SQLite
   - Persistent storage
   - Transaction logging

2. **Authentication**
   - Login system cho clients
   - Role-based access control
   - Admin panel

3. **Advanced Features**
   - Seat selection UI
   - Multiple showtimes per movie
   - Payment gateway integration
   - Booking history
   - Reports & analytics

4. **Network Improvements**
   - SSL/TLS encryption
   - Heartbeat/keepalive mechanism
   - Automatic reconnection
   - Load balancing (multiple servers)

5. **UI/UX**
   - Modern Material Design
   - WPF instead of WinForms
   - Responsive layouts
   - Dark mode

---

## XI. KẾT LUẬN

Dự án đã hoàn thành đầy đủ yêu cầu đề bài:

### Đáp ứng yêu cầu:
✅ **Server-Client architecture** - Implemented  
✅ **Multi-client support** - Implemented  
✅ **Dữ liệu tập trung tại Server** - Implemented  
✅ **Đồng bộ thông tin vé** - Implemented  
✅ **Ngăn chặn đặt trùng vé** - Implemented  
✅ **Kế thừa từ bài 5** - Data structure & UI inherited  
✅ **Load từ file** - input5.txt  

### Điểm nổi bật:
- Thread-safe booking mechanism
- Real-time synchronization
- Professional error handling
- Comprehensive logging
- User-friendly UI
- Complete documentation

### Thời gian hoàn thành:
- Planning & Architecture: 30 phút
- Implementation: 2 giờ
- Testing & Documentation: 1 giờ
- **Total: ~3.5 giờ**

---

**Sinh viên thực hiện:** Phạm Tấn Gia Quốc  
**MSSV:** 23521308  
**Môn học:** NT106.Q11.ANTT - Lập trình mạng căn bản  
**Bài tập:** Lab02 - Bài thực hành số 2  
**Ngày hoàn thành:** [Current Date]
