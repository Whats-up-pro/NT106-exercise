# QUICK START GUIDE
## Server-Client Ticket Management System

### 🚀 5-MINUTE SETUP

#### Step 1: Open in Visual Studio (30 seconds)
```
1. Double-click: Lab02.sln
2. Wait for Visual Studio to load
```

#### Step 2: Restore Packages (1 minute)
```
Option A (Recommended):
- Right-click on Solution in Solution Explorer
- Click "Restore NuGet Packages"
- Wait for completion

Option B (If Option A fails):
- Tools → NuGet Package Manager → Package Manager Console
- Run: Install-Package Newtonsoft.Json -Version 13.0.3
```

#### Step 3: Build (30 seconds)
```
Press: Ctrl + Shift + B
Or: Build → Build Solution
```

#### Step 4: Copy Data File (10 seconds)
```
Copy: input5.txt
To: bin\Debug\input5.txt
```

#### Step 5: Run! (3 minutes)
```
First instance:
1. Press F5 or click "Start"
2. Choose "Khởi động Server"
3. Click "Khởi động Server" button

Second instance (new window):
1. Run bin\Debug\Lab02.exe again
2. Choose "Khởi động Client"
3. Server IP: 127.0.0.1
4. Click "Kết nối"
5. Select movie and book tickets!

Third instance (optional):
- Repeat step 2 to test multiple clients
```

---

## 🎯 TEST IN 2 MINUTES

### Quick Test Scenario:
```
1. Server: Click "Khởi động Server" 
   ✓ See movies loaded

2. Client 1: Connect, book 5 tickets for "Mai"
   ✓ Success message appears
   ✓ Tickets reduce from 20 to 15

3. Client 2: Connect (if running)
   ✓ Automatically sees 15 tickets (not 20)
   ✓ Real-time sync working!

4. Client 2: Try booking 20 tickets
   ✓ Error: "Không đủ vé! Chỉ còn 15 vé."
   ✓ Validation working!
```

---

## ⚠️ TROUBLESHOOTING (30 seconds each)

### Problem: Build errors about Newtonsoft.Json
```
Solution:
1. Tools → NuGet Package Manager → Package Manager Console
2. Run: Install-Package Newtonsoft.Json -Version 13.0.3
3. Rebuild (Ctrl+Shift+B)
```

### Problem: "Không tìm thấy file input5.txt"
```
Solution:
Copy input5.txt to bin\Debug\ folder
```

### Problem: Client can't connect
```
Solution:
1. Make sure Server is running first
2. Use 127.0.0.1 for same computer
3. Turn off firewall temporarily
```

---

## 📊 SAMPLE DATA (input5.txt)

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

## ✅ SUCCESS INDICATORS

You'll know it's working when you see:

**Server:**
```
[12:30:45] Server đã khởi động trên cổng 8888
[12:30:50] Đã load 4 phim từ file
[12:31:00] Client mới kết nối. Tổng: 1
[12:31:15] Client-1234 đã đặt 5 vé cho 'Mai'
```

**Client:**
```
[12:31:00] Đã kết nối tới server!
[12:31:15] Đặt thành công 5 vé cho phim 'Mai'
[12:31:16] Dữ liệu đã được cập nhật từ server
```

**DataGridView:**
- Shows all movies with prices
- Ticket counts update in real-time
- All clients show same data

---

## 🎓 LEARNING POINTS

This project demonstrates:
- ✅ TCP/IP Socket Programming
- ✅ Multi-threaded Server
- ✅ Thread-safe operations (locking)
- ✅ JSON serialization
- ✅ Real-time synchronization
- ✅ Windows Forms UI
- ✅ Client-Server architecture

---

## 📞 NEED HELP?

Check these files:
1. **README.md** - Technical overview
2. **HUONG_DAN_SU_DUNG.md** - Detailed guide (Vietnamese)
3. **TOM_TAT_DU_AN.md** - Complete project summary

**Author:** Phạm Tấn Gia Quốc - 23521308
