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
        /// 自动回复对象
        /// </summary>
        /// <value>The autoreply form.</value>
        private UserControl hotAutoForm { get; set; }



        /// <summary>
        /// 窗口标题
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        public int CurrentRowIndex { get; set; }

        public AddWeChat(Main main, TaskControl control)
        {
            InitializeComponent();
            hotForm = main;
            hotTask = control;
            hotAutoForm = null;
        }

        public AddWeChat(Main main, UserControl control)
        {
            InitializeComponent();
            hotForm = main;
            hotAutoForm = control;
            hotTask = null;
        }

        public int editId { get; set; }

        public string weChatTitle { get; set; }
        public string weChatPid { get; set; }


        private void AddWeChat_Load(object sender, EventArgs e)
        {
            txtWeChatTitle.Text = weChatTitle;
            txtPid.Text = weChatPid;
            if (!string.IsNullOrEmpty(Title))
            {
                lbTitle.Text = Title;
                this.Text = Title;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtWeChatTitle.Text))
            {
                txtWeChatTitle.Focus();
                return;
            }
            MessageAlert alert = new MessageAlert();
            Loading ld = new Loading();
            SetAutoReplyControl replyControl = hotAutoForm as SetAutoReplyControl;
            SetAutoRemoveChatroom autoRemoveControl = hotAutoForm as SetAutoRemoveChatroom;
            SendMessage sendControl = hotAutoForm as SendMessage;
            string groupTitle = txtWeChatTitle.Text;
            string groupPid = txtPid.Text;
            ((Action)(delegate ()
            {
                int flag = 0;
                UserWechatListModel data = new UserWechatListModel();
                if (hotTask != null)
                {
                    //data = LogicUser.Instance.UpdateUserWeChatTitle(MyUserInfo.LoginToken, editId, txtWeChatTitle.Text);

                    if (LogicHotTao.Instance.UpdateUserWeChatTitle(MyUserInfo.currentUserId, editId, groupTitle, groupPid))
                    {
                        data.pid = groupPid;
                        data.wechattitle = groupTitle;
                        flag = 1;
                    }
                }
                else if (replyControl != null || sendControl != null)
                    flag = LogicUser.Instance.UpdateUserWeChatTitle(MyUserInfo.LoginToken, txtWeChatTitle.Text, 0);
                else if (autoRemoveControl != null)
                    flag = LogicUser.Instance.UpdateUserWeChatTitle(MyUserInfo.LoginToken, txtWeChatTitle.Text, 1);


                if (flag > 0)
                {
                    alert.Message = "保存成功";
                }
                else
                    alert.Message = "保存失败，请检查是否重复";

                ld.CloseForm();
                this.BeginInvoke((Action)(delegate ()
                {
                    alert.ShowDialog(this);
                    if (flag > 0)
                    {
                        if (hotTask != null)
                        {
                            //hotTask.SetPidView(data, editId > 0 ? CurrentRowIndex : -1);
                            hotTask.loadUserPidGridView();
                        }
                        else
                        {
                            if (replyControl != null)
                            {
                                replyControl.LoadDgvChatRoom();
                                if (hotForm.wxlogin != null)
                                    hotForm.wxlogin.LoadAutoHandleData();
                            }
                            else if (autoRemoveControl != null)
                            {
                                autoRemoveControl.LoadDgvChatRoom();
                            }
                            else if (sendControl != null)
                            {
                                sendControl.LoadDgvChatRoom();
                                if (hotForm.wxlogin != null)
                                    hotForm.wxlogin.LoadAutoHandleData();
                            }
                        }
                        this.Close();
                    }
                }));

            })).BeginInvoke(null, null);
            ld.ShowDialog(hotForm);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
