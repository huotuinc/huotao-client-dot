using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WwChatHttpCore.Objects;

namespace HotTaoMonitoring.UserControls
{
    public partial class ListenForm : UserControl
    {
        private MainForm mainForm { get; set; }

        public EditForm editForm { get; set; }

        public ListenForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void ListenForm_Load(object sender, EventArgs e)
        {
            SetContactsView(mainForm.contact_all);
        }


        /// <summary>
        /// 设置监控内容
        /// </summary>
        /// <param name="user">The user.</param>
        public void SetDataContentView(WXUser user, string msgSendUser, string nickName, string content)
        {
            if (dgvWeChatList.InvokeRequired)
            {
                this.Invoke(new Action<WXUser, string, string, string>(SetDataContentView), new object[] { user, msgSendUser, nickName, content });
            }
            else
            {
                int i = dataContent.Rows.Count;
                dataContent.Rows.Add();
                ++i;
                dataContent.Rows[i - 1].Cells["MsgContent"].Value = DateTime.Now.ToString("MM-dd HH:mm:ss") + " " + user.ShowName + " [" + nickName + "]:" + content.Replace("<br/>", "\r\n");
                dataContent.Rows[i - 1].Cells["MsgUserName"].Value = user.UserName;
                dataContent.Rows[i - 1].Cells["MsgNickName"].Value = nickName;
                dataContent.Rows[i - 1].Cells["MsgText"].Value = content;
                dataContent.Rows[i - 1].Cells["MsgStatus"].Value = "未回复";
                dataContent.Rows[i - 1].Cells["MsgSendUser"].Value = msgSendUser;
                if (i % 2 == 0)
                {
                    dataContent.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                    dataContent.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewEvenRowBackColor;
                }
                else
                {
                    dataContent.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;
                    dataContent.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewOddRowBackColor;
                }
                dataContent.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                dataContent.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;
                if (editForm != null && editForm.toUserName == user.UserName && editForm.toNickName == nickName)
                {
                    editForm.CurrentRowIndex = i - 1;
                    editForm.ShowReceiveMsg(nickName, content);
                    editForm.writeCacheData();
                }

            }
        }

        /// <summary>
        /// 设置回复状态
        /// </summary>
        /// <param name="CurrentRowIndex">Index of the current row.</param>
        public void SetDataContentViewStatus(int CurrentRowIndex)
        {
            dataContent.Rows[CurrentRowIndex].Cells["MsgStatus"].Value = "已回复";
        }



        /// <summary>
        /// 加载微信通讯录
        /// </summary>
        /// <param name="user">The user.</param>
        public void SetContactsView(WXUser user)
        {
            if (dgvWeChatList.InvokeRequired)
            {
                this.Invoke(new Action<WXUser>(SetContactsView), new object[] { user });
            }
            else
            {
                int i = dgvWeChatList.Rows.Count;
                dgvWeChatList.Rows.Add();
                ++i;
                dgvWeChatList.Rows[i - 1].Cells["ShowName"].Value = user.ShowName;
                dgvWeChatList.Rows[i - 1].Cells["UserName"].Value = user.UserName;
                if (i % 2 == 0)
                {
                    dgvWeChatList.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                    dgvWeChatList.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewEvenRowBackColor;
                }
                else
                {
                    dgvWeChatList.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;
                    dgvWeChatList.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewOddRowBackColor;
                }
                dgvWeChatList.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                dgvWeChatList.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;

            }
        }
        /// <summary>
        /// 加载微信通讯录
        /// </summary>
        /// <param name="contact_all">The contact_all.</param>
        public void SetContactsView(List<WXUser> contact_all)
        {
            if (dgvWeChatList.InvokeRequired)
            {
                this.Invoke(new Action<List<WXUser>>(SetContactsView), new object[] { contact_all });
            }
            else
            {
                this.dgvWeChatList.Rows.Clear();
                int i = dgvWeChatList.Rows.Count;

                foreach (var user in contact_all)
                {
                    dgvWeChatList.Rows.Add();
                    ++i;
                    dgvWeChatList.Rows[i - 1].Cells["ShowName"].Value = user.ShowName;
                    dgvWeChatList.Rows[i - 1].Cells["UserName"].Value = user.ShowName;
                    if (i % 2 == 0)
                    {
                        dgvWeChatList.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                        dgvWeChatList.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewEvenRowBackColor;
                    }
                    else
                    {
                        dgvWeChatList.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;
                        dgvWeChatList.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewOddRowBackColor;
                    }
                    dgvWeChatList.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                    dgvWeChatList.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;
                }
            }
        }

