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
    public partial class SetAutoReplyControl : UserControl
    {
        private Main hotForm { get; set; }
        public SetAutoReplyControl(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }




        public void Save()
        {

        }
    }
}
