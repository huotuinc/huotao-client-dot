using HotTao.Controls;
using HotTaoCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HotTao
{
    public partial class Main : BaseForm
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


        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            CheckAutoLogin(user =>
            {
                if (user != null)
                {
                    SetLoginData(user);
                    openControl(new HomeControl(this));
                }
                else
                    openControl(new LoginControl(this));
            });
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            openControl(new HomeControl(this));
        }

        /// <summary>
        /// 销毁Panel
        /// </summary>
        private void DisPanel()
        {
            foreach (UserControl uc in Container.Panel2.Controls)
            {
                uc.Dispose();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 设置面板
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSetting_Click(object sender, EventArgs e)
        {
            openControl(new SetControl(this));
        }

        /// <summary>
        /// 历史
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnHistory_Click(object sender, EventArgs e)
        {
            openControl(new HistoryControl(this));
        }


        /// <summary>
        /// 打开指定用户控件
        /// </summary>
        /// <param name="uc">The uc.</param>
        public void openControl(UserControl uc)
        {
            foreach (UserControl uu in Container.Panel2.Controls)
            {
                if (uu.GetType() == uc.GetType())
                {
                    return;
                }
            }
            uc.Dock = DockStyle.Fill;
            DisPanel();
            this.Container.Panel2.Controls.Add(uc);
        }






        public static UserModel currentUserData = null;
        /// <summary>
        /// 当前登陆用户ID
        /// </summary>
        public int currentUserId { get; set; }
        /// <summary>
        /// 设置登录用户数据
        /// </summary>
        /// <param name="user"></param>
        public void SetLoginData(UserModel user)
        {
            currentUserData = user;
            if (user != null)
                currentUserId = user.userid;
            else
                currentUserId = 0;
        }

    }
}
