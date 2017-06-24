using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HotTaoCore.Logic;
using HotTaoCore.Models;
using System.Threading;
using Newtonsoft.Json;
using HotTaoCore;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Net;
using HOTReuestService;

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

        /// <summary>
        /// 自动刷新任务数据
        /// </summary>
       // System.Windows.Forms.Timer autoRefreshTask;


        private void HomeControl_Load(object sender, EventArgs e)
        {
            if (MyUserInfo.currentUserId > 0)
            {
                                
               // HotJavaApi.SendUserNotice(MyUserInfo.LoginToken, WeChatTemplateMessageSceneType.群异常,"tesdt");               

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


                CurrentShowRowNumber = 1;
                LoadGoodsGridView();
                loadUserPidGridView();
                LoadTaskPlanGridView();

                //if (autoRefreshTask == null)
                //    autoRefreshTask = new System.Windows.Forms.Timer();

                //autoRefreshTask.Interval = 1000 * 60;
                //autoRefreshTask.Tick += AutoRefreshTask_Tick;
                //autoRefreshTask.Start();

            }
            else
                hotForm.openControl(new LoginControl(hotForm));

            //hotForm.worker.RunWorkerAsync("http://www.dataoke.com");
        }

        /// <summary>
        /// 自动刷新任务数据
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="NotImplementedException"></exception>
        private void AutoRefreshTask_Tick(object sender, EventArgs e)
        {
            LoadTaskPlanGridView();
        }
        /// <summary>
        /// 加载用户推广位
        /// </summary>
        public void loadUserPidGridView()
        {

            new Thread(() =>
           {
               //是否自动添加属性字段
               this.dgvPid.AutoGenerateColumns = false;

               var pidData = LogicHotTao.Instance(MyUserInfo.currentUserId).GetUserWeChatGroupListByUserId(MyUserInfo.currentUserId);
               if (pidData != null)
               {
                   hotForm.weChatGroups = pidData;
                   SetPidView(pidData);
                   if (this.dgvPid.Rows.Count > 0)
                   {
                       dgvPid.Rows[0].Selected = false;
                       dgvPid.ContextMenuStrip = cmsWeChatMenu;
                   }
               }
           })
            { IsBackground = true }.Start();

        }


        public void SetPidView(List<UserWechatListModel> data)
        {
            if (dgvPid.InvokeRequired)
            {
                this.Invoke(new Action<List<UserWechatListModel>>(SetPidView), new object[] { data });
            }
            else
            {
                this.dgvPid.Rows.Clear();
                int i = dgvPid.Rows.Count;
                for (int j = 0; j < data.Count(); j++)
                {
                    dgvPid.Rows.Add();
                    ++i;

                    dgvPid.Rows[i - 1].Cells["groupindex"].Value = i.ToString();
                    dgvPid.Rows[i - 1].Cells["shareid"].Value = data[j].id.ToString();
                    dgvPid.Rows[i - 1].Cells["sharetitle"].Value = data[j].wechattitle.ToString();
                    dgvPid.Rows[i - 1].Cells["pid"].Value = data[j].pid.ToString();

                    if (i % 2 == 0)
                    {
                        dgvPid.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                        dgvPid.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewEvenRowBackColor;
                    }
                    else
                    {
                        dgvPid.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;
                        dgvPid.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewOddRowBackColor;
                    }


                    dgvPid.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                    dgvPid.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;
                }
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
                dgvPid.Rows[i - 1].Cells["groupindex"].Value = i.ToString();
                dgvPid.Rows[i - 1].Cells["shareid"].Value = model.id.ToString();
                dgvPid.Rows[i - 1].Cells["sharetitle"].Value = model.wechattitle.ToString();
                dgvPid.Rows[i - 1].Cells["pid"].Value = model.pid.ToString();
                if (i % 2 == 0)
                {
                    dgvPid.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                    dgvPid.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewEvenRowBackColor;
                }
                else
                {
                    dgvPid.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;
                    dgvPid.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewOddRowBackColor;
                }


                dgvPid.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                dgvPid.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;
            }
        }


        public void LoadTaskPlanGridView()
        {
            new Thread(() =>
            {
                //是否自动添加属性字段
                this.dgvTaskPlan.AutoGenerateColumns = false;
                //var data = LogicGoods.Instance.getGoodsList(MyUserInfo.LoginToken);
                var taskData = LogicHotTao.Instance(MyUserInfo.currentUserId).FindUserTaskPlanListByUserId(MyUserInfo.currentUserId, true);
                if (taskData != null)
                {
                    SetTaskView(taskData);
                    if (this.dgvTaskPlan.Rows.Count > 0)
                    {
                        dgvTaskPlan.Rows[0].Selected = false;
                        dgvTaskPlan.ContextMenuStrip = cmsTaskMeun;
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

                this.dgvTaskPlan.Rows.Clear();
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
                dgvTaskPlan.ContextMenuStrip = cmsTaskMeun;
            }
        }



        /// <summary>
        /// 加载商品数据
        /// </summary>
        public void LoadGoodsGridView()
        {
            new Thread(() =>
            {
                //是否自动添加属性字段
                this.dgvData.AutoGenerateColumns = false;
                var data = LogicHotTao.Instance(MyUserInfo.currentUserId).FindByUserGoodsList(MyUserInfo.currentUserId);
                if (data != null)
                {
                    SetGoodsGridViewData(dgvData, data);
                    if (this.dgvData.Rows.Count > 0)
                    {
                        dgvData.Rows[0].Selected = false;
                        dgvData.ContextMenuStrip = cmsGoodsMenu;
                    }
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
                    obj.Rows[i - 1].Cells["rowIndex"].Value = i;
                    obj.Rows[i - 1].Cells["gid"].Value = data[j].id.ToString();
                    obj.Rows[i - 1].Cells["goodsName"].Value = data[j].goodsName.ToString();
                    obj.Rows[i - 1].Cells["goodsSupplier"].Value = data[j].goodsSupplier.ToString();
                    obj.Rows[i - 1].Cells["goodsPrice"].Value = data[j].goodsPrice.ToString();
                    obj.Rows[i - 1].Cells["goodsSalesAmount"].Value = data[j].goodsSalesAmount.ToString();
                    obj.Rows[i - 1].Cells["goodsComsRate"].Value = data[j].goodsComsRate.ToString();
                    obj.Rows[i - 1].Cells["couponPrice"].Value = data[j].couponPrice.ToString();
                    obj.Rows[i - 1].Cells["couponId"].Value = data[j].couponId;
                    obj.Rows[i - 1].Cells["goodsId"].Value = data[j].goodsId;
                    obj.Rows[i - 1].Cells["updateTime"].Value = data[j].updateTime.ToString();

                    if (i % 2 == 0)
                    {
                        obj.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                        obj.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewEvenRowBackColor;
                    }
                    else
                    {
                        obj.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;
                        obj.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewOddRowBackColor;
                    }
                    obj.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                    obj.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;

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
                if (eCode != 1)
                {
                    MessageConfirm confirm = new MessageConfirm("您确认要删除计划【" + taskid + "】吗？");
                    confirm.CallBack += () =>
                    {
                        if (LogicHotTao.Instance(MyUserInfo.currentUserId).DeleteUserTaskPlan(taskid))
                        {
                            LogicHotTao.Instance(MyUserInfo.currentUserId).DeleteShareText(taskid);
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
            List<int> ids = new List<int>();
            List<string> titles = new List<string>();
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
                        ids.Add(result);
                        rows.Add(item);
                    }
                    string text = item.Cells["sharetitle"].Value.ToString();
                    if (!string.IsNullOrEmpty(text) && !titles.Contains(text))
                    {
                        titles.Add(text);
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
                    string idsStr = JsonConvert.SerializeObject(pidList);
                    ((Action)(delegate ()
                    {
                        if (LogicHotTao.Instance(MyUserInfo.currentUserId).DeleteUserWeChatGroup(ids))
                        {
                            //TODO:待优化
                            foreach (var title in titles)
                            {
                                //删除微信群的分享内容
                                LogicHotTao.Instance(MyUserInfo.currentUserId).DeleteWeChatShareText(title);
                            }
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
                        ids.Add(result);
                        string idsStr = JsonConvert.SerializeObject(pidList);
                        this.dgvPid.Rows.Remove(row);
                        ((Action)(delegate ()
                        {
                            if (LogicHotTao.Instance(MyUserInfo.currentUserId).DeleteUserWeChatGroup(ids))
                                LogicHotTao.Instance(MyUserInfo.currentUserId).DeleteWeChatShareText(sharetitle);
                        })).BeginInvoke(null, null);



                    };
                    confirm.ShowDialog(this);
                }
                else
                    ShowAlert("请先选择要删除的数据行!");
            }

        }

        public bool TaskPlanSelected = false;
        /// <summary>
        /// 修改任务计划
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void dgvTaskPlan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection cells = this.dgvTaskPlan.CurrentRow.Cells;

            if (cells == null) return;

            if (!TaskPlanSelected)
                TaskPlanSelected = true;
            else
            {
                TaskPlanSelected = false;
                cells[0].Selected = TaskPlanSelected;
            }
            SetPIDGridViewSelected(TaskPlanSelected);
            SetGoodsGridViewSelected(TaskPlanSelected);

            if (cells["edittask"].ColumnIndex == e.ColumnIndex)
            {
                UpdateTask(cells, cells["edittask"].RowIndex);
            }


        }

        /// <summary>
        /// 设置商品数据默认选中
        /// </summary>
        public void SetGoodsGridViewSelected(bool isSelected)
        {
            //判断任务计划数据是否为空
            if (this.dgvTaskPlan.Rows != null && this.dgvTaskPlan.Rows.Count > 0)
            {
                //获取当前选择行数据
                DataGridViewCellCollection currentRow = this.dgvTaskPlan.CurrentRow.Cells;
                if (currentRow != null)
                {
                    //设置推广商品和推广位为未选中状态
                    foreach (DataGridViewRow row in dgvData.Rows)
                    {
                        row.Cells[0].Value = 0;
                        row.Selected = false;
                    }
                    if (isSelected)
                    {
                        //根据任务计划之前的选择，将商品和推广位设为选中状态
                        string goodsText = currentRow["goodsText"].Value.ToString();
                        if (!string.IsNullOrEmpty(goodsText))
                        {
                            List<GoodsTaskModel> goodsIds = JsonConvert.DeserializeObject<List<GoodsTaskModel>>(goodsText);
                            goodsIds.ForEach(item =>
                            {
                                foreach (DataGridViewRow row in dgvData.Rows)
                                {
                                    int result = 0;
                                    int.TryParse(row.Cells["gid"].Value.ToString(), out result);
                                    if (result == item.id)
                                    {
                                        row.Cells[0].Value = result;
                                        row.Selected = true;
                                    }
                                }
                            });
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 设置pid数据默认选中
        /// </summary>
        public void SetPIDGridViewSelected(bool isSelected)
        {
            //判断任务计划数据是否为空
            if (this.dgvPid.Rows != null && this.dgvPid.Rows.Count > 0)
            {
                //获取当前选择行数据
                DataGridViewCellCollection currentRow = this.dgvTaskPlan.CurrentRow.Cells;
                if (currentRow != null)
                {
                    foreach (DataGridViewRow row in dgvPid.Rows)
                    {
                        row.Cells[0].Value = 0;
                        row.Selected = false;
                    }
                    if (isSelected)
                    {
                        //根据任务计划之前的选择，将商品和推广位设为选中状态
                        string pidsText = currentRow["pidsText"].Value.ToString();
                        if (!string.IsNullOrEmpty(pidsText))
                        {
                            List<UserPidTaskModel> pIds = JsonConvert.DeserializeObject<List<UserPidTaskModel>>(pidsText);
                            pIds.ForEach(item =>
                            {
                                foreach (DataGridViewRow row in dgvPid.Rows)
                                {
                                    int result = 0;
                                    int.TryParse(row.Cells["shareid"].Value.ToString(), out result);
                                    if (result == item.id)
                                    {
                                        row.Cells[0].Value = result;
                                        row.Selected = true;
                                    }
                                }
                            });
                        }
                    }
                }
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
        /// 商品操作
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //
            DataGridViewCellCollection cells = this.dgvData.CurrentRow.Cells;
            if (cells != null && cells["editgoods"].ColumnIndex == e.ColumnIndex)
            {
                int deleteId = 0;
                int.TryParse(cells["gid"].Value.ToString(), out deleteId);
                MessageConfirm confirm = new MessageConfirm();
                confirm.Message = "确认要删除该商品吗";
                confirm.CallBack += () =>
                {
                    ((Action)(delegate ()
                    {
                        LogicHotTao.Instance(MyUserInfo.currentUserId).DeleteGoods(deleteId);
                    })).BeginInvoke(null, null);

                    this.dgvData.Rows.RemoveAt(cells[0].RowIndex);

                };
                confirm.ShowDialog(this);
            }
            //验券
            else if (cells != null && cells["shareLink"].ColumnIndex == e.ColumnIndex)
            {
                string url = GlobalConfig.couponUrl;
                url += "?src=ht_hot&activityId=" + cells["couponId"].Value;
                url += "&itemId=" + cells["goodsId"].Value.ToString().Replace("=", "");
                url += "&pid=mm_33648229_22032774_73500078";
                Process.Start(url);
            }
            //插入视频
            else if (cells != null && cells["insertVideo"].ColumnIndex == e.ColumnIndex)
            {
                int gid = 0;
                int.TryParse(cells["gid"].Value.ToString(), out gid);
                string itemId = cells["goodsId"].Value.ToString().Replace("=", "");

                InsertVideo video = new InsertVideo(hotForm);
                video.itemId = itemId;
                video.gid = gid;
                video.ShowDialog(this);
            }
            else  //点击单元格选中商品
            {
                if (this.dgvData.Rows.Count > 0)
                {
                    DataGridViewCellCollection row = this.dgvData.Rows[e.RowIndex].Cells;
                    if (row != null)
                    {
                        int result = 0;
                        if (!(bool)row[0].EditedFormattedValue == true)
                            int.TryParse(row["gid"].Value.ToString(), out result);
                        if (result > 0)
                            this.dgvData.Rows[e.RowIndex].Cells[0].Value = result;
                    }
                }
            }
        }

        /// <summary>
        /// 采集微信聊天窗口
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnWeChatWinGet_Click(object sender, EventArgs e)
        {
            bool isOk = false;
            MessageConfirm confirm = new MessageConfirm();
            confirm.Message = "请确保采集的群聊都单独拖出来";
            confirm.CallBack += () => { isOk = true; };
            confirm.ShowDialog(this);
            if (isOk)
                GetWeChatWinHandler();
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
                        LogicHotTao.Instance(MyUserInfo.currentUserId).AddUserWeChatGroup(new SQLiteEntitysModel.weChatGroupModel()
                        {
                            title = win.szWindowName,
                            userid = MyUserInfo.currentUserId
                        });
                    }
                    ld.CloseForm();
                    this.BeginInvoke((Action)(delegate ()
                    {
                        loadUserPidGridView();
                        ShowAlert("采集完成");
                    }));
                })).BeginInvoke(null, null);
                ld.ShowDialog(hotForm);
            }
            else
            {
                ShowAlert("未找到微信窗口!");
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
                add.weChatPid = this.dgvPid.CurrentRow.Cells["pid"].Value.ToString();
                add.ShowDialog(this);
            }
            else
            {
                if (this.dgvPid.Rows.Count > 0)
                {
                    DataGridViewCellCollection row = this.dgvPid.Rows[e.RowIndex].Cells;
                    if (row != null)
                    {
                        int result = 0;
                        if (!(bool)row[0].EditedFormattedValue == true)
                            int.TryParse(row["shareid"].Value.ToString(), out result);
                        if (result > 0)
                            this.dgvPid.Rows[e.RowIndex].Cells[0].Value = result;
                    }
                }
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
                    add.weChatPid = row["pid"].Value.ToString();
                    add.ShowDialog(this);
                }
                else
                {
                    ShowAlert("请先选择要修改的数据行");
                }
            }
        }
        private int MouseCurrentRowIndex = 0;

        ///// <summary>
        ///// 淘宝登录成功状态
        ///// </summary>
        //private bool LoginTaobaoSuccess = false;

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
                bool isOK = false;
                MessageConfirm confirm = new MessageConfirm("您还没登录淘宝账号，是否前往登录？");
                confirm.CallBack += () =>
                {
                    isOK = true;
                };
                confirm.ShowDialog(this);
                if (isOK)
                {
                    hotForm.LoginTaoBao();
                }
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

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ckbGoodsAllSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvData.Rows != null && dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    int result = 0;
                    int.TryParse(row.Cells["gid"].Value.ToString(), out result);
                    if (ckbGoodsAllSelected.Checked)
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
        /// 导入本地商品
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnImportLocatGoods_Click(object sender, EventArgs e)
        {
            ImportGoods import = new ImportGoods(this);
            import.ImportType = "goods";
            import.ShowDialog(this);
        }

        /// <summary>
        /// 批量导入PID
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolsBatchImport_Click(object sender, EventArgs e)
        {
            ImportGoods import = new ImportGoods(this);
            import.ImportType = "pid";
            import.ShowDialog(this);
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
                    BuildShareText build = new BuildShareText(hotForm, this);
                    int result = 0;
                    int.TryParse(cells["taskid"].Value.ToString(), out result);
                    build.taskid = result;
                    build.ShowDialog(this);
                }
            }
        }

        /// <summary>
        /// 启动计划
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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


        private void toolsExport_Click(object sender, EventArgs e)
        {
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string filepath = saveFile.FileName;
                var groupData = LogicHotTao.Instance(MyUserInfo.currentUserId).GetUserWeChatGroupListByUserId(MyUserInfo.currentUserId);
                if (groupData != null && groupData.Count() > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("昵称", typeof(string));
                    dt.Columns.Add("PID", typeof(string));
                    DataRow newRow;
                    foreach (var item in groupData)
                    {
                        newRow = dt.NewRow();
                        newRow[0] = item.wechattitle;
                        newRow[1] = item.pid;
                        dt.Rows.Add(newRow);
                    }

                    ExcelHelper.ExportDT(dt, filepath);
                    ShowAlert("数据导出成功!");
                }
            }
        }

        /// <summary>
        /// 一键清空我的商品
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClearAllGoods_Click(object sender, EventArgs e)
        {
            bool isOK = false;
            MessageConfirm confirm = new MessageConfirm("您确定要清空我的商品数据？");
            confirm.CallBack += () =>
            {
                isOK = true;
            };
            confirm.ShowDialog(this);
            if (isOK)
            {
                bool flag = LogicHotTao.Instance(MyUserInfo.currentUserId).DeleteAllGoods(MyUserInfo.currentUserId);
                if (flag)
                {
                    LoadTaskPlanGridView();
                    LoadGoodsGridView();
                }
            }
        }

        /// <summary>
        /// 删除选中的商品数据
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolsDeleteSelectedGoods_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewRow item in dgvData.Rows)
            {
                if ((bool)item.Cells[0].EditedFormattedValue == true)
                {
                    int result = 0;
                    int.TryParse(item.Cells["gid"].Value.ToString(), out result);
                    if (result > 0 && !ids.Contains(result))
                    {
                        ids.Add(result);
                        rows.Add(item);
                    }
                }
            }
            if (ids.Count() > 0)
            {
                bool isOk = false;
                MessageConfirm confirm = new MessageConfirm();
                confirm.Message = "您确定要删除勾选的商品数据？";
                confirm.CallBack += () =>
                {
                    isOk = true;
                };
                confirm.ShowDialog(this);
                if (isOk)
                {
                    bool flag = LogicHotTao.Instance(MyUserInfo.currentUserId).DeleteAllGoods(MyUserInfo.currentUserId, ids);
                    if (flag)
                    {
                        int c = rows.Count();
                        for (int i = c - 1; i >= 0; i--)
                        {
                            this.dgvData.Rows.Remove(rows[i]);
                        }
                    }
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //ProcessStartInfo startInfo = new ProcessStartInfo("TBSync.exe", string.Format("{0} {1}", MyUserInfo.LoginToken, MyUserInfo.currentUserId));
            //startInfo.WindowStyle = ProcessWindowStyle.Minimized;
            //Process.Start(startInfo);

        }

        private void toolsExportGoods_Click(object sender, EventArgs e)
        {
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string filepath = saveFile.FileName;
                var goodsData = LogicHotTao.Instance(MyUserInfo.currentUserId).FindByUserGoodsList(MyUserInfo.currentUserId);
                if (goodsData != null && goodsData.Count() > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("商品id", typeof(string));
                    dt.Columns.Add("商品名称", typeof(string));
                    dt.Columns.Add("商品简介", typeof(string));
                    dt.Columns.Add("商品主图", typeof(string));
                    dt.Columns.Add("商品详情页链接地址", typeof(string));
                    dt.Columns.Add("商品价格", typeof(string));
                    dt.Columns.Add("商品月销量", typeof(string));
                    dt.Columns.Add("收入比率(%)", typeof(string));
                    dt.Columns.Add("卖家id", typeof(string));
                    dt.Columns.Add("平台类型", typeof(string));
                    dt.Columns.Add("优惠券id", typeof(string));
                    dt.Columns.Add("优惠券总量", typeof(string));
                    dt.Columns.Add("优惠券剩余量", typeof(string));
                    dt.Columns.Add("优惠券面额(单位元)", typeof(string));
                    dt.Columns.Add("优惠券结束时间", typeof(string));
                    dt.Columns.Add("优惠券链接", typeof(string));
                    DataRow newRow;
                    foreach (var item in goodsData)
                    {
                        newRow = dt.NewRow();
                        newRow["商品id"] = item.goodsId.ToString();
                        newRow["商品名称"] = item.goodsName.ToString();
                        newRow["商品简介"] = item.goodsIntro.ToString();
                        newRow["商品主图"] = item.goodsMainImgUrl.ToString();
                        newRow["商品详情页链接地址"] = item.goodsDetailUrl.ToString();
                        newRow["商品价格"] = item.goodsPrice.ToString();
                        newRow["商品月销量"] = item.goodsSalesAmount.ToString();
                        newRow["收入比率(%)"] = item.goodsComsRate.ToString();
                        newRow["卖家id"] = "";
                        newRow["优惠券总量"] = "";
                        newRow["优惠券剩余量"] = "";
                        newRow["平台类型"] = item.goodsSupplier.ToString();
                        newRow["优惠券id"] = item.couponId.ToString();
                        newRow["优惠券面额(单位元)"] = item.couponPrice.ToString();
                        newRow["优惠券结束时间"] = item.endTime.ToString();
                        newRow["优惠券链接"] = item.couponUrl.ToString();
                        dt.Rows.Add(newRow);
                    }

                    ExcelHelper.ExportDT(dt, filepath);
                    ShowAlert("数据导出成功!");
                }
            }
        }

        /// <summary>
        /// 网址采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoodsCollect_Click(object sender, EventArgs e)
        {
            GoodsCollect collect = new GoodsCollect(this, hotForm);
            collect.StartPosition = FormStartPosition.CenterParent;
            collect.ShowDialog(this);
        }
    }
}
