/*
 * 版权所有:杭州火图科技有限公司
 * 地址:浙江省杭州市滨江区西兴街道阡陌路智慧E谷B幢4楼在地图中查看
 * (c) Copyright Hangzhou Hot Technology Co., Ltd.
 * Floor 4,Block B,Wisdom E Valley,Qianmo Road,Binjiang District
 * 2013-2017. All rights reserved.
 * author guomw
**/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTaoCore.Models
{
    /// <summary>
    /// 设置配置
    /// </summary>
    public class ConfigModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        /// <value>The userid.</value>
        public int userid { get; set; }

        /// <summary>
        /// 群发过滤条件
        /// </summary>
        /// <value>The where_config.</value>
        public string where_config { get; set; }

        /// <summary>
        /// 发送顺序，0正序，1倒序
        /// </summary>
        /// <value>The send_orderby.</value>
        public int send_orderby { get; set; }

        /// <summary>
        /// 发送时间配置
        /// </summary>
        /// <value>The send_time_config.</value>
        public string send_time_config { get; set; }
        /// <summary>
        /// 启用自动回复 1启用
        /// </summary>
        /// <value>The enable_autoreply.</value>
        public int enable_autoreply { get; set; }

        /// <summary>
        /// 自动回复配置
        /// </summary>
        /// <value>The auto_reply_config.</value>
        public string auto_reply_config { get; set; }


        public DateTime createtime { get; set; }
    }

    /// <summary>
    /// 群发条件过滤
    /// </summary>
    public class ConfigWhereModel
    {

        public int minCouponDateDayCountEnable { get; set; }

        /// <summary>
        // 最小优惠券结束天数
        /// </summary>
        /// <value>The minimum coupon amount.</value>
        public int minCouponDateDayCount { get; set; }


        public int minCouponAmountEnable { get; set; }
        /// <summary>
        /// 最低优惠券数量
        /// </summary>
        /// <value>The minimum coupon amount.</value>
        public int minCouponAmount { get; set; }
        /// <summary>
        /// 最小月销量
        /// </summary>
        /// <value>The minimum month sales amount.</value>
        public int minMonthSalesAmount { get; set; }

        public int minMonthSalesAmountEnable { get; set; }

        /// <summary>
        /// 最低佣金率
        /// </summary>
        /// <value>The minimum CMS rate amount.</value>
        public decimal minCmsRateAmount { get; set; }


        public int minCmsRateAmountEnable { get; set; }
        /// <summary>
        /// 最小商品价格
        /// </summary>
        /// <value>The minimum goods price.</value>
        public decimal minGoodsPrice { get; set; }

        /// <summary>
        /// 启用价格过滤
        /// </summary>
        /// <value>The goods price enable.</value>
        public int GoodsPriceEnable { get; set; }
        /// <summary>
        /// 最大商品价格
        /// </summary>
        /// <value>The minimum goods price.</value>
        public decimal maxGoodsPrice { get; set; }


        public int filterGoodsEnable { get; set; }



    }
    /// <summary>
    /// 发送时间配置
    /// </summary>
    public class ConfigSendTimeModel
    {
        /// <summary>
        /// 操作时间间隔 单位秒
        /// </summary>
        /// <value>The handle interval.</value>
        public int handleInterval { get; set; }
        /// <summary>
        /// 发送商品间隔 单位秒
        /// </summary>
        /// <value>The goodsinterval.</value>
        public int goodsinterval { get; set; }
    }
    /// <summary>
    /// 自动回复配置
    /// </summary>
    public class ConfigAutoReplyModel
    {
        /// <summary>
        /// 关键字
        /// </summary>
        /// <value>The keyworld.</value>
        public string keyworld { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        /// <value>The replycontent.</value>
        public string replycontent { get; set; }
    }

}
