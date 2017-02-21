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
using System.Threading;

namespace HotTao.Controls
{
    public partial class TaskControl : UserControl
    {
        private Main hotForm { get; set; }
        public int CurrentShowRowNumber { get; set; }

        public const int PageRowCount = 100;

        public TaskControl(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }
        private void HomeControl_Load(object sender, EventArgs e)
        {
            if (hotForm.currentUserId > 0)
            {
                CurrentShowRowNumber = 1;
                LoadGoodsGridView();
                loadUserPidGridView();
                LoadTaskPlanGridView();
            }
            else
                hotForm.openControl(new LoginControl(hotForm));

            dgvData.MouseWheel += DgvData_MouseWheel;
            dgvPid.MouseWheel += DgvData_MouseWheel;
            dgvTaskPlan.MouseWheel += DgvData_MouseWheel;

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
                    if (e.Delta > 0)//向上
                    {
                        if (ri > 0)
                        {
                            dvc = dataGridView1.Rows[ri - 1].Cells[ci];
                            dataGridView1.CurrentCell = dvc;
                        }
                    }
                    else
                    {
                        if (ri < dataGridView1.Rows.Count - 1)
                        {
                            dvc = dataGridView1.Rows[ri + 1].Cells[ci];
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


        /// <summary>
        /// 加载用户推广位
        /// </summary>
        private void loadUserPidGridView()
        {

            //是否自动添加属性字段
            this.dgvPid.AutoGenerateColumns = false;
            ((Action)(delegate ()
            {
                var pidData = LogicUserPid.Instance.getUserPidList(hotForm.currentUserId);
                if (pidData != null)
                {
                    this.BeginInvoke((Action)(delegate ()  //等待结束
                    {
                        SetPidView(pidData);
                        if (this.dgvPid.Rows.Count > 0)
                        {
                            dgvPid.Rows[0].Selected = false;
                            dgvPid.ContextMenuStrip = cmsWeChatMenu;
                        }
                    }));
                }

            })).BeginInvoke(null, null);
        }


        private void SetPidView(List<UserPidModel> data)
        {
            int i = dgvPid.Rows.Count;
            for (int j = 0; j < data.Count(); j++)
            {
                dgvPid.Rows.Add();
                ++i;
                dgvPid.Rows[i - 1].Cells["shareid"].Value = data[j].id.ToString();
                dgvPid.Rows[i - 1].Cells["sharetitle"].Value = data[j].title.ToString();
                dgvPid.Rows[i - 1].Cells["pid"].Value = data[j].pid.ToString();
                if (i % 2 == 0)
                    dgvPid.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                else
                    dgvPid.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;

                dgvPid.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                dgvPid.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;
            }
        }

        private void LoadTaskPlanGridView()
        {
            //是否自动添加属性字段
            this.dgvTaskPlan.AutoGenerateColumns = false;
            ((Action)(delegate ()
            {
                var taskData = LogicTaskPlan.Instance.getTaskPlanList(hotForm.currentUserId);
                if (taskData != null)
                {
                    this.BeginInvoke((Action)(delegate ()  //等待结束
                    {

                        SetTaskView(taskData);
                        if (this.dgvTaskPlan.Rows.Count > 0)
                        {
                            dgvTaskPlan.Rows[0].Selected = false;
                            dgvTaskPlan.ContextMenuStrip = cmsTaskMeun;
                        }
                    }));
                }

            })).BeginInvoke(null, null);
        }

        private void SetTaskView(List<TaskPlanModel> taskData)
        {
            int i = dgvTaskPlan.Rows.Count;
            for (int j = 0; j < taskData.Count(); j++)
            {
                dgvTaskPlan.Rows.Add();
                ++i;
                dgvTaskPlan.Rows[i - 1].Cells["taskid"].Value = taskData[j].id.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["taskTitle"].Value = taskData[j].title.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["taskStartTime"].Value = taskData[j].startTime.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["taskStatusText"].Value = taskData[j].statusText.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["goodsText"].Value = taskData[j].goodsText.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["pidsText"].Value = taskData[j].pidsText.ToString();
                if (i % 2 == 0)
                    dgvTaskPlan.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                else
                    dgvTaskPlan.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;

                dgvTaskPlan.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                dgvTaskPlan.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;
            }
        }


        /// <summary>
        /// 加载商品数据
        /// </summary>
        private void LoadGoodsGridView()
        {
            new Thread(() =>
            {
                //是否自动添加属性字段
                this.dgvData.AutoGenerateColumns = false;
                var data = LogicGoods.Instance.getGoodsList(CurrentShowRowNumber, PageRowCount);
                if (data != null)
                {
                    SetGoodsGridViewData(dgvData, data);
                    if (this.dgvData.Rows.Count > 0)
                        dgvData.Rows[0].Selected = false;
                }
            })
            { IsBackground = true }.Start();

        }

        private void SetGoodsGridViewData(DataGridView obj, List<GoodsModel> data)
        {
            if (dgvData.InvokeRequired)
            {
                this.Invoke(new Action<DataGridView, List<GoodsModel>>(SetGoodsGridViewData), new object[] { obj, data });
            }
            else
            {
                if (CurrentShowRowNumber == 1)
                    obj.Rows.Clear();

                int i = dgvData.Rows.Count;
                for (int j = 0; j < data.Count(); j++)
                {
                    obj.Rows.Add();
                    ++i;
                    obj.Rows[i - 1].Cells["rowIndex"].Value = data[j].rowIndex.ToString();
                    obj.Rows[i - 1].Cells["gid"].Value = data[j].id.ToString();
                    obj.Rows[i - 1].Cells["goodsId"].Value = data[j].goodsId.ToString();
                    obj.Rows[i - 1].Cells["goodsDetailUrl"].Value = data[j].goodsDetailUrl.ToString();
                    obj.Rows[i - 1].Cells["goodsName"].Value = data[j].goodsName.ToString();
                    obj.Rows[i - 1].Cells["goodsSupplier"].Value = data[j].goodsSupplier.ToString();
                    obj.Rows[i - 1].Cells["goodsPrice"].Value = data[j].goodsPrice.ToString();
                    obj.Rows[i - 1].Cells["goodsSalesAmount"].Value = data[j].goodsSalesAmount.ToString();
                    obj.Rows[i - 1].Cells["goodsComsRate"].Value = data[j].goodsComsRate.ToString();
                    obj.Rows[i - 1].Cells["goodsCommission"].Value = data[j].goodsCommission.ToString();
                    obj.Rows[i - 1].Cells["couponPrice"].Value = data[j].couponPrice.ToString();
                    obj.Rows[i - 1].Cells["updateTime"].Value = data[j].updateTime.ToString();
                    obj.Rows[i - 1].Cells["startTime"].Value = data[j].startTime.ToString();
                    obj.Rows[i - 1].Cells["endTime"].Value = data[j].endTime.ToString();
                    obj.Rows[i - 1].Cells["createTime"].Value = data[j].createTime.ToString();
                    obj.Rows[i - 1].Cells["couponUrl"].Value = data[j].couponUrl.ToString();
                    obj.Rows[i - 1].Cells["shareLink"].Value = data[j].shareLink.ToString();
                    obj.Rows[i - 1].Cells["goodsMainImgUrl"].Value = data[j].goodsMainImgUrl.ToString();


                    if (i % 2 == 0)
                        obj.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                    else
                        obj.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;
                    obj.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                    obj.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;
                }

            }
        }
        /// <summary>
        /// 商品数据滚动加载
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ScrollEventArgs"/> instance containing the event data.</param>
        private void dgvData_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue < e.NewValue && dgvData.RowCount < e.NewValue + 16)
            {
                CurrentShowRowNumber++;
                var goodsData = LogicGoods.Instance.getGoodsList(CurrentShowRowNumber, PageRowCount);
                if (goodsData != null)
                {
                    //data.AddRange(goodsData);
                    SetGoodsGridViewData(dgvData, goodsData);
                }
            }
        }

        /// <summary>
        /// 添加/编辑计划任务
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            TaskEdit te = new TaskEdit(this);
            te.ShowDialog(this);
        }

