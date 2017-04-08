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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotTaoMonitoring
{
    public struct WindowInfo
    {
        public IntPtr hWnd;
        public string szWindowName;
        public string szClassName;
    }
    public class WinApi
    {

        //无标题窗体右键菜单
        private const int WS_SYSMENU = 0x00080000; // 系统菜单
        private const int WS_MINIMIZEBOX = 0x20000; // 最大最小化按钮
        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        private static extern IntPtr SetWindowLong(HandleRef hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        private static extern int GetWindowLong(HandleRef hWnd, int nIndex);

        //下面几个是设置窗口阴影
        private const int CS_DropSHADOW = 0x20000;
        private const int GCL_STYLE = (-26);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetClassLong(IntPtr hwnd, int nIndex);



        /// <summary>
        /// EnumWindows函数，EnumWindowsProc 为处理函数
        /// </summary>
        /// <param name="ewp">The ewp.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        private static extern int EnumWindows(EnumWindowsProc ewp, int lParam);

        public delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);



        /// <summary>
        /// 获取窗口标题
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpString"></param>
        /// <param name="nMaxCount"></param>
        /// <returns></returns>
        [DllImport("user32", SetLastError = true)]
        private static extern int GetWindowText(
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
        private static extern int GetClassName(
            IntPtr hWnd,//句柄
            StringBuilder lpString, //类名
            int nMaxCount //最大值
            );


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



        /// <summary>
        /// 寻找系统的全部窗口
        /// </summary>
        /// <param name="classname">ChatWnd</param>
        /// <returns>List&lt;WindowInfo&gt;.</returns>
        public static List<WindowInfo> GetAllDesktopWindows(string classname = "ChatWnd")
        {
            List<WindowInfo> wndList = new List<WindowInfo>();
            EnumWindows(delegate (IntPtr hWin, int p)
            {
                StringBuilder sb = new StringBuilder(256);
                GetClassName(hWin, sb, sb.Capacity);
                if (classname == sb.ToString())
                {
                    WindowInfo wnd = new WindowInfo();
                    wnd.hWnd = hWin;
                    wnd.szClassName = sb.ToString();
                    GetWindowText(hWin, sb, sb.Capacity);
                    wnd.szWindowName = sb.ToString();

                    if (!wndList.Exists(item => { return item.szWindowName == wnd.szWindowName; }))
                        wndList.Add(wnd);
                }
                return true;
            }, 0);
            return wndList;
        }


    }
}
