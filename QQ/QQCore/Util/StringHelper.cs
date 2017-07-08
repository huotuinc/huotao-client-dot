using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace iQQ.Net.WebQQCore.Util
{
    /**
     * 字符串工具类
     *
     * @author solosky
     */
    public static class StringHelper
    {
        public static Dictionary<string, string> QueryStringToDict(string queryString)
        {
            var dict = new Dictionary<string, string>();
            var queryItems = queryString.Split('&');
            foreach (var query in queryItems)
            {
                var pair = query.Split('=');
                if (pair.Length == 2 && !dict.Keys.Contains(pair[0]))
                {
                    dict.Add(pair[0], pair[1]);
                }
            }
            return dict;
        }

        /// <summary>
        /// 把十六进制字符串转在byte[]
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] HexStringToBytes(string hex)
        {
            if (hex.Length == 0)
            {
                return new byte[] { 0 };
            }
            if (hex.Length % 2 == 1)
            {
                hex = "0" + hex;
            }
            var result = new byte[hex.Length / 2];

            for (var i = 0; i < hex.Length / 2; i++)
            {
                result[i] = byte.Parse(hex.Substring(2 * i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }
            return result;
        }

        /**
         * 转义HTML中特殊的字符
         *
         * @param html HTML 内容
         * @return 结果字符串
         */
        public static string QouteHtmlSpecialChars(string html)
        {
            if (html == null) return null;
            string[] specialChars = { "&", "\"", "'", "<", ">" };
            string[] qouteChars = { "&amp;", "&quot;", "&apos;", "&lt;", "&gt;" };
            for (var i = 0; i < specialChars.Length; i++)
            {
                html = html.Replace(specialChars[i], qouteChars[i]);
            }
            return html;
        }

        /**
         * 反转义HTML中特殊的字符
         *
         * @param html HTML 内容
         * @return 结果字符串
         */
        public static string UnqouteHtmlSpecialChars(string html)
        {
            if (html == null) return null;
            string[] specialChars = { "&", "\"", "'", "<", ">", " " };
            string[] qouteChars = { "&amp;", "&quot;", "&apos;", "&lt;", "&gt;", "&nbsp;" };
            for (var i = 0; i < specialChars.Count(); i++)
            {
                html = html.Replace(qouteChars[i], specialChars[i]);
            }
            return html;
        }


        /**
         * 去掉HTML标签
         *
         * @param html HTML 内容
         * @return 去除HTML标签后的结果
         */
        public static string StripHtmlSpecialChars(string html)
        {
            if (html == null) return null;
            html = Regex.Replace(html, "</?[^>]+>", "");
            html = html.Replace("&nbsp;", " ");

            return html;
        }


        /// <summary>
        /// 获取qrtoken
        /// </summary>
        /// <returns></returns>
        public static string GetQrToken(string qrsigCookieValue)
        {
            string js = "function GetToken(t) { for (var e = 0, i = 0, n = t.length; n > i; ++i) { e += (e << 5) + t.charCodeAt(i); } return 2147483647 & e; }";
            string fun = string.Format(@"GetToken('{0}')", qrsigCookieValue);
            string result = ExecuteScript(fun, js);
            return result;
        }

        /// <summary>
        /// 执行js 代码
        /// </summary>
        /// <param name="sExpression"></param>
        /// <param name="sCode"></param>
        /// <returns></returns>
        private static string ExecuteScript(string sExpression, string sCode)
        {
            Type obj = Type.GetTypeFromProgID("ScriptControl");
            if (obj == null) return "";
            object ScriptControl = Activator.CreateInstance(obj);
            obj.InvokeMember("Language", BindingFlags.SetProperty, null, ScriptControl, new object[] { "JavaScript" });
            obj.InvokeMember("AddCode", BindingFlags.InvokeMethod, null, ScriptControl, new object[] { sCode });
            return obj.InvokeMember("Eval", BindingFlags.InvokeMethod, null, ScriptControl, new object[] { sExpression }).ToString();
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
        /// <summary>
        /// 过滤文本
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string FilterText(string msg)
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
                }
            }
            return msg;
        }



    }

}
