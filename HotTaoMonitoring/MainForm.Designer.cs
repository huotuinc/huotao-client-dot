namespace HotTaoMonitoring
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bgPanel = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picWeChatHead = new System.Windows.Forms.PictureBox();
            this.lbWeChatNickName = new System.Windows.Forms.Label();
            this.picMin = new System.Windows.Forms.PictureBox();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.rightContainer = new HotTaoMonitoring.module.HotPanel(this.components);
            this.bgPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWeChatHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(166, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 45);
            this.label5.TabIndex = 1;
            this.label5.Tag = "2";
            this.label5.Text = "微信监控";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.Tab_Selected_Click);
            this.label5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CloseMyInfoForm);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(256, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 45);
            this.label1.TabIndex = 1;
            this.label1.Tag = "1";
            this.label1.Text = "基本配置";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.Tab_Selected_Click);
            this.label1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CloseMyInfoForm);
            // 
            // bgPanel
            // 
            this.bgPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(108)))), ((int)(((byte)(172)))));
            this.bgPanel.Controls.Add(this.lbTitle);
            this.bgPanel.Controls.Add(this.label2);
            this.bgPanel.Controls.Add(this.picWeChatHead);
            this.bgPanel.Controls.Add(this.label5);
            this.bgPanel.Controls.Add(this.lbWeChatNickName);
            this.bgPanel.Controls.Add(this.label1);
            this.bgPanel.Controls.Add(this.picMin);
            this.bgPanel.Controls.Add(this.pbClose);
            this.bgPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bgPanel.Location = new System.Drawing.Point(0, 0);
            this.bgPanel.Name = "bgPanel";
            this.bgPanel.Size = new System.Drawing.Size(890, 46);
            this.bgPanel.TabIndex = 22;
            this.bgPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CloseMyInfoForm);
            this.bgPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.bgPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.bgPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(51, 15);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(104, 16);
            this.lbTitle.TabIndex = 6;
            this.lbTitle.Text = "火淘客服系统";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(708, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 8;
            // 
            // picWeChatHead
            // 
            this.picWeChatHead.Location = new System.Drawing.Point(4, 3);
            this.picWeChatHead.Name = "picWeChatHead";
            this.picWeChatHead.Size = new System.Drawing.Size(40, 40);
            this.picWeChatHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWeChatHead.TabIndex = 7;
            this.picWeChatHead.TabStop = false;
            this.picWeChatHead.Click += new System.EventHandler(this.picWeChatHead_Click);
            // 
            // lbWeChatNickName
            // 
            this.lbWeChatNickName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbWeChatNickName.ForeColor = System.Drawing.Color.Crimson;
            this.lbWeChatNickName.Location = new System.Drawing.Point(48, 25);
            this.lbWeChatNickName.Name = "lbWeChatNickName";
            this.lbWeChatNickName.Size = new System.Drawing.Size(113, 16);
            this.lbWeChatNickName.TabIndex = 6;
            this.lbWeChatNickName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbWeChatNickName.Visible = false;
            // 
            // picMin
            // 
            this.picMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMin.Image = global::HotTaoMonitoring.Properties.Resources.icon_min;
            this.picMin.Location = new System.Drawing.Point(837, 13);
            this.picMin.Name = "picMin";
            this.picMin.Size = new System.Drawing.Size(20, 20);
            this.picMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMin.TabIndex = 5;
            this.picMin.TabStop = false;
            this.picMin.Click += new System.EventHandler(this.picMin_Click);
            // 
            // pbClose
            // 
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = global::HotTaoMonitoring.Properties.Resources.icon_close;
            this.pbClose.Location = new System.Drawing.Point(863, 12);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(20, 20);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbClose.TabIndex = 5;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // rightContainer
            // 
            this.rightContainer.BackColor = System.Drawing.Color.White;
            this.rightContainer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.rightContainer.Location = new System.Drawing.Point(1, 46);
            this.rightContainer.Name = "rightContainer";
            this.rightContainer.Size = new System.Drawing.Size(887, 608);
            this.rightContainer.TabIndex = 23;
            this.rightContainer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CloseMyInfoForm);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 654);
            this.Controls.Add(this.rightContainer);
            this.Controls.Add(this.bgPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "火淘客服系统";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.bgPanel.ResumeLayout(false);
            this.bgPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWeChatHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel bgPanel;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.PictureBox picMin;
        private System.Windows.Forms.Label label5;
        private module.HotPanel rightContainer;
        private System.Windows.Forms.PictureBox picWeChatHead;
        private System.Windows.Forms.Label lbWeChatNickName;
        private System.Windows.Forms.Label label2;
    }
}