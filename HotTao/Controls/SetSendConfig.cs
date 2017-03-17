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

        private SetControl setForm { get; set; }

        public SetSendConfig(Main mainWin, SetControl control)
        {
            InitializeComponent();
            hotForm = mainWin;
            setForm = control;
        }
        private void SetSendConfig_Load(object sender, EventArgs e)
        {
            if (MyUserInfo.currentUserId > 0)
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
            if (hotForm.myConfig == null)
                hotForm.myConfig = new ConfigModel();
            else
            {
                ConfigSendTimeModel cfgTime = string.IsNullOrEmpty(hotForm.myConfig.send_time_config) ? null : JsonConvert.DeserializeObject<ConfigSendTimeModel>(hotForm.myConfig.send_time_config);
                if (cfgTime != null)
                {
                    txtgoodsinterval.Text = cfgTime.goodsinterval > 0 ? cfgTime.goodsinterval.ToString() : "35";
                    txthandleInterval.Text = cfgTime.handleInterval > 0 ? cfgTime.handleInterval.ToString() : "2";
                    rbTwSort.Checked = cfgTime.imagetextsort == 0;
                    rbWtSort.Checked = cfgTime.imagetextsort == 1;
                    txtTaskInterval.Text = cfgTime.taskinterval > 0 ? cfgTime.taskinterval.ToString() : "30";
                    rdSendWindows.Checked = cfgTime.sendmode == 0;
                    rdSendRequest.Checked = cfgTime.sendmode == 1;
                }

                ConfigWhereModel cfgWhere = string.IsNullOrEmpty(hotForm.myConfig.where_config) ? null : JsonConvert.DeserializeObject<ConfigWhereModel>(hotForm.myConfig.where_config);
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
            rdSendRequest.Checked = setForm.sendRequest;

        }

        public void Save()
        {
            int result = 0;
            decimal result2 = 0;
            hotForm.myConfig.userid = MyUserInfo.currentUserId;
            ConfigSendTimeModel cfgTime = string.IsNullOrEmpty(hotForm.myConfig.send_time_config) ? new ConfigSendTimeModel() : JsonConvert.DeserializeObject<ConfigSendTimeModel>(hotForm.myConfig.send_time_config);
            cfgTime = cfgTime == null ? new ConfigSendTimeModel() : cfgTime;


            //商品间隔
            int.TryParse(txtgoodsinterval.Text, out result);
            cfgTime.goodsinterval = result < 0 ? 35 : result;

            //图文间隔
            int.TryParse(txthandleInterval.Text, out result);
            cfgTime.handleInterval = result == 0 ? 2 : result;

            //任务间隔
            int.TryParse(txtTaskInterval.Text, out result);
            cfgTime.taskinterval = result == 0 ? 30 : result;
            //图文顺序
            cfgTime.imagetextsort = rbTwSort.Checked ? 0 : 1;

            //发送模式
            cfgTime.sendmode = rdSendWindows.Checked ? 0 : 1;

            MyUserInfo.sendmode = cfgTime.sendmode;

            //过滤条件
            ConfigWhereModel cfgWhere = string.IsNullOrEmpty(hotForm.myConfig.where_config) ? new ConfigWhereModel() : JsonConvert.DeserializeObject<ConfigWhereModel>(hotForm.myConfig.where_config);
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

            ConfigModel myConfig = hotForm.myConfig;
            myConfig.send_time_config = JsonConvert.SerializeObject(cfgTime);
            myConfig.where_config = JsonConvert.SerializeObject(cfgWhere);

            MessageAlert alert = new MessageAlert();
            Loading ld = new Loading();
            ((Action)(delegate ()
            {
                if (LogicUser.Instance.AddUserConfigModel(MyUserInfo.LoginToken, hotForm.myConfig) > 0)
                    alert.Message = "保存成功";
                else
                    alert.Message = "保存失败，请重试";
                ld.CloseForm();
                this.BeginInvoke((Action)(delegate ()
                {
                    hotForm.myConfig = myConfig;
                    alert.ShowDialog(this);
                }));


            })).BeginInvoke(null, null);
            ld.ShowDialog(this);
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

        private void rdSendRequest_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                int tag = Convert.ToInt32(rb.Tag.ToString());
                setForm.SetPancelVisible(tag == 1);

                setForm.sendRequest = rdSendRequest.Checked;
            }
        }
    }
}
