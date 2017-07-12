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
    public class VersionModel
    {
        /// <summary>
        /// 服务器版本
        /// </summary>
        /// <value>The version.</value>
        public int version { get; set; }

        /// <summary>
        /// 下载地址
        /// </summary>
        /// <value>The URL.</value>
        public string url { get; set; }

        public string desc { get; set; }
    }


    /// <summary>
    /// 采集脚步实体
    /// </summary>
    public class InjectionJsModel
    {
        /// <summary>
        /// 服务器版本
        /// </summary>
        /// <value>The version.</value>
        public int version { get; set; }

        public string code { get; set; }

    }
}
