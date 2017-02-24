using HotTao.Controls;
using HotTaoCore.Logic;
using HotTaoCore.Models;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
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


        NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();


        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        public static extern int GetWindowLong(HandleRef hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLong(HandleRef hWnd, int nIndex, int dwNewLong);

        /// <summary>
        /// 淘宝账号
        /// </summary>
        /// <value>The taobao no.</value>
        public string taobaoNo { get; set; }
        /// <summary>
        /// 淘宝密码
        /// </summary>
        public string taobaoPwd { set; get; }
        /// <summary>
        /// 是否已模拟淘宝登录
        /// </summary>
        /// <value>true if this instance is taobao login; otherwise, false.</value>
        public bool isTaobaoLogin { get; set; }


        /// <summary>
        /// 设置淘宝账号
        /// </summary>
        /// <param name="no">The no.</param>
        /// <param name="pwd">The password.</param>
        public void SetTaobaoAccount(string no, string pwd)
        {
            taobaoNo = no;
            taobaoPwd = pwd;
        }

        public Main()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Main_Load(object sender, EventArgs e)
        {

            //无标题窗体右键菜单
            int WS_SYSMENU = 0x00080000; // 系统菜单
            int WS_MINIMIZEBOX = 0x20000; // 最大最小化按钮
            int windowLong = (GetWindowLong(new HandleRef(this, this.Handle), -16));
            SetWindowLong(new HandleRef(this, this.Handle), -16, windowLong | WS_SYSMENU | WS_MINIMIZEBOX);

            isTaobaoLogin = false;
            CheckAutoLogin(user =>
            {
                if (user != null)
                {
                    SetLoginData(user);
                    openControl(new GoodsControl(this));
                }
                else
                    openControl(new LoginControl(this));
            });


        }

        /// <summary>
        /// 检查登录状态
        /// </summary>
        /// <returns></returns>
        public bool CheckLogin()
        {
            try
            {
                if (currentUserData != null)
                {
                    var user = LogicUser.Instance.getUserInfoByToken(currentUserData.loginToken);
                    if (user != null && user.activate == 1)
                    {
                        LoginSync = true;
                        return true;
                    }
                }
                LoginSync = false;
                openControl(new LoginControl(this));
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnHome_Click(object sender, EventArgs e)
        {
            SetSelectedBackgroundImage(sender);
            openControl(new GoodsControl(this));
        }

        /// <summary>
        /// 微信群发
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnWeChat_Click(object sender, EventArgs e)
        {
            SetSelectedBackgroundImage(sender);
            openControl(new TaskControl(this));
        }


        /// <summary>
        /// 销毁Panel
        /// </summary>
        private void DisPanel()
        {
            foreach (UserControl uc in this.HotContainer.Panel2.Controls)
            {
                if (uc != null)
                    uc.Dispose();
            }
        }
        /// <summary>
        /// 设置面板
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSetting_Click(object sender, EventArgs e)
        {
            SetSelectedBackgroundImage(sender);
            openControl(new SetControl(this));
        }

        /// <summary>
        /// 计划列表
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnHistory_Click(object sender, EventArgs e)
        {
            SetSelectedBackgroundImage(sender);
            openControl(new HistoryControl(this));
        }

        /// <summary>
        /// 客服
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnCustomService_Click(object sender, EventArgs e)
        {
            SetSelectedBackgroundImage(sender);
            openControl(new CustomServiceControl(this));
        }


        private void SetSelectedBackgroundImage(object sender)
        {
            foreach (var item in HotContainer.Panel1.Controls)
            {
                Panel pl = item as Panel;
                if (pl != null)
                    pl.BackgroundImage = null;
            }
            var p1 = sender as PictureBox;
            var p2 = sender as Label;
            var p3 = sender as Panel;
            if (p1 != null)
                p1.Parent.BackgroundImage = Properties.Resources.icon_bg;
            else if (p2 != null)
                p2.Parent.BackgroundImage = Properties.Resources.icon_bg;
            else if (p3 != null)
                p3.BackgroundImage = Properties.Resources.icon_bg;
        }


        /// <summary>
        /// 打开指定用户控件
        /// </summary>
        /// <param name="uc">The uc.</param>
        public void openControl(UserControl uc)
        {
            HotContainer.Panel2.Controls.Clear();
            foreach (UserControl uu in HotContainer.Panel2.Controls)
            {
                if (uu != null)
                {
                    if (uu.GetType() == uc.GetType())
                    {
                        return;
                    }
                }
            }
            uc.Dock = DockStyle.Fill;
            //DisPanel();
            this.HotContainer.Panel2.Controls.Add(uc);
        }


        /// <summary>
        /// 设置微信群发为选中状态
        /// </summary>
        public void SetWeChatTabSelected()
        {
            foreach (var item in HotContainer.Panel1.Controls)
            {
                Panel pl = item as Panel;
                if (pl != null)
                    pl.BackgroundImage = null;
            }
            btnWeChat.Parent.BackgroundImage = Properties.Resources.icon_bg;
        }
        /// <summary>
        /// 设置首页为选中状态
        /// </summary>
        public void SetHomeTabSelected()
        {
            foreach (var item in HotContainer.Panel1.Controls)
            {
                Panel pl = item as Panel;
                if (pl != null)
                    pl.BackgroundImage = null;
            }
            btnHome.Parent.BackgroundImage = Properties.Resources.icon_bg;
        }



        public static UserModel currentUserData = null;
        /// <summary>
        /// 当前登陆用户ID
        /// </summary>
        public int currentUserId { get; set; }

        public bool LoginSync = false;

        /// <summary>
        /// 设置登录用户数据
        /// </summary>
        /// <param name="user"></param>
        public void SetLoginData(UserModel user)
        {
            currentUserData = user;
            if (user != null)
            {
                LoginSync = true;
                currentUserId = user.userid;
                ((Action)(delegate ()
                {
                    while (LoginSync)
                    {
                        CheckLogin();
                        System.Threading.Thread.Sleep(1000);
                    }
                })).BeginInvoke(null, null);
            }
            else
                currentUserId = 0;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
            Process.GetCurrentProcess().Kill();
            Application.ExitThread();
            Environment.Exit(Environment.ExitCode);
        }

        private void pbMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_MINIMIZEBOX = 0x00020000;  // Winuser.h中定义
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style | WS_MINIMIZEBOX;   // 允许最小化操作
                return cp;
            }
        }
    }
}
