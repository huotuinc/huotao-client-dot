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
    /// 同步商品实体
    /// </summary>
    public class SyncGoodsModel
    {
        /// <summary>
        /// 同步时间
        /// </summary>
        /// <value>The date time.</value>
        public string dateTime { get; set; }

        /// <summary>
        /// 商品数据
        /// </summary>
        /// <value>The list.</value>
        public List<SyncGoodsList> list { get; set; }
    }

    public class SyncGoodsList
    {
        public long id { get; set; }

        public int userid { get; set; }

        /// <summary>
        /// Gets or sets the taobaousername.
        /// </summary>
        /// <value>The taobaousername.</value>
        public string taobaousername { get; set; }

        public string goodsId { get; set; }

        public string url { get; set; }

    }


    public class SyncAccountModel
    {
        public long id { get; set; }

        public int userid { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        /// <value>The loginname.</value>
        public string loginname { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        /// <value>The loginpwd.</value>
        public string loginpwd { get; set; }

    }

    /// <summary>
    /// 最后同步时间
    /// </summary>
    public class LastSyncTimeModel
    {
        /// <summary>
        /// 淘宝账号
        /// </summary>
        /// <value>The taobaousername.</value>
        public string taobaousername { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        /// <value>The userid.</value>
        public int userid { get; set; }
        /// <summary>
        /// 最后同步时间
        /// </summary>
        /// <value>The datetime.</value>
        public string datetime { get; set; }
    }

}
