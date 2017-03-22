using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HotTao.Controls
{
    /// <summary>
    /// 表示处理信息事件的方法
    /// </summary>
    /// <param name="user"></param>
    public delegate void OKEventHandler();

    public partial class MessageConfirm : Form
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

        

        public MessageConfirm(string message)
        {
            InitializeComponent();
            Message = message;
        }
        public MessageConfirm(string message, string title)
        {
            InitializeComponent();
            Message = message;
            Title = title;            
        }



        public event OKEventHandler CallBack;
        /// <summary>
        /// 设置提示内容
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }
        /// <summary>
        /// 设置标题
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        public MessageConfirm()
        {
            InitializeComponent();
        }


        public MessageConfirm(string message, string title, OKEventHandler callback)
        {
            InitializeComponent();
            Message = message;
            Title = title;
            CallBack = callback;
        }
        public MessageConfirm(string message, OKEventHandler callback)
        {
            InitializeComponent();
            Message = message;
            CallBack = callback;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
            CallBack?.Invoke();
        
        }

        private void MessageConfirm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Title))
            {
                lbTitle.Text = Title;
                this.Text = Title;
            }
            lbContent.Text = Message;
            lbTitle.Text = string.IsNullOrEmpty(Title) ? "提示" : Title;
        }

        private void MessageConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;   //将Handled设置为true，指示已经处理过KeyPress事件  
                this.Close();
                CallBack?.Invoke();
            }
        }

        private void MessageConfirm_Enter(object sender, EventArgs e)
        {                        
            this.Close();
            CallBack?.Invoke();
        }
    }
}
