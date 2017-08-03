/*
 * 版权所有:杭州火图科技有限公司
 * 地址:浙江省杭州市滨江区西兴街道阡陌路智慧E谷B幢4楼在地图中查看
 * (c) Copyright Hangzhou Hot Technology Co., Ltd.
 * Floor 4,Block B,Wisdom E Valley,Qianmo Road,Binjiang District
 * 2013-2017. All rights reserved.
 * author guomw
**/


using HotTaoCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HotTaoMonitoring
{
    /// <summary>
    /// 用户相关的全局数据类
    /// </summary>
    public class MyUserInfo
    {
        public static UserModel userData;

        public static string LoginToken = "";

        public static int currentUserId = 0;

        public void SetUserData(UserModel user)
        {
            userData = user;
            if (user != null)
            {
                LoginToken = user.loginToken;
                currentUserId = user.userid;
            }
            else
            {
                LoginToken = "";
                currentUserId = 0;
            }

        }

        /// <summary>
        /// 发送文案
        /// </summary>
        public static string sendtemplate = "";
        /// <summary>
        /// 默认文案
        /// </summary>
        public static string defaultSendTempateText = "[商品标题]\n[分隔符]\n【原价】：[商品价格]元\n【券后】：[券后价格]元\n【口令】：[二合一淘口令]\n[分隔符]\n购买方式：复制这条信息，打开『手" +
    "机淘宝』即可看到商品和优惠券，先领券再下单哦\n[分隔符]\n本群都是内部优惠券，敬请大家关注每天特价产品。\n";



        /// <summary>
        /// 我的推广位
        /// </summary>
        /// <value>My pid list.</value>
        public static List<UserTaoPidModel> MyPidList { get; set; }


        /// <summary>
        /// 淘宝登录cookie
        /// </summary>
        public static string TaobaoLoginCookies = "";

        /// <summary>
        /// 登录登录的淘宝账号
        /// </summary>
        public static string TaobaoName = "";


        /// <summary>
        /// 发送消息状态，0未发送，1发送中 2 发送完成
        /// </summary>
        public static int SendMessageStatus = 0;
        /// <summary>
        /// 发送的消息文本
        /// </summary>
        public static string SendMessageText = "";


        /// <summary>
        /// 过滤用户(微信昵称)，每个用户使用[]隔开
        /// </summary>
        public static string filterUserGroups = string.Empty;


        /// <summary>
        /// 发送模式 默认0窗口模式
        /// </summary>
        public static int sendmode = 0;

    }


    /// <summary>
    /// 用户控件枚举
    /// </summary>
    public enum UserControlsOpts
    {
        listen,
        filter,
        autoShopingGuide,
        autoShopingGuideConfig
    }

    /// <summary>
    /// 微信消息类型
    /// </summary>
    public enum WxMsgType : int
    {
        文本消息 = 1,
        图片消息 = 3,
        语音消息 = 34,
        VERIFYMSG = 37,
        共享名片 = 42,
        视频通话消息 = 43,
        动画表情 = 47,
        位置消息 = 48,
        分享链接 = 49,
        VOIPMSG = 50,
        小视频 = 62,
        SYSNOTICE = 9999,
        系统消息 = 10000,
        撤回消息 = 10002
    }




    /// <summary>
    /// 消息体
    /// </summary>
    public class WxMessageBodyModel
    {
        /// <summary>
        /// 消息时间
        /// </summary>
        /// <value>The content of the MSG.</value>
        public DateTime MsgTime { get; set; }

        /// <summary>
        /// 消息群标识
        /// </summary>
        /// <value>The name of the MSG user.</value>
        public string MsgUserName { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        /// <value>The MSG text.</value>
        public string MsgText { get; set; }

        /// <summary>
        ///  消息发送者标识
        /// </summary>
        /// <value>The MSG send user.</value>
        public string MsgSendUser { get; set; }

        /// <summary>
        /// 群标题
        /// </summary>
        /// <value>The name of the MSG show.</value>
        public string MsgShowName { get; set; }

        /// <summary>
        /// 发送者昵称
        /// </summary>
        /// <value>The name of the MSG nick.</value>
        public string MsgNickName { get; set; }

        /// <summary>
        /// 未读消息数
        /// </summary>
        /// <value>The not read count.</value>
        public int NotReadCount { get; set; }

        /// <summary>
        /// 回复状态
        /// </summary>
        /// <value>The MSG status.</value>
        public string MsgStatus { get; set; }



        /// <summary>
        /// 图片base64
        /// </summary>
        public string MsgImageBase64String { get; set; }

    }



    public class WxGuideGroupsModel
    {
        public string UserName { get; set; }

        public string ShowName { get; set; }

        public bool IsSelected { get; set; }


        
    }



    /// <summary>
    /// 
    /// </summary>
    public class CommonUtils
    {

        /// <summary>
        /// 过滤html标签
        /// </summary>
        /// <param name="htmlStr">The HTML string.</param>
        /// <returns>System.String.</returns>
        public static string HtmlToText(string htmlStr)
        {
            if (String.IsNullOrEmpty(htmlStr))
            {
                return "";
            }
            string regEx_style = "<style[^>]*?>[\\s\\S]*?<\\/style>"; //定义style的正则表达式 
            string regEx_script = "<script[^>]*?>[\\s\\S]*?<\\/script>"; //定义script的正则表达式 
            string regEx_html = "<[^>]+>"; //定义HTML标签的正则表达式 
            htmlStr = Regex.Replace(htmlStr, regEx_style, "");//删除css
            htmlStr = Regex.Replace(htmlStr, regEx_script, "");//删除js
            htmlStr = Regex.Replace(htmlStr, regEx_html, "");//删除html标记
            htmlStr = Regex.Replace(htmlStr, "\\s*|\t|\r|\n", "");//去除tab、空格、空行
            htmlStr = htmlStr.Replace(" ", "");
            return htmlStr.Trim();
        }

    }

}
