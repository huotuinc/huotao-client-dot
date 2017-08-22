namespace TBSync
{
    partial class LoginWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginWindow));
            this.hotPanel1 = new TBSync.HotPanel(this.components);
            this.gbLoginTaobao = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoginTaobao = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTbLoginName = new System.Windows.Forms.TextBox();
            this.txtTbLoginPwd = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnQrCodeLogin = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.tbPanel = new System.Windows.Forms.Panel();
            this.hotPanel1.SuspendLayout();
            this.gbLoginTaobao.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // hotPanel1
            // 
            this.hotPanel1.BackColor = System.Drawing.Color.White;
            this.hotPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.hotPanel1.Controls.Add(this.gbLoginTaobao);
            this.hotPanel1.Controls.Add(this.groupBox1);
            this.hotPanel1.Controls.Add(this.panel1);
            this.hotPanel1.Controls.Add(this.tbPanel);
            this.hotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotPanel1.Location = new System.Drawing.Point(0, 0);
            this.hotPanel1.Name = "hotPanel1";
            this.hotPanel1.Size = new System.Drawing.Size(528, 483);
            this.hotPanel1.TabIndex = 0;
            // 
            // gbLoginTaobao
            // 
            this.gbLoginTaobao.Controls.Add(this.label2);
            this.gbLoginTaobao.Controls.Add(this.btnLoginTaobao);
            this.gbLoginTaobao.Controls.Add(this.label1);
            this.gbLoginTaobao.Controls.Add(this.txtTbLoginName);
            this.gbLoginTaobao.Controls.Add(this.txtTbLoginPwd);
            this.gbLoginTaobao.Location = new System.Drawing.Point(0, 30);
            this.gbLoginTaobao.Name = "gbLoginTaobao";
            this.gbLoginTaobao.Size = new System.Drawing.Size(529, 393);
            this.gbLoginTaobao.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "淘宝密码：";
            // 
            // btnLoginTaobao
            // 
            this.btnLoginTaobao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLoginTaobao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoginTaobao.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnLoginTaobao.FlatAppearance.BorderSize = 0;
            this.btnLoginTaobao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(216)))), ((int)(((byte)(106)))));
            this.btnLoginTaobao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(183)))), ((int)(((byte)(89)))));
            this.btnLoginTaobao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginTaobao.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoginTaobao.ForeColor = System.Drawing.Color.White;
            this.btnLoginTaobao.Location = new System.Drawing.Point(181, 182);
            this.btnLoginTaobao.Name = "btnLoginTaobao";
            this.btnLoginTaobao.Size = new System.Drawing.Size(169, 38);
            this.btnLoginTaobao.TabIndex = 4;
            this.btnLoginTaobao.Text = "登     录";
            this.btnLoginTaobao.UseVisualStyleBackColor = false;
            this.btnLoginTaobao.Click += new System.EventHandler(this.btnLoginTaobao_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "淘宝账号：";
            // 
            // txtTbLoginName
            // 
            this.txtTbLoginName.Location = new System.Drawing.Point(190, 86);
            this.txtTbLoginName.Name = "txtTbLoginName";
            this.txtTbLoginName.Size = new System.Drawing.Size(206, 21);
            this.txtTbLoginName.TabIndex = 0;
            // 
            // txtTbLoginPwd
            // 
            this.txtTbLoginPwd.Location = new System.Drawing.Point(190, 132);
            this.txtTbLoginPwd.Name = "txtTbLoginPwd";
            this.txtTbLoginPwd.PasswordChar = '*';
            this.txtTbLoginPwd.Size = new System.Drawing.Size(206, 21);
            this.txtTbLoginPwd.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnQrCodeLogin);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(12, 427);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 49);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "登录方式";
            // 
            // rbtnQrCodeLogin
            // 
            this.rbtnQrCodeLogin.AutoSize = true;
            this.rbtnQrCodeLogin.Location = new System.Drawing.Point(157, 22);
            this.rbtnQrCodeLogin.Name = "rbtnQrCodeLogin";
            this.rbtnQrCodeLogin.Size = new System.Drawing.Size(107, 16);
            this.rbtnQrCodeLogin.TabIndex = 0;
            this.rbtnQrCodeLogin.Tag = "2";
            this.rbtnQrCodeLogin.Text = "二维码扫描登录";
            this.rbtnQrCodeLogin.UseVisualStyleBackColor = true;
            this.rbtnQrCodeLogin.CheckedChanged += new System.EventHandler(this.TaobaoLogin_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(42, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(95, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "1";
            this.radioButton1.Text = "模拟自动登录";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.TaobaoLogin_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(108)))), ((int)(((byte)(172)))));
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Controls.Add(this.pbClose);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 30);
            this.panel1.TabIndex = 8;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WinForm_MouseUp);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(10, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(77, 12);
            this.lbTitle.TabIndex = 7;
            this.lbTitle.Text = "登录淘宝联盟";
            // 
            // pbClose
            // 
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = global::TBSync.Properties.Resources.icon_close;
            this.pbClose.Location = new System.Drawing.Point(501, 5);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(20, 20);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbClose.TabIndex = 6;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // tbPanel
            // 
            this.tbPanel.Location = new System.Drawing.Point(1, 30);
            this.tbPanel.Name = "tbPanel";
            this.tbPanel.Size = new System.Drawing.Size(528, 393);
            this.tbPanel.TabIndex = 9;
            // 
            // LoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 483);
            this.Controls.Add(this.hotPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录淘宝";
            this.Load += new System.EventHandler(this.LoginWindow_Load);
            this.hotPanel1.ResumeLayout(false);
            this.gbLoginTaobao.ResumeLayout(false);
            this.gbLoginTaobao.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private HotPanel hotPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.Panel tbPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnQrCodeLogin;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox txtTbLoginPwd;
        private System.Windows.Forms.TextBox txtTbLoginName;
        private System.Windows.Forms.Button btnLoginTaobao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel gbLoginTaobao;
    }
}

