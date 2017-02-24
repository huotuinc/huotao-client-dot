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

        public ChromiumWebBrowser browser;

        private void GoodsControl_Load(object sender, EventArgs e)
        {

            if (hotForm.currentUserId > 0)
            {
                new Thread(() =>
                {
                    //browser = new ChromiumWebBrowser("file:///J:/HOT/CODE/huotao-client-dot/HotTao/bin/Debug/html/index.html");
                    //BrowserSettings settings = new BrowserSettings()
                    //{
                    //    LocalStorage = CefState.Enabled,
                    //    Javascript = CefState.Enabled
                    //};
                    //browser.Dock = DockStyle.Fill;
                    //SetBrowserPanel(browser);
                })
                { IsBackground = true }.Start();

            }
            else
                hotForm.openControl(new LoginControl(hotForm));

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
        /// 
        /// </summary>
        public void SubmitGoodsSelected()
        {
            //网页调该方法
            //window.external.SubmitGoodsSelected()
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ((Action)(delegate ()
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data["username"] = "guomw4";
                data["password"] = EncryptHelper.MD5_8("123456");
                //var content = BaseRequestService.Post<UserModel>("/huotao/register", data);
            })).BeginInvoke(null, null);


            hotForm.SetWeChatTabSelected();
            hotForm.openControl(new TaskControl(hotForm));
        }
    }
}
