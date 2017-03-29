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
using System.Threading;

namespace HotTao.Controls
{
    public partial class HistoryControl : UserControl
    {
        /// <summary>
        /// 鼠标当前所在行索引
        /// </summary>
        private int MouseCurrentRowIndex = 0;

        private Main hotForm { get; set; }
        public HistoryControl(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }

        private void HistoryControl_Load(object sender, EventArgs e)
        {
            if (MyUserInfo.currentUserId > 0)
            {
                if (MyUserInfo.sendmode == 1)
                {
                    if (hotForm.wxlogin != null && hotForm.wxlogin.isStartTask)
                        ShowStartButtonText("暂停计划");
                }
                else
                {
                    if (hotForm.winTask != null && hotForm.winTask.isStartTask)
                        ShowStartButtonText("暂停计划");
                }
                LoadTaskPlanGridView();

                dgvTaskPlan.MouseWheel += DgvData_MouseWheel;
            }
            else
                hotForm.openControl(new LoginControl(hotForm));

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


        /// <summary>
        /// 加载计划数据
        /// </summary>
        public void LoadTaskPlanGridView()
        {
            new Thread(() =>
            {
                //是否自动添加属性字段
                this.dgvTaskPlan.AutoGenerateColumns = false;
                var taskData = LogicHotTao.Instance(MyUserInfo.currentUserId).FindByUserTaskPlanList(MyUserInfo.currentUserId);
                if (taskData != null)
                {
                    SetTaskView(taskData);
                    if (this.dgvTaskPlan.Rows.Count > 0)
                    {
                        dgvTaskPlan.Rows[0].Selected = false;
                        dgvTaskPlan.ContextMenuStrip = cmsTask;
                    }
                }
            })
            { IsBackground = true }.Start();
        }


        private void SetTaskView(List<TaskPlanModel> taskData)
        {
            if (dgvTaskPlan.InvokeRequired)
            {
                this.Invoke(new Action<List<TaskPlanModel>>(SetTaskView), new object[] { taskData });
            }
            else
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
                    dgvTaskPlan.Rows[i - 1].Cells["ExecStatus"].Value = taskData[j].status.ToString();
                    dgvTaskPlan.Rows[i - 1].Cells["isTpwd"].Value = taskData[j].isTpwd.ToString();
                    dgvTaskPlan.Rows[i - 1].Cells["TpwdText"].Value = taskData[j].isTpwd == 1 ? "OK" : "";

                    if (i % 2 == 0)
                    {
                        dgvTaskPlan.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                        dgvTaskPlan.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewEvenRowBackColor;
                    }
                    else
                    {
                        dgvTaskPlan.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;
                        dgvTaskPlan.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewOddRowBackColor;
                    }


                    dgvTaskPlan.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                    dgvTaskPlan.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;
                }
            }
        }



        /// <summary>
        /// 开始转链
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartTpwd_Click(object sender, EventArgs e)
        {
            bool isOK = false;
            MessageConfirm confirm = new MessageConfirm("请确保任务已经设置了PID");
            confirm.CallBack += () =>
            {
                isOK = true;
            };
            confirm.ShowDialog(this);
            if (!isOK) return;
            if (dgvTaskPlan.Rows != null)
            {

                foreach (DataGridViewRow row in dgvTaskPlan.Rows)
                {
                    ((Action)(delegate ()
                    {
                        int result = 0, eCode = 0;
                        int.TryParse(row.Cells["isTpwd"].Value.ToString(), out result);
                        int.TryParse(row.Cells["ExecStatus"].Value.ToString(), out eCode);
                        if (result == 0 && eCode == 0)
                            StartTaskTpwd(row);
                    })).BeginInvoke(null, null);
                }
            }
        }
        /// <summary>
        /// 启动任务计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartTask_Click(object sender, EventArgs e)
        {
            bool isOK = false;
            if (MyUserInfo.sendmode == 1)
            {
                if (hotForm.wxlogin == null)
                {
                    MessageConfirm confirm = new MessageConfirm("您还没有微信授权，是否马上微信授权?");
                    confirm.CallBack += () =>
                    {
                        isOK = true;
                    };
                    confirm.ShowDialog(this);
                    if (isOK)
                    {
                        hotForm.wxlogin = new wxLogin(hotForm, this);
                        hotForm.wxlogin.ShowDialog(this);
                    }
                }
                else
                {
                    if (hotForm.wxlogin.isCloseWinForm)
                        hotForm.wxlogin.ShowWx();
                    else
                    {
                        if (hotForm.wxlogin.isStartTask)
                        {
                            hotForm.wxlogin.StopWx();
                            ShowStartButtonText("启动计划");
                        }
                        else
                        {
                            hotForm.wxlogin.StartWx();
                            ShowStartButtonText("暂停计划");
                        }
                    }

                }
            }
            else
            {
                if (hotForm.winTask == null)
                {

                    MessageConfirm confirm = new MessageConfirm("是否开始执行任务?");
                    confirm.CallBack += () =>
                    {
                        isOK = true;
                    };
                    confirm.ShowDialog(this);
                    if (isOK)
                    {
                        hotForm.winTask = new StartTask(hotForm, this);
                        hotForm.winTask.OK();
                    }
                }
                else
                {
                    hotForm.winTask.isStartTask = false;
                    hotForm.winTask.Close();
                    hotForm.winTask = null;
                    ShowStartButtonText("启动计划");
                }
            }
        }

