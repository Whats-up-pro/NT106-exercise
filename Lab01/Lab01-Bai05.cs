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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtA.Text = "";
            txtB.Text = "";
            txtA.Focus();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            try
            {
                int A = int.Parse(txtA.Text.Trim());
                int B = int.Parse(txtB.Text.Trim());

                // Giai thừa
                long giaiThuaA = 1, giaiThuaB = 1;
                for (int i = 1; i <= A; i++) giaiThuaA *= i;
                for (int i = 1; i <= B; i++) giaiThuaB *= i;

                // Tổng S1 và biểu thức
                int S1 = 0;
                string chuoiS1 = "";
                for (int i = 1; i < A; i++)
                {
                    S1 += i;
                    chuoiS1 += i + " + ";
                }
                chuoiS1 += "A";

                // Tổng S2 và biểu thức
                int S2 = 0;
                string chuoiS2 = "";
                for (int i = 1; i < B; i++)
                {
                    S2 += i;
                    chuoiS2 += i + " + ";
                }
                chuoiS2 += "B";

                // Tổng S3 = A^1 + A^2 + ... + A^B
                double S3 = 0;
                string chuoiS3 = "";
                for (int i = 1; i <= B; i++)
                {
                    double luyThua = Math.Pow(A, i);
                    S3 += luyThua;
                    chuoiS3 += $"A^{i}" + (i < B ? " + " : "");
                }

                // Hiển thị kết quả
                lblKetQua.Text =
                    $"A! = {giaiThuaA}              " +
                    $"B! = {giaiThuaB}\n"             +
                    $"S1 = {chuoiS1} = {S1}\n"        +
                    $"S2 = {chuoiS2} = {S2}\n"        +
                    $"S3 = {chuoiS3} = {S3:N0}";
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập số nguyên hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
