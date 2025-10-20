# 🎯 HƯỚNG DẪN THÊM NGƯỜI ĐÓNG GÓP

## Đã cập nhật: Bài 6 - Quản lý người dùng

### ✨ Tính năng mới

**Bài 6** giờ đây có thêm form "Quản lý người dùng" cho phép:
- ✅ Xem danh sách tất cả người dùng
- ✅ Thêm người dùng mới (người đóng góp món ăn)
- ✅ Chọn quyền hạn: User hoặc Admin

---

## 📝 Cách sử dụng - Bài 6 (SQLite)

### Bước 1: Mở form quản lý người dùng

1. Chạy ứng dụng Bài 6
2. Ở góc dưới bên trái, click nút **"Quản lý người dùng"**
3. Cửa sổ mới sẽ hiện ra

### Bước 2: Xem danh sách người dùng hiện tại

- ListView sẽ hiển thị:
  - **ID**: Mã người dùng
  - **Họ và tên**: Tên đầy đủ
  - **Quyền hạn**: User hoặc Admin

### Bước 3: Thêm người dùng mới

1. Nhập **Họ và tên** (VD: "Lê Thị C")
2. Chọn **Quyền hạn** từ dropdown:
   - `User` - Người dùng thông thường
   - `Admin` - Quản trị viên
3. Click nút **"Thêm"**
4. Thông báo "Thêm người dùng thành công!" sẽ hiện ra
5. Danh sách tự động cập nhật

### Bước 4: Sử dụng người dùng mới

1. Click nút **"Đóng"** để quay về màn hình chính
2. ComboBox "Người đóng góp" sẽ tự động cập nhật
3. Bây giờ bạn có thể chọn người dùng mới khi thêm món ăn!

---

## 🎬 Demo nhanh

```
1. Run Bài 6
2. Click "Quản lý người dùng"
3. Nhập:
   - Họ và tên: "Phạm Văn D"
   - Quyền hạn: "User"
4. Click "Thêm"
5. Click "Đóng"
6. Thêm món ăn mới với người đóng góp "Phạm Văn D"
```

---

## 📋 Validation

Form sẽ kiểm tra:
- ❌ Họ và tên không được để trống
- ❌ Phải chọn quyền hạn

---

## 🔧 Bài 7 - Server/Client

### Đối với Server:

Server tự động có sẵn người dùng mẫu trong database.

**Nếu muốn thêm người dùng mới:**

#### Option 1: Sử dụng SQLite Browser
1. Download SQLite Browser: https://sqlitebrowser.org/
2. Mở file `ServerDatabase.db` trong thư mục `Bai7_Server`
3. Tab "Browse Data" → Bảng "NguoiDung"
4. Click "Insert Record"
5. Nhập:
   - `HoVaTen`: Tên người dùng
   - `QuyenHan`: "User" hoặc "Admin"
6. Save

#### Option 2: Thêm vào code DatabaseHelper
Trong file `Bai7_Server/Database/DatabaseHelper.cs`, method `InsertSampleData()`:

```csharp
string[] nguoiDung = {
    "INSERT INTO NguoiDung (HoVaTen, QuyenHan) VALUES ('Admin', 'Admin')",
    "INSERT INTO NguoiDung (HoVaTen, QuyenHan) VALUES ('Nguyễn Văn A', 'User')",
    "INSERT INTO NguoiDung (HoVaTen, QuyenHan) VALUES ('Trần Thị B', 'User')",
    // THÊM DÒNG MỚI
    "INSERT INTO NguoiDung (HoVaTen, QuyenHan) VALUES ('Tên Mới', 'User')"
};
```

Sau đó:
1. Xóa file `ServerDatabase.db`
2. Chạy lại Server để tạo database mới

### Đối với Client:

Client sẽ tự động lấy danh sách người dùng từ Server khi kết nối.

---

## 🎯 Screenshot minh họa

### Bài 6 - Quản lý người dùng:

