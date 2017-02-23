namespace HotTao.Controls.Login
{
    partial class SetTaobaoAccountPage
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
            this.lbSkipStep = new System.Windows.Forms.LinkLabel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.loginPwd = new System.Windows.Forms.TextBox();
            this.loginName = new System.Windows.Forms.TextBox();
            this.hotGroupBox1 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.lbLoginName = new System.Windows.Forms.Label();
            this.hotGroupBox2 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.lbLoginPwd = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hotGroupBox1.SuspendLayout();
            this.hotGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSkipStep
            // 
            this.lbSkipStep.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            this.lbSkipStep.Location = new System.Drawing.Point(104, 198);
            this.lbSkipStep.Name = "lbSkipStep";
            this.lbSkipStep.Size = new System.Drawing.Size(62, 16);
            this.lbSkipStep.TabIndex = 18;
            this.lbSkipStep.TabStop = true;
            this.lbSkipStep.Text = "点击跳过";
            this.lbSkipStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSkipStep.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbSkipStep_LinkClicked);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(105)))));
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(105)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(19, 143);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(233, 41);
            this.btnLogin.TabIndex = 15;
            this.btnLogin.Text = "模拟登陆";
            this.btnLogin.UseVisualStyleBackColor = false;
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
            // hotGroupBox1
            // 
            this.hotGroupBox1.BackColor = System.Drawing.Color.White;
            this.hotGroupBox1.BorderColor = System.Drawing.Color.White;
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox1.Controls.Add(this.lbLoginName);
            this.hotGroupBox1.Controls.Add(this.loginName);
            this.hotGroupBox1.Location = new System.Drawing.Point(19, 52);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(233, 35);
            this.hotGroupBox1.TabIndex = 13;
            this.hotGroupBox1.TabStop = false;
            // 
            // lbLoginName
            // 
            this.lbLoginName.BackColor = System.Drawing.Color.Transparent;
            this.lbLoginName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.lbLoginName.Location = new System.Drawing.Point(6, 8);
            this.lbLoginName.Name = "lbLoginName";
            this.lbLoginName.Size = new System.Drawing.Size(90, 22);
            this.lbLoginName.TabIndex = 100;
            this.lbLoginName.Text = "请输入淘宝账户";
            this.lbLoginName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLoginName.Click += new System.EventHandler(this.lbLoginName_Click);
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BackColor = System.Drawing.Color.White;
            this.hotGroupBox2.BorderColor = System.Drawing.Color.White;
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox2.Controls.Add(this.lbLoginPwd);
            this.hotGroupBox2.Controls.Add(this.loginPwd);
            this.hotGroupBox2.Location = new System.Drawing.Point(19, 92);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(233, 35);
            this.hotGroupBox2.TabIndex = 14;
            this.hotGroupBox2.TabStop = false;
            // 
            // lbLoginPwd
            // 
            this.lbLoginPwd.BackColor = System.Drawing.Color.Transparent;
            this.lbLoginPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.lbLoginPwd.Location = new System.Drawing.Point(6, 8);
            this.lbLoginPwd.Name = "lbLoginPwd";
            this.lbLoginPwd.Size = new System.Drawing.Size(65, 22);
            this.lbLoginPwd.TabIndex = 15;
            this.lbLoginPwd.Text = "请输入密码";
            this.lbLoginPwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLoginPwd.Click += new System.EventHandler(this.lbLoginPwd_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 33);
            this.label1.TabIndex = 19;
            this.label1.Text = "淘宝账号设置";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SetTaobaoAccountPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbSkipStep);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.hotGroupBox1);
            this.Controls.Add(this.hotGroupBox2);
            this.Name = "SetTaobaoAccountPage";
            this.Size = new System.Drawing.Size(270, 241);
            this.hotGroupBox1.ResumeLayout(false);
            this.hotGroupBox1.PerformLayout();
            this.hotGroupBox2.ResumeLayout(false);
            this.hotGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel lbSkipStep;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox loginPwd;
        private System.Windows.Forms.TextBox loginName;
        private module.HotGroupBox hotGroupBox1;
        private System.Windows.Forms.Label lbLoginName;
        private module.HotGroupBox hotGroupBox2;
        private System.Windows.Forms.Label lbLoginPwd;
        private System.Windows.Forms.Label label1;
    }
}
