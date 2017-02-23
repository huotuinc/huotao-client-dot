using HotTaoCore.Logic;
using HotTaoCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HotTao.Controls
{
    public partial class TaskEdit : Form
    {


        public int taskid { get; set; }

        public string taskTitle { get; set; }

        public string taskStartTime { get; set; }

        public string taskEndTime { get; set; }


        private List<GoodsTaskModel> hotGoodsText { get; set; }
        private List<UserPidTaskModel> hotPidsText { get; set; }

        private Main hotForm { get; set; }
        private TaskControl hotTask { get; set; }
        public TaskEdit(Main main, TaskControl task)
        {
            InitializeComponent();
            hotForm = main;
            hotTask = task;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TaskEdit_Load(object sender, EventArgs e)
        {
            txtTaskTitle.Text = taskTitle;
            txtStartTime.Text = taskStartTime;
            txtEndTime.Text = taskEndTime;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaskTitle.Text))
            {
                txtTaskTitle.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtStartTime.Text))
            {
                txtStartTime.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtEndTime.Text))
            {
                txtEndTime.Focus();
                return;
            }

            string goodsText = JsonConvert.SerializeObject(hotGoodsText);
            string pidsText = JsonConvert.SerializeObject(hotPidsText);
            TaskPlanModel model = new TaskPlanModel()
            {
                userid = hotForm.currentUserId,
                title = txtTaskTitle.Text,
                startTime = Convert.ToDateTime(txtStartTime.Text),
                pidsText = pidsText,
                goodsText = goodsText
            };
            //int taskid = LogicTaskPlan.Instance.addTaskPlan(model);
            //if (taskid > 0)
            //{
            //    hotGoodsText.ForEach(goods =>
            //    {
            //        hotPidsText.ForEach(pids =>
            //        {
            //            LogicTaskPlan.Instance.addTaskGoodsPidLog(new TaskGoodsPidLogModel()
            //            {
            //                userid = hotForm.currentUserId,
            //                taskid = taskid,
            //                goodsid = goods.id,
            //                pid = pids.id,
            //                shareText = ""
            //            });
            //        });
            //    });


            //    hotTask.LoadTaskPlanGridView();
            //    txtTaskTitle.Clear();
            //    MessageAlert alert = new MessageAlert("保存成功");
            //    alert.Show(this);

            //}
        }
    }
}
