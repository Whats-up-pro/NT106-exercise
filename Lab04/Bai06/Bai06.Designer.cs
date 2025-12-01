namespace Bai06
{
    partial class Bai06
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.GroupBox groupBox_Login;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.GroupBox groupBox_UserInfo;
        private System.Windows.Forms.Label lbl_UserId;
        private System.Windows.Forms.Label lbl_DisplayUsername;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Label lbl_FirstName;
        private System.Windows.Forms.Label lbl_LastName;
        private System.Windows.Forms.TextBox txt_UserId;
        private System.Windows.Forms.TextBox txt_DisplayUsername;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox txt_FirstName;
        private System.Windows.Forms.TextBox txt_LastName;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.GroupBox groupBox_Json;
        private System.Windows.Forms.TextBox txt_JsonResponse;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lbl_Title = new Label();
            groupBox_Login = new GroupBox();
            lbl_Username = new Label();
            txt_Username = new TextBox();
            lbl_Password = new Label();
            txt_Password = new TextBox();
            btn_Login = new Button();
            btn_Clear = new Button();
            lbl_Status = new Label();
            groupBox_UserInfo = new GroupBox();
            lbl_UserId = new Label();
            txt_UserId = new TextBox();
            lbl_DisplayUsername = new Label();
            txt_DisplayUsername = new TextBox();
            lbl_Email = new Label();
            txt_Email = new TextBox();
            lbl_FirstName = new Label();
            txt_FirstName = new TextBox();
            lbl_LastName = new Label();
            txt_LastName = new TextBox();
            btn_Refresh = new Button();
            groupBox_Json = new GroupBox();
            txt_JsonResponse = new TextBox();
            groupBox_Login.SuspendLayout();
            groupBox_UserInfo.SuspendLayout();
            groupBox_Json.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_Title
            // 
            lbl_Title.AutoSize = true;
            lbl_Title.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbl_Title.ForeColor = Color.FromArgb(0, 120, 215);
            lbl_Title.Location = new Point(20, 20);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(440, 37);
            lbl_Title.TabIndex = 0;
            lbl_Title.Text = "HTTP GET - Thông Tin Người Dùng";
            // 
            // groupBox_Login
            // 
            groupBox_Login.Controls.Add(lbl_Username);
            groupBox_Login.Controls.Add(txt_Username);
            groupBox_Login.Controls.Add(lbl_Password);
            groupBox_Login.Controls.Add(txt_Password);
            groupBox_Login.Controls.Add(btn_Login);
            groupBox_Login.Controls.Add(btn_Clear);
            groupBox_Login.Location = new Point(20, 70);
            groupBox_Login.Name = "groupBox_Login";
            groupBox_Login.Size = new Size(760, 140);
            groupBox_Login.TabIndex = 1;
            groupBox_Login.TabStop = false;
            groupBox_Login.Text = "Đăng nhập";
            // 
            // lbl_Username
            // 
            lbl_Username.AutoSize = true;
            lbl_Username.Location = new Point(20, 35);
            lbl_Username.Name = "lbl_Username";
            lbl_Username.Size = new Size(78, 20);
            lbl_Username.TabIndex = 0;
            lbl_Username.Text = "Username:";
            // 
            // txt_Username
            // 
            txt_Username.Location = new Point(120, 32);
            txt_Username.Name = "txt_Username";
            txt_Username.Size = new Size(620, 27);
            txt_Username.TabIndex = 1;
            // 
            // lbl_Password
            // 
            lbl_Password.AutoSize = true;
            lbl_Password.Location = new Point(20, 72);
            lbl_Password.Name = "lbl_Password";
            lbl_Password.Size = new Size(73, 20);
            lbl_Password.TabIndex = 2;
            lbl_Password.Text = "Password:";
            // 
            // txt_Password
            // 
            txt_Password.Location = new Point(120, 69);
            txt_Password.Name = "txt_Password";
            txt_Password.Size = new Size(620, 27);
            txt_Password.TabIndex = 3;
            txt_Password.UseSystemPasswordChar = true;
            // 
            // btn_Login
            // 
            btn_Login.BackColor = Color.FromArgb(0, 120, 215);
            btn_Login.FlatStyle = FlatStyle.Flat;
            btn_Login.ForeColor = Color.White;
            btn_Login.Location = new Point(440, 105);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(150, 30);
            btn_Login.TabIndex = 4;
            btn_Login.Text = "Đăng nhập";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += btn_Login_Click;
            // 
            // btn_Clear
            // 
            btn_Clear.BackColor = Color.Gray;
            btn_Clear.FlatStyle = FlatStyle.Flat;
            btn_Clear.ForeColor = Color.White;
            btn_Clear.Location = new Point(590, 105);
            btn_Clear.Name = "btn_Clear";
            btn_Clear.Size = new Size(150, 30);
            btn_Clear.TabIndex = 5;
            btn_Clear.Text = "Xóa";
            btn_Clear.UseVisualStyleBackColor = false;
            btn_Clear.Click += btn_Clear_Click;
            // 
            // lbl_Status
            // 
            lbl_Status.AutoSize = true;
            lbl_Status.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl_Status.Location = new Point(20, 220);
            lbl_Status.Name = "lbl_Status";
            lbl_Status.Size = new Size(0, 23);
            lbl_Status.TabIndex = 2;
            // 
            // groupBox_UserInfo
            // 
            groupBox_UserInfo.Controls.Add(lbl_UserId);
            groupBox_UserInfo.Controls.Add(txt_UserId);
            groupBox_UserInfo.Controls.Add(lbl_DisplayUsername);
            groupBox_UserInfo.Controls.Add(txt_DisplayUsername);
            groupBox_UserInfo.Controls.Add(lbl_Email);
            groupBox_UserInfo.Controls.Add(txt_Email);
            groupBox_UserInfo.Controls.Add(lbl_FirstName);
            groupBox_UserInfo.Controls.Add(txt_FirstName);
            groupBox_UserInfo.Controls.Add(lbl_LastName);
            groupBox_UserInfo.Controls.Add(txt_LastName);
            groupBox_UserInfo.Controls.Add(btn_Refresh);
            groupBox_UserInfo.Location = new Point(20, 250);
            groupBox_UserInfo.Name = "groupBox_UserInfo";
            groupBox_UserInfo.Size = new Size(760, 220);
            groupBox_UserInfo.TabIndex = 3;
            groupBox_UserInfo.TabStop = false;
            groupBox_UserInfo.Text = "Thông tin người dùng";
            // 
            // lbl_UserId
            // 
            lbl_UserId.AutoSize = true;
            lbl_UserId.Location = new Point(20, 35);
            lbl_UserId.Name = "lbl_UserId";
            lbl_UserId.Size = new Size(27, 20);
            lbl_UserId.TabIndex = 0;
            lbl_UserId.Text = "ID:";
            // 
            // txt_UserId
            // 
            txt_UserId.Location = new Point(120, 32);
            txt_UserId.Name = "txt_UserId";
            txt_UserId.ReadOnly = true;
            txt_UserId.Size = new Size(620, 27);
            txt_UserId.TabIndex = 1;
            // 
            // lbl_DisplayUsername
            // 
            lbl_DisplayUsername.AutoSize = true;
            lbl_DisplayUsername.Location = new Point(20, 72);
            lbl_DisplayUsername.Name = "lbl_DisplayUsername";
            lbl_DisplayUsername.Size = new Size(78, 20);
            lbl_DisplayUsername.TabIndex = 2;
            lbl_DisplayUsername.Text = "Username:";
            // 
            // txt_DisplayUsername
            // 
            txt_DisplayUsername.Location = new Point(120, 69);
            txt_DisplayUsername.Name = "txt_DisplayUsername";
            txt_DisplayUsername.ReadOnly = true;
            txt_DisplayUsername.Size = new Size(620, 27);
            txt_DisplayUsername.TabIndex = 3;
            // 
            // lbl_Email
            // 
            lbl_Email.AutoSize = true;
            lbl_Email.Location = new Point(20, 109);
            lbl_Email.Name = "lbl_Email";
            lbl_Email.Size = new Size(49, 20);
            lbl_Email.TabIndex = 4;
            lbl_Email.Text = "Email:";
            // 
            // txt_Email
            // 
            txt_Email.Location = new Point(120, 106);
            txt_Email.Name = "txt_Email";
            txt_Email.ReadOnly = true;
            txt_Email.Size = new Size(620, 27);
            txt_Email.TabIndex = 5;
            // 
            // lbl_FirstName
            // 
            lbl_FirstName.AutoSize = true;
            lbl_FirstName.Location = new Point(20, 146);
            lbl_FirstName.Name = "lbl_FirstName";
            lbl_FirstName.Size = new Size(83, 20);
            lbl_FirstName.TabIndex = 6;
            lbl_FirstName.Text = "First Name:";
            // 
            // txt_FirstName
            // 
            txt_FirstName.Location = new Point(120, 143);
            txt_FirstName.Name = "txt_FirstName";
            txt_FirstName.ReadOnly = true;
            txt_FirstName.Size = new Size(280, 27);
            txt_FirstName.TabIndex = 7;
            // 
            // lbl_LastName
            // 
            lbl_LastName.AutoSize = true;
            lbl_LastName.Location = new Point(420, 146);
            lbl_LastName.Name = "lbl_LastName";
            lbl_LastName.Size = new Size(82, 20);
            lbl_LastName.TabIndex = 8;
            lbl_LastName.Text = "Last Name:";
            // 
            // txt_LastName
            // 
            txt_LastName.Location = new Point(510, 143);
            txt_LastName.Name = "txt_LastName";
            txt_LastName.ReadOnly = true;
            txt_LastName.Size = new Size(230, 27);
            txt_LastName.TabIndex = 9;
            // 
            // btn_Refresh
            // 
            btn_Refresh.BackColor = Color.FromArgb(0, 150, 136);
            btn_Refresh.FlatStyle = FlatStyle.Flat;
            btn_Refresh.ForeColor = Color.White;
            btn_Refresh.Location = new Point(590, 180);
            btn_Refresh.Name = "btn_Refresh";
            btn_Refresh.Size = new Size(150, 30);
            btn_Refresh.TabIndex = 10;
            btn_Refresh.Text = "Làm mới";
            btn_Refresh.UseVisualStyleBackColor = false;
            btn_Refresh.Click += btn_Refresh_Click;
            // 
            // groupBox_Json
            // 
            groupBox_Json.Controls.Add(txt_JsonResponse);
            groupBox_Json.Location = new Point(20, 480);
            groupBox_Json.Name = "groupBox_Json";
            groupBox_Json.Size = new Size(760, 200);
            groupBox_Json.TabIndex = 4;
            groupBox_Json.TabStop = false;
            groupBox_Json.Text = "JSON Response";
            // 
            // txt_JsonResponse
            // 
            txt_JsonResponse.Dock = DockStyle.Fill;
            txt_JsonResponse.Font = new Font("Consolas", 9F);
            txt_JsonResponse.Location = new Point(3, 23);
            txt_JsonResponse.Multiline = true;
            txt_JsonResponse.Name = "txt_JsonResponse";
            txt_JsonResponse.ReadOnly = true;
            txt_JsonResponse.ScrollBars = ScrollBars.Vertical;
            txt_JsonResponse.Size = new Size(754, 174);
            txt_JsonResponse.TabIndex = 0;
            // 
            // Bai06
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 700);
            Controls.Add(groupBox_Json);
            Controls.Add(groupBox_UserInfo);
            Controls.Add(lbl_Status);
            Controls.Add(groupBox_Login);
            Controls.Add(lbl_Title);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Bai06";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 6 - HTTP GET User Info";
            groupBox_Login.ResumeLayout(false);
            groupBox_Login.PerformLayout();
            groupBox_UserInfo.ResumeLayout(false);
            groupBox_UserInfo.PerformLayout();
            groupBox_Json.ResumeLayout(false);
            groupBox_Json.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
