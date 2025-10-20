# DEMO TESTING SCRIPT

## 📋 Test Cases cho Bài 6 - SQLite Version

### Test Case 1: Khởi động và hiển thị dữ liệu
**Bước thực hiện:**
1. Chạy ứng dụng Bài 6
2. Quan sát ListView

**Kết quả mong đợi:**
- ✅ Hiển thị ít nhất 3 món ăn mẫu
- ✅ Mỗi món ăn có ID, Tên, và Người đóng góp
- ✅ ComboBox hiển thị danh sách người dùng

---

### Test Case 2: Thêm món ăn mới
**Bước thực hiện:**
1. Nhập tên món ăn: "Bún Riêu"
2. Nhập hình ảnh: "bun_rieu.jpg" (hoặc để trống)
3. Chọn người đóng góp: "Nguyễn Văn A"
4. Click "Thêm"

**Kết quả mong đợi:**
- ✅ MessageBox "Thêm món ăn thành công!"
- ✅ ListView cập nhật với món ăn mới
- ✅ Input fields được clear

**Edge Cases:**
- ❌ Để trống tên món → Hiển thị warning
- ❌ Không chọn người đóng góp → Hiển thị warning

---

### Test Case 3: Xóa món ăn
**Bước thực hiện:**
1. Chọn một món ăn trong ListView
2. Click "Xóa"
3. Confirm trong MessageBox

**Kết quả mong đợi:**
- ✅ MessageBox xác nhận
- ✅ Món ăn biến mất khỏi ListView
- ✅ Database được cập nhật

**Edge Cases:**
- ❌ Không chọn món nào → Hiển thị warning

---

### Test Case 4: Random món ăn
**Bước thực hiện:**
1. Click "Chọn ngẫu nhiên món ăn"
2. Lặp lại nhiều lần

**Kết quả mong đợi:**
- ✅ Mỗi lần click hiển thị món ăn khác nhau (có thể trùng)
- ✅ Hiển thị tên món ăn
- ✅ Hiển thị người đóng góp
- ✅ Hiển thị hình ảnh (nếu file tồn tại)

**Edge Cases:**
- ❌ Danh sách rỗng → Hiển thị warning

---

### Test Case 5: Làm mới
**Bước thực hiện:**
1. Nhập một số thông tin vào input fields
2. Click "Làm mới"

**Kết quả mong đợi:**
- ✅ ListView được reload từ database
- ✅ Input fields được clear

---

### Test Case 6: Persistence (Database)
**Bước thực hiện:**
1. Thêm một món ăn mới
2. Đóng ứng dụng
3. Mở lại ứng dụng
4. Kiểm tra ListView

**Kết quả mong đợi:**
- ✅ Món ăn vừa thêm vẫn còn
- ✅ File `HomNayAnGi.db` được tạo trong thư mục app

---

## 📋 Test Cases cho Bài 7 - Server-Client Version

### Test Case 1: Khởi động Server
**Bước thực hiện:**
1. Chạy Bai7_Server
2. Giữ nguyên port 8888
3. Click "Start Server"

**Kết quả mong đợi:**
- ✅ Button "Start Server" disabled
- ✅ Button "Stop Server" enabled
- ✅ Status: "Running" (màu xanh)
- ✅ Log hiển thị "Server started on port 8888"

**Edge Cases:**
- ❌ Port đã được sử dụng → Error message
- ❌ Port không hợp lệ (abc, -1, 99999) → Error message

---

### Test Case 2: Kết nối Client
**Bước thực hiện:**
1. Với Server đang chạy
2. Chạy Bai7_Client
3. IP: 127.0.0.1, Port: 8888
4. Click "Kết nối"

**Kết quả mong đợi:**
- ✅ MessageBox "Kết nối server thành công!"
- ✅ GroupBox "Đăng nhập" được enabled
- ✅ ComboBox hiển thị danh sách người dùng
- ✅ Server log: "New client connected"

**Edge Cases:**
- ❌ Server không chạy → "Không thể kết nối"
- ❌ IP/Port sai → "Không thể kết nối"

---

### Test Case 3: Đăng nhập Client
**Bước thực hiện:**
1. Chọn người dùng: "Nguyễn Văn A"
2. Click "Đăng nhập"

**Kết quả mong đợi:**
- ✅ MessageBox "Đăng nhập thành công! Xin chào Nguyễn Văn A!"
- ✅ GroupBox "Thêm món ăn" enabled
- ✅ GroupBox "Hôm nay ăn gì?" enabled
- ✅ ListView hiển thị danh sách món ăn

---

### Test Case 4: Thêm món ăn từ Client
**Bước thực hiện:**
1. Nhập tên: "Cao Lầu Hội An"
2. Nhập hình ảnh: "cao_lau.jpg"
3. Click "Thêm"

**Kết quả mong đợi:**
- ✅ MessageBox "Thêm món ăn thành công!"
- ✅ ListView cập nhật
- ✅ Server log: "Processed request: ADD_MONAN"
- ✅ Input fields clear

---

### Test Case 5: Multi-Client Scenario
**Bước thực hiện:**
1. Giữ Server chạy
2. Mở Client 1, đăng nhập "Nguyễn Văn A", thêm món "Phở Gà"
3. Mở Client 2, đăng nhập "Trần Thị B", thêm món "Bánh Cuốn"
4. Cả 2 clients click "Làm mới"

**Kết quả mong đợi:**
- ✅ Server log hiển thị 2 clients connected
- ✅ Cả 2 clients đều thấy cả Phở Gà và Bánh Cuốn
- ✅ Database đồng bộ giữa các clients

