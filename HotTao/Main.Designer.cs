namespace HotTao
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.HotContainer = new System.Windows.Forms.SplitContainer();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.pbMin = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCustomService = new System.Windows.Forms.PictureBox();
            this.panelHelp = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pbHelp = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSetting = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnHistory = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnWeChat = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.toolTipText = new System.Windows.Forms.ToolTip(this.components);
            this.hotPanel1 = new HotTao.Controls.module.HotPanel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.HotContainer)).BeginInit();
            this.HotContainer.Panel1.SuspendLayout();
            this.HotContainer.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCustomService)).BeginInit();
            this.panelHelp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSetting)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHistory)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnWeChat)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.hotPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // HotContainer
            // 
            this.HotContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HotContainer.IsSplitterFixed = true;
            this.HotContainer.Location = new System.Drawing.Point(0, 0);
            this.HotContainer.Margin = new System.Windows.Forms.Padding(0);
            this.HotContainer.Name = "HotContainer";
            this.HotContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // HotContainer.Panel1
            // 
            this.HotContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(108)))), ((int)(((byte)(172)))));
            this.HotContainer.Panel1.Controls.Add(this.panel7);
            this.HotContainer.Panel1.Controls.Add(this.panel6);
            this.HotContainer.Panel1.Controls.Add(this.panelHelp);
            this.HotContainer.Panel1.Controls.Add(this.panel4);
            this.HotContainer.Panel1.Controls.Add(this.panel3);
            this.HotContainer.Panel1.Controls.Add(this.panel2);
            this.HotContainer.Panel1.Controls.Add(this.panel1);
            this.HotContainer.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.HotContainer.Panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.HotContainer.Panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            this.HotContainer.Panel1MinSize = 0;
            // 
            // HotContainer.Panel2
            // 
            this.HotContainer.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.HotContainer.Panel2MinSize = 0;
            this.HotContainer.Size = new System.Drawing.Size(920, 720);
            this.HotContainer.SplitterDistance = 109;
            this.HotContainer.SplitterWidth = 1;
            this.HotContainer.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Controls.Add(this.pictureBox3);
            this.panel7.Controls.Add(this.pbClose);
            this.panel7.Controls.Add(this.pbMin);
            this.panel7.Location = new System.Drawing.Point(818, 6);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(97, 25);
            this.panel7.TabIndex = 6;
            this.panel7.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::HotTao.Properties.Resources.icon_menu;
            this.pictureBox3.Location = new System.Drawing.Point(28, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(13, 13);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            this.toolTipText.SetToolTip(this.pictureBox3, "菜单");
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pbClose
            // 
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = global::HotTao.Properties.Resources.icon_close;
            this.pbClose.Location = new System.Drawing.Point(82, 3);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(13, 13);
            this.pbClose.TabIndex = 5;
            this.pbClose.TabStop = false;
            this.toolTipText.SetToolTip(this.pbClose, "关闭");
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // pbMin
            // 
            this.pbMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMin.Image = global::HotTao.Properties.Resources.icon_min;
            this.pbMin.Location = new System.Drawing.Point(55, 3);
            this.pbMin.Name = "pbMin";
            this.pbMin.Size = new System.Drawing.Size(13, 13);
            this.pbMin.TabIndex = 3;
            this.pbMin.TabStop = false;
            this.toolTipText.SetToolTip(this.pbMin, "最小化");
            this.pbMin.Click += new System.EventHandler(this.pbMin_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(108)))), ((int)(((byte)(172)))));
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.btnCustomService);
            this.panel6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel6.Location = new System.Drawing.Point(424, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(83, 113);
            this.panel6.TabIndex = 2;
            this.panel6.Visible = false;
            this.panel6.Click += new System.EventHandler(this.btnCustomService_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(26, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "客服";
            // 
            // btnCustomService
            // 
            this.btnCustomService.BackColor = System.Drawing.Color.Transparent;
            this.btnCustomService.Image = global::HotTao.Properties.Resources.icon_06;
            this.btnCustomService.Location = new System.Drawing.Point(16, 25);
            this.btnCustomService.Name = "btnCustomService";
            this.btnCustomService.Size = new System.Drawing.Size(50, 50);
            this.btnCustomService.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCustomService.TabIndex = 0;
            this.btnCustomService.TabStop = false;
            this.toolTipText.SetToolTip(this.btnCustomService, "客服");
            this.btnCustomService.Click += new System.EventHandler(this.btnCustomService_Click);
            // 
            // panelHelp
            // 
            this.panelHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(108)))), ((int)(((byte)(172)))));
            this.panelHelp.Controls.Add(this.label5);
            this.panelHelp.Controls.Add(this.pbHelp);
            this.panelHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelHelp.Location = new System.Drawing.Point(524, 0);
            this.panelHelp.Name = "panelHelp";
            this.panelHelp.Size = new System.Drawing.Size(83, 113);
            this.panelHelp.TabIndex = 1;
            this.panelHelp.Visible = false;
            this.panelHelp.Click += new System.EventHandler(this.pbHelp_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(23, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "QQ采集";
            this.label5.Click += new System.EventHandler(this.pbHelp_Click);
            // 
            // pbHelp
            // 
            this.pbHelp.BackColor = System.Drawing.Color.Transparent;
            this.pbHelp.Image = global::HotTao.Properties.Resources.qq50x50;
            this.pbHelp.Location = new System.Drawing.Point(16, 25);
            this.pbHelp.Name = "pbHelp";
            this.pbHelp.Size = new System.Drawing.Size(50, 50);
            this.pbHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHelp.TabIndex = 0;
            this.pbHelp.TabStop = false;
            this.toolTipText.SetToolTip(this.pbHelp, "QQ采集");
            this.pbHelp.Click += new System.EventHandler(this.pbHelp_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(108)))), ((int)(((byte)(172)))));
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.btnSetting);
            this.panel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel4.Location = new System.Drawing.Point(324, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(83, 113);
            this.panel4.TabIndex = 1;
            this.panel4.Visible = false;
            this.panel4.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(15, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "软件配置";
            this.label4.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.Transparent;
            this.btnSetting.Image = global::HotTao.Properties.Resources.icon_04;
            this.btnSetting.Location = new System.Drawing.Point(16, 25);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(50, 50);
            this.btnSetting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSetting.TabIndex = 0;
            this.btnSetting.TabStop = false;
            this.toolTipText.SetToolTip(this.btnSetting, "软件配置");
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(108)))), ((int)(((byte)(172)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btnHistory);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Location = new System.Drawing.Point(224, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(83, 113);
            this.panel3.TabIndex = 1;
            this.panel3.Visible = false;
            this.panel3.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "运行日志";
            this.label3.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.BackColor = System.Drawing.Color.Transparent;
            this.btnHistory.Image = global::HotTao.Properties.Resources.icon_03;
            this.btnHistory.Location = new System.Drawing.Point(16, 25);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(50, 50);
            this.btnHistory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnHistory.TabIndex = 0;
            this.btnHistory.TabStop = false;
            this.toolTipText.SetToolTip(this.btnHistory, "计划列表");
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(108)))), ((int)(((byte)(172)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnWeChat);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Location = new System.Drawing.Point(124, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(83, 113);
            this.panel2.TabIndex = 1;
            this.panel2.Visible = false;
            this.panel2.Click += new System.EventHandler(this.btnWeChat_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "微信群发";
            this.label2.Click += new System.EventHandler(this.btnWeChat_Click);
            // 
            // btnWeChat
            // 
            this.btnWeChat.BackColor = System.Drawing.Color.Transparent;
            this.btnWeChat.Image = global::HotTao.Properties.Resources.icon_02;
            this.btnWeChat.Location = new System.Drawing.Point(16, 25);
            this.btnWeChat.Name = "btnWeChat";
            this.btnWeChat.Size = new System.Drawing.Size(50, 50);
            this.btnWeChat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnWeChat.TabIndex = 0;
            this.btnWeChat.TabStop = false;
            this.toolTipText.SetToolTip(this.btnWeChat, "微信群发");
            this.btnWeChat.Click += new System.EventHandler(this.btnWeChat_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::HotTao.Properties.Resources.icon_bg;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(24, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(83, 113);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            this.panel1.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "商品库";
            this.label1.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnHome
            // 
            this.btnHome.Image = global::HotTao.Properties.Resources.icon_01;
            this.btnHome.Location = new System.Drawing.Point(16, 25);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(50, 50);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnHome.TabIndex = 0;
            this.btnHome.TabStop = false;
            this.btnHome.Tag = "";
            this.toolTipText.SetToolTip(this.btnHome, "商品库");
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // hotPanel1
            // 
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Controls.Add(this.HotContainer);
            this.hotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel1.Location = new System.Drawing.Point(0, 0);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(920, 720);
            this.hotPanel1.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(920, 720);
            this.Controls.Add(this.hotPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "火淘助手工具";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.HotContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HotContainer)).EndInit();
            this.HotContainer.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCustomService)).EndInit();
            this.panelHelp.ResumeLayout(false);
            this.panelHelp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSetting)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHistory)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnWeChat)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.hotPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer HotContainer;
        private System.Windows.Forms.PictureBox pbHelp;
        private System.Windows.Forms.PictureBox btnHistory;
        private System.Windows.Forms.PictureBox btnSetting;
        private System.Windows.Forms.PictureBox btnWeChat;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.ToolTip toolTipText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelHelp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox btnCustomService;
        private System.Windows.Forms.PictureBox pbMin;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel7;
        private Controls.module.HotPanel hotPanel1;
    }
}