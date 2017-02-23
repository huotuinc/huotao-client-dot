using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using HotTaoCore;
using HotCoreUtils.Helper;
using HotTaoCore.Models;

namespace HotTao.Controls
{
    public partial class GoodsControl : UserControl
    {

        private Main hotForm { get; set; }

        public GoodsControl(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;

        }

        private void GoodsControl_Load(object sender, EventArgs e)
        {

            if (hotForm.currentUserId > 0)
            {
            }
            else
                hotForm.openControl(new LoginControl(hotForm));

        }


        /// <summary>
        /// 
        /// </summary>
        public void SubmitGoodsSelected()
        {
            //网页调该方法
            //window.external.SubmitGoodsSelected()
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ((Action)(delegate ()
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data["username"] = "guomw4";
                data["password"] = EncryptHelper.MD5_8("123456");
                //var content = BaseRequestService.Post<UserModel>("/huotao/register", data);
            })).BeginInvoke(null, null);


            hotForm.SetWeChatTabSelected();
            hotForm.openControl(new TaskControl(hotForm));
        }
    }
}
