using HotCoreUtils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTaoCore
{
    public class GlobalConfig
    {

        public const string dbpath = "db";

        public const string datapath = "data";

        /// <summary>
        /// 优惠券地址
        /// </summary>
        public const string couponUrl = "https://uland.taobao.com/coupon/edetail";

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

    }





}
