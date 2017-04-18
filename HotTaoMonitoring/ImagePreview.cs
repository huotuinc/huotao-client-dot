using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotTaoMonitoring
{
    public partial class ImagePreview : Form
    {
        public ImagePreview()
        {
            InitializeComponent();
        }


        private void ImagePreview_Load(object sender, EventArgs e)
        {
            
        }


        public void ShowPreview(Image image)
        {
            if (this.pictureBox1.InvokeRequired)
            {
                this.pictureBox1.Invoke(new Action<Image>(ShowPreview), new object[] { image });
            }
            else
            {
                pictureBox1.Image = image;
            }
           
        }
    }
}
