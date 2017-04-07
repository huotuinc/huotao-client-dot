using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HotCoreUtils.Helper;
using HotTaoCore.Logic;
using HotTaoCore.Models;
using HotTaoCore;
using System.Threading;

namespace HotTao.Controls.Login
{
    public partial class LoginPage : UserControl
    {
        NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        private Main hotForm { get; set; }
        private LoginControl loginForm { get; set; }
        public LoginPage(Main mainWin, LoginControl loginWin)
        {
            InitializeComponent();
            hotForm = mainWin;
            loginForm = loginWin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }



        /// <summary>
        /// 是否记住密码
        /// </summary>
        private bool IsRememberPassword { get; set; }
        /// <summary>
        /// 临时密码
        /// </summary>
        private string _tempPassword { get; set; }
        private string _tempLoginName { get; set; }

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
        private bool SavePwd { get; set; }
        private bool AutoLogin { get; set; }

        private string lgpwd = string.Empty;
        private string lgname = string.Empty;
        public void Login()
        {
            try
            {
                if (isLogining)
                    return;

                if (string.IsNullOrEmpty(loginName.Text))
                {
                    lbTipMsg.Text = "请输入登录账户!";
                    //loginName1.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(loginPwd.Text))
                {
                    lbTipMsg.Text = "请输入登录密码!";
                    loginPwd.Focus();
                    return;
                }
                SavePwd = this.ckbSavePwd.Checked;
                AutoLogin = ckbAutoLogin.Checked;
                string pwd = string.Empty;
                //if (this.IsRememberPassword && _tempPassword == loginPwd.Text && _tempLoginName == loginName.Text)
                //    pwd = loginPwd.Text;
                //else
                pwd = EncryptHelper.MD5(loginPwd.Text);

                lgname = loginName.Text;
                lgpwd = loginPwd.Text;
                loginSuccess = false;
                isLogining = true;
                ((Action)(delegate ()
                {
                    var data = LogicUser.Instance.login(lgname, pwd, (err) =>
                    {
                        if (err != null && err.resultCode != 200)
                        {
                            this.BeginInvoke((Action)(delegate ()  //等待结束
                            {
                                lbTipMsg.Text = err.resultMsg;
                            }));
                            isLogining = false;
                            loginSuccess = true;
                        }
                    });
                    if (data != null)
                    {
                        if (data.activate == 1)
                        {
                            loginSuccess = true;
                            isLogining = false;
                            this.BeginInvoke((Action)(delegate ()  //等待结束
                            {
                                lbTipMsg.Text = "登录成功，请稍后...";
                            }));
                            loginResult(data);
                            hotForm.ReloadBrowser(data.loginToken);

                            
                            new Thread(() =>
                            {
                                Thread.Sleep(3000);
                                hotForm.LoginTaoBao();
                            })
                            { IsBackground = true }.Start();

                        }
                        else
                        {
                            this.BeginInvoke((Action)(delegate ()  //等待结束
                            {
                                lbTipMsg.Text = "该账号已禁用，请联系管理员!";
                            }));
                            isLogining = false;
                            loginSuccess = true;
                        }
                    }
                })).BeginInvoke(null, null);

                ((Action)(delegate ()
                {
                    int c = 1;
                    while (!loginSuccess)
                    {
                        this.BeginInvoke((Action)(delegate ()  //等待结束
                        {
                            string t = "";
                            if (c == 1)
                                t = "登录中，请稍后.";
                            else if (c == 2)
                                t = "登录中，请稍后..";
                            else if (c == 3)
                            {
                                t = "登录中，请稍后...";
                                c = 0;
                            }
                            if (!loginSuccess)
                                lbTipMsg.Text = t;
                        }));
                        c++;
                        System.Threading.Thread.Sleep(1000);
                    }
                })).BeginInvoke(null, null);

            }
            catch (Exception ex)
            {
                loginSuccess = true;
                log.Error(ex);
                this.BeginInvoke((Action)(delegate ()  //等待结束
                {
                    lbTipMsg.Text = "连接服务器失败!";
                    isLogining = false;
                }));
            }
        }

        /// <summary>
        /// 登录结果处理
        /// </summary>
        /// <param name="data"></param>
        private void loginResult(UserModel data)
        {
            this.BeginInvoke((Action)(delegate ()  //等待结束
            {
                //设置登陆状态,必须先设置登录状态
                hotForm.SetLoginData(data);

                if (data != null)
                {
                    LogicHotTao.Instance(data.userid).AddLoginName(new SQLiteEntitysModel.LoginNameModel()
                    {
                        userid = data.userid,
                        login_name = data.loginName,
                        login_password = lgpwd,
                        is_save_pwd = SavePwd ? 1 : 0
                    });
                }                                
                hotForm.SetHomeTabSelected();
                hotForm.openControl(new GoodsControl(hotForm));
            }));

        }


        /// <summary>
        /// 加载账号和密码，如果之前登陆记者过密码时
        /// </summary>
        /// <returns></returns>
        public string LoadLoginNameAndPwd()
        {
            try
            {
                string filePath = System.IO.Path.Combine(Application.StartupPath, GlobalConfig.dbpath + ConstConfig.conf_user);
                if (File.Exists(filePath))
                {
                    FileStream aFile = new FileStream(filePath, FileMode.Open);
                    StreamReader sr = new StreamReader(aFile);
                    string str = sr.ReadToEnd();
                    sr.Close();
                    sr.Dispose();
                    aFile.Close();
                    aFile.Dispose();
                    return str;
                }
                return string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }


        /// <summary>
        /// 记住密码
        /// </summary>
        private void RememberPassword(string pwdStr)
        {
            string filePath = System.IO.Path.Combine(Application.StartupPath, GlobalConfig.dbpath);
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            filePath += ConstConfig.conf_user;
            if (!File.Exists(filePath))
                File.Create(filePath).Dispose();
            StreamWriter sw = new StreamWriter(@filePath, false);
            sw.Write(pwdStr);
            sw.Close();//写入
        }

        private void ckbAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAutoLogin.Checked)
                ckbSavePwd.Checked = true;
        }


        private void SetText(string content)
        {
            MessageBox.Show(content, "提示");
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

        private void LoginPage_Load(object sender, EventArgs e)
        {
            loginName.Focus();

            var data = LogicHotTao.Instance(MyUserInfo.currentUserId).GetLoginNameList();
            if (data != null && data.Count() > 0)
            {
                loginName.Text = data[0].login_name;
                this.ckbSavePwd.Checked = true;
                this.ckbAutoLogin.Checked = false;
                this.IsRememberPassword = true;
                lbLoginName.Visible = false;
                if (!string.IsNullOrEmpty(data[0].login_password) && data[0].is_save_pwd == 1)
                {
                    loginPwd.Text = data[0].login_password;

                    lbLoginPwd.Visible = false;
                }
                data.ForEach(item =>
                {
                    loginName.Items.Add(item.login_name);
                });
            }
        }

        private void lkRegister_Click(object sender, EventArgs e)
        {
            loginForm.openControl(new RegisterPage(hotForm, loginForm));
        }

        private void loginName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(loginName.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.X, e.Bounds.Y + 3);
        }

        /// <summary>
        /// 切换账号时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbLoginName.Visible = false;

            ComboBox cb = sender as ComboBox;

            var data = LogicHotTao.Instance(MyUserInfo.currentUserId).GetLoginName(cb.Text);

            if (data != null)
            {
                if (!string.IsNullOrEmpty(data.login_password) && data.is_save_pwd == 1)
                {
                    loginPwd.Text = data.login_password;
                    lbLoginPwd.Visible = false;
                }
            }

        }
    }
}
