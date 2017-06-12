using HotTaoCore.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotTaoRegistAccount
{
    public partial class RegisterForm : FormEx
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


        public RegisterForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(str);
            byte[] result = md5.ComputeHash(data);
            String ret = "";
            for (int i = 0; i < result.Length; i++)
                ret += result[i].ToString("x").PadLeft(2, '0');
            return ret;
        }
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
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (isLogining)
                return;
            if (string.IsNullOrEmpty(loginName.Text))
            {
                MessageBox.Show("请输入登录账户");
                return;
            }
            if (string.IsNullOrEmpty(loginPwd.Text))
            {
                MessageBox.Show("请输入登录密码");
                return;
            }
            if (string.IsNullOrEmpty(txtRegisterVerifyCode.Text))
            {
                MessageBox.Show("请输入验证码!");
                txtRegisterVerifyCode.Focus();
                return;
            }

            string lgname = loginName.Text;
            string pwd = MD5(loginPwd.Text);
            string verifyCode = txtRegisterVerifyCode.Text;
            isLogining = true;
            ((Action)(delegate ()
            {
                try
                {
                    var data = LogicUser.Instance.Register(lgname, pwd, verifyCode, (err) =>
                            {
                                if (err != null && err.resultCode != 200)
                                {
                                    this.BeginInvoke((Action)(delegate ()  //等待结束
                                    {
                                        MessageBox.Show(err.resultMsg);
                                    }));
                                }
                            });
                    if (data != null)
                    {
                        MessageBox.Show("注册成功");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("服务器开小差了，请稍后再试!");
                }
                isLogining = false;
            })).BeginInvoke(null, null);
        }
        private bool isSendVerifyCode { get; set; }
        private void btnGetVerifyCode_Click(object sender, EventArgs e)
        {
            if (isSendVerifyCode) return;
            if (string.IsNullOrEmpty(loginName.Text.Trim()) || loginName.Text.Trim().Length != 11)
            {
                MessageBox.Show("请输入手机号码");
                return;
            }

            string errorMsg = string.Empty;
            //获取
            if (LogicUser.Instance.sendCodeForRegister(loginName.Text.Trim(), out errorMsg))
            {
                isSendVerifyCode = true;
                timeOut();
            }
            else
            {
                MessageBox.Show(errorMsg);
            }
        }


        private void timeOut()
        {
            btnGetVerifyCode.BackColor = Color.Silver;
            new System.Threading.Thread(() =>
            {
                int s = 60;
                ShowTime(s);
                while (isSendVerifyCode)
                {
                    System.Threading.Thread.Sleep(1000);
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

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
