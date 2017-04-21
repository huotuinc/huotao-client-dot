using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HotCoreUtils.Helper;
using HotTaoCore.Logic;
using System.Threading;

namespace HotTao.Controls.Login
{
    public partial class RegisterPage : UserControl
    {
        NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        private Main hotForm { get; set; }
        private LoginControl loginForm { get; set; }
        public RegisterPage(Main mainWin, LoginControl loginWin)
        {
            InitializeComponent();
            hotForm = mainWin;
            loginForm = loginWin;
        }



        private void lbLoginName_Click(object sender, EventArgs e)
        {
            this.loginName.Focus();
        }

        private void lbLoginPwd_Click(object sender, EventArgs e)
        {
            this.loginPwd.Focus();
        }
        private void loginName_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(loginName.Text))
                lbLoginName.Visible = false;
            else
                lbLoginName.Visible = true;
        }

        private void loginPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(loginPwd.Text))
                lbLoginPwd.Visible = false;
            else
                lbLoginPwd.Visible = true;
        }


        private bool _isLogining = false;
        public bool loginSuccess { get; set; }

        public bool isLogining
        {
            get
            {
                return _isLogining;
            }

            set
            {
                _isLogining = value;
            }
        }


        public void AlertTip(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(AlertTip), new object[] { text });
            }
            else
            {
                MessageAlert alert = new MessageAlert(text, "提示");
                alert.StartPosition = FormStartPosition.CenterScreen;
                alert.Show(this);
            }
        }



        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (isLogining)
                    return;
                if (string.IsNullOrEmpty(loginName.Text))
                {
                    AlertTip("请输入登录账户");
                    loginName.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(loginPwd.Text))
                {
                    AlertTip("请输入登录密码!");
                    loginPwd.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtRegisterVerifyCode.Text))
                {
                    AlertTip("请输入验证码!");
                    txtRegisterVerifyCode.Focus();
                    return;
                }


                string lgname = loginName.Text;
                string pwd = EncryptHelper.MD5(loginPwd.Text);
                string verifyCode = txtRegisterVerifyCode.Text;
                string code = txtCode.Text;
                isLogining = true;
                Loading ld = new Loading();
                ((Action)(delegate ()
                {
                    var data = LogicUser.Instance.Register(lgname, pwd, verifyCode, (err) =>
                    {
                        if (err != null && err.resultCode != 200)
                        {
                            this.BeginInvoke((Action)(delegate ()  //等待结束
                            {
                                MessageAlert alert = new MessageAlert(err.resultMsg, "提示");
                                alert.StartPosition = FormStartPosition.CenterScreen;
                                alert.Show();
                            }));
                        }
                        isLogining = false;
                    }, code);
                    ld.CloseForm();
                    if (data != null)
                    {
                        AlertTip("注册成功!");
                        isLogining = false;
                        this.BeginInvoke((Action)(delegate ()  //等待结束
                        {
                            loginForm.openControl(new LoginPage(hotForm, loginForm));
                        }));
                    }                    
                })).BeginInvoke(null, null);
                ld.ShowDialog(this);
            }
            catch (Exception ex)
            {
                AlertTip("连接服务器失败!");
                log.Error(ex.Message);
            }
        }






        private void timeOut()
        {
            btnGetVerifyCode.BackColor = Color.Silver;
            new Thread(() =>
            {
                int s = 60;
                ShowTime(s);
                while (isSendVerifyCode)
                {
                    Thread.Sleep(1000);
                    --s;
                    if (s <= 0)
                        isSendVerifyCode = false;
                    ShowTime(s);
                }
            })
            { IsBackground = true }.Start();
        }


        public void ShowTime(int timeout)
        {
            if (this.btnGetVerifyCode.InvokeRequired)
            {
                this.btnGetVerifyCode.Invoke(new Action<int>(ShowTime), new object[] { timeout });
            }
            else
            {
                if (timeout > 0)
                    btnGetVerifyCode.Text = timeout.ToString() + "秒后再试";
                else
                {
                    btnGetVerifyCode.Text = "获取验证码";
                    btnGetVerifyCode.BackColor = Color.FromArgb(18, 216, 106);
                }
            }
        }






        private void lbVerifyCode_Click(object sender, EventArgs e)
        {
            txtRegisterVerifyCode.Focus();
        }
        private void txtRegisterVerifyCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRegisterVerifyCode.Text))
                lbVerifyCode.Visible = false;
            else
                lbVerifyCode.Visible = true;
        }

        private void lbCode_Click(object sender, EventArgs e)
        {
            txtCode.Focus();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCode.Text))
                lbCode.Visible = false;
            else
                lbCode.Visible = true;
        }
        private bool isSendVerifyCode { get; set; }
        private void btnGetVerifyCode_Click(object sender, EventArgs e)
        {
            if (isSendVerifyCode) return;
            if (string.IsNullOrEmpty(loginName.Text.Trim()) || loginName.Text.Trim().Length != 11)
            {
                AlertTip("请输入手机号码");
                return;
            }

            //获取
            if (LogicUser.Instance.sendCodeForRegister(loginName.Text.Trim()))
            {
                isSendVerifyCode = true;
                timeOut();
            }
            else
            {
                AlertTip("发送失败");
            }
        }
    }
}
