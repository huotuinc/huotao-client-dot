using CefSharp;
using CefSharp.WinForms;
using HOTReuestService;
using HotTao.Controls;
using HotTao.Properties;
using HotTaoCore;
using HotTaoCore.Enums;
using HotTaoCore.Logic;
using HotTaoCore.Models;
using Newtonsoft.Json;
using QQLogin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Windows.Forms;

namespace HotTao
{
    public partial class Main : BaseForm
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
            if (myMenu != null)
            {
                myMenu.Close();
                myMenu = null;
            }
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLocation = this.Location;
                mouseOffset = Control.MousePosition;
            }
        }

        private void WinForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (myMenu != null)
            {
                myMenu.Close();
                myMenu = null;
            }
            isMouseDown = false;
        }
        private void WinForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (myMenu != null)
            {
                myMenu.Close();
                myMenu = null;
            }
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


        NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();


        /// <summary>
        /// 淘宝账号
        /// </summary>
        /// <value>The taobao no.</value>
        public string taobaoNo { get; set; }
        /// <summary>
        /// 淘宝密码
        /// </summary>
        public string taobaoPwd { set; get; }

        /// <summary>
        /// 微信登录窗口对象
        /// </summary>
        public wxLogin wxlogin { get; set; }

        /// <summary>
        /// 任务窗口
        /// </summary>
        /// <value>The win task.</value>
        public StartTask winTask { get; set; }

        /// <summary>
        /// 我的配置信息
        /// </summary>
        /// <value>My configuration.</value>
        public ConfigModel myConfig { get; set; }

        /// <summary>
        /// token是否有效
        /// </summary>
        public bool isTokenValid { get; set; }

        /// <summary>
        /// 申请总数量
        /// </summary>
        public int ApplyTotal { get; set; }

        /// <summary>
        /// 申请完成数量
        /// </summary>
        public int ApplyFinishCount { get; set; }


        /// <summary>
        /// 运行日志
        /// </summary>
        public List<LogRuningModel> logRuningList { get; set; }

        public ChromiumWebBrowser browser;

        /// <summary>
        /// 
        /// </summary>
        public BackgroundWorker worker;

        public Main()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Main_Load(object sender, EventArgs e)
        {
            SetWinFormTaskbarSystemMenu();
            //检查更新
            CheckVersion();
            //初始化数据库
            InitDataBase();

            InitBrowser("");
            openControl(new LoginControl(this));

            if (logRuningList == null)
                logRuningList = new List<LogRuningModel>();

            if (worker != null)
            {
                worker.Dispose();
                worker = null;
            }
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
        }

        public GoodsCollectBrowser collectBrowser { get; set; }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string url = e.Argument.ToString();
            CollectBrowserShow(url);
        }

        /// <summary>
        /// 打开采集浏览器
        /// </summary>
        /// <param name="url"></param>
        private void CollectBrowserShow(string url)
        {
            if (!string.IsNullOrEmpty(url) && url.Equals("http://www.dataoke.com"))
                url = "http://www.dataoke.com/qlist/";
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(CollectBrowserShow), new object[] { url });
            }
            else
            {
                if (collectBrowser != null)
                    collectBrowser.LoadBrowser(url);
                else
                {
                    collectBrowser = new GoodsCollectBrowser(this, url);
                    collectBrowser.StartPosition = FormStartPosition.CenterScreen;
                    collectBrowser.Show(this);
                }
            }
        }




        /// <summary>
        /// Checks the version.
        /// </summary>
        private void CheckVersion()
        {
            new System.Threading.Thread(() =>
            {
                int v = this.GetCurrentClientVersion();
                if (v > 0)
                {
                    var version = HotTaoApiService.Instance.CheckVersion(v);
                    if (version != null)
                        ShowConfirm(version);
                }
            })
            { IsBackground = true }.Start();
        }

        private void ShowConfirm(VersionModel version)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<VersionModel>(ShowConfirm), new object[] { version });
            }
            else
            {
                bool isUpdate = false;
                MessageConfirm cfr = new MessageConfirm("发现新版本，是否马上下载更新?");
                cfr.CallBack += () =>
                {
                    isUpdate = true;
                };
                cfr.StartPosition = FormStartPosition.CenterScreen;
                cfr.ShowDialog();
                if (isUpdate)
                {
                    Process.Start("CheckUpdate.exe");
                    CloseMain();
                }
            }
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
                string sourceFileName = System.Environment.CurrentDirectory + "\\data\\fdgs.db";
                if (!System.IO.File.Exists(sourceFileName))
                {
                    MessageAlert alert = new MessageAlert("系统初始化失败");
                    alert.CallBack += () =>
                    {
                        this.Close();
                    };
                    alert.ShowDialog(this);
                }
                string dbpath = System.Environment.CurrentDirectory + "\\data\\" + MyUserInfo.currentUserId;
                if (!System.IO.Directory.Exists(dbpath))
                    System.IO.Directory.CreateDirectory(dbpath);

                dbpath += "\\fdgs.db";

                if (!System.IO.File.Exists(dbpath))
                {
                    System.IO.File.Copy(sourceFileName, dbpath);
                }

                //初始化商品同步数据库
                sourceFileName = System.Environment.CurrentDirectory + "\\data\\syncgoods.db";
                if (!System.IO.File.Exists(sourceFileName))
                {
                    //MessageBox.Show("系统初始化失败", "错误");
                    MessageAlert alert = new MessageAlert("系统初始化失败");
                    alert.CallBack += () =>
                    {
                        this.Close();
                    };
                    alert.ShowDialog(this);
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




        /// <summary>
        /// 加载用户配置信息
        /// </summary>
        public void LoadMyConfig()
        {
            ((Action)(delegate ()
            {
                myConfig = LogicUser.Instance.GetConfigModel(MyUserInfo.LoginToken);


                if (myConfig != null)
                {
                    ConfigSendTimeModel cfgTime = string.IsNullOrEmpty(myConfig.send_time_config) ? null : JsonConvert.DeserializeObject<ConfigSendTimeModel>(myConfig.send_time_config);
                    if (cfgTime != null)
                    {
                        MyUserInfo.sendmode = cfgTime.sendmode;
                    }
                }
            })).BeginInvoke(null, null);
        }



        /// <summary>
        /// 初始化商品库
        /// </summary>
        public void InitBrowser(string token)
        {
            new System.Threading.Thread(() =>
            {
                browser = new ChromiumWebBrowser(token);
                browser.RegisterJsObject("jsGoods", new GoodsControl(this), false);
                BrowserSettings settings = new BrowserSettings()
                {
                    LocalStorage = CefState.Enabled,
                    Javascript = CefState.Enabled,
                };
                browser.BrowserSettings = settings;
                browser.Size = new Size(920, 607);
                browser.Location = new Point(1, 0);
            })
            { IsBackground = true }.Start();
        }

        public void ReloadBrowser(string token)
        {
            if (browser != null)
                browser.Load(ApiConst.Url + "/goods/goodListPage?viewMode=2&token=" + token);
            else
                InitBrowser(ApiConst.Url + "/goods/goodListPage?viewMode=2&token=" + token);
        }


        //无标题窗体右键菜单
        private const int WS_SYSMENU = 0x00080000; // 系统菜单
        private const int WS_MINIMIZEBOX = 0x20000; // 最大最小化按钮

        //下面几个是设置窗口阴影
        private const int CS_DropSHADOW = 0x20000;
        private const int GCL_STYLE = (-26);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        /// <summary>
        /// 无边框样式的winform窗口，需要单独设置，才能启用任务栏的系统菜单功能，
        /// </summary>
        private void SetWinFormTaskbarSystemMenu()
        {
            int windowLong = (WinApi.GetWindowLong(new HandleRef(this, this.Handle), -16));
            WinApi.SetWindowLong(new HandleRef(this, this.Handle), -16, windowLong | WS_SYSMENU | WS_MINIMIZEBOX);
            //设置阴影
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW);
        }


        /// <summary>
        /// 检查登录状态
        /// </summary>
        /// <returns></returns>
        public bool CheckLogin()
        {
            try
            {
                if (LogicUser.Instance.getUserInfoByToken(MyUserInfo.LoginToken))
                {
                    LoginSync = true;
                    return true;
                }
                HotJavaApi.SendUserNotice(MyUserInfo.LoginToken, WeChatTemplateMessageSceneType.客户端离线);
                LogicUser.CheckTokenErrorCount = 0;
                LoginSync = false;
                this.BeginInvoke((Action)(delegate ()  //等待结束
                {
                    MyUserInfo my = new MyUserInfo();
                    my.SetUserData(null);
                    if (wxlogin != null)
                    {
                        wxlogin.isStartTask = false;
                        wxlogin.isCloseWinForm = true;
                        wxlogin.Close();
                        wxlogin = null;
                    }
                    if (winTask != null)
                    {
                        winTask.isStartTask = false;
                        winTask.Close();
                        winTask = null;
                    }
                    openControl(new LoginControl(this));
                }));


                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnHome_Click(object sender, EventArgs e)
        {
            SetSelectedBackgroundImage(sender);
            openControl(new GoodsControl(this));
        }

        /// <summary>
        /// 微信群发
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnWeChat_Click(object sender, EventArgs e)
        {
            SetSelectedBackgroundImage(sender);
            openControl(new TaskControl(this));
        }


        /// <summary>
        /// 销毁Panel
        /// </summary>
        private void DisPanel()
        {
            foreach (UserControl uc in this.HotContainer.Panel2.Controls)
            {
                if (uc != null)
                    uc.Dispose();
            }
        }
        /// <summary>
        /// 设置面板
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSetting_Click(object sender, EventArgs e)
        {
            SetSelectedBackgroundImage(sender);
            openControl(new SetControl(this));
        }

        /// <summary>
        /// 计划列表
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnHistory_Click(object sender, EventArgs e)
        {
            SetSelectedBackgroundImage(sender);
            openControl(new HistoryControl(this));
        }

        /// <summary>
        /// 客服
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnCustomService_Click(object sender, EventArgs e)
        {
            SetSelectedBackgroundImage(sender);
            openControl(new CustomServiceControl(this));
        }

        /// <summary>
        /// 设置当前选中tab的背景图片
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void SetSelectedBackgroundImage(object sender)
        {
            foreach (var item in HotContainer.Panel1.Controls)
            {
                Panel pl = item as Panel;
                if (pl != null)
                {
                    pl.BackgroundImage = null;
                    pl.BackColor = ConstConfig.HeaderBackColor;
                }
            }
            var p1 = sender as PictureBox;
            var p2 = sender as Label;
            var p3 = sender as Panel;
            if (p1 != null)
            {
                p1.Parent.BackgroundImage = Properties.Resources.icon_bg;
                p1.Parent.BackColor = Color.Transparent;
            }
            else if (p2 != null)
            {
                p2.Parent.BackgroundImage = Properties.Resources.icon_bg;
                p2.Parent.BackColor = Color.Transparent;
            }
            else if (p3 != null)
            {
                p3.BackgroundImage = Properties.Resources.icon_bg;
                p3.BackColor = Color.Transparent;
            }
        }


        /// <summary>
        /// 打开指定用户控件
        /// </summary>
        /// <param name="uc">The uc.</param>
        public void openControl(UserControl uc)
        {
            this.BeginInvoke((Action)(delegate ()  //等待结束
            {
                HotContainer.Panel2.Controls.Clear();
                uc.Dock = DockStyle.Fill;
                this.HotContainer.Panel2.Controls.Add(uc);
            }));
        }


        /// <summary>
        /// 设置微信群发为选中状态
        /// </summary>
        public void SetWeChatTabSelected()
        {
            foreach (var item in HotContainer.Panel1.Controls)
            {
                Panel pl = item as Panel;
                if (pl != null)
                {
                    pl.BackgroundImage = null;
                    pl.BackColor = ConstConfig.HeaderBackColor;
                }
            }
            btnWeChat.Parent.BackgroundImage = Properties.Resources.icon_bg;
            btnWeChat.Parent.BackColor = Color.Transparent;
        }
        /// <summary>
        /// 设置首页为选中状态
        /// </summary>
        public void SetHomeTabSelected()
        {
            foreach (var item in HotContainer.Panel1.Controls)
            {
                Panel pl = item as Panel;
                if (pl != null)
                {
                    pl.BackgroundImage = null;
                    pl.BackColor = ConstConfig.HeaderBackColor;
                }
            }
            btnHome.Parent.BackgroundImage = Properties.Resources.icon_bg;
            btnHome.Parent.BackColor = Color.Transparent;
        }

        public bool LoginSync = false;

        /// <summary>
        /// 设置登录用户数据
        /// </summary>
        /// <param name="user"></param>
        public void SetLoginData(UserModel user)
        {
            MyUserInfo my = new MyUserInfo();
            my.SetUserData(user);
            if (user != null)
            {
                LoginSync = true;
                MyUserInfo.currentUserId = user.userid;

                LoadMyConfig();
                GetDefaultTemplateText();
                InitDataBase();
                ((Action)(delegate ()
                {
                    while (LoginSync)
                    {
                        CheckLogin();
                        System.Threading.Thread.Sleep(10000);
                    }
                })).BeginInvoke(null, null);
            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_MINIMIZEBOX = 0x00020000;  // Winuser.h中定义
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style | WS_MINIMIZEBOX;   // 允许最小化操作
                return cp;
            }
        }

        /// <summary>
        /// 帮助
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pbHelp_Click(object sender, EventArgs e)
        {
            SetSelectedBackgroundImage(sender);
            if (MyUserInfo.currentUserId > 0)
            {
                LoginQQ();

            }
            else
                openControl(new LoginControl(this));

        }


        private void pbCustom_Click(object sender, EventArgs e)
        {
            SetSelectedBackgroundImage(sender);
            openControl(new CustomSendControl(this));
        }





        public Loading LoadingShow { get; set; }

        private void Main_Shown(object sender, EventArgs e)
        {
            foreach (var item in HotContainer.Panel1.Controls)
            {
                Panel pl = item as Panel;
                if (pl != null)
                {
                    pl.Visible = true;
                }
            }

            panel7.Visible = true;
        }


        private MenuControl myMenu { get; set; }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MyUserInfo.currentUserId <= 0)
            {
                About about = new About();
                about.ShowDialog(this);
            }
            else
            {
                if (myMenu == null)
                {
                    RECT rect = new RECT();
                    WinApi.GetWindowRect(this.Handle, ref rect);
                    int x = rect.Right - 72;
                    WinApi.GetWindowRect(pictureBox3.Handle, ref rect);
                    myMenu = new MenuControl(this);
                    myMenu.StartPosition = FormStartPosition.Manual;
                    myMenu.Location = new Point(x, rect.Bottom);
                    //myMenu.Size = new Size(72, 72);
                    myMenu.Show();
                }
                else
                {
                    myMenu.Close();
                    myMenu = null;
                }
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
                alert.Show();
            }
        }

        public void CloseMain()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(CloseMain), new object[] { });
            }
            else
            {
                this.Close();
            }
        }



        /// <summary>
        /// 确认提示
        /// </summary>
        /// <param name="text"></param>
        /// <param name="title"></param>
        /// <param name="callback"></param>
        public void AlertConfirm(string text, string title, Action callback)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string, string, Action>(AlertConfirm), new object[] { text, title, callback });
            }
            else
            {
                bool isOk = false;
                MessageConfirm alert = new MessageConfirm(text, title);
                alert.StartPosition = FormStartPosition.CenterScreen;
                alert.CallBack += () =>
                {
                    isOk = true;
                };
                alert.ShowDialog();
                if (isOk)
                    callback?.Invoke();
            }
        }


        /// <summary>
        /// 显示激活窗口
        /// </summary>
        public void ShowCDKeyForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ShowCDKeyForm));
            }
            else
            {
                CDkey cdkey = new CDkey(this);
                cdkey.StartPosition = FormStartPosition.CenterScreen;
                cdkey.ShowDialog(this);
            }
        }




        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.wxlogin != null)
            {
                wxlogin.isStartTask = false;
                wxlogin.isCloseWinForm = true;
                wxlogin.Close();
                wxlogin = null;
            }
            if (this.winTask != null)
            {
                winTask.isStartTask = false;
                winTask.Close();
                winTask = null;
            }
            //关闭数据库连接
            if (MyUserInfo.currentUserId > 0)
                LogicHotTao.Instance(MyUserInfo.currentUserId).CloseConnection();
            Application.ExitThread();
            Process.GetCurrentProcess().Kill();

        }


        #region 登录淘宝相关操作

        //public Alilogin.Alilogin lw;
        public TBSync.LoginWindow lw;
        private Timer checkTbLoginTime;
        private bool loginSuccess = false;
        /// <summary>
        /// 登录淘宝
        /// </summary>
        public void LoginTaoBao()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(LoginTaoBao), new object[] { });
            }
            else
            {
                loginSuccess = false;
                //TimingRefreshAlimamaPage();
                if (lw != null)
                {
                    if (lw.RefreshAuthView != null)
                    {
                        lw.RefreshAuthView.Stop();
                        lw.RefreshAuthView.Dispose();
                        lw.RefreshAuthView = null;
                    }
                    if (lw.browser != null)
                    {
                        lw.browser.Dispose();
                    }
                    lw.Dispose();
                    lw.Close();
                    lw = null;
                }
                lw = new TBSync.LoginWindow();

                lw.LoginSuccessHandle += Lw_LoginSuccessHandle;
                lw.CloseWindowHandle += Lw_CloseWindowHandle;
                lw.StartPosition = FormStartPosition.CenterScreen;
                lw.Show(this);
            }
        }
        /// <summary>
        /// 检查淘宝登录状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckTbLoginTime_Tick(object sender, EventArgs e)
        {
            new System.Threading.Thread(() =>
            {
                if (lw == null || !loginSuccess || string.IsNullOrEmpty(MyUserInfo.TaobaoName)) return;
                MyUserInfo.cookieJson = lw.GetCurrentCookiesToString();
                bool flag = LogicUser.Instance.checkCookieStatus(MyUserInfo.LoginToken, MyUserInfo.cookieJson);
                if (!flag)
                {
                    LoginTaoBao();
                }
            })
            { IsBackground = true }.Start();
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        private void Lw_CloseWindowHandle()
        {
            if (!loginSuccess)
            {
                AlertConfirm("关闭将无法自动申请高佣,确定取消登录?", "退出提示", () =>
                {
                    lw.HideWindow();
                });
            }
            else
                lw.HideWindow();


            SetWinForegroundWindow(this.Handle);

        }


        private void SetWinForegroundWindow(IntPtr hWin)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<IntPtr>(SetWinForegroundWindow), new object[] { hWin });
            }
            else
            {
                WinApi.SetForegroundWindow(hWin);
            }
        }



        /// <summary>
        /// 登录成功事件回调
        /// </summary>
        /// <param name="jsons">The jsons.</param>
        private void Lw_LoginSuccessHandle(CookieCollection cookies)
        {
            SetWinForegroundWindow(this.Handle);
            //lw.HideWindow();
            loginSuccess = true;
            MyUserInfo.cookies = cookies;
            MyUserInfo.TaobaoName = lw.GetTaobaoName();
            string cookieJson = lw.GetCurrentCookiesToString();
            new System.Threading.Thread(() =>
            {
                bindTaobao(cookieJson);
            })
            { IsBackground = true }.Start();
        }
        private int RetryCount { get; set; }
        private void bindTaobao(string cookieJson)
        {
            var result = LogicSyncGoods.Instance.BindTaobao(MyUserInfo.LoginToken, cookieJson, false);
            if (result.resultCode == 200)
            {
                MyUserInfo.TaobaoName = result.data.ToString();
                RetryCount = 0;
            }
            else if (result.resultCode == 511)
            {
                RetryCount = 0;
                AlertConfirm("当前登录淘宝账号与上次不匹配，是否切换?", "提示", () =>
                {
                    result = LogicSyncGoods.Instance.BindTaobao(MyUserInfo.LoginToken, cookieJson, true);
                    if (result.resultCode == 200)
                        MyUserInfo.TaobaoName = result.data.ToString();
                });
            }
            else
            {
                RetryCount++;
                if (RetryCount < 3)
                {
                    bindTaobao(cookieJson);
                }
            }
        }


        /// <summary>
        /// 关闭淘宝窗口事件
        /// </summary>
        private void loginWindowsClose()
        {
            if (lw == null) return;
            if (lw.InvokeRequired)
            {
                this.lw.Invoke(new Action(loginWindowsClose), new object[] { });
            }
            else
            {
                if (lw != null)
                    lw.Close();
                lw = null;
            }
        }
        /// <summary>
        /// 刷新状态
        /// </summary>
        /// <value>true if [refresh status]; otherwise, false.</value>
        private bool RefreshStatus { get; set; }
        /// <summary>
        /// 刷新地址
        /// </summary>
        /// <value>The refresh URL.</value>
        private string RefreshUrl { get; set; }
        /// <summary>
        /// 定时刷新
        /// </summary>
        /// <value>The timing refresh.</value>
        private Timer timingRefresh { get; set; }

        public bool IsRuning { get; set; }

        /// <summary>
        /// 定时刷新阿里妈妈页面，以保证其登录状态
        /// 调用场景：登录阿里妈妈后触发
        /// </summary>
        private void TimingRefreshAlimamaPage()
        {
            if (timingRefresh != null)
            {
                timingRefresh.Stop();
                timingRefresh.Dispose();
                timingRefresh = null;
            }
            timingRefresh = new Timer();
            timingRefresh.Interval = 300000;
            timingRefresh.Tick += TimingRefresh_Tick;
            timingRefresh.Start();

            //if (checkTbLoginTime != null)
            //{
            //    checkTbLoginTime.Stop();
            //    checkTbLoginTime.Dispose();
            //    checkTbLoginTime = null;
            //}
            //checkTbLoginTime = new Timer();
            //checkTbLoginTime.Interval = 10 * 60 * 1000;
            //checkTbLoginTime.Tick += CheckTbLoginTime_Tick;
            //checkTbLoginTime.Start();

        }
        /// <summary>
        /// 定时刷新
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void TimingRefresh_Tick(object sender, EventArgs e)
        {
            if (!loginSuccess) return;
            new System.Threading.Thread(() =>
            {
                ResetRefeshStatus();
                if (lw == null) return;
                string taobaoname = lw.GetTaobaoName();
                if (!string.IsNullOrEmpty(taobaoname))
                    lw.GoPage(RefreshUrl);
            })
            { IsBackground = true }.Start();
        }


        int urlIndex = 0;
        /// <summary>
        /// Resets the refesh status.
        /// </summary>
        public void ResetRefeshStatus()
        {
            switch (urlIndex)
            {
                case 0:
                    urlIndex = 1;
                    RefreshUrl = "http://www.alimama.com";
                    break;
                case 1:
                    urlIndex = 2;
                    RefreshUrl = "https://www.taobao.com/";
                    break;
                case 2:
                    urlIndex = 0;
                    RefreshUrl = "https://www.tmall.com/";
                    break;
                default:
                    urlIndex = 1;
                    RefreshUrl = "http://www.alimama.com";
                    break;
            }
            try
            {
                MyUserInfo.TaobaoName = lw.GetTaobaoName();
                MyUserInfo.cookies = lw.GetCurrentCookies();
                MyUserInfo.cookieJson = lw.GetCurrentCookiesToString();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            RefreshStatus = !RefreshStatus;
        }


        private static Dictionary<string, DateTime> notifyMap { get; set; } = new Dictionary<string, DateTime>();
        /// <summary>
        /// 异常通知
        /// </summary>        
        private void SendNotify()
        {
            string title = "taobao_login";
            if (notifyMap.ContainsKey(title))
            {
                DateTime nowDt = DateTime.Now;
                notifyMap.TryGetValue(title, out nowDt);
                if (nowDt.AddMinutes(30).CompareTo(DateTime.Now) < 0)
                {
                    notifyMap[title] = DateTime.Now;
                    HotJavaApi.SendUserNotice(MyUserInfo.LoginToken, WeChatTemplateMessageSceneType.阿里妈妈离线);
                    new System.Threading.Thread(() =>
                    {
                        LoginTaoBao();
                    })
                    { IsBackground = true }.Start();
                }
            }
            else
            {
                notifyMap[title] = DateTime.Now;
                HotJavaApi.SendUserNotice(MyUserInfo.LoginToken, WeChatTemplateMessageSceneType.阿里妈妈离线);
                new System.Threading.Thread(() =>
                {
                    LoginTaoBao();
                })
                { IsBackground = true }.Start();
            }
        }



        /// <summary>
        /// 申请高佣
        /// </summary>
        /// <param name="goodsDetailUrl">商品详情地址</param>
        public void ApplyPlan(string goodsId, string goodsName, string goodsUrl)
        {
            if (lw == null)
            {
                logRuningList.Add(new LogRuningModel()
                {
                    goodsid = goodsId,
                    goodsName = goodsName,
                    title = goodsId,
                    content = goodsName,
                    logTime = DateTime.Now,
                    logType = LogTypeOpts.未知,
                    isError = true,
                    goodsUrl = goodsUrl,
                    remark = "您还没登录阿里妈妈，请登录后重试!"
                });
                SendNotify();
                return;
            }
            LogRuningModel logData = new LogRuningModel()
            {
                goodsid = goodsId,
                goodsName = goodsName,
                title = goodsId,
                content = goodsName,
                logTime = DateTime.Now,
                goodsUrl = goodsUrl,
                logType = LogTypeOpts.申请高佣,
            };
            string content = string.Empty;
            try
            {
                MyUserInfo.cookies = lw.GetCurrentCookies();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (System.Net.Cookie item in MyUserInfo.cookies)
                {
                    sb.AppendLine(string.Format("{0}={1}", item.Name, item.Value));
                }
                var tbToken = lw.GetTbToken();
                string searchUrl = string.Format("http://pub.alimama.com/items/search.json?q={0}&_t={1}&auctionTag=&perPageSize=40&shopTag=&t={1}&_tb_token_={2}&pvid=", HttpUtility.UrlEncode(goodsUrl), getClientMsgId(), tbToken);
                CookieContainer cookiesContainer = new CookieContainer();
                cookiesContainer.Add(MyUserInfo.cookies);
                content = HttpRequestService.HttpGet(searchUrl, cookiesContainer);
                decimal tkRate = 0;
                decimal eventRate = 0;
                bool tkMktStatus = false;
                bool resultOk = false;
                if (!string.IsNullOrEmpty(content))
                {
                    try
                    {
                        TaobaoSearchResultModel searchResult = JsonConvert.DeserializeObject<TaobaoSearchResultModel>(content);
                        if (searchResult != null && searchResult.ok && searchResult.data.pageList != null)
                        {
                            //通用计划
                            tkRate = searchResult.data.pageList[0].tkRate;

                            if (!string.IsNullOrEmpty(searchResult.data.pageList[0].eventRate))
                                eventRate = Convert.ToDecimal(searchResult.data.pageList[0].eventRate);

                            if (!string.IsNullOrEmpty(searchResult.data.pageList[0].tkMktStatus))
                                tkMktStatus = Convert.ToInt32(searchResult.data.pageList[0].tkMktStatus) == 1;
                            resultOk = true;
                        }
                        else
                        {
                            logData.isError = false;
                            logData.logType = LogTypeOpts.未知;
                            logData.remark = "[" + goodsId + "]" + "该商品在阿里妈妈未找到";
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error("该商品在阿里妈妈未找到" + ex.Message);
                        logData.isError = false;
                        logData.logType = LogTypeOpts.未知;
                        logData.remark = "[" + goodsId + "]" + "该商品在阿里妈妈未找到";
                    }
                }
                if (resultOk)
                {
                    if (tkMktStatus)
                    {
                        logData.isError = false;
                        logData.logType = LogTypeOpts.营销计划;
                        logData.remark = "[" + goodsId + "]" + "营销计划,佣金:" + tkRate.ToString() + " %";
                    }
                    else
                    {
                        //获取更多定向计划数据
                        string url = string.Format("http://pub.alimama.com/pubauc/getCommonCampaignByItemId.json?itemId={0}&t={1}&_tb_token_={2}&pvid=", goodsId, getClientMsgId(), tbToken);
                        cookiesContainer = null;
                        cookiesContainer = new CookieContainer();
                        cookiesContainer.Add(MyUserInfo.cookies);
                        content = BaseRequestService.HttpGet(url, cookiesContainer);
                        if (content.Contains("html"))
                        {
                            logData.isError = true;
                            logData.remark = "阿里妈妈登录状态已失效，请重新登录";

                            SendNotify();
                        }
                        else
                        {
                            try
                            {
                                TaobaoCommonCampaignItemsModel items = JsonConvert.DeserializeObject<TaobaoCommonCampaignItemsModel>(content);
                                if (items != null && items.ok && items.data != null && items.data.Count > 0)
                                {

                                    var listData = items.data.OrderByDescending(r => r.commissionRate).ToList();
                                    TaobaoCommonItem item = listData[0];

                                    //开始申请佣金
                                    if (tkRate <= item.commissionRate)
                                        ApplyPlan(goodsId, goodsName, item.CampaignID, item.ShopKeeperID, item.commissionRate / 100, goodsUrl);
                                    else
                                    {
                                        logData.isError = false;
                                        logData.logType = LogTypeOpts.通用计划;
                                        logData.remark = "[" + goodsId + "]" + "通用计划,佣金:" + tkRate.ToString() + " %";
                                    }
                                }
                                else
                                {
                                    logData.isError = false;
                                    if (eventRate > tkRate)
                                    {
                                        logData.logType = LogTypeOpts.高佣活动;
                                        logData.remark = "[" + goodsId + "]" + "高佣活动,佣金:" + tkRate.ToString() + " %";
                                    }
                                    else
                                    {
                                        logData.logType = LogTypeOpts.通用计划;
                                        logData.remark = "[" + goodsId + "]" + "通用计划,佣金:" + tkRate.ToString() + " %";
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                logData.isError = false;
                                if (eventRate > tkRate)
                                {
                                    logData.logType = LogTypeOpts.高佣活动;
                                    logData.remark = "[" + goodsId + "]" + "高佣活动,佣金:" + tkRate.ToString() + " %";
                                }
                                else
                                {
                                    logData.logType = LogTypeOpts.通用计划;
                                    logData.remark = "[" + goodsId + "]" + "通用计划,佣金:" + tkRate.ToString() + " %";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            if (logRuningList.Exists(item => { return item.goodsid == logData.goodsid && item.logType == LogTypeOpts.申请高佣; }))
            {
                logRuningList.ForEach(l =>
                {
                    if (l.goodsid == logData.goodsid)
                    {
                        l = logData;
                        return;
                    }
                });
            }
            else
                logRuningList.Add(logData);
        }


        /// <summary>
        /// 申请高佣
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="goodsName"></param>
        /// <param name="campId">计划ID</param>
        /// <param name="keeperid">店铺ID</param>
        /// <param name="commissionRate">佣金率</param>
        public void ApplyPlan(string goodsId, string goodsName, string campId, string keeperid, decimal commissionRate, string goodsUrl)
        {
            LogRuningModel logData = new LogRuningModel()
            {
                goodsid = goodsId,
                goodsName = goodsName,
                title = goodsId,
                content = goodsName,
                logTime = DateTime.Now,
                logType = LogTypeOpts.申请高佣,
                campId = campId,
                keeperid = keeperid,
                commissionRate = commissionRate,
                goodsUrl = goodsUrl
            };

            try
            {
                MyUserInfo.cookies = lw.GetCurrentCookies();
                CookieContainer cookiesContainer = new CookieContainer();
                cookiesContainer.Add(MyUserInfo.cookies);
                string applyUrl = "http://pub.alimama.com/pubauc/applyForCommonCampaign.json";
                Dictionary<string, string> formFields = new Dictionary<string, string>();
                formFields["campId"] = campId;
                formFields["keeperid"] = keeperid;
                formFields["applyreason"] = "您好，淘客人多，请于通过!";
                formFields["_tb_token_"] = lw.GetTbToken();
                formFields["t"] = getClientMsgId().ToString();
                formFields["pvid"] = "";
                string res = BaseRequestService.HttpPost(applyUrl, formFields, cookiesContainer);

                TaobaoCommonCampaignItemsModel _items = JsonConvert.DeserializeObject<TaobaoCommonCampaignItemsModel>(res);
                if (_items != null)
                {
                    if (_items.ok)
                    {
                        logData.isError = false;
                        logData.remark = "[" + goodsId + "]" + "自动申请佣金成功,佣金:" + (commissionRate * 100) + " %";
                    }
                    else
                    {
                        logData.isError = _items.info.message.Contains("您已经在申请该计划或您已经申请过该掌柜计划") ? false : true;
                        logData.remark = "[" + goodsId + "]" + _items.info.message;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                logData.isError = true;
                logData.remark = "[" + goodsId + "]" + "一瞬间，风起人涌，交通拥堵，请稍后重试！";
            }

            if (logRuningList.Exists(item => { return item.goodsid == logData.goodsid && item.logType == LogTypeOpts.申请高佣; }))
            {
                logRuningList.ForEach(l =>
                {
                    if (l.goodsid == logData.goodsid)
                    {
                        l = logData;
                        return;
                    }
                });
            }
            else
                logRuningList.Add(logData);
        }


        private void ThreadHandle(Action call)
        {
            new System.Threading.Thread(() =>
            {
                call?.Invoke();
            })
            { IsBackground = true }.Start();
        }

        /// <summary>
        /// 获取随机时间戳
        /// </summary>
        /// <returns>System.Int64.</returns>
        public static double getClientMsgId()
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (DateTime.Now - startTime).TotalMilliseconds;
        }
        #endregion




        #region QQ相关操作

        public QQMainControl qqForm;

        public Timer autoJoinImageTimer { get; set; }

        public bool IsJoinImageCompleted { get; set; } = true;

        /// <summary>
        /// 登录QQ
        /// </summary>
        private void LoginQQ()
        {
            if (qqForm == null)
            {
                qqForm = new QQLogin.QQMainControl();
                qqForm.IsShowJoinImage = true;
                qqForm.IdentificationTag = MyUserInfo.currentUserId.ToString();
                qqForm.CloseQQHandler += QqForm_CloseQQHandler;
                qqForm.BuildGoodsHandler += QqForm_BuildGoodsHandler;
                openControl(qqForm);

                if (autoJoinImageTimer != null)
                {
                    autoJoinImageTimer.Stop();
                    autoJoinImageTimer.Dispose();
                    autoJoinImageTimer = null;
                }
                autoJoinImageTimer = new Timer();
                autoJoinImageTimer.Interval = 5000;
                autoJoinImageTimer.Tick += AutoJoinImageTimer_Tick;
                autoJoinImageTimer.Start();
            }
            else
                openControl(qqForm);
        }

        /// <summary>
        /// 自动合成图定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoJoinImageTimer_Tick(object sender, EventArgs e)
        {
            if (IsJoinImageCompleted && qqForm != null && qqForm.EnableJoinImage)
            {
                IsJoinImageCompleted = false;
                DateTime startTime = DateTime.Now;
                DateTime endTime = DateTime.Now.AddHours(12);

                if (qqForm.EnableTimeConfig)
                {
                    //当前时间大于任务开始时间小于结束时间,则时间当前时间为任务开始时间
                    if (qqForm.TaskStartTime.CompareTo(DateTime.Now) < 0 && qqForm.TaskEndTime.CompareTo(DateTime.Now) > 0)
                    {
                        startTime = DateTime.Now;
                        endTime = qqForm.TaskEndTime;
                    }
                    //如果任务时间大于当前时间
                    else if (qqForm.TaskStartTime.CompareTo(DateTime.Now) > 0)
                    {
                        startTime = qqForm.TaskStartTime;
                        endTime = qqForm.TaskEndTime;
                    }
                    else if (qqForm.TaskEndTime.CompareTo(DateTime.Now) < 0)
                        return;
                }
                new System.Threading.Thread(() =>
                {
                    if (weChatGroups == null) weChatGroups = LogicHotTao.Instance(MyUserInfo.currentUserId).GetUserWeChatGroupListByUserId(MyUserInfo.currentUserId);
                    string appkey = string.Empty;
                    string appsecret = string.Empty;
                    if (myConfig == null)
                        myConfig = new ConfigModel();
                    else
                    {
                        ConfigSendTimeModel cfgTime = string.IsNullOrEmpty(myConfig.send_time_config) ? null : JsonConvert.DeserializeObject<ConfigSendTimeModel>(myConfig.send_time_config);
                        if (cfgTime != null)
                        {
                            appkey = cfgTime.appkey;
                            appsecret = cfgTime.appsecret;
                        }
                    }
                    if (string.IsNullOrEmpty(appkey) && string.IsNullOrEmpty(appsecret))
                    {
                        appkey = Resources.taobaoappkey;
                        appsecret = Resources.taobaoappsecret;
                    }

                    LogicHotTao.Instance(MyUserInfo.currentUserId).AutoJoinImage(MyUserInfo.LoginToken, weChatGroups, appkey, appsecret, startTime, endTime);
                    IsJoinImageCompleted = true;
                })
                { IsBackground = true }.Start();
            }
        }

        /// <summary>
        /// 当前微信群列表数据
        /// </summary>
        public List<UserWechatListModel> weChatGroups { get; set; }

        public static object lock_goods = new object();

        public bool isStart = false;

        /// <summary>
        /// 生成商品,并判断是否开启创建任务计划
        /// </summary>
        /// <param name="msgCode">商品</param>
        /// <param name="urls">采集到的URL</param>
        /// <param name="isAutoSend"></param>   
        /// <param name="EnableCustomTemplate"></param>   
        /// <param name="callback">处理回调通知</param>
        private void QqForm_BuildGoodsHandler(long msgCode, string msgGroupName, string msgContent, string msgFullContent, List<string> urls, bool isAutoSend, bool EnableCustomTemplate, Action<MessageCallBackType, int, int> callback)
        {
            if ((isAutoSend || qqForm.EnableJoinImage) && !EnableCustomTemplate && !isStart)
            {
                MyUserInfo.sendmode = 0;
                if (winTask == null)
                {
                    winTask = new StartTask(this);
                    winTask.OK();
                    isStart = true;
                }
            }
            lock (lock_goods)
            {
                DateTime startTime = DateTime.Now;
                DateTime endTime = DateTime.Now.AddHours(12);
                if (qqForm.EnableTimeConfig)
                {                    
                    //当前时间大于任务开始时间小于结束时间,则时间当前时间为任务开始时间
                    if (qqForm.TaskStartTime.CompareTo(DateTime.Now) < 0 && qqForm.TaskEndTime.CompareTo(DateTime.Now) > 0)
                    {
                        startTime = DateTime.Now;
                        endTime = qqForm.TaskEndTime;
                    }
                    //如果任务时间大于当前时间
                    else if (qqForm.TaskStartTime.CompareTo(DateTime.Now) > 0)
                    {
                        startTime = qqForm.TaskStartTime;
                        endTime = qqForm.TaskEndTime;
                    }
                    else if (qqForm.TaskEndTime.CompareTo(DateTime.Now) < 0)
                        return;
                }

                if (weChatGroups == null) weChatGroups = LogicHotTao.Instance(MyUserInfo.currentUserId).GetUserWeChatGroupListByUserId(MyUserInfo.currentUserId);
                int groupCount = weChatGroups.Count();
                if (urls != null)
                {
                    List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    if (urls.Count() > 0)
                        data["url"] = urls[0];
                    else
                        data["url"] = "";

                    if (urls.Count() > 1)
                        data["url2"] = urls[1];
                    else
                        data["url2"] = "";

                    data["message"] = msgFullContent;
                    list.Add(data);

                    string jsonUrls = JsonConvert.SerializeObject(list);
                    //根据地址，获取商品优惠信息
                    List<GoodsSelectedModel> goodsData = LogicGoods.Instance.getGoodsByLink(MyUserInfo.LoginToken, jsonUrls);
                    try
                    {
                        if (goodsData != null && goodsData.Count() > 0)
                        {
                            callback?.Invoke(MessageCallBackType.正在准备, 0, 0);
                            bool isUpdate = false;
                            //保存商品到本地数据库
                            int gid = LogicGoods.Instance.SaveGoods(goodsData[0], MyUserInfo.currentUserId, out isUpdate);
                            if (isUpdate)
                            {
                                callback?.Invoke(MessageCallBackType.完成, 0, 0);
                                return;
                            }
                            List<GoodsTaskModel> goodsidList = new List<GoodsTaskModel>();
                            goodsidList.Add(new GoodsTaskModel() { id = gid });
                            List<GoodsTaskModel> pidList = new List<GoodsTaskModel>();
                            foreach (var group in weChatGroups)
                            {
                                if (pidList.FindIndex(r => { return r.id == group.id; }) < 0)
                                    pidList.Add(new GoodsTaskModel() { id = group.id });
                            }
                            string goodsText = JsonConvert.SerializeObject(goodsidList);
                            string pidsText = JsonConvert.SerializeObject(pidList);

                            if (groupCount > 0 && isAutoSend && !qqForm.EnableJoinImage)
                            {
                                System.Threading.Thread.Sleep(2000);

                                int taskId = 0;
                                callback?.Invoke(MessageCallBackType.开始创建计划, 0, groupCount);
                                //添加任务计划
                                var result = LogicHotTao.Instance(MyUserInfo.currentUserId).AddUserTaskPlan(new TaskPlanModel()
                                {
                                    userid = MyUserInfo.currentUserId,
                                    title = goodsData[0].goodsName,
                                    startTime = startTime,
                                    endTime = endTime,
                                    pidsText = pidsText,
                                    goodsText = goodsText,
                                    id = 0
                                });
                                taskId = Convert.ToInt32(result.id);

                                #region 开始转链准备
                                string appkey = string.Empty;
                                string appsecret = string.Empty;
                                if (myConfig == null)
                                    myConfig = new ConfigModel();
                                else
                                {
                                    ConfigSendTimeModel cfgTime = string.IsNullOrEmpty(myConfig.send_time_config) ? null : JsonConvert.DeserializeObject<ConfigSendTimeModel>(myConfig.send_time_config);
                                    if (cfgTime != null)
                                    {
                                        appkey = cfgTime.appkey;
                                        appsecret = cfgTime.appsecret;
                                    }
                                }

                                if (string.IsNullOrEmpty(appkey) && string.IsNullOrEmpty(appsecret))
                                {
                                    appkey = Resources.taobaoappkey;
                                    appsecret = Resources.taobaoappsecret;
                                }

                                //开始转链
                                int i = 1;
                                string templateText = EnableCustomTemplate ? msgContent : MyUserInfo.sendtemplate;// + "复制这条信息，打开『手机淘宝』[二合一淘口令]领券下单即可抢购宝贝";
                                LogicHotTao.Instance(MyUserInfo.currentUserId).BuildTaskTpwd(MyUserInfo.LoginToken, MyUserInfo.currentUserId, taskId, templateText, appkey, appsecret, (share) =>
                                {
                                    callback?.Invoke(MessageCallBackType.开始转链, i, groupCount);
                                    i++;
                                });
                                #endregion
                                callback?.Invoke(MessageCallBackType.转链完成, 0, groupCount);
                                //
                                writeTemplate(taskId.ToString(), templateText);

                            }
                            callback?.Invoke(MessageCallBackType.完成, 0, 0);
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        callback?.Invoke(MessageCallBackType.失败, 0, 0);
                    }
                }
            }
        }



        /// <summary>
        /// 点击关闭按钮回调事件
        /// </summary>
        private void QqForm_CloseQQHandler()
        {
            AlertConfirm("是否退出QQ监控?", "提示", () =>
            {
                qqForm.CloseEx();
                openControl(new GoodsControl(this));
                qqForm = null;
            });
        }


        /// <summary>
        /// 缓存文件路径
        /// </summary>
        private static string cacheFilePath = System.IO.Path.Combine(Application.StartupPath, GlobalConfig.datapath);
        /// <summary>
        /// 写入配置文件
        /// </summary>
        private void writeTemplate(string taskid, string text)
        {
            string path = string.Format("{0}/{1}/temp", cacheFilePath, MyUserInfo.currentUserId.ToString());

            string templateFileName = path + string.Format("/text_{0}.txt", taskid);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            if (!File.Exists(templateFileName))
                File.Create(templateFileName).Dispose();
            StreamWriter sw = new StreamWriter(@templateFileName, false);
            sw.Write(text);
            sw.Close();//写入
        }
        #endregion

    }
}
