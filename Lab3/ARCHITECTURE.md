# CẤU TRÚC CODE VÀ GIẢI THÍCH CHI TIẾT

## 📁 Tổng quan cấu trúc

```
Lab3/
│
├── Bai6_HomNayAnGi_SQLite/      # Standalone application với SQLite
│   ├── Models/                   # Các class model
│   │   ├── MonAn.cs             # Class đại diện món ăn
│   │   └── NguoiDung.cs         # Class đại diện người dùng
│   ├── Database/                 # Layer xử lý database
│   │   └── DatabaseHelper.cs    # CRUD operations với SQLite
│   ├── MainForm.cs              # Business logic của form
│   ├── MainForm.Designer.cs     # UI design code (auto-generated)
│   └── Program.cs               # Entry point của ứng dụng
│
├── Bai7_Server/                  # TCP Server application
│   ├── Models/
│   │   ├── MonAn.cs             # [Serializable] model
│   │   ├── NguoiDung.cs         # [Serializable] model
│   │   └── Message.cs           # Protocol message class
│   ├── Database/
│   │   └── DatabaseHelper.cs    # Server-side database operations
│   ├── TcpServer.cs             # Core TCP server logic
│   ├── ServerForm.cs            # UI để quản lý server
│   └── Program.cs
│
└── Bai7_Client/                  # TCP Client application
    ├── Models/
    │   ├── MonAn.cs             # [Serializable] model
    │   ├── NguoiDung.cs         # [Serializable] model
    │   └── Message.cs           # Protocol message class
    ├── Network/
    │   └── TcpClientHelper.cs   # Wrapper cho TCP communication
    ├── ClientForm.cs            # Main client UI logic
    └── Program.cs
```

---

## 🏗️ Kiến trúc từng layer

### Layer 1: Models (Data Layer)

**MonAn.cs** - Đại diện cho một món ăn
```csharp
public class MonAn
{
    public int IDMA { get; set; }          // ID món ăn
    public string TenMonAn { get; set; }   // Tên món ăn
    public string HinhAnh { get; set; }    // Đường dẫn hình ảnh
    public int IDNCC { get; set; }         // ID người đóng góp (FK)
}
```

**NguoiDung.cs** - Đại diện cho người dùng/người đóng góp
```csharp
public class NguoiDung
{
    public int IDNCC { get; set; }         // ID người dùng
    public string HoVaTen { get; set; }    // Họ và tên
    public string QuyenHan { get; set; }   // Quyền hạn (Admin/User)
}
```

**Message.cs** (chỉ có ở Bài 7) - Protocol communication
```csharp
[Serializable]  // Bắt buộc để serialize qua network
public class Message
{
    public string Action { get; set; }      // Loại hành động
    public object Data { get; set; }        // Dữ liệu gửi kèm
    public int UserID { get; set; }         // ID người dùng request
    public bool Success { get; set; }       // Trạng thái response
    public string ErrorMessage { get; set; } // Lỗi nếu có
}
```

---

### Layer 2: Database Layer

**DatabaseHelper.cs** - Xử lý tất cả operations với SQLite

**Các method chính:**

```csharp
// Khởi tạo database và tạo bảng
private void InitializeDatabase()
{
    // Tạo bảng NguoiDung
    // Tạo bảng MonAn với Foreign Key
    // Insert dữ liệu mẫu nếu là DB mới
}

// CRUD cho NguoiDung
public List<NguoiDung> GetAllNguoiDung()
public void AddNguoiDung(NguoiDung nguoiDung)
public NguoiDung GetNguoiDungById(int idncc)

// CRUD cho MonAn
public List<MonAn> GetAllMonAn()
public void AddMonAn(MonAn monAn)
public void DeleteMonAn(int idma)
public List<MonAn> GetMonAnByUser(int idncc)  // Chỉ Bài 7
```

**Connection String:**
```csharp
string connectionString = "Data Source=HomNayAnGi.db;Version=3;";
```

**SQL Queries mẫu:**
```sql
-- Tạo bảng NguoiDung
CREATE TABLE IF NOT EXISTS NguoiDung (
    IDNCC INTEGER PRIMARY KEY AUTOINCREMENT,
    HoVaTen TEXT NOT NULL,
    QuyenHan TEXT NOT NULL
)

-- Tạo bảng MonAn với Foreign Key
CREATE TABLE IF NOT EXISTS MonAn (
    IDMA INTEGER PRIMARY KEY AUTOINCREMENT,
    TenMonAn TEXT NOT NULL,
    HinhAnh TEXT,
    IDNCC INTEGER,
    FOREIGN KEY (IDNCC) REFERENCES NguoiDung(IDNCC)
)

-- Lấy tất cả món ăn
SELECT IDMA, TenMonAn, HinhAnh, IDNCC FROM MonAn

-- Thêm món ăn
INSERT INTO MonAn (TenMonAn, HinhAnh, IDNCC) 
VALUES (@TenMonAn, @HinhAnh, @IDNCC)
```

