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
    public partial class SetSendConfig : UserControl
    {
        private Main hotForm { get; set; }
        public SetSendConfig(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }
        /// <summary>
        /// 我的配置
        /// </summary>
        /// <value>My configuration.</value>
        private ConfigModel myConfig { get; set; }
        private void SetSendConfig_Load(object sender, EventArgs e)
        {
            if (hotForm.currentUserId > 0)
            {
                LoadConfig();
            }
            else
                hotForm.openControl(new LoginControl(hotForm));

        }

        /// <summary>
        /// 加载配置数据
        /// </summary>
        private void LoadConfig()
        {
            myConfig = LogicUser.Instance.GetConfigModel(hotForm.currentUserId);
            if (myConfig == null)
                myConfig = new ConfigModel();
            else
            {
                ConfigSendTimeModel cfgTime = string.IsNullOrEmpty(myConfig.send_time_config) ? null : JsonConvert.DeserializeObject<ConfigSendTimeModel>(myConfig.send_time_config);
                if (cfgTime != null)
                {
                    txtgoodsinterval.Text = cfgTime.goodsinterval.ToString();
                    txthandleInterval.Text = cfgTime.handleInterval.ToString();
                }
                //排序
                rbtSendorderbyAsc.Checked = myConfig.send_orderby == 0;
                rbtSendorderbyDesc.Checked = myConfig.send_orderby == 1;

                ConfigWhereModel cfgWhere = string.IsNullOrEmpty(myConfig.where_config) ? null : JsonConvert.DeserializeObject<ConfigWhereModel>(myConfig.where_config);
                if (cfgWhere != null)
                {
                    //优惠券过期天数
                    ckbminCouponDayCount.Checked = cfgWhere.minCouponDateDayCountEnable == 1;
                    txtminCouponDateDayCount.Text = cfgWhere.minCouponDateDayCount.ToString();

                    //优惠券低于n张
                    ckbCoupon.Checked = cfgWhere.minCouponAmountEnable == 1;
                    txtminCouponAmount.Text = cfgWhere.minCouponAmount.ToString();

                    //商品销量
                    ckbMonthSales.Checked = cfgWhere.minMonthSalesAmountEnable == 1;
                    txtminMonthSalesAmount.Text = cfgWhere.minMonthSalesAmount.ToString();

                    //商品返佣率过滤
                    ckbCmsRate.Checked = cfgWhere.minCmsRateAmountEnable == 1;
                    txtminCmsRateAmount.Text = cfgWhere.minCmsRateAmount.ToString();

                    //商品价格过滤
                    ckbGoodsPrice.Checked = cfgWhere.GoodsPriceEnable == 1;
                    txtminGoodsPrice.Text = cfgWhere.minGoodsPrice.ToString();
                    txtmaxGoodsPrice.Text = cfgWhere.maxGoodsPrice.ToString();

                    //
                    ckbfilterGoods.Checked = cfgWhere.filterGoodsEnable == 1;
                }
            }

        }

        public void Save()
        {
            int result = 0;
            decimal result2 = 0;
            MessageAlert alert = new MessageAlert();


            ConfigSendTimeModel cfgTime = string.IsNullOrEmpty(myConfig.send_time_config) ? new ConfigSendTimeModel() : JsonConvert.DeserializeObject<ConfigSendTimeModel>(myConfig.send_time_config);
            cfgTime = cfgTime == null ? new ConfigSendTimeModel() : cfgTime;

            //操作时间
            int.TryParse(txtgoodsinterval.Text, out result);
            cfgTime.goodsinterval = result;
            int.TryParse(txthandleInterval.Text, out result);
            cfgTime.handleInterval = result;

            //过滤条件
            ConfigWhereModel cfgWhere = string.IsNullOrEmpty(myConfig.where_config) ? new ConfigWhereModel() : JsonConvert.DeserializeObject<ConfigWhereModel>(myConfig.where_config);
            cfgWhere = cfgWhere == null ? new ConfigWhereModel() : cfgWhere;

            //优惠券过期
            cfgWhere.minCouponDateDayCountEnable = ckbminCouponDayCount.Checked ? 1 : 0;
            int.TryParse(txtminCouponDateDayCount.Text, out result);
            cfgWhere.minCouponDateDayCount = result;

            //优惠券数量
            cfgWhere.minCouponAmountEnable = ckbCoupon.Checked ? 1 : 0;
            int.TryParse(txtminCouponAmount.Text, out result);
            cfgWhere.minCouponAmount = result;

            //月销量
            cfgWhere.minMonthSalesAmountEnable = ckbMonthSales.Checked ? 1 : 0;
            int.TryParse(txtminMonthSalesAmount.Text, out result);
            cfgWhere.minMonthSalesAmount = result;


            //佣金比率
            cfgWhere.minCmsRateAmountEnable = ckbCmsRate.Checked ? 1 : 0;
            decimal.TryParse(txtminCmsRateAmount.Text, out result2);
            cfgWhere.minCmsRateAmount = result2;

            //商品价格
            cfgWhere.GoodsPriceEnable = ckbGoodsPrice.Checked ? 1 : 0;
            decimal.TryParse(txtminGoodsPrice.Text, out result2);
            cfgWhere.minGoodsPrice = result2;
            decimal.TryParse(txtmaxGoodsPrice.Text, out result2);
            cfgWhere.maxGoodsPrice = result2;

            //过滤今日重复商品
            cfgWhere.filterGoodsEnable = ckbfilterGoods.Checked ? 1 : 0;


            myConfig.send_orderby = rbtSendorderbyAsc.Checked ? 0 : 1;
            myConfig.send_time_config = JsonConvert.SerializeObject(cfgTime);
            myConfig.where_config = JsonConvert.SerializeObject(cfgWhere);
            LogicUser.Instance.AddUserConfigModel(myConfig);

            alert.Message = "保存成功";
            alert.ShowDialog(this);
        }

        /// <summary>
        /// 数字
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void TextBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;//消除不合适字符  
            }
            else if (Char.IsNumber(e.KeyChar))
            {
                int result = 0;
                int.TryParse(t.Text, out result);
                if (result <= 0)
                    e.Handled = true;
            }
        }

        /// <summary>
        /// 数字+小数点
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void TextBoxFloat_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;//消除不合适字符  
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar != '.' || t.Text.Length == 0)//小数点  
                {
                    e.Handled = true;
                }
                if (t.Text.LastIndexOf('.') != -1)
                {
                    e.Handled = true;
                }
            }
        }

    }
}
