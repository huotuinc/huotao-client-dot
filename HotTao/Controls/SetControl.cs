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

        private int cIndex = 0;
        private Main hotForm { get; set; }

        public SetControl(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }

        private void SetControl_Load(object sender, EventArgs e)
        {
            SetCurrentControlIndex(0);
            openControl(new SetAccountControl(hotForm));
        }


        /// <summary>
        /// 当前右边控件的索引
        /// 0 SetAccountControl
        /// 1 SetSendTemplateControl
        /// 2 SetSendConfig
        /// 3 SetAutoReplyControl
        /// </summary>
        private void SetCurrentControlIndex(int index)
        {
            cIndex = index;
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (UserControl uc in splitContainer1.Panel1.Controls)
            {
                MethodInfo mi = uc.GetType().GetMethod("Save",BindingFlags.Public);
                if (mi != null)
                {
                    //执行该方法并返回
                    mi.Invoke(uc, new object[] { });
                }
            }
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
            SetCurrentControlIndex(1);
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            openControl(new SetSendConfig(hotForm));
            SetCurrentControlIndex(2);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            openControl(new SetAutoReplyControl(hotForm));
            SetCurrentControlIndex(3);
        }
    }
}
