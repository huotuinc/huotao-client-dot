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

namespace HotTao.Controls
{
    public partial class UserPIDControl : Form
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
        /// <summary>
        /// 当前选中的行索引
        /// </summary>
        /// <value>The index of the current row.</value>
        public int CurrentRowIndex { get; set; }

        /// <summary>
        /// 当前需要设置的微信群ID
        /// </summary>
        /// <value>The we chat identifier.</value>
        public int WeChatId { get; set; }


        public UserPIDControl(Main main, TaskControl task)
        {
            InitializeComponent();
            hotForm = main;
            hotTask = task;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserPIDControl_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Title))
            {
                lbTitle.Text = Title;
                this.Text = Title;
            }
            loadUserPidGridView();

            dgvUserPid.MouseWheel += DgvData_MouseWheel;
        }

        /// <summary>
        /// 选择行
        /// </summary>
        private DataGridViewCellCollection SelectedRow;

        /// <summary>
        /// 加载用户推广位
        /// </summary>
        public void loadUserPidGridView()
        {

            //是否自动添加属性字段
            this.dgvUserPid.AutoGenerateColumns = false;
            this.dgvUserPid.Rows.Clear();
            ((Action)(delegate ()
            {
                var pidData = LogicUserPid.Instance.getUserPidList(hotForm.currentUserId, hotForm.taobaoNo);
                if (pidData != null)
                {
                    this.BeginInvoke((Action)(delegate ()  //等待结束
                    {
                        SetPidView(pidData);
                        if (this.dgvUserPid.Rows.Count > 0)
                        {
                            dgvUserPid.Rows[0].Selected = false;
                        }
                    }));
                }

            })).BeginInvoke(null, null);
        }



        private void SetPidView(List<UserPidModel> data)
        {
            int i = dgvUserPid.Rows.Count;
            for (int j = 0; j < data.Count(); j++)
            {
                dgvUserPid.Rows.Add();
                ++i;
                dgvUserPid.Rows[i - 1].Cells["id"].Value = data[j].id.ToString();
                dgvUserPid.Rows[i - 1].Cells["title"].Value = data[j].title.ToString();
                dgvUserPid.Rows[i - 1].Cells["pid"].Value = data[j].pid.ToString();
                if (i % 2 == 0)
                    dgvUserPid.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                else
                    dgvUserPid.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;

                dgvUserPid.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                dgvUserPid.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;
            }
        }
        /// <summary>
        /// 确定事件
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (WeChatId > 0)
            {
                this.Close();
                string pidText = string.Empty;
                int result = 0;
                if (SelectedRow != null)
                {
                    int.TryParse(SelectedRow["id"].Value.ToString(), out result);
                    pidText = SelectedRow["pid"].Value.ToString();
                }
                if (LogicUser.Instance.UpdateUserWeChatPid(hotForm.currentUserId, WeChatId, result))
                {
                    pidText = result > 0 ? pidText : "";
                    this.Close();
                    hotTask.SetWeChatRowData(CurrentRowIndex, "pid", pidText);
                }
            }
        }

        /// <summary>
        /// 点击列表行时触发选择操作
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void dgvUserPid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvUserPid.Rows.Count > 0)
            {

                foreach (DataGridViewRow item in this.dgvUserPid.Rows)
                {
                    if (item.Cells[0].RowIndex != e.RowIndex)
                    {
                        item.Cells["chkPid"].Value = 0;
                        item.Selected = false;
                    }
                }

                DataGridViewCellCollection row = this.dgvUserPid.Rows[e.RowIndex].Cells;
                if (row != null)
                {
                    if ((bool)row["chkPid"].EditedFormattedValue == true)
                    {
                        this.dgvUserPid.Rows[e.RowIndex].Cells["chkPid"].Value = 0;
                        this.dgvUserPid.Rows[e.RowIndex].Selected = false;
                        SelectedRow = null;
                    }
                    else
                    {
                        int result = 0;
                        int.TryParse(row["id"].Value.ToString(), out result);
                        this.dgvUserPid.Rows[e.RowIndex].Cells["chkPid"].Value = result;
                        this.dgvUserPid.Rows[e.RowIndex].Selected = true;
                        SelectedRow = row;
                    }
                }
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

    }
}