---

### Layer 3: Network Layer (Chỉ Bài 7)

#### **TcpServer.cs** - Server-side networking

**Luồng hoạt động:**
```
1. TcpListener.Start() → Lắng nghe trên port
2. AcceptClients() → Chạy trong thread riêng
3. Khi có client connect → Tạo thread mới HandleClient()
4. HandleClient() → Đọc request, xử lý, gửi response
5. ProcessRequest() → Route request đến database operations
```

**Code flow:**
```csharp
public void Start()
{
    listener.Start();
    Thread acceptThread = new Thread(AcceptClients);
    acceptThread.Start();
}

private void AcceptClients()
{
    while (isRunning)
    {
        TcpClient client = listener.AcceptTcpClient();
        Thread clientThread = new Thread(() => HandleClient(client));
        clientThread.Start();
    }
}

private void HandleClient(TcpClient client)
{
    while (client.Connected)
    {
        Message request = DeserializeMessage();
        Message response = ProcessRequest(request);
        SerializeMessage(response);
    }
}
```

#### **TcpClientHelper.cs** - Client-side networking

**Luồng hoạt động:**
```
1. Connect() → Kết nối đến server
2. SendRequest() → Serialize message và gửi
3. Nhận response từ server
4. Deserialize và return kết quả
```

**Code flow:**
```csharp
public bool Connect()
{
    client = new TcpClient();
    client.Connect(serverIP, serverPort);
    stream = client.GetStream();
}

private Message SendRequest(Message request)
{
    formatter.Serialize(stream, request);       // Gửi
    Message response = formatter.Deserialize(stream); // Nhận
    return response;
}

// Wrapper methods
public List<MonAn> GetAllMonAn()
{
    Message request = new Message { Action = "GET_ALL_MONAN" };
    Message response = SendRequest(request);
    return (List<MonAn>)response.Data;
}
```

---

### Layer 4: Presentation Layer (UI)

#### **MainForm.cs / ClientForm.cs / ServerForm.cs**

**Event Handlers:**

```csharp
// Khi form load
private void MainForm_Load(object sender, EventArgs e)
{
    LoadNguoiDung();  // Load danh sách người dùng vào ComboBox
    LoadMonAn();      // Load danh sách món ăn vào ListView
}

// Khi click nút Thêm
private void btnThem_Click(object sender, EventArgs e)
{
    // 1. Validate input
    // 2. Tạo object MonAn
    // 3. Gọi DatabaseHelper.AddMonAn() hoặc ClientHelper.AddMonAn()
    // 4. Refresh ListView
}

// Khi click nút Random
private void btnRandom_Click(object sender, EventArgs e)
{
    // 1. Lấy danh sách món ăn
    // 2. Random.Next() để chọn ngẫu nhiên
    // 3. Hiển thị kết quả lên Label và PictureBox
}
```

**ListView Operations:**
```csharp
private void LoadMonAn()
{
    listViewMonAn.Items.Clear();
    
    foreach (MonAn monAn in danhSachMonAn)
    {
        ListViewItem item = new ListViewItem(monAn.IDMA.ToString());
        item.SubItems.Add(monAn.TenMonAn);
        item.SubItems.Add(nguoiDung.HoVaTen);
        item.Tag = monAn;  // Lưu object để dùng sau
        listViewMonAn.Items.Add(item);
    }
}
```

---

## 🔄 Luồng dữ liệu

### Bài 6: Standalone Application

```
User Input
    ↓
MainForm (UI Layer)
    ↓
DatabaseHelper (Data Access Layer)
    ↓
SQLite Database
    ↓
DatabaseHelper (Data Access Layer)
    ↓
MainForm (UI Layer)
    ↓
Display to User
```

### Bài 7: Client-Server Architecture

```
Client Side:
User Input
    ↓
ClientForm (UI Layer)
    ↓
TcpClientHelper (Network Layer)
    ↓
Serialize Message
    ↓
TCP/IP Network
    
Server Side:
TCP/IP Network
    ↓
TcpServer.HandleClient()
    ↓
Deserialize Message
    ↓
ProcessRequest() → Route to DatabaseHelper
    ↓
SQLite Database
    ↓
DatabaseHelper returns data
    ↓
Serialize Response
    ↓
TCP/IP Network
    
Client Side:
TCP/IP Network
    ↓
Deserialize Response
    ↓
TcpClientHelper returns data
    ↓
ClientForm updates UI
    ↓
Display to User
```

---

## 🎯 Design Patterns sử dụng

