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
        /// <summary>
        /// The register
        /// </summary>
        public const string register = "/huotao/register";
        /// <summary>
        /// token校验
        /// </summary>
        public const string checkToken = "/huotao/checkToken";

        /// <summary>
        /// 获取获取微信群列表
        /// </summary>
        public const string getWeChatGroups = "/weChatGroup/getWeChatGroups";

        /// <summary>
        /// 新增微信群
        /// </summary>
        public const string saveWeChatGroup = "/weChatGroup/saveWeChatGroup";

        /// <summary>
        /// 删除微信群
        /// </summary>
        public const string delWeChatGroup = "/weChatGroup/delWeChatGroup";

        /// <summary>
        /// 获取任务列表
        /// </summary>
        public const string getTaskList = "/task/getTaskList";

        /// <summary>
        /// 添加/修改任务
        /// </summary>
        public const string saveTask = "/task/saveTask";

        /// <summary>
        /// 删除任务
        /// </summary>
        public const string delTask = "/task/delTask";

        /// <summary>
        /// 修改已转发的数据状态
        /// </summary>
        public const string modifyTaskExecuteStatus = "/task/modifyTaskExecuteStatus";


        /// <summary>
        /// 获取商品
        /// </summary>
        public const string getGoodsList = "/hotUser/getGoodsList";

        /// <summary>
        /// 删除商品
        /// </summary>
        public const string delGoods = "/hotUser/delGoods";


        /// <summary>
        /// 添加自动管理群
        /// </summary>
        public const string saveAutoWeChatGroup = "/weChatGroup/saveAutoWeChatGroup";


        /// <summary>
        /// 转链
        /// </summary>
        public const string turnChain = "/task/turnChain";

        /// <summary>
        /// 获取推广位列表
        /// </summary>
        public const string getExtensions = "/weChatGroup/getExtensions";

        /// <summary>
        /// 设置微信群pid
        /// </summary>
        public const string setPid = "/weChatGroup/setPid";


        /// <summary>
        /// 设置用户配置
        /// </summary>
        public const string saveHotUserConfig = "/hotUser/saveHotUserConfig";
        /// <summary>
        /// 获取用户配置
        /// </summary>
        public const string getHotUserConfig = "/hotUser/getHotUserConfig";

        #endregion
    }
}
