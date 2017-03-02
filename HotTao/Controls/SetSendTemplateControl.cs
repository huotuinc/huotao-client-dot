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
    public partial class SetSendTemplateControl : UserControl
    {
        private Main hotForm { get; set; }
        public SetSendTemplateControl(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }
        private void SetSendTemplateControl_Load(object sender, EventArgs e)
        {
            if (MyUserInfo.currentUserId > 0)
            {

                if (string.IsNullOrEmpty(MyUserInfo.sendtemplate))
                    MyUserInfo.sendtemplate = MyUserInfo.defaultSendTempateText;
                else
                {
                    txtTempText.Text = MyUserInfo.sendtemplate;
                }
            }
            else
                hotForm.openControl(new LoginControl(hotForm));

        }


        /// <summary>
        /// 将变量标签插入指定位置
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SetTag_Click(object sender, EventArgs e)
        {
            Label tag = sender as Label;
            string strInsertText = tag.Text;
            int start = txtTempText.SelectionStart;
            txtTempText.Text = txtTempText.Text.Insert(start, strInsertText);
            txtTempText.SelectionStart = start;
            txtTempText.SelectionLength = strInsertText.Length;
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        public void Save()
        {
            MessageAlert alert = new MessageAlert();
            Loading ld = new Loading();
            string tempText = txtTempText.Text;
            ((Action)(delegate ()
            {
                if (LogicUser.Instance.AddUserSendTemplate(MyUserInfo.LoginToken, tempText))
                {
                    alert.Message = "保存成功";
                }
                else
                    alert.Message = "保存失败";
                ld.CloseForm();
                this.BeginInvoke((Action)(delegate ()
                {
                    MyUserInfo.sendtemplate = tempText;
                    alert.ShowDialog(this);
                }));
            })).BeginInvoke(null, null);
            ld.ShowDialog(this);
        }
        /// <summary>
        /// 恢复默认模板
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDefaultTemplate_Click(object sender, EventArgs e)
        {
            txtTempText.Text = MyUserInfo.defaultSendTempateText;
        }
    }
}
