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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSo.Text = "";
            txtRead.Text = "";
            txtSo.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDocSo_Click(object sender, EventArgs e)
        {
            try
            {
                int so = int.Parse(txtSo.Text.Trim());
                string chu = "";

                switch (so)
                {
                    case 0: chu = "Không"; break;
                    case 1: chu = "Một"; break;
                    case 2: chu = "Hai"; break;
                    case 3: chu = "Ba"; break;
                    case 4: chu = "Bốn"; break;
                    case 5: chu = "Năm"; break;
                    case 6: chu = "Sáu"; break;
                    case 7: chu = "Bảy"; break;
                    case 8: chu = "Tám"; break;
                    case 9: chu = "Chín"; break;
                    default: chu = "Vui lòng nhập số từ 0 đến 9"; break;
                }

                txtRead.Text = chu;
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập số nguyên hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
