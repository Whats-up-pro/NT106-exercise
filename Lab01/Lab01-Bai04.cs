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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            cmbLoaiTien.Items.Add("USD (Đô-la Mỹ)");
            cmbLoaiTien.Items.Add("EUR (Euro)");
            cmbLoaiTien.Items.Add("GBP (Bảng Anh)");
            cmbLoaiTien.Items.Add("SGD (Đô-la Singapore)");
            cmbLoaiTien.Items.Add("JPY (Yên Nhật)");
            cmbLoaiTien.SelectedIndex = 0;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void btnDoiTien_Click(object sender, EventArgs e)
        {
            try
            {
                double soTien = double.Parse(txtSoTien.Text.Trim());
                double tyGia = 0;

                switch (cmbLoaiTien.SelectedItem.ToString())
                {
                    case "USD (Đô-la Mỹ)": tyGia = 22772; break;
                    case "EUR (Euro)": tyGia = 28132; break;
                    case "GBP (Bảng Anh)": tyGia = 31538; break;
                    case "SGD (Đô-la Singapore)": tyGia = 17286; break;
                    case "JPY (Yên Nhật)": tyGia = 214; break;
                    default:
                        MessageBox.Show("Vui lòng chọn loại tiền tệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }

                double ketQua = soTien * tyGia;
                txtKetQua.Text = $"{ketQua:N0} VNĐ";
                Rate.Text = $"1 {cmbLoaiTien.SelectedItem} = {tyGia:N0} VNĐ";

            }
            catch
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form4_Load_1(object sender, EventArgs e)
        {

        }
    }
}
