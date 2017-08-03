using CefSharp;
using CefSharp.WinForms;
using HotTao.Properties;
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
using System.Text;
using System.Text.RegularExpressions;
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


        private string defaultUrl { get; set; }

        private static string jsCode { get; set; }
        private static string defaultJsCode = @"var Injection={HOST_NAME:window.location.hostname,WEBSITES:['dataoke','haodanku','taokezhushou','shihuizhu','localhost'],dataoke:function(){var self=this;var button=this.getButton('.copy_text');var em=$('<em>一键点击，轻松加入采集列表</em>');em.css({'display':'block','font-size':'14px','font-style':'normal'});button.css({'position':'absolute','top':0,'padding-top':'30%','height':'100%','width':'100%','font-size':'28px','background':'rgba(51,51,51,.8)','box-sizing':'border-box'}).text('火淘采集').append(em).prev().hide().prev().hide();button.off('click');button.on('click',function(){var $target=$(this).find('.copyText');self.sendData($target)})},haodanku:function(){var self=this;var button=self.getButton('.fq-copy');var em=$('<em>一键点击，轻松加入采集列表</em>');em.css({'display':'block','font-size':'14px','font-style':'normal'});button.css({'position':'absolute','top':0,'padding-top':'30%','height':'100%','width':'100%','font-size':'28px','background':'rgba(51,51,51,.8)','box-sizing':'border-box'}).text('火淘采集').append(em).parent().css({'height':'100%','width':'100%'}).siblings().hide().parent().css({'top':0,'height':'265px'});button.off('click');button.on('click',function(){var href=$(this).closest('ul').prev('a').attr('href');var html=$(this).data('tips');var $target=$('<div></div>').html(html+' '+href);self.sendData($target)})},taokezhushou:function(){var self=this;var button=self.getButton('.copytext-btn');button.css({'width':'100%','font-size':'20px','background':'rgba(51,51,51,.8)','box-sizing':'border-box'}).text('火淘采集');button.off('click');button.on('click',function(){var $target=$(this).next('.media-list-box').find('.media-text-area');self.sendData($target)})},shihuizhu:function(){var self=this;var button=self.getButton('.official');var em=$('<em>一键点击，轻松加入采集列表</em>');em.css({'display':'block','margin-top':'10px','font-size':'14px','font-style':'normal'});button.css({'opacity':0,'position':'absolute','top':0,'left':0,'padding-top':'30%','height':'272px','width':'100%','font-size':'28px','background':'rgba(51,51,51,.8)','color':'#fff','box-sizing':'border-box'}).text('火淘采集').append(em).closest('.goods-sale').next('.intro').css({'top':0});button.mouseenter(function(){$(this).css('opacity',1)});button.mouseleave(function(){$(this).css('opacity',0)});button.off('click');button.on('click',function(){var $target=$(this).closest('.goods-sale').next('.intro');self.sendData($target)})},getButton:function(className){return $(className)},localhost:function(){console.info('==== This Localhost ====')},sendData:function($target){var div=$('<div></div>');var data={};data.image=$target.find('img').attr('src');div.append($target.html().replace(/<br>/g,' '));data.text=$.trim(div.text());jsGoods.copyGoodsContent(data.image,data.text)},run:function(type){this[type]()},init:function(){var self=this;self.WEBSITES.forEach(function(val){if(self.HOST_NAME.indexOf(val)>-1){return self.run(val)}})}};Injection.init();";

        public GoodsCollectBrowser(Main form, string url = "")
        {
            hotForm = form;
            defaultUrl = url;
            InitializeComponent();
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;

        }

        private void picClose_Click(object sender, EventArgs e)
        {
            if (!Runing)
            {
                hotForm.collectBrowser.Dispose();
                hotForm.collectBrowser = null;
                this.Close();
            }
            else
            {
                MessageConfirm confirm = new MessageConfirm("正在进行商品采集，你确定要退出吗？");
                confirm.CallBack += () =>
                {
                    hotForm.collectBrowser.Dispose();
                    hotForm.collectBrowser = null;
                    this.Close();

                };
                confirm.ShowDialog(this);
            }
        }

        private void GoodsCollectBrowser_Load(object sender, EventArgs e)
        {
            //初始化
            InitBrowser(defaultUrl);
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
                    browser.RegisterJsObject("jsGoods", new GoodsCollectBrowser(hotForm), false);
                    browser.BrowserSettings = settings;
                    browser.Dock = DockStyle.Fill;
                    browser.LifeSpanHandler = new LifeSpanHandler();
                    browser.AddressChanged += Browser_AddressChanged;
                    browser.FrameLoadEnd += Browser_FrameLoadEnd;
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
            InsertJsCode();
        }

        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            InsertJsCode();
        }


        private void InsertJsCode()
        {
            if (string.IsNullOrEmpty(jsCode))
            {
                var js = BaseRequestService.GetInjectionJsCode();
                if (!string.IsNullOrEmpty(js))
                    jsCode = js;
                else
                    jsCode = defaultJsCode;
            }
            browser.ExecuteScriptAsync(jsCode);
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
        /// 设置商品链接
        /// </summary>
        /// <param name="url"></param>
        public void SetGoodsUrl(string url)
        {
            if (this.txtAddress.InvokeRequired)
            {
                this.txtAddress.Invoke(new Action<string>(SetGoodsUrl), new object[] { url });
            }
            else
            {
                txtAddress.Text = url;

            }
        }

        /// <summary>
        /// 地址发送改变时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Browser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            InsertJsCode();
            SetGoodsUrl(e.Address);



        }

        private void GoodsCollectBrowser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                OpenGoodsUrl();
            }
        }

        private void picRefresh_Click(object sender, EventArgs e)
        {
            OpenGoodsUrl();
        }


        /// <summary>
        /// 打开地址
        /// </summary>
        private void OpenGoodsUrl()
        {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                return;
            }
            LoadBrowser(txtAddress.Text);
        }

        /// <summary>
        /// 加载浏览器地址
        /// </summary>
        /// <param name="address"></param>
        public void LoadBrowser(string address)
        {
            browser.Load(address);
            browser.Focus();
            SetGoodsUrl(txtAddress.Text);
        }



        private void picForward_Click(object sender, EventArgs e)
        {
            browser.Forward();
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            browser.Back();
        }


        /// <summary>
        /// 当前窗口是否已是最大化
        /// </summary>
        private bool isMax { get; set; }


        /// <summary>
        /// 最大化切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picMax_Click(object sender, EventArgs e)
        {
            if (!isMax)
            {
                this.WindowState = FormWindowState.Maximized;
                picMax.Image = Resources.max_01;
                isMax = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                picMax.Image = Resources.max;
                isMax = false;
            }
            ResizeWin();
        }

        /// <summary>
        /// 窗口大小发生变化时调用
        /// </summary>
        private void ResizeWin()
        {
            RECT rect = new RECT();
            WinApi.GetWindowRect(this.Handle, ref rect);
            plSite.Width = rect.Right - rect.Left - 195;
            panelBrowser.Size = new Size(rect.Right - rect.Left - 2, rect.Bottom - rect.Top - 94);
            plRightTop.Location = new Point(rect.Right - rect.Left - 112, 0);
            plfooter.Width = rect.Right - rect.Left;
            plfooter.Location = new Point(0, rect.Bottom - rect.Top - 60);
            btnAddGoods.Location = new Point(rect.Right - rect.Left - 100, btnAddGoods.Location.Y);

        }


        /// <summary>
        /// 最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        /// <summary>
        /// 是否在执行
        /// </summary>
        private bool Runing { get; set; }
        /// <summary>
        /// 当前任务ID
        /// </summary>
        private string taskid { get; set; }
        public Loading ld { get; set; }
        /// <summary>
        /// 是否已加载完成
        /// </summary>
        private bool isLoadingCompleted { get; set; } = true;

        /// <summary>
        /// 开始采集网址商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddGoods_Click(object sender, EventArgs e)
        {
            string url = txtAddress.Text;
            if (string.IsNullOrEmpty(url))
            {
                return;
            }
            if (isLoadingCompleted)
            {
                isLoadingCompleted = false;
                Runing = true;
                if (ld != null && !ld.IsDisposed)
                {
                    ld.Dispose();
                    ld.Close();
                }
                ld = new Loading();
                ld.StartPosition = FormStartPosition.Manual;
                RECT rect = new RECT();
                WinApi.GetWindowRect(this.Handle, ref rect);
                ld.Location = new Point(rect.Left, rect.Top);
                ld.Size = new Size(rect.Right - rect.Left, rect.Bottom - rect.Top);
                ld.Show(this);
                setTipMsg("正在准备采集...");
            }
            if (!Runing) return;
            new System.Threading.Thread(() =>
            {
                //建立采集计划
                taskid = LogicGoods.Instance.startDigOnePage(MyUserInfo.LoginToken, url);
                if (string.IsNullOrEmpty(taskid))
                {
                    Runing = false;
                    LoadingClose();
                    AlertTip("服务器开小差了，请稍后再试！");
                }
                else
                {
                    while (Runing)
                    {
                        setTipMsg("采集中...请稍后！");
                        doPolling();
                        System.Threading.Thread.Sleep(500);
                    }
                }
            })
            { IsBackground = true }.Start();
        }

        /// <summary>
        /// 关闭loading
        /// </summary>
        private void LoadingClose()
        {
            if (!isLoadingCompleted)
            {
                if (this.ld != null && this.ld.InvokeRequired)
                {
                    this.ld.Invoke(new Action(LoadingClose), new object[] { });
                }
                else
                {
                    lbTipMsg.Text = "";
                    if (ld != null)
                        ld.Close();

                    isLoadingCompleted = true;
                }
            }
        }
        /// <summary>
        /// 设置提示内容
        /// </summary>
        /// <param name="text"></param>
        private void setTipMsg(string text)
        {
            if (this.lbTipMsg.InvokeRequired)
            {
                this.lbTipMsg.Invoke(new Action<string>(setTipMsg), new object[] { text });
            }
            else
            {
                lbTipMsg.Text = text;
            }
        }



        /// <summary>
        /// 轮询
        /// </summary>
        private void doPolling()
        {
            if (string.IsNullOrEmpty(taskid))
                return;
            var result = LogicGoods.Instance.queryGoods(MyUserInfo.LoginToken, taskid);
            if (result != null)
            {
                Runing = !result.finish;
                if (result.urls != null && result.urls.Count() > 0)
                {
                    importGoods(result.urls);
                }
            }
        }



        /// <summary>
        /// 提示
        /// </summary>
        /// <param name="text"></param>
        public void AlertTip(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(AlertTip), new object[] { text });
            }
            else
            {
                MessageAlert alert = new MessageAlert(text, "提示");
                alert.StartPosition = FormStartPosition.CenterScreen;
                alert.Show();
            }
        }


        public void AlertConfirm(string text, Action<bool> result)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(AlertTip), new object[] { text });
            }
            else
            {
                bool isOk = false;
                MessageConfirm alert = new MessageConfirm(text, "提示");
                alert.StartPosition = FormStartPosition.CenterScreen;
                alert.CallBack += () => { isOk = true; };
                alert.ShowDialog(this);
                result?.Invoke(isOk);
            }
        }


        /// <summary>
        /// 打开指定采集网
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenUrl(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            txtAddress.Text = btn.Tag.ToString();
            OpenGoodsUrl();
        }


        /// <summary>
        /// 商品导入
        /// </summary>
        /// <param name="data"></param>
        public void importGoods(List<GoodsCollertUrlsModel> data)
        {
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            foreach (var item in data)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict["url"] = item.goodsUrl;
                dict["url2"] = item.couponUrl;
                dict["message"] = string.Format("{0}，券后【{1}元】包邮秒杀，领券地址：{2} \r\n 下单地址:{3} ", item.goodsName, item.couponAfterPrice.ToString("f2"), item.couponUrl, item.goodsUrl);
                list.Add(dict);
            }
            string jsonUrls = JsonConvert.SerializeObject(list);
            setTipMsg(string.Format("采集完成，共采集到{0}个商品,正在解析商品...", data.Count()));
            //根据地址，获取商品优惠信息
            List<GoodsSelectedModel> goodsData = LogicGoods.Instance.getGoodsByLink(MyUserInfo.LoginToken, jsonUrls);
            try
            {
                if (goodsData != null && goodsData.Count() > 0)
                {
                    setTipMsg(string.Format("商品解析完成，共{0}个商品,正在保存...", goodsData.Count()));
                    bool isUpdate = false;
                    foreach (var goods in goodsData)
                    {
                        try
                        {
                            //保存商品到本地数据库
                            LogicGoods.Instance.SaveGoods(goods, MyUserInfo.currentUserId, out isUpdate);
                        }
                        catch (Exception ex)
                        {
                            log.Error(ex);
                        }
                    }
                    LoadingClose();
                    AlertTip("数据采集完成");
                }
                else
                {
                    LoadingClose();
                    AlertTip("数据采集完成");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                LoadingClose();
                AlertTip("服务器开小差了，请稍后再试！");
            }

        }








        /// <summary>
        /// 复制商品文案
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <param name="text"></param>
        public void copyGoodsContent(string imageUrl, string text)
        {

            //new System.Threading.Thread(() =>
            //{
            List<string> urls = GetUrls(text);

            //UrlsHelper urlsHelper = new UrlsHelper();
            //urlsHelper.Url = urls.Count() > 0 ? urls[0] : "";
            //urlsHelper.Url2 = urls.Count() > 1 ? urls[1] : "";

            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["url"] = urls.Count() > 0 ? urls[0] : "";
            data["url2"] = urls.Count() > 1 ? urls[1] : "";
            data["message"] = text;
            list.Add(data);
            string jsonUrls = JsonConvert.SerializeObject(list);
            List<GoodsSelectedModel> goodsData = LogicGoods.Instance.getGoodsByLink(MyUserInfo.LoginToken, jsonUrls);
            if (goodsData != null && goodsData.Count() > 0)
            {
                try
                {
                    var goods = goodsData[0];
                    goods.goodsImageUrl = imageUrl;
                    string url = urls.Last();
                    int idx = text.IndexOf(url);
                    goods.goodsIntro = text.Substring(idx).Replace(url,"");


                    bool isUpdate = false;
                    //保存商品到本地数据库
                    LogicGoods.Instance.SaveGoods(goods, MyUserInfo.currentUserId, out isUpdate);
                    MessageBox.Show("操作成功!");
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            }
            //})
            //{ IsBackground = true }.Start();
        }


        /// <summary>
        /// 返回指定内容中的url数量
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<string> GetUrls(string input)
        {
            input = input.Replace("&amp;", "&");
            string pattern = "http[s]?://.*?(?!(\\w|\\.|/|\\?|\\=|&|%|;))";
            List<string> urls = new List<string>();
            foreach (Match match in Regex.Matches(input, pattern))
            {
                if (!urls.Contains(match.Value))
                    urls.Add(match.Value);
            }
            return urls;
        }
    }
}
