using DemoLib;
using HotJoinImage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DemoTest.Test1();
        }
        /// <summary>
        /// 三合一
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            DemoTest.Test3();
        }

        /// <summary>
        /// 二合一
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DemoTest.Test2();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DemoTest.Test4();
        }
    }
}
