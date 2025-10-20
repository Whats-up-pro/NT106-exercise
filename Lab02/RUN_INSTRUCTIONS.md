# ✅ BUILD HOÀN TẤT - HƯỚNG DẪN CHẠY ỨNG DỤNG

## 🎉 Chúc mừng! Project đã build thành công!

### 📁 Files đã tạo:
```
✅ bin/Debug/Lab02.exe          - Ứng dụng chính
✅ bin/Debug/Newtonsoft.Json.dll - JSON library
✅ bin/Debug/input5.txt          - Dữ liệu phim
✅ bin/Debug/Lab02.exe.config    - Config file
```

---

## 🚀 CÁCH CHẠY ỨNG DỤNG

### Cách 1: Double-click (Đơn giản nhất)
```
1. Mở thư mục: bin\Debug\
2. Nhấn đúp vào: Lab02.exe
3. Chọn chế độ: Server hoặc Client
```

### Cách 2: Từ Command Line
```bash
cd bin/Debug
./Lab02.exe
```

### Cách 3: Từ Visual Studio
```
1. Mở Lab02.sln
2. Nhấn F5 (Run with debugging)
   hoặc Ctrl+F5 (Run without debugging)
```

---

## 📋 HƯỚNG DẪN SỬ DỤNG CHI TIẾT

### Bước 1: Chạy Server
```
1. Chạy Lab02.exe (lần đầu)
2. Click "Khởi động Server"
3. Click nút "Khởi động Server"
4. Server sẽ hiển thị:
   - Danh sách 4 phim
   - Log: "Server đã khởi động trên cổng 8888"
```

### Bước 2: Chạy Client (có thể chạy nhiều)
```
1. Chạy Lab02.exe LẦN NỮA (instance mới)
   
   Cách mở nhiều instances:
   - Cách A: Nhấn đúp Lab02.exe lại trong Explorer
   - Cách B: Mở terminal mới và chạy: bin/Debug/Lab02.exe
   - Cách C: Từ cmd: start bin\Debug\Lab02.exe

2. Click "Khởi động Client"
3. Nhập Server IP: 127.0.0.1
4. Click "Kết nối"
5. Danh sách phim sẽ hiển thị
```

### Bước 3: Đặt vé
```
1. Trên Client, chọn phim từ dropdown
2. Nhập số lượng vé (tối đa = số vé còn lại)
3. Click "Đặt vé"
4. Quan sát:
   - Client: Thông báo thành công
   - Server: Log hiển thị booking
   - Tất cả Clients: Tự động cập nhật số vé
```

---

## 🧪 TEST ĐƠN GIẢN

### Test 1: Chạy Server
```bash
# Terminal 1:
cd bin/Debug
./Lab02.exe

# Chọn "Khởi động Server"
# Click "Khởi động Server"
# ✓ Thấy 4 phim trong DataGridView
```

### Test 2: Chạy 1 Client
```bash
# Terminal 2 (hoặc double-click Lab02.exe lần nữa):
cd bin/Debug
./Lab02.exe

# Chọn "Khởi động Client"
# IP: 127.0.0.1
# Click "Kết nối"
# ✓ Thấy danh sách phim
```

### Test 3: Đặt vé
```
# Trên Client:
1. Chọn phim "Mai" (có 20 vé)
2. Số lượng: 5
3. Click "Đặt vé"
# ✓ Thành công
# ✓ Còn 15 vé
```

### Test 4: Chạy Client thứ 2
```bash
# Terminal 3:
cd bin/Debug
./Lab02.exe

# Chọn Client, kết nối
# ✓ Thấy phim "Mai" còn 15 vé (không phải 20)
# ✓ Đồng bộ đang hoạt động!
```

---

## 📊 DỮ LIỆU MẪU (input5.txt)

File `bin/Debug/input5.txt` chứa:
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

---

## 🎮 CÁC TÍNH NĂNG CHÍNH

### Server:
- ✅ Quản lý dữ liệu tập trung
- ✅ Xử lý nhiều clients đồng thời
- ✅ Thread-safe booking
- ✅ Real-time updates
- ✅ Comprehensive logging

### Client:
- ✅ Kết nối tới server
- ✅ Xem danh sách phim
- ✅ Đặt vé với validation
- ✅ Tự động refresh khi có thay đổi
- ✅ Hiển thị thông tin chi tiết

### Đồng bộ:
- ✅ Client A đặt vé → Client B tự động cập nhật
- ✅ Không thể đặt trùng vé
- ✅ Real-time synchronization

---

## 🛠️ TROUBLESHOOTING

### Lỗi: "Không tìm thấy file input5.txt"
```
Giải pháp:
File đã có trong bin/Debug/input5.txt rồi
Nếu bị xóa, copy lại từ thư mục gốc
```

### Lỗi: "Lỗi kết nối"
```
Nguyên nhân: Server chưa chạy
Giải pháp: Khởi động Server trước khi chạy Client
```

### Lỗi: "Không đủ vé"
```
Đây là tính năng, không phải lỗi!
Có nghĩa là vé đã hết hoặc không đủ số lượng
```

---

## 📝 BUILD TRONG TƯƠNG LAI

Nếu bạn sửa code và cần build lại:

### Cách 1: Dùng quick-build.bat
```bash
./quick-build.bat
```

### Cách 2: Dùng Visual Studio
```
1. Mở Lab02.sln
2. Build → Rebuild Solution (Ctrl+Shift+B)
```

### Cách 3: Dùng Developer Command Prompt
```cmd
cd "d:\HK1_2025-2026\NT106.Q11.ANTT - LTM can ban\Thuc hanh\Lab02"
msbuild Lab02.sln /p:Configuration=Debug /p:Platform="Any CPU"
```

---

## 🎯 CHECKLIST HOÀN THÀNH

✅ Code đã viết xong
✅ NuGet packages đã restore
✅ Build thành công
✅ Lab02.exe đã tạo ra
✅ input5.txt đã có trong bin/Debug
✅ Tất cả dependencies đã sẵn sàng
✅ Sẵn sàng để chạy và test!

---

## 📚 TÀI LIỆU THAM KHẢO

- **README.md** - Tổng quan kỹ thuật
- **HUONG_DAN_SU_DUNG.md** - Hướng dẫn chi tiết
- **QUICK_START.md** - Hướng dẫn nhanh
- **TOM_TAT_DU_AN.md** - Tổng kết dự án
- **ARCHITECTURE.md** - Sơ đồ kiến trúc
- **BUILD_INSTRUCTIONS.md** - Hướng dẫn build

---

## 🎊 CHÚC MỪNG!

Bạn đã hoàn thành xong project! Bây giờ:

1. ✅ Chạy Server
2. ✅ Chạy 2-3 Clients
3. ✅ Test đặt vé
4. ✅ Quan sát đồng bộ real-time

**Have fun!** 🚀

---

**Author:** Phạm Tấn Gia Quốc - 23521308  
**Course:** NT106.Q11.ANTT - Network Programming  
**Status:** ✅ COMPLETE & READY TO RUN
