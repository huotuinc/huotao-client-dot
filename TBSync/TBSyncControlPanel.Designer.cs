namespace TBSync
{
    partial class TBSyncControlPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TBSyncControlPanel));
            this.hotPanel1 = new TBSync.HotPanel(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbprogress = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SyncGoodsProgress = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAsyncGoods = new System.Windows.Forms.Button();
            this.btnBindTaobao = new System.Windows.Forms.Button();
            this.btnLoginTaobao = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbMin = new System.Windows.Forms.PictureBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.hotGroupBox3 = new TBSync.HotGroupBox(this.components);
            this.txtLoginPwd = new System.Windows.Forms.TextBox();
            this.hotGroupBox2 = new TBSync.HotGroupBox(this.components);
            this.txtLoginName = new System.Windows.Forms.RichTextBox();
            this.hotGroupBox1 = new TBSync.HotGroupBox(this.components);
            this.txtMsgTip = new System.Windows.Forms.RichTextBox();
            this.hotPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.hotGroupBox3.SuspendLayout();
            this.hotGroupBox2.SuspendLayout();
            this.hotGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hotPanel1
            // 
            this.hotPanel1.BackColor = System.Drawing.Color.White;
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Controls.Add(this.label4);
            this.hotPanel1.Controls.Add(this.label3);
            this.hotPanel1.Controls.Add(this.lbprogress);
            this.hotPanel1.Controls.Add(this.label2);
            this.hotPanel1.Controls.Add(this.SyncGoodsProgress);
            this.hotPanel1.Controls.Add(this.label1);
            this.hotPanel1.Controls.Add(this.btnAsyncGoods);
            this.hotPanel1.Controls.Add(this.btnBindTaobao);
            this.hotPanel1.Controls.Add(this.btnLoginTaobao);
            this.hotPanel1.Controls.Add(this.panel1);
            this.hotPanel1.Controls.Add(this.hotGroupBox3);
            this.hotPanel1.Controls.Add(this.hotGroupBox2);
            this.hotPanel1.Controls.Add(this.hotGroupBox1);
            this.hotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel1.Location = new System.Drawing.Point(0, 0);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(800, 634);
            this.hotPanel1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(309, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "剩余20件商品未同步";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "2017-03-22 14:56:22";
            // 
            // lbprogress
            // 
            this.lbprogress.AutoSize = true;
            this.lbprogress.Location = new System.Drawing.Point(766, 166);
            this.lbprogress.Name = "lbprogress";
            this.lbprogress.Size = new System.Drawing.Size(17, 12);
            this.lbprogress.TabIndex = 15;
            this.lbprogress.Text = "0%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "上次同步时间";
            // 
            // SyncGoodsProgress
            // 
            this.SyncGoodsProgress.BackColor = System.Drawing.Color.Silver;
            this.SyncGoodsProgress.ForeColor = System.Drawing.Color.Lime;
            this.SyncGoodsProgress.Location = new System.Drawing.Point(12, 165);
            this.SyncGoodsProgress.Name = "SyncGoodsProgress";
            this.SyncGoodsProgress.Size = new System.Drawing.Size(747, 15);
            this.SyncGoodsProgress.Step = 1;
            this.SyncGoodsProgress.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "同步情况";
            // 
            // btnAsyncGoods
            // 
            this.btnAsyncGoods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnAsyncGoods.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsyncGoods.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnAsyncGoods.FlatAppearance.BorderSize = 0;
            this.btnAsyncGoods.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnAsyncGoods.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(183)))), ((int)(((byte)(89)))));
            this.btnAsyncGoods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsyncGoods.ForeColor = System.Drawing.Color.White;
            this.btnAsyncGoods.Location = new System.Drawing.Point(711, 67);
            this.btnAsyncGoods.Name = "btnAsyncGoods";
            this.btnAsyncGoods.Size = new System.Drawing.Size(75, 32);
            this.btnAsyncGoods.TabIndex = 12;
            this.btnAsyncGoods.Text = "开通同步";
            this.btnAsyncGoods.UseVisualStyleBackColor = false;
            this.btnAsyncGoods.Click += new System.EventHandler(this.btnAsyncGoods_Click);
            // 
            // btnBindTaobao
            // 
            this.btnBindTaobao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnBindTaobao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBindTaobao.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnBindTaobao.FlatAppearance.BorderSize = 0;
            this.btnBindTaobao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnBindTaobao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(177)))));
            this.btnBindTaobao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBindTaobao.ForeColor = System.Drawing.Color.White;
            this.btnBindTaobao.Location = new System.Drawing.Point(407, 68);
            this.btnBindTaobao.Name = "btnBindTaobao";
            this.btnBindTaobao.Size = new System.Drawing.Size(50, 32);
            this.btnBindTaobao.TabIndex = 11;
            this.btnBindTaobao.Text = "绑定";
            this.btnBindTaobao.UseVisualStyleBackColor = false;
            this.btnBindTaobao.Click += new System.EventHandler(this.btnBindTaobao_Click);
            // 
            // btnLoginTaobao
            // 
            this.btnLoginTaobao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnLoginTaobao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoginTaobao.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnLoginTaobao.FlatAppearance.BorderSize = 0;
            this.btnLoginTaobao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnLoginTaobao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(177)))));
            this.btnLoginTaobao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginTaobao.ForeColor = System.Drawing.Color.White;
            this.btnLoginTaobao.Location = new System.Drawing.Point(630, 67);
            this.btnLoginTaobao.Name = "btnLoginTaobao";
            this.btnLoginTaobao.Size = new System.Drawing.Size(75, 32);
            this.btnLoginTaobao.TabIndex = 11;
            this.btnLoginTaobao.Text = "登录淘宝";
            this.btnLoginTaobao.UseVisualStyleBackColor = false;
            this.btnLoginTaobao.Click += new System.EventHandler(this.btnLoginTaobao_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(108)))), ((int)(((byte)(172)))));
            this.panel1.Controls.Add(this.pbMin);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Controls.Add(this.pbClose);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 45);
            this.panel1.TabIndex = 9;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // pbMin
            // 
            this.pbMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMin.Image = global::TBSync.Properties.Resources.icon_min;
            this.pbMin.Location = new System.Drawing.Point(748, 14);
            this.pbMin.Name = "pbMin";
            this.pbMin.Size = new System.Drawing.Size(20, 20);
            this.pbMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbMin.TabIndex = 8;
            this.pbMin.TabStop = false;
            this.pbMin.Click += new System.EventHandler(this.pbMin_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(10, 14);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(101, 12);
            this.lbTitle.TabIndex = 7;
            this.lbTitle.Text = "商品同步控制面板";
            // 
            // pbClose
            // 
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = global::TBSync.Properties.Resources.icon_close;
            this.pbClose.Location = new System.Drawing.Point(774, 14);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(20, 20);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbClose.TabIndex = 6;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // hotGroupBox3
            // 
            this.hotGroupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.hotGroupBox3.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox3.BorderTitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.hotGroupBox3.Controls.Add(this.txtLoginPwd);
            this.hotGroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hotGroupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.hotGroupBox3.Location = new System.Drawing.Point(209, 63);
            this.hotGroupBox3.Name = "hotGroupBox3";
            this.hotGroupBox3.Size = new System.Drawing.Size(191, 39);
            this.hotGroupBox3.TabIndex = 2;
            this.hotGroupBox3.TabStop = false;
            // 
            // txtLoginPwd
            // 
            this.txtLoginPwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.txtLoginPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoginPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtLoginPwd.Location = new System.Drawing.Point(4, 15);
            this.txtLoginPwd.Name = "txtLoginPwd";
            this.txtLoginPwd.Size = new System.Drawing.Size(181, 14);
            this.txtLoginPwd.TabIndex = 0;
            this.txtLoginPwd.UseSystemPasswordChar = true;
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.hotGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.hotGroupBox2.Controls.Add(this.txtLoginName);
            this.hotGroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hotGroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.hotGroupBox2.Location = new System.Drawing.Point(12, 63);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(191, 39);
            this.hotGroupBox2.TabIndex = 1;
            this.hotGroupBox2.TabStop = false;
            // 
            // txtLoginName
            // 
            this.txtLoginName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.txtLoginName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoginName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLoginName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtLoginName.Location = new System.Drawing.Point(3, 17);
            this.txtLoginName.Multiline = false;
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtLoginName.Size = new System.Drawing.Size(185, 19);
            this.txtLoginName.TabIndex = 3;
            this.txtLoginName.Text = "";
            // 
            // hotGroupBox1
            // 
            this.hotGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.hotGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.hotGroupBox1.Controls.Add(this.txtMsgTip);
            this.hotGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hotGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.hotGroupBox1.Location = new System.Drawing.Point(12, 186);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(778, 436);
            this.hotGroupBox1.TabIndex = 5;
            this.hotGroupBox1.TabStop = false;
            // 
            // txtMsgTip
            // 
            this.txtMsgTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.txtMsgTip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMsgTip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsgTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtMsgTip.Location = new System.Drawing.Point(3, 17);
            this.txtMsgTip.Name = "txtMsgTip";
            this.txtMsgTip.ReadOnly = true;
            this.txtMsgTip.Size = new System.Drawing.Size(772, 416);
            this.txtMsgTip.TabIndex = 3;
            this.txtMsgTip.Text = "";
            // 
            // TBSyncControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 634);
            this.Controls.Add(this.hotPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TBSyncControlPanel";
            this.Text = "控制面板";
            this.Load += new System.EventHandler(this.TBSyncControlPanel_Load);
            this.hotPanel1.ResumeLayout(false);
            this.hotPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.hotGroupBox3.ResumeLayout(false);
            this.hotGroupBox3.PerformLayout();
            this.hotGroupBox2.ResumeLayout(false);
            this.hotGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox txtMsgTip;
        private HotGroupBox hotGroupBox1;
        private HotPanel hotPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.PictureBox pbMin;
        private System.Windows.Forms.Button btnAsyncGoods;
        private System.Windows.Forms.Button btnLoginTaobao;
        private HotGroupBox hotGroupBox2;
        private System.Windows.Forms.RichTextBox txtLoginName;
        private HotGroupBox hotGroupBox3;
        private System.Windows.Forms.ProgressBar SyncGoodsProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBindTaobao;
        private System.Windows.Forms.TextBox txtLoginPwd;
        private System.Windows.Forms.Label lbprogress;
    }
}