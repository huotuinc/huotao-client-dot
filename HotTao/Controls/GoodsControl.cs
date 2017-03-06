using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using HotTaoCore;
using HotCoreUtils.Helper;
using HotTaoCore.Models;
using CefSharp.WinForms;
using CefSharp;
using System.Threading;

namespace HotTao.Controls
{
    public partial class GoodsControl : UserControl
    {

        private Main hotForm { get; set; }

        public GoodsControl(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;

        }

        public static ChromiumWebBrowser browser;
        private static bool isSubmit = false;
        /// <summary>
        /// 定时器，定时去检查网页操作是否完成,如果完成，则跳转到微信群发页面
        /// </summary>
        private static System.Windows.Forms.Timer timer = null;

        private void GoodsControl_Load(object sender, EventArgs e)
        {

            if (MyUserInfo.currentUserId > 0)
            {
                isSubmit = false;
                new Thread(() =>
                {
                    string url =ApiConst.Url + "/goods/goodListPage?token=" + MyUserInfo.LoginToken;
                    if (browser != null)
                    {
                        try
                        {
                            browser.Dispose();
                            browser = null;
                        }
                        catch (Exception)
                        {
                            browser = null;
                        }
                    }
                    browser = new ChromiumWebBrowser(url);
                    browser.RegisterJsObject("jsGoods", new GoodsControl(hotForm), false);
                    BrowserSettings settings = new BrowserSettings()
                    {
                        LocalStorage = CefState.Enabled,
                        Javascript = CefState.Enabled,                        
                    };

                    //browser.Dock = DockStyle.Fill;
                    browser.Size = new Size(920, 607);
                    browser.Location = new Point(1, 0);
                    SetBrowserPanel(browser);

                })
                { IsBackground = true }.Start();

                if (timer != null)
                {
                    timer.Stop();
                    timer = null;
                }
                timer = new System.Windows.Forms.Timer();
                timer.Interval = 10;
                timer.Tick += Timer_Tick;
                timer.Start();
            }
            else
                hotForm.openControl(new LoginControl(hotForm));

        }


        /// <summary>
        /// 定时器，定时去检查网页操作是否完成,如果完成，则跳转到微信群发页面
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (isSubmit)
            {
                if (timer != null)
                {
                    timer.Stop();
                    timer = null;
                }
                hotForm.SetWeChatTabSelected();
                hotForm.openControl(new TaskControl(hotForm));

            }
        }

        private void SetBrowserPanel(ChromiumWebBrowser data)
        {
            if (hotPanel2.InvokeRequired)
            {
                this.Invoke(new Action<ChromiumWebBrowser>(SetBrowserPanel), new object[] { data });
            }
            else
            {
                hotPanel2.Controls.Add(data);
                hotPanel2.Refresh();
            }
        }

        /// <summary>
        /// 网页通知客户端操作完成
        /// </summary>
        public void Finish()
        {
            //网页调该方法            
            isSubmit = true;
        }
        /// <summary>
        /// 打开外部浏览器
        /// </summary>
        /// <param name="url">The URL.</param>
        public void OpenExternalBrowser(string url)
        {
            System.Diagnostics.Process.Start(url);
        }

        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns>System.String.</returns>
        public string getToken()
        {
            return MyUserInfo.LoginToken;
        }
    }
}
