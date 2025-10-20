using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Result_Click(object sender, EventArgs e)
        {
   
        }

        private void InitializeComponent()
        {
            this.btnTinhTong = new System.Windows.Forms.Button();
            this.txtSo1 = new System.Windows.Forms.TextBox();
            this.txtSo2 = new System.Windows.Forms.TextBox();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.num1 = new System.Windows.Forms.Label();
            this.Num2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTinhTong
            // 
            this.btnTinhTong.Location = new System.Drawing.Point(107, 124);
            this.btnTinhTong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTinhTong.Name = "btnTinhTong";
            this.btnTinhTong.Size = new System.Drawing.Size(85, 19);
            this.btnTinhTong.TabIndex = 0;
            this.btnTinhTong.Text = "Tính";
            this.btnTinhTong.UseVisualStyleBackColor = true;
            this.btnTinhTong.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtSo1
            // 
            this.txtSo1.Location = new System.Drawing.Point(197, 55);
            this.txtSo1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSo1.Name = "txtSo1";
            this.txtSo1.Size = new System.Drawing.Size(108, 20);
            this.txtSo1.TabIndex = 1;
            this.txtSo1.TextChanged += new System.EventHandler(this.txtSo1_TextChanged);
            // 
            // txtSo2
            // 
            this.txtSo2.Location = new System.Drawing.Point(197, 84);
            this.txtSo2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSo2.Name = "txtSo2";
            this.txtSo2.Size = new System.Drawing.Size(108, 20);
            this.txtSo2.TabIndex = 2;
            // 
            // txtKetQua
            // 
            this.txtKetQua.Location = new System.Drawing.Point(197, 159);
            this.txtKetQua.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.ReadOnly = true;
            this.txtKetQua.Size = new System.Drawing.Size(108, 20);
            this.txtKetQua.TabIndex = 3;
            this.txtKetQua.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // num1
            // 
            this.num1.Location = new System.Drawing.Point(105, 57);
            this.num1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.num1.Name = "num1";
            this.num1.Size = new System.Drawing.Size(87, 19);
            this.num1.TabIndex = 5;
            this.num1.Text = "Số thứ nhất";
            this.num1.Click += new System.EventHandler(this.label2_Click);
            // 
            // Num2
            // 
            this.Num2.Location = new System.Drawing.Point(105, 87);
            this.Num2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Num2.Name = "Num2";
            this.Num2.Size = new System.Drawing.Size(60, 20);
            this.Num2.TabIndex = 6;
            this.Num2.Text = "Số thứ hai";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Kết Quả";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Num2);
            this.Controls.Add(this.num1);
            this.Controls.Add(this.txtKetQua);
            this.Controls.Add(this.txtSo2);
            this.Controls.Add(this.txtSo1);
            this.Controls.Add(this.btnTinhTong);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private Button btnTinhTong;

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int so1 = int.Parse(txtSo1.Text.Trim());
                int so2 = int.Parse(txtSo2.Text.Trim());
                int tong = so1 + so2;
                txtKetQua.Text = tong.ToString();
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TextBox txtSo1;
        private TextBox txtSo2;
        private TextBox txtKetQua;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private Label num1;
        private Label Num2;

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private Label label3;

        private void txtSo1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
