using HOTReuestService;
using HOTReuestService.Helper;
using HotTaoCore.Logic;
using HotTaoCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotTaoMonitoring
{
    public partial class Login : Form
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

        public Login()
        {
            InitializeComponent();
            InitDataBase();
        }

        private void picClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void lbLoginName_Click(object sender, EventArgs e)
        {
            this.loginName.Focus();
        }

        private void lbLoginPwd_Click(object sender, EventArgs e)
        {
            this.loginPwd.Focus();
        }

        private void loginName_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(loginName.Text))
                lbLoginName.Visible = false;
            else
                lbLoginName.Visible = true;
        }

        private void loginPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(lbLoginPwd.Text))
                lbLoginPwd.Visible = false;
            else
                lbLoginPwd.Visible = true;
        }



        private void loginName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(loginName.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.X, e.Bounds.Y + 3);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //设置阴影
            // WinApi.SetWinFormTaskbarSystemMenu(this);
            loginName.Focus();
            var data = LogicHotTao.Instance(0).GetLoginNameList();
            if (data != null && data.Count() > 0)
            {
                loginName.Text = data[0].login_name;
                this.ckbSavePwd.Checked = true;
                this.IsRememberPassword = true;
                lbLoginName.Visible = false;
                if (!string.IsNullOrEmpty(data[0].login_password) && data[0].is_save_pwd == 1)
                {
                    loginPwd.Text = data[0].login_password;

                    lbLoginPwd.Visible = false;
                }
                data.ForEach(item =>
                {
                    loginName.Items.Add(item.login_name);
                });
            }
        }
        /// <summary>
        /// 切换账号时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbLoginName.Visible = false;

            ComboBox cb = sender as ComboBox;

            var data = LogicHotTao.Instance(0).GetLoginName(cb.Text);

            if (data != null)
            {
                if (!string.IsNullOrEmpty(data.login_password) && data.is_save_pwd == 1)
                {
                    loginPwd.Text = data.login_password;
                    lbLoginPwd.Visible = false;
                }
            }

        }


        /// <summary>
        /// 是否记住密码
        /// </summary>
        private bool IsRememberPassword { get; set; }
        private bool _isLogining = false;
        public bool loginSuccess { get; set; }

        public bool isLogining
        {
            get
            {
                return _isLogining;
            }

            set
            {
                _isLogining = value;
            }
        }
        private bool SavePwd { get; set; }
        private bool AutoLogin { get; set; }
        private string lgpwd = string.Empty;
        private string lgname = string.Empty;
        public void LoginHandle()
        {
            try
            {
                if (isLogining)
                    return;
                if (string.IsNullOrEmpty(loginName.Text))
                {
                    lbTipMsg.Text = "请输入登录账户!";
                    return;
                }
                if (string.IsNullOrEmpty(loginPwd.Text))
                {
                    lbTipMsg.Text = "请输入登录密码!";
                    loginPwd.Focus();
                    return;
                }
                SavePwd = this.ckbSavePwd.Checked;
                AutoLogin = false;
                string pwd = string.Empty;
                pwd = EncryptHelper.MD5(loginPwd.Text);
                lgname = loginName.Text;
                lgpwd = loginPwd.Text;
                loginSuccess = false;
                isLogining = true;
                ((Action)(delegate ()
                {                    
                    var data = LogicUser.Instance.login(lgname, pwd, (err) =>
                    {
                        if (err != null && err.resultCode != 200)
                        {
                            this.BeginInvoke((Action)(delegate ()  //等待结束
                            {
                                lbTipMsg.Text = err.resultMsg;
                            }));
                            isLogining = false;
                            loginSuccess = true;
                        }
                    }, true);
                    if (data != null)
                    {
                        if (data.activate == 1)
                        {
                            loginSuccess = true;
                            isLogining = false;
                            this.BeginInvoke((Action)(delegate ()  //等待结束
                            {
                                lbTipMsg.Text = "登录成功，请稍后...";
                            }));
                            if (data != null)
                            {
                                MyUserInfo my = new MyUserInfo();
                                my.SetUserData(data);
                                LogicHotTao.Instance(0).AddLoginName(new SQLiteEntitysModel.LoginNameModel()
                                {
                                    userid = data.userid,
                                    login_name = data.loginName,
                                    login_password = lgpwd,
                                    is_save_pwd = SavePwd ? 1 : 0
                                });
                            }
                            this.BeginInvoke((Action)(delegate ()  //等待结束
                            {

                                this.Hide();
                                MainForm main = new MainForm(this);
                                main.StartPosition = FormStartPosition.CenterScreen;
                                main.Show();
                            }));
                        }
                        else
                        {
                            this.BeginInvoke((Action)(delegate ()  //等待结束
                            {
                                lbTipMsg.Text = "该账号已禁用，请联系管理员!";
                            }));
                            isLogining = false;
                            loginSuccess = true;
                        }
                    }
                })).BeginInvoke(null, null);

                ((Action)(delegate ()
                {
                    int c = 1;
                    while (!loginSuccess)
                    {
                        this.BeginInvoke((Action)(delegate ()  //等待结束
                        {
                            string t = "登录中，请稍后";
                            if (c == 1)
                                t = "登录中，请稍后.";
                            else if (c == 2)
                                t = "登录中，请稍后..";
                            else if (c == 3)
                            {
                                t = "登录中，请稍后...";
                                c = 0;
                            }
                            if (!loginSuccess)
                                lbTipMsg.Text = t;
                        }));
                        c++;
                        System.Threading.Thread.Sleep(1000);
                    }

                })).BeginInvoke(null, null);

            }
            catch (Exception ex)
            {
                loginSuccess = true;
                log.Error(ex);
                this.BeginInvoke((Action)(delegate ()  //等待结束
                {
                    lbTipMsg.Text = "连接服务器失败!";
                    isLogining = false;
                }));
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginHandle();
        }


        public new void Close()
        {
            //关闭数据库连接            
            Application.ExitThread();
            Process.GetCurrentProcess().Kill();
        }



        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <returns>BuildDataBase.</returns>
        public void InitDataBase()
        {
            try
            {
                //初始化用户本地数据库
                string sourceFileName = System.Environment.CurrentDirectory + "\\data\\fdgs.db";
                if (!System.IO.File.Exists(sourceFileName))
                {
                    MessageBox.Show("系统初始化失败", "错误");
                    this.Close();
                }
                string dbpath = System.Environment.CurrentDirectory + "\\data\\" + MyUserInfo.currentUserId;
                if (!System.IO.Directory.Exists(dbpath))
                    System.IO.Directory.CreateDirectory(dbpath);

                dbpath += "\\fdgs.db";

                if (!System.IO.File.Exists(dbpath))
                {
                    System.IO.File.Copy(sourceFileName, dbpath);
                }

                //初始化商品同步数据库
                sourceFileName = System.Environment.CurrentDirectory + "\\data\\syncgoods.db";
                if (!System.IO.File.Exists(sourceFileName))
                {
                    MessageBox.Show("系统初始化失败", "错误");
                    this.Close();
                }
                dbpath = System.Environment.CurrentDirectory + "\\data\\" + MyUserInfo.currentUserId;
                if (!System.IO.Directory.Exists(dbpath))
                    System.IO.Directory.CreateDirectory(dbpath);

                dbpath += "\\syncgoods.db";
                if (!System.IO.File.Exists(dbpath))
                {
                    System.IO.File.Copy(sourceFileName, dbpath);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        /// <summary>
        /// 显示注册
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void lkbRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HotTaoRegistAccount.RegisterForm reg = new HotTaoRegistAccount.RegisterForm();
            reg.StartPosition = FormStartPosition.CenterScreen;
            reg.Show(this);

           // hotPanelRegister.Visible = true;
        }
        /// <summary>
        /// 返回登录
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void lkbLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            hotPanelRegister.Visible = false;
        }

        private void lbRegisterMobile_Click(object sender, EventArgs e)
        {
            txtRegisterMobile.Focus();
        }

        private void lbRegisterPwd_Click(object sender, EventArgs e)
        {
            txtRegisterPwd.Focus();
        }

        private void lbVerifyCode_Click(object sender, EventArgs e)
        {
            txtRegisterVerifyCode.Focus();
        }

        private void txtRegisterMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRegisterMobile.Text))
                lbRegisterMobile.Visible = false;
            else
                lbRegisterMobile.Visible = true;
        }

        private void txtRegisterPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRegisterPwd.Text))
                lbRegisterPwd.Visible = false;
            else
                lbRegisterPwd.Visible = true;
        }

        private void txtRegisterVerifyCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRegisterVerifyCode.Text))
                lbVerifyCode.Visible = false;
            else
                lbVerifyCode.Visible = true;
        }

        private bool isSendVerifyCode { get; set; }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnGetVerifyCode_Click(object sender, EventArgs e)
        {
            if (isSendVerifyCode) return;
            if (string.IsNullOrEmpty(txtRegisterMobile.Text.Trim()) || txtRegisterMobile.Text.Trim().Length != 11)
            {
                ShowAlert("请输入手机号码");
                return;
            }

            //获取
            if (LogicUser.Instance.sendCodeForRegister(txtRegisterMobile.Text.Trim()))
            {
                isSendVerifyCode = true;
                timeOut();
            }

        }


        private void timeOut()
        {
            btnGetVerifyCode.BackColor = Color.Silver;
            new Thread(() =>
            {
                int s = 60;
                ShowTime(s);
                while (isSendVerifyCode)
                {
                    Thread.Sleep(1000);
                    --s;
                    if (s <= 0)
                        isSendVerifyCode = false;
                    ShowTime(s);
                }
            })
            { IsBackground = true }.Start();
        }


        public void ShowTime(int timeout)
        {
            if (this.btnGetVerifyCode.InvokeRequired)
            {
                this.btnGetVerifyCode.Invoke(new Action<int>(ShowTime), new object[] { timeout });
            }
            else
            {
                if (timeout > 0)
                    btnGetVerifyCode.Text = timeout.ToString() + "秒后再试";
                else
                {
                    btnGetVerifyCode.Text = "获取验证码";
                    btnGetVerifyCode.BackColor = Color.FromArgb(18, 216, 106);
                }
            }
        }


        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRegisterMobile.Text.Trim()) || txtRegisterMobile.Text.Trim().Length != 11)
            {
                ShowAlert("请输入手机号码");
                return;
            }

            if (string.IsNullOrEmpty(txtRegisterPwd.Text.Trim()))
            {
                ShowAlert("请输入登录密码");
                return;
            }
            if (string.IsNullOrEmpty(txtRegisterVerifyCode.Text.Trim()))
            {
                ShowAlert("请输入验证码");
                return;
            }
            
            var userData = LogicUser.Instance.Register(txtRegisterMobile.Text.Trim(), EncryptHelper.MD5(txtRegisterPwd.Text.Trim()), txtRegisterVerifyCode.Text.Trim(), (err) =>
            {

            });
        }

        /// <summary>
        /// 数字
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void TextBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;//消除不合适字符  
            }
        }

        /// <summary>
        /// 显示弹出框
        /// </summary>
        /// <param name="text">The text.</param>
        public void ShowAlert(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(ShowAlert), new object[] { text });
            }
            else
            {
                MessageAlert alert = new MessageAlert(text);
                alert.ShowDialog(this);
            }
        }

    }
}
