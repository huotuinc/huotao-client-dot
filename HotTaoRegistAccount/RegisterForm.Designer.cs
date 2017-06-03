namespace HotTaoRegistAccount
{
    partial class RegisterForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.loginName = new System.Windows.Forms.TextBox();
            this.loginPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnGetVerifyCode = new System.Windows.Forms.Button();
            this.txtRegisterVerifyCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bgPanel = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.bgPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // loginName
            // 
            this.loginName.Location = new System.Drawing.Point(88, 50);
            this.loginName.Name = "loginName";
            this.loginName.Size = new System.Drawing.Size(184, 21);
            this.loginName.TabIndex = 1;
            // 
            // loginPwd
            // 
            this.loginPwd.Location = new System.Drawing.Point(88, 120);
            this.loginPwd.Name = "loginPwd";
            this.loginPwd.Size = new System.Drawing.Size(184, 21);
            this.loginPwd.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "手机号码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码";
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(105)))));
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(105)))));
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(39, 162);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(233, 41);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "注册";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnGetVerifyCode
            // 
            this.btnGetVerifyCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnGetVerifyCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetVerifyCode.FlatAppearance.BorderSize = 0;
            this.btnGetVerifyCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetVerifyCode.ForeColor = System.Drawing.Color.White;
            this.btnGetVerifyCode.Location = new System.Drawing.Point(186, 86);
            this.btnGetVerifyCode.Name = "btnGetVerifyCode";
            this.btnGetVerifyCode.Size = new System.Drawing.Size(86, 21);
            this.btnGetVerifyCode.TabIndex = 114;
            this.btnGetVerifyCode.Text = "获取验证码";
            this.btnGetVerifyCode.UseVisualStyleBackColor = false;
            this.btnGetVerifyCode.Click += new System.EventHandler(this.btnGetVerifyCode_Click);
            // 
            // txtRegisterVerifyCode
            // 
            this.txtRegisterVerifyCode.Location = new System.Drawing.Point(88, 86);
            this.txtRegisterVerifyCode.Name = "txtRegisterVerifyCode";
            this.txtRegisterVerifyCode.Size = new System.Drawing.Size(94, 21);
            this.txtRegisterVerifyCode.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "短信验证码";
            // 
            // bgPanel
            // 
            this.bgPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(108)))), ((int)(((byte)(172)))));
            this.bgPanel.Controls.Add(this.lbTitle);
            this.bgPanel.Controls.Add(this.pbClose);
            this.bgPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bgPanel.Location = new System.Drawing.Point(0, 0);
            this.bgPanel.Name = "bgPanel";
            this.bgPanel.Size = new System.Drawing.Size(302, 28);
            this.bgPanel.TabIndex = 115;
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
            this.lbTitle.Size = new System.Drawing.Size(53, 12);
            this.lbTitle.TabIndex = 6;
            this.lbTitle.Text = "注册账号";
            // 
            // pbClose
            // 
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = global::HotTaoRegistAccount.Properties.Resources.icon_close;
            this.pbClose.Location = new System.Drawing.Point(278, 4);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(20, 20);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbClose.TabIndex = 5;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(302, 235);
            this.Controls.Add(this.bgPanel);
            this.Controls.Add(this.btnGetVerifyCode);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRegisterVerifyCode);
            this.Controls.Add(this.loginPwd);
            this.Controls.Add(this.loginName);
            this.Name = "RegisterForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册";
            this.bgPanel.ResumeLayout(false);
            this.bgPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox loginName;
        private System.Windows.Forms.TextBox loginPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnGetVerifyCode;
        private System.Windows.Forms.TextBox txtRegisterVerifyCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel bgPanel;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.PictureBox pbClose;
    }
}

