using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotTaoMonitoring
{
    public partial class MyInfoForm : Form
    {
        private MainForm mainForm { get; set; }
        public MyInfoForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        /// <summary>
        /// 微信昵称
        /// </summary>
        /// <value>The we chat title.</value>
        private string weChatTitle { get; set; }
        /// <summary>
        /// 微信头像
        /// </summary>
        /// <value>The we chat head img.</value>
        private Image weChatHeadImg { get; set; }

        /// <summary>
        /// 设置数据
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="image">The image.</param>
        public void SetData(string title, Image image)
        {
            weChatTitle = title;
            weChatHeadImg = image;
        }

        private void MyInfoForm_Load(object sender, EventArgs e)
        {
            lbKefu.Text = MyUserInfo.userData.loginName;
            lbWeChatTitle.Text = weChatTitle;
            picWeChatImage.Image = weChatHeadImg;
        }
        private void lbLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.myInfo = null;
            mainForm.SwitchLogin();
        }
        /// <summary>
        /// 切换微信
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lbSwitchWeChat_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.myInfo = null;
            mainForm.SwitchWeChatLogin();
        }
    }
}
