using CefSharp;
using HotCoreUtils.Helper;
using HotTaoCore;
using HotTaoCore.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TBSync;

namespace HotTaoSquare
{
    public partial class MainForm : FormEx
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
                if (isMax)
                {
                    this.WindowState = FormWindowState.Normal;
                    isMax = false;
                    ResizeWin();
                }
                Point pt = Control.MousePosition;
                _x = mouseOffset.X - pt.X;
                _y = mouseOffset.Y - pt.Y;

                this.Location = new Point(FormLocation.X - _x, FormLocation.Y - _y);
            }
        }
        #endregion

        private Login loginForm { get; set; }

        /// <summary>
        /// 是否已加载完成
        /// </summary>
        private bool isLoadingCompleted { get; set; }

        /// <summary>
        /// 加载页面地址
        /// </summary>
        private static string intiUrl = ApiConst.www + "/widePlace/index";

        public MainForm(Login form)
        {
            InitializeComponent();
            loginForm = form;
        }
        public Loading ld { get; set; }
        private void MainForm_Load(object sender, EventArgs e)
        {
            new System.Threading.Thread(() =>
            {
                if (loginForm.browser == null)
                    loginForm.InitBrowser(intiUrl);
                LoginTaoBao();
            })
            { IsBackground = true }.Start();

        }


        /// <summary>
        /// 添加浏览控件到展示界面
        /// </summary>
        private void AddBrowser()
        {
            try
            {
                if (hotPanel1.InvokeRequired)
                {
                    hotPanel1.Invoke(new Action(AddBrowser), new object[] { });
                }
                else
                {
                    if (loginForm.browser == null)
                        loginForm.InitBrowser(intiUrl);

                    if (loginForm.browser != null)
                    {
                        loginForm.browser.FrameLoadEnd += BrowseLoadEnd;
                        loginForm.browser.TitleChanged += Browser_TitleChanged;
                    }
                    hotPanel1.Controls.Add(loginForm.browser);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        /// <summary>
        /// 页面标题发送改变时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Browser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            SetTitle(e.Title);
            LoadingClose();
        }

        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="title"></param>
        private void SetTitle(string title)
        {
            if (this.lbTitle.InvokeRequired)
            {
                this.lbTitle.Invoke(new Action<string>(SetTitle), new object[] { title });
            }
            else
            {
                lbTitle.Text = title;
            }
        }



        /// <summary>
        /// 页面加载完成后触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            LoadingClose();
        }


        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picClose_Click(object sender, EventArgs e)
        {
            AlertConfirm("确定要退出?", "注销提示", (ret) =>
            {
                if (ret)
                    this.Close();
            });

        }

        private new void Close()
        {
            Application.ExitThread();
            Process.GetCurrentProcess().Kill();
        }

        /// <summary>
        /// 窗口第一次加载显示时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (!isLoadingCompleted)
            {
                if (ld != null && !ld.IsDisposed)
                {
                    ld.Dispose();
                    ld.Close();
                }
                ld = new Loading();
                ld.StartPosition = FormStartPosition.Manual;
                RECT rect = new RECT();
                WinApi.GetWindowRect(this.Handle, ref rect);
                ld.Location = new Point(rect.Left, rect.Top);
                ld.Show(this);
            }
        }

        /// <summary>
        /// 关闭loading
        /// </summary>
        private void LoadingClose()
        {
            if (!isLoadingCompleted)
            {
                if (this.ld != null && this.ld.InvokeRequired)
                {
                    this.ld.Invoke(new Action(LoadingClose), new object[] { });
                }
                else
                {
                    if (ld != null)
                        ld.Close();

                    isLoadingCompleted = true;
                }
            }
        }



        /// <summary>
        /// 当前窗口是否已是最大化
        /// </summary>
        private bool isMax { get; set; }
        /// <summary>
        /// 最大化或最小化切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picMax_Click(object sender, EventArgs e)
        {
            //if (!isMax)
            //{
            //    this.WindowState = FormWindowState.Maximized;
            //    isMax = true;
            //}
            //else
            //{
            //    this.WindowState = FormWindowState.Normal;
            //    isMax = false;
            //}
            //ResizeWin();
        }

        /// <summary>
        /// 窗口大小发生变化时调用
        /// </summary>
        private void ResizeWin()
        {
            //RECT rect = new RECT();
            //WinApi.GetWindowRect(this.Handle, ref rect);
            //hotPanel1.Size = new Size(rect.Right - rect.Left, rect.Bottom - rect.Top - 30);
            //plTop.Width = rect.Right - rect.Left;
            //plRightTop.Location = new Point(plTop.Width, 0);
            //lbTitle.Width = rect.Right - rect.Left - plRightTop.Width;
        }






        #region 登录淘宝相关操作

        public LoginWindow lw;
        private Timer checkTbLoginTime;
        private bool loginSuccess = false;
        /// <summary>
        /// 登录淘宝
        /// </summary>
        public void LoginTaoBao()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(LoginTaoBao), new object[] { });
                }
                else
                {
                    loginSuccess = false;
                    TimingRefreshAlimamaPage();
                    if (lw != null)
                    {
                        lw.Dispose();
                        lw.Close();
                        lw = null;
                    }
                    lw = new LoginWindow();
                    lw.LoginSuccessHandle += Lw_LoginSuccessHandle;
                    lw.CloseWindowHandle += Lw_CloseWindowHandle;
                    lw.StartPosition = FormStartPosition.CenterScreen;
                    lw.ShowDialog(this);


                    if (checkTbLoginTime == null)
                        checkTbLoginTime = new Timer();
                    checkTbLoginTime.Interval = 60 * 1000;// 300000;
                    checkTbLoginTime.Tick += CheckTbLoginTime_Tick;
                    checkTbLoginTime.Start();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
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
                if (!lw.isLogin())
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
            AlertConfirm("必须登录淘宝联盟,确定退出?", "退出提示", (ret) =>
            {
                if (ret)
                    this.Close();
            });
        }

        /// <summary>
        /// 登录成功事件回调
        /// </summary>
        /// <param name="jsons">The jsons.</param>
        private void Lw_LoginSuccessHandle(CookieCollection cookies)
        {
            loginSuccess = true;
            loginWindowsHide();
            AddBrowser();
            MyUserInfo.cookies = cookies;
            MyUserInfo.TaobaoName = lw.GetTaobaoName();
            MyUserInfo.cookieJson = lw.GetCurrentCookiesToString();
            Dictionary<string, string> formFields = new Dictionary<string, string>();
            formFields["taobaoName"] = MyUserInfo.TaobaoName;
            formFields["token"] = MyUserInfo.LoginToken;
            //获取签名
            string signature = SignatureHelper.BuildSign(formFields, ApiConst.SecretKey);
            string param = string.Format("token={0}&signature={1}&taobaoName={2}", MyUserInfo.LoginToken, signature, MyUserInfo.TaobaoName);
            loginForm.InitBrowser(ApiConst.Url + "/widePlace/login?" + param);
            new System.Threading.Thread(() =>
            {
                bindTaobao(MyUserInfo.cookieJson);
            })
            { IsBackground = true }.Start();
        }



        private int RetryCount { get; set; }
        private void bindTaobao(string cookieJson)
        {
            try
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
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }


        ///// <summary>
        ///// 隐藏淘宝窗口事件
        ///// </summary>
        private void loginWindowsHide()
        {
            if (lw == null) return;
            if (lw.InvokeRequired)
            {
                this.lw.Invoke(new Action(loginWindowsHide), new object[] { });
            }
            else
            {
                if (lw != null)
                    lw.Hide();
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
            new System.Threading.Thread(() =>
            {
                ResetRefeshStatus();
                if (lw == null) return;
                string taobaoname = lw.GetTaobaoName();
                if (!string.IsNullOrEmpty(taobaoname))
                    lw.GoPage(RefreshUrl);
                MyUserInfo.cookieJson = lw.GetCurrentCookiesToString();
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


        /// <summary>
        /// 确认提示
        /// </summary>
        /// <param name="text"></param>
        /// <param name="title"></param>
        /// <param name="callback"></param>
        public void AlertConfirm(string text, string title, Action<bool> callback)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string, string, Action<bool>>(AlertConfirm), new object[] { text, title, callback });
            }
            else
            {
                bool isOk = false;
                MessageConfirmWindow alert = new MessageConfirmWindow(text, title);
                alert.StartPosition = FormStartPosition.CenterParent;
                alert.CallBack += () =>
                {
                    isOk = true;
                };
                alert.ShowDialog(this);
                callback?.Invoke(isOk);
            }
        }

        #endregion

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picRefresh_Click(object sender, EventArgs e)
        {
            if (loginForm.browser != null)
                loginForm.browser.Reload();
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picHome_Click(object sender, EventArgs e)
        {
            if (loginForm.browser != null)
                loginForm.browser.Load(intiUrl);
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            loginForm.browser.Back();
        }

        private void picForward_Click(object sender, EventArgs e)
        {
            if (loginForm.browser != null)
                loginForm.browser.Forward();
        }
        /// <summary>
        /// 最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        /// <summary>
        /// 文案设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbSetting_Click(object sender, EventArgs e)
        {
            TemplateConfig tcfg = new TemplateConfig();
            tcfg.StartPosition = FormStartPosition.CenterParent;
            tcfg.ShowDialog(this);
        }
    }
}
