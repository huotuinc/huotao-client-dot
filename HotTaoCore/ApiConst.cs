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
        public const string Url = "http://112.74.23.122:8080";//112.74.23.122


        public const string CheckUpdateUrl = "http://120.24.54.54:8084";


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
        /// 获取自动回复/踢人微信群列表
        /// </summary>
        public const string getAutoReplyWeChatGroupList = "/hotUser/getAutoReplyWeChatGroupList";

        /// <summary>
        /// 添加自动管理群
        /// </summary>
        public const string saveAutoWeChatGroup = "/hotUser/saveAutoReplyWeChatGroupList";

        /// <summary>
        /// 删除回复/踢人微信群
        /// </summary>
        public const string delAutoReplyWeChatGroup = "/hotUser/delReplyWeChatGroup";




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
        /// <summary>
        /// 获取执行任务列表
        /// </summary>
        public const string getTaskExecuteList = "/task/getTaskExecuteList";

        /// <summary>
        /// 修改任务状态
        /// </summary>
        public const string modifyTaskStatus = "/task/modifyTaskStatus";


        /// <summary>
        /// 拉取阿里妈妈推广位信息
        /// </summary>
        public const string getPids = "/alimama/getPids";

        /// <summary>
        /// 获取淘宝账号
        /// </summary>
        public const string getTaobaoUsername = "/alimama/getTaobaoUsername";


        /// <summary>
        /// 获取自定义文案
        /// </summary>
        public const string getUserGoodsTempList = "/hotUser/getUserGoodsTempList";

        /// <summary>
        /// 自定义文案设置
        /// </summary>
        public const string saveUserGoodsTempList = "/hotUser/saveUserGoodsTempList";




        ///// <summary>
        ///// 获取自动回复微信群列表
        ///// </summary>
        //public const string getReplyWeChatList = "/hotUser/getReplyWeChatList";




        /// <summary>
        /// 获取关键字自动回复配置列表
        /// </summary>
        public const string getKeywordReplyConfigList = "/hotUser/getReplyConfigList";

        /// <summary>
        /// 添加关键字回复配置
        /// </summary>
        public const string saveReplyConfig = "/hotUser/saveReplyConfig";

        /// <summary>
        /// 删除关键字回复配置
        /// </summary>
        public const string delReplyConfig = "/hotUser/delReplyConfig";



        /// <summary>
        /// 获取需要同步的商品数量
        /// </summary>
        public const string countForApplyGoods = "/api/countForApplyGoods";

        /// <summary>
        /// 获取需要同步的商品地址列表
        /// </summary>
        public const string listForApplyGoods = "/api/listForApplyGoods";


        /// <summary>
        /// 确认最后商品同步时间
        /// </summary>
        public const string confirmForApplyGoods = "/api/confirmForApplyGoods";

        /// <summary>
        /// 绑定淘宝帐号
        /// </summary>
        public const string bindTaobao = "/api/bindTaobao";

        /// <summary>
        /// 生成短链
        /// </summary>
        public const string buildShortUrl = "/api/buildShortUrl";


        #endregion
    }
}
