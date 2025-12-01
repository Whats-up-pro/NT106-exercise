namespace Bai02
{
    partial class Bai02
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtURL = new System.Windows.Forms.TextBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.rtbHTML = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(24, 25);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(430, 27);
            this.txtURL.TabIndex = 0;
            this.txtURL.Text = "http://uit.edu.vn";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(24, 65);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(430, 27);
            this.txtFilePath.TabIndex = 1;
            this.txtFilePath.Text = "E:\\uit.html";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(472, 35);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(94, 40);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // rtbHTML
            // 
            this.rtbHTML.Location = new System.Drawing.Point(24, 110);
            this.rtbHTML.Name = "rtbHTML";
            this.rtbHTML.Size = new System.Drawing.Size(542, 300);
            this.rtbHTML.TabIndex = 3;
            this.rtbHTML.Text = "";
            // 
            // Bai02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 433);
            this.Controls.Add(this.rtbHTML);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.txtURL);
            this.Name = "Bai02";
            this.Text = "Bai2";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.RichTextBox rtbHTML;
    }
}
