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
    public partial class Loading : Form
    {
        private Main hotForm { get; set; }

        Timer timerClose = null;

        public Loading()
        {
            InitializeComponent();

        }
        /// <summary>
        /// 设置定时关闭时间
        /// </summary>
        /// <param name="Interval">单位毫秒</param>
        public void SetTimerClose(int Interval)
        {
            timerClose = new Timer();
            timerClose.Interval = Interval;
            timerClose.Tick += TimerClose_Tick;
            timerClose.Start();
        }

        private void TimerClose_Tick(object sender, EventArgs e)
        {
            timerClose.Stop();
            timerClose = null;
            CloseForm();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void CloseForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(CloseForm), new object[] { });
            }
            else
            {
                this.Close();
            }
            //this.BeginInvoke((Action)(delegate ()  //等待结束
            //{
            //    this.Close();
            //}));
        }
        protected override CreateParams CreateParams
        {
            get
            {
                //const int WS_EX_APPWINDOW = 0x40000;
                const int WS_EX_TOOLWINDOW = 0x80;
                CreateParams cp = base.CreateParams;
                //cp.ExStyle &= (~WS_EX_APPWINDOW);    // 不显示在TaskBar
                cp.ExStyle |= WS_EX_TOOLWINDOW;      // 不显示在Alt-Tab
                return cp;
            }
        }
    }
}
