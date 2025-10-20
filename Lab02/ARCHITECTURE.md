# SYSTEM ARCHITECTURE DIAGRAMS

## 1. OVERALL SYSTEM ARCHITECTURE

```
┌─────────────────────────────────────────────────────────────────┐
│                         USER STARTS APP                         │
│                          Lab02.exe                              │
└────────────────────────────┬────────────────────────────────────┘
                             │
                             ▼
                   ┌──────────────────┐
                   │  StartupForm     │
                   │  Choose Mode:    │
                   │  ┌────────────┐  │
                   │  │ Server     │  │
                   │  │ Client     │  │
                   │  │ Form5      │  │
                   │  └────────────┘  │
                   └────┬────────┬────┘
                        │        │
           ┌────────────┘        └────────────┐
           │                                  │
           ▼                                  ▼
    ┌─────────────┐                    ┌─────────────┐
    │ ServerForm  │                    │ ClientForm  │
    │             │                    │             │
    │ ┌─────────┐ │                    │ ┌─────────┐ │
    │ │ Start   │ │                    │ │ Connect │ │
    │ │ Stop    │ │◄──────TCP─────────►│ │ Book    │ │
    │ └─────────┘ │   Port 8888        │ │ Refresh │ │
    │             │   JSON Messages    │ └─────────┘ │
    │ ┌─────────┐ │                    │             │
    │ │ Movies  │ │                    │ ┌─────────┐ │
    │ │ Grid    │ │                    │ │ Movies  │ │
    │ └─────────┘ │                    │ │ Grid    │ │
    │             │                    │ └─────────┘ │
    │ ┌─────────┐ │                    │             │
    │ │ Log     │ │                    │ ┌─────────┐ │
    │ │ Text    │ │                    │ │ Log     │ │
    │ └─────────┘ │                    │ │ Text    │ │
    └──────┬──────┘                    │ └─────────┘ │
           │                           └─────────────┘
           │
           ▼
    ┌─────────────┐
    │ input5.txt  │
    │             │
    │ Movie Data  │
    └─────────────┘
```

---

## 2. MULTI-CLIENT SCENARIO

```
                    ┌──────────────────┐
                    │  SERVER          │
                    │  Port: 8888      │
                    │  Thread Pool     │
                    └────────┬─────────┘
                             │
                    ┌────────┴────────┐
                    │                 │
            ┌───────▼─────┐   ┌──────▼──────┐   ┌──────▼──────┐
            │ Client A    │   │ Client B    │   │ Client C    │
            │ Thread 1    │   │ Thread 2    │   │ Thread 3    │
            └─────────────┘   └─────────────┘   └─────────────┘
            
            User: Alice       User: Bob         User: Charlie
            Location: PC1     Location: PC2     Location: PC3
```

---

## 3. BOOKING FLOW DIAGRAM

```
Client A                Server                    Client B, C
   │                       │                          │
   │  1. BookTicket       │                          │
   │  (Mai, 5 tickets)    │                          │
   ├──────────────────────►│                          │
   │                       │                          │
   │                       │ 2. Lock(lockObject)     │
   │                       │ ┌─────────────────┐     │
   │                       │ │ Critical Section│     │
   │                       │ │ - Find movie    │     │
   │                       │ │ - Check tickets │     │
   │                       │ │ - Update counts │     │
   │                       │ └─────────────────┘     │
   │                       │ 3. Unlock               │
   │                       │                          │
   │  4. Success Response  │                          │
   │◄──────────────────────┤                          │
   │                       │                          │
   │                       │ 5. Broadcast RefreshData│
   │                       ├─────────────────────────►│
   │                       │                          │
   │                       │                          │ 6. Auto-refresh
   │                       │  7. GetMovies           │
   │                       │◄─────────────────────────┤
   │                       │                          │
   │                       │  8. Updated MovieData    │
   │                       ├─────────────────────────►│
   │                       │                          │
   │                       │                          │ 9. UI Update
   │                       │                          │    (15 tickets)
```

---

## 4. THREAD ARCHITECTURE

