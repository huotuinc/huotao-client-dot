/*
 * 版权所有:杭州火图科技有限公司
 * 地址:浙江省杭州市滨江区西兴街道阡陌路智慧E谷B幢4楼在地图中查看
 * (c) Copyright Hangzhou Hot Technology Co., Ltd.
 * Floor 4,Block B,Wisdom E Valley,Qianmo Road,Binjiang District
 * 2013-2017. All rights reserved.
 * author guomw
**/


using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TBSync
{


    /// <summary>
    /// 表示登录完成事件的方法
    /// </summary>
    /// <param name="user"></param>
    public delegate void LoginSuccessEventHandler(CookieCollection cookies);

    /// <summary>
    /// 登录页面加载完成事件方法
    /// </summary>
    public delegate void LoginPageLoadSuccessEventHandler(bool success);

    /// <summary>
    /// 页面访问受限事件方法
    /// </summary>
    public delegate void LoadDenyEventHandler();

    /// <summary>
    /// 关闭事件
    /// </summary>
    public delegate void CloseEventHandler();


    /// <summary>
    /// 表示处理信息事件的方法
    /// </summary>
    /// <param name="user"></param>
    public delegate void OKEventHandler();

}
