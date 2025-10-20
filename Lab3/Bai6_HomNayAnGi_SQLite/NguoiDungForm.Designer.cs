namespace Bai6_HomNayAnGi_SQLite
{
    partial class NguoiDungForm
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
            this.listViewNguoiDung = new System.Windows.Forms.ListView();
            this.columnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHoVaTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnQuyenHan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.cboQuyenHan = new System.Windows.Forms.ComboBox();
            this.txtHoVaTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listViewNguoiDung);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 250);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách người dùng";
            // 
            // listViewNguoiDung
            // 
            this.listViewNguoiDung.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnID,
            this.columnHoVaTen,
            this.columnQuyenHan});
            this.listViewNguoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewNguoiDung.FullRowSelect = true;
            this.listViewNguoiDung.GridLines = true;
            this.listViewNguoiDung.HideSelection = false;
            this.listViewNguoiDung.Location = new System.Drawing.Point(3, 16);
            this.listViewNguoiDung.Name = "listViewNguoiDung";
            this.listViewNguoiDung.Size = new System.Drawing.Size(454, 231);
            this.listViewNguoiDung.TabIndex = 0;
            this.listViewNguoiDung.UseCompatibleStateImageBehavior = false;
            this.listViewNguoiDung.View = System.Windows.Forms.View.Details;
            // 
            // columnID
            // 
            this.columnID.Text = "ID";
            this.columnID.Width = 50;
            // 
            // columnHoVaTen
            // 
            this.columnHoVaTen.Text = "Họ và tên";
            this.columnHoVaTen.Width = 250;
            // 
            // columnQuyenHan
            // 
            this.columnQuyenHan.Text = "Quyền hạn";
            this.columnQuyenHan.Width = 140;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThem);
            this.groupBox2.Controls.Add(this.cboQuyenHan);
            this.groupBox2.Controls.Add(this.txtHoVaTen);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 268);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 120);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thêm người dùng mới";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(180, 80);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 25);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cboQuyenHan
            // 
            this.cboQuyenHan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuyenHan.FormattingEnabled = true;
            this.cboQuyenHan.Items.AddRange(new object[] {
            "User",
            "Admin"});
            this.cboQuyenHan.Location = new System.Drawing.Point(120, 50);
            this.cboQuyenHan.Name = "cboQuyenHan";
            this.cboQuyenHan.Size = new System.Drawing.Size(320, 21);
            this.cboQuyenHan.TabIndex = 3;
            // 
            // txtHoVaTen
            // 
            this.txtHoVaTen.Location = new System.Drawing.Point(120, 25);
            this.txtHoVaTen.Name = "txtHoVaTen";
            this.txtHoVaTen.Size = new System.Drawing.Size(320, 20);
            this.txtHoVaTen.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quyền hạn:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ và tên:";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(372, 394);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 30);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // NguoiDungForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 436);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NguoiDungForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý người dùng";
            this.Load += new System.EventHandler(this.NguoiDungForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listViewNguoiDung;
        private System.Windows.Forms.ColumnHeader columnID;
        private System.Windows.Forms.ColumnHeader columnHoVaTen;
        private System.Windows.Forms.ColumnHeader columnQuyenHan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cboQuyenHan;
        private System.Windows.Forms.TextBox txtHoVaTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDong;
    }
}
