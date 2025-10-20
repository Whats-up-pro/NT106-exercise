using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace Lab02
{
    public partial class Form6 : Form
    {
        List<MonAn> danhSachMonAn = new List<MonAn>();
        private ListView listView1;
        private PictureBox pictureBox1;
        private Label lblTenMon;
        private Button btnChonMon;
        private Label lblNguoiDongGop;
        string connectionString = "Data Source=MonAn.db;Version=3;";


        private void LoadDanhSachMonAn()
        {
            danhSachMonAn.Clear();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT MonAn.TenMonAn, MonAn.HinhAnh, NguoiDung.HoVaTen 
                         FROM MonAn JOIN NguoiDung ON MonAn.IDNCC = NguoiDung.IDNCC";

                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var mon = new MonAn
                    {
                        TenMonAn = reader.GetString(0),
                        HinhAnh = reader.GetString(1),
                        HoVaTenNguoiDongGop = reader.GetString(2)
                    };
                    danhSachMonAn.Add(mon);
                }
            }

            listView1.Items.Clear();
            foreach (var mon in danhSachMonAn)
            {
                var item = new ListViewItem(mon.TenMonAn);
                item.SubItems.Add(mon.HoVaTenNguoiDongGop);
                listView1.Items.Add(item);
            }
        }
        public Form6()
        {
            InitializeComponent();
            LoadDanhSachMonAn();
        }

        // Ví dụ: hàm để load dữ liệu từ SQLite
        

        private void TaoDatabaseVaBang()
        {
            string dbPath = "MonAn.db";

            // Tạo file nếu chưa tồn tại
            if (!System.IO.File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            string connectionString = $"Data Source={dbPath};Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string taoBangNguoiDung = @"
            CREATE TABLE IF NOT EXISTS NguoiDung (
                IDNCC INTEGER PRIMARY KEY AUTOINCREMENT,
                HoVaTen TEXT NOT NULL,
                QuyenHan TEXT NOT NULL
            );";

                string taoBangMonAn = @"
            CREATE TABLE IF NOT EXISTS MonAn (
                IDMA INTEGER PRIMARY KEY AUTOINCREMENT,
                TenMonAn TEXT NOT NULL,
                HinhAnh TEXT NOT NULL,
                IDNCC INTEGER NOT NULL,
                FOREIGN KEY(IDNCC) REFERENCES NguoiDung(IDNCC)
            );";

                SQLiteCommand cmd1 = new SQLiteCommand(taoBangNguoiDung, conn);
                SQLiteCommand cmd2 = new SQLiteCommand(taoBangMonAn, conn);

                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Tạo cơ sở dữ liệu và bảng thành công!");
            }
        }

        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.btnChonMon = new System.Windows.Forms.Button();
            this.lblNguoiDongGop = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(23, 43);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(287, 380);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.Columns.Add("Tên món ăn", 150);
            listView1.Columns.Add("Người đóng góp", 120);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(383, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(661, 380);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblTenMon
            // 
            this.lblTenMon.AutoSize = true;
            this.lblTenMon.Location = new System.Drawing.Point(401, 21);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(79, 16);
            this.lblTenMon.TabIndex = 2;
            this.lblTenMon.Text = "Tên Món Ăn";
            // 
            // btnChonMon
            // 
            this.btnChonMon.Location = new System.Drawing.Point(98, 443);
            this.btnChonMon.Name = "btnChonMon";
            this.btnChonMon.Size = new System.Drawing.Size(136, 46);
            this.btnChonMon.TabIndex = 3;
            this.btnChonMon.Text = "Chọn Món";
            this.btnChonMon.UseVisualStyleBackColor = true;
            // 
            // lblNguoiDongGop
            // 
            this.lblNguoiDongGop.AutoSize = true;
            this.lblNguoiDongGop.Location = new System.Drawing.Point(673, 21);
            this.lblNguoiDongGop.Name = "lblNguoiDongGop";
            this.lblNguoiDongGop.Size = new System.Drawing.Size(104, 16);
            this.lblNguoiDongGop.TabIndex = 4;
            this.lblNguoiDongGop.Text = "Người đóng góp";
            this.lblNguoiDongGop.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form6
            // 
            this.ClientSize = new System.Drawing.Size(1122, 598);
            this.Controls.Add(this.lblNguoiDongGop);
            this.Controls.Add(this.btnChonMon);
            this.Controls.Add(this.lblTenMon);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listView1);
            this.Name = "Form6";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnChonMon_Click(object sender, EventArgs e)
        {
            if (danhSachMonAn.Count == 0)
            {
                MessageBox.Show("Chưa có món ăn nào!");
                return;
            }

            Random rnd = new Random();
            int index = rnd.Next(danhSachMonAn.Count);
            var mon = danhSachMonAn[index];

            pictureBox1.Image = Image.FromFile(mon.HinhAnh);
            lblTenMon.Text = mon.TenMonAn;
            lblNguoiDongGop.Text = mon.HoVaTenNguoiDongGop;
            this.btnChonMon.Click += new System.EventHandler(this.btnChonMon_Click);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
