using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotTaoMonitoring.UserControls
{
    public partial class ShopingGuideControl : UserControl
    {
        private MainForm mainForm { get; set; }
        public ShopingGuideControl(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void ShopingGuideControl_Load(object sender, EventArgs e)
        {
            openControl(UserControlsOpts.autoShopingGuideConfig);
        }



        /// <summary>
        /// 打开指定用户控件
        /// </summary>
        /// <param name="uc">The uc.</param>
        public void openControl(UserControlsOpts opt)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<UserControlsOpts>(openControl), new object[] { opt });
            }
            else
            {
                UserControl control = null;
                if (mainForm.windowFormControls.ContainsKey(opt))
                    mainForm.windowFormControls.TryGetValue(opt, out control);
                if (control != null && !control.IsDisposed)
                {
                    PanelGuideContainer.Controls.Clear();
                    this.PanelGuideContainer.Controls.Add(control);
                }
                else
                    ShowControl(opt);
            }
        }

        /// <summary>
        /// 显示界面
        /// </summary>
        /// <param name="opt">The opt.</param>
        private void ShowControl(UserControlsOpts opt)
        {
            if (mainForm.windowFormControls == null)
                mainForm.windowFormControls = new Dictionary<UserControlsOpts, UserControl>();
            else
                mainForm.windowFormControls.Remove(opt);
            switch (opt)
            {
                case UserControlsOpts.autoShopingGuideConfig:
                    PanelGuideContainer.Controls.Clear();
                    var shopguide = new ShopingGuideGroupConfigControl(mainForm);
                    this.PanelGuideContainer.Controls.Add(shopguide);
                    mainForm.windowFormControls.Add(opt, shopguide);
                    break;
                default:
                    break;
            }
        }
    }
}
