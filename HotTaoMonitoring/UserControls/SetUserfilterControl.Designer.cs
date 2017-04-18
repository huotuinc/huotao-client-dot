namespace HotTaoMonitoring.UserControls
{
    partial class SetUserfilterControl
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.hotGroupBox2 = new HotTaoMonitoring.module.HotGroupBox(this.components);
            this.txtUserfilter = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.hotPanel1 = new HotTaoMonitoring.module.HotPanel(this.components);
            this.hotGroupBox2.SuspendLayout();
            this.hotPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(25, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 12);
            this.label3.TabIndex = 49;
            this.label3.Text = "开启监控时，将不对白名单内设置的用户生效";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(25, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(593, 12);
            this.label2.TabIndex = 50;
            this.label2.Text = "请在方框内填入需过滤用户的微信昵称，多个昵称之间使用空格隔开，昵称需用[]括起来，格式：[张三][李四]\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(25, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 51;
            this.label1.Text = "说明：";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(158)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(177)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(852, 278);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 28);
            this.btnSave.TabIndex = 48;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.hotGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox2.Controls.Add(this.txtUserfilter);
            this.hotGroupBox2.Location = new System.Drawing.Point(7, 38);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(937, 219);
            this.hotGroupBox2.TabIndex = 0;
            this.hotGroupBox2.TabStop = false;
            // 
            // txtUserfilter
            // 
            this.txtUserfilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.txtUserfilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserfilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserfilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtUserfilter.Location = new System.Drawing.Point(3, 17);
            this.txtUserfilter.Name = "txtUserfilter";
            this.txtUserfilter.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtUserfilter.Size = new System.Drawing.Size(931, 199);
            this.txtUserfilter.TabIndex = 1;
            this.txtUserfilter.Text = "";
            this.txtUserfilter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CloseMyInfoForm);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 51;
            this.label4.Text = "不监控用户设置";
            // 
            // hotPanel1
            // 
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Controls.Add(this.btnSave);
            this.hotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel1.Location = new System.Drawing.Point(0, 0);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(950, 607);
            this.hotPanel1.TabIndex = 52;
            // 
            // SetUserfilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hotGroupBox2);
            this.Controls.Add(this.hotPanel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.Name = "SetUserfilterControl";
            this.Size = new System.Drawing.Size(950, 607);
            this.Load += new System.EventHandler(this.SetUserfilterControl_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CloseMyInfoForm);
            this.hotGroupBox2.ResumeLayout(false);
            this.hotPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private module.HotGroupBox hotGroupBox2;
        private System.Windows.Forms.RichTextBox txtUserfilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private module.HotPanel hotPanel1;
    }
}
