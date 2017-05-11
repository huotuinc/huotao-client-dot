namespace HotTao.Controls
{
    partial class GoodsCollect
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
            this.panel7 = new System.Windows.Forms.Panel();
            this.plRightTop = new System.Windows.Forms.Panel();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.hotGroupBox4 = new HotTaoControls.HotGroupBox(this.components);
            this.panelWeb = new System.Windows.Forms.Panel();
            this.hotGroupBox3 = new HotTaoControls.HotGroupBox(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAddGoods = new System.Windows.Forms.Button();
            this.hotGroupBox5 = new HotTaoControls.HotGroupBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbCouponPrice = new System.Windows.Forms.Label();
            this.lbCouponName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenUrl = new System.Windows.Forms.Button();
            this.hotGroupBox2 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.txtGoodsUrl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hotGroupBox1 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.txtCouponUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7.SuspendLayout();
            this.plRightTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.hotGroupBox4.SuspendLayout();
            this.hotGroupBox3.SuspendLayout();
            this.hotGroupBox5.SuspendLayout();
            this.hotGroupBox2.SuspendLayout();
            this.hotGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel7.Controls.Add(this.plRightTop);
            this.panel7.Controls.Add(this.lbTitle);
            this.panel7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1280, 31);
            this.panel7.TabIndex = 12;
            this.panel7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.panel7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.panel7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // plRightTop
            // 
            this.plRightTop.Controls.Add(this.picHome);
            this.plRightTop.Controls.Add(this.picClose);
            this.plRightTop.Location = new System.Drawing.Point(1205, 0);
            this.plRightTop.Name = "plRightTop";
            this.plRightTop.Size = new System.Drawing.Size(75, 31);
            this.plRightTop.TabIndex = 122;
            // 
            // picHome
            // 
            this.picHome.BackColor = System.Drawing.Color.Transparent;
            this.picHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picHome.Image = global::HotTao.Properties.Resources.sy13x13;
            this.picHome.Location = new System.Drawing.Point(9, 6);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(20, 20);
            this.picHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picHome.TabIndex = 118;
            this.picHome.TabStop = false;
            this.picHome.Click += new System.EventHandler(this.picHome_Click);
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::HotTao.Properties.Resources.icon_close1;
            this.picClose.Location = new System.Drawing.Point(47, 6);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(20, 20);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 118;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.ForeColor = System.Drawing.Color.Black;
            this.lbTitle.Location = new System.Drawing.Point(7, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(149, 12);
            this.lbTitle.TabIndex = 6;
            this.lbTitle.Text = "根据商品网址采集商品信息";
            // 
            // hotGroupBox4
            // 
            this.hotGroupBox4.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox4.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox4.Controls.Add(this.panelWeb);
            this.hotGroupBox4.Location = new System.Drawing.Point(9, 151);
            this.hotGroupBox4.Name = "hotGroupBox4";
            this.hotGroupBox4.Size = new System.Drawing.Size(1263, 638);
            this.hotGroupBox4.TabIndex = 2;
            this.hotGroupBox4.TabStop = false;
            this.hotGroupBox4.Text = "商品预览";
            // 
            // panelWeb
            // 
            this.panelWeb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWeb.Location = new System.Drawing.Point(3, 17);
            this.panelWeb.Name = "panelWeb";
            this.panelWeb.Size = new System.Drawing.Size(1257, 618);
            this.panelWeb.TabIndex = 0;
            // 
            // hotGroupBox3
            // 
            this.hotGroupBox3.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox3.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox3.Controls.Add(this.btnRefresh);
            this.hotGroupBox3.Controls.Add(this.btnAddGoods);
            this.hotGroupBox3.Controls.Add(this.hotGroupBox5);
            this.hotGroupBox3.Controls.Add(this.label1);
            this.hotGroupBox3.Controls.Add(this.btnOpenUrl);
            this.hotGroupBox3.Controls.Add(this.hotGroupBox2);
            this.hotGroupBox3.Controls.Add(this.label3);
            this.hotGroupBox3.Controls.Add(this.hotGroupBox1);
            this.hotGroupBox3.Controls.Add(this.label2);
            this.hotGroupBox3.Location = new System.Drawing.Point(9, 32);
            this.hotGroupBox3.Name = "hotGroupBox3";
            this.hotGroupBox3.Size = new System.Drawing.Size(1263, 114);
            this.hotGroupBox3.TabIndex = 0;
            this.hotGroupBox3.TabStop = false;
            this.hotGroupBox3.Text = "设置";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(183)))), ((int)(((byte)(89)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1171, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 40);
            this.btnRefresh.TabIndex = 56;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
            this.btnAddGoods.Location = new System.Drawing.Point(1171, 65);
            this.btnAddGoods.Name = "btnAddGoods";
            this.btnAddGoods.Size = new System.Drawing.Size(75, 40);
            this.btnAddGoods.TabIndex = 58;
            this.btnAddGoods.Text = "保存";
            this.btnAddGoods.UseVisualStyleBackColor = false;
            this.btnAddGoods.Click += new System.EventHandler(this.btnAddGoods_Click);
            // 
            // hotGroupBox5
            // 
            this.hotGroupBox5.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox5.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox5.Controls.Add(this.label5);
            this.hotGroupBox5.Controls.Add(this.label4);
            this.hotGroupBox5.Controls.Add(this.lbCouponPrice);
            this.hotGroupBox5.Controls.Add(this.lbCouponName);
            this.hotGroupBox5.Location = new System.Drawing.Point(768, 16);
            this.hotGroupBox5.Name = "hotGroupBox5";
            this.hotGroupBox5.Size = new System.Drawing.Size(389, 92);
            this.hotGroupBox5.TabIndex = 57;
            this.hotGroupBox5.TabStop = false;
            this.hotGroupBox5.Text = "优惠券信息";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "优惠金额：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "标题：";
            // 
            // lbCouponPrice
            // 
            this.lbCouponPrice.AutoSize = true;
            this.lbCouponPrice.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbCouponPrice.Location = new System.Drawing.Point(101, 65);
            this.lbCouponPrice.Name = "lbCouponPrice";
            this.lbCouponPrice.Size = new System.Drawing.Size(41, 12);
            this.lbCouponPrice.TabIndex = 38;
            this.lbCouponPrice.Text = "(暂无)";
            // 
            // lbCouponName
            // 
            this.lbCouponName.AutoSize = true;
            this.lbCouponName.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbCouponName.Location = new System.Drawing.Point(77, 33);
            this.lbCouponName.Name = "lbCouponName";
            this.lbCouponName.Size = new System.Drawing.Size(41, 12);
            this.lbCouponName.TabIndex = 38;
            this.lbCouponName.Text = "(暂无)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 38;
            this.label1.Text = "商品链接";
            // 
            // btnOpenUrl
            // 
            this.btnOpenUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnOpenUrl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenUrl.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnOpenUrl.FlatAppearance.BorderSize = 0;
            this.btnOpenUrl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnOpenUrl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(183)))), ((int)(((byte)(89)))));
            this.btnOpenUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenUrl.ForeColor = System.Drawing.Color.White;
            this.btnOpenUrl.Location = new System.Drawing.Point(649, 20);
            this.btnOpenUrl.Name = "btnOpenUrl";
            this.btnOpenUrl.Size = new System.Drawing.Size(56, 35);
            this.btnOpenUrl.TabIndex = 56;
            this.btnOpenUrl.Text = "查看";
            this.btnOpenUrl.UseVisualStyleBackColor = false;
            this.btnOpenUrl.Click += new System.EventHandler(this.btnOpenUrl_Click);
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.hotGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox2.Controls.Add(this.txtGoodsUrl);
            this.hotGroupBox2.Location = new System.Drawing.Point(87, 14);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(555, 41);
            this.hotGroupBox2.TabIndex = 1;
            this.hotGroupBox2.TabStop = false;
            // 
            // txtGoodsUrl
            // 
            this.txtGoodsUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.txtGoodsUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGoodsUrl.Location = new System.Drawing.Point(6, 17);
            this.txtGoodsUrl.Name = "txtGoodsUrl";
            this.txtGoodsUrl.Size = new System.Drawing.Size(543, 14);
            this.txtGoodsUrl.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(647, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 38;
            this.label3.Text = "(选填)";
            // 
            // hotGroupBox1
            // 
            this.hotGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.hotGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox1.Controls.Add(this.txtCouponUrl);
            this.hotGroupBox1.Location = new System.Drawing.Point(87, 59);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(555, 41);
            this.hotGroupBox1.TabIndex = 2;
            this.hotGroupBox1.TabStop = false;
            // 
            // txtCouponUrl
            // 
            this.txtCouponUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.txtCouponUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCouponUrl.Location = new System.Drawing.Point(6, 17);
            this.txtCouponUrl.Name = "txtCouponUrl";
            this.txtCouponUrl.Size = new System.Drawing.Size(543, 14);
            this.txtCouponUrl.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 38;
            this.label2.Text = "优惠券链接";
            // 
            // GoodsCollect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 794);
            this.Controls.Add(this.hotGroupBox4);
            this.Controls.Add(this.hotGroupBox3);
            this.Controls.Add(this.panel7);
            this.KeyPreview = true;
            this.Name = "GoodsCollect";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "采集商品";
            this.Load += new System.EventHandler(this.GoodsCollect_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GoodsCollect_KeyDown);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.plRightTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.hotGroupBox4.ResumeLayout(false);
            this.hotGroupBox3.ResumeLayout(false);
            this.hotGroupBox3.PerformLayout();
            this.hotGroupBox5.ResumeLayout(false);
            this.hotGroupBox5.PerformLayout();
            this.hotGroupBox2.ResumeLayout(false);
            this.hotGroupBox2.PerformLayout();
            this.hotGroupBox1.ResumeLayout(false);
            this.hotGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lbTitle;
        private module.HotGroupBox hotGroupBox2;
        private System.Windows.Forms.TextBox txtGoodsUrl;
        private System.Windows.Forms.Panel panelWeb;
        private System.Windows.Forms.Label label1;
        private module.HotGroupBox hotGroupBox1;
        private System.Windows.Forms.TextBox txtCouponUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOpenUrl;
        private HotTaoControls.HotGroupBox hotGroupBox3;
        private HotTaoControls.HotGroupBox hotGroupBox4;
        private HotTaoControls.HotGroupBox hotGroupBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbCouponPrice;
        private System.Windows.Forms.Label lbCouponName;
        private System.Windows.Forms.Button btnAddGoods;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel plRightTop;
        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.PictureBox picClose;
    }
}