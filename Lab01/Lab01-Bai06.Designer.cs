namespace App1
{
    partial class Form6
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDiem = new System.Windows.Forms.TextBox();
            this.btnXuLy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.lstDanhSachDiem = new System.Windows.Forms.ListBox();
            this.lblDiemTB = new System.Windows.Forms.Label();
            this.lblCaoThap = new System.Windows.Forms.Label();
            this.lblKetQuaMon = new System.Windows.Forms.Label();
            this.lblXepLoai = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDiem
            // 
            this.txtDiem.Location = new System.Drawing.Point(125, 12);
            this.txtDiem.Name = "txtDiem";
            this.txtDiem.Size = new System.Drawing.Size(100, 20);
            this.txtDiem.TabIndex = 0;
            // 
            // btnXuLy
            // 
            this.btnXuLy.Location = new System.Drawing.Point(254, 15);
            this.btnXuLy.Name = "btnXuLy";
            this.btnXuLy.Size = new System.Drawing.Size(75, 23);
            this.btnXuLy.TabIndex = 1;
            this.btnXuLy.Text = "Xử lý dữ liệu";
            this.btnXuLy.UseVisualStyleBackColor = true;
            this.btnXuLy.Click += new System.EventHandler(this.btnXuLy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nhập DS điểm";
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Location = new System.Drawing.Point(32, 72);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(94, 13);
            this.lblThongBao.TabIndex = 3;
            this.lblThongBao.Text = "Đúng/ Sai Format:";
            // 
            // lstDanhSachDiem
            // 
            this.lstDanhSachDiem.FormattingEnabled = true;
            this.lstDanhSachDiem.Location = new System.Drawing.Point(418, 19);
            this.lstDanhSachDiem.Name = "lstDanhSachDiem";
            this.lstDanhSachDiem.Size = new System.Drawing.Size(370, 95);
            this.lstDanhSachDiem.TabIndex = 4;
            this.lstDanhSachDiem.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // lblDiemTB
            // 
            this.lblDiemTB.AutoSize = true;
            this.lblDiemTB.Location = new System.Drawing.Point(32, 99);
            this.lblDiemTB.Name = "lblDiemTB";
            this.lblDiemTB.Size = new System.Drawing.Size(51, 13);
            this.lblDiemTB.TabIndex = 5;
            this.lblDiemTB.Text = "Điểm TB:";
            // 
            // lblCaoThap
            // 
            this.lblCaoThap.AutoSize = true;
            this.lblCaoThap.Location = new System.Drawing.Point(32, 123);
            this.lblCaoThap.Name = "lblCaoThap";
            this.lblCaoThap.Size = new System.Drawing.Size(79, 13);
            this.lblCaoThap.TabIndex = 6;
            this.lblCaoThap.Text = "Điểm cao nhất:";
            // 
            // lblKetQuaMon
            // 
            this.lblKetQuaMon.AutoSize = true;
            this.lblKetQuaMon.Location = new System.Drawing.Point(32, 162);
            this.lblKetQuaMon.Name = "lblKetQuaMon";
            this.lblKetQuaMon.Size = new System.Drawing.Size(88, 13);
            this.lblKetQuaMon.TabIndex = 7;
            this.lblKetQuaMon.Text = "Số môn đậu/ rớt:";
            this.lblKetQuaMon.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblXepLoai
            // 
            this.lblXepLoai.AutoSize = true;
            this.lblXepLoai.Location = new System.Drawing.Point(32, 196);
            this.lblXepLoai.Name = "lblXepLoai";
            this.lblXepLoai.Size = new System.Drawing.Size(48, 13);
            this.lblXepLoai.TabIndex = 8;
            this.lblXepLoai.Text = "Xếp loại:";
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblXepLoai);
            this.Controls.Add(this.lblKetQuaMon);
            this.Controls.Add(this.lblCaoThap);
            this.Controls.Add(this.lblDiemTB);
            this.Controls.Add(this.lstDanhSachDiem);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXuLy);
            this.Controls.Add(this.txtDiem);
            this.Name = "Form6";
            this.Text = "Form6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDiem;
        private System.Windows.Forms.Button btnXuLy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.ListBox lstDanhSachDiem;
        private System.Windows.Forms.Label lblDiemTB;
        private System.Windows.Forms.Label lblCaoThap;
        private System.Windows.Forms.Label lblKetQuaMon;
        private System.Windows.Forms.Label lblXepLoai;
    }
}