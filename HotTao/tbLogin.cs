using CefSharp;
using CefSharp.WinForms;
using HotTao.Controls;
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

namespace HotTao
{

    /// <summary>
    /// 表示登录完成事件的方法
    /// </summary>
    /// <param name="user"></param>
    public delegate void LoginSuccessEventHandler(JArray jsons);

    public partial class tbLogin : Form
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



        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool InternetGetCookieEx(
           string url,
           string cookieName,
           StringBuilder cookieData,
           ref int size,
           Int32 dwFlags,
           IntPtr lpReserved);
        private const Int32 InternetCookieHttponly = 0x2000;
        /// <summary>
        /// Gets the URI cookie container.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        public static CookieContainer GetUriCookieContainer(Uri uri)
        {
            CookieContainer cookies = null;
            // Determine the size of the cookie
            int datasize = 8192 * 16;
            StringBuilder cookieData = new StringBuilder(datasize);
            if (!InternetGetCookieEx(uri.ToString(), null, cookieData, ref datasize, InternetCookieHttponly, IntPtr.Zero))
            {
                if (datasize < 0)
                    return null;
                // Allocate stringbuilder large enough to hold the cookie
                cookieData = new StringBuilder(datasize);
                if (!InternetGetCookieEx(
                    uri.ToString(),
                    null, cookieData,
                    ref datasize,
                    InternetCookieHttponly,
                    IntPtr.Zero))
                    return null;
            }
            if (cookieData.Length > 0)
            {
                cookies = new CookieContainer();
                cookies.SetCookies(uri, cookieData.ToString().Replace(';', ','));
            }
            return cookies;
        }

        public tbLogin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 登录成功的回调事件
        /// </summary>
        public event LoginSuccessEventHandler LoginSuccessHandle;

        private void tbLogin_Load(object sender, EventArgs e)
        {
            string url = "https://login.taobao.com/member/login.jhtml?style=mini&newMini2=true&css_style=alimama&from=alimama";
            browser.Navigate(url);
            browser.ScriptErrorsSuppressed = false;
            browser.ScrollBarsEnabled = false;
            browser.DocumentTitleChanged += Browser2_DocumentTitleChanged;
            //tbPanel.Controls.Add(browser);
        }
        private bool isLogin = false;
        private void Browser2_DocumentTitleChanged(object sender, EventArgs e)
        {
            if (browser.DocumentTitle.Contains("阿里妈妈"))
            {
                if (!isLogin)
                {
                    loginSuccess();
                }
            }
        }

        /// <summary>
        /// 打开连接
        /// </summary>
        /// <param name="url">The URL.</param>
        public void GoUrl(string url)
        {
            //browser.Load(url);
            //this.Show();
        }

        public void SetInit()
        {
            if (Cef.IsInitialized)
                return;
            Cef.Initialize(new CefSettings() { PersistSessionCookies = true });
        }


        private void loginSuccess()
        {
            CookieContainer cookies = GetUriCookieContainer(browser.Url);
            if (cookies == null) return;
            isLogin = true;
            JArray jsons = new JArray();
            foreach (System.Net.Cookie cookie in cookies.GetCookies(browser.Url))
            {
                JObject json = new JObject();
                json["name"] = cookie.Name;
                json["path"] = cookie.Path;
                json["domain"] = cookie.Domain;
                json["value"] = cookie.Value;
                jsons.Add(json);
            }
            LoginSuccessHandle?.Invoke(jsons);
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
