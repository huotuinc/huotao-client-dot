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
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.hotGroupBox1 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.hotGroupBox6 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.txtTaobaoNo = new System.Windows.Forms.TextBox();
            this.hotGroupBox5 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.txtTaobaoPwd = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.hotGroupBox3 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.loginName = new System.Windows.Forms.TextBox();
            this.hotGroupBox4 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.loginPwd = new System.Windows.Forms.TextBox();
            this.hotGroupBox2 = new HotTao.Controls.module.HotGroupBox(this.components);
            this.hotGroupBox1.SuspendLayout();
            this.hotGroupBox6.SuspendLayout();
            this.hotGroupBox5.SuspendLayout();
            this.hotGroupBox3.SuspendLayout();
            this.hotGroupBox4.SuspendLayout();
            this.hotGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckbAutoLogin
            // 
            this.ckbAutoLogin.AutoSize = true;
            this.ckbAutoLogin.Location = new System.Drawing.Point(366, 120);
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
            this.ckbSavePwd.Location = new System.Drawing.Point(261, 120);
            this.ckbSavePwd.Name = "ckbSavePwd";
            this.ckbSavePwd.Size = new System.Drawing.Size(72, 16);
            this.ckbSavePwd.TabIndex = 11;
            this.ckbSavePwd.Text = "记住密码";
            this.ckbSavePwd.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(200, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "密码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(176, 36);
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
            this.label8.Location = new System.Drawing.Point(332, -4);
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
            this.hotGroupBox1.Controls.Add(this.hotGroupBox6);
            this.hotGroupBox1.Controls.Add(this.hotGroupBox5);
            this.hotGroupBox1.Controls.Add(this.btnLogin);
            this.hotGroupBox1.Controls.Add(this.label9);
            this.hotGroupBox1.Controls.Add(this.label10);
            this.hotGroupBox1.Controls.Add(this.label13);
            this.hotGroupBox1.Location = new System.Drawing.Point(10, 209);
            this.hotGroupBox1.Name = "hotGroupBox1";
            this.hotGroupBox1.Size = new System.Drawing.Size(730, 151);
            this.hotGroupBox1.TabIndex = 28;
            this.hotGroupBox1.TabStop = false;
            // 
            // hotGroupBox6
            // 
            this.hotGroupBox6.BackColor = System.Drawing.Color.White;
            this.hotGroupBox6.BorderColor = System.Drawing.Color.Silver;
            this.hotGroupBox6.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox6.Controls.Add(this.txtTaobaoNo);
            this.hotGroupBox6.Location = new System.Drawing.Point(249, 27);
            this.hotGroupBox6.Name = "hotGroupBox6";
            this.hotGroupBox6.Size = new System.Drawing.Size(189, 35);
            this.hotGroupBox6.TabIndex = 3;
            this.hotGroupBox6.TabStop = false;
            // 
            // txtTaobaoNo
            // 
            this.txtTaobaoNo.BackColor = System.Drawing.Color.White;
            this.txtTaobaoNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTaobaoNo.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTaobaoNo.Location = new System.Drawing.Point(4, 14);
            this.txtTaobaoNo.Margin = new System.Windows.Forms.Padding(10);
            this.txtTaobaoNo.Name = "txtTaobaoNo";
            this.txtTaobaoNo.Size = new System.Drawing.Size(176, 16);
            this.txtTaobaoNo.TabIndex = 0;
            // 
            // hotGroupBox5
            // 
            this.hotGroupBox5.BackColor = System.Drawing.Color.White;
            this.hotGroupBox5.BorderColor = System.Drawing.Color.Silver;
            this.hotGroupBox5.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox5.Controls.Add(this.txtTaobaoPwd);
            this.hotGroupBox5.Location = new System.Drawing.Point(249, 73);
            this.hotGroupBox5.Name = "hotGroupBox5";
            this.hotGroupBox5.Size = new System.Drawing.Size(189, 35);
            this.hotGroupBox5.TabIndex = 4;
            this.hotGroupBox5.TabStop = false;
            // 
            // txtTaobaoPwd
            // 
            this.txtTaobaoPwd.BackColor = System.Drawing.Color.White;
            this.txtTaobaoPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTaobaoPwd.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTaobaoPwd.Location = new System.Drawing.Point(4, 14);
            this.txtTaobaoPwd.Margin = new System.Windows.Forms.Padding(10);
            this.txtTaobaoPwd.Name = "txtTaobaoPwd";
            this.txtTaobaoPwd.Size = new System.Drawing.Size(176, 16);
            this.txtTaobaoPwd.TabIndex = 1;
            this.txtTaobaoPwd.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(105)))));
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(105)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(467, 40);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(141, 41);
            this.btnLogin.TabIndex = 16;
            this.btnLogin.Text = "模拟登陆";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label9.Location = new System.Drawing.Point(319, -4);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(5);
            this.label9.Size = new System.Drawing.Size(93, 22);
            this.label9.TabIndex = 14;
            this.label9.Text = "淘宝账户设置";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(176, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "淘宝账号";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(176, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 7;
            this.label13.Text = "淘宝密码";
            // 
            // hotGroupBox3
            // 
            this.hotGroupBox3.BackColor = System.Drawing.Color.White;
            this.hotGroupBox3.BorderColor = System.Drawing.Color.Silver;
            this.hotGroupBox3.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox3.Controls.Add(this.loginName);
            this.hotGroupBox3.Location = new System.Drawing.Point(249, 22);
            this.hotGroupBox3.Name = "hotGroupBox3";
            this.hotGroupBox3.Size = new System.Drawing.Size(189, 35);
            this.hotGroupBox3.TabIndex = 1;
            this.hotGroupBox3.TabStop = false;
            // 
            // loginName
            // 
            this.loginName.BackColor = System.Drawing.Color.White;
            this.loginName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginName.Location = new System.Drawing.Point(4, 14);
            this.loginName.Margin = new System.Windows.Forms.Padding(10);
            this.loginName.Name = "loginName";
            this.loginName.Size = new System.Drawing.Size(176, 16);
            this.loginName.TabIndex = 0;
            // 
            // hotGroupBox4
            // 
            this.hotGroupBox4.BackColor = System.Drawing.Color.White;
            this.hotGroupBox4.BorderColor = System.Drawing.Color.Silver;
            this.hotGroupBox4.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox4.Controls.Add(this.loginPwd);
            this.hotGroupBox4.Location = new System.Drawing.Point(249, 68);
            this.hotGroupBox4.Name = "hotGroupBox4";
            this.hotGroupBox4.Size = new System.Drawing.Size(189, 35);
            this.hotGroupBox4.TabIndex = 2;
            this.hotGroupBox4.TabStop = false;
            // 
            // loginPwd
            // 
            this.loginPwd.BackColor = System.Drawing.Color.White;
            this.loginPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginPwd.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginPwd.Location = new System.Drawing.Point(4, 14);
            this.loginPwd.Margin = new System.Windows.Forms.Padding(10);
            this.loginPwd.Name = "loginPwd";
            this.loginPwd.Size = new System.Drawing.Size(176, 16);
            this.loginPwd.TabIndex = 1;
            this.loginPwd.UseSystemPasswordChar = true;
            // 
            // hotGroupBox2
            // 
            this.hotGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.hotGroupBox2.BorderTitleColor = System.Drawing.Color.Black;
            this.hotGroupBox2.Controls.Add(this.hotGroupBox3);
            this.hotGroupBox2.Controls.Add(this.hotGroupBox4);
            this.hotGroupBox2.Controls.Add(this.label8);
            this.hotGroupBox2.Controls.Add(this.label6);
            this.hotGroupBox2.Controls.Add(this.ckbAutoLogin);
            this.hotGroupBox2.Controls.Add(this.label7);
            this.hotGroupBox2.Controls.Add(this.ckbSavePwd);
            this.hotGroupBox2.Location = new System.Drawing.Point(10, 12);
            this.hotGroupBox2.Name = "hotGroupBox2";
            this.hotGroupBox2.Size = new System.Drawing.Size(730, 169);
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
            this.Size = new System.Drawing.Size(750, 384);
            this.Load += new System.EventHandler(this.SetAccountControl_Load);
            this.hotGroupBox1.ResumeLayout(false);
            this.hotGroupBox1.PerformLayout();
            this.hotGroupBox6.ResumeLayout(false);
            this.hotGroupBox6.PerformLayout();
            this.hotGroupBox5.ResumeLayout(false);
            this.hotGroupBox5.PerformLayout();
            this.hotGroupBox3.ResumeLayout(false);
            this.hotGroupBox3.PerformLayout();
            this.hotGroupBox4.ResumeLayout(false);
            this.hotGroupBox4.PerformLayout();
            this.hotGroupBox2.ResumeLayout(false);
            this.hotGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox ckbAutoLogin;
        private System.Windows.Forms.CheckBox ckbSavePwd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private module.HotGroupBox hotGroupBox1;
        private module.HotGroupBox hotGroupBox2;
        private System.Windows.Forms.Button btnLogin;
        private module.HotGroupBox hotGroupBox3;
        private System.Windows.Forms.TextBox loginName;
        private module.HotGroupBox hotGroupBox4;
        private System.Windows.Forms.TextBox loginPwd;
        private module.HotGroupBox hotGroupBox6;
        private System.Windows.Forms.TextBox txtTaobaoNo;
        private module.HotGroupBox hotGroupBox5;
        private System.Windows.Forms.TextBox txtTaobaoPwd;
    }
}
