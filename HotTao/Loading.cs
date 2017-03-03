using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotTao
{
    public partial class Loading : Form
    {
        private Main hotForm { get; set; }
        public Loading()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 关闭
        /// </summary>
        public void CloseForm()
        {
            this.BeginInvoke((Action)(delegate ()  //等待结束
            {
                this.Close();
            }));
        }
    }
}
