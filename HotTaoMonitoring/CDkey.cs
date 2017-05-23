
using HotTaoCore.Logic;
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
    public partial class CDkey : Form
    {

        private MainForm hotForm { get; set; }

        private bool isActive { get; set; }

        public CDkey(MainForm form)
        {
            InitializeComponent();
            hotForm = form;
            isActive = false;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
            if (isActive)
                hotForm.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                AlertTip("请输入激活码");
                return;
            }
            //获取
            if (LogicUser.Instance.activeAccount(MyUserInfo.LoginToken, txtCode.Text, 1))
            {
                isActive = true;
                AlertTip("恭喜你！激活成功！请重新登录!");
                this.Close();
            }
            else
                AlertTip("无效激活码！");
        }



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
                alert.Show(this);
            }
        }

        private void CDkey_Load(object sender, EventArgs e)
        {
            if (MyUserInfo.userData != null)
                lbsoftwareText.Text = MyUserInfo.userData.softwareText;
        }
    }
}
