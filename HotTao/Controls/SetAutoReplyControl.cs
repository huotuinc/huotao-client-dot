using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HotTaoCore.Logic;
using HotTaoCore.Models;
using Newtonsoft.Json;

namespace HotTao.Controls
{
    public partial class SetAutoReplyControl : UserControl
    {
        private Main hotForm { get; set; }


        /// <summary>
        /// 我的配置
        /// </summary>
        /// <value>My configuration.</value>
        private ConfigModel myConfig { get; set; }


        public SetAutoReplyControl(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }

        private void SetAutoReplyControl_Load(object sender, EventArgs e)
        {
            if (hotForm.currentUserId > 0)
            {
                LoadConfig();
            }
            else
                hotForm.openControl(new LoginControl(hotForm));
        }

        private void LoadConfig()
        {
            myConfig = LogicUser.Instance.GetConfigModel(hotForm.currentUserId);
            if (myConfig == null)
                myConfig = new ConfigModel();
            else
            {
                ckbAutoReplay.Checked = myConfig.enable_autoreply == 1;

                ConfigAutoReplyModel cfgAuto = string.IsNullOrEmpty(myConfig.auto_reply_config) ? null : JsonConvert.DeserializeObject<ConfigAutoReplyModel>(myConfig.auto_reply_config);
                if (cfgAuto != null)
                {
                    txtKeyword.Text = cfgAuto.keyworld;
                    txtResponeContent.Text = cfgAuto.replycontent;
                }

            }
        }


        public void Save()
        {
            ConfigAutoReplyModel cfgAuto = string.IsNullOrEmpty(myConfig.auto_reply_config) ? new ConfigAutoReplyModel() : JsonConvert.DeserializeObject<ConfigAutoReplyModel>(myConfig.auto_reply_config);
            cfgAuto = cfgAuto == null ? new ConfigAutoReplyModel() : cfgAuto;

            cfgAuto.keyworld = txtKeyword.Text;
            cfgAuto.replycontent = txtResponeContent.Text;

            //启用自动回复
            myConfig.enable_autoreply = ckbAutoReplay.Checked ? 1 : 0;
            myConfig.auto_reply_config = JsonConvert.SerializeObject(cfgAuto);


            LogicUser.Instance.AddUserConfigModel(myConfig);

            MessageAlert alert = new MessageAlert();
            alert.Message = "保存成功";
            alert.ShowDialog(this);

        }
    }
}
