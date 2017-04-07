using HotTaoMonitoring.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotTaoMonitoring
{
    public partial class MainForm : Form
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

        private Login loginForm { get; set; }

        /// <summary>
        /// 面板
        /// </summary>
        /// <value>The window form controls.</value>
        public Dictionary<UserControlsOpts, UserControl> windowFormControls { get; set; }


        public MainForm(Login form)
        {
            InitializeComponent();
            loginForm = form;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            WinApi.SetWinFormTaskbarSystemMenu(this);
            windowFormControls = new Dictionary<UserControlsOpts, UserControl>();

            openControl(UserControlsOpts.filter);
        }

        /// <summary>
        /// 打开指定用户控件
        /// </summary>
        /// <param name="uc">The uc.</param>
        public void openControl(UserControlsOpts opt)
        {
            UserControl control = null;
            rightContainer.Controls.Clear();
            if (windowFormControls.ContainsKey(opt))
                windowFormControls.TryGetValue(opt, out control);
            if (control != null && !control.IsDisposed)
                this.rightContainer.Controls.Add(control);
            else
                ShowControl(opt);
        }


        private void ShowControl(UserControlsOpts opt)
        {
            if (windowFormControls == null)
                windowFormControls = new Dictionary<UserControlsOpts, UserControl>();
            else
                windowFormControls.Remove(opt);
            switch (opt)
            {
                case UserControlsOpts.listen:
                    var listen = new ListenForm(this);
                    this.rightContainer.Controls.Add(listen);
                    windowFormControls.Add(opt, listen);
                    break;
                case UserControlsOpts.filter:
                    var filter = new SetUserfilterControl(this);
                    this.rightContainer.Controls.Add(new SetUserfilterControl(this));
                    windowFormControls.Add(opt, filter);
                    break;
                default:
                    break;
            }
        }



        private void pbClose_Click(object sender, EventArgs e)
        {
            loginForm.Close();
        }

        private void picMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 选择左侧菜单
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Tab_Selected_Click(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            int tag = 0;
            int.TryParse(lb.Tag.ToString(), out tag);

            switch (tag)
            {
                case 1:
                    openControl(UserControlsOpts.filter);
                    break;
                case 2:
                    openControl(UserControlsOpts.listen);
                    break;
                default:
                    break;
            }

        }











    }
}
