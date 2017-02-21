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

namespace HotTao.Controls
{
    public partial class HistoryControl : UserControl
    {
        private Main hotForm { get; set; }
        public HistoryControl(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }

        private void HistoryControl_Load(object sender, EventArgs e)
        {
            if (hotForm.currentUserId > 0)
                LoadTaskPlanGridView();
            else
                hotForm.openControl(new LoginControl(hotForm));

            dateTimePicker1.Size = new System.Drawing.Size(217, 40);
            dateTimePicker1.Height = 40;
            

        }


        /// <summary>
        /// 加载计划数据
        /// </summary>
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
                        //dgvTaskPlan.DataSource = taskData;
                        if (this.dgvTaskPlan.Rows.Count > 0)
                        {
                            dgvTaskPlan.Rows[0].Selected = false;
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
                dgvTaskPlan.Rows[i - 1].Cells["startTimeText"].Value = taskData[j].startTimeText.ToString();
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

    }
}
