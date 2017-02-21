using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HotCoreUtils.Helper;
using HotTaoCore.Logic;
using HotTaoCore.Models;
using System.IO;
using HotTaoCore;
using System.Reflection;

namespace HotTao.Controls
{
    /// <summary>
    /// 软件设置
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class SetControl : UserControl
    {
        private Main hotForm { get; set; }
        
        public SetControl(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }

        private void SetControl_Load(object sender, EventArgs e)
        {           

            openControl(new SetAccountControl(hotForm));
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
         
        }

        /// <summary>
        /// 销毁Panel
        /// </summary>
        private void DisPanel()
        {
            foreach (UserControl uc in splitContainer1.Panel1.Controls)
            {
                uc.Dispose();
            }
        }


        /// <summary>
        /// 打开指定用户控件
        /// </summary>
        /// <param name="uc">The uc.</param>
        public void openControl(UserControl uc)
        {
            foreach (UserControl uu in splitContainer1.Panel1.Controls)
            {
                if (uu.GetType() == uc.GetType())
                {
                    return;
                }
            }
            uc.Dock = DockStyle.Fill;
            DisPanel();
            this.splitContainer1.Panel1.Controls.Add(uc);
        }


        private void panel_Click(object sender, EventArgs e)
        {   
            openControl(new SetSendTemplateControl(hotForm));
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            openControl(new SetSendConfig(hotForm));
        }
    }
}
