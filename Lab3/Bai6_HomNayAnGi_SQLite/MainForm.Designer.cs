namespace Bai6_HomNayAnGi_SQLite
{
    partial class MainForm
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
            this.listViewMonAn = new System.Windows.Forms.ListView();
            this.columnIDMA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTenMonAn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnNguoiDongGop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTenMonAn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHinhAnh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboNguoiDung = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnQuanLyNguoiDung = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRandom = new System.Windows.Forms.Button();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.pictureBoxMonAn = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMonAn)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listViewMonAn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 300);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách món ăn";
            // 
            // listViewMonAn
            // 
            this.listViewMonAn.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnIDMA,
            this.columnTenMonAn,
            this.columnNguoiDongGop});
            this.listViewMonAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMonAn.FullRowSelect = true;
            this.listViewMonAn.GridLines = true;
            this.listViewMonAn.HideSelection = false;
            this.listViewMonAn.Location = new System.Drawing.Point(3, 16);
            this.listViewMonAn.Name = "listViewMonAn";
            this.listViewMonAn.Size = new System.Drawing.Size(444, 281);
            this.listViewMonAn.TabIndex = 0;
            this.listViewMonAn.UseCompatibleStateImageBehavior = false;
            this.listViewMonAn.View = System.Windows.Forms.View.Details;
            // 
            // columnIDMA
            // 
            this.columnIDMA.Text = "ID";
            this.columnIDMA.Width = 50;
            // 
            // columnTenMonAn
            // 
            this.columnTenMonAn.Text = "Tên món ăn";
            this.columnTenMonAn.Width = 200;
            // 
            // columnNguoiDongGop
            // 
            this.columnNguoiDongGop.Text = "Người đóng góp";
            this.columnNguoiDongGop.Width = 180;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLamMoi);
            this.groupBox2.Controls.Add(this.btnXoa);
            this.groupBox2.Controls.Add(this.btnThem);
            this.groupBox2.Controls.Add(this.cboNguoiDung);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtHinhAnh);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtTenMonAn);
            this.groupBox2.Location = new System.Drawing.Point(12, 318);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 170);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thêm món ăn mới";
            // 
            // txtTenMonAn
            // 
            this.txtTenMonAn.Location = new System.Drawing.Point(120, 30);
            this.txtTenMonAn.Name = "txtTenMonAn";
            this.txtTenMonAn.Size = new System.Drawing.Size(300, 20);
            this.txtTenMonAn.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên món ăn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hình ảnh:";
            // 
            // txtHinhAnh
            // 
            this.txtHinhAnh.Location = new System.Drawing.Point(120, 60);
            this.txtHinhAnh.Name = "txtHinhAnh";
            this.txtHinhAnh.Size = new System.Drawing.Size(300, 20);
            this.txtHinhAnh.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Người đóng góp:";
            // 
            // cboNguoiDung
            // 
            this.cboNguoiDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNguoiDung.FormattingEnabled = true;
            this.cboNguoiDung.Location = new System.Drawing.Point(120, 90);
            this.cboNguoiDung.Name = "cboNguoiDung";
            this.cboNguoiDung.Size = new System.Drawing.Size(300, 21);
            this.cboNguoiDung.TabIndex = 5;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(120, 130);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 25);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(220, 130);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 25);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(320, 130);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(90, 25);
            this.btnLamMoi.TabIndex = 8;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnQuanLyNguoiDung
            // 
            this.btnQuanLyNguoiDung.Location = new System.Drawing.Point(12, 494);
            this.btnQuanLyNguoiDung.Name = "btnQuanLyNguoiDung";
            this.btnQuanLyNguoiDung.Size = new System.Drawing.Size(150, 30);
            this.btnQuanLyNguoiDung.TabIndex = 9;
            this.btnQuanLyNguoiDung.Text = "Quản lý người dùng";
            this.btnQuanLyNguoiDung.UseVisualStyleBackColor = true;
            this.btnQuanLyNguoiDung.Click += new System.EventHandler(this.btnQuanLyNguoiDung_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBoxMonAn);
            this.groupBox3.Controls.Add(this.lblKetQua);
            this.groupBox3.Controls.Add(this.btnRandom);
            this.groupBox3.Location = new System.Drawing.Point(468, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 476);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hôm nay ăn gì?";
            // 
            // btnRandom
            // 
            this.btnRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandom.Location = new System.Drawing.Point(20, 30);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(284, 45);
            this.btnRandom.TabIndex = 0;
            this.btnRandom.Text = "Chọn ngẫu nhiên món ăn";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // lblKetQua
            // 
            this.lblKetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKetQua.Location = new System.Drawing.Point(20, 90);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(284, 80);
            this.lblKetQua.TabIndex = 1;
            this.lblKetQua.Text = "Nhấn nút để chọn món ăn!";
            this.lblKetQua.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxMonAn
            // 
            this.pictureBoxMonAn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxMonAn.Location = new System.Drawing.Point(20, 180);
            this.pictureBoxMonAn.Name = "pictureBoxMonAn";
            this.pictureBoxMonAn.Size = new System.Drawing.Size(284, 280);
            this.pictureBoxMonAn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMonAn.TabIndex = 2;
            this.pictureBoxMonAn.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 536);
            this.Controls.Add(this.btnQuanLyNguoiDung);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 6 - Hôm nay ăn gì? (SQLite)";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMonAn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listViewMonAn;
        private System.Windows.Forms.ColumnHeader columnIDMA;
        private System.Windows.Forms.ColumnHeader columnTenMonAn;
        private System.Windows.Forms.ColumnHeader columnNguoiDongGop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTenMonAn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHinhAnh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboNguoiDung;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnQuanLyNguoiDung;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.PictureBox pictureBoxMonAn;
    }
}
