namespace QQLogin
{
    partial class QQLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QQLogin));
            this.hotPanel1 = new HotTaoControls.HotPanel();
            this.picQQ = new System.Windows.Forms.PictureBox();
            this.lbMsg = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picQrcode = new System.Windows.Forms.PictureBox();
            this.hotPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQrcode)).BeginInit();
            this.SuspendLayout();
            // 
            // hotPanel1
            // 
            this.hotPanel1.BackColor = System.Drawing.Color.White;
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Controls.Add(this.picQQ);
            this.hotPanel1.Controls.Add(this.lbMsg);
            this.hotPanel1.Controls.Add(this.label3);
            this.hotPanel1.Controls.Add(this.label1);
            this.hotPanel1.Controls.Add(this.picClose);
            this.hotPanel1.Controls.Add(this.picQrcode);
            this.hotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel1.Location = new System.Drawing.Point(0, 0);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(241, 340);
            this.hotPanel1.TabIndex = 1;
            this.hotPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.hotPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.hotPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // picQQ
            // 
            this.picQQ.BackColor = System.Drawing.Color.Transparent;
            this.picQQ.Image = global::QQLogin.Properties.Resources.qq50x50;
            this.picQQ.Location = new System.Drawing.Point(108, 176);
            this.picQQ.Name = "picQQ";
            this.picQQ.Size = new System.Drawing.Size(25, 25);
            this.picQQ.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQQ.TabIndex = 4;
            this.picQQ.TabStop = false;
            this.picQQ.Visible = false;
            // 
            // lbMsg
            // 
            this.lbMsg.Location = new System.Drawing.Point(1, 302);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(239, 12);
            this.lbMsg.TabIndex = 3;
            this.lbMsg.Text = "使用QQ手机版扫描二维码";
            this.lbMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.label3.Location = new System.Drawing.Point(51, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "安全登录防止盗号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "登录 Smart QQ";
            // 
            // picClose
            // 
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::QQLogin.Properties.Resources.icon_close1;
            this.picClose.Location = new System.Drawing.Point(213, 7);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(20, 20);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 1;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // picQrcode
            // 
            this.picQrcode.Image = global::QQLogin.Properties.Resources.loading;
            this.picQrcode.Location = new System.Drawing.Point(29, 97);
            this.picQrcode.Name = "picQrcode";
            this.picQrcode.Size = new System.Drawing.Size(184, 184);
            this.picQrcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picQrcode.TabIndex = 0;
            this.picQrcode.TabStop = false;
            this.picQrcode.Click += new System.EventHandler(this.lbRefreshQrCode_Click);
            this.picQrcode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.picQrcode.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.picQrcode.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // QQLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 340);
            this.Controls.Add(this.hotPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QQLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.hotPanel1.ResumeLayout(false);
            this.hotPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQrcode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picQrcode;
        private HotTaoControls.HotPanel hotPanel1;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picQQ;
    }
}

