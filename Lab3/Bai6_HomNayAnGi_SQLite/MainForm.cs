using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Bai6_HomNayAnGi_SQLite.Database;
using Bai6_HomNayAnGi_SQLite.Models;

namespace Bai6_HomNayAnGi_SQLite
{
    public partial class MainForm : Form
    {
        private DatabaseHelper dbHelper;
        private List<MonAn> danhSachMonAn;
        private List<NguoiDung> danhSachNguoiDung;
        private Random random;

        public MainForm()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            random = new Random();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadNguoiDung();
            LoadMonAn();
        }

        private void LoadNguoiDung()
        {
            danhSachNguoiDung = dbHelper.GetAllNguoiDung();
            cboNguoiDung.DataSource = null;
            cboNguoiDung.DataSource = danhSachNguoiDung;
            cboNguoiDung.DisplayMember = "HoVaTen";
            cboNguoiDung.ValueMember = "IDNCC";
        }

        private void LoadMonAn()
        {
            danhSachMonAn = dbHelper.GetAllMonAn();
            listViewMonAn.Items.Clear();

            foreach (MonAn monAn in danhSachMonAn)
            {
                NguoiDung nguoiDung = dbHelper.GetNguoiDungById(monAn.IDNCC);
                ListViewItem item = new ListViewItem(monAn.IDMA.ToString());
                item.SubItems.Add(monAn.TenMonAn);
                item.SubItems.Add(nguoiDung != null ? nguoiDung.HoVaTen : "Unknown");
                item.Tag = monAn;
                listViewMonAn.Items.Add(item);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenMonAn.Text))
            {
                MessageBox.Show("Vui lòng nhập tên món ăn!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboNguoiDung.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn người đóng góp!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MonAn monAn = new MonAn
            {
                TenMonAn = txtTenMonAn.Text.Trim(),
                HinhAnh = txtHinhAnh.Text.Trim(),
                IDNCC = ((NguoiDung)cboNguoiDung.SelectedItem).IDNCC
            };

            try
            {
                dbHelper.AddMonAn(monAn);
                MessageBox.Show("Thêm món ăn thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMonAn();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm món ăn: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listViewMonAn.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa món ăn này?", 
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MonAn monAn = (MonAn)listViewMonAn.SelectedItems[0].Tag;
                try
                {
                    dbHelper.DeleteMonAn(monAn.IDMA);
                    MessageBox.Show("Xóa món ăn thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMonAn();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa món ăn: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadMonAn();
            ClearInput();
        }

        private void ClearInput()
        {
            txtTenMonAn.Clear();
            txtHinhAnh.Clear();
            if (cboNguoiDung.Items.Count > 0)
                cboNguoiDung.SelectedIndex = 0;
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            if (danhSachMonAn == null || danhSachMonAn.Count == 0)
            {
                MessageBox.Show("Không có món ăn nào trong danh sách!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int randomIndex = random.Next(0, danhSachMonAn.Count);
            MonAn monAnNgauNhien = danhSachMonAn[randomIndex];
            NguoiDung nguoiDung = dbHelper.GetNguoiDungById(monAnNgauNhien.IDNCC);

            lblKetQua.Text = $"🍽️ Món ăn: {monAnNgauNhien.TenMonAn}\n\n" +
                           $"👤 Người đóng góp: {nguoiDung?.HoVaTen ?? "Unknown"}";

            // Hiển thị hình ảnh nếu có
            if (!string.IsNullOrEmpty(monAnNgauNhien.HinhAnh) && File.Exists(monAnNgauNhien.HinhAnh))
            {
                try
                {
                    pictureBoxMonAn.Image = Image.FromFile(monAnNgauNhien.HinhAnh);
                }
                catch
                {
                    pictureBoxMonAn.Image = null;
                }
            }
            else
            {
                pictureBoxMonAn.Image = null;
            }
        }

        private void btnQuanLyNguoiDung_Click(object sender, EventArgs e)
        {
            NguoiDungForm form = new NguoiDungForm();
            form.ShowDialog();
            
            // Reload lại danh sách người dùng sau khi đóng form
            LoadNguoiDung();
        }
    }
}
