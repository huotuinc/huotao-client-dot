using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotTaoCore.Logic;
using HotTaoCore.Models;
using Newtonsoft.Json;
using HotTaoCore;

namespace HotTao.Controls
{
    public partial class SetAutoRemoveChatroom : UserControl
    {
        private Main hotForm { get; set; }
        public SetAutoRemoveChatroom(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }

        private void SetAutoRemoveChatroom_Load(object sender, EventArgs e)
        {
            if (MyUserInfo.currentUserId > 0)
            {
                LoadConfig();
                LoadDgvChatRoom();
            }
            else
                hotForm.openControl(new LoginControl(hotForm));

            dgvChatRoom.MouseWheel += DgvData_MouseWheel;
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
                var data = LogicUser.Instance.GetUserReplyWeChatList(MyUserInfo.LoginToken, 1);
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

        private void LoadConfig()
        {
            if (hotForm.myConfig != null)
            {
                ckbAutoRemove.Checked = hotForm.myConfig.enable_autoremove == 1;

                ConfigWhereModel cfgWhere = string.IsNullOrEmpty(hotForm.myConfig.where_config) ? null : JsonConvert.DeserializeObject<ConfigWhereModel>(hotForm.myConfig.where_config);

                if (cfgWhere == null || string.IsNullOrEmpty(cfgWhere.auto_remove_user_where)) return;

                AutoRemoveUserWhereModel auto_remove = JsonConvert.DeserializeObject<AutoRemoveUserWhereModel>(cfgWhere.auto_remove_user_where);
                if (auto_remove == null) return;

                ckbSendMessage.Checked = auto_remove.enable_send_text == 1;
                ckbSendImage.Checked = auto_remove.enable_send_image == 1;
                ckbSendLink.Checked = auto_remove.enable_share_link == 1;
                ckbSendCard.Checked = auto_remove.enable_share_card == 1;

                txtSendTextLenght.Text = auto_remove.send_text_lenght.ToString();
                txtSendImageCount.Text = auto_remove.send_image_count.ToString();
            }
        }


        private void btnAddChat_Click(object sender, EventArgs e)
        {
            AddWeChat wechat = new AddWeChat(hotForm, this);
            wechat.Title = "添加微信群";
            wechat.ShowDialog(this);
        }

        private void ckbAutoRemove_CheckedChanged(object sender, EventArgs e)
        {
            ((Action)(delegate ()
            {
                hotForm.myConfig.enable_autoremove = ckbAutoRemove.Checked ? 1 : 0;

                LogicUser.Instance.AddUserConfigModel(MyUserInfo.LoginToken, hotForm.myConfig);

            })).BeginInvoke(null, null);
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

        private void ShowAlert(string Message)
        {
            MessageAlert alert = new MessageAlert();
            alert.Message = Message;
            alert.ShowDialog(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageAlert alert = new MessageAlert();
            Loading ld = new Loading();
            ((Action)(delegate ()
            {
                hotForm.myConfig.enable_autoremove = ckbAutoRemove.Checked ? 1 : 0;

                AutoRemoveUserWhereModel auto_remove_user_where = new AutoRemoveUserWhereModel();
                auto_remove_user_where.enable_send_text = ckbSendMessage.Checked ? 1 : 0;
                auto_remove_user_where.enable_send_image = ckbSendImage.Checked ? 1 : 0;
                auto_remove_user_where.enable_share_card = ckbSendCard.Checked ? 1 : 0;
                auto_remove_user_where.enable_share_link = ckbSendLink.Checked ? 1 : 0;

                int result = 0;

                int.TryParse(txtSendImageCount.Text, out result);
                auto_remove_user_where.send_image_count = result > 0 ? result : 2;

                //发送文本的长度
                int.TryParse(txtSendTextLenght.Text, out result);
                auto_remove_user_where.send_text_lenght = result > 0 ? result : 20;

                ConfigWhereModel cfgWhere = string.IsNullOrEmpty(hotForm.myConfig.where_config) ? null : JsonConvert.DeserializeObject<ConfigWhereModel>(hotForm.myConfig.where_config);

                cfgWhere.auto_remove_user_where = JsonConvert.SerializeObject(auto_remove_user_where);

                hotForm.myConfig.where_config = JsonConvert.SerializeObject(cfgWhere);
                int flag = LogicUser.Instance.AddUserConfigModel(MyUserInfo.LoginToken, hotForm.myConfig);

                ld.CloseForm();
                this.BeginInvoke((Action)(delegate ()  //等待结束
                {
                    alert.Message = flag > 0 ? "保存成功" : "保存失败";
                    alert.ShowDialog(this);
                }));

            })).BeginInvoke(null, null);
            ld.ShowDialog(hotForm);
        }


        /// <summary>
        /// 数字
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void TextBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;//消除不合适字符  
            }
        }
    }

}
