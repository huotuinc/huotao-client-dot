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
        public int id { get; set; }

        public int userid { get; set; }

        /// <summary>
        /// Gets or sets the taobaousername.
        /// </summary>
        /// <value>The taobaousername.</value>
        public string taobaousername { get; set; }

        public string goodsId { get; set; }

        public string url { get; set; }
        
    }
}
