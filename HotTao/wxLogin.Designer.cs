namespace HotTao
{
    partial class wxLogin
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
            this.linkReturn = new System.Windows.Forms.LinkLabel();
            this.lblTip = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picQRCode = new System.Windows.Forms.PictureBox();
            this.hotBg = new HotTao.Controls.module.HotPanel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // linkReturn
            // 
            this.linkReturn.AutoSize = true;
            this.linkReturn.BackColor = System.Drawing.Color.Transparent;
            this.linkReturn.ForeColor = System.Drawing.Color.Transparent;
            this.linkReturn.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkReturn.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.linkReturn.Location = new System.Drawing.Point(94, 342);
            this.linkReturn.Name = "linkReturn";
            this.linkReturn.Size = new System.Drawing.Size(89, 12);
            this.linkReturn.TabIndex = 13;
            this.linkReturn.TabStop = true;
            this.linkReturn.Text = "返回二维码界面";
            this.linkReturn.Visible = false;
            this.linkReturn.VisitedLinkColor = System.Drawing.Color.Teal;
            this.linkReturn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkReturn_LinkClicked);
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTip.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblTip.Location = new System.Drawing.Point(65, 306);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(149, 20);
            this.lblTip.TabIndex = 12;
            this.lblTip.Text = "手机微信扫一扫以登录";
            this.lblTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "微信";
            // 
            // picClose
            // 
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::HotTao.Properties.Resources.icon_close1;
            this.picClose.Location = new System.Drawing.Point(256, 8);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(20, 20);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 14;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // picQRCode
            // 
            this.picQRCode.Location = new System.Drawing.Point(42, 73);
            this.picQRCode.Name = "picQRCode";
            this.picQRCode.Size = new System.Drawing.Size(200, 200);
            this.picQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQRCode.TabIndex = 10;
            this.picQRCode.TabStop = false;
            // 
            // hotBg
            // 
            this.hotBg.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.hotBg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotBg.Location = new System.Drawing.Point(0, 0);
            this.hotBg.Name = "hotBg";
            this.hotBg.Size = new System.Drawing.Size(284, 402);
            this.hotBg.TabIndex = 15;
            this.hotBg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.hotBg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.hotBg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // wxLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(284, 402);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.linkReturn);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picQRCode);
            this.Controls.Add(this.hotBg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "wxLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "微信登录";
            this.Load += new System.EventHandler(this.wxLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.LinkLabel linkReturn;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picQRCode;
        private Controls.module.HotPanel hotBg;
    }
}