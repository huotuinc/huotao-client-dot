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

        /// <summary>
        /// 数据库连接字符串（默认MssqlDBConnectionString）
        /// </summary>
        /// <returns>返回连接字符串</returns>
        public static string getConnectionString()
        {
            return "Data Source=192.168.1.210; Database=HotTaoHelper;User ID=wxroot;Password=wxroot@1234;";// ConfigHelper.MssqlDBConnectionString;
        }

        /// <summary>
        /// 监听地址
        /// </summary>
        /// <returns></returns>
        public static string listenUrl()
        {
            return ConfigHelper.GetConfigString("listenUrl");
        }

    }
}
