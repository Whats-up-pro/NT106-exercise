using System;
using System.Windows.Forms;
using Bai7_Client.Models;
using Bai7_Client.Network;

namespace Bai7_Client
{
    public partial class DangKyForm : Form
    {
        private TcpClientHelper clientHelper;
        public int NewUserID { get; private set; } = -1;

        public DangKyForm(TcpClientHelper client)
        {
            InitializeComponent();
            clientHelper = client;
        }

        private void DangKyForm_Load(object sender, EventArgs e)
        {
            cboQuyenHan.SelectedIndex = 0; // Mặc định là "User"
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboQuyenHan.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn quyền hạn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                NguoiDung nguoiDung = new NguoiDung
                {
                    HoVaTen = txtHoVaTen.Text.Trim(),
                    QuyenHan = cboQuyenHan.SelectedItem.ToString()
                };

                NewUserID = clientHelper.AddNguoiDung(nguoiDung);

                if (NewUserID > 0)
                {
                    MessageBox.Show($"Đăng ký thành công!\nXin chào {nguoiDung.HoVaTen}!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại! Vui lòng thử lại.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đăng ký: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
