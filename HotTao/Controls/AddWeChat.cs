using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HotTaoCore.Logic;

namespace HotTao.Controls
{
    public partial class AddWeChat : Form
    {
        private Main hotForm { get; set; }
        private TaskControl hotTask { get; set; }
        public AddWeChat(Main main, TaskControl task)
        {
            InitializeComponent();
            hotForm = main;
            hotTask = task;
        }


        public int editId { get; set; }

        public string weChatTitle { get; set; }


        private void AddWeChat_Load(object sender, EventArgs e)
        {
            txtWeChatTitle.Text = weChatTitle;
        }

                
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtWeChatTitle.Text))
            {
                txtWeChatTitle.Focus();
                return;
            }
            MessageAlert alert = new MessageAlert();
            int flag = editId > 0 ? LogicUser.Instance.UpdateUserWeChatTitle(hotForm.currentUserId, editId, txtWeChatTitle.Text) : LogicUser.Instance.AddUserWeChat(new HotTaoCore.Models.UserWechatListModel()
            {
                wechattitle = txtWeChatTitle.Text,
                userid = hotForm.currentUserId
            });
            if (flag > 0)
            {
                alert.Message = "保存成功";
            }
            else
                alert.Message = "保存失败，请检查是否重复";

            hotTask.loadUserPidGridView();
            alert.ShowDialog(this);
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
