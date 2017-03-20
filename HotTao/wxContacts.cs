using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WwChatHttpCore.Objects;

namespace HotTao
{
    public partial class wxContacts : Form
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

        private wxLogin wxlg { get; set; }
        public wxContacts(wxLogin winForm, Image img)
        {
            InitializeComponent();
            wxlg = winForm;
            pbHeadImg.Image = img;
        }

        private void wxContacts_Load(object sender, EventArgs e)
        {
            SetWinFormTaskbarSystemMenu();


            this.dgvWeChatList.AutoGenerateColumns = false;
            this.dgvWeChatList.Rows.Clear();

            dgvWeChatList.MouseWheel += DgvData_MouseWheel;
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
                        //if (ri - 3 > 0)
                        //    c = 3;
                        //else 
                        if (ri > 0)
                            c = 1;
                        if (c > 0)
                        {
                            dvc = dataGridView1.Rows[ri - c].Cells[ci];
                            dataGridView1.CurrentCell = dvc;
                        }
                    }
                    else
                    {
                        //if (ri < dataGridView1.Rows.Count - 3)
                        //    c = 3;
                        //else 
                        if (ri < dataGridView1.Rows.Count - 1)
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



        private void picClose_Click(object sender, EventArgs e)
        {
            wxlg.isCloseWinForm = true;
            wxlg.isStartTask = false;
            if (wxlg.taskForm != null)
                wxlg.taskForm.ShowStartButtonText("开始计划");
            if (wxlg.historyForm != null)
                wxlg.historyForm.ShowStartButtonText("开始计划");
            this.Close();
        }


        public void SetTitle(string title)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(SetTitle), new object[] { title });
            }
            else
            {
                this.Text = "[" + title + "】的通讯录";
                this.txtNickName.Text = title;
            }
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="text">The text.</param>
        public void SetLog(string text, bool showTime = true)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string, bool>(SetLog), new object[] { text, showTime });
            }
            else
            {
                if (showTime)
                    this.txtSendLog.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + text + "\r\n");
                else
                {
                    this.txtSendLog.AppendText(text + "\r\n");
                }

                this.txtSendLog.Refresh();
                this.txtSendLog.ScrollToCaret();
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



        /// <summary>
        /// 无边框样式的winform窗口，需要单独设置，才能启用任务栏的系统菜单功能，
        /// </summary>
        private void SetWinFormTaskbarSystemMenu()
        {
            //无标题窗体右键菜单
            int WS_SYSMENU = 0x00080000; // 系统菜单
            int WS_MINIMIZEBOX = 0x20000; // 最大最小化按钮
            int windowLong = (WinApi.GetWindowLong(new HandleRef(this, this.Handle), -16));
            WinApi.SetWindowLong(new HandleRef(this, this.Handle), -16, windowLong | WS_SYSMENU | WS_MINIMIZEBOX);
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {

           
        }

        /// <summary>
        /// 刷新通讯录
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolsRefresh_Click(object sender, EventArgs e)
        {
            wxlg.ReloadContact();            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var data = wxlg.contact_all.FindAll(item =>
            {
                return item.ShowName.Contains(txtSearch.Text);
            });
            SetSearhContactsView(data);
        }

        private void picMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
