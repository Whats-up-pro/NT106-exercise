using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Windows.Forms;

namespace Bai06
{
    public partial class Bai06 : Form
    {
        private readonly HttpClient httpClient;
        private string? accessToken;
        private string? tokenType;

        public Bai06()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private async void btn_Login_Click(object sender, EventArgs e)
        {
            string username = txt_Username.Text.Trim();
            string password = txt_Password.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btn_Login.Enabled = false;
                lbl_Status.Text = "Đang đăng nhập...";
                lbl_Status.ForeColor = System.Drawing.Color.Blue;

                // Tạo form-data cho HTTP POST
                var formData = new MultipartFormDataContent();
                formData.Add(new StringContent(username), "username");
                formData.Add(new StringContent(password), "password");

                // Gửi POST request
                var response = await httpClient.PostAsync("https://nt106.uitiot.vn/auth/token", formData);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // Parse JSON response
                    var jsonDoc = JsonDocument.Parse(responseContent);
                    var root = jsonDoc.RootElement;

                    tokenType = root.GetProperty("token_type").GetString();
                    accessToken = root.GetProperty("access_token").GetString();

                    lbl_Status.Text = "Đăng nhập thành công!";
                    lbl_Status.ForeColor = System.Drawing.Color.Green;

                    // Tự động lấy thông tin user
                    await GetUserInfo();
                }
                else
                {
                    // Parse error response
                    var jsonDoc = JsonDocument.Parse(responseContent);
                    var root = jsonDoc.RootElement;

                    string detail = root.GetProperty("detail").GetString() ?? "Đăng nhập không thành công";

                    lbl_Status.Text = detail;
                    lbl_Status.ForeColor = System.Drawing.Color.Red;
                    ClearUserInfo();
                }
            }
            catch (Exception ex)
            {
                lbl_Status.Text = $"Lỗi: {ex.Message}";
                lbl_Status.ForeColor = System.Drawing.Color.Red;
                ClearUserInfo();
            }
            finally
            {
                btn_Login.Enabled = true;
            }
        }

        private async Task GetUserInfo()
        {
            try
            {
                lbl_Status.Text = "Đang lấy thông tin người dùng...";
                lbl_Status.ForeColor = System.Drawing.Color.Blue;

                // Thêm Authorization header với JWT token
                httpClient.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue(tokenType ?? "Bearer", accessToken);

                // HTTP GET để lấy thông tin user
                var getUserResponse = await httpClient.GetAsync("https://nt106.uitiot.vn/api/v1/user/me");
                var getUserResponseString = await getUserResponse.Content.ReadAsStringAsync();

                if (getUserResponse.IsSuccessStatusCode)
                {
                    // Parse JSON response
                    var jsonDoc = JsonDocument.Parse(getUserResponseString);
                    var root = jsonDoc.RootElement;

                    // Hiển thị thông tin user
                    txt_UserId.Text = root.GetProperty("id").GetInt32().ToString();
                    txt_DisplayUsername.Text = root.GetProperty("username").GetString() ?? "";
                    txt_Email.Text = root.GetProperty("email").GetString() ?? "";
                    txt_FirstName.Text = root.GetProperty("first_name").GetString() ?? "";
                    txt_LastName.Text = root.GetProperty("last_name").GetString() ?? "";
                    
                    // Hiển thị JSON đầy đủ
                    txt_JsonResponse.Text = JsonSerializer.Serialize(
                        jsonDoc, 
                        new JsonSerializerOptions { WriteIndented = true }
                    );

                    lbl_Status.Text = "Đã tải thông tin người dùng thành công!";
                    lbl_Status.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lbl_Status.Text = "Không thể lấy thông tin người dùng!";
                    lbl_Status.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lbl_Status.Text = $"Lỗi khi lấy thông tin: {ex.Message}";
                lbl_Status.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ClearUserInfo()
        {
            txt_UserId.Clear();
            txt_DisplayUsername.Clear();
            txt_Email.Clear();
            txt_FirstName.Clear();
            txt_LastName.Clear();
            txt_JsonResponse.Clear();
            accessToken = null;
            tokenType = null;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_Username.Clear();
            txt_Password.Clear();
            ClearUserInfo();
            lbl_Status.Text = "";
        }

        private async void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                MessageBox.Show("Vui lòng đăng nhập trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await GetUserInfo();
        }
    }
}