```
┌────────────────────────────────────────┐
│  Quản lý người dùng               [X] │
├────────────────────────────────────────┤
│ ┌─ Danh sách người dùng ──────────┐   │
│ │ ID │ Họ và tên       │ Quyền hạn│   │
│ │  1 │ Admin           │ Admin    │   │
│ │  2 │ Nguyễn Văn A    │ User     │   │
│ │  3 │ Trần Thị B      │ User     │   │
│ └──────────────────────────────────┘   │
│                                         │
│ ┌─ Thêm người dùng mới ────────────┐   │
│ │ Họ và tên:  [________________]   │   │
│ │ Quyền hạn:  [User ▼]             │   │
│ │             [Thêm]               │   │
│ └──────────────────────────────────┘   │
│                                         │
│                        [Đóng]          │
└────────────────────────────────────────┘
```

---

## ✅ Test Cases

### Test 1: Thêm người dùng hợp lệ
**Input:**
- Họ và tên: "Lê Văn E"
- Quyền hạn: "User"

**Expected:**
- ✅ MessageBox "Thêm người dùng thành công!"
- ✅ ListView cập nhật với user mới
- ✅ Input fields được clear

### Test 2: Để trống họ tên
**Input:**
- Họ và tên: ""
- Quyền hạn: "User"

**Expected:**
- ❌ MessageBox "Vui lòng nhập họ và tên!"

### Test 3: Không chọn quyền hạn
**Input:**
- Họ và tên: "Test"
- Quyền hạn: (không chọn)

**Expected:**
- ❌ MessageBox "Vui lòng chọn quyền hạn!"

### Test 4: Persistence
**Steps:**
1. Thêm người dùng mới
2. Đóng ứng dụng
3. Mở lại ứng dụng
4. Kiểm tra người dùng

**Expected:**
- ✅ Người dùng mới vẫn còn trong database

---

## 🔍 Troubleshooting

### Lỗi: "Không thể thêm người dùng"
**Nguyên nhân:** Database bị lock hoặc corrupt

**Giải pháp:**
1. Đóng tất cả ứng dụng
2. Xóa file `.db-wal` và `.db-shm`
3. Chạy lại ứng dụng

### Lỗi: ComboBox không cập nhật
**Nguyên nhân:** Chưa reload sau khi thêm user

**Giải pháp:**
- Form tự động gọi `LoadNguoiDung()` khi đóng
- Nếu vẫn không cập nhật, click "Làm mới"

---

## 📚 Technical Details

### Files mới:
- `NguoiDungForm.cs` - Business logic
- `NguoiDungForm.Designer.cs` - UI design

### Files cập nhật:
- `MainForm.Designer.cs` - Thêm button "Quản lý người dùng"
- `MainForm.cs` - Thêm event handler

### Database Operations:
```csharp
// Thêm người dùng mới
public void AddNguoiDung(NguoiDung nguoiDung)
{
    // INSERT INTO NguoiDung...
}

// Lấy tất cả người dùng
public List<NguoiDung> GetAllNguoiDung()
{
    // SELECT * FROM NguoiDung
}
```

---

## 🎓 Best Practices

1. **Đặt tên người dùng rõ ràng**
   - ✅ "Nguyễn Văn A"
   - ❌ "User1", "Test"

2. **Chọn quyền hạn phù hợp**
   - `User` - Cho người dùng thông thường
   - `Admin` - Chỉ cho quản trị viên

3. **Kiểm tra trùng lặp**
   - Database cho phép tên trùng (không có constraint UNIQUE)
   - Nên kiểm tra manual trước khi thêm

---

## 💡 Tips & Tricks

1. **Thêm nhiều người dùng nhanh:**
   - Nhập tên → Tab → Chọn quyền → Enter
   - Form tự động clear sau khi thêm

2. **Sửa người dùng:**
   - Hiện tại chưa có tính năng Edit
   - Sử dụng SQLite Browser để edit

3. **Xóa người dùng:**
   - Hiện tại chưa có tính năng Delete
   - Sử dụng SQLite Browser để xóa

---

## 🚀 Future Enhancements

Tính năng có thể thêm vào sau:
- [ ] Sửa thông tin người dùng
- [ ] Xóa người dùng (with cascade delete cho món ăn)
- [ ] Tìm kiếm người dùng
- [ ] Sắp xếp theo tên/quyền hạn
- [ ] Export danh sách người dùng

---

**Chúc bạn thành công! 🎉**

*Cập nhật: October 20, 2025*
