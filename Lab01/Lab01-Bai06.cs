using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnXuLy_Click(object sender, EventArgs e)
        {
            string input = txtDiem.Text.Trim();
            string[] parts = input.Split(',');

            List<double> diemList = new List<double>();
            bool isValid = true;

            foreach (string part in parts)
            {
                if (double.TryParse(part.Trim(), out double diem))
                {
                    diemList.Add(diem);
                }
                else
                {
                    isValid = false;
                    break;
                }
            }

            if (!isValid || diemList.Count == 0)
            {
                lblThongBao.Text = "❌ Sai format! Vui lòng nhập lại.";
                lstDanhSachDiem.Items.Clear();
                return;
            }

            lblThongBao.Text = "✅ Đã nhập đúng format.";

            // Hiển thị danh sách điểm
            lstDanhSachDiem.Items.Clear();
            for (int i = 0; i < diemList.Count; i++)
            {
                lstDanhSachDiem.Items.Add($"Môn {i + 1}: {diemList[i]}");
            }

            // Tính điểm trung bình
            double diemTB = diemList.Average();
            lblDiemTB.Text = $"🎯 Điểm trung bình: {diemTB:N2}";

            // Tìm điểm cao nhất, thấp nhất
            double max = diemList.Max();
            double min = diemList.Min();
            int monMax = diemList.IndexOf(max) + 1;
            int monMin = diemList.IndexOf(min) + 1;
            lblCaoThap.Text = $"🔺 Cao nhất: Môn {monMax} ({max}) | 🔻 Thấp nhất: Môn {monMin} ({min})";

            // Đếm số môn đậu/rớt (đậu ≥ 5)
            int soMonDau = diemList.Count(d => d >= 5);
            int soMonRot = diemList.Count - soMonDau;
            lblKetQuaMon.Text = $"✅ Đậu: {soMonDau} môn | ❌ Rớt: {soMonRot} môn";

            // Xếp loại
            string xepLoai = "Kém";
            if (diemTB >= 8 && diemList.All(d => d >= 6.5)) xepLoai = "Giỏi";
            else if (diemTB >= 6.5 && diemList.All(d => d >= 5)) xepLoai = "Khá";
            else if (diemTB >= 5 && diemList.All(d => d >= 3.5)) xepLoai = "Trung Bình";
            else if (diemTB >= 3.5 && diemList.All(d => d >= 2)) xepLoai = "Yếu";

            lblXepLoai.Text = $"📌 Xếp loại: {xepLoai}";
        }
    }
}
