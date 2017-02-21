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
    /// 微信登录授权配置
    /// </summary>
    public class WxAuthConfigModel
    {
        public int userid { get; set; }

        public long uid { get; set; }

        public string sid { get; set; }

        public string skey { get; set; }

        public string webwxDataTicket { get; set; }

        public string passTicket { get; set; }
    }
}
