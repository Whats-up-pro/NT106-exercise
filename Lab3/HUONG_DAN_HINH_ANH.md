# 📸 Hướng dẫn hiển thị hình ảnh món ăn

## ✨ Tính năng đã thêm

### 1. **Thêm món ăn với hình ảnh**
- Nút "Chọn ảnh..." để chọn file hình ảnh từ máy tính
- Hỗ trợ các định dạng: `.jpg`, `.jpeg`, `.png`, `.gif`, `.bmp`
- Xem trước (preview) hình ảnh ngay khi chọn
- Textbox "Hình ảnh" được đặt ở chế độ ReadOnly để tránh nhập sai đường dẫn

### 2. **Xem hình ảnh trong danh sách**
- Click vào bất kỳ món ăn nào trong ListView
- Hình ảnh sẽ hiển thị trong PictureBox bên phải
- Thông tin món ăn và người đóng góp hiển thị kèm theo

### 3. **Xem hình ảnh khi random**
- Random món ăn của tôi → Hiển thị hình ảnh món ăn của bạn
- Random cộng đồng → Hiển thị hình ảnh món ăn từ cộng đồng
- Tự động scale ảnh vừa với PictureBox (SizeMode = Zoom)

## 🎯 Cách sử dụng

### **Bước 1: Thêm món ăn mới**
1. Kết nối đến Server
2. Đăng nhập hoặc đăng ký tài khoản
3. Nhập tên món ăn (ví dụ: "Phở bò")
4. Bấm nút **"Chọn ảnh..."**
5. Chọn file hình ảnh từ máy tính của bạn
6. Xem trước hình ảnh trong PictureBox
7. Bấm **"Thêm"** để lưu món ăn

### **Bước 2: Xem hình ảnh món ăn**

#### Cách 1: Click vào danh sách
1. Trong "Danh sách món ăn", click vào bất kỳ món ăn nào
2. Hình ảnh hiển thị ngay tức thì bên phải
3. Thông tin người đóng góp hiển thị kèm theo

#### Cách 2: Random món ăn
1. Bấm **"Random của tôi"** hoặc **"Random cộng đồng"**
2. Hình ảnh món ăn được chọn ngẫu nhiên hiển thị
3. Thông tin món ăn và người đóng góp hiển thị

## 💡 Lưu ý quan trọng

### ⚠️ **Về đường dẫn file ảnh:**
- Đường dẫn file ảnh được lưu **tuyệt đối** (absolute path)
- Ví dụ: `C:\Users\YourName\Pictures\pho-bo.jpg`
- **Nếu di chuyển file ảnh**, phải thêm lại món ăn với đường dẫn mới

### 📁 **Khuyến nghị:**
1. Tạo thư mục riêng để lưu ảnh món ăn:
   ```
   D:\FoodImages\
   ```

2. Copy tất cả ảnh món ăn vào thư mục này

3. Không di chuyển hoặc xóa ảnh sau khi đã thêm vào hệ thống

### 🔄 **Để share ảnh giữa nhiều Client:**
- Đặt ảnh trong thư mục chung (shared folder/network drive)
- Tất cả client dùng chung đường dẫn này
- Hoặc dùng HTTP URL (cần sửa code để hỗ trợ)

## 🚀 Cải tiến trong tương lai

### Có thể thêm:
1. **Upload ảnh lên Server**: 
   - Server lưu trữ ảnh tập trung
   - Client tải ảnh từ server khi cần

2. **Base64 encoding**:
   - Encode ảnh thành Base64
   - Lưu trực tiếp vào database
   - Không phụ thuộc vào file system

3. **Thumbnail/Preview**:
   - Hiển thị thumbnail nhỏ trong ListView
   - Ảnh lớn khi click vào

4. **Cloud storage**:
   - Upload ảnh lên Google Drive, Imgur, etc.
   - Lưu URL thay vì đường dẫn local

## 📝 Code mẫu - Upload ảnh lên Server (tương lai)

```csharp
// Client gửi ảnh dưới dạng byte[]
public bool UploadImage(string filePath)
{
    byte[] imageBytes = File.ReadAllBytes(filePath);
    Message request = new Message 
    { 
        Action = "UPLOAD_IMAGE",
        Data = imageBytes
    };
    // ... send to server
}

// Server lưu ảnh vào thư mục
public string SaveImage(byte[] imageBytes, string fileName)
{
    string imagePath = Path.Combine("Images", fileName);
    File.WriteAllBytes(imagePath, imageBytes);
    return imagePath;
}
```

## 🎨 Demo Screenshots

### Thêm món ăn với ảnh:
```
+-------------------+
| Tên món ăn: Phở   |
| Hình ảnh: [Browse]|  [Preview Image]
| [Thêm] [Làm mới]  |
+-------------------+
```

### Xem món ăn trong danh sách:
```
+-------------------+     +------------------+
| ID | Món ăn | Người |   | 🍽️ Thông tin    |
|----|--------|-------|   | Món ăn: Phở     |
| 1  | Phở    | Minh  |   | Người: Minh     |
| 2  | Cơm    | Lan   |   |                 |
+-------------------+     | [Image Preview] |
                          +------------------+
```

## 📞 Hỗ trợ

Nếu gặp vấn đề:
1. Kiểm tra file ảnh có tồn tại không
2. Kiểm tra định dạng file (jpg, png, etc.)
3. Kiểm tra quyền đọc file
4. Xem thông báo lỗi chi tiết

---

**Phiên bản:** 3.1  
**Ngày cập nhật:** 20/10/2025  
**Người thực hiện:** GitHub Copilot 🤖
