using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace HotTao.Controls.module
{
    public partial class HotButton : Component
    {
        public HotButton()
        {
            InitializeComponent();
        }

        public HotButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