        /// <summary>
        /// 删除计划
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolTaskDel_Click(object sender, EventArgs e)
        {

        }



        private bool allSelected = false;

        /// <summary>
        /// 微信群全选和取消
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolWeChatAllSelected_Click(object sender, EventArgs e)
        {
            if (dgvPid.Rows != null && dgvPid.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvPid.Rows)
                {
                    int result = 0;
                    int.TryParse(row.Cells["shareid"].Value.ToString(), out result);
                    if (!allSelected)
                    {
                        row.Cells[0].Value = result;
                        row.Selected = true;
                    }
                    else
                    {
                        row.Cells[0].Value = 0;
                        row.Selected = false;
                    }
                }
                allSelected = !allSelected;
            }


            if (allSelected)
                toolWeChatAllSelected.Text = "取消选择";
            else
                toolWeChatAllSelected.Text = "全择";
        }
        /// <summary>
        /// 添加/编辑微信群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnAddWeChatGroup_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolWeChatDel_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 修改任务计划
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void dgvTaskPlan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = this.dgvTaskPlan.CurrentRow.Cells["edittask"];
            if (cell != null && cell.ColumnIndex == e.ColumnIndex)
            {
                btnAddTask_Click(null, null);
            }

        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //
            DataGridViewCell cell = this.dgvData.CurrentRow.Cells["editgoods"];
            if (cell != null && cell.ColumnIndex == e.ColumnIndex)
            {
                this.dgvData.Rows.RemoveAt(cell.RowIndex);
                MessageBox.Show("删除成功");
            }
        }

        /// <summary>
        /// 采集微信聊天窗口
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnWeChatWinGet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("请确保采集的群聊都单独拖出来", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var wins = WinApi.GetAllDesktopWindows();
                if (wins != null && wins.Count() > 0)
                {
                    List<UserPidModel> testData = new List<UserPidModel>();
                    int itemid = dgvPid.Rows.Count + 1;
                    foreach (var win in wins)
                    {
                        testData.Add(new UserPidModel()
                        {
                            id = itemid,
                            title = win.szWindowName,
                            userid = 1,
                            pid = ""
                        });
                        itemid++;
                    }
                    SetPidView(testData);
                }
                else
                {
                    MessageBox.Show("微信初始化失败,请把需要采集的群聊单独拖出来");
                }
            }
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAddGoods_Click(object sender, EventArgs e)
        {

        }
    }
}
