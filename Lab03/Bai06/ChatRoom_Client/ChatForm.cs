using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;
using Bai8_ChatRoom_Client.Models;

namespace Bai8_ChatRoom_Client
{
    public partial class ChatForm : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;
        private string username;
        private List<string> onlineUsers = new List<string>();
        private string selectedUser = null;  // For private chat

        public ChatForm()
        {
            InitializeComponent();
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            txtServerIP.Text = "127.0.0.1";
            txtPort.Text = "8888";
            tabControl1.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên của bạn!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtPort.Text, out int port))
            {
                MessageBox.Show("Port không hợp lệ!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                client = new TcpClient();
                client.Connect(txtServerIP.Text, port);
                stream = client.GetStream();

                // Send JOIN message
                ChatMessage joinMsg = new ChatMessage
                {
                    Type = "JOIN",
                    SenderName = username,
                    Content = $"{username} joined the chat"
                };
                SendMessage(joinMsg);

                // Start receive thread
                receiveThread = new Thread(ReceiveMessages);
                receiveThread.IsBackground = true;
                receiveThread.Start();

                // Update UI
                groupBox1.Enabled = false;
                tabControl1.Enabled = true;
                this.Text = $"Chat Room - {username}";

                AppendMessage($"✅ Connected as {username}", Color.Green);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể kết nối: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendMessage(ChatMessage message)
        {
            try
            {
                byte[] data = JsonSerializer.SerializeToUtf8Bytes(message);
                byte[] lengthPrefix = BitConverter.GetBytes(data.Length);

                stream.Write(lengthPrefix, 0, 4);
                stream.Write(data, 0, data.Length);
                stream.Flush();
            }
            catch (Exception ex)
            {
                AppendMessage($"❌ Send error: {ex.Message}", Color.Red);
            }
        }

        private void ReceiveMessages()
        {
            try
            {
                while (client.Connected)
                {
                    // Read length prefix
                    byte[] lengthBuffer = new byte[4];
                    int bytesRead = 0;
                    while (bytesRead < 4)
                    {
                        int read = stream.Read(lengthBuffer, bytesRead, 4 - bytesRead);
                        if (read == 0) break;
                        bytesRead += read;
                    }

                    if (bytesRead < 4) break;

                    int messageLength = BitConverter.ToInt32(lengthBuffer, 0);

                    // Read message data
                    byte[] buffer = new byte[messageLength];
                    int totalBytesRead = 0;
                    while (totalBytesRead < messageLength)
                    {
                        int read = stream.Read(buffer, totalBytesRead, messageLength - totalBytesRead);
                        if (read == 0) break;
                        totalBytesRead += read;
                    }

                    if (totalBytesRead < messageLength) break;

                    // Deserialize message
                    ChatMessage message = JsonSerializer.Deserialize<ChatMessage>(buffer);

                    if (message != null)
                    {
                        HandleReceivedMessage(message);
                    }
                }
            }
            catch (Exception ex)
            {
                if (client.Connected)
                {
                    AppendMessage($"❌ Receive error: {ex.Message}", Color.Red);
                }
            }
        }

        private void HandleReceivedMessage(ChatMessage message)
        {
            this.Invoke(new Action(() =>
            {
                switch (message.Type)
                {
                    case "JOIN":
                        if (message.SenderName != username)
                        {
                            AppendMessage($"👤 {message.Content}", Color.Gray);
                        }
                        break;

                    case "LEAVE":
                        AppendMessage($"👋 {message.Content}", Color.Gray);
                        break;

                    case "PUBLIC":
                        string publicMsg = $"[{message.Timestamp:HH:mm:ss}] {message.SenderName}: {message.Content}";
                        AppendMessage(publicMsg, message.SenderName == username ? Color.Blue : Color.Black);
                        break;

                    case "PRIVATE":
                        string privatePrefix = message.SenderName == username ? "You -> " : $"{message.SenderName} -> ";
                        string privateMsg = $"[{message.Timestamp:HH:mm:ss}] 🔒 {privatePrefix}{message.ReceiverName}: {message.Content}";
                        AppendPrivateMessage(privateMsg);
                        break;

                    case "FILE":
                        HandleFileReceived(message);
                        break;

                    case "IMAGE":
                        HandleImageReceived(message);
                        break;

                    case "USER_LIST":
                        UpdateUserList(message.UserList);
                        break;
                }
            }));
        }

        private void btnSendPublic_Click(object sender, EventArgs e)
        {
            string content = txtPublicMessage.Text.Trim();
            if (string.IsNullOrEmpty(content)) return;

            ChatMessage message = new ChatMessage
            {
                Type = "PUBLIC",
                SenderName = username,
                Content = content
            };

            SendMessage(message);
            txtPublicMessage.Clear();
        }

        private void btnSendPrivate_Click(object sender, EventArgs e)
        {
            if (selectedUser == null)
            {
                MessageBox.Show("Vui lòng chọn người nhận!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string content = txtPrivateMessage.Text.Trim();
            if (string.IsNullOrEmpty(content)) return;

            ChatMessage message = new ChatMessage
            {
                Type = "PRIVATE",
                SenderName = username,
                ReceiverName = selectedUser,
                Content = content
            };

            SendMessage(message);
            txtPrivateMessage.Clear();
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files|*.txt|All Files|*.*";
            ofd.Title = "Chọn file để gửi";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] fileData = File.ReadAllBytes(ofd.FileName);
                    string fileName = Path.GetFileName(ofd.FileName);

                    ChatMessage message = new ChatMessage
                    {
                        Type = "FILE",
                        SenderName = username,
                        ReceiverName = chkPrivateFile.Checked ? selectedUser : null,
                        FileName = fileName,
                        FileData = fileData,
                        Content = $"Sent file: {fileName}"
                    };

                    SendMessage(message);
                    AppendMessage($"📎 You sent file: {fileName}", Color.Green);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi gửi file: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSendImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            ofd.Title = "Chọn hình ảnh để gửi";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] imageData = File.ReadAllBytes(ofd.FileName);
                    string fileName = Path.GetFileName(ofd.FileName);

                    ChatMessage message = new ChatMessage
                    {
                        Type = "IMAGE",
                        SenderName = username,
                        ReceiverName = chkPrivateImage.Checked ? selectedUser : null,
                        FileName = fileName,
                        FileData = imageData,
                        Content = $"Sent image: {fileName}"
                    };

                    SendMessage(message);
                    AppendMessage($"🖼️ You sent image: {fileName}", Color.Green);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi gửi ảnh: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void HandleFileReceived(ChatMessage message)
        {
            string displayMsg = message.ReceiverName != null
                ? $"📎 [PRIVATE] {message.SenderName} sent file: {message.FileName}"
                : $"📎 {message.SenderName} sent file: {message.FileName}";

            AppendMessage(displayMsg, Color.Purple);

            // Ask to save
            if (MessageBox.Show($"Save file {message.FileName}?", "File Received", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = message.FileName;
                sfd.Filter = "All Files|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(sfd.FileName, message.FileData);
                    MessageBox.Show("File saved successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void HandleImageReceived(ChatMessage message)
        {
            string displayMsg = message.ReceiverName != null
                ? $"🖼️ [PRIVATE] {message.SenderName} sent image: {message.FileName}"
                : $"🖼️ {message.SenderName} sent image: {message.FileName}";

            AppendMessage(displayMsg, Color.DarkCyan);

            // Show image preview
            using (MemoryStream ms = new MemoryStream(message.FileData))
            {
                Image img = Image.FromStream(ms);
                
                Form imageForm = new Form();
                imageForm.Text = $"Image from {message.SenderName} - {message.FileName}";
                imageForm.Size = new Size(600, 500);
                imageForm.StartPosition = FormStartPosition.CenterParent;

                PictureBox pb = new PictureBox();
                pb.Dock = DockStyle.Fill;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Image = img;

                Button btnSaveImage = new Button();
                btnSaveImage.Text = "Save Image";
                btnSaveImage.Dock = DockStyle.Bottom;
                btnSaveImage.Height = 40;
                btnSaveImage.Click += (s, ev) =>
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.FileName = message.FileName;
                    sfd.Filter = "Image Files|*.jpg;*.jpeg;*.png";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(sfd.FileName, message.FileData);
                        MessageBox.Show("Image saved!", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };

                imageForm.Controls.Add(pb);
                imageForm.Controls.Add(btnSaveImage);
                imageForm.ShowDialog();
            }
        }

        private void UpdateUserList(string[] users)
        {
            onlineUsers = users.ToList();
            listBoxUsers.Items.Clear();

            foreach (string user in users)
            {
                if (user != username)
                {
                    listBoxUsers.Items.Add(user);
                }
            }

            lblOnlineCount.Text = $"Online: {users.Length}";
        }

        private void listBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxUsers.SelectedItem != null)
            {
                selectedUser = listBoxUsers.SelectedItem.ToString();
                lblSelectedUser.Text = $"Chat with: {selectedUser}";
            }
        }

        private void AppendMessage(string message, Color color)
        {
            txtPublicChat.SelectionStart = txtPublicChat.TextLength;
            txtPublicChat.SelectionLength = 0;
            txtPublicChat.SelectionColor = color;
            txtPublicChat.AppendText(message + Environment.NewLine);
            txtPublicChat.SelectionColor = txtPublicChat.ForeColor;
            txtPublicChat.ScrollToCaret();
        }

        private void AppendPrivateMessage(string message)
        {
            txtPrivateChat.SelectionStart = txtPrivateChat.TextLength;
            txtPrivateChat.SelectionLength = 0;
            txtPrivateChat.SelectionColor = Color.DarkMagenta;
            txtPrivateChat.AppendText(message + Environment.NewLine);
            txtPrivateChat.SelectionColor = txtPrivateChat.ForeColor;
            txtPrivateChat.ScrollToCaret();
        }

        private void txtPublicMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSendPublic_Click(sender, e);
            }
        }

        private void txtPrivateMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSendPrivate_Click(sender, e);
            }
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null && client.Connected)
            {
                ChatMessage leaveMsg = new ChatMessage
                {
                    Type = "LEAVE",
                    SenderName = username,
                    Content = $"{username} left the chat"
                };
                SendMessage(leaveMsg);

                stream?.Close();
                client?.Close();
            }
        }
    }
}
