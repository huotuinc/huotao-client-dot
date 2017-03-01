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
    /// 自动回复群
    /// </summary>
    public class WxAutoReplyModel
    {
        public int id { get; set; }

        /// <summary>
        ///用户id
        /// </summary>
        /// <value>The userid.</value>
        public int userid { get; set; }

        /// <summary>
        /// 目标类型，0 自动回复，1踢人
        /// </summary>
        /// <value>The type of the handle.</value>
        public int handleType { get; set; }
        /// <summary>
        /// 群标题
        /// </summary>
        /// <value>The wechattile.</value>
        public string wechattitle { get; set; }
    }

    /// <summary>
    /// 关键字回复实体
    /// </summary>
    public class WxAutoReplyKeywordModel
    {
        public int id { get; set; }

        /// <summary>
        ///用户id
        /// </summary>
        /// <value>The userid.</value>
        public int userid { get; set; }

        public string replyKeyword { get; set; }
        /// <summary>
        /// 回复类型 0 文本，1商品
        /// </summary>
        /// <value>The type of the reply.</value>
        public int replyType { get; set; }

        public string replyContent { get; set; }

        /// <summary>
        /// 关键字回复关联的商品ID
        /// </summary>
        /// <value>The reply goods identifier.</value>
        public int replyGoodsId { get; set; }
    }
}
