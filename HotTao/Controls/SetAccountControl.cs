using System;
using System.Windows.Forms;
using System.IO;

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
            var data = LogicHotTao.Instance(MyUserInfo.currentUserId).GetLoginName(MyUserInfo.userData.loginName);
            if (data != null)
            {
                loginName.Text = data.login_name;
                loginName.ReadOnly = true;
                loginPwd.ReadOnly = true;
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
