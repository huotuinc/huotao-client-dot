namespace HotTaoSquare
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.hotPanel1 = new HotTaoSquare.module.HotPanel(this.components);
            this.lbTipMsg = new System.Windows.Forms.Label();
            this.ckbSavePwd = new System.Windows.Forms.CheckBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.hotGroupBox2 = new HotTaoSquare.module.HotGroupBox(this.components);
            this.lbLoginPwd = new System.Windows.Forms.Label();
            this.txtLoginPwd = new System.Windows.Forms.TextBox();
            this.hotGroupBox1 = new HotTaoSquare.module.HotGroupBox(this.components);
            this.lbLoginMobile = new System.Windows.Forms.Label();
            this.txtLoginMobile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hotPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.hotGroupBox2.SuspendLayout();
            this.hotGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hotPanel1
            // 
            this.hotPanel1.BackColor = System.Drawing.Color.White;
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Controls.Add(this.lbTipMsg);
            this.hotPanel1.Controls.Add(this.ckbSavePwd);
            this.hotPanel1.Controls.Add(this.picClose);
            this.hotPanel1.Controls.Add(this.btnLogin);
            this.hotPanel1.Controls.Add(this.hotGroupBox2);
            this.hotPanel1.Controls.Add(this.hotGroupBox1);
            this.hotPanel1.Controls.Add(this.label2);
            this.hotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel1.Location = new System.Drawing.Point(0, 0);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(284, 402);
            this.hotPanel1.TabIndex = 0;
            this.hotPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.hotPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.hotPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // lbTipMsg
            // 
            this.lbTipMsg.ForeColor = System.Drawing.Color.Red;
            this.lbTipMsg.Location = new System.Drawing.Point(3, 329);
            this.lbTipMsg.Name = "lbTipMsg";
            this.lbTipMsg.Size = new System.Drawing.Size(278, 54);
            this.lbTipMsg.TabIndex = 119;
            this.lbTipMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ckbSavePwd
            // 
            this.ckbSavePwd.AutoSize = true;
            this.ckbSavePwd.Checked = true;
            this.ckbSavePwd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbSavePwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckbSavePwd.Location = new System.Drawing.Point(26, 303);
            this.ckbSavePwd.Name = "ckbSavePwd";
            this.ckbSavePwd.Size = new System.Drawing.Size(72, 16);
            this.ckbSavePwd.TabIndex = 118;
            this.ckbSavePwd.Text = "记住密码";
            this.ckbSavePwd.UseVisualStyleBackColor = true;
            // 
            // picClose
            // 
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::HotTaoSquare.Properties.Resources.icon_close1;
            this.picClose.Location = new System.Drawing.Point(255, 5);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(20, 20);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 117;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(183)))), ((int)(((byte)(89)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(20, 235);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(247, 41);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox2.Controls.Add(this.lbLoginPwd);
            this.hotGroupBox2.Controls.Add(this.txtLoginPwd);
            this.hotGroupBox2.Location = new System.Drawing.Point(20, 163);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(247, 43);
            this.hotGroupBox2.TabIndex = 2;
            this.hotGroupBox2.TabStop = false;
            // 
            // lbLoginPwd
            // 
            this.lbLoginPwd.BackColor = System.Drawing.Color.Transparent;
            this.lbLoginPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.lbLoginPwd.Location = new System.Drawing.Point(10, 13);
            this.lbLoginPwd.Name = "lbLoginPwd";
            this.lbLoginPwd.Size = new System.Drawing.Size(90, 22);
            this.lbLoginPwd.TabIndex = 114;
            this.lbLoginPwd.Text = "请输入登录密码";
            this.lbLoginPwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLoginPwd.Click += new System.EventHandler(this.lbLoginPwd_Click);
            // 
            // txtLoginPwd
            // 
            this.txtLoginPwd.BackColor = System.Drawing.Color.White;
            this.txtLoginPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoginPwd.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLoginPwd.Location = new System.Drawing.Point(6, 18);
            this.txtLoginPwd.Margin = new System.Windows.Forms.Padding(10);
            this.txtLoginPwd.Name = "txtLoginPwd";
            this.txtLoginPwd.Size = new System.Drawing.Size(234, 16);
            this.txtLoginPwd.TabIndex = 113;
            this.txtLoginPwd.UseSystemPasswordChar = true;
            this.txtLoginPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loginPwd_KeyDown);
            this.txtLoginPwd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.loginPwd_KeyDown);
            // 
            // hotGroupBox1
            // 
            this.hotGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox1.Controls.Add(this.lbLoginMobile);
            this.hotGroupBox1.Controls.Add(this.txtLoginMobile);
            this.hotGroupBox1.Location = new System.Drawing.Point(20, 102);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(247, 43);
            this.hotGroupBox1.TabIndex = 1;
            this.hotGroupBox1.TabStop = false;
            // 
            // lbLoginMobile
            // 
            this.lbLoginMobile.BackColor = System.Drawing.Color.Transparent;
            this.lbLoginMobile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.lbLoginMobile.Location = new System.Drawing.Point(10, 13);
            this.lbLoginMobile.Name = "lbLoginMobile";
            this.lbLoginMobile.Size = new System.Drawing.Size(90, 22);
            this.lbLoginMobile.TabIndex = 114;
            this.lbLoginMobile.Text = "请输入手机号码";
            this.lbLoginMobile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLoginMobile.Click += new System.EventHandler(this.lbLoginName_Click);
            // 
            // txtLoginMobile
            // 
            this.txtLoginMobile.BackColor = System.Drawing.Color.White;
            this.txtLoginMobile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoginMobile.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLoginMobile.Location = new System.Drawing.Point(6, 18);
            this.txtLoginMobile.Margin = new System.Windows.Forms.Padding(10);
            this.txtLoginMobile.Name = "txtLoginMobile";
            this.txtLoginMobile.Size = new System.Drawing.Size(234, 16);
            this.txtLoginMobile.TabIndex = 113;
            this.txtLoginMobile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loginName_KeyDown);
            this.txtLoginMobile.KeyUp += new System.Windows.Forms.KeyEventHandler(this.loginName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.label2.Location = new System.Drawing.Point(114, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 24);
            this.label2.TabIndex = 112;
            this.label2.Text = "登录";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 402);
            this.Controls.Add(this.hotPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.Login_Load);
            this.hotPanel1.ResumeLayout(false);
            this.hotPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.hotGroupBox2.ResumeLayout(false);
            this.hotGroupBox2.PerformLayout();
            this.hotGroupBox1.ResumeLayout(false);
            this.hotGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private module.HotPanel hotPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbLoginMobile;
        private System.Windows.Forms.TextBox txtLoginMobile;
        private module.HotGroupBox hotGroupBox1;
        private module.HotGroupBox hotGroupBox2;
        private System.Windows.Forms.Label lbLoginPwd;
        private System.Windows.Forms.TextBox txtLoginPwd;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.CheckBox ckbSavePwd;
        private System.Windows.Forms.Label lbTipMsg;
    }
}

