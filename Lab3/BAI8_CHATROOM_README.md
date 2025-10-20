# 💬 Bài 8: Chat Room - Multi Client

## 📋 Mô tả đề bài

Viết chương trình **Chat Room** sử dụng TCP Client và TCP Listener với các tính năng:
- ✅ Multi-client (nhiều người dùng cùng lúc)
- ✅ Public chat (tin nhắn công khai cho mọi người)
- ✅ Private chat (tin nhắn riêng tư giữa 2 người)
- ✅ Gửi file `.txt`
- ✅ Gửi hình ảnh `.jpg`, `.png`
- ✅ Không cần đăng ký/đăng nhập (chỉ cần nhập tên)

## 🎯 Tính năng đã triển khai

### Server:
1. **Quản lý kết nối**: Accept nhiều client cùng lúc
2. **Broadcast**: Gửi tin nhắn public đến tất cả client
3. **Private message**: Chuyển tin nhắn riêng giữa 2 client
4. **User list**: Cập nhật danh sách user online
5. **File/Image transfer**: Chuyển tiếp file và hình ảnh
6. **Logging**: Hiển thị tất cả hoạt động trên server

### Client:
1. **3 tabs chính**:
   - **Public Chat**: Chat công khai với mọi người
   - **Private Chat**: Chat riêng với 1 người
   - **Send Files/Images**: Gửi file và hình ảnh

2. **Tính năng**:
   - Hiển thị danh sách user online (bên phải)
   - Chọn user để chat riêng
   - Gửi tin nhắn bằng nút Send hoặc Enter
   - Preview hình ảnh nhận được
   - Lưu file/hình ảnh nhận được
   - Màu sắc phân biệt loại tin nhắn

## 🚀 Cách chạy

### Bước 1: Start Server
```bash
cd "d:/HK1_2025-2026/NT106.Q11.ANTT - LTM căn bản/Thực hành/Lab3/Bai8_ChatRoom_Server"
dotnet run
```
- Nhập Port (mặc định: 8888)
- Bấm "Start Server"
- Server sẵn sàng nhận kết nối

### Bước 2: Start Clients (nhiều client)
```bash
cd "d:/HK1_2025-2026/NT106.Q11.ANTT - LTM căn bản/Thực hành/Lab3/Bai8_ChatRoom_Client"
dotnet run
```
- Nhập Server IP (127.0.0.1)
- Nhập Port (8888)
- Nhập tên của bạn (ví dụ: "Alice")
- Bấm "Connect"

**Lặp lại** để mở nhiều client với tên khác nhau!

## 📝 Hướng dẫn sử dụng

### 1. Public Chat (Chat công khai)
- Tab "Public Chat"
- Nhập tin nhắn
- Enter hoặc bấm "Send"
- **Tất cả** mọi người sẽ thấy tin nhắn

### 2. Private Chat (Chat riêng)
- Tab "Private Chat"
- Chọn người dùng từ danh sách bên phải
- Nhập tin nhắn
- Enter hoặc bấm "Send Private"
- **Chỉ** người được chọn nhận được tin nhắn

### 3. Gửi File (.txt)
- Tab "Send Files/Images"
- Section "Send File (.txt)"
- Bấm "📎 Choose File..."
- Chọn file .txt
- ✅ Tick "Send to selected user" nếu muốn gửi riêng
- File được gửi

### 4. Gửi Hình ảnh (.jpg, .png)
- Tab "Send Files/Images"
- Section "Send Image"
- Bấm "📷 Choose Image..."
- Chọn file ảnh
- ✅ Tick "Send to selected user" nếu muốn gửi riêng
- Hình ảnh được gửi

### 5. Nhận File/Hình ảnh
- **File**: Popup hỏi có muốn lưu không
- **Hình ảnh**: Tự động hiển thị preview, có nút "Save Image"

## 🎨 Giao diện

### Server:
```
┌─────────────────────────────────┐
│  Server Control                 │
│  Port: [8888] [Start] [Stop]    │
├─────────────────────────────────┤
│  Status: 🟢 Running - Online: 3 │
├─────────────────────────────────┤
│  Server Log                     │
│  [Clear Log]                    │
│  ┌───────────────────────────┐  │
│  │ [12:34:56] Alice joined   │  │
│  │ [12:35:10] Bob joined     │  │
│  │ [12:35:20] [PUBLIC] Alice │  │
│  └───────────────────────────┘  │
└─────────────────────────────────┘
```

### Client:
```
┌────────────────────────────────────────────┐
│ Connection                                 │
│ IP: [127.0.0.1] Port: [8888] Name: [Alice]│
│ [Connect]                                  │
├────────────────────────────────────────────┤
│ ┌──────────────────┬──────────────────┐   │
│ │ Public Chat      │ Online Users     │   │
│ │                  │ - Bob            │   │
│ │ Bob: Hello!      │ - Charlie        │   │
│ │ Alice: Hi Bob!   │                  │   │
│ │ [Message____] [Send]                │   │
│ ├──────────────────┴──────────────────┤   │
│ │ Private Chat                         │   │
│ │ Chat with: Bob                       │   │
│ │ Alice -> Bob: Secret message         │   │
│ │ [Message____] [Send Private]         │   │
│ ├──────────────────────────────────────┤   │
│ │ Send Files/Images                    │   │
│ │ [📎 Choose File...] ☐ Private       │   │
│ │ [📷 Choose Image...] ☐ Private      │   │
│ └──────────────────────────────────────┘   │
└────────────────────────────────────────────┘
```

