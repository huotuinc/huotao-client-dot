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
using Newtonsoft.Json;
using Alimama;

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
            if (MyUserInfo.currentUserId > 0)
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
        /// 加载用户推广位
        /// </summary>
        public void loadUserPidGridView()
        {
            //是否自动添加属性字段
            this.dgvPid.AutoGenerateColumns = false;
            this.dgvPid.Rows.Clear();
            ((Action)(delegate ()
            {
                var pidData = LogicUser.Instance.GetUserWeChatList(MyUserInfo.LoginToken);
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


        public void SetPidView(List<UserWechatListModel> data)
        {
            int i = dgvPid.Rows.Count;
            for (int j = 0; j < data.Count(); j++)
            {
                dgvPid.Rows.Add();
                ++i;
                dgvPid.Rows[i - 1].Cells["shareid"].Value = data[j].id.ToString();
                dgvPid.Rows[i - 1].Cells["sharetitle"].Value = data[j].wechattitle.ToString();
                dgvPid.Rows[i - 1].Cells["pid"].Value = data[j].pid.ToString();
                if (i % 2 == 0)
                    dgvPid.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                else
                    dgvPid.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;

                dgvPid.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                dgvPid.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;
            }
        }

        public void SetPidView(UserWechatListModel model, int CurrentRowIndex)
        {
            if (CurrentRowIndex != -1)
            {
                dgvPid.Rows[CurrentRowIndex].Cells["shareid"].Value = model.id.ToString();
                dgvPid.Rows[CurrentRowIndex].Cells["sharetitle"].Value = model.wechattitle.ToString();
                dgvPid.Rows[CurrentRowIndex].Cells["pid"].Value = model.pid.ToString();
            }
            else
            {
                int i = dgvPid.Rows.Count;
                dgvPid.Rows.Add();
                ++i;
                dgvPid.Rows[i - 1].Cells["shareid"].Value = model.id.ToString();
                dgvPid.Rows[i - 1].Cells["sharetitle"].Value = model.wechattitle.ToString();
                dgvPid.Rows[i - 1].Cells["pid"].Value = model.pid.ToString();
                if (i % 2 == 0)
                    dgvPid.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                else
                    dgvPid.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;
                dgvPid.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                dgvPid.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;
            }
        }


        public void LoadTaskPlanGridView()
        {
            //是否自动添加属性字段
            this.dgvTaskPlan.AutoGenerateColumns = false;
            this.dgvTaskPlan.Rows.Clear();
            ((Action)(delegate ()
            {
                var taskData = LogicTaskPlan.Instance.getTaskPlanList(MyUserInfo.LoginToken);
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
                dgvTaskPlan.Rows[i - 1].Cells["taskEndTime"].Value = taskData[j].endTime.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["taskStatusText"].Value = taskData[j].statusText.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["goodsText"].Value = taskData[j].goodsText.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["pidsText"].Value = taskData[j].pidsText.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["ExecStatus"].Value = taskData[j].status.ToString();
                if (i % 2 == 0)
                    dgvTaskPlan.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                else
                    dgvTaskPlan.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;

                dgvTaskPlan.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                dgvTaskPlan.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;
            }
        }

        public void SetTaskView(TaskPlanModel model, int CurrentRowIndex)
        {
            if (CurrentRowIndex != -1)
            {
                dgvTaskPlan.Rows[CurrentRowIndex].Cells["taskid"].Value = model.id.ToString();
                dgvTaskPlan.Rows[CurrentRowIndex].Cells["taskTitle"].Value = model.title.ToString();
                dgvTaskPlan.Rows[CurrentRowIndex].Cells["taskStartTime"].Value = model.startTime.ToString();
                dgvTaskPlan.Rows[CurrentRowIndex].Cells["taskEndTime"].Value = model.endTime.ToString();
                dgvTaskPlan.Rows[CurrentRowIndex].Cells["taskStatusText"].Value = model.statusText.ToString();
                dgvTaskPlan.Rows[CurrentRowIndex].Cells["goodsText"].Value = model.goodsText.ToString();
                dgvTaskPlan.Rows[CurrentRowIndex].Cells["pidsText"].Value = model.pidsText.ToString();
                dgvTaskPlan.Rows[CurrentRowIndex].Cells["ExecStatus"].Value = model.ExecStatus.ToString();
            }
            else
            {
                int i = dgvTaskPlan.Rows.Count;
                dgvTaskPlan.Rows.Add();
                ++i;
                dgvTaskPlan.Rows[i - 1].Cells["taskid"].Value = model.id.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["taskTitle"].Value = model.title.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["taskStartTime"].Value = model.startTime.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["taskEndTime"].Value = model.endTime.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["taskStatusText"].Value = model.statusText.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["goodsText"].Value = model.goodsText.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["pidsText"].Value = model.pidsText.ToString();
                dgvTaskPlan.Rows[i - 1].Cells["ExecStatus"].Value = model.ExecStatus.ToString();
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
                var data = LogicGoods.Instance.getGoodsList(MyUserInfo.LoginToken);
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
                    //obj.Rows[i - 1].Cells["goodsId"].Value = data[j].goodsId.ToString();
                    //obj.Rows[i - 1].Cells["goodsDetailUrl"].Value = data[j].goodsDetailUrl.ToString();
                    obj.Rows[i - 1].Cells["goodsName"].Value = data[j].goodsName.ToString();
                    obj.Rows[i - 1].Cells["goodsSupplier"].Value = data[j].goodsSupplier.ToString();
                    obj.Rows[i - 1].Cells["goodsPrice"].Value = data[j].goodsPrice.ToString();
                    obj.Rows[i - 1].Cells["goodsSalesAmount"].Value = data[j].goodsSalesAmount.ToString();
                    obj.Rows[i - 1].Cells["goodsComsRate"].Value = data[j].goodsComsRate.ToString();
                    obj.Rows[i - 1].Cells["goodsCommission"].Value = data[j].goodsCommission.ToString();
                    obj.Rows[i - 1].Cells["couponPrice"].Value = data[j].couponPrice.ToString();
                    //obj.Rows[i - 1].Cells["updateTime"].Value = data[j].updateTime.ToString();
                    //obj.Rows[i - 1].Cells["startTime"].Value = data[j].startTime.ToString();
                    //obj.Rows[i - 1].Cells["endTime"].Value = data[j].endTime.ToString();
                    //obj.Rows[i - 1].Cells["createTime"].Value = data[j].createTime.ToString();
                    //obj.Rows[i - 1].Cells["couponUrl"].Value = data[j].couponUrl.ToString();
                    //obj.Rows[i - 1].Cells["shareLink"].Value = data[j].shareLink.ToString();
                    //obj.Rows[i - 1].Cells["goodsMainImgUrl"].Value = data[j].goodsMainImgUrl.ToString();


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
            //if (e.OldValue < e.NewValue && dgvData.RowCount < e.NewValue + 16)
            //{
            //    CurrentShowRowNumber++;
            //    var goodsData = LogicGoods.Instance.getGoodsList(CurrentShowRowNumber, PageRowCount);
            //    if (goodsData != null)
            //    {
            //        //data.AddRange(goodsData);
            //        SetGoodsGridViewData(dgvData, goodsData);
            //    }
            //}
        }

        /// <summary>
        /// 添加/编辑计划任务
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            List<GoodsTaskModel> goodsidList = new List<GoodsTaskModel>();
            //循环获取选中的数据
            foreach (DataGridViewRow item in dgvData.Rows)
            {
                if ((bool)item.Cells[0].EditedFormattedValue == true)
                {
                    int result = 0;
                    int.TryParse(item.Cells["gid"].Value.ToString(), out result);
                    if (result > 0 && goodsidList.FindIndex(r => { return r.id == result; }) < 0)
                        goodsidList.Add(new GoodsTaskModel() { id = result });
                }
            }
            List<UserPidTaskModel> pidList = new List<UserPidTaskModel>();
            foreach (DataGridViewRow item in dgvPid.Rows)
            {
                if ((bool)item.Cells[0].EditedFormattedValue == true)
                {
                    int result = 0;
                    int.TryParse(item.Cells["shareid"].Value.ToString(), out result);
                    if (result > 0 && pidList.FindIndex(r => { return r.id == result; }) < 0)
                        pidList.Add(new UserPidTaskModel() { id = result });
                }
            }
            if (pidList.Count() == 0)
            {
                ShowAlert("请先选择微信群");
                return;
            }
            if (goodsidList.Count() == 0)
            {
                ShowAlert("请先添加商品");
                return;
            }

            TaskEdit te = new TaskEdit(hotForm, this);
            te.hotGoodsText = goodsidList;
            te.hotPidsText = pidList;
            te.Title = "添加任务计划";
            te.ShowDialog(this);
        }

        /// <summary>
        /// 删除计划
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolTaskDel_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dgvTaskPlan.Rows[MouseCurrentRowIndex];
            if (row != null)
            {
                int taskid = Convert.ToInt32(row.Cells["taskid"].Value);
                int eCode = 0;
                int.TryParse(row.Cells["ExecStatus"].Value.ToString(), out eCode);
                if (eCode != 2)
                {
                    MessageConfirm confirm = new MessageConfirm("您确认要删除计划【" + taskid + "】吗？");
                    confirm.CallBack += () =>
                    {
                        var taskidList = new List<GoodsTaskModel>();
                        taskidList.Add(new GoodsTaskModel()
                        {
                            id = taskid
                        });
                        string taskids = JsonConvert.SerializeObject(taskidList);
                        dgvTaskPlan.Rows.Remove(row);
                        ((Action)(delegate ()
                        {
                            LogicTaskPlan.Instance.deleteTaskPlan(MyUserInfo.LoginToken, taskids);
                        })).BeginInvoke(null, null);

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
                    if (ckbWeChatAllSelected.Checked)
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
            }
        }
        /// <summary>
        /// 添加/编辑微信群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnAddWeChatGroup_Click(object sender, EventArgs e)
        {
            AddWeChat add = new AddWeChat(hotForm, this);
            add.Title = "添加微信群";
            add.ShowDialog(this);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolWeChatDel_Click(object sender, EventArgs e)
        {
            List<UserPidTaskModel> pidList = new List<UserPidTaskModel>();
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewRow item in dgvPid.Rows)
            {
                if ((bool)item.Cells[0].EditedFormattedValue == true)
                {
                    int result = 0;
                    int.TryParse(item.Cells["shareid"].Value.ToString(), out result);
                    if (result > 0 && pidList.FindIndex(r => { return r.id == result; }) < 0)
                    {
                        pidList.Add(new UserPidTaskModel() { id = result });
                        rows.Add(item);
                    }
                }
            }
            if (pidList != null && pidList.Count() > 0)
            {
                MessageConfirm confirm = new MessageConfirm();
                confirm.Message = "您确定要删除勾选的微信群吗";
                confirm.CallBack += () =>
                {
                    Loading ld = new Loading();
                    string ids = JsonConvert.SerializeObject(pidList);
                    ((Action)(delegate ()
                    {
                        if (LogicUser.Instance.DeleteUserWeChat(MyUserInfo.LoginToken, ids))
                        {
                            this.BeginInvoke((Action)(delegate ()
                            {
                                loadUserPidGridView();
                            }));
                        }
                        ld.CloseForm();
                    })).BeginInvoke(null, null);
                    ld.ShowDialog(hotForm);

                };
                confirm.ShowDialog(this);
            }
            else
            {
                DataGridViewRow row = this.dgvPid.Rows[MouseCurrentRowIndex];
                if (row != null)
                {
                    int result = 0;
                    int.TryParse(row.Cells["shareid"].Value.ToString(), out result);
                    string sharetitle = row.Cells["sharetitle"].Value.ToString();
                    MessageConfirm confirm = new MessageConfirm("您确定要删除【" + sharetitle + "】？");
                    confirm.CallBack += () =>
                    {
                        pidList.Add(new UserPidTaskModel() { id = result });
                        string ids = JsonConvert.SerializeObject(pidList);
                        this.dgvPid.Rows.Remove(row);
                        ((Action)(delegate ()
                        {
                            LogicUser.Instance.DeleteUserWeChat(MyUserInfo.LoginToken, ids);
                        })).BeginInvoke(null, null);



                    };
                    confirm.ShowDialog(this);
                }
                else
                    ShowAlert("请先选择要删除的数据行!");
            }

        }

        /// <summary>
        /// 修改任务计划
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void dgvTaskPlan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection cells = this.dgvTaskPlan.CurrentRow.Cells;
            if (cells != null && cells["edittask"].ColumnIndex == e.ColumnIndex)
            {
                UpdateTask(cells, cells["edittask"].RowIndex);
            }

        }

        private void toolTaskUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewCellCollection cells = this.dgvTaskPlan.Rows[MouseCurrentRowIndex].Cells;
            if (cells != null)
            {
                UpdateTask(cells, MouseCurrentRowIndex);
            }
        }

        private void UpdateTask(DataGridViewCellCollection cells, int rowIndex)
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
                te.CurrentRowIndex = rowIndex;
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
                DataGridViewCellCollection cells = this.dgvData.CurrentRow.Cells;
                int deleteId = 0;
                int.TryParse(cells["gid"].Value.ToString(), out deleteId);
                MessageConfirm confirm = new MessageConfirm();
                confirm.Message = "确认要删除该商品吗";
                confirm.CallBack += () =>
                {
                    ((Action)(delegate ()
                    {
                        LogicGoods.Instance.DeleteGoods(MyUserInfo.LoginToken, deleteId);
                    })).BeginInvoke(null, null);

                    this.dgvData.Rows.RemoveAt(cell.RowIndex);
                    ShowAlert("删除成功");
                };
                confirm.ShowDialog(this);
            }
        }

        /// <summary>
        /// 采集微信聊天窗口
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnWeChatWinGet_Click(object sender, EventArgs e)
        {
            MessageConfirm confirm = new MessageConfirm();
            confirm.Message = "请确保采集的群聊都单独拖出来";
            confirm.CallBack += GetWeChatWinHandler;
            confirm.ShowDialog(this);
        }
        /// <summary>
        /// 采集微信聊天窗口
        /// </summary>
        private void GetWeChatWinHandler()
        {
            var wins = WinApi.GetAllDesktopWindows();
            if (wins != null && wins.Count() > 0)
            {
                Loading ld = new Loading();
                ((Action)(delegate ()
                {
                    foreach (var win in wins)
                    {
                        LogicUser.Instance.UpdateUserWeChatTitle(MyUserInfo.LoginToken, 0, win.szWindowName);
                        this.BeginInvoke((Action)(delegate ()
                        {
                            ShowAlert("采集完成");
                        }));
                    }
                    ld.CloseForm();
                })).BeginInvoke(null, null);
                ld.ShowDialog(hotForm);
            }
            else
            {
                ShowAlert("微信初始化失败");
            }
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAddGoods_Click(object sender, EventArgs e)
        {
            hotForm.openControl(new GoodsControl(hotForm));
        }


        private void ShowAlert(string Message)
        {
            MessageAlert alert = new MessageAlert();
            alert.Message = Message;
            alert.ShowDialog(this);
        }

        /// <summary>
        /// 修改微信群
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void dgvPid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = this.dgvPid.CurrentRow.Cells["editwechat"];
            if (cell != null && cell.ColumnIndex == e.ColumnIndex)
            {
                AddWeChat add = new AddWeChat(hotForm, this);
                add.Title = "修改微信群";
                add.CurrentRowIndex = cell.RowIndex;
                int result = 0;
                int.TryParse(this.dgvPid.CurrentRow.Cells["shareid"].Value.ToString(), out result);
                add.editId = result;
                add.weChatTitle = this.dgvPid.CurrentRow.Cells["sharetitle"].Value.ToString();
                add.ShowDialog(this);
            }
        }

        /// <summary>
        /// 全选任务计划
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ckbAllSelectedTask_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvPid.Rows != null && dgvTaskPlan.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvTaskPlan.Rows)
                {
                    int result = 0;
                    int.TryParse(row.Cells["taskid"].Value.ToString(), out result);
                    if (ckbAllSelectedTask.Checked)
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
            }
        }
        /// <summary>
        /// 修改微信群
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolWeChatUpdate_Click(object sender, EventArgs e)
        {
            if (this.dgvPid.Rows.Count > MouseCurrentRowIndex)
            {
                DataGridViewCellCollection row = this.dgvPid.Rows[MouseCurrentRowIndex].Cells;
                if (row != null)
                {
                    AddWeChat add = new AddWeChat(hotForm, this);
                    int result = 0;
                    int.TryParse(row["shareid"].Value.ToString(), out result);
                    add.editId = result;
                    add.Title = "修改微信群";
                    add.CurrentRowIndex = MouseCurrentRowIndex;
                    add.weChatTitle = row["sharetitle"].Value.ToString();
                    add.ShowDialog(this);
                }
                else
                {
                    ShowAlert("请先选择要修改的数据行");
                }
            }
        }
        private int MouseCurrentRowIndex = 0;

        private void toolWeChatSetPid_Click(object sender, EventArgs e)
        {
            if (MyUserInfo.currentUserId == 0) return;

            if (!string.IsNullOrEmpty(MyUserInfo.TaobaoName))
            {
                if (this.dgvPid.Rows.Count > MouseCurrentRowIndex)
                {
                    DataGridViewCell cell = this.dgvPid.Rows[MouseCurrentRowIndex].Cells["shareid"];
                    if (cell != null)
                    {
                        int WeChatId = 0;
                        int.TryParse(cell.Value.ToString(), out WeChatId);
                        UserPIDControl userPid = new UserPIDControl(hotForm, this);
                        userPid.Title = "设置PID";
                        userPid.WeChatId = WeChatId;
                        userPid.CurrentRowIndex = cell.RowIndex;
                        userPid.ShowDialog(this);
                    }
                }
            }
            else
            {
                ShowAlert("请先登录淘宝账号");
            }
        }


        /// <summary>
        /// 设置微信群数据
        /// </summary>
        /// <param name="rowIndex">行索引</param>
        /// <param name="columnName">列名称</param>
        /// <param name="value">值</param>
        public void SetWeChatRowData(int rowIndex, string columnName, string value)
        {
            if (this.dgvPid.Rows.Count > rowIndex)
            {
                dgvPid.Rows[rowIndex].Cells[columnName].Value = value;
                ShowAlert("设置成功");
            }
            else
                ShowAlert("设置失败");
        }

        private void dgvPid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            MouseCurrentRowIndex = e.RowIndex;
        }

        private void dgvTaskPlan_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            MouseCurrentRowIndex = e.RowIndex;
        }
    }
}
