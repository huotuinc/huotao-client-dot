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

namespace Alimama
{


    /// <summary>
    /// 表示登录完成事件的方法
    /// </summary>
    /// <param name="user"></param>
    public delegate void LoginSuccessEventHandler(JArray jsons);

    /// <summary>
    /// 可以使用<see cref="LoginAware"/>该接口作为结果回调获取者
    /// </summary>
    public partial class LoginWindow : Form
    {
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

        /// <summary>
        /// 登录成功的回调事件
        /// </summary>
        public event LoginSuccessEventHandler LoginSuccessHandle;

        //private readonly LoginAware aware;

        private static bool isLogin = false;

        public LoginWindow()
        {
            //LoginAware aware
            //this.aware = aware;
            isLogin = false;
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.DocumentTitle.StartsWith("淘宝联盟"))
            {
                if (!isLogin)
                {
                    isLogin = true;
                    loginSuccess();
                }
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void loginSuccess()
        {
            CookieContainer cookies = GetUriCookieContainer(webBrowser1.Url);
            JArray jsons = new JArray();
            foreach (Cookie cookie in cookies.GetCookies(webBrowser1.Url))
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

        private void LoginWindow_Load(object sender, EventArgs e)
        {
            new Thread(delegate ()
            {
                while (!isLogin){}
                Thread.Sleep(1000);
                EnabledButton();
            })
            { IsBackground = true }.Start();
        }


        private void EnabledButton()
        {
            if (button1.InvokeRequired)
            {
                this.Invoke(new Action(EnabledButton), new object[] { });
            }
            else
            {
                button1.Enabled = true;
            }
        }
    }
}
