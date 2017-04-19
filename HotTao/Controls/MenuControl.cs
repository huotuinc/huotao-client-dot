using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotTao.Controls
{
    public partial class MenuControl : Form
    {
        private Main hotForm { get; set; }
        public MenuControl(Main form)
        {
            InitializeComponent();
            hotForm = form;
        }

        private void MenuControl_Load(object sender, EventArgs e)
        {
            WinApi.SetWinFormTaskbarSystemMenu(this);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                //const int WS_EX_APPWINDOW = 0x40000;
                const int WS_EX_TOOLWINDOW = 0x80;
                CreateParams cp = base.CreateParams;
                //cp.ExStyle &= (~WS_EX_APPWINDOW);    // 不显示在TaskBar
                cp.ExStyle |= WS_EX_TOOLWINDOW;      // 不显示在Alt-Tab
                return cp;
            }
        }
        /// <summary>
        /// 关于我们
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lbAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog(hotForm);
        }

        /// <summary>
        /// 退出按钮
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lbLogout_Click(object sender, EventArgs e)
        {
            hotForm.AlertConfirm("是否退出当前登录账户？","注销",()=> {
                MyUserInfo my = new MyUserInfo();
                my.SetUserData(null);
                if (hotForm.wxlogin != null)
                {
                    hotForm.wxlogin.isStartTask = false;
                    hotForm.wxlogin.isCloseWinForm = true;
                    hotForm.wxlogin.Close();
                    hotForm.wxlogin = null;
                }
                if (hotForm.winTask != null)
                {
                    hotForm.winTask.isStartTask = false;
                    hotForm.winTask.Close();
                    hotForm.winTask = null;
                }
                this.Hide();
                hotForm.openControl(new LoginControl(hotForm));
            });
            
        }
    }
}
