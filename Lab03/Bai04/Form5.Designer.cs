using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lab02
{
    partial class Form5
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
            this.btnDocFile = new System.Windows.Forms.Button();
            this.btnXuatThongKe = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dgvPhim = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhim)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDocFile
            // 
            this.btnDocFile.Location = new System.Drawing.Point(43, 275);
            this.btnDocFile.Name = "btnDocFile";
            this.btnDocFile.Size = new System.Drawing.Size(250, 61);
            this.btnDocFile.TabIndex = 0;
            this.btnDocFile.Text = "Đọc File";
            this.btnDocFile.UseVisualStyleBackColor = true;
            this.btnDocFile.Click += new System.EventHandler(this.BtnDocFile_Click);
            // 
            // btnXuatThongKe
            // 
            this.btnXuatThongKe.Location = new System.Drawing.Point(43, 354);
            this.btnXuatThongKe.Name = "btnXuatThongKe";
            this.btnXuatThongKe.Size = new System.Drawing.Size(250, 61);
            this.btnXuatThongKe.TabIndex = 1;
            this.btnXuatThongKe.Text = "Xuất ";
            this.btnXuatThongKe.UseVisualStyleBackColor = true;
            this.btnXuatThongKe.Click += new System.EventHandler(this.btnXuatThongKe_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(381, 290);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(373, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // dgvPhim
            // 
            this.dgvPhim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhim.Location = new System.Drawing.Point(43, 12);
            this.dgvPhim.Name = "dgvPhim";
            this.dgvPhim.RowHeadersWidth = 51;
            this.dgvPhim.RowTemplate.Height = 24;
            this.dgvPhim.Size = new System.Drawing.Size(745, 227);
            this.dgvPhim.TabIndex = 3;
            this.dgvPhim.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhim_CellContentClick);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvPhim);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnXuatThongKe);
            this.Controls.Add(this.btnDocFile);
            this.Name = "Form5";
            this.Text = "23521308 - Phạm Tấn Gia Quốc - Form 5";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDocFile;
        private System.Windows.Forms.Button btnXuatThongKe;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView dgvPhim;





    }
}

