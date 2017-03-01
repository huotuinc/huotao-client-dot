namespace HotTao.Controls
{
    partial class TestControl1
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
            this.hotGroupBox2 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.txtKeyword = new System.Windows.Forms.RichTextBox();
            this.hotGroupBox1 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.hotGroupBox2.SuspendLayout();
            this.hotGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.hotGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox2.Controls.Add(this.txtKeyword);
            this.hotGroupBox2.Location = new System.Drawing.Point(99, 45);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(280, 40);
            this.hotGroupBox2.TabIndex = 39;
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
            this.txtKeyword.Size = new System.Drawing.Size(274, 20);
            this.txtKeyword.TabIndex = 26;
            this.txtKeyword.Text = "";
            // 
            // hotGroupBox1
            // 
            this.hotGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox1.Controls.Add(this.button2);
            this.hotGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.hotGroupBox1.Location = new System.Drawing.Point(99, 107);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(93, 44);
            this.hotGroupBox1.TabIndex = 45;
            this.hotGroupBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(1, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 34);
            this.button2.TabIndex = 41;
            this.button2.Text = "新建";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // TestControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.hotGroupBox1);
            this.Controls.Add(this.hotGroupBox2);
            this.Name = "TestControl1";
            this.Size = new System.Drawing.Size(531, 423);
            this.hotGroupBox2.ResumeLayout(false);
            this.hotGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private module.HotGroupBox hotGroupBox2;
        private System.Windows.Forms.RichTextBox txtKeyword;
        private module.HotGroupBox hotGroupBox1;
        private System.Windows.Forms.Button button2;
    }
}
