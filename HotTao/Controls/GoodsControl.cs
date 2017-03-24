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
                string url = ApiConst.Url + "/goods/goodListPage?token=" + MyUserInfo.LoginToken;

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
                string url = ApiConst.Url + "/goods/goodListPage?token=" + MyUserInfo.LoginToken;
                hotForm.browser.Load(url);
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
                            foreach (var item in goodsData)
                            {
                                try
                                {
                                    if (item.couponPrice <= 0 || item.goodsPrice - item.couponPrice <= 0) continue;
                                    GoodsModel goods = new GoodsModel()
                                    {
                                        userid = MyUserInfo.currentUserId,
                                        goodsId = item.goodsId,
                                        goodsName = item.goodsName,
                                        goodsIntro = item.goodsIntro,
                                        goodsMainImgUrl = item.goodsImageUrl,
                                        goodsDetailUrl = item.goodsDetailUrl,
                                        goodsSupplier = string.IsNullOrEmpty(item.goodsPlatform) ? "淘宝" : item.goodsPlatform,
                                        goodsComsRate = item.goodsComsRate,
                                        goodsPrice = item.goodsPrice,
                                        goodsSalesAmount = item.goodsSalesAmount,
                                        endTime = Convert.ToDateTime(item.endTime),
                                        couponUrl = item.couponUrl,
                                        couponId = item.couponId,
                                        couponPrice = item.couponPrice
                                    };
                                    string fileName = Environment.CurrentDirectory + "\\temp\\img";
                                    if (!Directory.Exists(fileName))
                                        Directory.CreateDirectory(fileName);
                                    fileName += "\\" + EncryptHelper.MD5(goods.goodsId) + ".jpg";
                                    //判断文件是否存在
                                    if (!File.Exists(fileName))
                                    {
                                        byte[] data = BaseRequestService.GetNetWorkImageData(goods.goodsMainImgUrl);
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
                                        else continue;
                                    }
                                    goods.goodslocatImgPath = fileName;
                                    LogicHotTao.Instance(MyUserInfo.currentUserId).AddUserGoods(goods);
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
                isSubmit = true;
            }
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