        /// <summary>
        /// 获取选中的微信群
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        public List<string> GetSelectedWeChat()
        {
            List<string> data = new List<string>();
            foreach (DataGridViewRow item in dgvWeChatList.Rows)
            {
                if ((bool)item.Cells[0].EditedFormattedValue == true)
                {
                    string title = item.Cells["ShowName"].Value.ToString();
                    if (!data.Contains(title))
                        data.Add(title);
                }
            }

            return data;
        }


        /// <summary>
        /// 刷新列表
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolsRefresh_Click(object sender, EventArgs e)
        {
            if (mainForm.wxlogin != null)
            {
                this.dgvWeChatList.Rows.Clear();
                mainForm.wxlogin.ReloadContact();
            }
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var data = mainForm.contact_all.FindAll(item =>
            {
                return item.ShowName.Contains(txtSearch.Text);
            });
            SetContactsView(data);
        }

        /// <summary>
        /// 全选、取消
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolsAllSelected_Click(object sender, EventArgs e)
        {
            if (dgvWeChatList.Rows != null && dgvWeChatList.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvWeChatList.Rows)
                {
                    int result = 0;
                    int.TryParse(row.Cells["UserName"].Value.ToString(), out result);
                    if (!mainForm.IsSelected)
                    {
                        row.Cells[0].Value = 1;
                        row.Selected = true;
                    }
                    else
                    {
                        row.Cells[0].Value = 0;
                        row.Selected = false;
                    }
                }
                mainForm.IsSelected = !mainForm.IsSelected;
                toolsAllSelected.Text = mainForm.IsSelected ? "取消全选" : "全选";
            }
        }

        private void dataContent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection cells = this.dataContent.CurrentRow.Cells;
            if (cells != null && cells["edit"].ColumnIndex == e.ColumnIndex)
            {
                if (editForm == null)
                {
                    editForm = new EditForm(mainForm, this);
                    editForm.toUserName = cells["MsgUserName"].Value.ToString();
                    editForm.toNickName = cells["MsgNickName"].Value.ToString();
                    editForm.StartPosition = FormStartPosition.CenterScreen;
                    editForm.MsgSendUser = cells["MsgSendUser"].Value.ToString();
                    editForm.CurrentRowIndex = e.RowIndex;
                    editForm.Show(this);
                    editForm.ShowReceiveMsg(editForm.toNickName, cells["MsgText"].Value.ToString());
                    editForm.writeCacheData();
                }
                else if (editForm.toUserName != cells["MsgUserName"].Value.ToString() || editForm.toNickName != cells["MsgNickName"].Value.ToString())
                {
                    editForm.toUserName = cells["MsgUserName"].Value.ToString();
                    editForm.toNickName = cells["MsgNickName"].Value.ToString();
                    editForm.MsgSendUser = cells["MsgSendUser"].Value.ToString();

                    editForm.CurrentRowIndex = e.RowIndex;
                    editForm.SetTitle(editForm.toNickName);
                    editForm.LoadHtml();                    
                    //editForm.ShowReceiveMsg(editForm.toNickName, cells["MsgText"].Value.ToString());
                    editForm.Show();
                }
                else
                {
                    editForm.Show();
                }
                
            }
        }
    }
}
