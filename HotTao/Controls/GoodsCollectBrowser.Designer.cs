namespace HotTao.Controls
{
    partial class GoodsCollectBrowser
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
            this.panelBrowser = new System.Windows.Forms.Panel();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.btnAddGoods = new System.Windows.Forms.Button();
            this.plSite = new HotTao.Controls.module.HotPanel(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.plRightTop = new System.Windows.Forms.Panel();
            this.picMin = new System.Windows.Forms.PictureBox();
            this.picMax = new System.Windows.Forms.PictureBox();
            this.picForward = new System.Windows.Forms.PictureBox();
            this.picBack = new System.Windows.Forms.PictureBox();
            this.picRefresh = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.plfooter = new System.Windows.Forms.Panel();
            this.lbTipMsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.plSite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.plRightTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picForward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRefresh)).BeginInit();
            this.plfooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBrowser
            // 
            this.panelBrowser.BackColor = System.Drawing.Color.White;
            this.panelBrowser.Location = new System.Drawing.Point(1, 28);
            this.panelBrowser.Name = "panelBrowser";
            this.panelBrowser.Size = new System.Drawing.Size(1278, 633);
            this.panelBrowser.TabIndex = 0;
            this.panelBrowser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.panelBrowser.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.panelBrowser.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddress.Location = new System.Drawing.Point(27, 6);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(1058, 14);
            this.txtAddress.TabIndex = 0;
            this.txtAddress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.txtAddress.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.txtAddress.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.SystemColors.Control;
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::HotTao.Properties.Resources.icon_close1;
            this.picClose.Location = new System.Drawing.Point(85, 3);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(20, 20);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 118;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // btnAddGoods
            // 
            this.btnAddGoods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnAddGoods.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddGoods.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnAddGoods.FlatAppearance.BorderSize = 0;
            this.btnAddGoods.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnAddGoods.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(177)))));
            this.btnAddGoods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGoods.ForeColor = System.Drawing.Color.White;
            this.btnAddGoods.Location = new System.Drawing.Point(1174, 10);
            this.btnAddGoods.Name = "btnAddGoods";
            this.btnAddGoods.Size = new System.Drawing.Size(97, 40);
            this.btnAddGoods.TabIndex = 120;
            this.btnAddGoods.Text = "开始批量采集";
            this.btnAddGoods.UseVisualStyleBackColor = false;
            this.btnAddGoods.Click += new System.EventHandler(this.btnAddGoods_Click);
            // 
            // plSite
            // 
            this.plSite.BackColor = System.Drawing.Color.White;
            this.plSite.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.plSite.Controls.Add(this.txtAddress);
            this.plSite.Controls.Add(this.pictureBox3);
            this.plSite.Location = new System.Drawing.Point(72, 2);
            this.plSite.Name = "plSite";
            this.plSite.Size = new System.Drawing.Size(1088, 25);
            this.plSite.TabIndex = 58;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::HotTao.Properties.Resources.site;
            this.pictureBox3.Location = new System.Drawing.Point(2, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 118;
            this.pictureBox3.TabStop = false;
            // 
            // plRightTop
            // 
            this.plRightTop.Controls.Add(this.picMin);
            this.plRightTop.Controls.Add(this.picMax);
            this.plRightTop.Controls.Add(this.picClose);
            this.plRightTop.Location = new System.Drawing.Point(1166, 0);
            this.plRightTop.Name = "plRightTop";
            this.plRightTop.Size = new System.Drawing.Size(112, 26);
            this.plRightTop.TabIndex = 121;
            // 
            // picMin
            // 
            this.picMin.BackColor = System.Drawing.SystemColors.Control;
            this.picMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMin.Image = global::HotTao.Properties.Resources.icon_min_1;
            this.picMin.Location = new System.Drawing.Point(33, 3);
            this.picMin.Name = "picMin";
            this.picMin.Size = new System.Drawing.Size(20, 20);
            this.picMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMin.TabIndex = 118;
            this.picMin.TabStop = false;
            this.picMin.Click += new System.EventHandler(this.picMin_Click);
            // 
            // picMax
            // 
            this.picMax.BackColor = System.Drawing.SystemColors.Control;
            this.picMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMax.Image = global::HotTao.Properties.Resources.max;
            this.picMax.Location = new System.Drawing.Point(59, 3);
            this.picMax.Name = "picMax";
            this.picMax.Size = new System.Drawing.Size(20, 20);
            this.picMax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMax.TabIndex = 118;
            this.picMax.TabStop = false;
            this.picMax.Click += new System.EventHandler(this.picMax_Click);
            // 
            // picForward
            // 
            this.picForward.BackColor = System.Drawing.SystemColors.Control;
            this.picForward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picForward.Image = global::HotTao.Properties.Resources.qj13x13;
            this.picForward.Location = new System.Drawing.Point(25, 6);
            this.picForward.Name = "picForward";
            this.picForward.Size = new System.Drawing.Size(20, 20);
            this.picForward.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picForward.TabIndex = 118;
            this.picForward.TabStop = false;
            this.picForward.Click += new System.EventHandler(this.picForward_Click);
            // 
            // picBack
            // 
            this.picBack.BackColor = System.Drawing.SystemColors.Control;
            this.picBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBack.Image = global::HotTao.Properties.Resources.ht13x13;
            this.picBack.Location = new System.Drawing.Point(4, 6);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(20, 20);
            this.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBack.TabIndex = 118;
            this.picBack.TabStop = false;
            this.picBack.Click += new System.EventHandler(this.picBack_Click);
            // 
            // picRefresh
            // 
            this.picRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.picRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picRefresh.Image = global::HotTao.Properties.Resources.refresh_;
            this.picRefresh.Location = new System.Drawing.Point(47, 6);
            this.picRefresh.Name = "picRefresh";
            this.picRefresh.Size = new System.Drawing.Size(20, 20);
            this.picRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picRefresh.TabIndex = 118;
            this.picRefresh.TabStop = false;
            this.picRefresh.Click += new System.EventHandler(this.picRefresh_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 34);
            this.button1.TabIndex = 122;
            this.button1.Tag = "http://www.dataoke.com/qlist/";
            this.button1.Text = "大淘客";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnOpenUrl);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(92, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 34);
            this.button2.TabIndex = 122;
            this.button2.Tag = "http://www.taokezhushou.com/search?page=1";
            this.button2.Text = "淘客助手";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnOpenUrl);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(172, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 34);
            this.button3.TabIndex = 122;
            this.button3.Tag = "http://www.shihuizhu.com/today";
            this.button3.Text = "实惠猪";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnOpenUrl);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(252, 13);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(74, 34);
            this.button4.TabIndex = 122;
            this.button4.Tag = "http://www.haodanku.com/";
            this.button4.Text = "好单库";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnOpenUrl);
            // 
            // plfooter
            // 
            this.plfooter.Controls.Add(this.lbTipMsg);
            this.plfooter.Controls.Add(this.button1);
            this.plfooter.Controls.Add(this.button4);
            this.plfooter.Controls.Add(this.button2);
            this.plfooter.Controls.Add(this.btnAddGoods);
            this.plfooter.Controls.Add(this.button3);
            this.plfooter.Location = new System.Drawing.Point(0, 660);
            this.plfooter.Name = "plfooter";
            this.plfooter.Size = new System.Drawing.Size(1280, 60);
            this.plfooter.TabIndex = 124;
            this.plfooter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.plfooter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.plfooter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // lbTipMsg
            // 
            this.lbTipMsg.AutoSize = true;
            this.lbTipMsg.ForeColor = System.Drawing.Color.Red;
            this.lbTipMsg.Location = new System.Drawing.Point(349, 23);
            this.lbTipMsg.Name = "lbTipMsg";
            this.lbTipMsg.Size = new System.Drawing.Size(0, 12);
            this.lbTipMsg.TabIndex = 123;
            // 
            // GoodsCollectBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.plfooter);
            this.Controls.Add(this.picBack);
            this.Controls.Add(this.plRightTop);
            this.Controls.Add(this.picForward);
            this.Controls.Add(this.picRefresh);
            this.Controls.Add(this.plSite);
            this.Controls.Add(this.panelBrowser);
            this.KeyPreview = true;
            this.Name = "GoodsCollectBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "网址采集";
            this.Load += new System.EventHandler(this.GoodsCollectBrowser_Load);
            this.DoubleClick += new System.EventHandler(this.picMax_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GoodsCollectBrowser_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.plSite.ResumeLayout(false);
            this.plSite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.plRightTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picForward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRefresh)).EndInit();
            this.plfooter.ResumeLayout(false);
            this.plfooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBrowser;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnAddGoods;
        private module.HotPanel plSite;
        private System.Windows.Forms.Panel plRightTop;
        private System.Windows.Forms.PictureBox picMin;
        private System.Windows.Forms.PictureBox picMax;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox picForward;
        private System.Windows.Forms.PictureBox picBack;
        private System.Windows.Forms.PictureBox picRefresh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel plfooter;
        private System.Windows.Forms.Label lbTipMsg;
    }
}