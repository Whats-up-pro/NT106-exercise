namespace App1
{
    partial class Form4
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
            this.Amount = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.cmbLoaiTien = new System.Windows.Forms.ComboBox();
            this.btnDoiTien = new System.Windows.Forms.Button();
            this.Changed = new System.Windows.Forms.Label();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.ExchangeRate = new System.Windows.Forms.Label();
            this.Rate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Amount
            // 
            this.Amount.AutoSize = true;
            this.Amount.Location = new System.Drawing.Point(51, 41);
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(79, 13);
            this.Amount.TabIndex = 0;
            this.Amount.Text = "Số tiền cần đổi";
            this.Amount.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(136, 38);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(132, 20);
            this.txtSoTien.TabIndex = 1;
            // 
            // cmbLoaiTien
            // 
            this.cmbLoaiTien.AllowDrop = true;
            this.cmbLoaiTien.FormattingEnabled = true;
            this.cmbLoaiTien.Items.AddRange(new object[] {
            "USD (Đô-la Mỹ)",
            "EUR (Euro)",
            "GBP (Bảng Anh)",
            "SGD (Đô-la Singapore)",
            "JPY (Yên Nhật)"});
            this.cmbLoaiTien.Location = new System.Drawing.Point(274, 38);
            this.cmbLoaiTien.Name = "cmbLoaiTien";
            this.cmbLoaiTien.Size = new System.Drawing.Size(121, 21);
            this.cmbLoaiTien.TabIndex = 2;
            this.cmbLoaiTien.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnDoiTien
            // 
            this.btnDoiTien.Location = new System.Drawing.Point(54, 75);
            this.btnDoiTien.Name = "btnDoiTien";
            this.btnDoiTien.Size = new System.Drawing.Size(182, 23);
            this.btnDoiTien.TabIndex = 3;
            this.btnDoiTien.Text = "Chuyển đổi";
            this.btnDoiTien.UseVisualStyleBackColor = true;
            this.btnDoiTien.Click += new System.EventHandler(this.btnDoiTien_Click);
            // 
            // Changed
            // 
            this.Changed.AutoSize = true;
            this.Changed.Location = new System.Drawing.Point(51, 121);
            this.Changed.Name = "Changed";
            this.Changed.Size = new System.Drawing.Size(74, 13);
            this.Changed.TabIndex = 4;
            this.Changed.Text = "Số tiền đã đổi";
            this.Changed.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtKetQua
            // 
            this.txtKetQua.Location = new System.Drawing.Point(136, 118);
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.Size = new System.Drawing.Size(132, 20);
            this.txtKetQua.TabIndex = 5;
            this.txtKetQua.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ExchangeRate
            // 
            this.ExchangeRate.AutoSize = true;
            this.ExchangeRate.Location = new System.Drawing.Point(48, 180);
            this.ExchangeRate.Name = "ExchangeRate";
            this.ExchangeRate.Size = new System.Drawing.Size(77, 13);
            this.ExchangeRate.TabIndex = 6;
            this.ExchangeRate.Text = "Tỷ giá quy đổi:";
            // 
            // Rate
            // 
            this.Rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rate.Location = new System.Drawing.Point(133, 180);
            this.Rate.Name = "Rate";
            this.Rate.Size = new System.Drawing.Size(262, 23);
            this.Rate.TabIndex = 7;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Rate);
            this.Controls.Add(this.ExchangeRate);
            this.Controls.Add(this.txtKetQua);
            this.Controls.Add(this.Changed);
            this.Controls.Add(this.btnDoiTien);
            this.Controls.Add(this.cmbLoaiTien);
            this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.Amount);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Amount;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.ComboBox cmbLoaiTien;
        private System.Windows.Forms.Button btnDoiTien;
        private System.Windows.Forms.Label Changed;
        private System.Windows.Forms.TextBox txtKetQua;
        private System.Windows.Forms.Label ExchangeRate;
        private System.Windows.Forms.Label Rate;
    }
}