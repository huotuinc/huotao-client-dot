using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HotTaoCore.Logic;

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
                        dgvTaskPlan.DataSource = taskData;
                        if (this.dgvTaskPlan.Rows.Count > 0)
                        {
                            dgvTaskPlan.Rows[0].Selected = false;
                        }
                    }));
                }

            })).BeginInvoke(null, null);
        }
    }
}
