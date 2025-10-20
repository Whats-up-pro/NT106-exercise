using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lab02
{
    public partial class Form5 : Form
    {
        List<Phim> danhSachPhim = new List<Phim>();

        public Form5()
        {
            InitializeComponent();
        }

        private void BtnDocFile_Click(object sender, EventArgs e)
        {
            danhSachPhim.Clear();
            string path = "input5.txt";

            if (!File.Exists(path))
            {
                MessageBox.Show("Không tìm thấy file input5.txt");
                return;
            }

            string[] lines = File.ReadAllLines(path);
            if (lines.Length % 5 != 0)
            {
                MessageBox.Show("File không đúng định dạng! Mỗi phim cần 5 dòng.");
                return;
            }

            for (int i = 0; i < lines.Length; i += 5)
            {
                string tenPhim = lines[i];
                double giaVe = double.Parse(lines[i + 1]);
                List<int> phongChieu = lines[i + 2].Split(',').Select(int.Parse).ToList();

                int soVeBan = string.IsNullOrWhiteSpace(lines[i + 3]) ? 0 : int.Parse(lines[i + 3]);
                int soVeTon = string.IsNullOrWhiteSpace(lines[i + 4]) ? 0 : int.Parse(lines[i + 4]);

                var phim = new Phim
                {
                    TenPhim = tenPhim,
                    GiaVeChuan = giaVe,
                    PhongChieu = phongChieu,
                    SoLuongVeBan = soVeBan,
                    SoLuongVeTon = soVeTon
                };

                danhSachPhim.Add(phim);
            }

            dgvPhim.DataSource = danhSachPhim.Select(p => new
            {
                p.TenPhim,
                p.GiaVeChuan,
                PhongChieu = string.Join(",", p.PhongChieu),
                p.SoLuongVeBan,
                p.SoLuongVeTon,
                DoanhThu = p.DoanhThu,
                TiLeBan = p.TiLeBan.ToString("P2")
            }).ToList();
        }


        private void btnXuatThongKe_Click(object sender, EventArgs e)
        {
            var thongKe = danhSachPhim
                .OrderByDescending(p => p.DoanhThu)
                .Select((p, index) => new
                {
                    p.TenPhim,
                    p.SoLuongVeBan,
                    p.SoLuongVeTon,
                    TiLeBan = p.TiLeBan.ToString("P2"),
                    DoanhThu = p.DoanhThu.ToString("N0"),
                    XepHang = index + 1
                }).ToList();

            progressBar1.Maximum = thongKe.Count;
            progressBar1.Value = 0;

            using (StreamWriter sw = new StreamWriter("output5.txt"))
            {
                foreach (var phim in thongKe)
                {
                    sw.WriteLine($"Tên phim: {phim.TenPhim}");
                    sw.WriteLine($"Số vé bán: {phim.SoLuongVeBan}");
                    sw.WriteLine($"Số vé tồn: {phim.SoLuongVeTon}");
                    sw.WriteLine($"Tỉ lệ bán: {phim.TiLeBan}");
                    sw.WriteLine($"Doanh thu: {phim.DoanhThu}");
                    sw.WriteLine($"Xếp hạng: {phim.XepHang}");
                    sw.WriteLine(new string('-', 40));

                    progressBar1.Value++;
                    Application.DoEvents(); // cập nhật UI
                }
            }

            MessageBox.Show("Xuất thống kê thành công!");
        }

        private void dgvPhim_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Không cần xử lý gì ở đây nếu không có yêu cầu tương tác
        }
    }
}
