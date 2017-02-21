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
            this.Container = new System.Windows.Forms.SplitContainer();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.btnHistory = new System.Windows.Forms.PictureBox();
            this.btnSetting = new System.Windows.Forms.PictureBox();
            this.btnTimer = new System.Windows.Forms.PictureBox();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.toolTipText = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Container)).BeginInit();
            this.Container.Panel1.SuspendLayout();
            this.Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.SuspendLayout();
            // 
            // Container
            // 
            this.Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Container.IsSplitterFixed = true;
            this.Container.Location = new System.Drawing.Point(0, 0);
            this.Container.Margin = new System.Windows.Forms.Padding(0);
            this.Container.Name = "Container";
            this.Container.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Container.Panel1
            // 
            this.Container.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(108)))), ((int)(((byte)(172)))));
            this.Container.Panel1.Controls.Add(this.pictureBox5);
            this.Container.Panel1.Controls.Add(this.btnHistory);
            this.Container.Panel1.Controls.Add(this.btnSetting);
            this.Container.Panel1.Controls.Add(this.btnTimer);
            this.Container.Panel1.Controls.Add(this.btnHome);
            this.Container.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.Container.Panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.Container.Panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            this.Container.Panel1MinSize = 0;
            // 
            // Container.Panel2
            // 
            this.Container.Panel2.AutoScroll = true;
            this.Container.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.Container.Panel2MinSize = 0;
            this.Container.Size = new System.Drawing.Size(920, 720);
            this.Container.SplitterDistance = 113;
            this.Container.SplitterWidth = 1;
            this.Container.TabIndex = 0;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::HotTao.Properties.Resources.home;
            this.pictureBox5.Location = new System.Drawing.Point(440, 15);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(74, 74);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            this.toolTipText.SetToolTip(this.pictureBox5, "帮助");
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Image = global::HotTao.Properties.Resources.home;
            this.btnHistory.Location = new System.Drawing.Point(336, 15);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(74, 74);
            this.btnHistory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnHistory.TabIndex = 0;
            this.btnHistory.TabStop = false;
            this.toolTipText.SetToolTip(this.btnHistory, "历史查询");
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Image = global::HotTao.Properties.Resources.home;
            this.btnSetting.Location = new System.Drawing.Point(238, 15);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(74, 74);
            this.btnSetting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSetting.TabIndex = 0;
            this.btnSetting.TabStop = false;
            this.toolTipText.SetToolTip(this.btnSetting, "软件配置");
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnTimer
            // 
            this.btnTimer.Image = global::HotTao.Properties.Resources.home;
            this.btnTimer.Location = new System.Drawing.Point(131, 15);
            this.btnTimer.Name = "btnTimer";
            this.btnTimer.Size = new System.Drawing.Size(74, 74);
            this.btnTimer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnTimer.TabIndex = 0;
            this.btnTimer.TabStop = false;
            this.toolTipText.SetToolTip(this.btnTimer, "定时");
            // 
            // btnHome
            // 
            this.btnHome.Image = global::HotTao.Properties.Resources.home;
            this.btnHome.Location = new System.Drawing.Point(29, 15);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(74, 74);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnHome.TabIndex = 0;
            this.btnHome.TabStop = false;
            this.btnHome.Tag = "";
            this.toolTipText.SetToolTip(this.btnHome, "首页");
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(920, 720);
            this.Controls.Add(this.Container);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Container.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Container)).EndInit();
            this.Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer Container;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox btnHistory;
        private System.Windows.Forms.PictureBox btnSetting;
        private System.Windows.Forms.PictureBox btnTimer;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.ToolTip toolTipText;
    }
}