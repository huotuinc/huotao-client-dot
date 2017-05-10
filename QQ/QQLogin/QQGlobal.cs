/*
 * 版权所有:杭州火图科技有限公司
 * 地址:浙江省杭州市滨江区西兴街道阡陌路智慧E谷B幢4楼在地图中查看
 * (c) Copyright Hangzhou Hot Technology Co., Ltd.
 * Floor 4,Block B,Wisdom E Valley,Qianmo Road,Binjiang District
 * 2013-2017. All rights reserved.
 * author guomw
**/


using iQQ.Net.WebQQCore.Im;
using iQQ.Net.WebQQCore.Im.Bean;
using iQQ.Net.WebQQCore.Im.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQLogin
{

    /// <summary>
    /// QQ登录成功通知
    /// </summary>
    public delegate void QQNotifyLoginSuccessEventHandler();

    /// <summary>
    /// QQ群消息通知
    /// </summary>    
    /// <param name="msgCode">消息Code</param>
    /// <param name="msgGroupName">群标题</param>
    /// <param name="msgContent">消息内容</param>
    /// <param name="urls">消息包含的url</param>
    public delegate void QQNotifyGroupMsgEventHandler(long msgCode, string msgGroupName, string msgContent, List<string> urls);

    /// <summary>
    /// 关闭QQ
    /// </summary>
    public delegate void CloseQQEventHandler();
    /// <summary>
    /// QQ群加载完成
    /// </summary>
    public delegate void QQGroupLoadSuccessEventHandler();



    /// <summary>
    /// 根据商品地址，生成商品信息
    /// </summary>
    /// <param name="msgCode">商品CODE</param>
    /// <param name="urls">链接</param>
    /// <param name="isAutoSend">是否自动跟发</param>    
    /// <param name="callback">回调</param>    
    public delegate void BuildGoodsEventHandler(long msgCode,List<string> urls, bool isAutoSend,Action<MessageCallBackType,int,int> callback);

    /// <summary>
    /// 批量保存到本地商品库
    /// </summary>
    /// <param name="urls"></param>
    public delegate void BatchSaveEventHandler(List<Dictionary<string, string>> urls);



    /// <summary>
    /// 消息处理回调类型
    /// </summary>
    public enum MessageCallBackType
    {
        正在准备,
        开始转链,
        转链完成,
        开始创建计划,
        完成
    }




    /// <summary>
    /// 全局类
    /// </summary>
    public static class QQGlobal
    {
        /// <summary>
        /// QQ登录对象
        /// </summary>
        public static QQLogin loginForm { get; set; }

        /// <summary>
        /// 群加载完成
        /// </summary>
        public static bool QQGroupLoadSuccess { get; set; }
        /// <summary>
        /// 好友加载完成
        /// </summary>
        public static bool QQBuddyLoadSuccess { get; set; }

        /// <summary>
        /// qq数据
        /// </summary>
        public static QQStore store
        {
            get
            {
                return client.Store;
            }
        }
        /// <summary>
        /// QQ对象
        /// </summary>
        public static WebQQClient client { get; set; }

        /// <summary>
        /// 监控的群数量
        /// </summary>
        public static List<QQGroup> listenGroups { get; set; } = new List<QQGroup>();


        /// <summary>
        /// 获取自己账户实体
        /// </summary>
        public static QQAccount account
        {
            get
            {
                return client.Account;
            }
        }

        /// <summary>
        /// 颜色值 248, 248, 248
        /// </summary>
        public static readonly Color backColorSelected = Color.FromArgb(248, 248, 248);
        /// <summary>
        /// 颜色值 255, 255, 255
        /// </summary>
        public static readonly Color backColor = Color.FromArgb(255, 255, 255);


        /// <summary>
        /// 
        /// </summary>
        public static void Reset()
        {
            listenGroups.Clear();
            client = null;
            QQGroupLoadSuccess = false;
            QQBuddyLoadSuccess = false;
            loginForm = null;
        }

    }




    /// <summary>
    /// 采集的消息实体
    /// </summary>
    public class QQGroupMessageModel
    {

        public long Code { get; set; }

        /// <summary>
        /// 消息来源QQ群
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// 消息完整内容
        /// </summary>
        public string MessageContent { get; set; }

        /// <summary>
        /// 链接1
        /// </summary>
        public string MessageUrl1 { get; set; }

        /// <summary>
        /// 链接2
        /// </summary>
        public string MessageUrl2 { get; set; }

        /// <summary>
        /// 消息状态0未处理   1已处理
        /// </summary>
        public int MessageStatus { get; set; } = 0;
    }

}
