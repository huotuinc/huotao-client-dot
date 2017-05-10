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
                ld.CloseForm();
                //string url = ApiConst.Url + "/goods/goodListPage?viewMode=2&token=" + MyUserInfo.LoginToken;
                //hotForm.browser.Load(url);
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


        /// <summary>
        /// 下载商品图片
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="goodsImageUrl">The goods image URL.</param>
        private void downloadGoodsImage(string fileName, string goodsImageUrl, string goodsid)
        {
            new Thread(() =>
            {
                try
                {
                    string _goodsid = goodsid;
                    byte[] data = BaseRequestService.GetNetWorkImageData(goodsImageUrl);
                    if (data == null)
                    {
                        Thread.Sleep(1000);
                        data = BaseRequestService.GetNetWorkImageData(goodsImageUrl);
                    }
                    if (data != null)
                    {
                        MemoryStream ms = new MemoryStream(data);
                        Bitmap img = new Bitmap(ms);
                        img.Save(fileName, ImageFormat.Jpeg);
                        ms.Dispose();
                        ms = null;
                        img.Dispose();
                        img = null;
                    }
                    else
                    {
                        log.Info("网络图片地址：" + goodsImageUrl);
                        //_goodsid
                    }

                }
                catch (Exception ex)
                {

                    log.Error("downloadGoodsImage:" + ex.ToString());
                }
            })
            { IsBackground = true }.Start();
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
        #endregion
    }
}
