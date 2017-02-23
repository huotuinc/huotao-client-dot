﻿using System;
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

        #region 移动窗口
        /*
         * 首先将窗体的边框样式修改为None，让窗体没有标题栏
         * 实现这个效果使用了三个事件：鼠标按下、鼠标弹起、鼠标移动
         * 鼠标按下时更改变量isMouseDown标记窗体可以随鼠标的移动而移动
         * 鼠标移动时根据鼠标的移动量更改窗体的location属性，实现窗体移动
         * 鼠标弹起时更改变量isMouseDown标记窗体不可以随鼠标的移动而移动
         */
        private bool isMouseDown = false;
        private Point FormLocation;     //form的location
        private Point mouseOffset;      //鼠标的按下位置
        private void WinForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLocation = this.Location;
                mouseOffset = Control.MousePosition;
            }
        }

        private void WinForm_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
        private void WinForm_MouseMove(object sender, MouseEventArgs e)
        {
            int _x = 0;
            int _y = 0;
            if (isMouseDown)
            {
                Point pt = Control.MousePosition;
                _x = mouseOffset.X - pt.X;
                _y = mouseOffset.Y - pt.Y;

                this.Location = new Point(FormLocation.X - _x, FormLocation.Y - _y);
            }

        }
        #endregion


        private Main hotForm { get; set; }
        private TaskControl hotTask { get; set; }
        /// <summary>
        /// 窗口标题
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

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
            if (!string.IsNullOrEmpty(Title))
                lbTitle.Text = Title;
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
