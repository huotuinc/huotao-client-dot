using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace HOTReuestService.Helper
{
    /// <summary>
    /// 日志标识
    /// </summary>
    public enum LogHelperTag
    {
        /// <summary>
        /// debug
        /// </summary>
        DEBUG = 0,
        /// <summary>
        /// info
        /// </summary>
        INFO = 1,
        /// <summary>
        /// error
        /// </summary>
        ERROR = 2
    }
    /// <summary>
    /// 日志帮助类
    /// </summary>
    public class LogHelper
    {
        private LogHelper() { }
        #region 日志写入
        private static Object LogObject = null;

        /// <summary>
        /// 日志，用户外面控制输出环境
        /// </summary>
        /// <param name="content"></param>
        /// <param name="tag"></param>
        /// <param name="DebugMode">true：debug模式，false：release模式,默认true，</param>
        public static void Log(string content, LogHelperTag tag = LogHelperTag.DEBUG, bool DebugMode = true)
        {
            if (DebugMode)
            {
                if (LogObject == null)
                    LogObject = new object();
                lock (LogObject)
                {
                    WriteLog(tag.ToString(), content);
                }
            }
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="content"></param>
        private static void WriteLog(string tag, object content)
        {
            DateTime date = DateTime.Now;
            string logPath = "Log";
            string logPathFull = null;

            logPathFull = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logPath);


            //判断文件目录是否存在
            if (!System.IO.Directory.Exists(logPathFull))
                System.IO.Directory.CreateDirectory(logPathFull);

            string logFile = logPathFull + System.IO.Path.DirectorySeparatorChar.ToString() + date.ToString("yyyy-MM-dd") + "-" + tag + ".log";

            //判断文件是否存在
            if (!File.Exists(logFile))
            {
                File.Create(logFile).Close();
            }
            StreamWriter rw = new StreamWriter(logFile, true, System.Text.Encoding.Default);
            rw.WriteLine(string.Format(@"{0},{1} {2} {3}", date.ToString(), date.Millisecond, tag, content));
            rw.Flush();
            rw.Close();
        }
        #endregion
    }
}
