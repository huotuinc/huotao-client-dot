using System;
using System.Windows.Forms;
using System.IO;
using HotCoreUtils.Helper;
using HotTaoCore;
using HotTaoCore.Logic;
using System.Linq;
namespace HotTao.Controls
{
    /// <summary>
    /// 账号设置
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class SetAccountControl : UserControl
    {
        NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

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
            //string lp = LoadLoginNameAndPwd();
            //if (!string.IsNullOrEmpty(lp))
            //{
            //    var arr = lp.Split('|');
            //    if (arr.Length > 2)
            //    {
            //        loginName.Text = MyUserInfo.userData.loginName;
            //        loginName.ReadOnly = true;
            //        loginPwd.ReadOnly = true;
            //        _tempLoginName = arr[0];
            //        // loginPwd.Text = MyUserInfo.userData.loginPwd;
            //        loginPwd.Text = _tempPassword = arr[1];
            //        int isAutoLogin = 0;
            //        int.TryParse(arr[2], out isAutoLogin);
            //        this.ckbSavePwd.Checked = true;
            //        this.ckbAutoLogin.Checked = isAutoLogin == 1 ? true : false;
            //        this.IsRememberPassword = true;
            //    }
            //}



            var data = LogicHotTao.Instance(MyUserInfo.currentUserId).GetLoginName(MyUserInfo.userData.loginName);
            if (data != null)
            {
                loginName.Text = data.login_name;
                this.ckbSavePwd.Checked = data.is_save_pwd == 1;
                this.ckbAutoLogin.Checked = false;
                this.IsRememberPassword = true;
                if (!string.IsNullOrEmpty(data.login_password) && data.is_save_pwd == 1)
                {
                    loginPwd.Text = data.login_password;
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
                //string pwdStr = string.Empty;
                //bool isUpdate = false;
                ////判断是否记住密码
                //if (this.ckbSavePwd.Checked || ckbAutoLogin.Checked)
                //{
                //    if (!string.IsNullOrEmpty(loginName.Text) && !string.IsNullOrEmpty(loginPwd.Text))
                //    {
                //        if (_tempPassword != loginPwd.Text || _tempLoginName != loginName.Text)
                //        {
                //            pwdStr = loginName.Text + "|" + EncryptHelper.MD5(loginPwd.Text) + "|" + (ckbAutoLogin.Checked ? "1" : "0");// ;       
                //            isUpdate = true;
                //        }
                //        else
                //        {
                //            pwdStr = _tempLoginName + "|" + _tempPassword + "|" + (ckbAutoLogin.Checked ? "1" : "0");// ;          
                //        }
                //    }
                //}
                //RememberPassword(pwdStr);
                //if (isUpdate)
                //    hotForm.SetLoginData(null);


                LogicHotTao.Instance(MyUserInfo.currentUserId).AddLoginName(new HotTaoCore.Models.SQLiteEntitysModel.LoginNameModel()
                {
                    userid = MyUserInfo.currentUserId,
                    login_name = loginName.Text,
                    login_password = loginPwd.Text,
                    is_save_pwd = this.ckbSavePwd.Checked ? 1 : 0
                });

                ShowAlert("保存成功");
            }
            catch (Exception ex)
            {
                log.Error(ex);
                ShowAlert("保存失败");
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
            catch (Exception ex)
            {
                log.Error(ex);
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


        private void ShowAlert(string content)
        {
            MessageAlert alert = new MessageAlert(content);
            alert.ShowDialog(this);
        }
    }
}
