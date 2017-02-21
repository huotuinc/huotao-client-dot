namespace HotTao.Controls
{
    partial class SetAccountControl
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
            this.ckbAutoLogin = new System.Windows.Forms.CheckBox();
            this.ckbSavePwd = new System.Windows.Forms.CheckBox();
            this.loginPwd = new System.Windows.Forms.TextBox();
            this.loginName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.hotGroupBox1 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.hotGroupBox2 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.hotGroupBox1.SuspendLayout();
            this.hotGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckbAutoLogin
            // 
            this.ckbAutoLogin.AutoSize = true;
            this.ckbAutoLogin.Location = new System.Drawing.Point(358, 103);
            this.ckbAutoLogin.Name = "ckbAutoLogin";
            this.ckbAutoLogin.Size = new System.Drawing.Size(72, 16);
            this.ckbAutoLogin.TabIndex = 13;
            this.ckbAutoLogin.Text = "自动登录";
            this.ckbAutoLogin.UseVisualStyleBackColor = true;
            this.ckbAutoLogin.CheckedChanged += new System.EventHandler(this.ckbAutoLogin_CheckedChanged);
            // 
            // ckbSavePwd
            // 
            this.ckbSavePwd.AutoSize = true;
            this.ckbSavePwd.Location = new System.Drawing.Point(217, 103);
            this.ckbSavePwd.Name = "ckbSavePwd";
            this.ckbSavePwd.Size = new System.Drawing.Size(72, 16);
            this.ckbSavePwd.TabIndex = 11;
            this.ckbSavePwd.Text = "记住密码";
            this.ckbSavePwd.UseVisualStyleBackColor = true;
            // 
            // loginPwd
            // 
            this.loginPwd.Location = new System.Drawing.Point(252, 61);
            this.loginPwd.Name = "loginPwd";
            this.loginPwd.PasswordChar = '*';
            this.loginPwd.Size = new System.Drawing.Size(178, 21);
            this.loginPwd.TabIndex = 9;
            // 
            // loginName
            // 
            this.loginName.Location = new System.Drawing.Point(252, 24);
            this.loginName.Name = "loginName";
            this.loginName.Size = new System.Drawing.Size(178, 21);
            this.loginName.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(215, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "密码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(192, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "软件账户";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label8.Location = new System.Drawing.Point(270, -3);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(5);
            this.label8.Size = new System.Drawing.Size(67, 22);
            this.label8.TabIndex = 14;
            this.label8.Text = "账户设置";
            // 
            // hotGroupBox1
            // 
            this.hotGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.Blue;
            this.hotGroupBox1.Controls.Add(this.label9);
            this.hotGroupBox1.Controls.Add(this.label10);
            this.hotGroupBox1.Controls.Add(this.textBox2);
            this.hotGroupBox1.Controls.Add(this.label13);
            this.hotGroupBox1.Controls.Add(this.textBox1);
            this.hotGroupBox1.Location = new System.Drawing.Point(10, 187);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(646, 151);
            this.hotGroupBox1.TabIndex = 28;
            this.hotGroupBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label9.Location = new System.Drawing.Point(259, -2);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(5);
            this.label9.Size = new System.Drawing.Size(93, 22);
            this.label9.TabIndex = 14;
            this.label9.Text = "淘宝账户设置";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(190, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "淘宝账号";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(250, 69);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(178, 21);
            this.textBox2.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(189, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 7;
            this.label13.Text = "淘宝密码";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(250, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 21);
            this.textBox1.TabIndex = 8;
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox2.Controls.Add(this.label8);
            this.hotGroupBox2.Controls.Add(this.loginName);
            this.hotGroupBox2.Controls.Add(this.label6);
            this.hotGroupBox2.Controls.Add(this.ckbAutoLogin);
            this.hotGroupBox2.Controls.Add(this.label7);
            this.hotGroupBox2.Controls.Add(this.ckbSavePwd);
            this.hotGroupBox2.Controls.Add(this.loginPwd);
            this.hotGroupBox2.Location = new System.Drawing.Point(10, 12);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(646, 151);
            this.hotGroupBox2.TabIndex = 29;
            this.hotGroupBox2.TabStop = false;
            // 
            // SetAccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.hotGroupBox2);
            this.Controls.Add(this.hotGroupBox1);
            this.Name = "SetAccountControl";
            this.Size = new System.Drawing.Size(671, 384);
            this.Load += new System.EventHandler(this.SetAccountControl_Load);
            this.hotGroupBox1.ResumeLayout(false);
            this.hotGroupBox1.PerformLayout();
            this.hotGroupBox2.ResumeLayout(false);
            this.hotGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox ckbAutoLogin;
        private System.Windows.Forms.CheckBox ckbSavePwd;
        private System.Windows.Forms.TextBox loginPwd;
        private System.Windows.Forms.TextBox loginName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private module.HotGroupBox hotGroupBox1;
        private module.HotGroupBox hotGroupBox2;
    }
}
