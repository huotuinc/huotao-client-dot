﻿using System;
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
        /// 自动回复群id
        /// </summary>
        /// <value>The wechatid.</value>
        private int wechatid { get; set; }


        public SetAutoReplyControl(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }

        private void SetAutoReplyControl_Load(object sender, EventArgs e)
        {
            if (MyUserInfo.currentUserId > 0)
            {

                LoadConfig();
                LoadDgvChatRoom();
                LoadDgvKeyword();
            }
            else
                hotForm.openControl(new LoginControl(hotForm));

            dgvChatRoom.MouseWheel += DgvData_MouseWheel;
            dgvKeyword.MouseWheel += DgvData_MouseWheel;

        }

        /// <summary>
        /// 加载自动回复的群
        /// </summary>
        public void LoadDgvChatRoom()
        {
            //是否自动添加属性字段
            this.dgvChatRoom.AutoGenerateColumns = false;
            this.dgvChatRoom.Rows.Clear();
            ((Action)(delegate ()
            {
                var data = LogicUser.Instance.GetUserReplyWeChatList(MyUserInfo.LoginToken);
                if (data != null)
                {
                    this.BeginInvoke((Action)(delegate ()  //等待结束
                    {
                        SetChatRoomView(data);
                        if (this.dgvChatRoom.Rows.Count > 0)
                        {
                            dgvChatRoom.Rows[0].Selected = false;
                        }
                    }));
                }
            })).BeginInvoke(null, null);
        }

        /// <summary>
        /// 加载数据列表
        /// </summary>
        /// <param name="data">The data.</param>
        private void SetChatRoomView(List<WxAutoReplyModel> data)
        {
            int i = dgvChatRoom.Rows.Count;
            for (int j = 0; j < data.Count(); j++)
            {
                dgvChatRoom.Rows.Add();
                ++i;
                dgvChatRoom.Rows[i - 1].Cells["id"].Value = data[j].id.ToString();
                dgvChatRoom.Rows[i - 1].Cells["wechattitle"].Value = data[j].wechattitle.ToString();

                if (i % 2 == 0)
                    dgvChatRoom.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                else
                    dgvChatRoom.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;

                dgvChatRoom.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                dgvChatRoom.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;
            }

        }


        /// <summary>
        /// 加载关键字
        /// </summary>
        public void LoadDgvKeyword()
        {
            //是否自动添加属性字段
            this.dgvKeyword.AutoGenerateColumns = false;
            this.dgvKeyword.Rows.Clear();
            ((Action)(delegate ()
            {
                var data = LogicUser.Instance.GetUserReplyKeywordList(MyUserInfo.LoginToken);
                if (data != null)
                {
                    this.BeginInvoke((Action)(delegate ()  //等待结束
                    {
                        SetKeywordView(data);
                        if (this.dgvKeyword.Rows.Count > 0)
                        {
                            dgvKeyword.Rows[0].Selected = false;
                        }
                    }));
                }
            })).BeginInvoke(null, null);
        }


        private void SetKeywordView(List<WxAutoReplyKeywordModel> data)
        {
            int i = dgvKeyword.Rows.Count;
            for (int j = 0; j < data.Count(); j++)
            {
                dgvKeyword.Rows.Add();
                ++i;
                dgvKeyword.Rows[i - 1].Cells["keywordid"].Value = data[j].id.ToString();
                dgvKeyword.Rows[i - 1].Cells["replyKeyword"].Value = data[j].replyKeyword.ToString();
                dgvKeyword.Rows[i - 1].Cells["replyType"].Value = data[j].replyType == 0 ? "自定义文字" : "自定义商品";
                if (data[j].replyType == 0)
                    dgvKeyword.Rows[i - 1].Cells["replyContent"].Value = data[j].replyContent.ToString();
                else
                    dgvKeyword.Rows[i - 1].Cells["replyContent"].Value = "回复商品";


                if (i % 2 == 0)
                    dgvKeyword.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                else
                    dgvKeyword.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;

                dgvKeyword.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                dgvKeyword.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;
            }

        }




        private void LoadConfig()
        {
            if (hotForm.myConfig == null)
                hotForm.myConfig = new ConfigModel();
            ckbAutoReplay.Checked = hotForm.myConfig.enable_autoreply == 1;
        }


        public void Save()
        {
        }

        /// <summary>
        /// 鼠标滚动事件
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void DgvData_MouseWheel(object sender, MouseEventArgs e)
        {
            DataGridView dataGridView1 = sender as DataGridView;
            try
            {
                if (dataGridView1.CurrentCell != null)
                {
                    DataGridViewCell dvc = dataGridView1.CurrentCell;
                    int ri = dvc.RowIndex;
                    int ci = dvc.ColumnIndex;
                    int c = 0;
                    if (e.Delta > 0)//向上
                    {
                        if (ri - 3 > 0)
                            c = 3;
                        else if (ri > 0)
                            c = 1;
                        if (c > 0)
                        {
                            dvc = dataGridView1.Rows[ri - c].Cells[ci];
                            dataGridView1.CurrentCell = dvc;
                        }
                    }
                    else
                    {
                        if (ri < dataGridView1.Rows.Count - 3)
                            c = 3;
                        else if (ri < dataGridView1.Rows.Count - 1)
                            c = 1;
                        if (c > 0)
                        {
                            dvc = dataGridView1.Rows[ri + c].Cells[ci];
                            dataGridView1.CurrentCell = dvc;
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }
        private void btnAddChat_Click(object sender, EventArgs e)
        {
            AddWeChat wechat = new AddWeChat(hotForm, this);
            wechat.Title = "添加微信群";
            wechat.ShowDialog(this);
        }


        private void ckbAutoReplay_CheckedChanged(object sender, EventArgs e)
        {
            ((Action)(delegate ()
            {
                hotForm.myConfig.enable_autoreply = ckbAutoReplay.Checked ? 1 : 0;
                LogicUser.Instance.AddUserConfigModel(hotForm.myConfig);

            })).BeginInvoke(null, null);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddKeywordControl kwControl = new AddKeywordControl(hotForm,this);
            kwControl.Title = "添加关键字";
            kwControl.ShowDialog(this);
        }
    }
}
