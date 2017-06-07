using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
namespace TBSync
{
    /// <summary>
    /// 淘宝登录窗口
    /// </summary>
    public partial class LoginWindow : Form
    {        
        public LoginWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登录成功的回调事件
        /// </summary>
        public event LoginSuccessEventHandler LoginSuccessHandle;
        /// <summary>
        /// 登录页面加载完成
        /// </summary>
        public event LoginPageLoadSuccessEventHandler LoadSuccessHandle;

        /// <summary>
        /// 关闭窗口
        /// </summary>
        public event CloseEventHandler CloseWindowHandle;
        /// <summary>
        /// 访问受限
        /// </summary>
        public event LoadDenyEventHandler LoadDenyHandler;

        /// <summary>
        /// 浏览控件
        /// </summary>
        public ChromiumWebBrowser browser;

        /// <summary>
        /// The login URL
        /// </summary>
        private const string LoginUrl = "https://login.taobao.com/member/login.jhtml?style=mini&newMini2=true&css_style=alimama&from=alimama";
        /// <summary>
        /// 登录成功跳转阿里妈妈首页页面
        /// </summary>
        private const string LoginSuccessUrl = "http://www.alimama.com/index.htm";

        /// <summary>
        /// 受限url
        /// </summary>
        private const string denyUrl = "alisec.alimama.com/deny.html";
        /// <summary>
        /// 500页面
        /// </summary>
        private const string errorUrl = "www.alimama.com/500.htm";

        /// <summary>
        /// 搜索url
        /// </summary>
        private const string searchUrl = "http://pub.alimama.com/promo/search/index.htm";

        /// <summary>
        /// 初始化是否加载完成
        /// </summary>
        private bool isLoadCompleted = false;
        /// <summary>
        ///是否登录完成
        /// </summary>
        private bool isLoginCompleted = false;

        /// <summary>
        /// 登录成功时间
        /// </summary>
        private DateTime loginSuccessTime { get; set; }

        /// <summary>
        /// 所有的cookie
        /// </summary>
        private List<System.Net.Cookie> lstCookies { get; set; }

        private void LoginWindow_Load(object sender, EventArgs e)
        {
            OpenTaobao();
        }

