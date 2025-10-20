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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(txtA.Text.Trim());
                double b = double.Parse(txtC.Text.Trim());
                double c = double.Parse(txtB.Text.Trim());

                double max, min;

                // Tìm số lớn nhất
                if (a >= b && a >= c)
                    max = a;
                else if (b >= a && b >= c)
                    max = b;
                else
                    max = c;

                // Tìm số nhỏ nhất
                if (a <= b && a <= c)
                    min = a;
                else if (b <= a && b <= c)
                    min = b;
                else
                    min = c;

                txtMax.Text = max.ToString();
                txtMin.Text = min.ToString();
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát?","Thoát chương trình", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtA.Text = "";
            txtB.Text = "";
            txtC.Text = "";
            txtMax.Text = "";
            txtMin.Text = "";
            txtA.Focus();       //đưa pointer về số đầu tiên
        }
    }
}
