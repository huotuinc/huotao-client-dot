using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace HotTao.Controls
{
    public partial class TestControl1 : UserControl
    {
        public TestControl1()
        {
            InitializeComponent();
        }




        #region 开始模拟鼠标操作桌面微信发送内容
        //定义变量
        const int AnimationCount = 5;
        /// <summary>
        /// 鼠标移动结束坐标
        /// </summary>
        private Point endPosition;
        private int count;
        /// <summary>
        /// 是否松开鼠标左键
        /// </summary>
        bool isMouseLeftUp = true;
        /// <summary>
        /// 移动鼠标到搜索框定时器
        /// </summary>
        System.Windows.Forms.Timer seachBoxTimer = null;

        /// <summary>
        /// 开始模拟鼠标操作桌面微信，（微信聊天列表不能有置顶聊天）
        /// </summary>
        public void StartSimulateWeChat()
        {
            IntPtr awin = WinApi.GetWeChatWindow();
            if (awin == IntPtr.Zero)
            {
                MessageBox.Show("获取微信主窗口句柄失败", "提示");
                return;
            }
            WinApi.CloseWindow(awin);
            WinApi.ShowWindow(awin, WinApi.NCmdShowFlag.SW_SHOWNORMAL);//在显示
            RECT rc = new RECT();
            WinApi.GetWindowRect(awin, ref rc);
            endPosition.X = rc.Left;
            endPosition.Y = rc.Top;
            if (true)
            {
                //应该打开窗口有延迟，所以需要定时去操作
                ////暂停2秒
                Thread.Sleep(2000);
                moveMouseToWeChatSeachBox(endPosition);
            }
        }

        /// <summary>
        /// 移动鼠标到搜索框
        /// </summary>
        /// <param name="end">鼠标移动结束坐标</param>
        public void moveMouseToWeChatSeachBox(Point endpos)
        {
            endPosition.X = endPosition.X + 70;
            endPosition.Y = endPosition.Y + 26;
            seachBoxTimer = new System.Windows.Forms.Timer();
            this.count = AnimationCount;
            seachBoxTimer.Tick += SeachBoxTimer_Tick;
            seachBoxTimer.Start();
        }

        /// <summary>
        /// 定时移动鼠标事件，用于显示鼠标的移动轨迹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeachBoxTimer_Tick(object sender, EventArgs e)
        {
            //count = WinApi.mouseAnimation(endPosition, MousePosition, count, isMouseLeftUp, (p =>
            //{
            //    if (!isMouseLeftUp)
            //    {
            //        WinApi.mouse_event(WinApi.MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
            //    }
            //    seachBoxTimer.Stop();
            //    seachBoxTimer = null;
            //    //搜索对象
            //    SeachTarget();
            //}));
        }
        /// <summary>
        /// 复制文本到搜索框中
        /// </summary>
        private void SeachTarget()
        {
            //往搜索框中写入文本
            SendKeys.SendWait("文件传输助手");
            //暂停2秒
            Thread.Sleep(2000);

            Point curPos = new Point(endPosition.X + 20, endPosition.Y + 60);

            WinApi.SetCursorPos(curPos.X, curPos.Y);
            //鼠标点击
            WinApi.mouse_event(WinApi.MouseEventFlag.LeftDown | WinApi.MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);

            Thread.Sleep(1000);
            //按下鼠标左键
            WinApi.mouse_event(WinApi.MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);

            Thread.Sleep(1000);
            int stepx = 100;
            int stepy = 0;

            WinApi.mouse_event(WinApi.MouseEventFlag.Move, stepx, stepy, 0, UIntPtr.Zero);

            //松开鼠标
            Thread.Sleep(1000);
            WinApi.mouse_event(WinApi.MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
            Thread.Sleep(1000);

            IntPtr childForm = WinApi.GetWeChatWindowEx();
            if (childForm == IntPtr.Zero)
            {
                MessageBox.Show("获取微信窗口句柄失败", "提示");
                return;
            }
            //RECT rc = new RECT();
            //WinApi.GetWindowRect(childForm, ref rc);

            //往聊天窗口中写入文本
            //SendKeys.SendWait(DateTime.Now.ToLocalTime().ToString());
            WinApi.InputStr(childForm, DateTime.Now.ToLocalTime().ToString());

            //WinApi.InputImage(childForm, "http://img01.taobaocdn.com/bao/uploaded/i1/TB1wz_KOXXXXXbBapXXXXXXXXXX_!!0-item_pic.jpg");
            //回车
            WinApi.keybd_event(Keys.Enter, 0, 0, 0);

            //Thread.Sleep(2000);
            //这个流程结束后，关闭当前窗口
            // WinApi.CloseWindow(childForm);
            // Thread.Sleep(2000);
        }




        #endregion
    }
}
