using HotTao.Controls;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HotTao
{
    static class Program
    {

        static Logger log = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.ThreadException += Application_ThreadException;
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
            catch (Exception ex)
            {
                string str = "";
                string strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now.ToString() + "\r\n";

                if (ex != null)
                {
                    str = string.Format(strDateInfo + "异常类型：{0}\r\n异常消息：{1}\r\n异常信息：{2}\r\n",
                         ex.GetType().Name, ex.Message, ex.StackTrace);
                }
                else
                {
                    str = string.Format("应用程序线程错误:{0}", ex);
                }
                log.Error(str);
                MessageAlert alert = new MessageAlert("发生致命错误，请及时联系客户！", "系统错误");
                alert.ShowDialog();
            }
        }



        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                log.Error(ex);
            }
            catch
            {
                MessageAlert alert = new MessageAlert("系统异常，应用程序将退出！！", "错误提示");
                alert.ShowDialog();
                Application.ExitThread();
                Environment.Exit(Environment.ExitCode);
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                log.Error(e.Exception);                
            }
            catch(Exception ex)
            {
                log.Error(ex);
                MessageAlert alert = new MessageAlert("系统异常，应用程序将退出！！", "错误提示");
                alert.ShowDialog();
                Application.ExitThread();
                Environment.Exit(Environment.ExitCode);
            }
        }
    }
}
