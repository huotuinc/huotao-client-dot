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
            string tempText = LogicUser.Instance.GetUserSendTemplate(hotForm.currentUserId);
            if (!string.IsNullOrEmpty(tempText))
                txtTempText.Text = tempText;
        }
        private void SetTag_Click(object sender, EventArgs e)
        {
            Label tag = sender as Label;
            string strInsertText = tag.Text;
            int start = txtTempText.SelectionStart;
            txtTempText.Text = txtTempText.Text.Insert(start, strInsertText);
            txtTempText.SelectionStart = start;
            txtTempText.SelectionLength = strInsertText.Length;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtTempText.Text = txtTempDefaultText.Text;
        }



        public void Save()
        {
            if (LogicUser.Instance.AddUserSendTemplate(hotForm.currentUserId, txtTempText.Text))
            {
                MessageBox.Show("保存成功", "提示");
            }
            else
                MessageBox.Show("保存失败", "提示");
        }
    }
}