```
┌─────────────────────────────────────────────────────────────┐
│                        SERVER PROCESS                        │
├─────────────────────────────────────────────────────────────┤
│                                                               │
│  Main Thread (UI)                                            │
│  ┌────────────────────────────────────────┐                 │
│  │ - ServerForm UI                        │                 │
│  │ - DataGridView updates                 │                 │
│  │ - Log display                          │                 │
│  └────────────────────────────────────────┘                 │
│                                                               │
│  Accept Thread                                               │
│  ┌────────────────────────────────────────┐                 │
│  │ while (isRunning)                      │                 │
│  │   AcceptTcpClient()                    │                 │
│  │   Spawn new ClientThread               │                 │
│  └────────────────────────────────────────┘                 │
│                                                               │
│  Client Threads (one per client)                            │
│  ┌────────────┐  ┌────────────┐  ┌────────────┐           │
│  │ Thread 1   │  │ Thread 2   │  │ Thread 3   │  ...      │
│  │            │  │            │  │            │           │
│  │ HandleMsg  │  │ HandleMsg  │  │ HandleMsg  │           │
│  └────────────┘  └────────────┘  └────────────┘           │
│                                                               │
│  Shared Data (Thread-safe with lock)                        │
│  ┌────────────────────────────────────────┐                 │
│  │ List<Phim> danhSachPhim                │                 │
│  │ List<TcpClient> clients                │                 │
│  │ object lockObject                      │                 │
│  └────────────────────────────────────────┘                 │
└─────────────────────────────────────────────────────────────┘
```

```
┌─────────────────────────────────────────────────────────────┐
│                       CLIENT PROCESS                         │
├─────────────────────────────────────────────────────────────┤
│                                                               │
│  Main Thread (UI)                                            │
│  ┌────────────────────────────────────────┐                 │
│  │ - ClientForm UI                        │                 │
│  │ - Button clicks                        │                 │
│  │ - DataGridView updates                 │                 │
│  └────────────────────────────────────────┘                 │
│                                                               │
│  Receive Thread                                              │
│  ┌────────────────────────────────────────┐                 │
│  │ while (isConnected)                    │                 │
│  │   Read server messages                 │                 │
│  │   If RefreshData:                      │                 │
│  │     Invoke(LoadMovies)                 │                 │
│  └────────────────────────────────────────┘                 │
└─────────────────────────────────────────────────────────────┘
```

---

## 5. MESSAGE PROTOCOL FLOW

```
┌──────────┐                                    ┌──────────┐
│  Client  │                                    │  Server  │
└────┬─────┘                                    └────┬─────┘
     │                                               │
     │  1. Connect                                   │
     │ ┌──────────────────────────────────┐         │
     │ │ Type: Connect                    │         │
     │ │ Data: null                       │         │
     │ └──────────────────────────────────┘         │
     ├──────────────────────────────────────────────►│
     │                                               │
     │  2. Connect Response                          │
     │ ┌──────────────────────────────────┐         │
     │ │ Type: Connect                    │         │
     │ │ Success: true                    │         │
     │ │ Data: "Kết nối thành công!"     │         │
     │ └──────────────────────────────────┘         │
     │◄──────────────────────────────────────────────┤
     │                                               │
     │  3. GetMovies                                 │
     │ ┌──────────────────────────────────┐         │
     │ │ Type: GetMovies                  │         │
     │ └──────────────────────────────────┘         │
     ├──────────────────────────────────────────────►│
     │                                               │
     │  4. MovieData Response                        │
     │ ┌──────────────────────────────────┐         │
     │ │ Type: GetMovies                  │         │
     │ │ Success: true                    │         │
     │ │ Data: [{movie1}, {movie2}, ...]  │         │
     │ └──────────────────────────────────┘         │
     │◄──────────────────────────────────────────────┤
     │                                               │
     │  5. BookTicket                                │
     │ ┌──────────────────────────────────┐         │
     │ │ Type: BookTicket                 │         │
     │ │ Data: {                          │         │
     │ │   TenPhim: "Mai",                │         │
     │ │   SoLuongVe: 5,                  │         │
     │ │   ClientName: "Client-1234"      │         │
     │ │ }                                │         │
     │ └──────────────────────────────────┘         │
     ├──────────────────────────────────────────────►│
     │                                               │
     │                                        ┌──────┴──────┐
     │                                        │ Lock        │
     │                                        │ Validate    │
     │                                        │ Update      │
     │                                        │ Unlock      │
     │                                        └──────┬──────┘
     │                                               │
     │  6. Booking Response                          │
     │ ┌──────────────────────────────────┐         │
     │ │ Type: BookTicket                 │         │
     │ │ Success: true                    │         │
     │ │ Data: "Đặt thành công 5 vé..."  │         │
     │ └──────────────────────────────────┘         │
     │◄──────────────────────────────────────────────┤
     │                                               │
```

---

## 6. DATA MODEL

