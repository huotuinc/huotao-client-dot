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
    public partial class HomeControl : UserControl
    {
        private Main hotForm { get; set; }
        public int CurrentShowRowNumber { get; set; }

        public const int PageRowCount = 100;

        public HomeControl(Main mainWin)
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
                        dgvPid.DataSource = pidData;
                        if (this.dgvPid.Rows.Count > 0)
                        {
                            dgvPid.Rows[0].Selected = false;
                        }
                    }));
                }

            })).BeginInvoke(null, null);
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
                        dgvTaskPlan.DataSource = taskData;
                        if (this.dgvTaskPlan.Rows.Count > 0)
                        {
                            dgvTaskPlan.Rows[0].Selected = false;
                        }
                    }));
                }

            })).BeginInvoke(null, null);
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
                    SetGoodsGridViewData(dgvData,data);
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
                this.Invoke(new Action<DataGridView,List<GoodsModel>>(SetGoodsGridViewData), new object[] { obj, data });
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
                }
   
            }
        }

        private void dgvData_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue < e.NewValue && dgvData.RowCount < e.NewValue + 16)
            {
                CurrentShowRowNumber++;
                var goodsData = LogicGoods.Instance.getGoodsList(CurrentShowRowNumber, PageRowCount);
                if (goodsData != null)
                {
                    //data.AddRange(goodsData);
                    SetGoodsGridViewData(dgvData,goodsData);
                }
            }
        }
    }
}
