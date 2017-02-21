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

namespace HotTao.Controls
{
    /// <summary>
    /// 软件设置
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class SetControl : UserControl
    {
        private Main hotForm { get; set; }

        private SetRightPanelControl rightControl;

        public SetControl(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }

        private void SetControl_Load(object sender, EventArgs e)
        {
            rightControl = new SetRightPanelControl(hotForm);
            rightControl.Dock = DockStyle.Fill;            
            this.splitContainer1.Panel1.Controls.Add(rightControl);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            rightControl.Save();
        }
    }
}
