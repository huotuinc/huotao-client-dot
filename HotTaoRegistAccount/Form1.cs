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
    public partial class Form1 : Form
    {
        public Form1()
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
        private void button1_Click(object sender, EventArgs e)
        {
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
            string lgname = loginName.Text;
            string pwd = MD5(loginPwd.Text);
            string verifyCode = "";
            ((Action)(delegate ()
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
            })).BeginInvoke(null, null);
        }
    }
}
