using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotTaoSquare
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {                
                const int WS_EX_TOOLWINDOW = 0x80;
                CreateParams cp = base.CreateParams;                
                cp.ExStyle |= WS_EX_TOOLWINDOW;      // 不显示在Alt-Tab
                return cp;
            }
        }
                
    }
}
