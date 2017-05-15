using CefSharp;
using CefSharp.WinForms;
using HotTaoCore;
using HotTaoCore.Logic;
using HotTaoCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotTao.Controls
{
    public partial class GoodsCollect : FormEx
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

        private Main hotForm { get; set; }

        private TaskControl taskForm { get; set; }

        public GoodsCollect(TaskControl control, Main form)
        {
            InitializeComponent();
            taskForm = control;
            hotForm = form;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void GoodsCollect_Load(object sender, EventArgs e)
        {
            InitBrowser("");
        }

        private ChromiumWebBrowser browser { get; set; }

        /// <summary>
        /// 初始化浏览器
        /// </summary>
        public void InitBrowser(string url)
        {
            new System.Threading.Thread(() =>
            {
                if (browser == null)
                {
                    BrowserSettings settings = new BrowserSettings()
                    {
                        LocalStorage = CefState.Enabled,
                        Javascript = CefState.Enabled,
                        Plugins = CefState.Enabled,
                        ImageLoading = CefState.Enabled,
                        ImageShrinkStandaloneToFit = CefState.Enabled,
                        WebGl = CefState.Enabled
                    };
                    browser = new ChromiumWebBrowser(url);
                    browser.BrowserSettings = settings;
                    browser.Dock = DockStyle.Fill;
                    browser.LifeSpanHandler = new LifeSpanHandler();
                    browser.AddressChanged += Browser_AddressChanged;
                    browser.TitleChanged += Browser_TitleChanged;
                    AddBrowser();
                }
                else
                    browser.Load(url);
            })
            { IsBackground = true }.Start();
        }

        private void Browser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
        }

        /// <summary>
        /// 地址发送改变时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Browser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            SetGoodsUrl(e.Address);
            GetGoodsInfo();
        }
        /// <summary>
        /// 添加浏览控件到展示界面
        /// </summary>
        private void AddBrowser()
        {
            if (panelWeb.InvokeRequired)
            {
                panelWeb.Invoke(new Action(AddBrowser));
            }
            else
            {
                panelWeb.Controls.Add(browser);
            }
        }

        private void btnOpenUrl_Click(object sender, EventArgs e)
        {
            OpenGoodsUrl();
        }


        private void OpenGoodsUrl()
        {
            if (string.IsNullOrEmpty(txtGoodsUrl.Text))
            {
                return;
            }
            browser.Load(txtGoodsUrl.Text.Trim());
            browser.Focus();
            GetGoodsInfo();
        }

        /// <summary>
        /// 回车键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsCollect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                OpenGoodsUrl();
            }
        }
        /// <summary>
        /// 当前
        /// </summary>
        private GoodsSelectedModel CurrentGoods { get; set; }

        /// <summary>
        /// 采集商品
        /// </summary>
        private void GetGoodsInfo()
        {
            CurrentGoods = null;
            SetCouponInfo();
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["url"] = txtGoodsUrl.Text.Trim();
            data["url2"] = txtCouponUrl.Text.Trim();
            data["message"] = "";
            list.Add(data);
            string jsonUrls = JsonConvert.SerializeObject(list);

            new System.Threading.Thread(() =>
            {
                //根据地址，获取商品优惠信息
                List<GoodsSelectedModel> goodsData = LogicGoods.Instance.getGoodsByLink(MyUserInfo.LoginToken, jsonUrls);
                try
                {
                    if (goodsData != null && goodsData.Count() > 0)
                    {
                        CurrentGoods = goodsData[0];
                        SetCouponInfo();

                        //if (hotForm.lw != null)
                        //{
                        //    var cookies= hotForm.lw.GetCurrentCookies("https://www.taobao.com/");
                        //    //获取更多定向计划数据
                        //    string url = string.Format("https://uland.taobao.com/cp/coupon?activityId={0}&itemId={1}", CurrentGoods.couponId, CurrentGoods.goodsId);
                        //    CookieContainer cookiesContainer = new CookieContainer();
                        //    cookiesContainer.Add(cookies);
                        //    string content = BaseRequestService.HttpGet(url, cookiesContainer);

                        //}

                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            })
            { IsBackground = true }.Start();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddGoods_Click(object sender, EventArgs e)
        {
            MessageAlert alert = new MessageAlert();
            bool isUpdate = false;
            if (CurrentGoods != null)
            {
                try
                {
                    //保存商品到本地数据库
                    int gid = LogicGoods.Instance.SaveGoods(CurrentGoods, MyUserInfo.currentUserId, out isUpdate);
                    if (gid > 0)
                    {
                        taskForm.LoadGoodsGridView();
                        Alert("保存成功!");
                    }
                    else
                        Alert("系统繁忙，请稍后再试!");
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    Alert("系统繁忙，请稍后再试!");
                }
            }
            else
                Alert("未查找到优惠券信息！请稍后刷新再试！");
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetGoodsInfo();
        }


        /// <summary>
        /// 确认提示
        /// </summary>
        /// <param name="text"></param>
        /// <param name="title"></param>
        /// <param name="callback"></param>
        public void AlertConfirm(string text, string title, Action<bool> callback)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string, string, Action<bool>>(AlertConfirm), new object[] { text, title, callback });
            }
            else
            {
                bool isOk = false;
                MessageConfirm alert = new MessageConfirm(text, title);
                alert.StartPosition = FormStartPosition.CenterScreen;
                alert.CallBack += () =>
                {
                    isOk = true;
                };
                alert.ShowDialog();
                callback?.Invoke(isOk);
            }
        }

        public void Alert(string text, string title = "提示")
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string, string>(Alert), new object[] { text, title });
            }
            else
            {
                MessageAlert alert = new MessageAlert(text, title);
                alert.StartPosition = FormStartPosition.CenterScreen;
                alert.ShowDialog();
            }
        }

        /// <summary>
        /// 设置优惠券信息
        /// </summary>
        public void SetCouponInfo()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(SetCouponInfo));
            }
            else
            {
                if (CurrentGoods != null)
                {
                    lbCouponName.Text = CurrentGoods.couponName;
                    lbCouponPrice.Text = CurrentGoods.couponPrice.ToString("f2");
                    txtCouponUrl.Text = CurrentGoods.couponUrl;
                }
                else
                {
                    lbCouponName.Text = "(暂无)";
                    lbCouponPrice.Text = "(暂无)";
                }
            }
        }


        /// <summary>
        /// 设置商品链接
        /// </summary>
        /// <param name="url"></param>
        public void SetGoodsUrl(string url)
        {
            if (this.txtGoodsUrl.InvokeRequired)
            {
                this.txtGoodsUrl.Invoke(new Action<string>(SetGoodsUrl), new object[] { url });
            }
            else
            {
                txtGoodsUrl.Text = url;
            }
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picHome_Click(object sender, EventArgs e)
        {
            browser.Load(ApiConst.www);
            browser.Focus();
        }
    }



    /// <summary>
    /// 禁止页面跳出浏览控件
    /// </summary>
    internal class LifeSpanHandler : ILifeSpanHandler
    {
        public bool DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            return false;
        }

        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public void OnBeforeClose(IWebBrowser browser)
        {

        }

        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {
        }

        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = browserControl;
            newBrowser.Load(targetUrl);
            return true;
        }
    }
}
