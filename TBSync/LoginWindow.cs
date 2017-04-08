using CefSharp;
using CefSharp.WinForms;
using HotTaoCore.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TBSync
{

    /// <summary>
    /// 表示登录完成事件的方法
    /// </summary>
    /// <param name="user"></param>
    public delegate void LoginSuccessEventHandler(JArray jsons);

    /// <summary>
    /// 提交申请完成
    /// </summary>
    public delegate void SubmitSuccessEventHandler(bool success, SyncGoodsList data);

    /// <summary>
    /// 登录页面加载完成事件方法
    /// </summary>
    public delegate void LoginPageLoadSuccessEventHandler(bool success);

    /// <summary>
    /// 关闭事件
    /// </summary>
    public delegate void CloseEventHandler();

    public partial class LoginWindow : Form
    {
        NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        public LoginWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 登录成功的回调事件
        /// </summary>
        public event LoginSuccessEventHandler LoginSuccessHandle;
        /// <summary>
        /// 提交申请完成
        /// </summary>
        public event SubmitSuccessEventHandler SubmitSuccessHandle;

        /// <summary>
        /// 登录页面加载完成
        /// </summary>
        public event LoginPageLoadSuccessEventHandler LoadSuccessHandle;

        /// <summary>
        /// 关闭窗口
        /// </summary>
        public event CloseEventHandler CloseWindowHandle;

        public ChromiumWebBrowser browser;

        /// <summary>
        /// The login URL
        /// </summary>
        private const string LoginUrl = "https://login.taobao.com/member/login.jhtml?style=mini&newMini2=true&css_style=alimama&from=alimama";
        /// <summary>
        /// 登录成功的页面
        /// </summary>
        private const string LoginSuccessUrl = "http://www.alimama.com/index.htm";


        private const string MyunionOverview = "http://pub.alimama.com/myunion.htm#!/myunion/overview";


        private const string callback = "http://pro.taobao.com/index.htm";

        /// <summary>
        /// 受限url
        /// </summary>
        private const string denyUrl = "http://alisec.alimama.com/deny.html";


        private void LoginWindow_Load(object sender, EventArgs e)
        {
            OpenTaobao();
        }

        public void OpenTaobao()
        {
            if (browser == null)
            {
                browser = new ChromiumWebBrowser(LoginUrl);
                BrowserSettings settings = new BrowserSettings()
                {
                    LocalStorage = CefState.Enabled,
                    Javascript = CefState.Enabled,
                    WebSecurity = CefState.Enabled
                };
                browser.Size = new Size(920, 607);
                browser.Location = new Point(1, 0);
                browser.FrameLoadEnd += Browser_FrameLoadEnd;
                this.tbPanel.Controls.Add(browser);
            }
        }


        private bool isLoadCompleted = false;
        private bool isLoginCompleted = false;
        private bool isLoadPlanCompleted = false;


        /// <summary>
        /// 是否登录成功
        /// </summary>
        private bool isLoginSuccess = false;

        /// <summary>
        /// 页面加载完成
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FrameLoadEndEventArgs"/> instance containing the event data.</param>
        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            log.Debug(e.Url);
            if (e.Url == LoginUrl)
            {
                if (!isLoadCompleted)
                {
                    isLoadCompleted = true;
                    new Thread(() =>
                    {
                        //页面加载完成回调
                        LoadSuccessHandle?.Invoke(true);
                    })
                    { IsBackground = true }.Start();
                }
            }
            //登录成功后的页面
            else if (e.Url == LoginSuccessUrl)
            {
                HideWindow();
                isLoginSuccess = true;
                if (!isLoginCompleted)
                {
                    isLoginCompleted = true;
                    new Thread(() =>
                    {
                        LoginSuccess();
                    })
                    { IsBackground = true }.Start();
                }
            }
            else if (!string.IsNullOrEmpty(planUrl) && e.Url.Contains(planUrl))
            {
                if (!isLoadPlanCompleted)
                {
                    isLoadPlanCompleted = true;
                    new Thread(() =>
                    {
                        ClickCampaignElement();
                    })
                    { IsBackground = true }.Start();

                }
            }
            else if (e.Url == callback || e.Url.Contains("alisec.alimama.com/deny.html"))
            {
                new Thread(() =>
                {
                    //提交完成
                     SubmitSuccessHandle?.Invoke(true, goods);
                })
                { IsBackground = true }.Start();
            }
        }

        private string planUrl { get; set; }

        public SyncGoodsList goods { get; set; }
        /// <summary>
        /// 打开计划页面
        /// </summary>
        /// <param name="url">The URL.</param>
        public void GoPlanPage(SyncGoodsList item)
        {
            if (!string.IsNullOrEmpty(item.url))
            {
                goods = item;
                isLoadPlanCompleted = false;
                planUrl = item.url.Trim();
                browser.Load(planUrl);

            }
            else
            {
                isLoadPlanCompleted = true;
                //提交完成
                SubmitSuccessHandle?.Invoke(false, goods);
            }

        }


        public void HideWindow()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(HideWindow), new object[] { });
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// 模拟点击申请推广
        /// </summary>
        private void ClickCampaignElement()
        {
            Thread.Sleep(500);
            bool result = false;
            //获取当前按钮文本
            try
            {
                object response = EvaluateScript(browser, "document.getElementsByClassName('campaign-commission').item(0).getElementsByTagName('a').item(0).innerHTML;");
                if (!string.IsNullOrEmpty(response.ToString()))
                    result = response.ToString().Contains("申请推广");
                if (result)
                {
                    //点击申请推广         
                    browser.ExecuteScriptAsync("document.getElementsByClassName('campaign-commission').item(0).getElementsByTagName('a').item(0).click();");
                    Thread.Sleep(100);
                    //输入推广理由
                    browser.ExecuteScriptAsync("document.getElementById('J_applyReason').innerText='1';");
                    Thread.Sleep(100);
                    //提交推广
                    browser.ExecuteScriptAsync("document.getElementsByClassName('form-auth').item(0).getElementsByTagName('li').item(1).getElementsByTagName('a').item(0).click();");

                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            new Thread(() =>
            {
                browser.Load(callback);
            })
            { IsBackground = true }.Start();
        }

        /// <summary>
        /// 执行js脚步，等待返回，timeout 15秒
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="script">The script.</param>
        /// <returns>System.Object.</returns>
        static object EvaluateScript(ChromiumWebBrowser b, string script)
        {
            var task = b.EvaluateScriptAsync(script);
            task.Wait(15000);
            JavascriptResponse response = task.Result;
            return response.Success ? (response.Result ?? "") : response.Message;
        }

        public void InputAccount(string loginname, string loginpwd)
        {
            isLoginSuccess = false;
            Thread.Sleep(500);
            //输入账号名
            browser.ExecuteScriptAsync("document.getElementById('TPL_username_1').value='" + loginname + "';");
            Thread.Sleep(500);
            browser.ExecuteScriptAsync("document.getElementById('TPL_password_1').value='" + loginname + "';");
            Thread.Sleep(500);
            //browser.ExecuteScriptAsync("document.getElementById('J_SubmitStatic').click();");
            //new Thread(() =>
            //{
            //    Thread.Sleep(1000);
            //    if (!isLoginSuccess)
            //    {
            //        //提交完成
            //        LoadSuccessHandle?.Invoke(false);
            //    }
            //})
            //{ IsBackground = true }.Start();
        }










        public void LoginSuccess()
        {
            var visitor = new CookieMonster();
            if (Cef.GetGlobalCookieManager().VisitUrlCookies(LoginSuccessUrl, true, visitor))
                visitor.WaitForAllCookies();
            JArray jsons = new JArray();
            foreach (System.Net.Cookie cookie in visitor.NamesValues)
            {
                JObject json = new JObject();
                json["name"] = cookie.Name;
                json["path"] = cookie.Path;
                json["domain"] = cookie.Domain;
                json["value"] = cookie.Value;
                jsons.Add(json);
            }
            //页面加载完成回调
            LoginSuccessHandle?.Invoke(jsons);
        }








        private void pbClose_Click(object sender, EventArgs e)
        {
            if (CloseWindowHandle != null)
                CloseWindowHandle?.Invoke();
            else
                CloseWindow();
        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        private void CloseWindow()
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(CloseWindow), new object[] { });
            }
            else
            {
                this.Close();
            }
        }



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


        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams createParams = base.CreateParams;
        //        createParams.ClassName = "LoginTaobaoWind"; //这就是我想要的窗体类名。
        //        return createParams;
        //    }
        //}

    }


    /// <summary>
    /// 获取Cefsharp cookie
    /// </summary>
    /// <seealso cref="CefSharp.ICookieVisitor" />
    class CookieMonster : ICookieVisitor
    {
        readonly List<System.Net.Cookie> cookies = new List<System.Net.Cookie>();
        readonly ManualResetEvent gotAllCookies = new ManualResetEvent(false);

        public bool Visit(CefSharp.Cookie cookie, int count, int total, ref bool deleteCookie)
        {
            cookies.Add(new System.Net.Cookie()
            {
                Name = cookie.Name,
                Path = cookie.Path,
                Domain = cookie.Domain,
                Value = cookie.Value
            });

            if (count == total - 1)
                gotAllCookies.Set();

            return true;
        }

        public void WaitForAllCookies()
        {
            gotAllCookies.WaitOne();
        }

        public IEnumerable<System.Net.Cookie> NamesValues
        {
            get { return cookies; }
        }
    }

}
