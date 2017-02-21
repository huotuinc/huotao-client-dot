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
using System.Drawing;
using System.Linq;
using System.Text;

namespace HotTao
{
    /// <summary>
    /// 常量和静态变量
    /// </summary>
    public class ConstConfig
    {
        /// <summary>
        /// DataGridView 行高
        /// </summary>
        public const int DataGridViewRowHeight = 40;

        /// <summary>
        /// DataGridView 字体颜色
        /// </summary>
        public static Color DataGridViewRowForeColor = Color.FromArgb(180, 180, 180);

        /// <summary>
        /// DataGridViewRow  偶数行背景颜色值
        /// </summary>
        public static Color DataGridViewEvenRowBackColor = Color.FromArgb(248, 248, 248);
        /// <summary>
        /// DataGridViewRow  奇数行背景颜色值
        /// </summary>
        public static Color DataGridViewOddRowBackColor = Color.FromArgb(255, 255, 255);
    }
}
