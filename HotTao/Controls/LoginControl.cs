using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using HotTaoCore;
using HotTaoCore.Models;
using HotTaoCore.Logic;
using HotTao.Controls.Login;

namespace HotTao.Controls
{
    public partial class LoginControl : UserControl
    {
        private Main hotForm { get; set; }



        public LoginControl(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }

        private void LoginControl_Load(object sender, EventArgs e)
        {
            openControl(new LoginButtonPage(hotForm, this));
        }

        /// <summary>
        /// 打开指定用户控件
        /// </summary>
        /// <param name="uc">The uc.</param>
        public void openControl(UserControl uc)
        {
            foreach (UserControl uu in panelLogin.Controls)
            {
                if (uu.GetType() == uc.GetType())
                {
                    return;
                }
            }
            uc.Dock = DockStyle.Fill;                                
            DisPanel();
            panelLogin.Controls.Add(uc);
        }

        private void DisPanel()
        {
            foreach (UserControl uc in panelLogin.Controls)
            {
                uc.Dispose();
            }
        }



    }
}
