using System;
using System.Windows.Forms;

namespace Bai8_ChatRoom_Server
{
    public partial class ServerForm : Form
    {
        private ChatServer server;

        public ServerForm()
        {
            InitializeComponent();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            txtPort.Text = "8888";
            UpdateStatus();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPort.Text, out int port))
            {
                MessageBox.Show("Port không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                server = new ChatServer(port);
                server.OnLogMessage += LogMessage;
                server.Start();

                btnStart.Enabled = false;
                btnStop.Enabled = true;
                txtPort.Enabled = false;

                UpdateStatus();
                LogMessage($"Server started on port {port}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể khởi động server: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                server.Stop();
                server = null;

                btnStart.Enabled = true;
                btnStop.Enabled = false;
                txtPort.Enabled = true;

                UpdateStatus();
                LogMessage("Server stopped");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            if (server != null)
            {
                lblStatus.Text = $"🟢 Running - Online: {server.GetOnlineCount()} users";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblStatus.Text = "🔴 Stopped";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LogMessage(string message)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() => LogMessage(message)));
            }
            else
            {
                txtLog.AppendText(message + Environment.NewLine);
                txtLog.SelectionStart = txtLog.Text.Length;
                txtLog.ScrollToCaret();
            }
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            server?.Stop();
        }
    }
}
