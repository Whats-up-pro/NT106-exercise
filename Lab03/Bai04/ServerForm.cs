using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Lab02
{
    public partial class ServerForm : Form
    {
        private TcpListener server;
        private List<TcpClient> clients = new List<TcpClient>();
        private List<Phim> danhSachPhim = new List<Phim>();
        private object lockObject = new object();
        private bool isRunning = false;

        public ServerForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                // Load data from file
                LoadMovieData();

                // Start server
                int port = 8888;
                server = new TcpListener(IPAddress.Any, port);
                server.Start();
                isRunning = true;

                LogMessage($"Server đã khởi động trên cổng {port}");
                btnStart.Enabled = false;
                btnStop.Enabled = true;

                // Start accepting clients
                Thread acceptThread = new Thread(AcceptClients);
                acceptThread.IsBackground = true;
                acceptThread.Start();

                UpdateMovieDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi động server: {ex.Message}");
            }
        }

        private void LoadMovieData()
        {
            danhSachPhim.Clear();
            string path = "input5.txt";

            if (!File.Exists(path))
            {
                MessageBox.Show("Không tìm thấy file input5.txt");
                return;
            }

            string[] lines = File.ReadAllLines(path);
            if (lines.Length % 5 != 0)
            {
                MessageBox.Show("File không đúng định dạng! Mỗi phim cần 5 dòng.");
                return;
            }

            for (int i = 0; i < lines.Length; i += 5)
            {
                string tenPhim = lines[i];
                double giaVe = double.Parse(lines[i + 1]);
                List<int> phongChieu = lines[i + 2].Split(',').Select(int.Parse).ToList();

                int soVeBan = string.IsNullOrWhiteSpace(lines[i + 3]) ? 0 : int.Parse(lines[i + 3]);
                int soVeTon = string.IsNullOrWhiteSpace(lines[i + 4]) ? 0 : int.Parse(lines[i + 4]);

                var phim = new Phim
                {
                    TenPhim = tenPhim,
                    GiaVeChuan = giaVe,
                    PhongChieu = phongChieu,
                    SoLuongVeBan = soVeBan,
                    SoLuongVeTon = soVeTon
                };

                danhSachPhim.Add(phim);
            }

            LogMessage($"Đã load {danhSachPhim.Count} phim từ file");
        }

        private void AcceptClients()
        {
            while (isRunning)
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();
                    lock (lockObject)
                    {
                        clients.Add(client);
                    }

                    LogMessage($"Client mới kết nối. Tổng: {clients.Count}");

                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
                catch
                {
                    if (!isRunning) break;
                }
            }
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();
                byte[] buffer = new byte[8192];

                while (isRunning && client.Connected)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string json = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    NetworkMessage message = JsonConvert.DeserializeObject<NetworkMessage>(json);

                    NetworkMessage response = ProcessMessage(message);

                    string responseJson = JsonConvert.SerializeObject(response);
                    byte[] responseData = Encoding.UTF8.GetBytes(responseJson);
                    stream.Write(responseData, 0, responseData.Length);
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Lỗi xử lý client: {ex.Message}");
            }
            finally
            {
                lock (lockObject)
                {
                    clients.Remove(client);
                }
                client?.Close();
                LogMessage($"Client đã ngắt kết nối. Còn lại: {clients.Count}");
            }
        }

        private NetworkMessage ProcessMessage(NetworkMessage message)
        {
            NetworkMessage response = new NetworkMessage();

            try
            {
                switch (message.Type)
                {
                    case MessageType.Connect:
                        response.Type = MessageType.Connect;
                        response.Success = true;
                        response.Data = "Kết nối thành công!";
                        break;

                    case MessageType.GetMovies:
                        lock (lockObject)
                        {
                            var movieList = danhSachPhim.Select(p => new MovieData
                            {
                                TenPhim = p.TenPhim,
                                GiaVeChuan = p.GiaVeChuan,
                                PhongChieu = string.Join(",", p.PhongChieu),
                                SoLuongVeBan = p.SoLuongVeBan,
                                SoLuongVeTon = p.SoLuongVeTon,
                                DoanhThu = p.DoanhThu,
                                TiLeBan = p.TiLeBan.ToString("P2")
                            }).ToList();

                            response.Type = MessageType.GetMovies;
                            response.Success = true;
                            response.Data = JsonConvert.SerializeObject(movieList);
                        }
                        break;

                    case MessageType.BookTicket:
                        var booking = JsonConvert.DeserializeObject<BookingRequest>(message.Data);
                        response = ProcessBooking(booking);
                        break;

                    case MessageType.Disconnect:
                        response.Type = MessageType.Disconnect;
                        response.Success = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        private NetworkMessage ProcessBooking(BookingRequest booking)
        {
            NetworkMessage response = new NetworkMessage { Type = MessageType.BookTicket };

            lock (lockObject)
            {
                var phim = danhSachPhim.FirstOrDefault(p => p.TenPhim == booking.TenPhim);
                
                if (phim == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Không tìm thấy phim!";
                    return response;
                }

                if (phim.SoLuongVeTon < booking.SoLuongVe)
                {
                    response.Success = false;
                    response.ErrorMessage = $"Không đủ vé! Chỉ còn {phim.SoLuongVeTon} vé.";
                    return response;
                }

                // Book tickets
                phim.SoLuongVeBan += booking.SoLuongVe;
                phim.SoLuongVeTon -= booking.SoLuongVe;

                response.Success = true;
                response.Data = $"Đặt thành công {booking.SoLuongVe} vé cho phim '{phim.TenPhim}'";

                LogMessage($"{booking.ClientName} đã đặt {booking.SoLuongVe} vé cho '{phim.TenPhim}'");
                UpdateMovieDisplay();

                // Notify all other clients
                BroadcastUpdate();
            }

            return response;
        }

        private void BroadcastUpdate()
        {
            NetworkMessage updateMsg = new NetworkMessage
            {
                Type = MessageType.RefreshData,
                Success = true
            };

            string json = JsonConvert.SerializeObject(updateMsg);
            byte[] data = Encoding.UTF8.GetBytes(json);

            lock (lockObject)
            {
                foreach (var client in clients.ToList())
                {
                    try
                    {
                        if (client.Connected)
                        {
                            NetworkStream stream = client.GetStream();
                            // Note: This is a simplified broadcast, in production you'd need a more robust mechanism
                        }
                    }
                    catch { }
                }
            }
        }

        private void UpdateMovieDisplay()
        {
            if (dgvMovies.InvokeRequired)
            {
                dgvMovies.Invoke(new Action(UpdateMovieDisplay));
                return;
            }

            lock (lockObject)
            {
                dgvMovies.DataSource = null;
                dgvMovies.DataSource = danhSachPhim.Select(p => new
                {
                    p.TenPhim,
                    p.GiaVeChuan,
                    PhongChieu = string.Join(",", p.PhongChieu),
                    p.SoLuongVeBan,
                    p.SoLuongVeTon,
                    DoanhThu = p.DoanhThu,
                    TiLeBan = p.TiLeBan.ToString("P2")
                }).ToList();
            }
        }

        private void LogMessage(string message)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action<string>(LogMessage), message);
                return;
            }

            txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\r\n");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void StopServer()
        {
            isRunning = false;

            lock (lockObject)
            {
                foreach (var client in clients)
                {
                    client?.Close();
                }
                clients.Clear();
            }

            server?.Stop();
            
            LogMessage("Server đã dừng");
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopServer();
        }
    }
}
