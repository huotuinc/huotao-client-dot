using System;
using System.Collections.Generic;
using System.Text;
using iQQ.Net.WebQQCore.Im.Bean.Content;
using iQQ.Net.WebQQCore.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace iQQ.Net.WebQQCore.Im.Bean
{

    public enum QQMsgType
    {
        BUDDY_MSG, 		//好友消息
        GROUP_MSG,		// 群消息
        DISCUZ_MSG,		//讨论组消息
        SESSION_MSG	//临时会话消息
    }

    /// <summary>
    /// QQ消息
    /// </summary>
    // 
    public class QQMsg
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 暂时不知什么含义
        /// </summary>
        public long Id2 { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public QQMsgType Type { get; set; }
        /// <summary>
        /// 消息接收方
        /// </summary>
        public QQUser To { get; set; }
        /// <summary>
        /// 消息发送方
        /// </summary>
        public QQUser From { get; set; }
        /// <summary>
        /// 所在群
        /// </summary>
        public QQGroup Group { get; set; }
        /// <summary>
        /// 讨论组
        /// </summary>
        public QQDiscuz Discuz { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 消息列表
        /// </summary>
        public List<IContentItem> ContentList { get; set; } = new List<IContentItem>();

        public string PackContentList()
        {
            // ["font",{"size":10,"color":"808080","style":[0,0,0],"name":"\u65B0\u5B8B\u4F53"}]
            var json = new JArray();
            foreach (var contentItem in ContentList)
            {
                json.Add(contentItem.ToJson());
            }
            return JsonConvert.SerializeObject(json);
        }


        //public void ParseContentList(JToken jToken)
        //{
        //    /*
        //        [
        //            [
        //                "font",
        //                {
        //                    "color": "000000",
        //                    "name": "微软雅黑",
        //                    "size": 10,
        //                    "style": [
        //                        0,
        //                        0,
        //                        0
        //                    ]
        //                }
        //            ],
        //            "d"
        //        ]
        //    */
        //    var array = jToken as JArray;
        //    if (array != null)
        //    {
        //        foreach (var t in array)
        //        {
        //            if (t is JArray)
        //            {
        //                var items = t.ToObject<JArray>();
        //                var contentItemType = ContentItemType.ValueOfRaw(items[0].ToString());
        //                var item = JsonConvert.SerializeObject(items);
        //                switch (contentItemType.Name.ToUpper())
        //                {
        //                    case "FACE": AddContentItem(new FaceItem(item)); break;
        //                    case "FONT": AddContentItem(new FontItem(item)); break;
        //                    case "CFACE": AddContentItem(new CFaceItem(item)); break;
        //                    case "OFFPIC": AddContentItem(new OffPicItem(item)); break;

        //                    default:
        //                    break;
        //                }
        //            }
        //            else
        //            {
        //                AddContentItem(new TextItem(JsonConvert.SerializeObject(t)));
        //            }
        //        }
        //    }
        //    else
        //    {
        //        throw new QQException(QQErrorCode.JSON_ERROR);
        //    }
        //}

        public void ParseContentList(string text)
        {
            try
            {
                var json = JArray.Parse(text);
                foreach (var t in json)
                {
                    if (t is JArray)
                    {
                        var items = t.ToObject<JArray>();
                        var contentItemType = ContentItemTypeInfo.ValueOfRaw(items[0].ToString());
                        var item = JsonConvert.SerializeObject(items);
                        switch (contentItemType)
                        {
                            case ContentItemType.Face:
                                AddContentItem(new FaceItem(item));
                                break;

                            case ContentItemType.Font:
                                AddContentItem(new FontItem(item));
                                break;

                            case ContentItemType.Cface:
                                AddContentItem(new CFaceItem(item));
                                break;

                            case ContentItemType.Offpic:
                                AddContentItem(new OffPicItem(item));
                                break;

                            default:
                                break;
                        }
                    }
                    else
                    {
                        AddContentItem(new TextItem(JsonConvert.SerializeObject(t)));
                    }
                }
            }
            catch (JsonException e)
            {
                throw new QQException(QQErrorCode.JsonError, e);
            }
            catch (Exception e)
            {
                throw new QQException(QQErrorCode.UnknownError, e);
            }
        }

        public void AddContentItem(IContentItem contentItem)
        {
            ContentList.Add(contentItem);
        }

        public void DeleteContentItem(IContentItem contentItem)
        {
            ContentList.Remove(contentItem);
        }

        public override string ToString()
        {
            return PackContentList();
        }

        public string GetTextReplace()
        {
            var buffer = new StringBuilder();
            foreach (var item in ContentList)
            {
                string msg = item.ToText();
                msg = FilterText(msg);
                if (string.IsNullOrEmpty(msg)) continue;

                if (!string.IsNullOrEmpty(msg.Trim()))
                {
                    msg = msg.Replace('"', ' ').Replace(" ", "\r\n");
                    buffer.AppendLine(msg);
                }
            }
            string msgText = buffer.ToString();
            List<string> urls = UrlUtils.GetUrls(msgText);
            if (urls != null)
            {
                foreach (var url in urls)
                {
                    msgText = msgText.Replace(url, "");
                }
            }

            StringBuilder sb = new StringBuilder();
            using (StringReader sr = new StringReader(msgText))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        sb.AppendLine(line);
                    }
                }
            }
            sb.AppendLine("");
            return sb.ToString();
        }

        public string GetText()
        {
            var buffer = new StringBuilder();
            foreach (var item in ContentList)
            {
                string msg = item.ToText();
                if (!string.IsNullOrEmpty(msg))
                {
                    msg = msg.Replace('"', ' ').Replace(" ", "");
                    buffer.AppendLine(msg);
                }
            }
            return buffer.ToString();
        }

        /// <summary>
        /// 获取文案中的url
        /// </summary>
        /// <returns></returns>
        public List<string> GetUrls()
        {
            return UrlUtils.GetUrls(GetText());
        }



        /// <summary>
        /// 过滤文本
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private string FilterText(string msg)
        {
            if (string.IsNullOrEmpty(msg)) return msg;

            //替换xxx元内部券            
            Regex regex;
            string[] patterns = {
                @"\d+元优惠券:",
                @"\d+元优惠券：",
                @"\d*\.\d+元内部券：",
                @"\d*\.\d+内部券：",
                @"\d*\.\d+内部券:",
                @"\d*\.\d+元内部券:",
                @"\d+元内部券：",
                @"\d+内部券:",
                @"\d+元内部券",
                @"\d*\.\d+元优惠券：",
                @"\d*\.\d+元优惠券:"                
            };
            foreach (var pattern in patterns)
            {
                regex = new Regex(pattern, RegexOptions.IgnoreCase);
                Match m = regex.Match(msg);
                if (m.Success)
                {
                    msg = regex.Replace(msg, "");
                    break;
                }
            }
            if (string.IsNullOrEmpty(msg)) return msg;

            foreach (var str in filterDictionary)
            {
                if (msg.Contains(str))
                {
                    msg = msg.Replace(str, "");
                    break;
                }
            }
            return msg;
        }








        /// <summary>
        /// 过滤词典
        /// </summary>
        private static string[] filterDictionary = {
            "抢购地址：",
            "商品地址：",
            "产品链接：",
            "抢购：",
            "领券：",
            "下单：",
            "领卷：",
            "优惠券：",
            "券：",
            "拍：",
            "内部券：",
            "抢购地址:",
            "商品地址:",
            "产品链接:",
            "抢购:",
            "领券:",
            "下单:",
            "领卷:",
            "优惠券:",
            "优惠券链接",
            "下单链接",
            "下单地址",
            "优惠券",
            "链接",
            "抢购",
            "领券",
            "下单",
            "领卷",
            "券如下",
            "【抢券】",
            "【下单】",
            "券:",
            "拍:",
        };



        public void ClearContentItems()
        {
            ContentList.Clear();
        }
    }
}
