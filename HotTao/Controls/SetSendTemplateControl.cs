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
                ((Action)(delegate ()
                {
                    string tempText = LogicUser.Instance.GetUserSendTemplate(MyUserInfo.currentUserId);
                    MyUserInfo.sendtemplate = tempText;
                    this.BeginInvoke((Action)(delegate ()
                    {
                        if (!string.IsNullOrEmpty(tempText))
                            txtTempText.Text = tempText;
                        else
                            MyUserInfo.sendtemplate = txtTempDefaultText.Text;
                    }));

                })).BeginInvoke(null, null);

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
            ((Action)(delegate ()
            {
                if (LogicUser.Instance.AddUserSendTemplate(MyUserInfo.currentUserId, txtTempText.Text))
                {
                    alert.Message = "保存成功";                    
                }
                else
                    alert.Message = "保存失败";
                ld.CloseForm();                
                this.BeginInvoke((Action)(delegate ()
                {
                    MyUserInfo.sendtemplate = txtTempText.Text;
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
            txtTempText.Text = txtTempDefaultText.Text;
        }
    }
}
