namespace Bai8_ChatRoom_Client
{
    partial class ChatForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSendPublic = new System.Windows.Forms.Button();
            this.txtPublicMessage = new System.Windows.Forms.TextBox();
            this.txtPublicChat = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblSelectedUser = new System.Windows.Forms.Label();
            this.btnSendPrivate = new System.Windows.Forms.Button();
            this.txtPrivateMessage = new System.Windows.Forms.TextBox();
            this.txtPrivateChat = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkPrivateImage = new System.Windows.Forms.CheckBox();
            this.btnSendImage = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkPrivateFile = new System.Windows.Forms.CheckBox();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblOnlineCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtServerIP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(620, 32);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(150, 30);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(430, 37);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(170, 20);
            this.txtUsername.TabIndex = 5;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(310, 37);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(70, 20);
            this.txtPort.TabIndex = 4;
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(90, 37);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(150, 20);
            this.txtServerIP.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(390, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 98);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(620, 450);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSendPublic);
            this.tabPage1.Controls.Add(this.txtPublicMessage);
            this.tabPage1.Controls.Add(this.txtPublicChat);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(612, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Public Chat";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSendPublic
            // 
            this.btnSendPublic.Location = new System.Drawing.Point(516, 385);
            this.btnSendPublic.Name = "btnSendPublic";
            this.btnSendPublic.Size = new System.Drawing.Size(90, 33);
            this.btnSendPublic.TabIndex = 2;
            this.btnSendPublic.Text = "Send";
            this.btnSendPublic.UseVisualStyleBackColor = true;
            this.btnSendPublic.Click += new System.EventHandler(this.btnSendPublic_Click);
            // 
            // txtPublicMessage
            // 
            this.txtPublicMessage.Location = new System.Drawing.Point(6, 391);
            this.txtPublicMessage.Name = "txtPublicMessage";
            this.txtPublicMessage.Size = new System.Drawing.Size(504, 20);
            this.txtPublicMessage.TabIndex = 1;
            this.txtPublicMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPublicMessage_KeyPress);
            // 
            // txtPublicChat
            // 
            this.txtPublicChat.Location = new System.Drawing.Point(6, 6);
            this.txtPublicChat.Name = "txtPublicChat";
            this.txtPublicChat.ReadOnly = true;
            this.txtPublicChat.Size = new System.Drawing.Size(600, 373);
            this.txtPublicChat.TabIndex = 0;
            this.txtPublicChat.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblSelectedUser);
            this.tabPage2.Controls.Add(this.btnSendPrivate);
            this.tabPage2.Controls.Add(this.txtPrivateMessage);
            this.tabPage2.Controls.Add(this.txtPrivateChat);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(612, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Private Chat";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblSelectedUser
            // 
            this.lblSelectedUser.AutoSize = true;
            this.lblSelectedUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedUser.ForeColor = System.Drawing.Color.DarkMagenta;
            this.lblSelectedUser.Location = new System.Drawing.Point(6, 360);
            this.lblSelectedUser.Name = "lblSelectedUser";
            this.lblSelectedUser.Size = new System.Drawing.Size(191, 15);
            this.lblSelectedUser.TabIndex = 3;
            this.lblSelectedUser.Text = "Select a user from the right";
            // 
            // btnSendPrivate
            // 
            this.btnSendPrivate.Location = new System.Drawing.Point(516, 385);
            this.btnSendPrivate.Name = "btnSendPrivate";
            this.btnSendPrivate.Size = new System.Drawing.Size(90, 33);
            this.btnSendPrivate.TabIndex = 2;
            this.btnSendPrivate.Text = "Send Private";
            this.btnSendPrivate.UseVisualStyleBackColor = true;
            this.btnSendPrivate.Click += new System.EventHandler(this.btnSendPrivate_Click);
            // 
            // txtPrivateMessage
            // 
            this.txtPrivateMessage.Location = new System.Drawing.Point(6, 391);
            this.txtPrivateMessage.Name = "txtPrivateMessage";
            this.txtPrivateMessage.Size = new System.Drawing.Size(504, 20);
            this.txtPrivateMessage.TabIndex = 1;
            this.txtPrivateMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrivateMessage_KeyPress);
            // 
            // txtPrivateChat
            // 
            this.txtPrivateChat.Location = new System.Drawing.Point(6, 6);
            this.txtPrivateChat.Name = "txtPrivateChat";
            this.txtPrivateChat.ReadOnly = true;
            this.txtPrivateChat.Size = new System.Drawing.Size(600, 345);
            this.txtPrivateChat.TabIndex = 0;
            this.txtPrivateChat.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(612, 424);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Send Files/Images";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkPrivateImage);
            this.groupBox3.Controls.Add(this.btnSendImage);
            this.groupBox3.Location = new System.Drawing.Point(15, 130);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(580, 100);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Send Image (.jpg, .png)";
            // 
            // chkPrivateImage
            // 
            this.chkPrivateImage.AutoSize = true;
            this.chkPrivateImage.Location = new System.Drawing.Point(200, 45);
            this.chkPrivateImage.Name = "chkPrivateImage";
            this.chkPrivateImage.Size = new System.Drawing.Size(193, 17);
            this.chkPrivateImage.TabIndex = 1;
            this.chkPrivateImage.Text = "Send to selected user (private chat)";
            this.chkPrivateImage.UseVisualStyleBackColor = true;
            // 
            // btnSendImage
            // 
            this.btnSendImage.Location = new System.Drawing.Point(30, 35);
            this.btnSendImage.Name = "btnSendImage";
            this.btnSendImage.Size = new System.Drawing.Size(150, 35);
            this.btnSendImage.TabIndex = 0;
            this.btnSendImage.Text = "📷 Choose Image...";
            this.btnSendImage.UseVisualStyleBackColor = true;
            this.btnSendImage.Click += new System.EventHandler(this.btnSendImage_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkPrivateFile);
            this.groupBox2.Controls.Add(this.btnSendFile);
            this.groupBox2.Location = new System.Drawing.Point(15, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(580, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Send File (.txt)";
            // 
            // chkPrivateFile
            // 
            this.chkPrivateFile.AutoSize = true;
            this.chkPrivateFile.Location = new System.Drawing.Point(200, 45);
            this.chkPrivateFile.Name = "chkPrivateFile";
            this.chkPrivateFile.Size = new System.Drawing.Size(193, 17);
            this.chkPrivateFile.TabIndex = 1;
            this.chkPrivateFile.Text = "Send to selected user (private chat)";
            this.chkPrivateFile.UseVisualStyleBackColor = true;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(30, 35);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(150, 35);
            this.btnSendFile.TabIndex = 0;
            this.btnSendFile.Text = "📎 Choose File...";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblOnlineCount);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.listBoxUsers);
            this.panel1.Location = new System.Drawing.Point(638, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 450);
            this.panel1.TabIndex = 2;
            // 
            // lblOnlineCount
            // 
            this.lblOnlineCount.AutoSize = true;
            this.lblOnlineCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnlineCount.ForeColor = System.Drawing.Color.Green;
            this.lblOnlineCount.Location = new System.Drawing.Point(10, 425);
            this.lblOnlineCount.Name = "lblOnlineCount";
            this.lblOnlineCount.Size = new System.Drawing.Size(63, 15);
            this.lblOnlineCount.TabIndex = 2;
            this.lblOnlineCount.Text = "Online: 0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Online Users";
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(10, 35);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(152, 381);
            this.listBoxUsers.TabIndex = 0;
            this.listBoxUsers.SelectedIndexChanged += new System.EventHandler(this.listBoxUsers_SelectedIndexChanged);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 560);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat Room Client - Bài 8";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_FormClosing);
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnSendPublic;
        private System.Windows.Forms.TextBox txtPublicMessage;
        private System.Windows.Forms.RichTextBox txtPublicChat;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblSelectedUser;
        private System.Windows.Forms.Button btnSendPrivate;
        private System.Windows.Forms.TextBox txtPrivateMessage;
        private System.Windows.Forms.RichTextBox txtPrivateChat;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkPrivateImage;
        private System.Windows.Forms.Button btnSendImage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkPrivateFile;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOnlineCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxUsers;
    }
}
