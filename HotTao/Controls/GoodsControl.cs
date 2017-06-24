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
using HOTReuestService.Helper;
using HotTaoCore.Models;
using CefSharp.WinForms;
using CefSharp;
using System.Threading;
using Newtonsoft.Json;
using System.IO;
using System.Drawing.Imaging;
using HotTaoCore.Logic;
using System.Text.RegularExpressions;

namespace HotTao.Controls
{
    public partial class GoodsControl : UserControl
    {
        NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        private Main hotForm { get; set; }

        public GoodsControl(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }
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
                string url = ApiConst.Url + "/goods/goodListPage?viewMode=2&token=" + MyUserInfo.LoginToken;
        
                if (hotForm.browser == null)
                {
                    hotForm.InitBrowser(url);
                }
                SetBrowserPanel(hotForm.browser);
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
                //LoadClose();
                ld.CloseForm();
                
                hotForm.SetWeChatTabSelected();
                hotForm.openControl(new TaskControl(hotForm));

            }
        }
        private void SetBrowserPanel(ChromiumWebBrowser data)
        {
            if (hotPanel2.InvokeRequired)
            {
                this.hotPanel2.Invoke(new Action<ChromiumWebBrowser>(SetBrowserPanel), new object[] { data });
            }
            else
            {
                hotPanel2.Controls.Add(data);
                hotPanel2.Refresh();
            }
        }
        private Loading ld = new Loading();
        /// <summary>
        /// 提交选择的商品json数据字符串
        /// </summary>
        /// <param name="json_goods_result">The json_goods_result.</param>
        public void SubmitGoods(string json_goods_result)
        {
            try
            {
                isSubmit = false;
                if (!string.IsNullOrEmpty(json_goods_result))
                {
                    List<GoodsSelectedModel> goodsData = JsonConvert.DeserializeObject<List<GoodsSelectedModel>>(json_goods_result);
                    if (goodsData != null && goodsData.Count() > 0)
                    {
                        new Thread(() =>
                        {
                            Regex regs = new Regex("&activityId=[^&]*", RegexOptions.IgnoreCase);
                            foreach (var item in goodsData)
                            {
                                try
                                {
                                    bool isUpdate = false;
                                    LogicGoods.Instance.SaveGoods(item, MyUserInfo.currentUserId, out isUpdate);
                                }
                                catch (Exception ex)
                                {
                                    log.Error(ex);
                                }
                            }
                            LoadClose();
                        })
                        { IsBackground = true }.Start();
                        ld.StartPosition = FormStartPosition.CenterParent;
                        ld.ShowDialog(hotForm);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void LoadClose()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(LoadClose), new object[] { });
            }
            else
            {
                ld.Close();
                new Thread(() =>
                {
                    Thread.Sleep(500);
                    isSubmit = true;
                })
                { IsBackground = true }.Start();
            }
        }

        #region 网页JS调用函数
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
        /// 网页获取token
        /// </summary>
        /// <returns>System.String.</returns>
        public string getToken()
        {
            return MyUserInfo.LoginToken;
        }
        /// <summary>
        /// 打开采集浏览器
        /// </summary>
        /// <param name="url"></param>
        public void OpenCollectBrowser(string url)
        {
            hotForm.worker.RunWorkerAsync(url);
        }

        #endregion
    }
}
