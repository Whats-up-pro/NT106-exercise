# Lab02 - Server-Client Ticket Management System
**23521308 - Phạm Tấn Gia Quốc**

## Mô tả
Hệ thống quản lý phòng vé đa client với kiến trúc Server-Client sử dụng TCP/IP. 
Kế thừa từ bài 5 Lab02, phiên bản 3 này cho phép nhiều client kết nối đồng thời và đặt vé, 
với dữ liệu được đồng bộ hóa thời gian thực giữa các client.

## Tính năng

### Server
- Khởi động TCP Server trên cổng 8888
- Tải dữ liệu phim từ file `input5.txt`
- Quản lý nhiều client kết nối đồng thời
- Xử lý yêu cầu đặt vé với thread-safe locking
- Hiển thị danh sách phim và số vé còn lại theo thời gian thực
- Ghi log các hoạt động của client

### Client
- Kết nối tới Server qua TCP/IP
- Xem danh sách phim và số vé còn lại
- Đặt vé với kiểm tra tính khả dụng
- Tự động cập nhật khi có client khác đặt vé
- Hiển thị thông tin chi tiết phim và giá vé

### Đồng bộ hóa
- Khi một client đặt vé, tất cả client khác được cập nhật tự động
- Server đảm bảo không có hai client đặt cùng một vé
- Sử dụng thread locking để tránh race condition

## Cấu trúc file

### File mới được tạo:
- `NetworkMessage.cs` - Định nghĩa các message protocol
- `ServerForm.cs` / `ServerForm.Designer.cs` / `ServerForm.resx` - Giao diện Server
- `ClientForm.cs` / `ClientForm.Designer.cs` / `ClientForm.resx` - Giao diện Client
- `StartupForm.cs` / `StartupForm.Designer.cs` / `StartupForm.resx` - Menu chọn chế độ

### File được giữ nguyên:
- `Phim.cs` - Class model cho phim
- `Form5.cs` - Phiên bản standalone (bài cũ)
- `input5.txt` - Dữ liệu phim mẫu

## Hướng dẫn cài đặt

### Yêu cầu:
- Visual Studio 2017 hoặc mới hơn
- .NET Framework 4.7.2
- NuGet Package Manager

### Cài đặt packages:

#### Cách 1: Sử dụng Visual Studio
1. Mở file `Lab02.sln` trong Visual Studio
2. Nhấp chuột phải vào Solution và chọn "Restore NuGet Packages"
3. Build solution (Ctrl+Shift+B)

#### Cách 2: Sử dụng NuGet CLI
```bash
cd "d:\HK1_2025-2026\NT106.Q11.ANTT - LTM căn bản\Thực hành\Lab02"
nuget restore Lab02.sln
msbuild Lab02.sln /p:Configuration=Debug
```

#### Cách 3: Cài đặt package thủ công
Nếu NuGet không khả dụng, tải Newtonsoft.Json từ NuGet.org:
```bash
# Trong Package Manager Console của Visual Studio:
Install-Package Newtonsoft.Json -Version 13.0.3
```

## Hướng dẫn sử dụng

### 1. Chuẩn bị dữ liệu
Đảm bảo file `input5.txt` tồn tại trong thư mục `bin/Debug/` với định dạng:
```
<Tên phim>
<Giá vé>
<Phòng chiếu (ngăn cách bởi dấu phẩy)>
<Số vé đã bán>
<Số vé còn lại>
```

Ví dụ:
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
```

### 2. Khởi động Server
1. Chạy ứng dụng `Lab02.exe`
2. Chọn "Khởi động Server"
3. Nhấn nút "Khởi động Server"
4. Server sẽ lắng nghe trên cổng 8888

### 3. Khởi động Client (có thể chạy nhiều instance)
1. Chạy ứng dụng `Lab02.exe` lần nữa (instance mới)
2. Chọn "Khởi động Client"
3. Nhập địa chỉ IP của Server (mặc định: 127.0.0.1 cho localhost)
4. Nhấn "Kết nối"
5. Chọn phim và số lượng vé để đặt

### 4. Đặt vé
1. Trên Client, chọn phim từ dropdown
2. Nhập số lượng vé muốn đặt
3. Nhấn "Đặt vé"
4. Kiểm tra các client khác để thấy dữ liệu được cập nhật

## Kiến trúc kỹ thuật

### Protocol Communication
- **Transport**: TCP/IP
- **Port**: 8888
- **Format**: JSON serialization
- **Message Types**: 
  - Connect: Kết nối ban đầu
  - GetMovies: Lấy danh sách phim
  - BookTicket: Đặt vé
  - RefreshData: Cập nhật dữ liệu
  - Disconnect: Ngắt kết nối

### Thread Safety
- Server sử dụng `lock(lockObject)` để đảm bảo thread-safe khi xử lý booking
- Mỗi client có một thread riêng để xử lý
- UI updates sử dụng `Invoke()` để tránh cross-thread exceptions

### Real-time Synchronization
- Server broadcast update message khi có thay đổi
- Client có background thread để nhận updates
- Tự động refresh danh sách phim khi nhận được signal

## Testing

### Test case 1: Đặt vé thành công
1. Khởi động Server
2. Khởi động 2 Clients
3. Client 1 đặt 5 vé cho phim "Mai"
4. Kiểm tra Client 2 thấy số vé còn lại giảm đi 5

### Test case 2: Không đủ vé
1. Client 1 đặt hết vé cho một phim
2. Client 2 thử đặt vé cho cùng phim đó
3. Hệ thống hiển thị thông báo lỗi "Không đủ vé"

### Test case 3: Multiple concurrent bookings
1. Khởi động Server và 3 Clients
2. Các clients cùng đặt vé đồng thời
3. Kiểm tra tổng số vé bán không vượt quá số vé tồn

## Troubleshooting

### Lỗi: "Không tìm thấy file input5.txt"
- Copy file `input5.txt` vào thư mục `bin/Debug/`

### Lỗi: "Could not load file or assembly 'Newtonsoft.Json'"
- Restore NuGet packages hoặc cài đặt thủ công Newtonsoft.Json

### Lỗi: "Lỗi kết nối"
- Kiểm tra Server đã khởi động chưa
- Kiểm tra địa chỉ IP và port
- Tắt firewall hoặc cho phép ứng dụng qua firewall

### Server không nhận connections
- Kiểm tra port 8888 không bị chiếm dụng
- Chạy với quyền Administrator nếu cần

## Giới hạn và cải tiến tương lai

### Giới hạn hiện tại:
- Broadcast mechanism đơn giản (có thể cải thiện)
- Không có authentication/authorization
- Dữ liệu không được lưu trữ persistent (chỉ trong RAM)

### Cải tiến tương lai:
- Thêm database để lưu trữ lâu dài
- Implement user authentication
- Thêm payment gateway integration
- Thêm seat selection UI
- Export reports và statistics
- Implement reconnection logic
- Add SSL/TLS encryption

## Tác giả
**Phạm Tấn Gia Quốc - 23521308**  
NT106.Q11.ANTT - Lập trình mạng căn bản  
Lab02 - Bài thực hành 2
