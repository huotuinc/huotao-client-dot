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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hotGroupBox2 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.txtGoodsUrl = new System.Windows.Forms.TextBox();
            this.btnOpenUrl = new System.Windows.Forms.Button();
            this.btnAddGoods = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panel2.SuspendLayout();
            this.hotGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnOpenUrl);
            this.panel1.Controls.Add(this.hotGroupBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1250, 632);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(5, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "标题";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picHome
            // 
            this.picHome.BackColor = System.Drawing.Color.Transparent;
            this.picHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picHome.Image = global::HotTao.Properties.Resources.sy13x13;
            this.picHome.Location = new System.Drawing.Point(23, 5);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(20, 20);
            this.picHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picHome.TabIndex = 118;
            this.picHome.TabStop = false;
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::HotTao.Properties.Resources.icon_close1;
            this.picClose.Location = new System.Drawing.Point(52, 4);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(20, 20);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 118;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.picClose);
            this.panel2.Controls.Add(this.picHome);
            this.panel2.Location = new System.Drawing.Point(1169, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(81, 30);
            this.panel2.TabIndex = 119;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(2, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1246, 592);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BackColor = System.Drawing.Color.White;
            this.hotGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox2.Controls.Add(this.txtGoodsUrl);
            this.hotGroupBox2.Location = new System.Drawing.Point(70, 4);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(1106, 33);
            this.hotGroupBox2.TabIndex = 2;
            this.hotGroupBox2.TabStop = false;
            // 
            // txtGoodsUrl
            // 
            this.txtGoodsUrl.BackColor = System.Drawing.Color.White;
            this.txtGoodsUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGoodsUrl.Location = new System.Drawing.Point(6, 13);
            this.txtGoodsUrl.Name = "txtGoodsUrl";
            this.txtGoodsUrl.Size = new System.Drawing.Size(1094, 14);
            this.txtGoodsUrl.TabIndex = 0;
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
            this.btnOpenUrl.Location = new System.Drawing.Point(1182, 10);
            this.btnOpenUrl.Name = "btnOpenUrl";
            this.btnOpenUrl.Size = new System.Drawing.Size(56, 27);
            this.btnOpenUrl.TabIndex = 57;
            this.btnOpenUrl.Text = "查看";
            this.btnOpenUrl.UseVisualStyleBackColor = false;
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
            this.btnAddGoods.Location = new System.Drawing.Point(1167, 673);
            this.btnAddGoods.Name = "btnAddGoods";
            this.btnAddGoods.Size = new System.Drawing.Size(75, 40);
            this.btnAddGoods.TabIndex = 120;
            this.btnAddGoods.Text = "保存";
            this.btnAddGoods.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "商品链接";
            // 
            // GoodsCollectBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 722);
            this.Controls.Add(this.btnAddGoods);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "GoodsCollectBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GoodsCollectBrowser";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panel2.ResumeLayout(false);
            this.hotGroupBox2.ResumeLayout(false);
            this.hotGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private module.HotGroupBox hotGroupBox2;
        private System.Windows.Forms.TextBox txtGoodsUrl;
        private System.Windows.Forms.Button btnOpenUrl;
        private System.Windows.Forms.Button btnAddGoods;
        private System.Windows.Forms.Label label2;
    }
}