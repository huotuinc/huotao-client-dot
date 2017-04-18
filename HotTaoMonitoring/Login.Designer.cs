namespace HotTaoMonitoring
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
            this.hotPanel1 = new HotTaoMonitoring.module.HotPanel(this.components);
            this.hotPanelRegister = new HotTaoMonitoring.module.HotPanel(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.lkbLogin = new System.Windows.Forms.LinkLabel();
            this.btnGetVerifyCode = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.hotGroupBox4 = new HotTaoMonitoring.module.HotGroupBox(this.components);
            this.lbRegisterMobile = new System.Windows.Forms.Label();
            this.txtRegisterMobile = new System.Windows.Forms.TextBox();
            this.hotGroupBox5 = new HotTaoMonitoring.module.HotGroupBox(this.components);
            this.lbVerifyCode = new System.Windows.Forms.Label();
            this.txtRegisterVerifyCode = new System.Windows.Forms.TextBox();
            this.hotGroupBox3 = new HotTaoMonitoring.module.HotGroupBox(this.components);
            this.lbRegisterPwd = new System.Windows.Forms.Label();
            this.txtRegisterPwd = new System.Windows.Forms.TextBox();
            this.lkbRegister = new System.Windows.Forms.LinkLabel();
            this.lbTipMsg = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbSavePwd = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.hotGroupBox2 = new HotTaoMonitoring.module.HotGroupBox(this.components);
            this.lbLoginPwd = new System.Windows.Forms.Label();
            this.loginPwd = new System.Windows.Forms.TextBox();
            this.hotGroupBox1 = new HotTaoMonitoring.module.HotGroupBox(this.components);
            this.lbLoginName = new System.Windows.Forms.Label();
            this.loginName = new System.Windows.Forms.ComboBox();
            this.hotPanel1.SuspendLayout();
            this.hotPanelRegister.SuspendLayout();
            this.hotGroupBox4.SuspendLayout();
            this.hotGroupBox5.SuspendLayout();
            this.hotGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.hotGroupBox2.SuspendLayout();
            this.hotGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hotPanel1
            // 
            this.hotPanel1.BackColor = System.Drawing.Color.White;
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Controls.Add(this.hotPanelRegister);
            this.hotPanel1.Controls.Add(this.lkbRegister);
            this.hotPanel1.Controls.Add(this.lbTipMsg);
            this.hotPanel1.Controls.Add(this.picClose);
            this.hotPanel1.Controls.Add(this.label1);
            this.hotPanel1.Controls.Add(this.ckbSavePwd);
            this.hotPanel1.Controls.Add(this.btnLogin);
            this.hotPanel1.Controls.Add(this.hotGroupBox2);
            this.hotPanel1.Controls.Add(this.hotGroupBox1);
            this.hotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel1.Location = new System.Drawing.Point(0, 0);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(284, 402);
            this.hotPanel1.TabIndex = 0;
            this.hotPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.hotPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.hotPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // hotPanelRegister
            // 
            this.hotPanelRegister.BorderColor = System.Drawing.Color.White;
            this.hotPanelRegister.Controls.Add(this.label5);
            this.hotPanelRegister.Controls.Add(this.lkbLogin);
            this.hotPanelRegister.Controls.Add(this.btnGetVerifyCode);
            this.hotPanelRegister.Controls.Add(this.btnRegister);
            this.hotPanelRegister.Controls.Add(this.label2);
            this.hotPanelRegister.Controls.Add(this.hotGroupBox4);
            this.hotPanelRegister.Controls.Add(this.hotGroupBox5);
            this.hotPanelRegister.Controls.Add(this.hotGroupBox3);
            this.hotPanelRegister.Location = new System.Drawing.Point(0, 39);
            this.hotPanelRegister.Name = "hotPanelRegister";
            this.hotPanelRegister.Size = new System.Drawing.Size(284, 361);
            this.hotPanelRegister.TabIndex = 112;
            this.hotPanelRegister.Visible = false;
            this.hotPanelRegister.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.hotPanelRegister.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.hotPanelRegister.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(164, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 114;
            this.label5.Text = "已有账号？";
            // 
            // lkbLogin
            // 
            this.lkbLogin.AutoSize = true;
            this.lkbLogin.Location = new System.Drawing.Point(233, 269);
            this.lkbLogin.Name = "lkbLogin";
            this.lkbLogin.Size = new System.Drawing.Size(29, 12);
            this.lkbLogin.TabIndex = 113;
            this.lkbLogin.TabStop = true;
            this.lkbLogin.Text = "登录";
            this.lkbLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkbLogin_LinkClicked);
            // 
            // btnGetVerifyCode
            // 
            this.btnGetVerifyCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnGetVerifyCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetVerifyCode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnGetVerifyCode.FlatAppearance.BorderSize = 0;
            this.btnGetVerifyCode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnGetVerifyCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(183)))), ((int)(((byte)(89)))));
            this.btnGetVerifyCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetVerifyCode.ForeColor = System.Drawing.Color.White;
            this.btnGetVerifyCode.Location = new System.Drawing.Point(170, 160);
            this.btnGetVerifyCode.Name = "btnGetVerifyCode";
            this.btnGetVerifyCode.Size = new System.Drawing.Size(93, 31);
            this.btnGetVerifyCode.TabIndex = 112;
            this.btnGetVerifyCode.Text = "获取验证码";
            this.btnGetVerifyCode.UseVisualStyleBackColor = false;
            this.btnGetVerifyCode.Click += new System.EventHandler(this.btnGetVerifyCode_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(183)))), ((int)(((byte)(89)))));
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(28, 215);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(233, 41);
            this.btnRegister.TabIndex = 112;
            this.btnRegister.Text = "注册";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.label2.Location = new System.Drawing.Point(67, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 24);
            this.label2.TabIndex = 111;
            this.label2.Text = "注册客服账号";
            // 
            // hotGroupBox4
            // 
            this.hotGroupBox4.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox4.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox4.Controls.Add(this.lbRegisterMobile);
            this.hotGroupBox4.Controls.Add(this.txtRegisterMobile);
            this.hotGroupBox4.Location = new System.Drawing.Point(29, 56);
            this.hotGroupBox4.Name = "hotGroupBox4";
            this.hotGroupBox4.Size = new System.Drawing.Size(233, 42);
            this.hotGroupBox4.TabIndex = 110;
            this.hotGroupBox4.TabStop = false;
            // 
            // lbRegisterMobile
            // 
            this.lbRegisterMobile.BackColor = System.Drawing.Color.Transparent;
            this.lbRegisterMobile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.lbRegisterMobile.Location = new System.Drawing.Point(12, 14);
            this.lbRegisterMobile.Name = "lbRegisterMobile";
            this.lbRegisterMobile.Size = new System.Drawing.Size(90, 22);
            this.lbRegisterMobile.TabIndex = 104;
            this.lbRegisterMobile.Text = "请输入手机号码";
            this.lbRegisterMobile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbRegisterMobile.Click += new System.EventHandler(this.lbRegisterMobile_Click);
            // 
            // txtRegisterMobile
            // 
            this.txtRegisterMobile.BackColor = System.Drawing.Color.White;
            this.txtRegisterMobile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRegisterMobile.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRegisterMobile.Location = new System.Drawing.Point(7, 17);
            this.txtRegisterMobile.Margin = new System.Windows.Forms.Padding(10);
            this.txtRegisterMobile.Name = "txtRegisterMobile";
            this.txtRegisterMobile.Size = new System.Drawing.Size(219, 16);
            this.txtRegisterMobile.TabIndex = 101;
            this.txtRegisterMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumber_KeyPress);
            this.txtRegisterMobile.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRegisterMobile_KeyDown);
            // 
            // hotGroupBox5
            // 
            this.hotGroupBox5.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox5.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox5.Controls.Add(this.lbVerifyCode);
            this.hotGroupBox5.Controls.Add(this.txtRegisterVerifyCode);
            this.hotGroupBox5.Location = new System.Drawing.Point(30, 151);
            this.hotGroupBox5.Name = "hotGroupBox5";
            this.hotGroupBox5.Size = new System.Drawing.Size(137, 42);
            this.hotGroupBox5.TabIndex = 110;
            this.hotGroupBox5.TabStop = false;
            // 
            // lbVerifyCode
            // 
            this.lbVerifyCode.BackColor = System.Drawing.Color.Transparent;
            this.lbVerifyCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.lbVerifyCode.Location = new System.Drawing.Point(11, 13);
            this.lbVerifyCode.Name = "lbVerifyCode";
            this.lbVerifyCode.Size = new System.Drawing.Size(78, 22);
            this.lbVerifyCode.TabIndex = 104;
            this.lbVerifyCode.Text = "请输入验证码";
            this.lbVerifyCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbVerifyCode.Click += new System.EventHandler(this.lbVerifyCode_Click);
            // 
            // txtRegisterVerifyCode
            // 
            this.txtRegisterVerifyCode.BackColor = System.Drawing.Color.White;
            this.txtRegisterVerifyCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRegisterVerifyCode.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRegisterVerifyCode.Location = new System.Drawing.Point(6, 17);
            this.txtRegisterVerifyCode.Margin = new System.Windows.Forms.Padding(10);
            this.txtRegisterVerifyCode.Name = "txtRegisterVerifyCode";
            this.txtRegisterVerifyCode.Size = new System.Drawing.Size(120, 16);
            this.txtRegisterVerifyCode.TabIndex = 101;
            this.txtRegisterVerifyCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRegisterVerifyCode_KeyDown);
            // 
            // hotGroupBox3
            // 
            this.hotGroupBox3.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox3.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox3.Controls.Add(this.lbRegisterPwd);
            this.hotGroupBox3.Controls.Add(this.txtRegisterPwd);
            this.hotGroupBox3.Location = new System.Drawing.Point(29, 104);
            this.hotGroupBox3.Name = "hotGroupBox3";
            this.hotGroupBox3.Size = new System.Drawing.Size(233, 42);
            this.hotGroupBox3.TabIndex = 110;
            this.hotGroupBox3.TabStop = false;
            // 
            // lbRegisterPwd
            // 
            this.lbRegisterPwd.BackColor = System.Drawing.Color.Transparent;
            this.lbRegisterPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.lbRegisterPwd.Location = new System.Drawing.Point(12, 15);
            this.lbRegisterPwd.Name = "lbRegisterPwd";
            this.lbRegisterPwd.Size = new System.Drawing.Size(67, 22);
            this.lbRegisterPwd.TabIndex = 104;
            this.lbRegisterPwd.Text = "请输入密码";
            this.lbRegisterPwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbRegisterPwd.Click += new System.EventHandler(this.lbRegisterPwd_Click);
            // 
            // txtRegisterPwd
            // 
            this.txtRegisterPwd.BackColor = System.Drawing.Color.White;
            this.txtRegisterPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRegisterPwd.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRegisterPwd.Location = new System.Drawing.Point(7, 17);
            this.txtRegisterPwd.Margin = new System.Windows.Forms.Padding(10);
            this.txtRegisterPwd.Name = "txtRegisterPwd";
            this.txtRegisterPwd.Size = new System.Drawing.Size(219, 16);
            this.txtRegisterPwd.TabIndex = 101;
            this.txtRegisterPwd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRegisterPwd_KeyDown);
            // 
            // lkbRegister
            // 
            this.lkbRegister.AutoSize = true;
            this.lkbRegister.Location = new System.Drawing.Point(229, 313);
            this.lkbRegister.Name = "lkbRegister";
            this.lkbRegister.Size = new System.Drawing.Size(29, 12);
            this.lkbRegister.TabIndex = 113;
            this.lkbRegister.TabStop = true;
            this.lkbRegister.Text = "注册";
            this.lkbRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkbRegister_LinkClicked);
            // 
            // lbTipMsg
            // 
            this.lbTipMsg.ForeColor = System.Drawing.Color.Red;
            this.lbTipMsg.Location = new System.Drawing.Point(3, 343);
            this.lbTipMsg.Name = "lbTipMsg";
            this.lbTipMsg.Size = new System.Drawing.Size(278, 54);
            this.lbTipMsg.TabIndex = 111;
            this.lbTipMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picClose
            // 
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::HotTaoMonitoring.Properties.Resources.icon_close1;
            this.picClose.Location = new System.Drawing.Point(255, 7);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(20, 20);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 110;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.label1.Location = new System.Drawing.Point(67, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 109;
            this.label1.Text = "登录客服系统";
            // 
            // ckbSavePwd
            // 
            this.ckbSavePwd.AutoSize = true;
            this.ckbSavePwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckbSavePwd.Location = new System.Drawing.Point(30, 313);
            this.ckbSavePwd.Name = "ckbSavePwd";
            this.ckbSavePwd.Size = new System.Drawing.Size(72, 16);
            this.ckbSavePwd.TabIndex = 108;
            this.ckbSavePwd.Text = "记住密码";
            this.ckbSavePwd.UseVisualStyleBackColor = true;
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
            this.btnLogin.Location = new System.Drawing.Point(29, 258);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(233, 41);
            this.btnLogin.TabIndex = 107;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox2.Controls.Add(this.lbLoginPwd);
            this.hotGroupBox2.Controls.Add(this.loginPwd);
            this.hotGroupBox2.Location = new System.Drawing.Point(25, 182);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(233, 42);
            this.hotGroupBox2.TabIndex = 106;
            this.hotGroupBox2.TabStop = false;
            // 
            // lbLoginPwd
            // 
            this.lbLoginPwd.BackColor = System.Drawing.Color.Transparent;
            this.lbLoginPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.lbLoginPwd.Location = new System.Drawing.Point(10, 13);
            this.lbLoginPwd.Name = "lbLoginPwd";
            this.lbLoginPwd.Size = new System.Drawing.Size(65, 22);
            this.lbLoginPwd.TabIndex = 103;
            this.lbLoginPwd.Text = "请输入密码";
            this.lbLoginPwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLoginPwd.Click += new System.EventHandler(this.lbLoginPwd_Click);
            // 
            // loginPwd
            // 
            this.loginPwd.BackColor = System.Drawing.Color.White;
            this.loginPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginPwd.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginPwd.Location = new System.Drawing.Point(6, 18);
            this.loginPwd.Margin = new System.Windows.Forms.Padding(10);
            this.loginPwd.Name = "loginPwd";
            this.loginPwd.Size = new System.Drawing.Size(219, 16);
            this.loginPwd.TabIndex = 101;
            this.loginPwd.UseSystemPasswordChar = true;
            this.loginPwd.Click += new System.EventHandler(this.lbLoginPwd_Click);
            this.loginPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loginPwd_KeyDown);
            this.loginPwd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.loginPwd_KeyDown);
            // 
            // hotGroupBox1
            // 
            this.hotGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox1.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox1.Controls.Add(this.lbLoginName);
            this.hotGroupBox1.Controls.Add(this.loginName);
            this.hotGroupBox1.Location = new System.Drawing.Point(25, 115);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(233, 42);
            this.hotGroupBox1.TabIndex = 105;
            this.hotGroupBox1.TabStop = false;
            // 
            // lbLoginName
            // 
            this.lbLoginName.BackColor = System.Drawing.Color.Transparent;
            this.lbLoginName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.lbLoginName.Location = new System.Drawing.Point(11, 13);
            this.lbLoginName.Name = "lbLoginName";
            this.lbLoginName.Size = new System.Drawing.Size(90, 22);
            this.lbLoginName.TabIndex = 104;
            this.lbLoginName.Text = "请输入手机号码";
            this.lbLoginName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLoginName.Click += new System.EventHandler(this.lbLoginName_Click);
            // 
            // loginName
            // 
            this.loginName.Cursor = System.Windows.Forms.Cursors.Default;
            this.loginName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.loginName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginName.FormattingEnabled = true;
            this.loginName.ItemHeight = 20;
            this.loginName.Location = new System.Drawing.Point(4, 12);
            this.loginName.Name = "loginName";
            this.loginName.Size = new System.Drawing.Size(226, 26);
            this.loginName.TabIndex = 102;
            this.loginName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.loginName_DrawItem);
            this.loginName.SelectedIndexChanged += new System.EventHandler(this.loginName_SelectedIndexChanged);
            this.loginName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loginName_KeyDown);
            this.loginName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.loginName_KeyDown);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 402);
            this.Controls.Add(this.hotPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录客户系统";
            this.Load += new System.EventHandler(this.Login_Load);
            this.hotPanel1.ResumeLayout(false);
            this.hotPanel1.PerformLayout();
            this.hotPanelRegister.ResumeLayout(false);
            this.hotPanelRegister.PerformLayout();
            this.hotGroupBox4.ResumeLayout(false);
            this.hotGroupBox4.PerformLayout();
            this.hotGroupBox5.ResumeLayout(false);
            this.hotGroupBox5.PerformLayout();
            this.hotGroupBox3.ResumeLayout(false);
            this.hotGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.hotGroupBox2.ResumeLayout(false);
            this.hotGroupBox2.PerformLayout();
            this.hotGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private module.HotPanel hotPanel1;
        private module.HotGroupBox hotGroupBox1;
        private System.Windows.Forms.Label lbLoginPwd;
        private System.Windows.Forms.Label lbLoginName;
        private System.Windows.Forms.ComboBox loginName;
        private module.HotGroupBox hotGroupBox2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox ckbSavePwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.TextBox loginPwd;
        private System.Windows.Forms.Label lbTipMsg;
        private module.HotPanel hotPanelRegister;
        private System.Windows.Forms.Label label2;
        private module.HotGroupBox hotGroupBox3;
        private System.Windows.Forms.TextBox txtRegisterPwd;
        private module.HotGroupBox hotGroupBox4;
        private System.Windows.Forms.TextBox txtRegisterMobile;
        private System.Windows.Forms.Label lbRegisterPwd;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.LinkLabel lkbLogin;
        private module.HotGroupBox hotGroupBox5;
        private System.Windows.Forms.TextBox txtRegisterVerifyCode;
        private System.Windows.Forms.Button btnGetVerifyCode;
        private System.Windows.Forms.Label lbRegisterMobile;
        private System.Windows.Forms.Label lbVerifyCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lkbRegister;
    }
}

