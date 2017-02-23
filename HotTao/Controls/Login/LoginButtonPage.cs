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
    public partial class LoginButtonPage : UserControl
    {
        private Main hotForm { get; set; }
        private LoginControl loginForm { get; set; }
        public LoginButtonPage(Main mainWin, LoginControl loginWin)
        {
            InitializeComponent();
            hotForm = mainWin;
            loginForm = loginWin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginForm.openControl(new LoginPage(hotForm, loginForm));
        }
    }
}
