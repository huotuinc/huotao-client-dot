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
        public ListenForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void ListenForm_Load(object sender, EventArgs e)
        {

        }




        /// <summary>
        /// 设置监控内容
        /// </summary>
        /// <param name="user">The user.</param>
        public void SetDataContentView(WXUser user,string content)
        {
            if (dgvWeChatList.InvokeRequired)
            {
                this.Invoke(new Action<WXUser, string>(SetDataContentView), new object[] { user, content });
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

                dgvWeChatList.CurrentCell = dgvWeChatList.Rows[dgvWeChatList.Rows.Count - 1].Cells[dgvWeChatList.CurrentCell.ColumnIndex];

            }
        }




        /// <summary>
        /// 设置联系人
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

                dgvWeChatList.CurrentCell = dgvWeChatList.Rows[dgvWeChatList.Rows.Count - 1].Cells[dgvWeChatList.CurrentCell.ColumnIndex];

            }
        }
        public void SetSearhContactsView(List<WXUser> contact_all)
        {
            if (dgvWeChatList.InvokeRequired)
            {
                this.Invoke(new Action<List<WXUser>>(SetSearhContactsView), new object[] { contact_all });
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
        }
    }
}
