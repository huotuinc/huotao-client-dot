using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotTao
{
    public partial class StartTask : Form
    {
        private Main hotForm { get; set; }
        public StartTask(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        Timer startTaskTimer = new Timer();

        private void btnOk_Click(object sender, EventArgs e)
        {
            startTaskTimer.Interval = 1000;
            startTaskTimer.Tick += StartTaskTimer_Tick;
            startTaskTimer.Start();

        }

        /// <summary>
        /// 开始执行任务
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="NotImplementedException"></exception>
        private void StartTaskTimer_Tick(object sender, EventArgs e)
        {
            if (startTaskTimer != null)
                startTaskTimer.Stop();



            StartSend(null);
        }


        private void SendFinish()
        {
            //停止两分钟
            System.Threading.Thread.Sleep(2 * 60 * 1000);
        }
        
        /// <summary>
        /// 开始执行发送
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="image">The image.</param>
        private void StartSend(Image image)
        {
            List<WindowInfo> lst = WinApi.GetAllDesktopWindows();
            if (lst == null || lst.Count() == 0)
            {
                return;
            }

            if (image != null)
            {

                Clipboard.SetImage(image);
                System.Threading.Thread.Sleep(1000);
                //粘贴图片
                foreach (WindowInfo item in lst)
                {
                    //设置微信为输入焦点
                    WinApi.SetActiveWin(item.hWnd);
                    WinApi.Paste(item.hWnd);
                    WinApi.Enter(item.hWnd);
                }
            }          
              
            //粘贴文本
            foreach (WindowInfo item in lst)
            {
                Clipboard.SetText("test");
                //设置微信为输入焦点
                WinApi.SetActiveWin(item.hWnd);
                WinApi.Paste(item.hWnd);
                WinApi.Enter(item.hWnd);
            }
        }

    }
}
