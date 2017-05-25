using CefSharp;
using CefSharp.WinForms;
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
    public partial class GoodsCollectBrowser : FormEx
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





        public GoodsCollectBrowser()
        {
           // hotForm = form;
            InitializeComponent();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GoodsCollectBrowser_Load(object sender, EventArgs e)
        {
            //初始化
            InitBrowser();
        }

        private ChromiumWebBrowser browser { get; set; }

        /// <summary>
        /// 初始化浏览器
        /// </summary>
        public void InitBrowser(string url = "")
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
            if (panelBrowser.InvokeRequired)
            {
                panelBrowser.Invoke(new Action(AddBrowser));
            }
            else
            {
                panelBrowser.Controls.Add(browser);
            }
        }


        /// <summary>
        /// 地址发送改变时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Browser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            //SetGoodsUrl(e.Address);
            //GetGoodsInfo();
        }

        private void GoodsCollectBrowser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (!string.IsNullOrEmpty(txtAddress.Text))
                    InitBrowser(txtAddress.Text);
            }
        }
    }
}
