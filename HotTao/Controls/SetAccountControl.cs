using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HotTaoCore.Logic;
using HotCoreUtils.Helper;
using HotTaoCore.Models;
using HotTaoCore;

namespace HotTao.Controls
{
    /// <summary>
    /// 账号设置
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class SetAccountControl : UserControl
    {


        private Main hotForm { get; set; }
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

        public SetAccountControl(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }
        private void SetAccountControl_Load(object sender, EventArgs e)
        {
            this.IsRememberPassword = false;
            string lp = LoadLoginNameAndPwd();
            if (!string.IsNullOrEmpty(lp))
            {
                var arr = lp.Split('|');
                if (arr.Length > 2)
                {
                    loginName.Text = _tempLoginName = arr[0];
                    loginPwd.Text = _tempPassword = arr[1];
                    int isAutoLogin = 0;
                    int.TryParse(arr[2], out isAutoLogin);
                    this.ckbSavePwd.Checked = true;
                    this.ckbAutoLogin.Checked = isAutoLogin == 1 ? true : false;
                    this.IsRememberPassword = true;
                }
            }
        }


        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            try
            {
                string pwdStr = string.Empty;
                //判断是否记住密码
                if (this.ckbSavePwd.Checked || ckbAutoLogin.Checked)
                {
                    if (!string.IsNullOrEmpty(loginName.Text) && !string.IsNullOrEmpty(loginPwd.Text))
                    {
                        if (_tempPassword != loginPwd.Text || _tempLoginName != loginName.Text)
                        {
                            pwdStr = loginName.Text + "|" + EncryptHelper.MD5(loginPwd.Text) + "|" + (ckbAutoLogin.Checked ? "1" : "0");// ;                            
                        }
                        else
                        {
                            pwdStr = _tempLoginName + "|" + _tempPassword + "|" + (ckbAutoLogin.Checked ? "1" : "0");// ;          
                        }
                    }
                }
                RememberPassword(pwdStr);
            }
            catch (Exception ex)
            {

                SetText(ex.Message);
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
            MessageAlert alert = new MessageAlert(content);
            alert.ShowDialog(this);            
        }
    }
}