```
┌─────────────────────────────────┐
│          Phim (Movie)           │
├─────────────────────────────────┤
│ + TenPhim: string               │
│ + GiaVeChuan: double            │
│ + PhongChieu: List<int>         │
│ + SoLuongVeBan: int             │
│ + SoLuongVeTon: int             │
│ + DoanhThu: double (computed)   │
│ + TiLeBan: double (computed)    │
└─────────────────────────────────┘
         ▲
         │ List of
         │
┌────────┴────────┐
│     Server      │
│  danhSachPhim   │
└─────────────────┘
```

```
┌─────────────────────────────────┐
│       NetworkMessage            │
├─────────────────────────────────┤
│ + Type: MessageType (enum)      │
│ + Data: string (JSON)           │
│ + Success: bool                 │
│ + ErrorMessage: string          │
└─────────────────────────────────┘

┌─────────────────────────────────┐
│       MessageType (enum)        │
├─────────────────────────────────┤
│ - Connect                       │
│ - GetMovies                     │
│ - BookTicket                    │
│ - RefreshData                   │
│ - Disconnect                    │
└─────────────────────────────────┘

┌─────────────────────────────────┐
│      BookingRequest             │
├─────────────────────────────────┤
│ + TenPhim: string               │
│ + SoLuongVe: int                │
│ + ClientName: string            │
└─────────────────────────────────┘

┌─────────────────────────────────┐
│        MovieData (DTO)          │
├─────────────────────────────────┤
│ + TenPhim: string               │
│ + GiaVeChuan: double            │
│ + PhongChieu: string            │
│ + SoLuongVeBan: int             │
│ + SoLuongVeTon: int             │
│ + DoanhThu: double              │
│ + TiLeBan: string               │
└─────────────────────────────────┘
```

---

## 7. FILE STRUCTURE

```
Lab02/
│
├── Program.cs ─────────────► StartupForm
│
├── StartupForm.cs ─────────► Choice: Server, Client, Form5
│   ├── StartupForm.Designer.cs
│   └── StartupForm.resx
│
├── ServerForm.cs ──────────► TCP Server, Multi-client
│   ├── ServerForm.Designer.cs
│   └── ServerForm.resx
│
├── ClientForm.cs ──────────► TCP Client, Booking
│   ├── ClientForm.Designer.cs
│   └── ClientForm.resx
│
├── NetworkMessage.cs ──────► Protocol definitions
│
├── Phim.cs ────────────────► Movie model
│
├── Form5.cs ───────────────► Original standalone (Lab2-Bai5)
│   ├── Form5.Designer.cs
│   └── Form5.resx
│
├── input5.txt ─────────────► Movie data
│
├── Lab02.csproj ───────────► Project file
├── Lab02.sln ──────────────► Solution file
├── packages.config ────────► NuGet packages
│
└── Documentation/
    ├── README.md
    ├── HUONG_DAN_SU_DUNG.md
    ├── TOM_TAT_DU_AN.md
    ├── QUICK_START.md
    └── ARCHITECTURE.md (this file)
```

---

## 8. STATE DIAGRAM

```
┌───────────┐
│   Start   │
│Application│
└─────┬─────┘
      │
      ▼
┌───────────┐      Choose       ┌───────────┐
│ Startup   ├──────Server───────►│  Server   │
│   Form    │                    │   Mode    │
└─────┬─────┘                    └─────┬─────┘
      │                                │
      │ Choose Client           Click Start
      │                                │
      ▼                                ▼
┌───────────┐                    ┌───────────┐
│  Client   │                    │ Listening │
│   Mode    │                    │ Port 8888 │
└─────┬─────┘                    └─────┬─────┘
      │                                │
      │ Enter IP & Connect      Accept Clients
      │                                │
      ▼                                ▼
┌───────────┐    TCP/IP          ┌───────────┐
│ Connected ├───────────────────►│ Connected │
│           │◄───────────────────┤           │
└─────┬─────┘                    └─────┬─────┘
      │                                │
      │ Book Tickets              Process Booking
      │                                │
      ▼                                ▼
┌───────────┐    BookTicket      ┌───────────┐
│ Request   ├───────────────────►│ Lock+     │
│ Booking   │                    │ Validate+ │
└───────────┘                    │ Update    │
      ▲                          └─────┬─────┘
      │                                │
      │ Response                Broadcast
      │                                │
      └────────────────────────────────┘
```

---

**Author:** Phạm Tấn Gia Quốc - 23521308  
**Course:** NT106.Q11.ANTT - Network Programming  
**Project:** Lab02 - Server-Client Ticket Management System
