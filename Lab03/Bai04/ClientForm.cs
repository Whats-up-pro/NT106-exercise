using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Lab02
{
    public partial class ClientForm : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;
        private bool isConnected = false;
        private string clientName;
        private List<MovieData> movieList = new List<MovieData>();

        public ClientForm()
        {
            InitializeComponent();
            clientName = $"Client-{DateTime.Now.Ticks % 10000}";
            this.Text = $"Client - {clientName} - 23521308";
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string serverIP = txtServerIP.Text.Trim();
                int port = 8888;

                client = new TcpClient();
                client.Connect(serverIP, port);
                stream = client.GetStream();

                isConnected = true;
                LogMessage("Đã kết nối tới server!");

                // Send connect message
                NetworkMessage connectMsg = new NetworkMessage
                {
                    Type = MessageType.Connect
                };
                SendMessage(connectMsg);

                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                btnRefresh.Enabled = true;
                txtServerIP.Enabled = false;

                // Load movies
                LoadMovies();

                // Start receive thread
                receiveThread = new Thread(ReceiveMessages);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMovies()
        {
            try
            {
                NetworkMessage request = new NetworkMessage
                {
                    Type = MessageType.GetMovies
                };

                NetworkMessage response = SendAndReceive(request);

                if (response.Success)
                {
                    movieList = JsonConvert.DeserializeObject<List<MovieData>>(response.Data);
                    UpdateMovieDisplay();
                }
                else
                {
                    MessageBox.Show($"Lỗi: {response.ErrorMessage}");
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Lỗi tải danh sách phim: {ex.Message}");
            }
        }

        private void UpdateMovieDisplay()
        {
            if (dgvMovies.InvokeRequired)
            {
                dgvMovies.Invoke(new Action(UpdateMovieDisplay));
                return;
            }

            dgvMovies.DataSource = null;
            dgvMovies.DataSource = movieList;

            // Update combo box
            cboPhim.DataSource = null;
            cboPhim.DataSource = movieList.Select(m => m.TenPhim).ToList();
            if (cboPhim.Items.Count > 0)
                cboPhim.SelectedIndex = 0;
        }

        private void SendMessage(NetworkMessage message)
        {
            if (stream == null || !stream.CanWrite) return;

            string json = JsonConvert.SerializeObject(message);
            byte[] data = Encoding.UTF8.GetBytes(json);
            stream.Write(data, 0, data.Length);
        }

        private NetworkMessage SendAndReceive(NetworkMessage message)
        {
            SendMessage(message);

            byte[] buffer = new byte[8192];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string json = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            return JsonConvert.DeserializeObject<NetworkMessage>(json);
        }

        private void ReceiveMessages()
        {
            byte[] buffer = new byte[8192];

            while (isConnected && client.Connected)
            {
                try
                {
                    if (stream.DataAvailable)
                    {
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);
                        if (bytesRead == 0) break;

                        string json = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        NetworkMessage message = JsonConvert.DeserializeObject<NetworkMessage>(json);

                        if (message.Type == MessageType.RefreshData)
                        {
                            // Auto refresh when server broadcasts update
                            LoadMovies();
                            LogMessage("Dữ liệu đã được cập nhật từ server");
                        }
                    }

                    Thread.Sleep(100);
                }
                catch
                {
                    break;
                }
            }
        }

        private void btnBookTicket_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                MessageBox.Show("Vui lòng kết nối tới server trước!");
                return;
            }

            if (cboPhim.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phim!");
                return;
            }

            try
            {
                string tenPhim = cboPhim.SelectedItem.ToString();
                int soLuongVe = (int)numSoLuong.Value;

                if (soLuongVe <= 0)
                {
                    MessageBox.Show("Số lượng vé phải lớn hơn 0!");
                    return;
                }

                BookingRequest booking = new BookingRequest
                {
                    TenPhim = tenPhim,
                    SoLuongVe = soLuongVe,
                    ClientName = clientName
                };

                NetworkMessage request = new NetworkMessage
                {
                    Type = MessageType.BookTicket,
                    Data = JsonConvert.SerializeObject(booking)
                };

                NetworkMessage response = SendAndReceive(request);

                if (response.Success)
                {
                    MessageBox.Show(response.Data, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMovies();
                    numSoLuong.Value = 1;
                }
                else
                {
                    MessageBox.Show(response.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đặt vé: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMovies();
            LogMessage("Đã làm mới dữ liệu");
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void Disconnect()
        {
            isConnected = false;

            if (client != null && client.Connected)
            {
                NetworkMessage disconnectMsg = new NetworkMessage
                {
                    Type = MessageType.Disconnect
                };
                SendMessage(disconnectMsg);
            }

            stream?.Close();
            client?.Close();

            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnRefresh.Enabled = false;
            txtServerIP.Enabled = true;

            LogMessage("Đã ngắt kết nối");
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

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }

        private void cboPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhim.SelectedItem != null)
            {
                string tenPhim = cboPhim.SelectedItem.ToString();
                var phim = movieList.FirstOrDefault(m => m.TenPhim == tenPhim);

                if (phim != null)
                {
                    lblThongTin.Text = $"Giá vé: {phim.GiaVeChuan:N0} VNĐ\n" +
                                      $"Phòng chiếu: {phim.PhongChieu}\n" +
                                      $"Vé còn lại: {phim.SoLuongVeTon}";

                    numSoLuong.Maximum = Math.Max(1, phim.SoLuongVeTon);
                }
            }
        }
    }
}
