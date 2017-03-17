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
        /// 启用自动移除  1启用
        /// </summary>
        /// <value>The enable_auto_remove.</value>
        public int enable_autoremove { get; set; }
        
    }

    /// <summary>
    /// 条件过滤
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

        /// <summary>
        /// 自动踢人条件
        /// </summary>
        public string auto_remove_user_where { get; set; }

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
        /// 发送间隔
        /// </summary>
        /// <value>The hd interval.</value>
        public decimal hdInterval { get; set; }

        /// <summary>
        /// 发送商品间隔 单位秒
        /// </summary>
        /// <value>The goodsinterval.</value>
        public int goodsinterval { get; set; }

        /// <summary>
        /// 图文发送顺序0是先图后文，1是先文后图
        /// </summary>
        /// <value>The imagetextsort.</value>
        public int imagetextsort { get; set; }

        /// <summary>
        /// 发送模式 0窗口模式  1网络请求模式  默认0
        /// </summary>
        /// <value>The sendmode.</value>
        public int sendmode { get; set; }

        /// <summary>
        /// 任务之间的间隔时间
        /// </summary>
        /// <value>The taskinterval.</value>
        public int taskinterval { get; set; }
    }

    /// <summary>
    /// 踢人条件
    /// </summary>
    public class AutoRemoveUserWhereModel
    {
        /// <summary>
        /// 启动发图片踢人
        /// </summary>
        public int enable_send_image { get; set; }
        /// <summary>
        /// 发送图片次数，默认2次
        /// </summary>
        public int send_image_count { get; set; }

        /// <summary>
        /// 启动发文本消息踢人
        /// </summary>
        public int enable_send_text { get; set; }

        /// <summary>
        /// 发送文本长度，默认最长20字
        /// </summary>
        public int send_text_lenght { get; set; }
        /// <summary>
        /// 启动分享连接踢人
        /// </summary>
        public int enable_share_link { get; set; }

        /// <summary>
        /// 启动分享名片踢人
        /// </summary>
        public int enable_share_card { get; set; }
    }
}
