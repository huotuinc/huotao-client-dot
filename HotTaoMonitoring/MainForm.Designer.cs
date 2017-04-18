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
            this.bgPanel = new System.Windows.Forms.Panel();
            this.lbSet = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbListen = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picWeChatHead = new System.Windows.Forms.PictureBox();
            this.picMin = new System.Windows.Forms.PictureBox();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.rightContainer = new HotTaoMonitoring.module.HotPanel(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.bgPanel.SuspendLayout();
            this.lbSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.lbListen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeChatHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // bgPanel
            // 
            this.bgPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(176)))));
            this.bgPanel.Controls.Add(this.label1);
            this.bgPanel.Controls.Add(this.lbSet);
            this.bgPanel.Controls.Add(this.lbListen);
            this.bgPanel.Controls.Add(this.label2);
            this.bgPanel.Controls.Add(this.picWeChatHead);
            this.bgPanel.Controls.Add(this.picMin);
            this.bgPanel.Controls.Add(this.pbClose);
            this.bgPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bgPanel.Location = new System.Drawing.Point(0, 0);
            this.bgPanel.Name = "bgPanel";
            this.bgPanel.Size = new System.Drawing.Size(950, 103);
            this.bgPanel.TabIndex = 22;
            this.bgPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CloseMyInfoForm);
            this.bgPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.bgPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.bgPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // lbSet
            // 
            this.lbSet.BackColor = System.Drawing.Color.Transparent;
            this.lbSet.Controls.Add(this.label4);
            this.lbSet.Controls.Add(this.pictureBox2);
            this.lbSet.Location = new System.Drawing.Point(96, 0);
            this.lbSet.Name = "lbSet";
            this.lbSet.Size = new System.Drawing.Size(93, 103);
            this.lbSet.TabIndex = 9;
            this.lbSet.Tag = "1";
            this.lbSet.Click += new System.EventHandler(this.Tab_Selected_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "基本配置";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.Tab_Selected_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HotTaoMonitoring.Properties.Resources.icon_set;
            this.pictureBox2.Location = new System.Drawing.Point(22, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.Tab_Selected_Click);
            // 
            // lbListen
            // 
            this.lbListen.BackColor = System.Drawing.Color.Transparent;
            this.lbListen.BackgroundImage = global::HotTaoMonitoring.Properties.Resources.icon_bg;
            this.lbListen.Controls.Add(this.label3);
            this.lbListen.Controls.Add(this.pictureBox1);
            this.lbListen.Location = new System.Drawing.Point(2, 0);
            this.lbListen.Name = "lbListen";
            this.lbListen.Size = new System.Drawing.Size(93, 103);
            this.lbListen.TabIndex = 9;
            this.lbListen.Tag = "2";
            this.lbListen.Click += new System.EventHandler(this.Tab_Selected_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "微信监控";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.Tab_Selected_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HotTaoMonitoring.Properties.Resources.icon_jk;
            this.pictureBox1.Location = new System.Drawing.Point(22, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.Tab_Selected_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 8;
            // 
            // picWeChatHead
            // 
            this.picWeChatHead.Image = global::HotTaoMonitoring.Properties.Resources.logo;
            this.picWeChatHead.Location = new System.Drawing.Point(878, 37);
            this.picWeChatHead.Name = "picWeChatHead";
            this.picWeChatHead.Size = new System.Drawing.Size(60, 60);
            this.picWeChatHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picWeChatHead.TabIndex = 7;
            this.picWeChatHead.TabStop = false;
            // 
            // picMin
            // 
            this.picMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMin.Image = global::HotTaoMonitoring.Properties.Resources.icon_min;
            this.picMin.Location = new System.Drawing.Point(898, 5);
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
            this.pbClose.Location = new System.Drawing.Point(924, 4);
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
            this.rightContainer.Location = new System.Drawing.Point(0, 103);
            this.rightContainer.Name = "rightContainer";
            this.rightContainer.Size = new System.Drawing.Size(950, 637);
            this.rightContainer.TabIndex = 23;
            this.rightContainer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CloseMyInfoForm);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("黑体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(746, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 63);
            this.label1.TabIndex = 10;
            this.label1.Text = "火淘客服";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 740);
            this.Controls.Add(this.rightContainer);
            this.Controls.Add(this.bgPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "火淘客服系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.bgPanel.ResumeLayout(false);
            this.bgPanel.PerformLayout();
            this.lbSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.lbListen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeChatHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel bgPanel;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.PictureBox picMin;
        private module.HotPanel rightContainer;
        private System.Windows.Forms.PictureBox picWeChatHead;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel lbListen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel lbSet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
    }
}