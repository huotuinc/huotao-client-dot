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

namespace HotTao.Controls.Login
{
    public partial class LoginPage : UserControl
    {
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
        public bool isLogining = false;
        public void Login()
        {
            try
            {
                if (isLogining)
                    return;
                if (string.IsNullOrEmpty(loginName.Text))
                {
                    loginName.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(loginPwd.Text))
                {
                    loginPwd.Focus();
                    return;
                }

                string pwd = string.Empty;
                if (this.IsRememberPassword && _tempPassword == loginPwd.Text && _tempLoginName == loginName.Text)
                    pwd = loginPwd.Text;
                else
                    pwd = EncryptHelper.MD5(loginPwd.Text);

                string lgname = loginName.Text;
                var data = LogicUser.Instance.login(lgname, pwd);
                if (data != null)
                {
                    if (data.activate == 1)
                    {
                        loginResult(data);
                    }
                    else
                    {
                        SetText("该账号已禁用，请联系管理员!");
                        return;
                    }
                }
                else
                {
                    SetText("账号或密码不正确");

                }

            }
            catch (Exception ex)
            {

                SetText(ex.Message);
            }
        }

        /// <summary>
        /// 登录结果处理
        /// </summary>
        /// <param name="data"></param>
        private void loginResult(UserModel data)
        {
            string loginToken = EncryptHelper.MD5(StringHelper.CreateCheckCodeWithNum(10));
            //更新登陆loginToken
            if (LogicUser.Instance.RefreshLoginToken(data.userid, loginToken))
            {
                data.loginToken = loginToken;
                //设置登陆状态,必须先设置登录状态
                this.hotForm.SetLoginData(data);

                //判断是否记住密码
                if (this.ckbSavePwd.Checked || ckbAutoLogin.Checked)
                {
                    if (_tempPassword != loginPwd.Text || _tempLoginName != loginName.Text)
                    {
                        string pwdStr = loginName.Text + "|" + EncryptHelper.MD5(loginPwd.Text) + "|" + (ckbAutoLogin.Checked ? "1" : "0");// ;
                        RememberPassword(pwdStr);
                    }
                }
                else
                    RememberPassword("");



                hotForm.openControl(new TaskControl(hotForm));

            }
        }


        /// <summary>
        /// 加载账号和密码，如果之前登陆记者过密码时
        /// </summary>
        /// <returns></returns>
        public string LoadLoginNameAndPwd()
        {
            try
            {
                string filePath = System.IO.Path.Combine(Application.StartupPath, GlobalConfig.dbpath + "/lp.hot");
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
            filePath += "/lp.hot";
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
    }
}
