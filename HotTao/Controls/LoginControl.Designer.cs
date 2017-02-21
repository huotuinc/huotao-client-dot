namespace HotTao.Controls
{
    partial class LoginControl
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
            this.loginName = new System.Windows.Forms.RichTextBox();
            this.loginPwd = new System.Windows.Forms.RichTextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.ckbSavePwd = new System.Windows.Forms.CheckBox();
            this.ckbAutoLogin = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panelStepLogin = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panelStepLogin.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginName
            // 
            this.loginName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.loginName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginName.Location = new System.Drawing.Point(63, 40);
            this.loginName.Multiline = false;
            this.loginName.Name = "loginName";
            this.loginName.Size = new System.Drawing.Size(243, 34);
            this.loginName.TabIndex = 2;
            this.loginName.Text = "";
            // 
            // loginPwd
            // 
            this.loginPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.loginPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginPwd.Location = new System.Drawing.Point(63, 101);
            this.loginPwd.Multiline = false;
            this.loginPwd.Name = "loginPwd";
            this.loginPwd.Size = new System.Drawing.Size(243, 34);
            this.loginPwd.TabIndex = 2;
            this.loginPwd.Text = "";
            this.loginPwd.UseWaitCursor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(63, 162);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(243, 41);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "下一步";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // ckbSavePwd
            // 
            this.ckbSavePwd.AutoSize = true;
            this.ckbSavePwd.Location = new System.Drawing.Point(63, 229);
            this.ckbSavePwd.Name = "ckbSavePwd";
            this.ckbSavePwd.Size = new System.Drawing.Size(72, 16);
            this.ckbSavePwd.TabIndex = 4;
            this.ckbSavePwd.Text = "记住密码";
            this.ckbSavePwd.UseVisualStyleBackColor = true;
            // 
            // ckbAutoLogin
            // 
            this.ckbAutoLogin.AutoSize = true;
            this.ckbAutoLogin.Location = new System.Drawing.Point(160, 229);
            this.ckbAutoLogin.Name = "ckbAutoLogin";
            this.ckbAutoLogin.Size = new System.Drawing.Size(72, 16);
            this.ckbAutoLogin.TabIndex = 5;
            this.ckbAutoLogin.Text = "自动登录";
            this.ckbAutoLogin.UseVisualStyleBackColor = true;
            this.ckbAutoLogin.CheckedChanged += new System.EventHandler(this.ckbAutoLogin_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(277, 230);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(29, 12);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "注册";
            // 
            // panelStepLogin
            // 
            this.panelStepLogin.BackColor = System.Drawing.Color.Transparent;
            this.panelStepLogin.Controls.Add(this.loginName);
            this.panelStepLogin.Controls.Add(this.linkLabel1);
            this.panelStepLogin.Controls.Add(this.loginPwd);
            this.panelStepLogin.Controls.Add(this.ckbAutoLogin);
            this.panelStepLogin.Controls.Add(this.btnLogin);
            this.panelStepLogin.Controls.Add(this.ckbSavePwd);
            this.panelStepLogin.Location = new System.Drawing.Point(285, 94);
            this.panelStepLogin.Name = "panelStepLogin";
            this.panelStepLogin.Size = new System.Drawing.Size(386, 282);
            this.panelStepLogin.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(285, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 282);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(87, 49);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(100, 96);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // LoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panelStepLogin);
            this.Controls.Add(this.panel1);
            this.Name = "LoginControl";
            this.Size = new System.Drawing.Size(920, 607);
            this.Load += new System.EventHandler(this.LoginControl_Load);
            this.panelStepLogin.ResumeLayout(false);
            this.panelStepLogin.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox loginName;
        private System.Windows.Forms.RichTextBox loginPwd;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox ckbSavePwd;
        private System.Windows.Forms.CheckBox ckbAutoLogin;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panelStepLogin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
