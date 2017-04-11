namespace HotTaoMonitoring
{
    partial class MyInfoForm
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
            this.hotPanel1 = new HotTaoMonitoring.module.HotPanel(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbSwitchWeChat = new System.Windows.Forms.Label();
            this.lbLogout = new System.Windows.Forms.Label();
            this.lbKefu = new System.Windows.Forms.Label();
            this.picWeChatImage = new System.Windows.Forms.PictureBox();
            this.lbWeChatTitle = new System.Windows.Forms.Label();
            this.hotPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWeChatImage)).BeginInit();
            this.SuspendLayout();
            // 
            // hotPanel1
            // 
            this.hotPanel1.BackColor = System.Drawing.Color.White;
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Controls.Add(this.label1);
            this.hotPanel1.Controls.Add(this.panel1);
            this.hotPanel1.Controls.Add(this.lbSwitchWeChat);
            this.hotPanel1.Controls.Add(this.lbLogout);
            this.hotPanel1.Controls.Add(this.lbKefu);
            this.hotPanel1.Controls.Add(this.picWeChatImage);
            this.hotPanel1.Controls.Add(this.lbWeChatTitle);
            this.hotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel1.Location = new System.Drawing.Point(0, 0);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(295, 230);
            this.hotPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label1.Location = new System.Drawing.Point(37, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "账户：";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel1.Location = new System.Drawing.Point(26, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 1);
            this.panel1.TabIndex = 7;
            // 
            // lbSwitchWeChat
            // 
            this.lbSwitchWeChat.AutoSize = true;
            this.lbSwitchWeChat.BackColor = System.Drawing.Color.Transparent;
            this.lbSwitchWeChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbSwitchWeChat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.lbSwitchWeChat.Location = new System.Drawing.Point(171, 193);
            this.lbSwitchWeChat.Name = "lbSwitchWeChat";
            this.lbSwitchWeChat.Size = new System.Drawing.Size(53, 12);
            this.lbSwitchWeChat.TabIndex = 3;
            this.lbSwitchWeChat.Text = "切换微信";
            this.lbSwitchWeChat.Click += new System.EventHandler(this.lbSwitchWeChat_Click);
            // 
            // lbLogout
            // 
            this.lbLogout.AutoSize = true;
            this.lbLogout.BackColor = System.Drawing.Color.Transparent;
            this.lbLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.lbLogout.Location = new System.Drawing.Point(232, 193);
            this.lbLogout.Name = "lbLogout";
            this.lbLogout.Size = new System.Drawing.Size(53, 12);
            this.lbLogout.TabIndex = 3;
            this.lbLogout.Text = "切换账户";
            this.lbLogout.Click += new System.EventHandler(this.lbLogout_Click);
            // 
            // lbKefu
            // 
            this.lbKefu.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbKefu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.lbKefu.Location = new System.Drawing.Point(89, 124);
            this.lbKefu.Name = "lbKefu";
            this.lbKefu.Size = new System.Drawing.Size(180, 18);
            this.lbKefu.TabIndex = 2;
            this.lbKefu.Text = "kefu001";
            this.lbKefu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picWeChatImage
            // 
            this.picWeChatImage.Location = new System.Drawing.Point(206, 26);
            this.picWeChatImage.Name = "picWeChatImage";
            this.picWeChatImage.Size = new System.Drawing.Size(55, 55);
            this.picWeChatImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWeChatImage.TabIndex = 1;
            this.picWeChatImage.TabStop = false;
            // 
            // lbWeChatTitle
            // 
            this.lbWeChatTitle.Font = new System.Drawing.Font("Meiryo UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbWeChatTitle.Location = new System.Drawing.Point(35, 34);
            this.lbWeChatTitle.Name = "lbWeChatTitle";
            this.lbWeChatTitle.Size = new System.Drawing.Size(166, 33);
            this.lbWeChatTitle.TabIndex = 0;
            this.lbWeChatTitle.Text = "天猫小爱";
            this.lbWeChatTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MyInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 230);
            this.Controls.Add(this.hotPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MyInfoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MyInfoForm";
            this.Load += new System.EventHandler(this.MyInfoForm_Load);
            this.hotPanel1.ResumeLayout(false);
            this.hotPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWeChatImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private module.HotPanel hotPanel1;
        private System.Windows.Forms.Label lbWeChatTitle;
        private System.Windows.Forms.PictureBox picWeChatImage;
        private System.Windows.Forms.Label lbKefu;
        private System.Windows.Forms.Label lbLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbSwitchWeChat;
    }
}