using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace HotTaoMonitoring.UserControls
{
    public partial class ShopingGuideGroupConfigControl : UserControl
    {

        private MainForm mainForm { get; set; }

        public ShopingGuideGroupConfigControl(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void ShopingGuideGroupConfigControl_Load(object sender, EventArgs e)
        {
            LoadContactsList();
        }

        List<WxGuideGroupsModel> wxGuideData = new List<WxGuideGroupsModel>();

        /// <summary>
        /// 加载微信通讯录
        /// </summary>
        private void LoadContactsList()
        {
            new Thread(() =>
            {
                //是否自动添加属性字段
                this.dgvWeChatList.AutoGenerateColumns = false;

                mainForm.contact_all.ForEach(user =>
                {
                    if (!wxGuideData.Exists(item => { return user.UserName == item.UserName; }))
                    {
                        wxGuideData.Add(new WxGuideGroupsModel()
                        {
                            ShowName = user.ShowName,
                            UserName = user.UserName,
                            IsSelected = false
                        });
                    }
                    else
                    {
                        wxGuideData.ForEach(item =>
                        {
                            if (item.UserName == user.UserName)
                                item.ShowName = user.ShowName;
                        });
                    }
                });
                SetContactsView(wxGuideData);
            })
            { IsBackground = true }.Start();
        }





        /// <summary>
        /// 加载微信通讯录
        /// </summary>
        /// <param name="contact_all">The contact_all.</param>
        public void SetContactsView(List<WxGuideGroupsModel> contact_all)
        {
            if (dgvWeChatList.InvokeRequired)
            {
                this.Invoke(new Action<List<WxGuideGroupsModel>>(SetContactsView), new object[] { contact_all });
            }
            else
            {
                this.dgvWeChatList.Rows.Clear();
                int i = dgvWeChatList.Rows.Count;
                foreach (var user in contact_all)
                {
                    dgvWeChatList.Rows.Add();
                    ++i;
                    dgvWeChatList.Rows[i - 1].Cells["ID"].Value = i;
                    dgvWeChatList.Rows[i - 1].Cells["ShowName"].Value = user.ShowName;
                    dgvWeChatList.Rows[i - 1].Cells["UserName"].Value = user.UserName;
                    dgvWeChatList.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewOddRowBackColor;
                    if (i % 2 == 0)
                    {
                        dgvWeChatList.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                        dgvWeChatList.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewEvenRowBackColor;
                    }
                    else
                    {
                        dgvWeChatList.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;
                        dgvWeChatList.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewOddRowBackColor;
                    }
                    dgvWeChatList.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                    dgvWeChatList.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;
                }
            }
        }

        /// <summary>
        /// 刷新群列表
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            mainForm.wxlogin.ReloadContact(() =>
            {
                LoadContactsList();
            });
        }
        /// <summary>
        /// 保存选择结果
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            ////List<GoodsTaskModel> goodsidList = new List<GoodsTaskModel>();
            ////循环获取选中的数据
            //foreach (DataGridViewRow item in dgvData.Rows)
            //{
            //    if ((bool)item.Cells[0].EditedFormattedValue == true)
            //    {
            //        int result = 0;
            //        int.TryParse(item.Cells["gid"].Value.ToString(), out result);
            //        if (result > 0 && goodsidList.FindIndex(r => { return r.id == result; }) < 0)
            //            goodsidList.Add(new GoodsTaskModel() { id = result });
            //    }
            //}
        }
    }
}
