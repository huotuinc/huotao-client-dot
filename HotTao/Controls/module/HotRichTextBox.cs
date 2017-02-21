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
using System.Windows.Forms;

namespace HotTao.Controls.module
{
    public class HotRichTextBox : RichTextBox
    {
        private RichTextBox richTextBox1;
        public HotRichTextBox()
        {
            richTextBox1 = this;
        }
        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, ref Rect lParam);
        private const int EM_GETRECT = 0x00b2;
        private const int EM_SETRECT = 0x00b3;

        private Rect RichTextBoxMargin
        {
            get
            {
                Rect rect = new Rect();
                SendMessage(richTextBox1.Handle, EM_GETRECT, IntPtr.Zero, ref rect);
                rect.Left += 1;
                rect.Top += 1;
                rect.Right = 1 + richTextBox1.DisplayRectangle.Width - rect.Right;
                rect.Bottom = richTextBox1.DisplayRectangle.Height - rect.Bottom;
                return rect;
            }
            set
            {
                Rect rect= new Rect(); 
                rect.Left = richTextBox1.ClientRectangle.Left + value.Left;
                rect.Top = richTextBox1.ClientRectangle.Top + value.Top;
                rect.Right = richTextBox1.ClientRectangle.Right - value.Right;
                rect.Bottom = richTextBox1.ClientRectangle.Bottom - value.Bottom;
                SendMessage(richTextBox1.Handle, EM_SETRECT, IntPtr.Zero, ref rect);
            }
        }
    }
}
