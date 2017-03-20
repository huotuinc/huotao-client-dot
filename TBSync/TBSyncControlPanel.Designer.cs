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
            this.hotPanel1 = new TBSync.HotPanel(this.components);
            this.btnAsyncGoods = new System.Windows.Forms.Button();
            this.btnLoginTaobao = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbMin = new System.Windows.Forms.PictureBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.hotGroupBox1 = new TBSync.HotGroupBox(this.components);
            this.txtMsgTip = new System.Windows.Forms.RichTextBox();
            this.hotPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.hotGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hotPanel1
            // 
            this.hotPanel1.BackColor = System.Drawing.Color.White;
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Controls.Add(this.btnAsyncGoods);
            this.hotPanel1.Controls.Add(this.btnLoginTaobao);
            this.hotPanel1.Controls.Add(this.textBox1);
            this.hotPanel1.Controls.Add(this.panel1);
            this.hotPanel1.Controls.Add(this.hotGroupBox1);
            this.hotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel1.Location = new System.Drawing.Point(0, 0);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(800, 507);
            this.hotPanel1.TabIndex = 6;
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
            this.btnAsyncGoods.Location = new System.Drawing.Point(96, 68);
            this.btnAsyncGoods.Name = "btnAsyncGoods";
            this.btnAsyncGoods.Size = new System.Drawing.Size(75, 32);
            this.btnAsyncGoods.TabIndex = 12;
            this.btnAsyncGoods.Text = "开通同步";
            this.btnAsyncGoods.UseVisualStyleBackColor = false;
            this.btnAsyncGoods.Click += new System.EventHandler(this.btnAsyncGoods_Click);
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
            this.btnLoginTaobao.Location = new System.Drawing.Point(15, 68);
            this.btnLoginTaobao.Name = "btnLoginTaobao";
            this.btnLoginTaobao.Size = new System.Drawing.Size(75, 32);
            this.btnLoginTaobao.TabIndex = 11;
            this.btnLoginTaobao.Text = "登录淘宝";
            this.btnLoginTaobao.UseVisualStyleBackColor = false;
            this.btnLoginTaobao.Click += new System.EventHandler(this.btnLoginTaobao_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.textBox1.Location = new System.Drawing.Point(12, 114);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(756, 50);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "";
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
            // hotGroupBox1
            // 
            this.hotGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.hotGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.hotGroupBox1.Controls.Add(this.txtMsgTip);
            this.hotGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hotGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.hotGroupBox1.Location = new System.Drawing.Point(12, 195);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(776, 281);
            this.hotGroupBox1.TabIndex = 5;
            this.hotGroupBox1.TabStop = false;
            this.hotGroupBox1.Text = "日志";
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
            this.txtMsgTip.Size = new System.Drawing.Size(770, 261);
            this.txtMsgTip.TabIndex = 3;
            this.txtMsgTip.Text = "";
            // 
            // TBSyncControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 507);
            this.Controls.Add(this.hotPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TBSyncControlPanel";
            this.Text = "控制面板";
            this.hotPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
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
        private System.Windows.Forms.RichTextBox textBox1;
        private System.Windows.Forms.Button btnAsyncGoods;
        private System.Windows.Forms.Button btnLoginTaobao;
    }
}