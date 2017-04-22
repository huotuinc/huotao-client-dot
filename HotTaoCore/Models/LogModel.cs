/*
 * 版权所有:杭州火图科技有限公司
 * 地址:浙江省杭州市滨江区西兴街道阡陌路智慧E谷B幢4楼在地图中查看
 * (c) Copyright Hangzhou Hot Technology Co., Ltd.
 * Floor 4,Block B,Wisdom E Valley,Qianmo Road,Binjiang District
 * 2013-2017. All rights reserved.
 * author guomw
**/


using HotTaoCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTaoCore.Models
{
    public class LogModel
    {
    }

    public class LogRuningModel
    {
        /// <summary>
        /// 商品ID（可为空）
        /// </summary>
        public string goodsid { get; set; }
        /// <summary>
        /// 商品名称(可为空)
        /// </summary>
        public string goodsName { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string content { get; set; }

        public DateTime logTime { get; set; }
        /// <summary>
        /// 1 申请佣金
        /// </summary>
        public LogTypeOpts logType { get; set; }

        public bool isError { get; set; }

        public string remark { get; set; }
    }

}
