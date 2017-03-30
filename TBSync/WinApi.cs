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

namespace TBSync
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
        /// Left click down code 
        /// </summary>
        public const uint downCode = 0x201; // Left click down code         
        /// <summary>
        /// Left click up code 
        /// </summary>
        public const uint upCode = 0x202; // Left click up code 



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
        /// 获取窗口句柄
        /// </summary>
        /// <param name="ClassN">窗口类名</param>
        /// <param name="WindN">窗口名</param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string ClassN, string WindN);
        /// <summary>
        /// 获取窗口大小及位置:需要调用方法GetWindowRect(IntPtr hWnd, ref RECT lpRect)
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpRect"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// 获取淘宝登录窗口
        /// </summary>
        /// <returns></returns>
        public static IntPtr GetTaobaoLoginWindowEx()
        {
            return FindWindow("WindowsForms10.Window.8.app.0.141b42a_r14_ad1", null);
        }

        /// <summary>
        /// 激活窗口
        /// </summary>
        /// <param name="handle">The handle.</param>
        public static RECT SetActiveWin(IntPtr handle)
        {
            RECT rc = new RECT();
            GetWindowRect(handle, ref rc);

            int h = rc.Top;
            //定位微信坐标       
            IntPtr lParam = (IntPtr)((h + 45 << 16) | 160);// The coordinates    

            SetInputFocus(handle, lParam);

            return rc;

        }
        /// <summary>
        /// 设置微信聊天窗口输入框焦点
        /// </summary>
        /// <param name="rc">The rc.</param>
        public static void SetInputFocus(IntPtr handle, IntPtr lParam)
        {       
            //发送点击鼠标左键
            SendMessage(handle, downCode, IntPtr.Zero, lParam); // Mouse button down 
            //发送释放鼠标左键
            SendMessage(handle, upCode, IntPtr.Zero, lParam); // Mouse button up  
        }
    }
}
