using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace HotTao
{

    /// <summary>
    /// 句柄坐标
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left; //最左坐标
        public int Top; //最上坐标
        public int Right; //最右坐标
        public int Bottom; //最下坐标
    }

    public class WinApi
    {
        /// <summary>
        /// 关闭窗口
        /// </summary>
        const int WM_CLOSE = 0x10;
        /// <summary>
        /// 往窗口发送字节数据
        /// </summary>
        const int WM_CHAR = 0X102;
        /// <summary>
        /// 获取窗口句柄
        /// </summary>
        /// <param name="ClassN">窗口类名</param>
        /// <param name="WindN">窗口名</param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string ClassN, string WindN);

        /// <summary>
        /// 获取子窗口句柄
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="childe"></param>
        /// <param name="strclass"></param>
        /// <param name="strname"></param>
        /// <returns></returns>
        [DllImport("User32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parent, IntPtr childe, string strclass, string strname);

        /**
          * n CmdShow的含义
          * 0 隐藏窗口
          * 1 正常大小显示窗口
          * 2 最小化窗口
          * 3 最大化窗口
          * 使用实例: ShowWindow(myPtr, 0);
          */
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int ShowWindow(IntPtr hwnd, NCmdShowFlag nCmdShow);


        //此处用于向窗口发送消息
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        /// <summary>
        /// 获取窗口大小及位置:需要调用方法GetWindowRect(IntPtr hWnd, ref RECT lpRect)
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpRect"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        /// <summary>
        /// 将枚举作为位域处理
        /// </summary>
        [Flags]
        public enum MouseEventFlag : uint //设置鼠标动作的键值
        {
            Move = 0x0001,               //发生移动
            LeftDown = 0x0002,           //鼠标按下左键
            LeftUp = 0x0004,             //鼠标松开左键
            RightDown = 0x0008,          //鼠标按下右键
            RightUp = 0x0010,            //鼠标松开右键
            MiddleDown = 0x0020,         //鼠标按下中键
            MiddleUp = 0x0040,           //鼠标松开中键
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,              //鼠标轮被移动
            VirtualDesk = 0x4000,        //虚拟桌面
            Absolute = 0x8000
        }
        /// <summary>
        /// 窗口显示枚举
        /// </summary>
        [Flags]
        public enum NCmdShowFlag : int
        {
            /// <summary>
            /// 隐藏窗口
            /// </summary>
            SW_HIDE = 0,
            /// <summary>
            /// 正常大小显示窗口
            /// </summary>
            SW_SHOWNORMAL = 1,
            /// <summary>
            /// 最小化窗口
            /// </summary>
            SW_SHOWMINIMIZED = 2,
            /// <summary>
            /// 最大化窗口
            /// </summary>
            SW_SHOWMAXIMIZED = 3,
        }

        /// <summary>
        /// 获取微信主窗口句柄
        /// </summary>
        /// <returns></returns>
        public static IntPtr GetWeChatWindow()
        {
            return FindWindow("WeChatMainWndForPC", null); //获取当前窗口句柄 ChatWnd //WeChatMainWndForPC
        }
        /// <summary>
        /// 获取微信单独子窗口句柄（必须单独出来的窗口）
        /// </summary>
        /// <returns></returns>
        public static IntPtr GetWeChatWindowEx()
        {
            return FindWindow("ChatWnd", null);
        }

        /// <summary>
        /// 获取窗口标题
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpString"></param>
        /// <param name="nMaxCount"></param>
        /// <returns></returns>
        [DllImport("user32", SetLastError = true)]
        public static extern int GetWindowText(
            IntPtr hWnd,//窗口句柄
            StringBuilder lpString,//标题
            int nMaxCount //最大值
            );


        /// <summary>
        /// 获取类的名字
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpString"></param>
        /// <param name="nMaxCount"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetClassName(
            IntPtr hWnd,//句柄
            StringBuilder lpString, //类名
            int nMaxCount //最大值
            );

        /// <summary>
        /// 根据坐标获取窗口句柄
        /// </summary>
        /// <param name="Point"></param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern IntPtr WindowFromPoint(Point Point);

        /// <summary>
        /// 获取子窗口句柄的委托
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public delegate bool WNDENUMPROC(IntPtr hWnd, int lParam);

        /// <summary>
        /// 获取子窗口句柄
        /// </summary>
        /// <param name="hwndParent"></param>
        /// <param name="lpEnumFunc"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern bool EnumChildWindows(IntPtr hwndParent, WNDENUMPROC lpEnumFunc, int lParam);

        /// <summary>
        /// 设置鼠标的位置
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        /// <summary>
        /// 设置鼠标按键和动作
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="data"></param>
        /// <param name="extraInfo"></param>
        [DllImport("user32.dll")]
        public static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo); //UIntPtr指针多句柄类型

        /// <summary>
        /// 模拟键盘的方法
        /// </summary>
        /// <param name="bVk"></param>
        /// <param name="bScan"></param>
        /// <param name="dwFlags"></param>
        /// <param name="dwExtraInfo"></param>
        [DllImport("user32.dll")]
        public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);


        /// <summary>
        /// 模拟按移动轨迹鼠标，结束后左键
        /// </summary>
        /// <param name="endPosition">结束坐标</param>
        /// <param name="MousePosition">鼠标坐标</param>
        /// <param name="count">时间</param>
        /// <param name="isMouseLeftUp">是否松开左键</param>
        /// <param name="callback">结束后回调</param>
        /// <returns></returns>
        public static int mouseAnimation(Point endPosition, Point MousePosition, int count, bool isMouseLeftUp, Action<Point> callback)
        {
            try
            {
                int stepx = (endPosition.X - MousePosition.X) / count;
                int stepy = (endPosition.Y - MousePosition.Y) / count;
                count--;
                if (count == 0)
                {
                    mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
                    if (isMouseLeftUp)
                        mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
                    callback?.Invoke(endPosition);
                    return count;
                }
                mouse_event(MouseEventFlag.Move, stepx, stepy, 0, UIntPtr.Zero);
                return count;
            }
            catch (Exception)
            {
                mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
                if (isMouseLeftUp)
                    mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
                callback?.Invoke(endPosition);
                return 0;
            }
        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="hWnd"></param>
        public static void CloseWindow(IntPtr hWnd)
        {
            SendMessage(hWnd, WM_CLOSE, 0, 0);
        }


        /// <summary>
        　/// 发送一个字符串
        　/// </summary>
        　/// <param name="myIntPtr">窗口句柄</param>
        　/// <param name="Input">字符串</param>
        public static void InputStr(IntPtr myIntPtr, string Input)
        {
            byte[] ch = (Encoding.ASCII.GetBytes(Input));
            for (int i = 0; i < ch.Length; i++)
            {
                SendMessage(myIntPtr, WM_CHAR, ch[i], 0);
            }
        }

        /// <summary>
        /// 发送一张图片
        /// </summary>
        /// <param name="myIntPtr">发送对象句柄</param>
        /// <param name="picUrl"> pic URL.</param>
        public static void InputImage(IntPtr myIntPtr, string picUrl)
        {
            byte[] data = GetNetWorkImageData(picUrl);
            if (data != null)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    SendMessage(myIntPtr, WM_CHAR, data[i], 0);
                }
            }
        }


        /// <summary>
        /// 获取网络图片数据
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>System.Byte[].</returns>
        private static byte[] GetNetWorkImageData(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "get";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream response_stream = response.GetResponseStream();
                int count = (int)response.ContentLength;
                int offset = 0;
                byte[] buf = new byte[count];
                while (count > 0)  //读取返回数据
                {
                    int n = response_stream.Read(buf, offset, count);
                    if (n == 0) break;
                    count -= n;
                    offset += n;
                }
                return buf;
            }
            catch
            {
                return null;
            }
        }
    }
}
