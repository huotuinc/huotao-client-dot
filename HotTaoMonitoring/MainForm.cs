using HotTaoMonitoring.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WwChatHttpCore.Objects;

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


        /// <summary>
        /// 当前用户的所用联系人
        /// </summary>
        public List<WXUser> contact_all = new List<WXUser>();

        /// <summary>
        /// 所有单独的微信窗口
        /// </summary>
        public List<WindowInfo> WeChatWindows = new List<WindowInfo>();

        /// <summary>
        /// 是否全部选择
        /// </summary>
        /// <value>true if this instance is selected; otherwise, false.</value>
        public bool IsSelected { get; set; }

        /// <summary>
        /// 监控列表
        /// </summary>
        /// <value>The filter form.</value>
        public ListenForm listenForm { get; set; }

        /// <summary>
        /// 聊天面板
        /// </summary>
        /// <value>The useredit.</value>
        public UserEditControl useredit { get; set; }



        /// <summary>
        /// 我的信息窗口
        /// </summary>
        /// <value>My information.</value>
        public MyInfoForm myInfo { get; set; }


        public MainForm(Login form)
        {
            InitializeComponent();
            loginForm = form;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            WinApi.SetWinFormTaskbarSystemMenu(this);
            windowFormControls = new Dictionary<UserControlsOpts, UserControl>();
            openControl(UserControlsOpts.listen);
        }

        /// <summary>
        /// 打开指定用户控件
        /// </summary>
        /// <param name="uc">The uc.</param>
        public void openControl(UserControlsOpts opt)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<UserControlsOpts>(openControl), new object[] { opt });
            }
            else
            {
                UserControl control = null;
                if (windowFormControls.ContainsKey(opt))
                    windowFormControls.TryGetValue(opt, out control);
                if (control != null && !control.IsDisposed)
                {
                    rightContainer.Controls.Clear();
                    if (opt == UserControlsOpts.listen)
                    {

                        SetListenBg();
                    }
                    else
                    {
                        SetSetBg();
                    }

                    this.rightContainer.Controls.Add(control);
                }
                else
                    ShowControl(opt);
            }
        }

        /// <summary>
        /// 显示界面
        /// </summary>
        /// <param name="opt">The opt.</param>
        private void ShowControl(UserControlsOpts opt)
        {
            if (windowFormControls == null)
                windowFormControls = new Dictionary<UserControlsOpts, UserControl>();
            else
                windowFormControls.Remove(opt);
            switch (opt)
            {
                case UserControlsOpts.listen:
                    OpenWx();
                    break;
                case UserControlsOpts.filter:
                    rightContainer.Controls.Clear();
                    var filter = new SetUserfilterControl(this);
                    this.rightContainer.Controls.Add(new SetUserfilterControl(this));
                    windowFormControls.Add(opt, filter);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Shows the filter.
        /// </summary>
        /// <param name="opt">The opt.</param>
        public void ShowListen(UserControlsOpts opt)
        {
            rightContainer.Controls.Clear();
            UserControl control = null;
            if (windowFormControls.ContainsKey(opt))
                windowFormControls.TryGetValue(opt, out control);
            if (control != null && !control.IsDisposed)
            {
                listenForm = control as ListenForm;
                this.rightContainer.Controls.Add(control);
            }
            else
            {
                listenForm = new ListenForm(this);
                this.rightContainer.Controls.Add(listenForm);
                windowFormControls.Add(opt, listenForm);
            }

            SetListenBg();
        }


        private void SetListenBg()
        {
            lbListen.BackgroundImage = Properties.Resources.icon_bg;
            lbListen.BackColor = Color.Transparent;

            lbSet.BackColor = ConstConfig.HeaderBackColor;
            lbSet.BackgroundImage = null;
        }

        private void SetSetBg()
        {
            lbListen.BackgroundImage = null;
            lbListen.BackColor = ConstConfig.HeaderBackColor;

            lbSet.BackgroundImage = Properties.Resources.icon_bg;
            lbSet.BackColor = Color.Transparent;
        }



        /// <summary>
        /// 弹出提示
        /// </summary>
        /// <param name="text">The text.</param>
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


        public wxLogin wxlogin { get; set; }

        private void OpenWx()
        {
            if (wxlogin == null)
            {
                wxlogin = new wxLogin(this);
                wxlogin.ShowDialog(this);
            }
            else
            {
                if (wxlogin.isCloseWinForm)
                    wxlogin.ShowWx();
            }
        }

        /// <summary>
        /// 关闭监控列表界面
        /// </summary>
        public void CloseMyContact()
        {
            listenForm = null;
            if (windowFormControls == null)
                windowFormControls = new Dictionary<UserControlsOpts, UserControl>();
            else
                windowFormControls.Remove(UserControlsOpts.listen);

            lbListen.BackColor = Color.Silver;
            lbSet.BackColor = Color.White;
            openControl(UserControlsOpts.filter);
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            ApplicationClose();
        }

        /// <summary>
        /// 退出应用
        /// </summary>
        public void ApplicationClose()
        {

            MessageConfirm confirm = new MessageConfirm();
            confirm.Title = "退出提示";
            confirm.Message = "确定要退出客服系统？";
            bool result = false;
            confirm.CallBack += () =>
            {
                result = true;
            };
            confirm.ShowDialog(this);
            if (result)
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
            lbListen.BackgroundImage = lbSet.BackgroundImage = null;
            lbListen.BackColor = lbSet.BackColor = ConstConfig.HeaderBackColor;

            var p1 = sender as PictureBox;
            var p2 = sender as Label;
            var p3 = sender as Panel;
            string _tag = "";
            if (p1 != null)
            {
                p1.Parent.BackgroundImage = Properties.Resources.icon_bg;
                p1.Parent.BackColor = Color.Transparent;
                _tag = p1.Parent.Tag.ToString();
            }
            else if (p2 != null)
            {
                p2.Parent.BackgroundImage = Properties.Resources.icon_bg;
                p2.Parent.BackColor = Color.Transparent;
                _tag = p2.Parent.Tag.ToString();
            }
            else if (p3 != null)
            {
                p3.BackgroundImage = Properties.Resources.icon_bg;
                p3.BackColor = Color.Transparent;
                _tag = p3.Tag.ToString();
            }

            int tag = 0;
            int.TryParse(_tag, out tag);

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

        /// <summary>
        /// 开启线程操作
        /// </summary>
        /// <param name="callback">The callback.</param>
        public void ThreadHandle(Action callback)
        {
            new System.Threading.Thread(() =>
            {
                callback?.Invoke();
            })
            { IsBackground = true }.Start();
        }







        /// <summary>
        /// 当前登录用户头像base64字符串
        /// </summary>
        /// <value>My image.</value>
        public string myImage { get; set; }

        /// <summary>
        /// 当前登录用户头像
        /// </summary>
        /// <value>My user image.</value>
        public Image myUserImage { get; set; }

        public string myUserNickName { get; set; }

        /// <summary>
        /// 设置主窗口标题
        /// </summary>
        /// <param name="title">The title.</param>
        public void SetWinFormTitle(string title)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(SetWinFormTitle), new object[] { title });
            }
            else
            {
                this.Text = this.Text + "-" + title;                
                myUserNickName = title;
            }
        }
        /// <summary>
        /// 设置主窗口图片
        /// </summary>
        /// <param name="image">The image.</param>
        public void SetWinFormImage(Image image)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<Image>(SetWinFormImage), new object[] { image });
            }
            else
            {
                //picWeChatHead.Image = image;
                myUserImage = image;
                if (string.IsNullOrEmpty(myImage))
                    myImage = MyIcon();
            }
        }

        private void picWeChatHead_Click(object sender, EventArgs e)
        {
            if (myInfo == null)
            {
                RECT rect = new RECT();
                WinApi.GetWindowRect(picWeChatHead.Handle, ref rect);
                myInfo = new MyInfoForm(this);
                myInfo.Location = new Point(rect.Right - (rect.Right - rect.Left) / 2, rect.Bottom - (rect.Bottom - rect.Top) / 2);
                myInfo.SetData(myUserNickName, myUserImage);
                myInfo.Show(this);
            }
            else
            {
                myInfo.Close();
                myInfo = null;
            }
        }



        /// <summary>
        /// 获取我的头像(base64)
        /// </summary>
        /// <returns>System.String.</returns>
        private string MyIcon()
        {
            try
            {
                Image image = myUserImage;
                if (myUserImage != null)
                {
                    MemoryStream ms = new MemoryStream();
                    image.Save(ms, ImageFormat.Jpeg);
                    byte[] buffer = ms.ToArray();
                    ms.Dispose();
                    ms.Close();
                    string base64 = Convert.ToBase64String(buffer);
                    if (!string.IsNullOrEmpty(base64))
                        base64 = "data:image/jpg;base64," + base64;

                    return base64;
                }
            }
            catch (Exception)
            {

            }
            return string.Empty;

        }

        /// <summary>
        /// 切换账户登录
        /// </summary>
        public void SwitchLogin()
        {
            MessageConfirm confirm = new MessageConfirm();
            confirm.Title = "提示";
            confirm.Message = "是否切换客服账户？";
            bool result = false;
            confirm.CallBack += () =>
            {
                result = true;
            };
            confirm.ShowDialog(this);
            if (result)
            {
                if (wxlogin != null)
                {
                    if (wxlogin.isLoginCheck)
                        wxlogin.loginClose = true;
                    else
                        wxlogin.loginClose = false;
                    wxlogin.isLoginCheck = false;
                    wxlogin.isCloseWinForm = true;
                    wxlogin.Close();
                    wxlogin = null;
                }

                loginForm.Show();
                this.Close();
            }
        }


        public void SwitchWeChatLogin()
        {
            MessageConfirm confirm = new MessageConfirm();
            confirm.Title = "提示";
            confirm.Message = "是否切换微信账户？";
            bool result = false;
            confirm.CallBack += () =>
            {
                result = true;
            };
            confirm.ShowDialog(this);
            if (result)
            {
                if (wxlogin != null)
                {
                    if (wxlogin.isLoginCheck)
                        wxlogin.loginClose = true;
                    else
                        wxlogin.loginClose = false;
                    wxlogin.isLoginCheck = false;
                    wxlogin.isCloseWinForm = true;
                    wxlogin.Close();
                    wxlogin = null;
                    //清除所有数据
                    listenForm.ClearAllData();
                    openControl(UserControlsOpts.filter);
                }
                OpenWx();
            }

        }



        public void CloseMyInfoForm(object sender, MouseEventArgs e)
        {
            if (myInfo != null)
            {
                myInfo.Close();
                myInfo = null;
            }
        }
    }
}
