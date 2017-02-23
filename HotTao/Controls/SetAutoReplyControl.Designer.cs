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
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.hotGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hotGroupBox1
            // 
            this.hotGroupBox1.BorderColor = System.Drawing.Color.Magenta;
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox1.Controls.Add(this.richTextBox2);
            this.hotGroupBox1.Controls.Add(this.richTextBox1);
            this.hotGroupBox1.Controls.Add(this.label2);
            this.hotGroupBox1.Controls.Add(this.label1);
            this.hotGroupBox1.Controls.Add(this.checkBox1);
            this.hotGroupBox1.Controls.Add(this.label9);
            this.hotGroupBox1.Location = new System.Drawing.Point(11, 19);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(678, 497);
            this.hotGroupBox1.TabIndex = 1;
            this.hotGroupBox1.TabStop = false;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Location = new System.Drawing.Point(355, 143);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(262, 100);
            this.richTextBox2.TabIndex = 36;
            this.richTextBox2.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(53, 143);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(246, 100);
            this.richTextBox1.TabIndex = 36;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 105);
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(53, 32);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 35;
            this.checkBox1.Text = "开启自动回复";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label9.Location = new System.Drawing.Point(281, -1);
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
            this.Size = new System.Drawing.Size(703, 646);
            this.hotGroupBox1.ResumeLayout(false);
            this.hotGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private module.HotGroupBox hotGroupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}
