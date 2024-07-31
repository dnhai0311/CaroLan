namespace Client
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.rdbtnOtherIp = new System.Windows.Forms.RadioButton();
            this.rdbtnLocalhost = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDesiredName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGiaoDien = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.txtIp);
            this.groupBox1.Controls.Add(this.rdbtnOtherIp);
            this.groupBox1.Controls.Add(this.rdbtnLocalhost);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kết nối server";
            // 
            // txtIp
            // 
            this.txtIp.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtIp.Enabled = false;
            this.txtIp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtIp.Location = new System.Drawing.Point(90, 43);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(87, 20);
            this.txtIp.TabIndex = 2;
            this.txtIp.Text = "Nhập IP";
            // 
            // rdbtnOtherIp
            // 
            this.rdbtnOtherIp.AutoSize = true;
            this.rdbtnOtherIp.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rdbtnOtherIp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rdbtnOtherIp.Location = new System.Drawing.Point(7, 44);
            this.rdbtnOtherIp.Name = "rdbtnOtherIp";
            this.rdbtnOtherIp.Size = new System.Drawing.Size(77, 17);
            this.rdbtnOtherIp.TabIndex = 1;
            this.rdbtnOtherIp.Text = "Vào phòng";
            this.rdbtnOtherIp.UseVisualStyleBackColor = false;
            this.rdbtnOtherIp.CheckedChanged += new System.EventHandler(this.rdbtnOtherIp_CheckedChanged);
            // 
            // rdbtnLocalhost
            // 
            this.rdbtnLocalhost.AutoSize = true;
            this.rdbtnLocalhost.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rdbtnLocalhost.Checked = true;
            this.rdbtnLocalhost.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rdbtnLocalhost.Location = new System.Drawing.Point(7, 20);
            this.rdbtnLocalhost.Name = "rdbtnLocalhost";
            this.rdbtnLocalhost.Size = new System.Drawing.Size(77, 17);
            this.rdbtnLocalhost.TabIndex = 0;
            this.rdbtnLocalhost.TabStop = true;
            this.rdbtnLocalhost.Text = "Tạo phòng";
            this.rdbtnLocalhost.UseVisualStyleBackColor = false;
            this.rdbtnLocalhost.CheckedChanged += new System.EventHandler(this.rdbtnLocalhost_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Controls.Add(this.txtDesiredName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox2.Location = new System.Drawing.Point(13, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 57);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // txtDesiredName
            // 
            this.txtDesiredName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtDesiredName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtDesiredName.Location = new System.Drawing.Point(90, 17);
            this.txtDesiredName.Name = "txtDesiredName";
            this.txtDesiredName.Size = new System.Drawing.Size(87, 20);
            this.txtDesiredName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên người chơi";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnOk.Location = new System.Drawing.Point(31, 164);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancel.Location = new System.Drawing.Point(112, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGiaoDien
            // 
            this.btnGiaoDien.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGiaoDien.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGiaoDien.Location = new System.Drawing.Point(73, 194);
            this.btnGiaoDien.Name = "btnGiaoDien";
            this.btnGiaoDien.Size = new System.Drawing.Size(75, 23);
            this.btnGiaoDien.TabIndex = 27;
            this.btnGiaoDien.Text = "Giao diện";
            this.btnGiaoDien.UseVisualStyleBackColor = false;
            this.btnGiaoDien.Click += new System.EventHandler(this.btnGiaoDien_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(216, 229);
            this.Controls.Add(this.btnGiaoDien);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.Text = "SignIn";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.RadioButton rdbtnOtherIp;
        private System.Windows.Forms.RadioButton rdbtnLocalhost;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDesiredName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGiaoDien;
    }
}