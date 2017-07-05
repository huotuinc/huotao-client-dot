using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
    public struct WindowInfo
    {
        public IntPtr hWnd;
        public string szWindowName;
        public string szClassName;
        /// <summary>
        /// 窗口类型,1表示QQ窗口句柄，0表示微信窗口句柄，目前就这两种，默认为0
        /// </summary>
        public int winType;
    }

    public struct My_lParam
    {

        public int i;
        public string s;
    }

    public class WinApi
    {
        /// <summary>
        /// 关闭窗口
        /// </summary>
        public const int WM_CLOSE = 0x10;
        /// <summary>
        /// 往窗口发送字节数据
        /// </summary>
        const int WM_CHAR = 0X102;

        public const int keyDown = 0x0100;
        public const int keyUp = 0x0101;
        public const int VM_CHAR = 0x0102;
        //回车
        public const uint VK_RETURN = 0x0D;

        /// <summary>
        /// Left click down code 
        /// </summary>
        public const uint downCode = 0x201; // Left click down code         
        /// <summary>
        /// Left click up code 
        /// </summary>
        public const uint upCode = 0x202; // Left click up code 


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


        /// <summary>
        /// 设为前端
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        [DllImport("User32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        /// <summary>
        /// EnumWindows函数，EnumWindowsProc 为处理函数
        /// </summary>
        /// <param name="ewp">The ewp.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        private static extern int EnumWindows(EnumWindowsProc ewp, int lParam);

        public delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

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
        //[DllImport("user32.dll", EntryPoint = "SendMessage")]
        //public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, ref My_lParam lParam);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, byte[] wParam, int lParam);



        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "PostMessage")]
        public static extern int PostMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);



        //消息发送API
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(
            IntPtr hWnd,        // 信息发往的窗口的句柄
            int Msg,            // 消息ID
            uint wParam,         // 参数1
            uint lParam          //参数2
        );



        /// <summary>
        /// 获取窗口大小及位置:需要调用方法GetWindowRect(IntPtr hWnd, ref RECT lpRect)
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpRect"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);


        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        public static extern int GetWindowLong(HandleRef hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLong(HandleRef hWnd, int nIndex, int dwNewLong);



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
            char[] ch = Input.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                SendMessage(myIntPtr, WM_CHAR, ch[i], 0);
            }
        }

        public static byte[] ImageToBytes(Image image)
        {
            ImageFormat format = image.RawFormat;
            using (MemoryStream ms = new MemoryStream())
            {
                if (format.Equals(ImageFormat.Jpeg))
                {
                    image.Save(ms, ImageFormat.Jpeg);
                }
                else if (format.Equals(ImageFormat.Png))
                {
                    image.Save(ms, ImageFormat.Png);
                }
                else if (format.Equals(ImageFormat.Bmp))
                {
                    image.Save(ms, ImageFormat.Bmp);
                }
                else if (format.Equals(ImageFormat.Gif))
                {
                    image.Save(ms, ImageFormat.Gif);
                }
                else if (format.Equals(ImageFormat.Icon))
                {
                    image.Save(ms, ImageFormat.Icon);
                }
                byte[] buffer = new byte[ms.Length];
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }


        public static Image BytesToImage(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream(buffer);
            Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }

        /// <summary>
        /// 激活窗口
        /// </summary>
        /// <param name="handle">The handle.</param>
        public static RECT SetActiveWin(IntPtr handle, bool isTop = true)
        {

            RECT rc = new RECT();
            GetWindowRect(handle, ref rc);
            ////显示窗口            
            ////ShowWindow(handle, NCmdShowFlag.SW_SHOWNORMAL);
            ////if (isTop)
            ////SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, 0x0001 | 0x0002);
            ////SetForegroundWindow(handle);
            SetWeChatInputFocus(handle, rc);
            return rc;

        }
        /// <summary>
        /// 设置窗口置顶
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <param name="isTop">if set to true [is top].</param>
        public static void SetWindowTop(IntPtr handle, bool isTop)
        {
            SetWindowPos(handle, isTop ? HWND_TOPMOST : HWND_NOTOPMOST, 0, 0, 0, 0, 0x0001 | 0x0002);
            ShowWindow(handle, NCmdShowFlag.SW_SHOWMINIMIZED);
        }

        /// <summary>
        /// 设置微信聊天窗口输入框焦点
        /// </summary>
        /// <param name="rc">The rc.</param>
        public static void SetWeChatInputFocus(IntPtr handle, RECT rc)
        {
            int h = rc.Bottom - rc.Top;
            //定位微信坐标       
            IntPtr lParam = (IntPtr)((h - 80 << 16) | 20);// The coordinates                                     
            //发送点击鼠标左键
            SendMessage(handle, downCode, IntPtr.Zero, lParam); // Mouse button down             
            //发送释放鼠标左键
            SendMessage(handle, upCode, IntPtr.Zero, lParam); // Mouse button up  
        }


        /// <summary>
        /// 粘贴Ctrl+V,粘贴后需要调用回车键
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <param name="isRelease">是否释放Ctrl键</param>
        public static void Paste(IntPtr handle, bool isRelease = true)
        {
            keybd_event(Keys.LControlKey, 0, 0, 0);
            System.Threading.Thread.Sleep(50);
            SendMessage(handle, 0x0100, 0x56, 0x002F0001);
            System.Threading.Thread.Sleep(100);
            if (isRelease)
                ReleaseControlKey();
        }
        /// <summary>
        /// 释放ctrl
        /// </summary>
        public static void ReleaseControlKey()
        {
            //释放ctrl
            keybd_event(Keys.LControlKey, 0, 2, 0);
        }

        /// <summary>
        /// 回车
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <param name="isEnter">是否是Enter</param>
        public static void Enter(IntPtr handle, bool isEnter = false)
        {
            if (!isEnter)
            {
                //回车Alt+S
                SendMessage(handle, 0x0104, 0x12, 0x20380001);
                SendMessage(handle, 0x0106, 83, 0x201F0001);
                SendMessage(handle, 0x0104, 0x53, 0x201F0001);

            }
            else
            {
                SendMessage(handle, 0x0100, 0x0D, 0x001C0001);
                SendMessage(handle, 0x0102, 13, 0x001C0001);
                SendMessage(handle, 0x0101, 0x0D, 0xC01C0001);
            }
            //释放ctrl
            //ReleaseControlKey();
        }




        /// <summary>
        /// 寻找系统的全部窗口
        /// </summary>
        /// <param name="classname">微信：ChatWnd，QQ：TXGuiFoundation，如果为空，则视为全部</param>
        /// <returns>List&lt;WindowInfo&gt;.</returns>
        public static List<WindowInfo> GetAllDesktopWindows()
        {
            List<WindowInfo> wndList = new List<WindowInfo>();
            EnumWindows(delegate (IntPtr hWin, int p)
            {
                StringBuilder sb = new StringBuilder(256);
                GetClassName(hWin, sb, sb.Capacity);
                if (sb.ToString().Equals("ChatWnd") || sb.ToString().Equals("TXGuiFoundation"))
                {
                    WindowInfo wnd = new WindowInfo();
                    wnd.hWnd = hWin;
                    wnd.winType = sb.ToString().Equals("TXGuiFoundation") ? 1 : 0;
                    wnd.szClassName = sb.ToString();
                    GetWindowText(hWin, sb, sb.Capacity);
                    wnd.szWindowName = sb.ToString();
                    if (filterWindow(wnd.szWindowName, wnd.winType == 1))
                        return true;

                    if (!wndList.Exists(item => { return item.szWindowName == wnd.szWindowName && item.winType == wnd.winType; }))
                        wndList.Add(wnd);
                }
                return true;
            }, 0);
            return wndList;
        }

        /// <summary>
        /// 过滤部分窗口名称
        /// </summary>
        /// <param name="windowName"></param>
        /// <returns></returns>
        private static bool filterWindow(string windowName, bool isQQWindow)
        {
            if (string.IsNullOrEmpty(windowName))
                return true;
            //如果不是QQ窗口,则直接返回
            if (!isQQWindow)
                return false;
            if (windowName.Equals("TXMenuWindow"))
                return true;
            if (windowName.Equals("QQ"))
                return true;
            if (windowName.Equals("TIM"))
                return true;
            if (windowName.Equals("实时加速工具"))
                return true;
            if (windowName.Equals("加速小火箭"))
                return true;
            if (windowName.Equals("小火箭通用加速") || windowName.Equals("小火箭托盘加速"))
                return true;
            if (windowName.Equals("登录电脑管家") || windowName.Contains("网络流量管理"))
                return true;
            if (windowName.Equals("腾讯网迷你版"))
                return true;
            if (windowName.Contains("Attention - Charlie Puth") || windowName.Contains("Attention") || windowName.Contains("Charlie Puth"))
                return true;
            if (windowName.Equals("群通知"))
                return true;
            return false;
        }

        /// <summary>
        /// 获取桌面QQ窗口
        /// </summary>
        /// <returns></returns>
        public static List<WindowInfo> GetDesktopQQWindows()
        {
            string classname = "TXGuiFoundation";
            List<WindowInfo> wndList = new List<WindowInfo>();
            EnumWindows(delegate (IntPtr hWin, int p)
            {
                StringBuilder sb = new StringBuilder(256);
                GetClassName(hWin, sb, sb.Capacity);
                if (classname == sb.ToString())
                {
                    WindowInfo wnd = new WindowInfo();
                    wnd.hWnd = hWin;
                    wnd.winType = 1;
                    wnd.szClassName = sb.ToString();
                    GetWindowText(hWin, sb, sb.Capacity);
                    wnd.szWindowName = sb.ToString();

                    if (filterWindow(wnd.szWindowName, wnd.winType == 1))
                        return true;
                    if (!wndList.Exists(item => { return item.szWindowName == wnd.szWindowName; }))
                        wndList.Add(wnd);
                }
                return true;
            }, 0);
            return wndList;
        }
        /// <summary>
        /// 获取桌面微信窗口
        /// </summary>
        /// <returns></returns>
        public static List<WindowInfo> GetDesktopWeChatWindows()
        {
            string classname = "ChatWnd";
            List<WindowInfo> wndList = new List<WindowInfo>();
            EnumWindows(delegate (IntPtr hWin, int p)
            {
                StringBuilder sb = new StringBuilder(256);
                GetClassName(hWin, sb, sb.Capacity);
                if (classname == sb.ToString())
                {
                    WindowInfo wnd = new WindowInfo();
                    wnd.hWnd = hWin;
                    wnd.winType = 0;
                    wnd.szClassName = sb.ToString();
                    GetWindowText(hWin, sb, sb.Capacity);
                    wnd.szWindowName = sb.ToString();

                    if (filterWindow(wnd.szWindowName, wnd.winType == 1))
                        return true;

                    if (!wndList.Exists(item => { return item.szWindowName == wnd.szWindowName; }))
                        wndList.Add(wnd);
                }
                return true;
            }, 0);
            return wndList;
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
        /// <summary>
        /// 在前面, 位于任何顶部窗口的前面
        /// </summary>
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        /// <summary>
        /// 在前面, 位于其他顶部窗口的后面
        /// </summary>
        public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        /// <summary>
        /// 在后面
        /// </summary>
        public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

        /// <summary>
        /// 置顶
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="hWndInsertAfter">The h WND insert after.</param>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <param name="cx">The cx.</param>
        /// <param name="cy">The cy.</param>
        /// <param name="uFlags">The u flags.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);













        //无标题窗体右键菜单
        private const int WS_SYSMENU = 0x00080000; // 系统菜单
        private const int WS_MINIMIZEBOX = 0x20000; // 最大最小化按钮

        //下面几个是设置窗口阴影
        private const int CS_DropSHADOW = 0x20000;
        private const int GCL_STYLE = (-26);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetClassLong(IntPtr hwnd, int nIndex);


        /// <summary>
        /// 无边框样式的winform窗口，需要单独设置，才能启用任务栏的系统菜单功能，
        /// </summary>
        public static void SetWinFormTaskbarSystemMenu(Form from)
        {
            int windowLong = (GetWindowLong(new HandleRef(from, from.Handle), -16));
            SetWindowLong(new HandleRef(from, from.Handle), -16, windowLong | WS_SYSMENU | WS_MINIMIZEBOX);
            //设置阴影
            SetClassLong(from.Handle, GCL_STYLE, GetClassLong(from.Handle, GCL_STYLE) | CS_DropSHADOW);
        }




    }
}