### 1. **Repository Pattern** (DatabaseHelper)
- Tách biệt logic truy cập database khỏi business logic
- Dễ dàng thay đổi database engine mà không ảnh hưởng UI

### 2. **Data Transfer Object (DTO)** (Message class)
- Đóng gói dữ liệu để truyền qua network
- Chứa metadata (Action, Success, Error)

### 3. **Facade Pattern** (TcpClientHelper)
- Cung cấp interface đơn giản cho complex TCP operations
- Che giấu chi tiết serialization/deserialization

### 4. **Thread per Connection** (TcpServer)
- Mỗi client connection chạy trong thread riêng
- Cho phép xử lý nhiều clients đồng thời

---

## 🔐 Thread Safety trong Bài 7

**Server Side:**
```csharp
private object lockObject = new object();
private List<TcpClient> clients = new List<TcpClient>();

// Khi thêm/xóa client
lock (lockObject)
{
    clients.Add(client);  // Thread-safe
}
```

**UI Updates (Cross-thread):**
```csharp
private void LogMessage(string message)
{
    if (txtLog.InvokeRequired)
    {
        txtLog.Invoke(new Action<string>(LogMessage), message);
    }
    else
    {
        txtLog.AppendText(message + Environment.NewLine);
    }
}
```

---

## 📊 Database Schema

```
┌─────────────────┐
│   NguoiDung     │
├─────────────────┤
│ IDNCC (PK)      │──┐
│ HoVaTen         │  │
│ QuyenHan        │  │
└─────────────────┘  │
                     │ 1:N
                     │
┌─────────────────┐  │
│     MonAn       │  │
├─────────────────┤  │
│ IDMA (PK)       │  │
│ TenMonAn        │  │
│ HinhAnh         │  │
│ IDNCC (FK)      │──┘
└─────────────────┘
```

**Relationships:**
- 1 NguoiDung có thể có nhiều MonAn (1:N)
- 1 MonAn chỉ thuộc về 1 NguoiDung

---

## 🚀 Performance Considerations

### Bài 6:
- ✅ Connection được đóng ngay sau mỗi operation (using statement)
- ✅ Parameterized queries để tránh SQL injection
- ✅ Index tự động trên Primary Key

### Bài 7:
- ✅ Thread pool cho multi-client
- ✅ Non-blocking I/O với Thread.Sleep(10)
- ✅ Connection pooling (mỗi client có riêng connection)
- ❌ **Note**: BinaryFormatter deprecated trong .NET 5+, nên dùng JSON trong production

---

## 🔧 Customization Points

### Thêm chức năng mới:

**1. Edit món ăn:**
```csharp
// DatabaseHelper.cs
public void UpdateMonAn(MonAn monAn)
{
    string sql = "UPDATE MonAn SET TenMonAn=@Ten, HinhAnh=@Hinh WHERE IDMA=@ID";
    // Execute query
}

// Add Action vào Message
"UPDATE_MONAN"

// TcpServer ProcessRequest
case "UPDATE_MONAN":
    dbHelper.UpdateMonAn((MonAn)request.Data);
    break;
```

**2. Tìm kiếm món ăn:**
```csharp
public List<MonAn> SearchMonAn(string keyword)
{
    string sql = "SELECT * FROM MonAn WHERE TenMonAn LIKE @Keyword";
    // Execute with '%' + keyword + '%'
}
```

**3. Thêm hình ảnh upload:**
```csharp
// Sử dụng OpenFileDialog
OpenFileDialog ofd = new OpenFileDialog();
ofd.Filter = "Image Files|*.jpg;*.png;*.gif";
if (ofd.ShowDialog() == DialogResult.OK)
{
    txtHinhAnh.Text = ofd.FileName;
}
```

---

## 📝 Best Practices được áp dụng

1. ✅ **Separation of Concerns**: Models, Database, Network, UI tách biệt
2. ✅ **Error Handling**: Try-catch blocks ở các điểm quan trọng
3. ✅ **Resource Management**: Using statements cho database connections
4. ✅ **Thread Safety**: Lock objects cho shared resources
5. ✅ **User Feedback**: MessageBox cho errors, Label cho status
6. ✅ **Code Reusability**: Helper classes cho common operations
7. ✅ **Parameterized Queries**: Tránh SQL injection

---

## 🎓 Học hỏi thêm

### SQLite:
- Indexes cho performance
- Transactions cho batch operations
- Views cho complex queries

### Networking:
- Async/await thay vì threads
- WebSocket thay vì raw TCP
- gRPC hoặc SignalR cho real-time apps

### Architecture:
- MVVM pattern cho WPF
- Clean Architecture
- Repository Pattern với Unit of Work

---

**Happy Coding! 💻**
