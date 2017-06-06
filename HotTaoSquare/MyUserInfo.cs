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
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HotTaoSquare
{

    /// <summary>
    /// 版本
    /// </summary>
    public class Version
    {
        /// <summary>
        /// 版本号
        /// </summary>
        public const string value = "1.0.0";
    }







    /// <summary>
    /// 用户相关的全局数据类
    /// </summary>
    public class MyUserInfo
    {
        public static UserModel userData { get; set; }

        public static string LoginToken { get; set; } = "";

        public static int currentUserId { get; set; } = 0;

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
        public static string sendtemplate { get; set; } = "";
        /// <summary>
        /// 默认文案
        /// </summary>
        public static string defaultSendTempateText = "[商品标题]\n[分隔符]\n【原价】：[商品价格]元\n【券后】：[券后价格]元\n【口令】：[二合一淘口令]\n[分隔符]\n购买方式：复制这条信息，打开『手" +
    "机淘宝』即可看到商品和优惠券，先领券再下单哦\n[分隔符]\n本群都是内部优惠券，敬请大家关注每天特价产品。\n";



        /// <summary>
        /// 登录登录的淘宝账号
        /// </summary>
        public static string TaobaoName { get; set; } = "";

        /// <summary>
        /// 当前cookie json
        /// </summary>
        public static string cookieJson { get; set; }


        /// <summary>
        /// 淘宝联盟cookies
        /// </summary>
        public static CookieCollection cookies { get; set; }

        /// <summary>
        /// 获取淘宝联盟token
        /// </summary>
        /// <returns></returns>
        public static string GetTbToken()
        {
            string _tb_token = string.Empty;
            foreach (Cookie cookie in cookies)
            {
                if (cookie.Name.Equals("_tb_token_"))
                {
                    _tb_token = cookie.Value;
                    break;
                }
            }
            return _tb_token;
        }



    }
}