## 🔧 Kiến trúc kỹ thuật

### Protocol:
- **Transport**: TCP/IP
- **Serialization**: JSON (System.Text.Json)
- **Message Format**: Length-prefix (4 bytes) + JSON data

### Message Types:
- `JOIN`: User tham gia chat
- `LEAVE`: User rời chat
- `PUBLIC`: Tin nhắn công khai
- `PRIVATE`: Tin nhắn riêng tư
- `FILE`: Gửi file .txt
- `IMAGE`: Gửi hình ảnh
- `USER_LIST`: Cập nhật danh sách user

### ChatMessage Model:
```csharp
public class ChatMessage
{
    public string Type { get; set; }
    public string SenderName { get; set; }
    public string ReceiverName { get; set; }
    public string Content { get; set; }
    public byte[] FileData { get; set; }
    public string FileName { get; set; }
    public DateTime Timestamp { get; set; }
    public string[] UserList { get; set; }
}
```

## 📊 Flow hoạt động

### 1. Kết nối:
```
Client                          Server
  |                               |
  |------ JOIN (username) ------->|
  |<----- USER_LIST --------------|
  |<----- Broadcast JOIN ---------|
```

### 2. Public Chat:
```
Client A                        Server                    Client B,C
  |                               |                           |
  |------ PUBLIC message -------->|                           |
  |                               |------- Broadcast -------->|
  |<----- Echo -------------------|                           |
```

### 3. Private Chat:
```
Client A                        Server                    Client B
  |                               |                           |
  |-- PRIVATE (A->B) ------------>|                           |
  |<----- Echo -------------------|-------- PRIVATE --------->|
```

### 4. File/Image:
```
Client                          Server                    Others
  |                               |                           |
  |-- FILE/IMAGE (with bytes) --->|                           |
  |                               |-- Broadcast/Forward ----->|
  |                               |                           |
  |                               |                  [Save dialog]
```

## 🎓 Demo Scenario

### Scenario 1: Group Chat
1. Alice, Bob, Charlie kết nối
2. Alice: "Hello everyone!"
3. Bob: "Hi Alice!"
4. Charlie: "Hey guys!"
→ **Kết quả**: Tất cả thấy tin nhắn của nhau

### Scenario 2: Private Chat
1. Alice chọn Bob từ danh sách
2. Alice gửi: "Bob, can we talk?"
3. Bob nhận tin nhắn riêng
4. Bob reply riêng cho Alice
→ **Kết quả**: Chỉ Alice và Bob thấy

### Scenario 3: File Sharing
1. Alice gửi file "homework.txt" (public)
2. Popup hiện ở Bob và Charlie
3. Bob save file
4. Charlie ignore
→ **Kết quả**: Bob có file, Charlie không

### Scenario 4: Image Sharing
1. Charlie gửi ảnh "photo.jpg" riêng cho Alice
2. Preview hiện ở Alice
3. Alice save ảnh
→ **Kết quả**: Chỉ Alice thấy ảnh

## ⚠️ Lưu ý

### 1. Tên người dùng:
- Phải unique (không trùng)
- Server không kiểm tra trùng (client sau kết nối nhưng không hoạt động đúng)
- **Nên thêm**: Kiểm tra tên trùng ở server

### 2. Kích thước file:
- Không giới hạn (có thể gửi file lớn)
- **Nên thêm**: Giới hạn kích thước (ví dụ: 10MB)

### 3. Bảo mật:
- Không mã hóa (plain text)
- **Nên thêm**: Mã hóa SSL/TLS

### 4. Error handling:
- Có xử lý disconnect
- **Nên thêm**: Retry logic, timeout

## 🔄 Cải tiến có thể thêm

### Level 1 (Easy):
- [ ] Kiểm tra tên trùng
- [ ] Giới hạn kích thước file
- [ ] Emoji picker
- [ ] Timestamp format options

### Level 2 (Medium):
- [ ] Lưu lịch sử chat
- [ ] Group chat (tạo room riêng)
- [ ] User status (online/away/busy)
- [ ] Typing indicator

### Level 3 (Hard):
- [ ] Database (lưu tin nhắn)
- [ ] Voice messages
- [ ] Video call
- [ ] End-to-end encryption

## 📚 Tài liệu tham khảo

- **TcpListener**: https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.tcplistener
- **TcpClient**: https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.tcpclient
- **NetworkStream**: https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.networkstream
- **JSON Serialization**: https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json

## 🎉 Kết luận

Bài 8 hoàn thiện với đầy đủ tính năng yêu cầu:
- ✅ Multi-client chat room
- ✅ Public và Private chat
- ✅ Gửi file .txt
- ✅ Gửi hình ảnh .jpg, .png
- ✅ UI thân thiện, dễ sử dụng
- ✅ Server quản lý kết nối hiệu quả

**Điểm mạnh:**
- Code rõ ràng, dễ hiểu
- UI đẹp với TabControl
- Xử lý file/image tốt
- Real-time user list

**Có thể cải thiện:**
- Thêm kiểm tra tên trùng
- Mã hóa dữ liệu
- Lưu lịch sử chat

---

**Tác giả:** GitHub Copilot 🤖  
**Ngày:** 20/10/2025  
**Môn học:** NT106.Q11.ANTT - LTM căn bản
