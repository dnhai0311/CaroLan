namespace Client
{
    partial class frmChat
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChat));
            this.lbChatVoi = new System.Windows.Forms.Label();
            this.txtChatWith = new System.Windows.Forms.TextBox();
            this.txtChatDisplay = new System.Windows.Forms.TextBox();
            this.txtChatInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.BanCo = new System.Windows.Forms.PictureBox();
            this.OK = new System.Windows.Forms.Button();
            this.lbChonDoiThu = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbEnemyName = new System.Windows.Forms.Label();
            this.lbEnemyWin = new System.Windows.Forms.Label();
            this.lbWin = new System.Windows.Forms.Label();
            this.lbCaption = new System.Windows.Forms.Label();
            this.cbListUser = new System.Windows.Forms.ComboBox();
            this.TG = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbTG = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTimePlay = new System.Windows.Forms.Label();
            this.pbMoon = new System.Windows.Forms.PictureBox();
            this.btnTaiLai = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BanCo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMoon)).BeginInit();
            this.SuspendLayout();
            // 
            // lbChatVoi
            // 
            this.lbChatVoi.AutoSize = true;
            this.lbChatVoi.BackColor = System.Drawing.SystemColors.Window;
            this.lbChatVoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChatVoi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbChatVoi.Location = new System.Drawing.Point(602, 261);
            this.lbChatVoi.Name = "lbChatVoi";
            this.lbChatVoi.Size = new System.Drawing.Size(66, 18);
            this.lbChatVoi.TabIndex = 0;
            this.lbChatVoi.Text = "Chat với:";
            // 
            // txtChatWith
            // 
            this.txtChatWith.Location = new System.Drawing.Point(668, 261);
            this.txtChatWith.Name = "txtChatWith";
            this.txtChatWith.Size = new System.Drawing.Size(185, 20);
            this.txtChatWith.TabIndex = 1;
            // 
            // txtChatDisplay
            // 
            this.txtChatDisplay.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtChatDisplay.Location = new System.Drawing.Point(601, 287);
            this.txtChatDisplay.Multiline = true;
            this.txtChatDisplay.Name = "txtChatDisplay";
            this.txtChatDisplay.ReadOnly = true;
            this.txtChatDisplay.Size = new System.Drawing.Size(255, 177);
            this.txtChatDisplay.TabIndex = 2;
            // 
            // txtChatInput
            // 
            this.txtChatInput.Location = new System.Drawing.Point(601, 470);
            this.txtChatInput.Multiline = true;
            this.txtChatInput.Name = "txtChatInput";
            this.txtChatInput.Size = new System.Drawing.Size(195, 46);
            this.txtChatInput.TabIndex = 3;
            this.txtChatInput.TextChanged += new System.EventHandler(this.txtChatInput_TextChanged);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(804, 470);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(54, 46);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // BanCo
            // 
            this.BanCo.Location = new System.Drawing.Point(11, 36);
            this.BanCo.Name = "BanCo";
            this.BanCo.Size = new System.Drawing.Size(578, 577);
            this.BanCo.TabIndex = 5;
            this.BanCo.TabStop = false;
            this.BanCo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.banco_OnMouseClick);
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.OK.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.OK.Location = new System.Drawing.Point(385, 6);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 24);
            this.OK.TabIndex = 6;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = false;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // lbChonDoiThu
            // 
            this.lbChonDoiThu.AutoSize = true;
            this.lbChonDoiThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChonDoiThu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbChonDoiThu.Location = new System.Drawing.Point(142, 8);
            this.lbChonDoiThu.Name = "lbChonDoiThu";
            this.lbChonDoiThu.Size = new System.Drawing.Size(96, 18);
            this.lbChonDoiThu.TabIndex = 8;
            this.lbChonDoiThu.Text = "Chọn đối thủ:";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbName.Location = new System.Drawing.Point(652, 168);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(42, 15);
            this.lbName.TabIndex = 9;
            this.lbName.Text = "A++++";
            // 
            // lbEnemyName
            // 
            this.lbEnemyName.AutoSize = true;
            this.lbEnemyName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbEnemyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEnemyName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbEnemyName.Location = new System.Drawing.Point(652, 211);
            this.lbEnemyName.Name = "lbEnemyName";
            this.lbEnemyName.Size = new System.Drawing.Size(42, 15);
            this.lbEnemyName.TabIndex = 10;
            this.lbEnemyName.Text = "A++++";
            // 
            // lbEnemyWin
            // 
            this.lbEnemyWin.AutoSize = true;
            this.lbEnemyWin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbEnemyWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEnemyWin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbEnemyWin.Location = new System.Drawing.Point(770, 211);
            this.lbEnemyWin.Name = "lbEnemyWin";
            this.lbEnemyWin.Size = new System.Drawing.Size(42, 15);
            this.lbEnemyWin.TabIndex = 11;
            this.lbEnemyWin.Text = "A++++";
            // 
            // lbWin
            // 
            this.lbWin.AutoSize = true;
            this.lbWin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbWin.Location = new System.Drawing.Point(770, 168);
            this.lbWin.Name = "lbWin";
            this.lbWin.Size = new System.Drawing.Size(42, 15);
            this.lbWin.TabIndex = 12;
            this.lbWin.Text = "A++++";
            // 
            // lbCaption
            // 
            this.lbCaption.AutoSize = true;
            this.lbCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbCaption.Location = new System.Drawing.Point(620, 36);
            this.lbCaption.Name = "lbCaption";
            this.lbCaption.Size = new System.Drawing.Size(218, 29);
            this.lbCaption.TabIndex = 13;
            this.lbCaption.Text = "CaroLanWithLove";
            // 
            // cbListUser
            // 
            this.cbListUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbListUser.FormattingEnabled = true;
            this.cbListUser.Location = new System.Drawing.Point(244, 6);
            this.cbListUser.Name = "cbListUser";
            this.cbListUser.Size = new System.Drawing.Size(135, 24);
            this.cbListUser.TabIndex = 16;
            this.cbListUser.SelectedIndexChanged += new System.EventHandler(this.cbListUser_SelectedIndexChanged);
            this.cbListUser.Click += new System.EventHandler(this.comboBox1_oneClick);
            // 
            // TG
            // 
            this.TG.AutoSize = true;
            this.TG.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TG.ForeColor = System.Drawing.Color.Lime;
            this.TG.Location = new System.Drawing.Point(706, 114);
            this.TG.Name = "TG";
            this.TG.Size = new System.Drawing.Size(59, 31);
            this.TG.TabIndex = 17;
            this.TG.Text = "120";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbTime.Location = new System.Drawing.Point(677, 77);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(114, 25);
            this.lbTime.TabIndex = 18;
            this.lbTime.Text = "Thời Gian";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // lbTG
            // 
            this.lbTG.AutoSize = true;
            this.lbTG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTG.Location = new System.Drawing.Point(602, 598);
            this.lbTG.Name = "lbTG";
            this.lbTG.Size = new System.Drawing.Size(149, 17);
            this.lbTG.TabIndex = 19;
            this.lbTG.Text = "Thời gian bạn đã chơi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(719, 598);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 20;
            // 
            // lbTimePlay
            // 
            this.lbTimePlay.AutoSize = true;
            this.lbTimePlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimePlay.Location = new System.Drawing.Point(757, 598);
            this.lbTimePlay.Name = "lbTimePlay";
            this.lbTimePlay.Size = new System.Drawing.Size(16, 17);
            this.lbTimePlay.TabIndex = 21;
            this.lbTimePlay.Text = "0";
            // 
            // pbMoon
            // 
            this.pbMoon.Image = ((System.Drawing.Image)(resources.GetObject("pbMoon.Image")));
            this.pbMoon.Location = new System.Drawing.Point(601, 522);
            this.pbMoon.Name = "pbMoon";
            this.pbMoon.Size = new System.Drawing.Size(49, 48);
            this.pbMoon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMoon.TabIndex = 23;
            this.pbMoon.TabStop = false;
            this.pbMoon.Click += new System.EventHandler(this.pbMoon_Click);
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.BackColor = System.Drawing.Color.White;
            this.btnTaiLai.Location = new System.Drawing.Point(514, 6);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(75, 23);
            this.btnTaiLai.TabIndex = 25;
            this.btnTaiLai.Text = "Tải lại";
            this.btnTaiLai.UseVisualStyleBackColor = false;
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // frmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(865, 624);
            this.Controls.Add(this.btnTaiLai);
            this.Controls.Add(this.pbMoon);
            this.Controls.Add(this.lbTimePlay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbTG);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.TG);
            this.Controls.Add(this.cbListUser);
            this.Controls.Add(this.lbCaption);
            this.Controls.Add(this.lbWin);
            this.Controls.Add(this.lbEnemyWin);
            this.Controls.Add(this.lbEnemyName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbChonDoiThu);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.BanCo);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtChatInput);
            this.Controls.Add(this.txtChatDisplay);
            this.Controls.Add(this.txtChatWith);
            this.Controls.Add(this.lbChatVoi);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormChat";
            this.Load += new System.EventHandler(this.FormChat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BanCo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMoon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbChatVoi;
        private System.Windows.Forms.TextBox txtChatWith;
        private System.Windows.Forms.TextBox txtChatDisplay;
        private System.Windows.Forms.TextBox txtChatInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.PictureBox BanCo;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Label lbChonDoiThu;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbEnemyName;
        private System.Windows.Forms.Label lbEnemyWin;
        private System.Windows.Forms.Label lbWin;
        private System.Windows.Forms.Label lbCaption;
        private System.Windows.Forms.ComboBox cbListUser;
        private System.Windows.Forms.Label TG;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbTG;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbTimePlay;
        private System.Windows.Forms.PictureBox pbMoon;
        private System.Windows.Forms.Button btnTaiLai;
    }
}