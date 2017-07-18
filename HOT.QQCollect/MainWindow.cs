using HOTReuestService;
using Newtonsoft.Json;
using QQLogin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOT.QQCollect
{
    public partial class MainWindow : FormEx
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

        public static object lock_goods = new object();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LoginQQ();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出QQ采集?", "退出提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
                Application.ExitThread();
                Process.GetCurrentProcess().Kill();
            }
        }

        private void picMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        public QQMainControl qqForm;
        /// <summary>
        /// 登录QQ
        /// </summary>
        private void LoginQQ()
        {
            if (qqForm == null)
            {
                qqForm = new QQLogin.QQMainControl();
                qqForm.IsShowAutoSend = false;
                qqForm.IsShowCustomTemplate = false;
                qqForm.IsShowBigCowGoodsCaiji = true;
                qqForm.CloseQQHandler += QqForm_CloseQQHandler;
                qqForm.BuildGoodsHandler += QqForm_BuildGoodsHandler;
            }
            qqForm.Dock = DockStyle.Fill;
            this.QQMainView.Controls.Add(qqForm);
        }

        /// <summary>
        /// 采集商品处理
        /// </summary>
        /// <param name="msgCode"></param>
        /// <param name="msgContent"></param>
        /// <param name="urls"></param>
        /// <param name="isAutoSend"></param>
        /// <param name="EnableCustomTemplate"></param>
        /// <param name="callback"></param>
        private void QqForm_BuildGoodsHandler(long msgCode, string msgGroupName, string msgContent, string msgFullContent, List<string> urls, bool isAutoSend, bool EnableCustomTemplate, Action<MessageCallBackType, int, int> callback)
        {
            lock (lock_goods)
            {
                try
                {
                    bool bigCow = true;
                    if (qqForm != null)
                        bigCow = qqForm.EnableBigCow;
                    List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    if (urls.Count() > 0)
                        data["url"] = urls[0];
                    else
                        data["url"] = "";
                    if (urls.Count() > 1)
                        data["url2"] = urls[1];
                    else
                        data["url2"] = "";
                    data["message"] = msgFullContent;
                    list.Add(data);

                    string jsonUrls = JsonConvert.SerializeObject(list);

                    callback?.Invoke(MessageCallBackType.正在准备, 0, 0);
                    //根据地址，获取商品优惠信息
                    bool result = HotJavaApi.UploadGoodsbyLink(qqForm.GetQQ(), msgGroupName, jsonUrls, bigCow ? "daniu" : "");

                    if (result)
                        callback?.Invoke(MessageCallBackType.完成, 0, 0);
                    else
                        callback?.Invoke(MessageCallBackType.失败, 0, 0);
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    callback?.Invoke(MessageCallBackType.失败, 0, 0);
                }
            }
        }

        private void QqForm_CloseQQHandler()
        {
            picClose_Click(null, null);
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            pHead.Visible = true;
        }
    }
}
