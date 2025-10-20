namespace App1
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSo = new System.Windows.Forms.TextBox();
            this.DocSo = new System.Windows.Forms.Label();
            this.btnDocSo = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.Label();
            this.txtRead = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtSo
            // 
            this.txtSo.Location = new System.Drawing.Point(337, 34);
            this.txtSo.Name = "txtSo";
            this.txtSo.Size = new System.Drawing.Size(100, 20);
            this.txtSo.TabIndex = 0;
            this.txtSo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // DocSo
            // 
            this.DocSo.AutoSize = true;
            this.DocSo.Location = new System.Drawing.Point(94, 37);
            this.DocSo.Name = "DocSo";
            this.DocSo.Size = new System.Drawing.Size(158, 13);
            this.DocSo.TabIndex = 1;
            this.DocSo.Text = "Nhập vào số nguyên từ 0 đến 9";
            this.DocSo.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnDocSo
            // 
            this.btnDocSo.Location = new System.Drawing.Point(559, 37);
            this.btnDocSo.Name = "btnDocSo";
            this.btnDocSo.Size = new System.Drawing.Size(75, 23);
            this.btnDocSo.TabIndex = 2;
            this.btnDocSo.Text = "Đọc";
            this.btnDocSo.UseVisualStyleBackColor = true;
            this.btnDocSo.Click += new System.EventHandler(this.btnDocSo_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(559, 86);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(559, 137);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Location = new System.Drawing.Point(94, 117);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(46, 13);
            this.Result.TabIndex = 5;
            this.Result.Text = "Kết Quả";
            this.Result.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtRead
            // 
            this.txtRead.Location = new System.Drawing.Point(152, 114);
            this.txtRead.Name = "txtRead";
            this.txtRead.ReadOnly = true;
            this.txtRead.Size = new System.Drawing.Size(100, 20);
            this.txtRead.TabIndex = 6;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtRead);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnDocSo);
            this.Controls.Add(this.DocSo);
            this.Controls.Add(this.txtSo);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSo;
        private System.Windows.Forms.Label DocSo;
        private System.Windows.Forms.Button btnDocSo;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.TextBox txtRead;
    }
}