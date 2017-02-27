namespace HotTao.Controls
{
    partial class SetAutoReplyControl
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
            this.hotGroupBox1 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.hotGroupBox3 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.txtResponeContent = new System.Windows.Forms.RichTextBox();
            this.hotGroupBox2 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.txtKeyword = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbAutoReplay = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.hotGroupBox1.SuspendLayout();
            this.hotGroupBox3.SuspendLayout();
            this.hotGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // hotGroupBox1
            // 
            this.hotGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox1.Controls.Add(this.hotGroupBox3);
            this.hotGroupBox1.Controls.Add(this.hotGroupBox2);
            this.hotGroupBox1.Controls.Add(this.label2);
            this.hotGroupBox1.Controls.Add(this.label1);
            this.hotGroupBox1.Controls.Add(this.ckbAutoReplay);
            this.hotGroupBox1.Controls.Add(this.label9);
            this.hotGroupBox1.Location = new System.Drawing.Point(11, 19);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(729, 497);
            this.hotGroupBox1.TabIndex = 1;
            this.hotGroupBox1.TabStop = false;
            // 
            // hotGroupBox3
            // 
            this.hotGroupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.hotGroupBox3.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox3.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox3.Controls.Add(this.txtResponeContent);
            this.hotGroupBox3.Location = new System.Drawing.Point(395, 147);
            this.hotGroupBox3.Name = "hotGroupBox3";
            this.hotGroupBox3.Size = new System.Drawing.Size(280, 220);
            this.hotGroupBox3.TabIndex = 39;
            this.hotGroupBox3.TabStop = false;
            // 
            // txtResponeContent
            // 
            this.txtResponeContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.txtResponeContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResponeContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResponeContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtResponeContent.Location = new System.Drawing.Point(3, 17);
            this.txtResponeContent.Name = "txtResponeContent";
            this.txtResponeContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtResponeContent.Size = new System.Drawing.Size(274, 200);
            this.txtResponeContent.TabIndex = 26;
            this.txtResponeContent.Text = "";
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.hotGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox2.Controls.Add(this.txtKeyword);
            this.hotGroupBox2.Location = new System.Drawing.Point(53, 147);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(280, 220);
            this.hotGroupBox2.TabIndex = 38;
            this.hotGroupBox2.TabStop = false;
            // 
            // txtKeyword
            // 
            this.txtKeyword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.txtKeyword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKeyword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKeyword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtKeyword.Location = new System.Drawing.Point(3, 17);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtKeyword.Size = new System.Drawing.Size(274, 200);
            this.txtKeyword.TabIndex = 26;
            this.txtKeyword.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 37;
            this.label2.Text = "设置自动回复内容";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 37;
            this.label1.Text = "消息中有以下字符时";
            // 
            // ckbAutoReplay
            // 
            this.ckbAutoReplay.AutoSize = true;
            this.ckbAutoReplay.Location = new System.Drawing.Point(53, 32);
            this.ckbAutoReplay.Name = "ckbAutoReplay";
            this.ckbAutoReplay.Size = new System.Drawing.Size(96, 16);
            this.ckbAutoReplay.TabIndex = 35;
            this.ckbAutoReplay.Text = "开启自动回复";
            this.ckbAutoReplay.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.label9.Location = new System.Drawing.Point(323, -1);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(5);
            this.label9.Size = new System.Drawing.Size(93, 22);
            this.label9.TabIndex = 34;
            this.label9.Text = "自动回复设置";
            // 
            // SetAutoReplyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.hotGroupBox1);
            this.Name = "SetAutoReplyControl";
            this.Size = new System.Drawing.Size(750, 646);
            this.Load += new System.EventHandler(this.SetAutoReplyControl_Load);
            this.hotGroupBox1.ResumeLayout(false);
            this.hotGroupBox1.PerformLayout();
            this.hotGroupBox3.ResumeLayout(false);
            this.hotGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private module.HotGroupBox hotGroupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ckbAutoReplay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private module.HotGroupBox hotGroupBox2;
        private System.Windows.Forms.RichTextBox txtKeyword;
        private module.HotGroupBox hotGroupBox3;
        private System.Windows.Forms.RichTextBox txtResponeContent;
    }
}
