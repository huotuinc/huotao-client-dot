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
    public class TaobaoCommonCampaignItemsModel
    {

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public List<TaobaoCommonItem> data { get; set; }

        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        /// <value>The information.</value>
        public TaobaoComInfo info { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>true if ok; otherwise, false.</value>
        public bool ok { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value>true if [invalid key]; otherwise, false.</value>
        public bool invalidKey { get; set; }

    }

    public class TaobaoCommonItem
    {
        public decimal commissionRate { get; set; }

        public string CampaignID { get; set; }

        public string CampaignName { get; set; }

        public string CampaignType { get; set; }

        public string AvgCommission { get; set; }

        public bool Exist { get; set; }

        public int manualAudit { get; set; }

        public string ShopKeeperID { get; set; }

        public string Properties { get; set; }

    }


    public class TaobaoComInfo
    {
        public string message { get; set; }

        public bool ok { get; set; }
    }

}
