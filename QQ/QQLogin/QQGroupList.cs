using iQQ.Net.WebQQCore.Im.Bean;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QQLogin
{
    public partial class QQGroupList : FormEx
    {
        //public QQLogin loginForm { get; set; }

        /// <summary>
        /// 当前鼠标所在的行索引
        /// </summary>
        private int currentRowIndex { get; set; }

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



        public QQGroupList(QQLogin qq)
        {
            InitializeComponent();
            //loginForm = qq;
        }

        private void QQGroupList_Load(object sender, EventArgs e)
        {
            lbTitle.Text = string.Format("WQQ-{0}", QQGlobal.account.QQ.ToString());
            new System.Threading.Thread(() =>
            {
                while (!QQGlobal.QQGroupLoadSuccess) { }
                SetContactsView(QQGlobal.client.GetGroupList());
            })
            { IsBackground = true }.Start();
        }

        /// <summary>
        /// 加载微信通讯录
        /// </summary>
        /// <param name="contact_all">The contact_all.</param>
        public void SetContactsView(List<QQGroup> contact_all)
        {
            if (dgvContact.InvokeRequired)
            {
                this.dgvContact.Invoke(new Action<List<QQGroup>>(SetContactsView), new object[] { contact_all });
            }
            else
            {
                this.dgvContact.Rows.Clear();
                int i = dgvContact.Rows.Count;
                picLoading.Visible = false;
                foreach (var user in contact_all)
                {
                    dgvContact.Rows.Add();
                    ++i;
                    dgvContact.Rows[i - 1].Cells["GroupTitle"].Value = user.Name;
                    dgvContact.Rows[i - 1].Cells["GroupGid"].Value = user.Gid;
                    dgvContact.Rows[i - 1].DefaultCellStyle.BackColor = QQGlobal.backColor;
                    dgvContact.Rows[i - 1].DefaultCellStyle.SelectionBackColor = QQGlobal.backColor;
                }
            }
        }


        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picClose_Click(object sender, EventArgs e)
        {
            if (QQGlobal.loginForm.IsCloseHandler)
                QQGlobal.loginForm.closeHandler();
            else
            {
                Application.ExitThread();
                Process.GetCurrentProcess().Kill();
            }
        }
        /// <summary>
        /// 最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 鼠标进入单元格时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvContact_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            currentRowIndex = e.RowIndex;
            dgvContact.Rows[e.RowIndex].DefaultCellStyle.BackColor = QQGlobal.backColorSelected;
            dgvContact.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = QQGlobal.backColorSelected;
        }

        /// <summary>
        /// 鼠标离开单元格时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvContact_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection cells = this.dgvContact.CurrentRow.Cells;
            if (cells[0].RowIndex != e.RowIndex)
            {
                dgvContact.Rows[e.RowIndex].DefaultCellStyle.BackColor = QQGlobal.backColor;
                dgvContact.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = QQGlobal.backColor;
            }
        }
        /// <summary>
        /// 点击单元格时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvContact_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection cells = this.dgvContact.CurrentRow.Cells;
            foreach (DataGridViewRow row in this.dgvContact.Rows)
            {
                if (row.Cells[0].RowIndex != e.RowIndex)
                {
                    row.DefaultCellStyle.BackColor = QQGlobal.backColor;
                    row.DefaultCellStyle.SelectionBackColor = QQGlobal.backColor;
                }
            }
        }



        /// <summary>
        /// 右键菜单在打开时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsTools_Opening(object sender, CancelEventArgs e)
        {
            DataGridViewCellCollection cells = this.dgvContact.CurrentRow.Cells;
            if (cells == null) e.Cancel = true;
            if (cells[0].RowIndex != currentRowIndex)
                e.Cancel = true;
            else
            {
                long gid = (long)cells["GroupGid"].Value;
                if (QQGlobal.listenGroups.Exists((g) => { return g.Gid == gid; }))
                    toolAddListen.Text = "移除监控";
                else
                    toolAddListen.Text = "添加监控";
            }

        }

        private void toolAddListen_Click(object sender, EventArgs e)
        {
            DataGridViewCellCollection cells = this.dgvContact.CurrentRow.Cells;
            if (cells == null) return;
            long gid = (long)cells["GroupGid"].Value;
            QQGroup group = QQGlobal.store.GetGroupByGin(gid);
            if (QQGlobal.listenGroups.Exists((g) => { return g.Gid == gid; }))
            {
                QQGlobal.listenGroups.Remove(group);
                cells["GroupTitle"].Value = group.Name;
            }
            else
            {
                QQGlobal.listenGroups.Add(group);
                cells["GroupTitle"].Value += "(已监控)";
            }

        }
    }
}
