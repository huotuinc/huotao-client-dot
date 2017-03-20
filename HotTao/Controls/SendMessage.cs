using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotTaoCore.Models;
using HotTaoCore.Logic;
using System.Threading;

namespace HotTao.Controls
{
    public partial class SendMessage : UserControl
    {
        private Main hotForm { get; set; }
        public SendMessage(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }



        System.Windows.Forms.Timer checkSendTime = new System.Windows.Forms.Timer();

        private void SendMessage_Load(object sender, EventArgs e)
        {
            if (MyUserInfo.currentUserId > 0)
            {
                LoadDgvChatRoom();
                //检查发送状态
                //CheckSendStatus();
                txtSendMessage.Text = MyUserInfo.SendMessageText;
                checkSendTime.Interval = 1000;
                checkSendTime.Tick += CheckSendStatus;
                if (MyUserInfo.SendMessageStatus == 1)
                {
                    checkSendTime.Start();
                    SetSendStatuTip("正在发送中,请稍后...");
                }
                dgvChatRoom.MouseWheel += DgvData_MouseWheel;
            }
            else
                hotForm.openControl(new LoginControl(hotForm));
        }

        private void CheckSendStatus(object sender, EventArgs e)
        {
            if (MyUserInfo.SendMessageStatus != 0)
            {
                if (MyUserInfo.SendMessageStatus == 1)
                    SetSendStatuTip("正在发送中,请稍后...");

                if (MyUserInfo.SendMessageStatus == 2)
                    SetSendStatuTip("发送完成");
            }
            else
                SetSendStatuTip("");
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
                var data = LogicUser.Instance.GetUserReplyWeChatList(MyUserInfo.LoginToken, 0);
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
                dgvChatRoom.Rows[i - 1].Cells["groupid"].Value = data[j].id.ToString();
                dgvChatRoom.Rows[i - 1].Cells["wechattitle"].Value = data[j].wechattitle.ToString();

                if (i % 2 == 0)
                {
                    dgvChatRoom.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                    dgvChatRoom.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewEvenRowBackColor;
                }
                else
                {
                    dgvChatRoom.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;
                    dgvChatRoom.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewOddRowBackColor;
                }


                dgvChatRoom.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                dgvChatRoom.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;
            }

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

        public void Save()
        {

        }


        /// <summary>
        /// 删除回复微信群
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void dgvChatRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = this.dgvChatRoom.CurrentRow.Cells["deleteWechat"];
            if (cell != null && cell.ColumnIndex == e.ColumnIndex)
            {
                DataGridViewCellCollection cells = this.dgvChatRoom.CurrentRow.Cells;
                int deleteId = 0;
                int.TryParse(cells["groupid"].Value.ToString(), out deleteId);
                if (deleteId <= 0)
                {
                    ShowAlert("请选择要删除的微信群");
                    return;
                }
                MessageConfirm confirm = new MessageConfirm();
                confirm.Message = "确认要删除该微信群吗";
                confirm.CallBack += () =>
                {
                    this.dgvChatRoom.Rows.RemoveAt(cell.RowIndex);
                    ShowAlert("删除成功");
                    ((Action)(delegate ()
                    {
                        LogicUser.Instance.DeleteReplyWeChat(MyUserInfo.LoginToken, deleteId);

                    })).BeginInvoke(null, null);

                };
                confirm.ShowDialog(this);
            }
        }
        private void btnAddChat_Click(object sender, EventArgs e)
        {
            AddWeChat wechat = new AddWeChat(hotForm, this);
            wechat.Title = "添加微信群";
            wechat.ShowDialog(this);
        }
        private void ShowAlert(string Message)
        {
            MessageAlert alert = new MessageAlert();
            alert.Message = Message;
            alert.ShowDialog(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSendMessage.Text))
            {
                return;
            }
            if (hotForm.wxlogin != null && !hotForm.wxlogin.isCloseWinForm)
            {
                //hotForm.wxlogin.LoadAutoHandleData();
                StartSend();
                hotForm.wxlogin.CheckActiveSendMessage();
            }
            else
            {
                MessageConfirm confirm = new MessageConfirm("您还没有微信授权，是否马上微信授权?");
                confirm.CallBack += () =>
                {
                    if (hotForm.wxlogin == null)
                    {
                        hotForm.wxlogin = new wxLogin(hotForm);
                        hotForm.wxlogin.ShowDialog(this);
                    }
                    else
                    {
                        if (hotForm.wxlogin.isCloseWinForm)
                            hotForm.wxlogin.ShowWx();
                    }
                };
                confirm.ShowDialog(this);
            }
        }

        /// <summary>
        /// 开始发送
        /// </summary>
        private void StartSend()
        {
            MyUserInfo.SendMessageStatus = 1;
            MyUserInfo.SendMessageText = txtSendMessage.Text;
            //检查发送状态            
            checkSendTime.Start();
            SetSendStatuTip("正在发送中,请稍后...");
            

        }

        /// <summary>
        /// 设置发送状态
        /// </summary>
        /// <param name="text"></param>
        private void SetSendStatuTip(string text)
        {
            if (lbSendStatus.InvokeRequired)
            {
                this.Invoke(new Action<string>(SetSendStatuTip), new object[] { text });
            }
            else
            {
                lbSendStatus.Text = text;
                if (MyUserInfo.SendMessageStatus == 2)
                {
                    txtSendMessage.ReadOnly = false;
                    btnSave.Enabled = true;
                }
                if (MyUserInfo.SendMessageStatus == 1)
                {
                    txtSendMessage.ReadOnly = true;
                    btnSave.Enabled = false;
                }
            }
        }
    }
}
