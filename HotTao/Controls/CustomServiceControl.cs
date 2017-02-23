using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HotTao.Controls
{
    public partial class CustomServiceControl : UserControl
    {

        private Main hotForm { get; set; }

        public CustomServiceControl(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }
    }
}
