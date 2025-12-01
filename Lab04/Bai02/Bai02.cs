using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Bai02
{
    public partial class Bai02 : Form
    {
        public Bai02()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtURL.Text))
            {
                MessageBox.Show("Please enter a URL!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFilePath.Text))
            {
                MessageBox.Show("Please enter a file path!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string url = txtURL.Text.Trim();
                string filePath = txtFilePath.Text.Trim();

                // Add http:// if not present
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "http://" + url;
                }

                // Create WebClient
                WebClient myClient = new WebClient();

                // Open read stream
                Stream response = myClient.OpenRead(url);
                
                // Download file
                myClient.DownloadFile(url, filePath);
                
                // Close stream
                response.Close();

                // Read the downloaded file and display in RichTextBox
                string htmlContent = File.ReadAllText(filePath);
                rtbHTML.Text = htmlContent;

                MessageBox.Show("Download completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
