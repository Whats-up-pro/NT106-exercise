using System;
using System.Windows.Forms;

namespace Bai7_Server
{
    public partial class ServerForm : Form
    {
        private TcpServer server;

        public ServerForm()
        {
            InitializeComponent();
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
                server = new TcpServer(port);
                server.OnLogMessage += LogMessage;
                server.Start();

                btnStart.Enabled = false;
                btnStop.Enabled = true;
                txtPort.Enabled = false;
                lblStatus.Text = "Status: Running";
                lblStatus.ForeColor = System.Drawing.Color.Green;

                LogMessage("Server đã khởi động thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi động server: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                server.Stop();
                server.OnLogMessage -= LogMessage;
                server = null;

                btnStart.Enabled = true;
                btnStop.Enabled = false;
                txtPort.Enabled = true;
                lblStatus.Text = "Status: Stopped";
                lblStatus.ForeColor = System.Drawing.Color.Red;

                LogMessage("Server đã dừng!");
            }
        }

        private void LogMessage(string message)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action<string>(LogMessage), message);
            }
            else
            {
                txtLog.AppendText(message + Environment.NewLine);
            }
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server != null)
            {
                server.Stop();
            }
        }
    }
}