---

### Test Case 6: Random món của tôi
**Bước thực hiện:**
1. Client 1 (User A) thêm 3 món ăn
2. Client 1 click "Random món của tôi"
3. Lặp lại nhiều lần

**Kết quả mong đợi:**
- ✅ Chỉ random trong 3 món của User A
- ✅ Hiển thị đúng thông tin món ăn
- ✅ Hiển thị "Món ăn của bạn"

**Edge Cases:**
- ❌ User chưa có món nào → "Bạn chưa có món ăn nào!"

---

### Test Case 7: Random từ cộng đồng
**Bước thực hiện:**
1. Client 1 (User A) có 2 món
2. Client 2 (User B) có 3 món
3. Cả 2 clients click "Random từ cộng đồng"

**Kết quả mong đợi:**
- ✅ Có thể random bất kỳ món nào trong 5 món
- ✅ User A có thể nhận món của User B và ngược lại
- ✅ Hiển thị "Món ăn từ cộng đồng"
- ✅ Hiển thị đúng người đóng góp

---

### Test Case 8: Server Stop và Restart
**Bước thực hiện:**
1. Có clients đang kết nối
2. Server click "Stop Server"
3. Quan sát clients
4. Server click "Start Server"

**Kết quả mong đợi:**
- ✅ Server log: "Server stopped"
- ✅ Clients bị disconnect
- ✅ Có thể start lại server
- ✅ Clients có thể reconnect

---

### Test Case 9: Database Persistence (Server)
**Bước thực hiện:**
1. Thêm nhiều món ăn từ clients
2. Stop server
3. Đóng tất cả clients
4. Start server lại
5. Connect client mới

**Kết quả mong đợi:**
- ✅ Tất cả món ăn vẫn còn
- ✅ File `ServerDatabase.db` tồn tại

---

### Test Case 10: Stress Test - Nhiều Clients
**Bước thực hiện:**
1. Start server
2. Mở 5 clients đồng thời
3. Mỗi client thêm 2 món ăn
4. Tất cả clients click làm mới

**Kết quả mong đợi:**
- ✅ Server xử lý được tất cả requests
- ✅ Tất cả clients thấy 10 món ăn
- ✅ Không có race condition
- ✅ Database consistent

---

## 🐛 Common Issues và Giải pháp

### Issue 1: "Port already in use"
**Symptoms:** Server không start được
**Solution:**
```bash
# Windows: Tìm process dùng port 8888
netstat -ano | findstr :8888
# Kill process với PID tương ứng
taskkill /PID <PID> /F
```

### Issue 2: Client không kết nối được
**Checklist:**
- [ ] Server đã start chưa?
- [ ] IP có đúng không? (127.0.0.1 cho localhost)
- [ ] Port có đúng không?
- [ ] Firewall có block không?

### Issue 3: Hình ảnh không hiển thị
**Giải pháp:**
- Sử dụng đường dẫn tuyệt đối
- Hoặc copy hình vào thư mục bin/Debug/net9.0-windows/

### Issue 4: Database locked
**Giải pháp:**
- Đóng tất cả instances của app
- Xóa file .db-wal và .db-shm
- Restart app

---

## 📊 Performance Metrics

### Bài 6:
- **Thêm món ăn:** < 100ms
- **Load danh sách:** < 200ms
- **Random:** < 10ms

### Bài 7:
- **Client connect:** < 500ms
- **Add món ăn (network):** < 300ms
- **Get danh sách (network):** < 500ms
- **Concurrent clients:** Hỗ trợ 10+ clients

---

## ✅ Acceptance Criteria

### Bài 6:
- [x] Tạo được database SQLite với 2 bảng
- [x] Hiển thị danh sách món ăn trong ListView
- [x] Thêm món ăn mới
- [x] Xóa món ăn
- [x] Random món ăn với thông tin đầy đủ
- [x] Data persistent sau khi restart app

### Bài 7:
- [x] Server start/stop thành công
- [x] Multi-client connection
- [x] Client login với user
- [x] Thêm món ăn từ client
- [x] Random món của bản thân
- [x] Random món từ cộng đồng
- [x] Data sync giữa clients
- [x] Database tập trung trên server

---

## 🎬 Demo Scenario cho Báo Cáo

### Scenario A: Bài 6 Demo (3-5 phút)

**Script:**
1. "Đây là ứng dụng Hôm nay ăn gì? sử dụng SQLite"
2. Mở app → "Database được khởi tạo tự động với dữ liệu mẫu"
3. Thêm món "Bún Bò Huế" → "Món ăn được lưu vào database"
4. Random 3 lần → "Mỗi lần random sẽ gợi ý 1 món khác nhau"
5. Đóng app → Mở lại → "Dữ liệu vẫn còn vì SQLite lưu persistent"

### Scenario B: Bài 7 Demo (5-7 phút)

**Script:**
1. "Đây là hệ thống Server-Client với database tập trung"
2. Start Server → "Server lắng nghe trên port 8888"
3. Mở Client 1, login User A → "Client kết nối thành công"
4. User A thêm món "Phở Gà" → "Server log shows request processed"
5. Mở Client 2, login User B → "Multi-client connection"
6. User B thêm món "Bánh Cuốn"
7. User A làm mới → "Thấy món của User B - database đồng bộ"
8. User A random món của tôi → "Chỉ random món của User A"
9. User B random từ cộng đồng → "Random tất cả món (A + B)"

---

**Chúc bạn test thành công! 🎉**
