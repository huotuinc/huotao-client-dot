using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HotTaoCore.Logic;
using HotTaoCore.Models;
using HotCoreUtils.Helper;
using System.IO;
using HotTaoCore;

namespace HotTao.Controls
{
    public partial class BaseForm : UserControl
    {
        public BaseForm()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 加载账号和密码，如果之前登陆记者过密码时
        /// </summary>
        /// <returns></returns>
        private string LoadLoginNameAndPwd()
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
        /// 检查登录
        /// </summary>
        /// <param name="callback">The callback.</param>
        public void CheckAutoLogin(Action<UserModel> callback)
        {
            string lp = LoadLoginNameAndPwd();
            if (!string.IsNullOrEmpty(lp))
            {
                var arr = lp.Split('|');
                if (arr.Length > 2)
                {
                    string loginName = arr[0];
                    string loginPwd = arr[1];
                    int isAutoLogin = 0;
                    int.TryParse(arr[2], out isAutoLogin);
                    //自动登录
                    if (isAutoLogin == 1)
                        AutoLogin(loginName, loginPwd, callback);
                    else
                        callback?.Invoke(null);

                }
                else
                    callback?.Invoke(null);
            }
            else
                callback?.Invoke(null);

        }

        /// <summary>
        /// 自动登录
        /// </summary>
        /// <param name="loginName">Name of the login.</param>
        /// <param name="loginPwd">The login password.</param>
        /// <param name="callback">The callback.</param>
        private void AutoLogin(string loginName, string loginPwd, Action<UserModel> callback)
        {
            var data = LogicUser.Instance.login(loginName, loginPwd);
            if (data.activate == 1)
            {
                data = loginResult(data);
                callback?.Invoke(data);
            }
            else
            {
                callback?.Invoke(null);
            }
        }

        /// <summary>
        /// 登录结果处理
        /// </summary>
        /// <param name="data"></param>
        private UserModel loginResult(UserModel data)
        {
            string loginToken = EncryptHelper.MD5(StringHelper.CreateCheckCodeWithNum(10));
            //更新登陆loginToken
            if (LogicUser.Instance.RefreshLoginToken(data.userid, loginToken))
            {
                data.loginToken = loginToken;
            }
            return data;
        }


    }
}
