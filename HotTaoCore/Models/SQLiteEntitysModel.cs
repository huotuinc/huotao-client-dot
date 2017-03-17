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
using System.Threading.Tasks;

namespace HotTaoCore.Models
{
    public class SQLiteEntitysModel
    {

        /// <summary>
        /// 微信群
        /// </summary>
        public class weChatGroupModel
        {
            public long id { get; set; }

            public int userid { get; set; }

            public string title { get; set; }

            public string pid { get; set; }
        }


        /// <summary>
        /// 微信群发送内容
        /// </summary>
        public class weChatShareTextModel
        {
            public long id { get; set; }

            public int userid { get; set; }

            public string title { get; set; }

            public string text { get; set; }
            /// <summary>
            /// 淘口令
            /// </summary>
            /// <value>The TPWD.</value>
            public string tpwd { get; set; }

            public int taskid { get; set; }

            public int goodsid { get; set; }

            /// <summary>
            /// 0未发送，1已发送 2没有发送内容
            /// </summary>
            /// <value>The status.</value>
            public int status { get; set; }
        }


        /// <summary>
        /// 微信群发送失败实体
        /// </summary>
        public class weChatUserWechatErrorModel
        {
            public long id { get; set; }

            public int userid { get; set; }

            public string title { get; set; }

            /// <summary>
            /// 分享文本
            /// </summary>
            /// <value>The share text.</value>
            public string shareText { get; set; }

            /// <summary>
            /// 创建时间
            /// </summary>
            /// <value>The craetetime.</value>
            public DateTime createtime { get; set; }

            /// <summary>
            /// 错误类型
            /// </summary>
            /// <value>The type of the error.</value>
            public int errorType { get; set; }
        }
    }
}