        public void ShowStartButtonText(string text)
        {
            if (btnStartTask.InvokeRequired)
            {
                this.Invoke(new Action<string>(ShowStartButtonText), new object[] { text });
            }
            else
            {
                btnStartTask.Text = text;
            }
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
            bool isOK = false;
            MessageConfirm confirm = new MessageConfirm("请确保任务已经设置了PID");
            confirm.CallBack += () =>
            {
                isOK = true;
            };
            confirm.ShowDialog(this);
            if (!isOK) return;

            DataGridViewRow row = this.dgvTaskPlan.Rows[MouseCurrentRowIndex];
            if (row != null)
            {
                int result = 0, eCode = 0;
                int.TryParse(row.Cells["isTpwd"].Value.ToString(), out result);
                int.TryParse(row.Cells["ExecStatus"].Value.ToString(), out eCode);
                if (eCode == 0)
                {

                    if (result > 0)
                    {
                        MessageConfirm confirm2 = new MessageConfirm("确定重新转链");
                        confirm2.CallBack += () =>
                        {
                            ((Action)(delegate () { StartTaskTpwd(row); })).BeginInvoke(null, null);
                        };
                        confirm2.ShowDialog(this);
                    }
                    else
                        ((Action)(delegate () { StartTaskTpwd(row); })).BeginInvoke(null, null);


                    ShowAlert("正在进行转链，请耐心等待。");
                }
                else
                {
                    ShowAlert("只对未执行的任务进行转链");
                }
            }
        }

        /// <summary>
        /// 开始转链
        /// </summary>
        /// <param name="row"></param>
        private void StartTaskTpwd(DataGridViewRow row)
        {
            int result = 0;
            int.TryParse(row.Cells["taskid"].Value.ToString(), out result);
            row.Cells["TpwdText"].Value = "正在转链";
            if (LogicTaskPlan.Instance.StartTaskTpwd(MyUserInfo.LoginToken, result))
            {
                row.Cells["TpwdText"].Value = "OK";
                row.Cells["isTpwd"].Value = 1;
            }
            else
            {
                row.Cells["TpwdText"].Value = "转链失败";
                row.Cells["isTpwd"].Value = 0;
            }
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
                        LogicHotTao.Instance(MyUserInfo.currentUserId).DeleteUserTaskPlan(taskid);
                        dgvTaskPlan.Rows.Remove(row);
                        //var taskidList = new List<GoodsTaskModel>();
                        //taskidList.Add(new GoodsTaskModel()
                        //{
                        //    id = taskid
                        //});
                        //string taskids = JsonConvert.SerializeObject(taskidList);
                        //if (LogicTaskPlan.Instance.deleteTaskPlan(MyUserInfo.LoginToken, taskids))
                        //{
                        //    dgvTaskPlan.Rows.Remove(row);
                        //}
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

        private void dgvTaskPlan_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCellCollection cells = this.dgvTaskPlan.CurrentRow.Cells;
            if (cells == null) return;

            if (cells["edittask"].ColumnIndex != e.ColumnIndex)
            {
                int eCode = 0;
                int.TryParse(cells["ExecStatus"].Value.ToString(), out eCode);
                if (eCode == 0)
                {
                    BuildShareText build = new BuildShareText(hotForm,this);
                    int result = 0;
                    int.TryParse(cells["taskid"].Value.ToString(), out result);
                    build.taskid = result;
                    build.ShowDialog(this);
                }
            }
        }
    }
}
