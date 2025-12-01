using Microsoft.Web.WebView2.WinForms;

namespace Bai03
{
    partial class Bai03
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnDownFiles = new System.Windows.Forms.Button();
            this.btnDownResources = new System.Windows.Forms.Button();
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 40);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(112, 20);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(460, 27);
            this.txtURL.TabIndex = 1;
            this.txtURL.Text = "https://uit.edu.vn/";
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(578, 12);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(94, 40);
            this.btnReload.TabIndex = 2;
            this.btnReload.Text = "reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnDownFiles
            // 
            this.btnDownFiles.Location = new System.Drawing.Point(490, 58);
            this.btnDownFiles.Name = "btnDownFiles";
            this.btnDownFiles.Size = new System.Drawing.Size(110, 29);
            this.btnDownFiles.TabIndex = 3;
            this.btnDownFiles.Text = "Down Files";
            this.btnDownFiles.UseVisualStyleBackColor = true;
            this.btnDownFiles.Click += new System.EventHandler(this.btnDownFiles_Click);
            // 
            // btnDownResources
            // 
            this.btnDownResources.Location = new System.Drawing.Point(606, 58);
            this.btnDownResources.Name = "btnDownResources";
            this.btnDownResources.Size = new System.Drawing.Size(140, 29);
            this.btnDownResources.TabIndex = 4;
            this.btnDownResources.Text = "Down Resources";
            this.btnDownResources.UseVisualStyleBackColor = true;
            this.btnDownResources.Click += new System.EventHandler(this.btnDownResources_Click);
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Location = new System.Drawing.Point(12, 93);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(760, 456);
            this.webView.TabIndex = 5;
            this.webView.ZoomFactor = 1D;
            // 
            // Bai03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.webView);
            this.Controls.Add(this.btnDownResources);
            this.Controls.Add(this.btnDownFiles);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.btnLoad);
            this.Name = "Bai03";
            this.Text = "Bai3";
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnDownFiles;
        private System.Windows.Forms.Button btnDownResources;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
    }
}