        /// <summary>
        /// 打开阿里妈妈登录
        /// </summary>
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
                browser.BrowserSettings = settings;
                browser.Size = new Size(920, 607);
                browser.Location = new Point(1, 0);
                browser.FrameLoadEnd += Browser_FrameLoadEnd;
                browser.TitleChanged += Browser_TitleChanged;
                browser.AddressChanged += Browser_AddressChanged;
                this.tbPanel.Controls.Add(browser);
            }
        }
        /// <summary>
        /// 登录发送改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Browser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            if (e.Address.Contains("www.alimama.com"))
            {
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Browser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            if (e.Title.Contains("阿里妈妈") || e.Title.Contains("淘宝联盟") || browser.Address.Contains("www.alimama.com"))
            {
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
        }

        /// <summary>
        /// 页面加载完成
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FrameLoadEndEventArgs"/> instance containing the event data.</param>
        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            if (e.Url == LoginUrl)
            {
                if (!isLoadCompleted)
                {
                    isLoadCompleted = true;
                    isLoginCompleted = false;
                    new Thread(() =>
                    {
                        //页面加载完成回调
                        LoadSuccessHandle?.Invoke(true);
                    })
                    { IsBackground = true }.Start();
                }
            }
            //错误
            else if (e.Url.Contains(errorUrl) || e.Url.Contains(denyUrl))
            {
                new Thread(() =>
                {
                    LoadDenyHandler?.Invoke();
                })
                { IsBackground = true }.Start();
            }
        }

        /// <summary>
        /// 打开指定页面
        /// </summary>
        /// <param name="url">The URL.</param>
        public void GoPage(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                browser.Load(url);
            }
        }



        /// <summary>
        /// 隐藏窗口
        /// </summary>
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
        /// 隐藏窗口
        /// </summary>
        public void SetTitle(string text)
        {
            if (this.lbTitle.InvokeRequired)
            {
                this.lbTitle.Invoke(new Action<string>(SetTitle), new object[] { text });
            }
            else
            {
                this.lbTitle.Text = text;
            }
        }


        /// <summary>
        /// 执行js脚步，等待返回，timeout 15秒
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="script">The script.</param>
        /// <param name="millisecondsTimeout">等待时间</param>
        /// <returns>System.Object.</returns>
        private object EvaluateScript(ChromiumWebBrowser b, string script, int millisecondsTimeout = 5000)
        {
            var task = b.EvaluateScriptAsync(script);
            task.Wait(millisecondsTimeout);
            JavascriptResponse response = task.Result;
            return response.Success ? (response.Result ?? "") : response.Message;
        }

        /// <summary>
        /// 登录成功回调处理
        /// </summary>
        private void LoginSuccess()
        {
            loginSuccessTime = DateTime.Now;
            SetTitle("登录成功!正在获取Token...");
            var visitor = new CookieMonster();
            if (Cef.GetGlobalCookieManager().VisitUrlCookies(LoginSuccessUrl, true, visitor))
                visitor.WaitForAllCookies();
            JArray jsons = new JArray();
            CookieCollection cookies = new CookieCollection();
            foreach (System.Net.Cookie cookie in visitor.NamesValues)
            {
                JObject json = new JObject();
                json["name"] = cookie.Name;
                json["path"] = cookie.Path;
                json["domain"] = cookie.Domain;
                json["value"] = cookie.Value;
                jsons.Add(json);
                cookies.Add(cookie);
            }
            string cookiesJson = JsonConvert.SerializeObject(jsons);
            //页面加载完成回调
            LoginSuccessHandle?.Invoke(cookies);
            SetTitle("登录成功!获取Token成功,正在验证token...");
            new Thread(() =>
            {
                Thread.Sleep(3000);
                HideWindow();
            })
            { IsBackground = true }.Start();

        }

        /// <summary>
        /// 获取淘宝账号
        /// </summary>
        public string GetTaobaoName()
        {
            var visitor = new CookieMonster();
            if (Cef.GetGlobalCookieManager().VisitUrlCookies("https://login.taobao.com/", true, visitor))
                visitor.WaitForAllCookies();
            string taobaoname = string.Empty;
            foreach (System.Net.Cookie cookie in visitor.NamesValues)
            {
                if (cookie.Name == "lid")
                {
                    taobaoname = cookie.Value;
                    break;
                }
            }
            return taobaoname;
        }


        /// <summary>
        /// 判断阿里妈妈是否登录
        /// </summary>
        /// <returns></returns>
        public bool isLogin()
        {
            //            
            if (loginSuccessTime.AddMinutes(30).CompareTo(DateTime.Now) < 0)
            {
                return false;
            }
            //bool loginStatus = false;
            //if (browser.Address.Contains("www.alimama.com"))
            //{
            //    object result = EvaluateScript(browser, "document.getElementsByClassName('menu-username').item(0).innerHTML");
            //    if (!string.IsNullOrEmpty(result.ToString()))
            //    {
            //        if (result.ToString().Equals("你好"))
            //            loginStatus = false;
            //    }
            //    return loginStatus;
            //}
            return true;
        }


        /// <summary>
        /// 获取指定cookie
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public System.Net.Cookie GetCookie(string name)
        {
            System.Net.Cookie cookie = null;
            List<System.Net.Cookie> cookies = GetAllCookies();
            foreach (System.Net.Cookie c in cookies)
            {
                if (c.Name == name)
                {
                    cookie = c;
                    break;
                }
            }
            return cookie;
        }

        /// <summary>
        /// 获取所有的cookie
        /// </summary>
        /// <returns></returns>
        public List<System.Net.Cookie> GetAllCookies()
        {
            if (lstCookies == null) lstCookies = new List<System.Net.Cookie>();
            if (lstCookies.Count() <= 0)
            {
                var visitor = new CookieMonster();
                if (Cef.GetGlobalCookieManager().VisitAllCookies(visitor))
                    visitor.WaitForAllCookies();
                foreach (System.Net.Cookie cookie in visitor.NamesValues)
                {
                    lstCookies.Add(cookie);
                }
            }
            return lstCookies;
        }



        /// <summary>
        /// 获取登录阿里妈妈的cookies
        /// </summary>
        /// <returns></returns>
        public CookieCollection GetCurrentCookies(string address = null)
        {
            var visitor = new CookieMonster();
            if (Cef.GetGlobalCookieManager().VisitUrlCookies(string.IsNullOrEmpty(address) ? LoginSuccessUrl : "address", true, visitor))
                visitor.WaitForAllCookies();
            CookieCollection cookies = new CookieCollection();
            foreach (System.Net.Cookie cookie in visitor.NamesValues)
            {
                cookies.Add(cookie);
            }
            return cookies;
        }

        /// <summary>
        /// 获取登录阿里妈妈的cookies
        /// </summary>
        public string GetCurrentCookiesToString()
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
            string cookiesJson = JsonConvert.SerializeObject(jsons);
            return cookiesJson;
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
