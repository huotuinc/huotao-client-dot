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
using Newtonsoft.Json;

namespace HotTao.Controls
{
    public partial class HistoryControl : UserControl
    {
        /// <summary>
        /// 鼠标当前所在行索引
        /// </summary>
        private int MouseCurrentRowIndex = 0;
        /// <summary>
        /// 转链成功的任务id集合
        /// </summary>
        private List<int> lstSuccessTaskId { get; set; }
        private Main hotForm { get; set; }
        public HistoryControl(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }

        private void HistoryControl_Load(object sender, EventArgs e)
        {
            if (hotForm.currentUserId > 0)
            {
                if (hotForm.wxlogin != null)
                    ShowStartButtonText("暂停计划");
                LoadTaskPlanGridView();
            }
            else
                hotForm.openControl(new LoginControl(hotForm));

        }


        /// <summary>
        /// 加载计划数据
        /// </summary>
        public void LoadTaskPlanGridView()
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
                            dgvTaskPlan.ContextMenuStrip = cmsTask;
                        }
                    }));
                }

            })).BeginInvoke(null, null);
        }


        private void SetTaskView(List<TaskPlanModel> taskData)
        {
            dgvTaskPlan.Rows.Clear();
            int i = dgvTaskPlan.Rows.Count;
            for (int j = 0; j < taskData.Count(); j++)
            {
                dgvTaskPlan.Rows.Add();
                ++i;
                dgvTaskPlan.Rows[i - 1].Cells["taskid"].Value = taskData[j].id.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["taskTitle"].Value = taskData[j].title.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["taskStartTime"].Value = taskData[j].startTime.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["taskEndTime"].Value = taskData[j].endTime.ToString();


                dgvTaskPlan.Rows[i - 1].Cells["startTimeText"].Value = taskData[j].startTimeText.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["taskStatusText"].Value = taskData[j].statusText.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["goodsText"].Value = taskData[j].goodsText.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["pidsText"].Value = taskData[j].pidsText.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["ExecStatus"].Value = taskData[j].ExecStatus.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["isTpwd"].Value = taskData[j].isTpwd.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["TpwdText"].Value = taskData[j].isTpwd == 1 ? "OK" : "";
                if (i % 2 == 0)
                    dgvTaskPlan.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                else
                    dgvTaskPlan.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;

                dgvTaskPlan.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                dgvTaskPlan.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;
            }
        }



        /// <summary>
        /// 开始转链
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartTpwd_Click(object sender, EventArgs e)
        {
            lstSuccessTaskId = new List<int>();
            if (dgvTaskPlan.Rows != null)
            {
                foreach (DataGridViewRow row in dgvTaskPlan.Rows)
                {
                    int result = 0;
                    int.TryParse(row.Cells["isTpwd"].Value.ToString(), out result);
                    if (result == 0)
                        StartTaskTpwd(row);
                }
                //更新转链结果
                LogicTaskPlan.Instance.UpdateTaskIsTpwd(hotForm.currentUserId, lstSuccessTaskId);
            }
        }
        /// <summary>
        /// 启动任务计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartTask_Click(object sender, EventArgs e)
        {
            if (hotForm.wxlogin == null)
            {
                hotForm.wxlogin = new wxLogin(hotForm, this);
                hotForm.wxlogin.Show();
            }
            else
            {
                hotForm.wxlogin.CloseWx();
                if (hotForm.wxlogin.isStartTask)
                    ShowStartButtonText("暂停计划");
                else
                    ShowStartButtonText("启用计划");
            }
        }

        public void ShowStartButtonText(string text)
        {
            btnStartTask.Text = text;
        }

        /// <summary>
        /// 修改计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolsTaskUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewCellCollection cells = this.dgvTaskPlan.Rows[MouseCurrentRowIndex].Cells;
            if (cells != null)
            {
                UpdateTask(cells);
            }
        }
        /// <summary>
        /// 复制计划（重启计划）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolsTaskCopy_Click(object sender, EventArgs e)
        {
            DataGridViewCellCollection cells = this.dgvTaskPlan.Rows[MouseCurrentRowIndex].Cells;
            if (cells != null)
            {
                TaskEdit te = new TaskEdit(hotForm, this);
                te.Title = "复制任务计划";
                te.hotGoodsText = JsonConvert.DeserializeObject<List<GoodsTaskModel>>(cells["goodsText"].Value.ToString());
                te.hotPidsText = JsonConvert.DeserializeObject<List<UserPidTaskModel>>(cells["pidsText"].Value.ToString());
                te.taskStartTime = cells["taskStartTime"].Value.ToString();
                te.taskTitle = cells["taskTitle"].Value.ToString();
                te.taskEndTime = cells["taskEndTime"].Value.ToString();
                te.ShowDialog(this);
            }
        }
        /// <summary>
        /// 一键转链
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolsTaskTpwd_Click(object sender, EventArgs e)
        {
            lstSuccessTaskId = new List<int>();
            DataGridViewRow row = this.dgvTaskPlan.Rows[MouseCurrentRowIndex];
            if (row != null)
            {
                int result = 0;
                int.TryParse(row.Cells["isTpwd"].Value.ToString(), out result);
                if (result > 0)
                {
                    MessageConfirm confirm = new MessageConfirm("确定重新转链");
                    confirm.CallBack += () =>
                    {
                        StartTaskTpwd(row);
                    };
                    confirm.ShowDialog(this);
                }
                else
                    StartTaskTpwd(row);

                //更新转链结果
                LogicTaskPlan.Instance.UpdateTaskIsTpwd(hotForm.currentUserId, lstSuccessTaskId);
            }
        }

        /// <summary>
        /// 开始转链
        /// </summary>
        /// <param name="row"></param>
        private void StartTaskTpwd(DataGridViewRow row)
        {
            ((Action)(delegate ()
            {
                int eCode = 0;
                int.TryParse(row.Cells["ExecStatus"].Value.ToString(), out eCode);
                if (eCode == 0 || eCode == 1)
                {
                    int result = 0;
                    int.TryParse(row.Cells["taskid"].Value.ToString(), out result);
                    row.Cells["TpwdText"].Value = "正在转链";
                    if (LogicTaskPlan.Instance.StartTaskTpwd(hotForm.currentUserId, result))
                    {
                        row.Cells["TpwdText"].Value = "OK";
                        row.Cells["isTpwd"].Value = 1;
                        lstSuccessTaskId.Add(result);
                    }
                    else
                    {
                        row.Cells["TpwdText"].Value = "转链失败";
                        row.Cells["isTpwd"].Value = 0;
                    }
                }
            })).BeginInvoke(null, null);
        }


        /// <summary>
        /// 删除计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolsTaskDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dgvTaskPlan.Rows[MouseCurrentRowIndex];
            if (row != null)
            {
                int taskid = Convert.ToInt32(row.Cells["taskid"].Value);
                int eCode = 0;
                int.TryParse(row.Cells["ExecStatus"].Value.ToString(), out eCode);
                if (eCode != 1)
                {
                    MessageConfirm confirm = new MessageConfirm("您确认要删除计划【" + taskid + "】吗？");
                    confirm.CallBack += () =>
                    {
                        if (LogicTaskPlan.Instance.deleteTaskPlan(hotForm.currentUserId, taskid))
                        {
                            dgvTaskPlan.Rows.Remove(row);
                        }
                    };
                    confirm.ShowDialog(this);
                }
                else
                    ShowAlert("不能删除正在执行的计划");
            }
            else
                ShowAlert("请先选择要删除的数据行!");
        }

        /// <summary>
        /// 修改计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTaskPlan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection cells = this.dgvTaskPlan.CurrentRow.Cells;
            if (cells != null && cells["edittask"].ColumnIndex == e.ColumnIndex)
            {
                UpdateTask(cells);
            }
        }

        private void dgvTaskPlan_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            MouseCurrentRowIndex = e.RowIndex;
        }


        private void UpdateTask(DataGridViewCellCollection cells)
        {
            int eCode = 0;
            int.TryParse(cells["ExecStatus"].Value.ToString(), out eCode);
            if (eCode == 0)
            {
                //
                TaskEdit te = new TaskEdit(hotForm, this);
                te.Title = "修改任务计划";
                int result = 0;
                int.TryParse(cells["taskid"].Value.ToString(), out result);
                te.taskid = result;
                te.taskStartTime = cells["taskStartTime"].Value.ToString();
                te.taskTitle = cells["taskTitle"].Value.ToString();
                te.taskEndTime = cells["taskEndTime"].Value.ToString();
                te.ShowDialog(this);
            }
            else
            {
                ShowAlert("只能修改[未执行]的任务");
            }
        }

        private void ShowAlert(string Message)
        {
            MessageAlert alert = new MessageAlert();
            alert.Message = Message;
            alert.ShowDialog(this);
        }
        private void ShowAlert(string Message, OKEventHandler handler)
        {
            MessageAlert alert = new MessageAlert();
            alert.Message = Message;
            alert.CallBack += handler;
            alert.ShowDialog(this);
        }
    }
}
