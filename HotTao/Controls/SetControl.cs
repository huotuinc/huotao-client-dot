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

        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (UserControl uc in splitContainer1.Panel1.Controls)
            {
                MethodInfo mi = uc.GetType().GetMethod("Save", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
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

        /// <summary>
        /// 切换面板
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SwitchControl_Click(object sender, EventArgs e)
        {
            Control c = sender as Control;
            int tag = Convert.ToInt32(c.Tag);
            SetSaveButtonVisible(true);
            switch (tag)
            {
                case 1: //软件账户设置
                    openControl(new SetAccountControl(hotForm));
                    break;
                case 2://淘宝账号设置
                    openControl(new SetAccountControl(hotForm));
                    break;
                case 3://文案设置
                    openControl(new SetSendTemplateControl(hotForm));
                    break;
                case 4://群发设置
                    openControl(new SetSendConfig(hotForm));
                    break;
                case 5://自动回复设置
                    openControl(new SetAutoReplyControl(hotForm));
                    SetSaveButtonVisible(false);
                    break;
                case 6://自动踢人设置
                    openControl(new SetAutoRemoveChatroom(hotForm));
                    SetSaveButtonVisible(false);
                    break;
                default:
                    break;
            }
            SetSelectedState(sender);
        }


        public void SetSaveButtonVisible(bool Visible)
        {
            btnSave.Visible = Visible;
        }

        /// <summary>
        /// 设置选中菜单背景颜色和字体样式
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void SetSelectedState(object sender)
        {
            //默认颜色
            Color fore = Color.FromArgb(129, 129, 129);

            foreach (Control item in hotLeftPanel.Controls)
            {
                int tag = 0;
                int.TryParse(item.Tag.ToString(), out tag);
                if (tag > 0)
                {
                    item.BackColor = Color.White;
                    item.Controls[0].ForeColor = fore;
                }
            }

            Panel p = sender as Panel;
            if (p != null)
            {
                p.BackColor = ConstConfig.SetLeftSelectedBackColor;
                p.Controls[0].ForeColor = Color.White;
            }
            else
            {
                Label lp = sender as Label;
                lp.Parent.BackColor = ConstConfig.SetLeftSelectedBackColor;
                lp.ForeColor = Color.White;
            }
        }

    }
}
