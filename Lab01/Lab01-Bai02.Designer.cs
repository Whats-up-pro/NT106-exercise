namespace App1
{
    partial class Form2
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
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.btnTinh = new System.Windows.Forms.Button();
            this.num1 = new System.Windows.Forms.Label();
            this.num2 = new System.Windows.Forms.Label();
            this.num3 = new System.Windows.Forms.Label();
            this.Max = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.Min = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(99, 79);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(100, 20);
            this.txtA.TabIndex = 0;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(347, 79);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(100, 20);
            this.txtB.TabIndex = 1;
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(594, 79);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(100, 20);
            this.txtC.TabIndex = 2;
            // 
            // btnTinh
            // 
            this.btnTinh.Location = new System.Drawing.Point(99, 137);
            this.btnTinh.Name = "btnTinh";
            this.btnTinh.Size = new System.Drawing.Size(74, 31);
            this.btnTinh.TabIndex = 3;
            this.btnTinh.Text = "Tìm";
            this.btnTinh.UseVisualStyleBackColor = true;
            this.btnTinh.Click += new System.EventHandler(this.btnTinh_Click);
            // 
            // num1
            // 
            this.num1.AutoSize = true;
            this.num1.Location = new System.Drawing.Point(31, 82);
            this.num1.Name = "num1";
            this.num1.Size = new System.Drawing.Size(62, 13);
            this.num1.TabIndex = 4;
            this.num1.Text = "Số thứ nhất";
            this.num1.Click += new System.EventHandler(this.label1_Click);
            // 
            // num2
            // 
            this.num2.AutoSize = true;
            this.num2.Location = new System.Drawing.Point(286, 82);
            this.num2.Name = "num2";
            this.num2.Size = new System.Drawing.Size(55, 13);
            this.num2.TabIndex = 5;
            this.num2.Text = "Số thứ hai";
            // 
            // num3
            // 
            this.num3.AutoSize = true;
            this.num3.Location = new System.Drawing.Point(535, 82);
            this.num3.Name = "num3";
            this.num3.Size = new System.Drawing.Size(53, 13);
            this.num3.TabIndex = 6;
            this.num3.Text = "Số thứ ba";
            // 
            // Max
            // 
            this.Max.AutoSize = true;
            this.Max.Location = new System.Drawing.Point(31, 213);
            this.Max.Name = "Max";
            this.Max.Size = new System.Drawing.Size(61, 13);
            this.Max.TabIndex = 7;
            this.Max.Text = "Số lớn nhất";
            this.Max.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(99, 213);
            this.txtMax.Name = "txtMax";
            this.txtMax.ReadOnly = true;
            this.txtMax.Size = new System.Drawing.Size(100, 20);
            this.txtMax.TabIndex = 8;
            // 
            // Min
            // 
            this.Min.AutoSize = true;
            this.Min.Location = new System.Drawing.Point(370, 219);
            this.Min.Name = "Min";
            this.Min.Size = new System.Drawing.Size(65, 13);
            this.Min.TabIndex = 9;
            this.Min.Text = "Số nhỏ nhất";
            this.Min.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(441, 216);
            this.txtMin.Name = "txtMin";
            this.txtMin.ReadOnly = true;
            this.txtMin.Size = new System.Drawing.Size(100, 20);
            this.txtMin.TabIndex = 10;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(289, 137);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(74, 31);
            this.btnThoat.TabIndex = 11;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(514, 137);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(74, 31);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.Min);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.Max);
            this.Controls.Add(this.num3);
            this.Controls.Add(this.num2);
            this.Controls.Add(this.num1);
            this.Controls.Add(this.btnTinh);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.Button btnTinh;
        private System.Windows.Forms.Label num1;
        private System.Windows.Forms.Label num2;
        private System.Windows.Forms.Label num3;
        private System.Windows.Forms.Label Max;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label Min;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
    }
}