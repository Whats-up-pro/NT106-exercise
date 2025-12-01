using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using HtmlAgilityPack;

namespace Bai03
{
    public partial class Bai03 : Form
    {
        public Bai03()
        {
            InitializeComponent();
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await webView.EnsureCoreWebView2Async(null);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtURL.Text))
            {
                MessageBox.Show("Please enter a URL!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string url = txtURL.Text.Trim();
            
            // Add https:// if not present
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "https://" + url;
            }

            try
            {
                webView.Source = new Uri(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading URL: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (webView.Source != null)
            {
                webView.Reload();
            }
        }

        private void btnDownFiles_Click(object sender, EventArgs e)
        {
            if (webView.Source == null)
            {
                MessageBox.Show("Please load a website first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "HTML Files|*.html";
                saveFileDialog.Title = "Save HTML File";
                saveFileDialog.FileName = "webpage.html";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string url = webView.Source.ToString();
                    WebClient client = new WebClient();
                    client.DownloadFile(url, saveFileDialog.FileName);
                    
                    MessageBox.Show("HTML file downloaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error downloading file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDownResources_Click(object sender, EventArgs e)
        {
            if (webView.Source == null)
            {
                MessageBox.Show("Please load a website first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                folderDialog.Description = "Select folder to save images";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string url = webView.Source.ToString();
                    string folderPath = folderDialog.SelectedPath;

                    // Download HTML content
                    WebClient client = new WebClient();
                    string htmlContent = client.DownloadString(url);

                    // Parse HTML using HtmlAgilityPack
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(htmlContent);

                    // Find all img tags
                    var imgNodes = doc.DocumentNode.SelectNodes("//img[@src]");
                    
                    if (imgNodes == null || imgNodes.Count == 0)
                    {
                        MessageBox.Show("No images found on this page!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    int downloadedCount = 0;
                    foreach (var img in imgNodes)
                    {
                        try
                        {
                            string imgUrl = img.GetAttributeValue("src", "");
                            
                            // Convert relative URL to absolute URL
                            if (!imgUrl.StartsWith("http"))
                            {
                                Uri baseUri = new Uri(url);
                                Uri absoluteUri = new Uri(baseUri, imgUrl);
                                imgUrl = absoluteUri.ToString();
                            }

                            // Get filename from URL
                            string fileName = Path.GetFileName(new Uri(imgUrl).LocalPath);
                            if (string.IsNullOrEmpty(fileName))
                            {
                                fileName = $"image_{downloadedCount}.jpg";
                            }

                            string savePath = Path.Combine(folderPath, fileName);

                            // Download image
                            WebClient imgClient = new WebClient();
                            imgClient.DownloadFile(imgUrl, savePath);
                            downloadedCount++;
                        }
                        catch
                        {
                            // Skip failed downloads
                            continue;
                        }
                    }

                    MessageBox.Show($"Downloaded {downloadedCount} images successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error downloading resources: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
