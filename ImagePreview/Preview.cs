using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace ImagePreview
{
    public partial class Preview : Form
    {

        public string base64Image { get; set; }

        public Preview(string[] args)
        {
            InitializeComponent();
            if (args.Length > 0)
                base64Image = args[0];
        }

        private void Preview_Load(object sender, EventArgs e)
        {
            try
            {
                picBox.Image = Image.FromFile(base64Image);
            }
            catch (Exception)
            {
                this.Close();
            }
        }

    }
}
