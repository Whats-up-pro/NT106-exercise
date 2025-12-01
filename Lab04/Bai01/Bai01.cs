using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Bai01
{
    public partial class Bai01 : Form
    {
        public Bai01()
        {
            InitializeComponent();
        }

        private string getHTML(string szURL)
        {
            try
            {
                // Create a request for the URL.
                WebRequest request = WebRequest.Create(szURL);
                // Get the response.
                WebResponse response = request.GetResponse();
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Close the response.
                response.Close();
                return responseFromServer;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        private void btnGET_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtURL.Text))
            {
                MessageBox.Show("Please enter a URL!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string url = txtURL.Text.Trim();
            
            // Add http:// if not present
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "http://" + url;
            }

            // Get HTML content
            string htmlContent = getHTML(url);
            
            // Display in RichTextBox
            rtbHTML.Text = htmlContent;
        }
    }
}
