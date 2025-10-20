using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Bai7_Client.Models;
using Bai7_Client.Network;

namespace Bai7_Client
{
    public partial class ClientForm : Form
    {
        private TcpClientHelper clientHelper;
        private NguoiDung currentUser;
        private List<MonAn> danhSachMonAn;
        private Random random;

        public ClientForm()
        {
            InitializeComponent();
            random = new Random();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPort.Text, out int port))
            {
                MessageBox.Show("Port không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clientHelper = new TcpClientHelper(txtServerIP.Text, port);

            if (clientHelper.Connect())
            {
                MessageBox.Show("Kết nối server thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnConnect.Enabled = false;
                txtServerIP.Enabled = false;
                txtPort.Enabled = false;
                groupBox2.Enabled = true;

                LoadNguoiDung();
            }
            else
            {
                MessageBox.Show("Không thể kết nối đến server!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNguoiDung()
        {
            List<NguoiDung> danhSach = clientHelper.GetAllNguoiDung();
            
            if (danhSach != null && danhSach.Count > 0)
            {
                cboNguoiDung.DataSource = danhSach;
                cboNguoiDung.DisplayMember = "HoVaTen";
                cboNguoiDung.ValueMember = "IDNCC";
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (cboNguoiDung.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn người dùng!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            currentUser = (NguoiDung)cboNguoiDung.SelectedItem;
            
            MessageBox.Show($"Đăng nhập thành công!\nXin chào {currentUser.HoVaTen}!", 
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            groupBox2.Enabled = false;
            groupBox3.Enabled = true;
            groupBox5.Enabled = true;

            LoadMonAn();
        }

        private void btnDangKyMoi_Click(object sender, EventArgs e)
        {
            DangKyForm form = new DangKyForm(clientHelper);
            
            if (form.ShowDialog() == DialogResult.OK)
            {
                // Reload danh sách người dùng
                LoadNguoiDung();
                
                // Tự động chọn user vừa đăng ký
                for (int i = 0; i < cboNguoiDung.Items.Count; i++)
                {
                    NguoiDung nd = (NguoiDung)cboNguoiDung.Items[i];
                    if (nd.IDNCC == form.NewUserID)
                    {
                        cboNguoiDung.SelectedIndex = i;
                        break;
                    }
                }
                
                // Tự động đăng nhập
                if (cboNguoiDung.SelectedItem != null)
                {
                    btnDangNhap_Click(sender, e);
                }
            }
        }

        private void LoadMonAn()
        {
            danhSachMonAn = clientHelper.GetAllMonAn();

            if (danhSachMonAn == null)
            {
                danhSachMonAn = new List<MonAn>();
                return;
            }

            listViewMonAn.Items.Clear();

            foreach (MonAn monAn in danhSachMonAn)
            {
                NguoiDung nguoiDung = clientHelper.GetNguoiDung(monAn.IDNCC);
                
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

            MonAn monAn = new MonAn
            {
                TenMonAn = txtTenMonAn.Text.Trim(),
                HinhAnh = txtHinhAnh.Text.Trim(),
                IDNCC = currentUser.IDNCC
            };

            if (clientHelper.AddMonAn(monAn))
            {
                MessageBox.Show("Thêm món ăn thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMonAn();
                ClearInput();
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm món ăn!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            pictureBox1.Image = null;
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.Title = "Chọn hình ảnh món ăn";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtHinhAnh.Text = openFileDialog1.FileName;
                
                // Hiển thị preview ảnh
                try
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể tải ảnh: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listViewMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewMonAn.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewMonAn.SelectedItems[0];
                MonAn monAn = (MonAn)item.Tag;

                if (monAn != null)
                {
                    // Hiển thị thông tin món ăn
                    NguoiDung nguoiDung = clientHelper.GetNguoiDung(monAn.IDNCC);
                    
                    lblKetQua.Text = $"🍽️ Thông tin món ăn\n\n" +
                                   $"Món ăn: {monAn.TenMonAn}\n" +
                                   $"Người đóng góp: {nguoiDung?.HoVaTen ?? "Unknown"}";

                    // Hiển thị hình ảnh
                    if (!string.IsNullOrEmpty(monAn.HinhAnh) && File.Exists(monAn.HinhAnh))
                    {
                        try
                        {
                            pictureBox1.Image = Image.FromFile(monAn.HinhAnh);
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        catch
                        {
                            pictureBox1.Image = null;
                            lblKetQua.Text += "\n\n⚠️ Không thể tải hình ảnh";
                        }
                    }
                    else
                    {
                        pictureBox1.Image = null;
                        lblKetQua.Text += "\n\n📷 Món ăn chưa có hình ảnh";
                    }
                }
            }
        }

        private void btnRandomCuaToi_Click(object sender, EventArgs e)
        {
            List<MonAn> monAnCuaToi = clientHelper.GetMyMonAn(currentUser.IDNCC);

            if (monAnCuaToi == null || monAnCuaToi.Count == 0)
            {
                MessageBox.Show("Bạn chưa có món ăn nào!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int randomIndex = random.Next(0, monAnCuaToi.Count);
            MonAn monAnNgauNhien = monAnCuaToi[randomIndex];

            DisplayMonAn(monAnNgauNhien, "Món ăn của bạn");
        }

        private void btnRandomCongDong_Click(object sender, EventArgs e)
        {
            if (danhSachMonAn == null || danhSachMonAn.Count == 0)
            {
                MessageBox.Show("Không có món ăn nào trong cộng đồng!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int randomIndex = random.Next(0, danhSachMonAn.Count);
            MonAn monAnNgauNhien = danhSachMonAn[randomIndex];

            DisplayMonAn(monAnNgauNhien, "Món ăn từ cộng đồng");
        }

        private void DisplayMonAn(MonAn monAn, string nguon)
        {
            NguoiDung nguoiDung = clientHelper.GetNguoiDung(monAn.IDNCC);

            lblKetQua.Text = $"🍽️ {nguon}\n\n" +
                           $"Món ăn: {monAn.TenMonAn}\n" +
                           $"Người đóng góp: {nguoiDung?.HoVaTen ?? "Unknown"}";

            // Hiển thị hình ảnh nếu có
            if (!string.IsNullOrEmpty(monAn.HinhAnh) && File.Exists(monAn.HinhAnh))
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(monAn.HinhAnh);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch
                {
                    pictureBox1.Image = null;
                    lblKetQua.Text += "\n\n⚠️ Không thể tải hình ảnh";
                }
            }
            else
            {
                pictureBox1.Image = null;
                lblKetQua.Text += "\n\n📷 Món ăn chưa có hình ảnh";
            }
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            clientHelper?.Disconnect();
        }
    }
}
