/*
 * 版权所有:杭州火图科技有限公司
 * 地址:浙江省杭州市滨江区西兴街道阡陌路智慧E谷B幢4楼在地图中查看
 * (c) Copyright Hangzhou Hot Technology Co., Ltd.
 * Floor 4,Block B,Wisdom E Valley,Qianmo Road,Binjiang District
 * 2013-2017. All rights reserved.
 * author guomw
**/


using HOTReuestService.Helper;
using HotTaoCore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HotTao
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
        public static string cookieJson = "";

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


        public static string cToken { get; set; } = "";



        /// <summary>
        /// 如果文件存在，则返回文件路径，否则返回null
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        public static string GetVideoFilePath(string goodsId)
        {
            string fileName = Environment.CurrentDirectory + "\\temp\\video\\" + currentUserId.ToString();
            if (!Directory.Exists(fileName))
                Directory.CreateDirectory(fileName);
            fileName += "\\" + EncryptHelper.MD5(goodsId);

            string filepath_gif = string.Format("{0}.gif", fileName);
            string filepath_mp4 = string.Format("{0}.mp4", fileName);

            if (File.Exists(filepath_mp4))
                return filepath_mp4;
            //判断
            else if (File.Exists(filepath_gif))
                return filepath_gif;
            return null;
        }

    }
}
