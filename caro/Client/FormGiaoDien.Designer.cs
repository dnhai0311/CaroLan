namespace Client
{
    partial class frmGiaoDien
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
            this.pbGiaoDien = new System.Windows.Forms.PictureBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.btnMo = new System.Windows.Forms.Button();
            this.btnBanCo = new System.Windows.Forms.Button();
            this.btnX = new System.Windows.Forms.Button();
            this.btnXVang = new System.Windows.Forms.Button();
            this.btnO = new System.Windows.Forms.Button();
            this.btnOVang = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbGiaoDien)).BeginInit();
            this.SuspendLayout();
            // 
            // pbGiaoDien
            // 
            this.pbGiaoDien.Location = new System.Drawing.Point(23, 50);
            this.pbGiaoDien.Name = "pbGiaoDien";
            this.pbGiaoDien.Size = new System.Drawing.Size(316, 268);
            this.pbGiaoDien.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGiaoDien.TabIndex = 0;
            this.pbGiaoDien.TabStop = false;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(23, 12);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(235, 20);
            this.txtDiaChi.TabIndex = 1;
            // 
            // btnMo
            // 
            this.btnMo.Location = new System.Drawing.Point(264, 12);
            this.btnMo.Name = "btnMo";
            this.btnMo.Size = new System.Drawing.Size(75, 23);
            this.btnMo.TabIndex = 2;
            this.btnMo.Text = "Mở";
            this.btnMo.UseVisualStyleBackColor = true;
            this.btnMo.Click += new System.EventHandler(this.btnMo_Click);
            // 
            // btnBanCo
            // 
            this.btnBanCo.Location = new System.Drawing.Point(369, 81);
            this.btnBanCo.Name = "btnBanCo";
            this.btnBanCo.Size = new System.Drawing.Size(147, 23);
            this.btnBanCo.TabIndex = 3;
            this.btnBanCo.Text = "Thay đổi bàn cờ";
            this.btnBanCo.UseVisualStyleBackColor = true;
            this.btnBanCo.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnX
            // 
            this.btnX.Location = new System.Drawing.Point(369, 123);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(147, 23);
            this.btnX.TabIndex = 3;
            this.btnX.Text = "Thay đổi quân cờ X";
            this.btnX.UseVisualStyleBackColor = true;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // btnXVang
            // 
            this.btnXVang.Location = new System.Drawing.Point(369, 166);
            this.btnXVang.Name = "btnXVang";
            this.btnXVang.Size = new System.Drawing.Size(147, 23);
            this.btnXVang.TabIndex = 3;
            this.btnXVang.Text = "Thay đổi quân cờ X vàng";
            this.btnXVang.UseVisualStyleBackColor = true;
            this.btnXVang.Click += new System.EventHandler(this.btnXVang_Click);
            // 
            // btnO
            // 
            this.btnO.Location = new System.Drawing.Point(369, 212);
            this.btnO.Name = "btnO";
            this.btnO.Size = new System.Drawing.Size(147, 23);
            this.btnO.TabIndex = 3;
            this.btnO.Text = "Thay đổi quân cờ O";
            this.btnO.UseVisualStyleBackColor = true;
            this.btnO.Click += new System.EventHandler(this.btnO_Click);
            // 
            // btnOVang
            // 
            this.btnOVang.Location = new System.Drawing.Point(369, 254);
            this.btnOVang.Name = "btnOVang";
            this.btnOVang.Size = new System.Drawing.Size(147, 23);
            this.btnOVang.TabIndex = 3;
            this.btnOVang.Text = "Thay đổi quân cờ O vàng";
            this.btnOVang.UseVisualStyleBackColor = true;
            this.btnOVang.Click += new System.EventHandler(this.btnOVang_Click);
            // 
            // frmGiaoDien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 339);
            this.Controls.Add(this.btnOVang);
            this.Controls.Add(this.btnO);
            this.Controls.Add(this.btnXVang);
            this.Controls.Add(this.btnX);
            this.Controls.Add(this.btnBanCo);
            this.Controls.Add(this.btnMo);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.pbGiaoDien);
            this.Name = "frmGiaoDien";
            this.Text = "FormGiaoDien";
            ((System.ComponentModel.ISupportInitialize)(this.pbGiaoDien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGiaoDien;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Button btnMo;
        private System.Windows.Forms.Button btnBanCo;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Button btnXVang;
        private System.Windows.Forms.Button btnO;
        private System.Windows.Forms.Button btnOVang;
    }
}