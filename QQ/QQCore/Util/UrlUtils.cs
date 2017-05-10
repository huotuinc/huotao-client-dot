using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace iQQ.Net.WebQQCore.Util
{
    public class UrlUtils
    {
        public static string GetOrigin(string url)
        {
            return url.Substring(0, url.LastIndexOf("/"));
        }


        /// <summary>
        /// 返回指定内容中的url数量
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<string> GetUrls(string input)
        {
            string pattern = "http[s]?://.*?(?!(\\w|\\.|/|\\?|\\=|&|%))";
            List<string> urls = new List<string>();
            foreach (Match match in Regex.Matches(input, pattern))
            {
                if (!urls.Contains(match.Value))
                    urls.Add(match.Value);
            }
            return urls;
        }
    }
}
