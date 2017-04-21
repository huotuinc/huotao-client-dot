namespace HotTao.Controls.Login
{
    partial class RegisterPage
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
            this.btnRegister = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetVerifyCode = new System.Windows.Forms.Button();
            this.hotGroupBox4 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.lbCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.hotGroupBox1 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.lbLoginName = new System.Windows.Forms.Label();
            this.loginName = new System.Windows.Forms.TextBox();
            this.hotGroupBox3 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.lbVerifyCode = new System.Windows.Forms.Label();
            this.txtRegisterVerifyCode = new System.Windows.Forms.TextBox();
            this.hotGroupBox2 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.lbLoginPwd = new System.Windows.Forms.Label();
            this.loginPwd = new System.Windows.Forms.TextBox();
            this.hotGroupBox4.SuspendLayout();
            this.hotGroupBox1.SuspendLayout();
            this.hotGroupBox3.SuspendLayout();
            this.hotGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(105)))));
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(105)))));
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(18, 192);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(233, 41);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "注册";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.label3.Location = new System.Drawing.Point(14, -2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 33);
            this.label3.TabIndex = 21;
            this.label3.Text = "注册火淘账号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGetVerifyCode
            // 
            this.btnGetVerifyCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnGetVerifyCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetVerifyCode.FlatAppearance.BorderSize = 0;
            this.btnGetVerifyCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetVerifyCode.ForeColor = System.Drawing.Color.White;
            this.btnGetVerifyCode.Location = new System.Drawing.Point(158, 110);
            this.btnGetVerifyCode.Name = "btnGetVerifyCode";
            this.btnGetVerifyCode.Size = new System.Drawing.Size(93, 36);
            this.btnGetVerifyCode.TabIndex = 113;
            this.btnGetVerifyCode.Text = "获取验证码";
            this.btnGetVerifyCode.UseVisualStyleBackColor = false;
            this.btnGetVerifyCode.Click += new System.EventHandler(this.btnGetVerifyCode_Click);
            // 
            // hotGroupBox4
            // 
            this.hotGroupBox4.BackColor = System.Drawing.Color.White;
            this.hotGroupBox4.BorderColor = System.Drawing.Color.White;
            this.hotGroupBox4.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox4.Controls.Add(this.lbCode);
            this.hotGroupBox4.Controls.Add(this.txtCode);
            this.hotGroupBox4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hotGroupBox4.Location = new System.Drawing.Point(18, 150);
            this.hotGroupBox4.Name = "hotGroupBox4";
            this.hotGroupBox4.Size = new System.Drawing.Size(233, 35);
            this.hotGroupBox4.TabIndex = 4;
            this.hotGroupBox4.TabStop = false;
            // 
            // lbCode
            // 
            this.lbCode.BackColor = System.Drawing.Color.Transparent;
            this.lbCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.lbCode.Location = new System.Drawing.Point(6, 7);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(97, 22);
            this.lbCode.TabIndex = 100;
            this.lbCode.Text = "软件激活码,选填";
            this.lbCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbCode.Click += new System.EventHandler(this.lbCode_Click);
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.White;
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCode.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCode.Location = new System.Drawing.Point(4, 12);
            this.txtCode.Margin = new System.Windows.Forms.Padding(10);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(219, 16);
            this.txtCode.TabIndex = 0;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            this.txtCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // hotGroupBox1
            // 
            this.hotGroupBox1.BackColor = System.Drawing.Color.White;
            this.hotGroupBox1.BorderColor = System.Drawing.Color.White;
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox1.Controls.Add(this.lbLoginName);
            this.hotGroupBox1.Controls.Add(this.loginName);
            this.hotGroupBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hotGroupBox1.Location = new System.Drawing.Point(18, 29);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(233, 35);
            this.hotGroupBox1.TabIndex = 1;
            this.hotGroupBox1.TabStop = false;
            // 
            // lbLoginName
            // 
            this.lbLoginName.BackColor = System.Drawing.Color.Transparent;
            this.lbLoginName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbLoginName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.lbLoginName.Location = new System.Drawing.Point(6, 8);
            this.lbLoginName.Name = "lbLoginName";
            this.lbLoginName.Size = new System.Drawing.Size(90, 22);
            this.lbLoginName.TabIndex = 100;
            this.lbLoginName.Text = "请输入手机号码";
            this.lbLoginName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLoginName.Click += new System.EventHandler(this.lbLoginName_Click);
            // 
            // loginName
            // 
            this.loginName.BackColor = System.Drawing.Color.White;
            this.loginName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginName.Location = new System.Drawing.Point(4, 12);
            this.loginName.Margin = new System.Windows.Forms.Padding(10);
            this.loginName.Name = "loginName";
            this.loginName.Size = new System.Drawing.Size(219, 16);
            this.loginName.TabIndex = 0;
            this.loginName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loginName_KeyDown);
            this.loginName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.loginName_KeyDown);
            // 
            // hotGroupBox3
            // 
            this.hotGroupBox3.BackColor = System.Drawing.Color.White;
            this.hotGroupBox3.BorderColor = System.Drawing.Color.White;
            this.hotGroupBox3.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox3.Controls.Add(this.lbVerifyCode);
            this.hotGroupBox3.Controls.Add(this.txtRegisterVerifyCode);
            this.hotGroupBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hotGroupBox3.Location = new System.Drawing.Point(18, 110);
            this.hotGroupBox3.Name = "hotGroupBox3";
            this.hotGroupBox3.Size = new System.Drawing.Size(134, 35);
            this.hotGroupBox3.TabIndex = 3;
            this.hotGroupBox3.TabStop = false;
            // 
            // lbVerifyCode
            // 
            this.lbVerifyCode.BackColor = System.Drawing.Color.White;
            this.lbVerifyCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbVerifyCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.lbVerifyCode.Location = new System.Drawing.Point(6, 8);
            this.lbVerifyCode.Name = "lbVerifyCode";
            this.lbVerifyCode.Size = new System.Drawing.Size(80, 22);
            this.lbVerifyCode.TabIndex = 15;
            this.lbVerifyCode.Text = "请输入验证码";
            this.lbVerifyCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbVerifyCode.Click += new System.EventHandler(this.lbVerifyCode_Click);
            // 
            // txtRegisterVerifyCode
            // 
            this.txtRegisterVerifyCode.BackColor = System.Drawing.Color.White;
            this.txtRegisterVerifyCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRegisterVerifyCode.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRegisterVerifyCode.Location = new System.Drawing.Point(4, 12);
            this.txtRegisterVerifyCode.Margin = new System.Windows.Forms.Padding(10);
            this.txtRegisterVerifyCode.Name = "txtRegisterVerifyCode";
            this.txtRegisterVerifyCode.Size = new System.Drawing.Size(111, 16);
            this.txtRegisterVerifyCode.TabIndex = 1;
            this.txtRegisterVerifyCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRegisterVerifyCode_KeyDown);
            this.txtRegisterVerifyCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRegisterVerifyCode_KeyDown);
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BackColor = System.Drawing.Color.White;
            this.hotGroupBox2.BorderColor = System.Drawing.Color.White;
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox2.Controls.Add(this.lbLoginPwd);
            this.hotGroupBox2.Controls.Add(this.loginPwd);
            this.hotGroupBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hotGroupBox2.Location = new System.Drawing.Point(18, 69);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(233, 35);
            this.hotGroupBox2.TabIndex = 2;
            this.hotGroupBox2.TabStop = false;
            // 
            // lbLoginPwd
            // 
            this.lbLoginPwd.BackColor = System.Drawing.Color.White;
            this.lbLoginPwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbLoginPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.lbLoginPwd.Location = new System.Drawing.Point(6, 8);
            this.lbLoginPwd.Name = "lbLoginPwd";
            this.lbLoginPwd.Size = new System.Drawing.Size(65, 22);
            this.lbLoginPwd.TabIndex = 15;
            this.lbLoginPwd.Text = "请输入密码";
            this.lbLoginPwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLoginPwd.Click += new System.EventHandler(this.lbLoginPwd_Click);
            // 
            // loginPwd
            // 
            this.loginPwd.BackColor = System.Drawing.Color.White;
            this.loginPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginPwd.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginPwd.Location = new System.Drawing.Point(4, 12);
            this.loginPwd.Margin = new System.Windows.Forms.Padding(10);
            this.loginPwd.Name = "loginPwd";
            this.loginPwd.Size = new System.Drawing.Size(219, 16);
            this.loginPwd.TabIndex = 1;
            this.loginPwd.UseSystemPasswordChar = true;
            this.loginPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loginPwd_KeyDown);
            this.loginPwd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.loginPwd_KeyDown);
            // 
            // RegisterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGetVerifyCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.hotGroupBox4);
            this.Controls.Add(this.hotGroupBox1);
            this.Controls.Add(this.hotGroupBox3);
            this.Controls.Add(this.hotGroupBox2);
            this.Name = "RegisterPage";
            this.Size = new System.Drawing.Size(270, 251);
            this.hotGroupBox4.ResumeLayout(false);
            this.hotGroupBox4.PerformLayout();
            this.hotGroupBox1.ResumeLayout(false);
            this.hotGroupBox1.PerformLayout();
            this.hotGroupBox3.ResumeLayout(false);
            this.hotGroupBox3.PerformLayout();
            this.hotGroupBox2.ResumeLayout(false);
            this.hotGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox loginPwd;
        private System.Windows.Forms.TextBox loginName;
        private module.HotGroupBox hotGroupBox1;
        private System.Windows.Forms.Label lbLoginName;
        private module.HotGroupBox hotGroupBox2;
        private System.Windows.Forms.Label lbLoginPwd;
        private System.Windows.Forms.Label label3;
        private module.HotGroupBox hotGroupBox3;
        private System.Windows.Forms.TextBox txtRegisterVerifyCode;
        private System.Windows.Forms.Button btnGetVerifyCode;
        private module.HotGroupBox hotGroupBox4;
        private System.Windows.Forms.Label lbCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lbVerifyCode;
    }
}
