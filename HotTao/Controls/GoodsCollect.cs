using CefSharp;
using CefSharp.WinForms;
using HotTaoCore.Logic;
using HotTaoCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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


        private TaskControl taskForm { get; set; }

        public GoodsCollect(TaskControl control)
        {
            InitializeComponent();
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
                    AddBrowser();
                }
                else
                    browser.Load(url);
            })
            { IsBackground = true }.Start();
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
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["url"] = txtGoodsUrl.Text.Trim();
            data["url2"] = txtCouponUrl.Text.Trim();
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
                //保存商品到本地数据库
                int gid = LogicGoods.Instance.SaveGoods(CurrentGoods, MyUserInfo.currentUserId, out isUpdate);
                if (gid > 0)
                {
                    alert.Message = "保存成功!";
                    taskForm.LoadGoodsGridView();
                }
                else
                    alert.Message = "商品采集失败!";
            }
            else
                alert.Message = "商品采集失败";
            alert.Show();
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
