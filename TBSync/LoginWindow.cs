using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TBSync
{
    /// <summary>
    /// 淘宝登录窗口
    /// </summary>
    public partial class LoginWindow : Form
    {
        Logger log = LogManager.GetCurrentClassLogger();

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
        private const string LoginUrl = "https://login.taobao.com/member/login.jhtml?style=mini&newMini2=false&css_style=alimama&from=alimama";
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
        /// 淘宝授权地址
        /// </summary>
        private const string authUrl = "https://oauth.taobao.com/authorize?response_type=token&client_id=24538400&state=1212&view=web";

        /// <summary>
        /// 淘宝授权结果页面
        /// </summary>
        private const string authView = "https://oauth.taobao.com/oauth2";

        /// <summary>
        /// 初始化是否加载完成
        /// </summary>
        private bool isLoadCompleted = false;
        /// <summary>
        ///是否登录完成
        /// </summary>
        private bool isLoginCompleted = false;

        /// <summary>
        /// 是否授权完成
        /// </summary>
        private bool isAuthCompleted = false;

        /// <summary>
        /// 登录成功时间
        /// </summary>
        private DateTime loginSuccessTime { get; set; }


        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 判断当前的淘宝账号密码是否读取本地数据
        /// </summary>
        private bool isLocalData { get; set; } = false;
        /// <summary>
        /// 当前是否是二维码扫描登录方式
        /// </summary>
        private bool isQrCodeLogin { get; set; } = false;
        /// <summary>
        /// 所有的cookie
        /// </summary>
        private List<System.Net.Cookie> lstCookies { get; set; }


        public System.Windows.Forms.Timer RefreshAuthView { get; set; }

        private string tblp { get; set; }

        private void LoginWindow_Load(object sender, EventArgs e)
        {
            OpenTaobao();

            tblp = GetData();
            if (!string.IsNullOrEmpty(tblp))
            {
                rbtnQrCodeLogin.Visible = true;
                var s = tblp.Split('|');
                txtTbLoginName.Text = s[0];
                txtTbLoginPwd.Text = s[1];
                isLocalData = true;
            }
            else
                isLocalData = false;

        }

        private void GetLocalData()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(GetLocalData));
            }
            else
            {
                isLocalData = false;
                if (!string.IsNullOrEmpty(tblp))
                {
                    isLocalData = true;
                    LoginTaobao();
                }
            }
        }





        /// <summary>
        /// 打开阿里妈妈登录
        /// </summary>
        public void OpenTaobao()
        {
            try
            {

                if (browser == null)
                {
                    browser = new ChromiumWebBrowser(LoginUrl);
                    BrowserSettings settings = new BrowserSettings()
                    {
                        LocalStorage = CefState.Enabled,
                        Javascript = CefState.Enabled,
                        Plugins = CefState.Enabled,
                        ImageLoading = CefState.Enabled,
                        ImageShrinkStandaloneToFit = CefState.Enabled,
                        WebGl = CefState.Enabled,
                    };
                    browser.BrowserSettings = settings;
                    browser.Size = new Size(920, 607);
                    browser.Location = new Point(1, 0);
                    browser.MenuHandler = new TBMenuHandler();
                    browser.FrameLoadEnd += Browser_FrameLoadEnd;
                    browser.TitleChanged += Browser_TitleChanged;
                    browser.AddressChanged += Browser_AddressChanged;
                    browser.IsBrowserInitializedChanged += Browser_IsBrowserInitializedChanged;
                    this.tbPanel.Controls.Add(browser);

                    //定时去刷新页面，以保证淘宝长久在线状态
                    if (RefreshAuthView != null)
                    {
                        RefreshAuthView.Stop();
                        RefreshAuthView.Dispose();
                        RefreshAuthView = null;
                    }
                    RefreshAuthView = new System.Windows.Forms.Timer();
                    RefreshAuthView.Interval = 1000 * 60 * 4;
                    RefreshAuthView.Tick += RefreshAuthView_Tick;
                    RefreshAuthView.Start();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                this.Close();
            }
        }
        /// <summary>
        /// 浏览器是否加载完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Browser_IsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs e)
        {
        }

        /// <summary>
        /// 定时刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshAuthView_Tick(object sender, EventArgs e)
        {
            //if (isAuthCompleted)
            //{
            if (browser != null)
            {
                if (browser.Address.Contains(authView))
                {
                    browser.Reload();
                }
            }
            //}
        }

        /// <summary>
        /// 地址发生改变时
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
            else if (e.Address.Contains(authView))
            {
                if (!isAuthCompleted)
                {
                    isAuthCompleted = true;
                    HideWindow();
                }
            }
            else if (e.Address.Equals(authUrl))
            {
                new Thread(() =>
                {
                    Thread.Sleep(10000);
                    if (browser.Address.Equals(authUrl))
                        browser.ExecuteScriptAsync("auther('true')");
                })
                { IsBackground = true }.Start();
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
            if (e.Url.Contains("https://login.taobao.com/member/login.jhtml"))
            {
                if (!isLoadCompleted)
                {
                    isLoadCompleted = true;
                    isLoginCompleted = false;
                    if (!isQrCodeLogin)
                        GetLocalData();
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
            else if (e.Url.Contains(authView))
            {
                if (!isAuthCompleted)
                {
                    isAuthCompleted = true;
                    HideWindow();
                }
            }
            else if (e.Url.Equals(authUrl))
            {
                new Thread(() =>
                {
                    Thread.Sleep(10000);
                    if (browser.Address.Equals(authUrl))
                        browser.ExecuteScriptAsync("auther('true')");
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
                if (browser != null)
                    browser.Reload();
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
            //判断当前控件是否被释放
            if (!this.IsDisposed && this.lbTitle != null && !this.lbTitle.IsDisposed)
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
        }

        /// <summary>
        /// 登录成功回调处理
        /// </summary>
        private void LoginSuccess()
        {
            try
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
                HideWindow();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
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
                if (cookie.Name == "lid" || cookie.Name == "lgc")
                {
                    taobaoname = cookie.Value;
                    break;
                }
            }
            return taobaoname;
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
            if (Cef.GetGlobalCookieManager().VisitUrlCookies(string.IsNullOrEmpty(address) ? LoginSuccessUrl : address, true, visitor))
                visitor.WaitForAllCookies();
            CookieCollection cookies = new CookieCollection();
            foreach (System.Net.Cookie cookie in visitor.NamesValues)
            {
                cookies.Add(cookie);
            }
            return cookies;
        }
        /// <summary>
        /// 获取阿里妈妈token
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public string GetTbToken()
        {
            try
            {
                var cookies = GetCurrentCookies();
                string _tb_token = string.Empty;
                foreach (System.Net.Cookie cookie in cookies)
                {
                    if (cookie.Name.Equals("_tb_token_"))
                    {
                        _tb_token = cookie.Value;
                        break;
                    }
                }
                return _tb_token;
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return "";
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
            isQrCodeLogin = true;
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

        private void TaobaoLogin_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            string url = string.Format("https://login.taobao.com/member/login.jhtml?style=mini&newMini2={0}&css_style=alimama&from=alimama", rb.Tag.ToString().Equals("1") ? "false" : "true");
            browser.Load(url);
            gbLoginTaobao.Visible = rb.Tag.ToString().Equals("1");
            isQrCodeLogin = !rb.Tag.ToString().Equals("1");
            btnLoginTaobao.Text = "登    录";
        }


        /// <summary>
        ///登录淘宝
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoginTaobao_Click(object sender, EventArgs e)
        {
            isQrCodeLogin = false;
            if (txtTbLoginName.Text.Trim().Length == 0)
                return;
            if (txtTbLoginPwd.Text.Trim().Length == 0)
                return;
            SetData(string.Format("{0}|{1}", txtTbLoginName.Text, txtTbLoginPwd.Text));
            //if (browser != null && browser.IsBrowserInitialized)
            //    browser.Load("https://login.taobao.com/member/login.jhtml?style=mini&newMini2=false&css_style=alimama&from=alimama");
            LoginTaobao();
        }


        private void LoginTaobao(bool isBtn = false)
        {
            if (isQrCodeLogin)
            {
                isQrCodeLogin = false;
                return;
            }
            btnLoginTaobao.Text = "登录中...请稍等!";
            if (!isLocalData)
                rbtnQrCodeLogin.Visible = true;

            var autoThread = new Thread(() =>
             {
                 if (!isQrCodeLogin)
                 {
                     HideLoginTaobaoPanel(false);
                     SendKeys.SendWait("{TAB}");
                     if (isBtn)
                     {
                         SendKeys.SendWait("{TAB}{TAB}{TAB}");
                     }
                     //模拟登录
                     AutoSimulateLogin(txtTbLoginName.Text.Trim(), txtTbLoginPwd.Text.Trim());
                 }
             });
            autoThread.IsBackground = true;
            autoThread.TrySetApartmentState(System.Threading.ApartmentState.STA);
            autoThread.Start();
        }
        /// <summary>
        /// 模拟登录
        /// </summary>
        /// <param name="tbLoginName"></param>
        /// <param name="tbLoginPwd"></param>
        private void AutoSimulateLogin(string tbLoginName, string tbLoginPwd)
        {
            SetTitle("自动登录中...");
            if (!isQrCodeLogin)
            {
                browser.ExecuteScriptAsync("document.getElementsByClassName('login-text J_UserName').item(0).value='';document.getElementsByClassName('login-text').item(1).value='';document.body.click()");
                browser.EvaluateScriptAsync("document.getElementById('TPL_username_1').focus();");
                Thread.Sleep(1000);
                ClipboardObjectData(tbLoginName);
                SendKeys.SendWait("^V");
                Thread.Sleep(1000);
                SendKeys.SendWait("{TAB}");
                Thread.Sleep(1000);
                SendKeys.SendWait(tbLoginPwd);
                Thread.Sleep(5000);
                SendKeys.SendWait("{ENTER}");
                //如果5秒后，还再这个页面，就认为它需要滑动验证码登录，将尝试重新模拟自动登录                
                SendKeys.SendWait("{TAB}{TAB}");
                Thread.Sleep(5000);
                if (browser.Address.Contains("https://login.taobao.com/member/login.jhtml"))
                {
                    HideLoginTaobaoPanel(true);
                    isLoadCompleted = false;
                    string url = string.Format("https://login.taobao.com/member/login.jhtml?style=mini&newMini2={0}&css_style=alimama&from=alimama", "false");
                    if (!isQrCodeLogin)
                        browser.Load(url);
                }
            }
        }
        /// <summary>
        /// 复制内容
        /// </summary>
        /// <param name="text"></param>
        /// <param name="count"></param>
        /// <param name="totalCount"></param>
        private void ClipboardObjectData(string text, int count = 1, int totalCount = 5)
        {
            try
            {
                Clipboard.SetDataObject(text, false, 5, 3000);
            }
            catch (Exception)
            {
                if (totalCount >= count)
                {
                    count++;
                    System.Threading.Thread.Sleep(1000);
                    ClipboardObjectData(text, count, totalCount);

                }
            }
        }

        private void HideLoginTaobaoPanel(bool isVisible)
        {

            if (this.gbLoginTaobao.InvokeRequired)
            {
                this.Invoke(new Action<bool>(HideLoginTaobaoPanel), new object[] { isVisible });
            }
            else
            {
                gbLoginTaobao.Visible = isVisible;
                if (isVisible)
                    btnLoginTaobao.Text = "登    录";
            }
        }










        /// <summary>
        /// 缓存文件路径
        /// </summary>
        private static string cacheFilePath = System.IO.Path.Combine(Application.StartupPath, "data");
        /// <summary>
        /// 文案文件名称
        /// </summary>
        private string GetPath()
        {
            return string.Format("{0}/{1}/tblp.data", cacheFilePath, UserId);
        }

        /// <summary>
        /// 写入配置文件
        /// </summary>
        private void SetData(string text)
        {
            try
            {
                string path = GetPath();
                if (!Directory.Exists(cacheFilePath))
                    Directory.CreateDirectory(cacheFilePath);
                if (!File.Exists(path))
                    File.Create(GetPath()).Dispose();
                StreamWriter sw = new StreamWriter(@path, false);
                sw.Write(text);
                sw.Close();//写入
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 获取文案
        /// </summary>
        /// <returns></returns>
        public string GetData()
        {
            try
            {
                string path = GetPath();
                if (File.Exists(path))
                {
                    FileStream aFile = new FileStream(path, FileMode.Open);
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


    /// <summary>
    /// 控制右键菜单
    /// </summary>
    internal class TBMenuHandler : IContextMenuHandler
    {
        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            //移除不需要的菜单
            model.Remove(CefMenuCommand.ViewSource);
            model.Remove(CefMenuCommand.Print);
            model.Remove(CefMenuCommand.AddToDictionary);
            model.Remove(CefMenuCommand.SpellCheckNoSuggestions);

            //修改菜单显示名称
            model.SetLabel(CefMenuCommand.Undo, "撤回");
            model.SetLabel(CefMenuCommand.Redo, "恢复");
            model.SetLabel(CefMenuCommand.Back, "返回");
            model.SetLabel(CefMenuCommand.Forward, "前进");
            model.SetLabel(CefMenuCommand.Cut, "剪切");
            model.SetLabel(CefMenuCommand.Copy, "复制");
            model.SetLabel(CefMenuCommand.Paste, "粘贴");
            model.SetLabel(CefMenuCommand.Delete, "删除");
            model.SetLabel(CefMenuCommand.SelectAll, "全选");
            model.SetLabel(CefMenuCommand.Reload, "重新加载");

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

}
