namespace HotTao.Controls
{
    partial class AddKeywordControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddKeywordControl));
            this.hotPanel1 = new HotTao.Controls.module.HotPanel(this.components);
            this.ckbAutoGoods = new System.Windows.Forms.RadioButton();
            this.ckbAutoText = new System.Windows.Forms.RadioButton();
            this.bgPanel = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.hotGroupBox1 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.txtReplyContent = new System.Windows.Forms.RichTextBox();
            this.hotGroupBox2 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hotPanel1.SuspendLayout();
            this.bgPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.hotGroupBox1.SuspendLayout();
            this.hotGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // hotPanel1
            // 
            this.hotPanel1.BackColor = System.Drawing.Color.White;
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Controls.Add(this.ckbAutoGoods);
            this.hotPanel1.Controls.Add(this.ckbAutoText);
            this.hotPanel1.Controls.Add(this.bgPanel);
            this.hotPanel1.Controls.Add(this.hotGroupBox1);
            this.hotPanel1.Controls.Add(this.hotGroupBox2);
            this.hotPanel1.Controls.Add(this.btnSave);
            this.hotPanel1.Controls.Add(this.label1);
            this.hotPanel1.Controls.Add(this.label3);
            this.hotPanel1.Controls.Add(this.label2);
            this.hotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel1.Location = new System.Drawing.Point(0, 0);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(520, 274);
            this.hotPanel1.TabIndex = 8;
            // 
            // ckbAutoGoods
            // 
            this.ckbAutoGoods.AutoSize = true;
            this.ckbAutoGoods.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckbAutoGoods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ckbAutoGoods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.ckbAutoGoods.Location = new System.Drawing.Point(259, 98);
            this.ckbAutoGoods.Name = "ckbAutoGoods";
            this.ckbAutoGoods.Size = new System.Drawing.Size(82, 16);
            this.ckbAutoGoods.TabIndex = 15;
            this.ckbAutoGoods.TabStop = true;
            this.ckbAutoGoods.Text = "自定义商品";
            this.ckbAutoGoods.UseVisualStyleBackColor = true;
            this.ckbAutoGoods.Visible = false;
            // 
            // ckbAutoText
            // 
            this.ckbAutoText.AutoSize = true;
            this.ckbAutoText.Checked = true;
            this.ckbAutoText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckbAutoText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ckbAutoText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.ckbAutoText.Location = new System.Drawing.Point(161, 98);
            this.ckbAutoText.Name = "ckbAutoText";
            this.ckbAutoText.Size = new System.Drawing.Size(82, 16);
            this.ckbAutoText.TabIndex = 15;
            this.ckbAutoText.TabStop = true;
            this.ckbAutoText.Text = "自定义文本";
            this.ckbAutoText.UseVisualStyleBackColor = true;
            // 
            // bgPanel
            // 
            this.bgPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(108)))), ((int)(((byte)(172)))));
            this.bgPanel.Controls.Add(this.lbTitle);
            this.bgPanel.Controls.Add(this.pbClose);
            this.bgPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bgPanel.Location = new System.Drawing.Point(0, 0);
            this.bgPanel.Name = "bgPanel";
            this.bgPanel.Size = new System.Drawing.Size(520, 28);
            this.bgPanel.TabIndex = 12;
            this.bgPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.bgPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.bgPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(7, 7);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(29, 12);
            this.lbTitle.TabIndex = 6;
            this.lbTitle.Text = "提示";
            // 
            // pbClose
            // 
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = global::HotTao.Properties.Resources.icon_close;
            this.pbClose.Location = new System.Drawing.Point(494, 4);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(20, 20);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbClose.TabIndex = 5;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // hotGroupBox1
            // 
            this.hotGroupBox1.BackColor = System.Drawing.Color.White;
            this.hotGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox1.Controls.Add(this.txtReplyContent);
            this.hotGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.hotGroupBox1.Location = new System.Drawing.Point(162, 128);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(283, 65);
            this.hotGroupBox1.TabIndex = 13;
            this.hotGroupBox1.TabStop = false;
            // 
            // txtReplyContent
            // 
            this.txtReplyContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReplyContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReplyContent.Location = new System.Drawing.Point(3, 17);
            this.txtReplyContent.Name = "txtReplyContent";
            this.txtReplyContent.Size = new System.Drawing.Size(277, 45);
            this.txtReplyContent.TabIndex = 0;
            this.txtReplyContent.Text = "";
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BackColor = System.Drawing.Color.White;
            this.hotGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox2.Controls.Add(this.txtKeyword);
            this.hotGroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.hotGroupBox2.Location = new System.Drawing.Point(161, 41);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(167, 35);
            this.hotGroupBox2.TabIndex = 13;
            this.hotGroupBox2.TabStop = false;
            // 
            // txtKeyword
            // 
            this.txtKeyword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKeyword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.txtKeyword.Location = new System.Drawing.Point(6, 15);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(155, 14);
            this.txtKeyword.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(183)))), ((int)(((byte)(89)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(178, 216);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(163, 32);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.label1.Location = new System.Drawing.Point(83, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "任务标题：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.label3.Location = new System.Drawing.Point(83, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "回复内容：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.label2.Location = new System.Drawing.Point(83, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "开始时间：";
            // 
            // AddKeywordControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 274);
            this.Controls.Add(this.hotPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddKeywordControl";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.AddKeywordControl_Load);
            this.hotPanel1.ResumeLayout(false);
            this.hotPanel1.PerformLayout();
            this.bgPanel.ResumeLayout(false);
            this.bgPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.hotGroupBox1.ResumeLayout(false);
            this.hotGroupBox2.ResumeLayout(false);
            this.hotGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private module.HotPanel hotPanel1;
        private System.Windows.Forms.Panel bgPanel;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.PictureBox pbClose;
        private module.HotGroupBox hotGroupBox2;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private module.HotGroupBox hotGroupBox1;
        private System.Windows.Forms.RichTextBox txtReplyContent;
        private System.Windows.Forms.RadioButton ckbAutoGoods;
        private System.Windows.Forms.RadioButton ckbAutoText;
    }
}
