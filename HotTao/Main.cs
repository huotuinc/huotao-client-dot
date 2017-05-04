using CefSharp;
using CefSharp.WinForms;
using HotTao.Controls;
using HotTaoCore;
using HotTaoCore.Enums;
using HotTaoCore.Logic;
using HotTaoCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        /// 运行日志
        /// </summary>
        public List<LogRuningModel> logRuningList { get; set; }



        public ChromiumWebBrowser browser;
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
                    Process.Start(version.url);
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
                string sourceFileName = System.Environment.CurrentDirectory + "\\data\\hottao.db";
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

                dbpath += "\\hottao.db";

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
                foreach (UserControl uu in HotContainer.Panel2.Controls)
                {
                    if (uu != null)
                    {
                        if (uu.GetType() == uc.GetType())
                        {
                            return;
                        }
                    }
                }
                uc.Dock = DockStyle.Fill;
                //DisPanel();
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
            MessageAlert alert = new MessageAlert("计划中...");
            alert.ShowDialog(this);
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
            panelHelp.Visible = false;
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

        public TBSync.LoginWindow lw;

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
                TimingRefreshAlimamaPage();
                if (lw != null)
                {
                    lw.Dispose();
                    lw.Close();
                    lw = null;
                }
                lw = new TBSync.LoginWindow();
                lw.LoginSuccessHandle += Lw_LoginSuccessHandle;
                lw.CloseWindowHandle += Lw_CloseWindowHandle;
                lw.StartPosition = FormStartPosition.CenterScreen;
                lw.ShowDialog(this);
            }
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        private void Lw_CloseWindowHandle()
        {
            AlertConfirm("必须登录阿里妈妈才能使用软件,确定退出?", "退出提示", () =>
            {
                this.Close();
            });
        }

        /// <summary>
        /// 登录成功事件回调
        /// </summary>
        /// <param name="jsons">The jsons.</param>
        private void Lw_LoginSuccessHandle(CookieCollection cookies)
        {
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
                //loginWindowsClose();
                //AlertConfirm("数据读取失败,是否重新读取!", "提示", () =>
                //{
                //    bindTaobao(cookieJson);
                //});
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
            timingRefresh.Interval = 30000;
            timingRefresh.Tick += TimingRefresh_Tick;
            timingRefresh.Start();
        }
        /// <summary>
        /// 定时刷新
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void TimingRefresh_Tick(object sender, EventArgs e)
        {
            ResetRefeshStatus();
            if (lw == null) return;
            string taobaoname = lw.GetTaobaoName();
            if (!string.IsNullOrEmpty(taobaoname))
                lw.GoPage(RefreshUrl);
        }

        /// <summary>
        /// Resets the refesh status.
        /// </summary>
        public void ResetRefeshStatus()
        {
            RefreshUrl = RefreshStatus ? "http://www.alimama.com/news.htm" : "http://www.alimama.com/college.htm";
            RefreshStatus = !RefreshStatus;
        }


        /// <summary>
        /// 申请高佣
        /// </summary>
        /// <param name="goodsDetailUrl">商品详情地址</param>
        public void ApplyPlan(string goodsId, string goodsName)
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
                    logType = LogTypeOpts.申请高佣,
                    isError = true,
                    remark = "您还没登录阿里妈妈，请登录后重试!"
                });
                return;
            }
            ThreadHandle(() =>
            {
                LogRuningModel logData = new LogRuningModel()
                {
                    goodsid = goodsId,
                    goodsName = goodsName,
                    title = goodsId,
                    content = goodsName,
                    logTime = DateTime.Now,
                    logType = LogTypeOpts.申请高佣,
                };
                try
                {
                    MyUserInfo.cookies = lw.GetCurrentCookies();
                    //获取更多定向计划数据
                    string url = string.Format("http://pub.alimama.com/pubauc/getCommonCampaignByItemId.json?itemId={0}&t={1}&_tb_token_={2}&pvid=", goodsId, getClientMsgId(), MyUserInfo.GetTbToken());
                    CookieContainer cookiesContainer = new CookieContainer();
                    cookiesContainer.Add(MyUserInfo.cookies);
                    string content = BaseRequestService.HttpGet(url, cookiesContainer);
                    TaobaoCommonCampaignItemsModel items = JsonConvert.DeserializeObject<TaobaoCommonCampaignItemsModel>(content);
                    if (items != null && items.ok && items.data != null && items.data.Count > 0)
                    {
                        var data = items.data.FindAll(i =>
                         {
                             return i.manualAudit == 0;
                         });
                        var listData = data.OrderByDescending(r => r.commissionRate).ToList();

                        TaobaoCommonItem item = listData[0];
                        if (item != null)
                        {
                            if (!item.Exist)
                            {
                                string applyUrl = "http://pub.alimama.com/pubauc/applyForCommonCampaign.json";
                                Dictionary<string, string> formFields = new Dictionary<string, string>();
                                formFields["campId"] = item.CampaignID;
                                formFields["keeperid"] = item.ShopKeeperID;
                                formFields["applyreason"] = "您好，淘客人多，请于通过!";
                                formFields["_tb_token_"] = MyUserInfo.GetTbToken();
                                formFields["t"] = getClientMsgId().ToString();
                                formFields["pvid"] = "";
                                string res = BaseRequestService.HttpPost(applyUrl, formFields, cookiesContainer);
                                log.Info(res);
                                TaobaoCommonCampaignItemsModel _items = JsonConvert.DeserializeObject<TaobaoCommonCampaignItemsModel>(res);
                                if (_items != null)
                                {
                                    if (_items.ok)
                                    {
                                        logData.isError = false;
                                        logData.remark = "[" + goodsId + "]" + "自动申请佣金成功,佣金:" + item.commissionRate + " %";
                                    }
                                    else
                                    {
                                        logData.isError = true;
                                        logData.remark = "[" + goodsId + "]" + _items.info.message;
                                    }
                                }
                            }
                            else
                            {
                                logData.isError = false;
                                logData.remark = "[" + goodsId + "]" + "已经申请过了";
                            }
                        }
                        else
                        {
                            logData.isError = false;
                            logData.remark = "[" + goodsId + "]" + "没找到定向佣金";
                        }
                    }
                    else
                    {
                        logData.isError = false;
                        logData.remark = "[" + goodsId + "]" + "没找到定向佣金";
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    logData.isError = true;
                    logData.remark = "[" + goodsId + "]" + "一瞬间，风起人涌，交通拥堵，请稍后重试！";
                }
                logRuningList.Add(logData);
            });
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
        public static long getClientMsgId()
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (long)(DateTime.Now - startTime).TotalMilliseconds;
        }
        #endregion

    }
}
