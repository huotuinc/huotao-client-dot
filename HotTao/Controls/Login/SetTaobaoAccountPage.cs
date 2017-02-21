using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HotTao.Controls.Login
{
    public partial class SetTaobaoAccountPage : UserControl
    {
        private Main hotForm { get; set; }
        private LoginControl loginForm { get; set; }
        public SetTaobaoAccountPage(Main mainWin, LoginControl loginWin)
        {
            InitializeComponent();
            hotForm = mainWin;
            loginForm = loginWin;
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
            if (!string.IsNullOrEmpty(loginPwd.Text))
                lbLoginPwd.Visible = false;
            else
                lbLoginPwd.Visible = true;
        }

        private void lbSkipStep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            hotForm.openControl(new TaskControl(hotForm));
        }
    }
}
