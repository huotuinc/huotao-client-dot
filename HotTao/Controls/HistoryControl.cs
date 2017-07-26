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
using System.Diagnostics;
using System.Web;

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
                LoadLogGridView();
            }
            else
                hotForm.openControl(new LoginControl(hotForm));

        }

        private System.Windows.Forms.Timer timingRefresh { get; set; }

        /// <summary>
        /// 加载日志数据
        /// </summary>
        public void LoadLogGridView()
        {
            new Thread(() =>
            {
                //是否自动添加属性字段
                this.dgvLogView.AutoGenerateColumns = false;
                if (hotForm.logRuningList != null && hotForm.logRuningList.Count() > 0)
                    SetLogView(hotForm.logRuningList);

            })
            { IsBackground = true }.Start();

            //if (timingRefresh != null)
            //{
            //    timingRefresh.Stop();
            //    timingRefresh.Dispose();
            //    timingRefresh = null;
            //}
            //timingRefresh = new System.Windows.Forms.Timer();
            //timingRefresh.Interval = 10000;
            //timingRefresh.Tick += TimingRefresh_Tick;
            //timingRefresh.Start();
        }

        //private void TimingRefresh_Tick(object sender, EventArgs e)
        //{
        //    if (hotForm.logRuningList != null && hotForm.logRuningList.Count() > 0)
        //        SetLogView(hotForm.logRuningList);
        //}

        private void SetLogView(List<LogRuningModel> data)
        {
            if (dgvLogView.InvokeRequired)
            {
                this.Invoke(new Action<List<LogRuningModel>>(SetLogView), new object[] { data });
            }
            else
            {
                dgvLogView.Rows.Clear();
                int i = dgvLogView.Rows.Count;
                for (int j = 0; j < data.Count(); j++)
                {
                    dgvLogView.Rows.Add();
                    ++i;
                    dgvLogView.Rows[i - 1].Cells["logId"].Value = i;
                    dgvLogView.Rows[i - 1].Cells["logType"].Value = data[j].logType.ToString();
                    dgvLogView.Rows[i - 1].Cells["logContent"].Value = data[j].remark;
                    dgvLogView.Rows[i - 1].Cells["logStatus"].Value = data[j].isError ? "失败" : "成功";
                    dgvLogView.Rows[i - 1].Cells["logTime"].Value = data[j].logTime.ToString("yyyy-MM-dd HH:mm:ss");
                    dgvLogView.Rows[i - 1].Cells["goodsid"].Value = data[j].goodsid;
                    dgvLogView.Rows[i - 1].Cells["goodsName"].Value = data[j].goodsName;

                    dgvLogView.Rows[i - 1].Cells["campId"].Value = data[j].campId;
                    dgvLogView.Rows[i - 1].Cells["keeperid"].Value = data[j].keeperid;
                    dgvLogView.Rows[i - 1].Cells["commissionRate"].Value = data[j].commissionRate;
                    dgvLogView.Rows[i - 1].Cells["goodsUrl"].Value = data[j].goodsUrl;

                    if (i % 2 == 0)
                    {
                        dgvLogView.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                        dgvLogView.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewEvenRowBackColor;
                    }
                    else
                    {
                        dgvLogView.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;
                        dgvLogView.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewOddRowBackColor;
                    }
                    dgvLogView.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                    dgvLogView.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;
                    dgvLogView.Rows[i - 1].DefaultCellStyle.NullValue = "查看商品";// data[j].isError && data[j].logType == HotTaoCore.Enums.LogTypeOpts.申请高佣 ? "查看商品" : "";
                }

                dgvLogView.CurrentCell = dgvLogView.Rows[dgvLogView.Rows.Count - 1].Cells[dgvLogView.CurrentCell.ColumnIndex];
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


        public void ShowStartButtonText(string text)
        {

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
                    BuildShareText build = new BuildShareText(hotForm, this);
                    int result = 0;
                    int.TryParse(cells["taskid"].Value.ToString(), out result);
                    build.taskid = result;
                    build.ShowDialog(this);
                }
            }
        }
        /// <summary>
        /// 重新申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvLogView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection cells = this.dgvLogView.CurrentRow.Cells;
            if (cells != null && cells["operation"].ColumnIndex == e.ColumnIndex)
            {
                string goodsid = cells["goodsid"].Value.ToString();
                string goodsName = cells["goodsName"].Value.ToString();
                string goodsUrl = cells["goodsUrl"].Value.ToString();
                string url = string.Format("http://pub.alimama.com/promo/search/index.htm?q={0}&_t=1500628600631&toPage=1&yxjh=-1", HttpUtility.UrlEncode(goodsUrl));
                Process.Start(url);
            }
        }

        private void toolClearAll_Click(object sender, EventArgs e)
        {
            hotForm.logRuningList.Clear();
            dgvLogView.Rows.Clear();
        }
    }
}
