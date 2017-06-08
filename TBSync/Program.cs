using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TBSync
{
    static class Program
    {
        static Logger log = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                //处理未捕获的异常   
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

                //处理UI线程异常   
                Application.ThreadException += Application_ThreadException;

                //处理非UI线程异常   
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoginWindow());
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
                MessageBox.Show("系统出现未知异常，请重启系统！");
            }
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            if (ex != null)
                log.Error(ex);
            MessageBox.Show("系统出现未知异常，请重启系统！");
            //Application.ExitThread();
            //Environment.Exit(Environment.ExitCode);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            var ex = e.Exception;
            if (ex != null)
                log.Error(ex);
            MessageBox.Show("系统出现未知异常，请重启系统！");
            //Application.ExitThread();
            //Environment.Exit(Environment.ExitCode);
        }
    } 
}
