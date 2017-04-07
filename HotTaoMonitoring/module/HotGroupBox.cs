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
    public partial class HotGroupBox : System.Windows.Forms.GroupBox
    {
        public HotGroupBox()
        {
            InitializeComponent();
        }

        public HotGroupBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private Color _borderColor = Color.Gainsboro;

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


        private Color _borderTitleColor = Color.Black;

        [Description("边框颜色")]
        public Color BorderTitleColor
        {
            get
            {
                return _borderTitleColor;
            }

            set
            {
                _borderTitleColor = value;
            }
        }
               

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GroupBox gbx = this;// as GroupBox;
            e.Graphics.Clear(gbx.BackColor);

            Pen p = new Pen(BorderColor, 1);
            int w = gbx.Width;
            int h = gbx.Height;
            Brush b = null;
            if (gbx.Parent != null)
                b = new SolidBrush(gbx.Parent.BackColor);
            else
                b = new SolidBrush(this.BackColor);

            e.Graphics.DrawLine(p, 3, h - 1, w - 4, h - 1);                     //bottom
            e.Graphics.DrawLine(p, 0, h - 4, 0, 12);                            //left
            e.Graphics.DrawLine(p, w - 1, h - 4, w - 1, 12);                    //right
            e.Graphics.FillRectangle(b, 0, 0, w, 8);
            e.Graphics.DrawLine(p, 3, 8, 10, 8);                                //lefg top
            e.Graphics.DrawLine(p, e.Graphics.MeasureString(gbx.Text, gbx.Font).Width + 8, 8, w - 4, 8);

            Brush btitle = new SolidBrush(BorderTitleColor);
            //绘制文字
            e.Graphics.DrawString(gbx.Text, gbx.Font, btitle, 10, 0);     //title

            e.Graphics.DrawArc(p, new Rectangle(0, 8, 10, 10), 180, 90);        //left top
            e.Graphics.DrawArc(p, new Rectangle(w - 11, 8, 10, 10), 270, 90);   //right top
            e.Graphics.DrawArc(p, new Rectangle(0, h - 11, 10, 10), 90, 90);    //left bottom
            e.Graphics.DrawArc(p, new Rectangle(w - 11, h - 11, 10, 10), 0, 90);//right bottom
        }
    }
}
