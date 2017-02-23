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

namespace HotTaoCore
{
    /// <summary>
    /// 接口常量
    /// </summary>
    public class ApiConst
    {
        /// <summary>
        /// 签名秘钥
        /// </summary>
        public const string SecretKey = "1165a8d240b29af3f418b8d10599d0da";
        /// <summary>
        /// 接口地址
        /// </summary>
        public const string Url = "http://192.168.1.57:8080";

        #region 接口常量

        public const string login = "/huotao/login";

        public const string register = "/huotao/register";
        /// <summary>
        /// token校验
        /// </summary>
        public const string checkToken = "/huotao/checkToken";
        #endregion
    }
}
