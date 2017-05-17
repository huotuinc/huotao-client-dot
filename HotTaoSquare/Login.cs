using CefSharp;
using CefSharp.WinForms;
using HotCoreUtils.Helper;
using HotTaoCore;
using HotTaoCore.Logic;
using HotTaoCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotTaoSquare
{
    public partial class Login : FormEx
    {

        #region 移动窗口
        /*
         * 首先将窗体的边框样式修改为None，让窗体没有标题栏
         * 实现这个效果使用了三个事件：鼠标按下、鼠标弹起、鼠标移动
         * 鼠标按下时更改变量isMouseDown标记窗体可以随鼠标的移动而移动
         * 鼠标移动时根据鼠标的移动量更改窗体的location属性，实现窗体移动
         * 鼠标弹起时更改变量isMouseDown标记窗体不可以随鼠标的移动而移动
         */
        private bool isMouseDown = false;
        private Point FormLocation;     //form的location
        private Point mouseOffset;      //鼠标的按下位置
        private void WinForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLocation = this.Location;
                mouseOffset = Control.MousePosition;
            }
        }

        private void WinForm_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
        private void WinForm_MouseMove(object sender, MouseEventArgs e)
        {
            int _x = 0;
            int _y = 0;
            if (isMouseDown)
            {
                Point pt = Control.MousePosition;
                _x = mouseOffset.X - pt.X;
                _y = mouseOffset.Y - pt.Y;

                this.Location = new Point(FormLocation.X - _x, FormLocation.Y - _y);
            }

        }
        #endregion


        public Login()
        {
            InitializeComponent();
            InitDataBase();
        }

        /// <summary>
        /// 是否记住密码
        /// </summary>
        private bool IsRememberPassword { get; set; }
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

        public ChromiumWebBrowser browser;

        /// <summary>
        /// 主界面
        /// </summary>
        public MainForm hotForm { get; set; }


        private void Login_Load(object sender, EventArgs e)
        {
            txtLoginMobile.Focus();
            var data = LogicHotTao.Instance(0).GetLoginNameList();
            if (data != null && data.Count() > 0)
            {
                txtLoginMobile.Text = data[0].login_name;
                this.ckbSavePwd.Checked = true;
                this.IsRememberPassword = true;
                lbLoginMobile.Visible = false;
                if (!string.IsNullOrEmpty(data[0].login_password) && data[0].is_save_pwd == 1)
                {
                    txtLoginPwd.Text = data[0].login_password;
                    lbLoginPwd.Visible = false;
                }
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbLoginName_Click(object sender, EventArgs e)
        {
            this.txtLoginMobile.Focus();
        }

        private void lbLoginPwd_Click(object sender, EventArgs e)
        {
            this.txtLoginPwd.Focus();
        }

        private void loginName_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLoginMobile.Text))
                lbLoginMobile.Visible = false;
            else
                lbLoginMobile.Visible = true;
        }

        private void loginPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLoginPwd.Text))
                lbLoginPwd.Visible = false;
            else
                lbLoginPwd.Visible = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginHandle();
        }

        public new void Close()
        {
            //关闭数据库连接            
            Application.ExitThread();
            Process.GetCurrentProcess().Kill();
        }

        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <returns>BuildDataBase.</returns>
        public void InitDataBase()
        {
            try
            {
                //初始化用户本地数据库
                string sourceFileName = System.Environment.CurrentDirectory + "\\data\\hottao.db";
                if (!System.IO.File.Exists(sourceFileName))
                {
                    MessageBox.Show("系统初始化失败", "错误");
                    this.Close();
                }
                string dbpath = System.Environment.CurrentDirectory + "\\data\\" + MyUserInfo.currentUserId;
                if (!System.IO.Directory.Exists(dbpath))
                    System.IO.Directory.CreateDirectory(dbpath);

                dbpath += "\\hottao.db";

                if (!System.IO.File.Exists(dbpath))
                {
                    System.IO.File.Copy(sourceFileName, dbpath);
                }


                //初始化商品同步数据库
                sourceFileName = System.Environment.CurrentDirectory + "\\data\\syncgoods.db";
                if (!System.IO.File.Exists(sourceFileName))
                {
                    MessageBox.Show("系统初始化失败", "错误");
                    this.Close();
                }
                dbpath = System.Environment.CurrentDirectory + "\\data\\" + MyUserInfo.currentUserId;
                if (!System.IO.Directory.Exists(dbpath))
                    System.IO.Directory.CreateDirectory(dbpath);

                dbpath += "\\syncgoods.db";
                if (!System.IO.File.Exists(dbpath))
                {
                    System.IO.File.Copy(sourceFileName, dbpath);
                }

            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }


        public void LoginHandle()
        {
            try
            {
                if (isLogining)
                    return;
                if (string.IsNullOrEmpty(txtLoginMobile.Text))
                {
                    lbTipMsg.Text = "请输入登录账户!";
                    return;
                }
                if (string.IsNullOrEmpty(txtLoginPwd.Text))
                {
                    lbTipMsg.Text = "请输入登录密码!";
                    txtLoginPwd.Focus();
                    return;
                }
                SavePwd = this.ckbSavePwd.Checked;
                AutoLogin = false;
                string pwd = string.Empty;
                pwd = EncryptHelper.MD5(txtLoginPwd.Text);
                lgname = txtLoginMobile.Text;
                lgpwd = txtLoginPwd.Text;
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
                    }, true);
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
                            if (data != null)
                            {
                                MyUserInfo my = new MyUserInfo();
                                my.SetUserData(data);
                                LogicHotTao.Instance(0).ClearLoginNameData();
                                LogicHotTao.Instance(0).AddLoginName(new SQLiteEntitysModel.LoginNameModel()
                                {
                                    userid = data.userid,
                                    login_name = data.loginName,
                                    login_password = lgpwd,
                                    is_save_pwd = SavePwd ? 1 : 0
                                });
                            }
                            this.BeginInvoke((Action)(delegate ()  //等待结束
                            {
                                this.Hide();
                                if (hotForm == null)
                                {
                                    hotForm = new MainForm(this);
                                    hotForm.StartPosition = FormStartPosition.CenterScreen;
                                    hotForm.Show();
                                }
                            }));
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
                            string t = "登录中，请稍后";
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
        /// 初始化浏览器
        /// </summary>
        public void InitBrowser(string url)
        {

            if (browser == null)
            {
                SetUserAgent();
                BrowserSettings settings = new BrowserSettings()
                {
                    LocalStorage = CefState.Enabled,
                    Javascript = CefState.Enabled,
                    Plugins = CefState.Enabled,
                    ImageLoading = CefState.Enabled,
                    ImageShrinkStandaloneToFit = CefState.Enabled,
                    WebGl = CefState.Enabled,
                };
                browser = new ChromiumWebBrowser(url);
                browser.BrowserSettings = settings;
                browser.RegisterJsObject("hotJs", new Login(), false);
                browser.Dock = DockStyle.Fill;
                browser.LifeSpanHandler = new LifeSpanHandler();
                browser.MenuHandler = new MenuHandler();
            }
            else
                browser.Load(url);
        }

        /// <summary>
        /// 重置浏览器
        /// </summary>
        public void ResetBrowser()
        {
            string currentUrl = "";
            if (browser != null)
            {
                currentUrl = browser.Address;
                browser.Dispose();
                browser = null;
            }
            InitBrowser(currentUrl);
        }

        /// <summary>
        /// 设置userAgent
        /// </summary>
        public void SetUserAgent()
        {
            CefSettings cfs = new CefSettings();
            Dictionary<string, string> formFields = new Dictionary<string, string>();
            //formFields["taobaoName"] = MyUserInfo.TaobaoName;
            formFields["token"] = MyUserInfo.LoginToken;
            //获取签名
            string signature = SignatureHelper.BuildSign(formFields, ApiConst.SecretKey);
            string param = string.Format("hottecexe:token={0}&signature={1};", MyUserInfo.LoginToken, signature);
            cfs.UserAgent = param + "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            Cef.Initialize(cfs, true, true);
        }



        #region 页面JS交互

        /// <summary>
        /// 淘宝账号
        /// </summary>
        /// <returns></returns>
        public string getTaobaoName()
        {
            return MyUserInfo.TaobaoName;
        }
        /// <summary>
        /// 获取淘宝cookie
        /// </summary>
        /// <returns></returns>
        public string getTaobaoCookies()
        {
            return MyUserInfo.cookieJson;
        }


        #endregion

        private void lkbRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(ApiConst.www);
        }
    }
    /// <summary>
    /// 控制右键菜单
    /// </summary>
    internal class MenuHandler : IContextMenuHandler
    {
        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            model.Clear();
            model.AddItem(CefMenuCommand.Back, "返回");
            model.AddItem(CefMenuCommand.Forward, "前进");
            model.AddItem(CefMenuCommand.Reload, "重新加载");

        }

        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            return false;
        }

        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {

        }

        public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }


    /// <summary>
    /// 禁止页面跳出浏览控件
    /// </summary>
    internal class LifeSpanHandler : ILifeSpanHandler
    {
        public bool DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            return false;
        }

        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public void OnBeforeClose(IWebBrowser browser)
        {

        }

        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {
        }

        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = browserControl;
            newBrowser.Load(targetUrl);
            return true;
        }
    }
}
