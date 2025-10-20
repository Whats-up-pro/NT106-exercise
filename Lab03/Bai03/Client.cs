using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Bai03
{
    public partial class frm_Client : Form
    {
        public frm_Client()
        {
            InitializeComponent();

            textBox1 = new TextBox();
            textBox1.Location = new System.Drawing.Point(12, 12); // Adjust location as needed
            textBox1.Size = new System.Drawing.Size(200, 20);      // Adjust size as needed
            this.Controls.Add(textBox1);
        }

        private TextBox textBox1;

        IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
        TcpClient tcpClient = new TcpClient();
        NetworkStream ns;
        bool isConnected = false;

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                if (isConnected) return;

                tcpClient.Connect(ipEndPoint);
                ns = tcpClient.GetStream();
                isConnected = true;

                // Optional: update UI state if you have these controls
                // btn_Connect.Enabled = false;
                // btn_Disconnect.Enabled = true;
                // btn_Send.Enabled = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isConnected) return;

                if (ns != null)
                {
                    ns.Close();
                    ns = null;
                }
                if (tcpClient != null)
                {
                    tcpClient.Close();
                }

                // Create a new TcpClient so the user can reconnect later
                tcpClient = new TcpClient();
                isConnected = false;

                // Optional: update UI state if you have these controls
                // btn_Connect.Enabled = true;
                // btn_Disconnect.Enabled = false;
                // btn_Send.Enabled = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            try
            {
                // Read message from the chat box (assumes there is a TextBox named textBox1)
                string message = textBox1 != null ? textBox1.Text : string.Empty;
                if (string.IsNullOrWhiteSpace(message))
                    return;

                // Ensure connection (lazy connect if not already connected)
                if (!isConnected)
                {
                    tcpClient.Connect(ipEndPoint);
                    ns = tcpClient.GetStream();
                    isConnected = true;
                }

                if (ns == null || !ns.CanWrite)
                {
                    MessageBox.Show("Cannot send data. The connection is not writable.");
                    return;
                }

                // Server expects newline-terminated messages
                if (!message.EndsWith("\n"))
                    message += "\n";

                byte[] data = Encoding.ASCII.GetBytes(message);
                ns.Write(data, 0, data.Length);

                // Optionally clear the chat box after sending
                if (textBox1 != null)
                    textBox1.Clear();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void frm_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (ns != null) ns.Close();
                if (tcpClient != null) tcpClient.Close();
            }
            catch
            {
                // ignore on close
            }
        }

        // If the Designer already wired up this handler, reuse it for Connect.
        private void button1_Click(object sender, EventArgs e)
        {
            btn_Connect_Click(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // No-op; keep if Designer wired it.
        }
    }
}
