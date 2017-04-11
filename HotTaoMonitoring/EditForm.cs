using HotTaoMonitoring.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.IO;
using HotCoreUtils.Helper;

namespace HotTaoMonitoring
{
    public partial class EditForm : Form
    {
        NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

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
        public void WinForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLocation = this.Location;
                mouseOffset = Control.MousePosition;
            }
        }

        public void WinForm_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
        public void WinForm_MouseMove(object sender, MouseEventArgs e)
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

        private MainForm mainForm { get; set; }

        /// <summary>
        /// 监控窗口
        /// </summary>
        /// <value>The listen form.</value>
        private ListenForm listenForm { get; set; }

        /// <summary>
        /// 回复群标识
        /// </summary>
        /// <value>The name of to user.</value>
        public string toUserName { get; set; }

        /// <summary>
        /// 群名称
        /// </summary>
        /// <value>The name of to show.</value>
        public string toShowName { get; set; }


        /// <summary>
        /// 图片路径
        /// </summary>
        /// <value>The image path.</value>
        private string imagePath { get; set; }

        /// <summary>
        /// 回复目标昵称
        /// </summary>
        /// <value>The name of to nick.</value>
        public string toNickName { get; set; }

        /// <summary>
        /// 窗口是否关闭
        /// </summary>
        /// <value>true if this instance is close; otherwise, false.</value>
        public bool isHide { get; set; }

        public int rowIndex { get; set; }


        /// <summary>
        /// 当前群用户标识
        /// </summary>
        /// <value>The MSG send user.</value>
        public string MsgSendUser { get; set; }

        private ChromiumWebBrowser webKitBrowser1 { get; set; }
        public EditForm(MainForm form, ListenForm listen)
        {
            InitializeComponent();
            mainForm = form;
            listenForm = listen;

        }


        private void EditForm_Load(object sender, EventArgs e)
        {
            LoadBrowser();
            SetTitle(toNickName);
        }

        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="title">The title.</param>
        public void SetTitle(string title)
        {
            lbTitle.Text = title;
        }

        public void LoadHtml()
        {
            _totalHtml = loadCacheData();
            webKitBrowser1.LoadHtml(_totalHtml, "http://www.baidu.com");
        }


        private void LoadBrowser()
        {
            if (webKitBrowser1 == null)
            {

                webKitBrowser1 = new ChromiumWebBrowser("http://www.baidu.com");

                BrowserSettings settings = new BrowserSettings()
                {
                    LocalStorage = CefState.Enabled,
                    Javascript = CefState.Enabled,
                };
                webKitBrowser1.Location = new Point(1, 0);
                webKitBrowser1.Dock = DockStyle.Fill;
                hotWebKitBrowser.Controls.Add(webKitBrowser1);
                LoadHtml();
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            isHide = true;
            this.Hide();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (mainForm != null && !string.IsNullOrEmpty(txtContent.Text))
            {
                string content = string.Format("@{0} {1}", toNickName, txtContent.Text);
                mainForm.wxlogin.AutoSendMessage(toUserName, content);
                mainForm.listenForm.SetDataContentStatus(rowIndex, MsgSendUser, toUserName);
                ShowSendMsg("我", txtContent.Text.Replace("\n", "<br/>"));
                writeCacheData();
                txtContent.Clear();
                txtContent.Focus();

            }
        }


        #region  消息框操作相关
        /// <summary>
        /// UI界面显示发送消息
        /// </summary>
        public void ShowSendMsg(string formShowName, string msg)
        {
            string str = @"<script type=""text/javascript"">window.location.hash = ""#ok"";</script> 
            <div class=""chat_content_group self"">               
            <p class=""chat_nick"">" + formShowName + @"</p>   
            <p class=""chat_content"">" + msg + @"</p>
            </div><a id='ok'></a>";
            if (_totalHtml == "")
            {
                _totalHtml = _baseHtml;
            }
            LoadBrowser();
            _totalHtml = _totalHtml.Replace("<a id='ok'></a>", "") + str;
            webKitBrowser1.LoadHtml(_totalHtml, "http://www.baidu.com");
        }
        /// <summary>
        /// UI界面显示发送图片消息
        /// </summary>
        /// <param name="formShowName">Name of the form show.</param>
        /// <param name="msg">The MSG.</param>
        public void ShowSendImageMsg(string formShowName, string base64Image)
        {
            string str = @"<script type=""text/javascript"">window.location.hash = ""#ok"";</script> 
            <div class=""chat_content_group self"">               
            <p class=""chat_nick"">" + formShowName + @"</p>   
            <p class=""chat_content""><img src=""" + base64Image + @""" width=""80px""></p>
            </div><a id='ok'></a>";
            if (_totalHtml == "")
            {
                _totalHtml = _baseHtml;
            }
            LoadBrowser();
            _totalHtml = _totalHtml.Replace("<a id='ok'></a>", "") + str;
            webKitBrowser1.LoadHtml(_totalHtml, "http://www.baidu.com");
        }


        /// <summary>
        /// UI界面显示接收消息
        /// </summary>
        public void ShowReceiveMsg(string toShowName, string msg, string time)
        {

            int idx = msg.IndexOf("<br/>");

            msg = msg.Substring(idx + 5);

            string str = @"<script type=""text/javascript"">window.location.hash = ""#ok"";</script> 
            <div class=""chat_content_group buddy"">               
            <p class=""chat_nick"">" + toShowName + "(" + time + ")" + @"</p>   
            <p class=""chat_content"">" + msg + @"</p>
            </div><a id='ok'></a>";
            if (_totalHtml == "")
            {
                _totalHtml = _baseHtml;
            }
            LoadBrowser();
            _totalHtml = _totalHtml.Replace("<a id='ok'></a>", "") + str;
            webKitBrowser1.LoadHtml(_totalHtml, "http://www.baidu.com");
        }

        /// <summary>
        /// 获取UI界面显示
        /// </summary>
        /// <param name="_toShowName">Name of the _to show.</param>
        /// <param name="_msg">The _MSG.</param>
        /// <returns>System.String.</returns>
        public string GetReceiveMsgHtml(string _toShowName, string _nickName, string _msg, string time)
        {
            string __totalHtml = loadCacheData(_toShowName, _nickName);
            int idx = _msg.IndexOf("<br/>");
            _msg = _msg.Substring(idx + 5);
            string str = @"<script type=""text/javascript"">window.location.hash = ""#ok"";</script> 
            <div class=""chat_content_group buddy"">               
            <p class=""chat_nick"">" + _nickName + "(" + time + ")" + @"</p>   
            <p class=""chat_content"">" + _msg + @"</p>
            </div><a id='ok'></a>";
            if (__totalHtml == "")
            {
                __totalHtml = _baseHtml;
            }
            __totalHtml = __totalHtml.Replace("<a id='ok'></a>", "") + str;
            return __totalHtml;
        }





        public string _totalHtml = "";
        public string _baseHtml = @"<html><head>
        <script type=""text/javascript"">window.location.hash = ""#ok"";</script>
        <style type=""text/css"">

        /*滚动条宽度*/  
        ::-webkit-scrollbar {  
        width: 8px;  
        }  
            
        /* 轨道样式 */  
        ::-webkit-scrollbar-track {  
        }  
   
        /* Handle样式 */  
        ::-webkit-scrollbar-thumb {  
        border-radius: 10px;  
        background: rgba(0,0,0,0.2);   
        }  
  
        /*当前窗口未激活的情况下*/  
        ::-webkit-scrollbar-thumb:window-inactive {  
        background: rgba(0,0,0,0.1);   
        }  
  
        /*hover到滚动条上*/  
        ::-webkit-scrollbar-thumb:vertical:hover{  
        background-color: rgba(0,0,0,0.3);  
        }  
        /*滚动条按下*/  
        ::-webkit-scrollbar-thumb:vertical:active{  
        background-color: rgba(0,0,0,0.7);  
        }  
        textarea{width: 500px;height: 300px;border: none;padding: 5px;}  

	    .chat_content_group.self {
        text-align: right;
        }
        .chat_content_group {
        padding: 0px;
        }
        .chat_content_group.self>.chat_content {
        text-align: left;
        }
        .chat_content_group.self>.chat_content {
        background: #7ccb6b;
        color:#fff;
        /*background: -webkit-gradient(linear,left top,left bottom,from(white,#e1e1e1));
        background: -webkit-linear-gradient(white,#e1e1e1);
        background: -moz-linear-gradient(white,#e1e1e1);
        background: -ms-linear-gradient(white,#e1e1e1);
        background: -o-linear-gradient(white,#e1e1e1);
        background: linear-gradient(#fff,#e1e1e1);*/
        }
        .chat_content {
        display: inline-block;
        min-height: 16px;
        max-width: 50%;
        color:#292929;
        background: #c3f1fd;
        font-family:微软雅黑;
        font-size:14px;
        /*background: -webkit-gradient(linear,left top,left bottom,from(#cf9),to(#9c3));
        background: -webkit-linear-gradient(#cf9,#9c3);
        background: -moz-linear-gradient(#cf9,#9c3);
        background: -ms-linear-gradient(#cf9,#9c3);
        background: -o-linear-gradient(#cf9,#9c3);
        background: linear-gradient(#cf9,#9c3);*/
        -webkit-border-radius: 5px;
        -moz-border-radius: 5px;
        border-radius: 5px;
        padding: 2px 15px;
        word-break: break-all;
        /*box-shadow: 1px 1px 5px #000;*/
        line-height: 1.4;
        }

        .chat_content_group.self>.chat_nick {
        text-align: right;
        }
        .chat_nick {
        font-size: 14px;
        margin: 0px;
        color:#8b8b8b;
        }

        .chat_content_group.self>.chat_content_avatar {
        float: right;
        margin: 0 0 0 10px;
        }

        .chat_content_group.buddy {
        text-align: left;
        }
        .chat_content_group {
        padding: 10px;
        }
        .chat_content_avatar {
        float: left;
        width: 40px;
        height: 40px;
        margin-right: 10px;
        }
        .imgtest{margin:10px 5px;
        overflow:hidden;}
        .list_ul figcaption p{
        font-size:11px;
        color:#aaa;
        }
        .imgtest figure div{
        display:inline-block;
        margin:5px auto;
        width:100px;
        height:100px;
        border-radius:100px;
        border:2px solid #fff;
        overflow:hidden;
        -webkit-box-shadow:0 0 3px #ccc;
        box-shadow:0 0 3px #ccc;
        }
        .imgtest img{width:100%;
        min-height:100%; text-align:center;}
	    </style>
        </head><body>";
        #endregion


        private bool IsUpload { get; set; }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (IsUpload) return;
            try
            {
                if (this.uploadImage.ShowDialog() == DialogResult.OK)
                {
                    IsUpload = true;
                    if (MessageBox.Show("您确定要发送该图片？", "提示", MessageBoxButtons.OK) == DialogResult.OK)
                    {

                        string filename = this.uploadImage.FileName;
                        string safefilename = this.uploadImage.SafeFileName;
                        mainForm.ThreadHandle(() =>
                        {
                            using (Stream stream = new FileStream(filename, FileMode.Open))
                            {
                                byte[] buffer = new byte[stream.Length];
                                //读取图片字节流
                                stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
                                string base64 = "data:img/jpg;base64," + Convert.ToBase64String(buffer);
                                ShowSendImageMsg("我", base64);


                                string content = string.Format("@{0}", toNickName);
                                mainForm.wxlogin.AutoSendMessage(toUserName, content);
                                mainForm.wxlogin.AutoSendImage(toUserName, safefilename, stream);

                                mainForm.listenForm.SetDataContentStatus(rowIndex, MsgSendUser, toUserName);


                                IsUpload = false;
                            }
                        });
                    }
                    else
                        IsUpload = false;
                }
            }
            catch (Exception ex)
            {
                IsUpload = false;
                log.Error(ex);
                MessageBox.Show("图片发送失败", "错误");
            }
        }





        /// <summary>
        /// 保存到文件
        /// </summary>
        public void writeCacheData()
        {
            string filePath = System.IO.Path.Combine(Application.StartupPath, "data/cacheData");
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            filePath += "/" + EncryptHelper.MD5(toShowName + toNickName) + ".cache";
            if (!File.Exists(filePath))
                File.Create(filePath).Dispose();
            StreamWriter sw = new StreamWriter(@filePath, false);
            sw.Write(_totalHtml);
            sw.Close();//写入
        }


        /// <summary>
        /// 保存聊天记录
        /// </summary>
        /// <param name="_toShowName">Name of the _to show.</param>
        /// <param name="_toNickName">Name of the _to nick.</param>
        /// <param name="content">The content.</param>
        public void writeCacheData(string _toShowName, string _toNickName, string content)
        {
            string filePath = System.IO.Path.Combine(Application.StartupPath, "data/cacheData");
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            filePath += "/" + EncryptHelper.MD5(_toShowName + _toNickName) + ".cache";
            if (!File.Exists(filePath))
                File.Create(filePath).Dispose();
            StreamWriter sw = new StreamWriter(@filePath, false);
            sw.Write(content);
            sw.Close();//写入
        }


        /// <summary>
        /// 读取本地缓存数据
        /// </summary>
        /// <returns></returns>
        public string loadCacheData()
        {
            try
            {
                string filePath = System.IO.Path.Combine(Application.StartupPath, "data/cacheData/" + EncryptHelper.MD5(toShowName + toNickName) + ".cache");
                if (File.Exists(filePath))
                {
                    FileStream aFile = new FileStream(filePath, FileMode.Open);
                    StreamReader sr = new StreamReader(aFile);
                    string str = sr.ReadToEnd();
                    sr.Close();
                    sr.Dispose();
                    aFile.Close();
                    aFile.Dispose();
                    return str;
                }
                return string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 读取本地缓存数据
        /// </summary>
        /// <returns></returns>
        public string loadCacheData(string _toShowName, string _toNickName)
        {
            try
            {
                string filePath = System.IO.Path.Combine(Application.StartupPath, "data/cacheData/" + EncryptHelper.MD5(_toShowName + _toNickName) + ".cache");
                if (File.Exists(filePath))
                {
                    FileStream aFile = new FileStream(filePath, FileMode.Open);
                    StreamReader sr = new StreamReader(aFile);
                    string str = sr.ReadToEnd();
                    sr.Close();
                    sr.Dispose();
                    aFile.Close();
                    aFile.Dispose();
                    return str;
                }
                return string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        private bool isKeyControl { get; set; }

        private void EditForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.RControlKey || e.KeyCode == Keys.LControlKey)
            {
                e.Handled = true;
                isKeyControl = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (isKeyControl)
                    txtContent.AppendText("\r\n");
                else
                    btnSend_Click(null, null);
            }
        }

        private void EditForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.RControlKey || e.KeyCode == Keys.LControlKey)
            {
                e.Handled = true;
                isKeyControl = false;
            }
        }
    }
}
