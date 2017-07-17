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

namespace HOTReuestService
{
    /// <summary>
    /// 接口常量
    /// </summary>
    public class ApiDefineConst
    {
        /// <summary>
        /// 签名秘钥
        /// </summary>
        public const string SecretKey = "1165a8d240b29af3f418b8d10599d0da";
        /// <summary>
        /// 接口地址
        /// </summary>
        public const string Url = "http://www.51huotao.com";// "http://www.staging.51huotao.com";//"

        /// <summary>
        /// 官网首页
        /// </summary>
        public const string www = "http://www.51huotao.com";

        public const string CheckUpdateUrl = Url + "/version/v.json";

        /// <summary>
        ///  采集js脚步地址
        /// </summary>
        public const string JsCode = Url + "/version/caijijs/injection.json";





        /// <summary>
        /// 获取帮助文档地址
        /// </summary>
        /// <param name="path">1发单说明，2客服说明 3淘客广场说明</param>
        /// <returns></returns>
        public static string getHelpUrl(object path)
        {
            return Url + "/portal/help" + path.ToString();
        }



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


        /// <summary>
        /// 激活软件接口
        /// </summary>
        public const string activeAccount = "/huotao/active";

        /// <summary>
        /// 发送短信验证码
        /// </summary>
        public const string sendCodeForRegister = "/huotao/sendCodeForRegister";

        /// <summary>
        /// 批量商品链接转商品数据接口
        /// </summary>
        public const string findGoodsByLink = "/goods/findGoodsByLink";

        /// <summary>
        /// 请求网址采集任务
        /// </summary>
        public const string startDigOnePage = "/goods/startDigOnePage";
        /// <summary>
        /// 获取采集结果
        /// </summary>
        public const string queryGoods = "/goods/queryGoods";

        /// <summary>
        /// 发送预警短信
        /// </summary>
        public const string sendWarning = "/api/sendWarning";


        /// <summary>
        /// 发送预警邮件
        /// </summary>
        public const string sendMail = "/api/sendMail";


        /// <summary>
        /// 检查阿里妈妈cookie是否过期
        /// </summary>
        public const string checkCookie = "/alimama/checkCookie";

        /// <summary>
        /// 根据商品链接查找最优定向佣金计划
        /// </summary>
        public const string getCommissionPlan = "/goods/getCommissionPlan";

        /// <summary>
        /// 上传QQ采集的商品
        /// </summary>
        public const string uploadGoodsbyLink = "/goods/uploadGoodsbyLink";

        /// <summary>
        /// 获取【可绑定当前帐号到扫码微信号的二维码】
        /// </summary>
        public const string subscribeForBind = "/wechat/subscribeForBind";

        /// <summary>
        /// 推送通知到用户
        /// </summary>
        public const string sendUserNotice = "/hotUser/sendUserNotice";

        #endregion
    }
}
