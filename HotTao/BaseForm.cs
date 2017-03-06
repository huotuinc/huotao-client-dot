using HotCoreUtils.Helper;
using HotTao.Controls;
using HotTaoCore;
using HotTaoCore.Logic;
using HotTaoCore.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HotTao
{
    public class BaseForm : Form
    {
        private RichTextBox txtTempDefaultText;

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
        public void CheckAutoLogin(Main hotForm, Action<UserModel> callback)
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
                    {
                        hotForm.openControl(new Logining());
                        ((Action)(delegate ()
                        {
                            AutoLogin(loginName, loginPwd, callback);

                        })).BeginInvoke(null, null);
                    }
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
        /// 获取文案
        /// </summary>
        public void GetDefaultTemplateText()
        {
            ((Action)(delegate ()
            {
                MyUserInfo.sendtemplate = LogicUser.Instance.GetUserSendTemplate(MyUserInfo.LoginToken);
                if (string.IsNullOrEmpty(MyUserInfo.sendtemplate))
                {
                    if (LogicUser.Instance.AddUserSendTemplate(MyUserInfo.LoginToken, MyUserInfo.defaultSendTempateText))
                        MyUserInfo.sendtemplate = MyUserInfo.defaultSendTempateText;
                }                
            })).BeginInvoke(null, null);
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
            if (data != null && data.activate == 1)
            {
                this.BeginInvoke((Action)(delegate ()  //等待结束
                {
                    callback?.Invoke(data);
                }));
            }
            else
            {
                this.BeginInvoke((Action)(delegate ()  //等待结束
                {
                    callback?.Invoke(null);
                }));
            }
        }

        private void InitializeComponent()
        {
            this.txtTempDefaultText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtTempDefaultText
            // 
            this.txtTempDefaultText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.txtTempDefaultText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTempDefaultText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtTempDefaultText.Location = new System.Drawing.Point(43, 36);
            this.txtTempDefaultText.Name = "txtTempDefaultText";
            this.txtTempDefaultText.ReadOnly = true;
            this.txtTempDefaultText.Size = new System.Drawing.Size(432, 263);
            this.txtTempDefaultText.TabIndex = 28;
            this.txtTempDefaultText.Text = "【[来源]】[商品标题]\n[分隔符]\n【原价】：[商品价格]元\n【券后】：[券后价格]元\n【口令】：[二合一淘口令]\n[分隔符]\n购买方式：复制这条信息，打开『手" +
    "机淘宝』即可看到商品和优惠券，先领券再下单哦\n[分隔符]\n本群都是内部优惠券，敬请大家关注每天特价产品。\n";
            this.txtTempDefaultText.Visible = false;
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(518, 334);
            this.Controls.Add(this.txtTempDefaultText);
            this.Name = "BaseForm";
            this.ResumeLayout(false);

        }
    }
}
