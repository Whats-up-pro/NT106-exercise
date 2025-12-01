namespace Bai01
{
    partial class Bai01
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
            this.btnGET = new System.Windows.Forms.Button();
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
            // btnGET
            // 
            this.btnGET.Location = new System.Drawing.Point(472, 23);
            this.btnGET.Name = "btnGET";
            this.btnGET.Size = new System.Drawing.Size(94, 29);
            this.btnGET.TabIndex = 1;
            this.btnGET.Text = "GET";
            this.btnGET.UseVisualStyleBackColor = true;
            this.btnGET.Click += new System.EventHandler(this.btnGET_Click);
            // 
            // rtbHTML
            // 
            this.rtbHTML.Location = new System.Drawing.Point(24, 70);
            this.rtbHTML.Name = "rtbHTML";
            this.rtbHTML.Size = new System.Drawing.Size(542, 340);
            this.rtbHTML.TabIndex = 2;
            this.rtbHTML.Text = "";
            // 
            // Bai01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 433);
            this.Controls.Add(this.rtbHTML);
            this.Controls.Add(this.btnGET);
            this.Controls.Add(this.txtURL);
            this.Name = "Bai01";
            this.Text = "Bai1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnGET;
        private System.Windows.Forms.RichTextBox rtbHTML;
    }
}
