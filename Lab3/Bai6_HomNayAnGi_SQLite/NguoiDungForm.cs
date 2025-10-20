using System;
using System.Windows.Forms;
using Bai6_HomNayAnGi_SQLite.Database;
using Bai6_HomNayAnGi_SQLite.Models;

namespace Bai6_HomNayAnGi_SQLite
{
    public partial class NguoiDungForm : Form
    {
        private DatabaseHelper dbHelper;

        public NguoiDungForm()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void NguoiDungForm_Load(object sender, EventArgs e)
        {
            cboQuyenHan.SelectedIndex = 0; // Mặc định là "User"
            LoadNguoiDung();
        }

        private void LoadNguoiDung()
        {
            var danhSach = dbHelper.GetAllNguoiDung();
            listViewNguoiDung.Items.Clear();

            foreach (var nguoiDung in danhSach)
            {
                ListViewItem item = new ListViewItem(nguoiDung.IDNCC.ToString());
                item.SubItems.Add(nguoiDung.HoVaTen);
                item.SubItems.Add(nguoiDung.QuyenHan);
                listViewNguoiDung.Items.Add(item);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
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

                dbHelper.AddNguoiDung(nguoiDung);

                MessageBox.Show("Thêm người dùng thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtHoVaTen.Clear();
                cboQuyenHan.SelectedIndex = 0;
                LoadNguoiDung();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm người dùng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
