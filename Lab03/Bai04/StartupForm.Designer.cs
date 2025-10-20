namespace Lab02
{
    partial class StartupForm
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
            this.btnServer = new System.Windows.Forms.Button();
            this.btnClient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnForm5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnServer
            // 
            this.btnServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServer.Location = new System.Drawing.Point(50, 80);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(300, 60);
            this.btnServer.TabIndex = 0;
            this.btnServer.Text = "Khởi động Server";
            this.btnServer.UseVisualStyleBackColor = true;
            this.btnServer.Click += new System.EventHandler(this.btnServer_Click);
            // 
            // btnClient
            // 
            this.btnClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClient.Location = new System.Drawing.Point(50, 160);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(300, 60);
            this.btnClient.TabIndex = 1;
            this.btnClient.Text = "Khởi động Client";
            this.btnClient.UseVisualStyleBackColor = true;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn chế độ khởi động";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnForm5
            // 
            this.btnForm5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForm5.Location = new System.Drawing.Point(50, 240);
            this.btnForm5.Name = "btnForm5";
            this.btnForm5.Size = new System.Drawing.Size(300, 40);
            this.btnForm5.TabIndex = 3;
            this.btnForm5.Text = "Form 5 (Standalone)";
            this.btnForm5.UseVisualStyleBackColor = true;
            this.btnForm5.Click += new System.EventHandler(this.btnForm5_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(50, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 40);
            this.label2.TabIndex = 4;
            this.label2.Text = "23521308 - Phạm Tấn Gia Quốc\r\nLab02 - Quản lý phòng vé";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnForm5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.btnServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "StartupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab02 - Startup";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnServer;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnForm5;
        private System.Windows.Forms.Label label2;
    }
}
