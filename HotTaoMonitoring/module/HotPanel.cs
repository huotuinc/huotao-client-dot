using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HotTaoMonitoring.module
{
    public partial class HotPanel : Panel
    {
        public HotPanel()
        {
            InitializeComponent();
        }


        private Color _borderColor = Color.FromArgb(238, 238, 238);

        [Description("边框颜色")]
        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }

            set
            {
                _borderColor = value;


            }
        }


        public HotPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //this.BorderStyle = BorderStyle.FixedSingle;
            ControlPaint.DrawBorder(e.Graphics,
                                this.ClientRectangle,
                                BorderColor,//7f9db9
                                1,
                                ButtonBorderStyle.Solid,
                                BorderColor,
                                1,
                                ButtonBorderStyle.Solid,
                                BorderColor,
                                1,
                                ButtonBorderStyle.Solid,
                                BorderColor,
                                1,
                                ButtonBorderStyle.Solid);

            //Pen p = new Pen(BorderColor, 0);
            //e.Graphics.DrawRectangle(p, 0, 0, this.Width - 1, this.Height - 1);

            //Rectangle rec = new Rectangle(0, 0, this.Width - 1, this.Height - 1);            
        }
    }
}
