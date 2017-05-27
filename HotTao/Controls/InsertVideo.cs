using CefSharp;
using CefSharp.WinForms;
using HotCoreUtils.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotTao.Controls
{
    public partial class InsertVideo : Form
    {

        /// <summary>
        /// 
        /// </summary>
        private Main hotForm { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public string itemId { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public int gid { get; set; }


        public InsertVideo(Main form)
        {
            hotForm = form;
            InitializeComponent();
        }

        private static string ext { get; set; }

        private string sourceFileName { get; set; }

        private void btnOpenUrl_Click(object sender, EventArgs e)
        {
            if (this.openInsertVideo.ShowDialog() == DialogResult.OK)
            {
                var ret = this.openInsertVideo.SafeFileName.Split('.');
                ext = ret[ret.Length - 1];
                using (Stream stream = this.openInsertVideo.OpenFile())
                {
                    long v = stream.Length / 1024 / 1024;
                    if (v < 20)
                    {
                        sourceFileName = this.openInsertVideo.FileName;
                        this.lbPath.Text = this.openInsertVideo.SafeFileName;
                    }
                    else
                    {
                        this.lbPath.Text = "文件太大";
                    }
                }
            }
            this.openInsertVideo.Dispose();
        }


        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 开始上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(sourceFileName))
            {
                string fileName = Environment.CurrentDirectory + "\\temp\\video\\" + MyUserInfo.currentUserId.ToString();
                if (!Directory.Exists(fileName))
                    Directory.CreateDirectory(fileName);
                fileName += "\\" + EncryptHelper.MD5(itemId) + "." + ext;
                File.Copy(sourceFileName, fileName, true);
                //TODO:将视频文件路径保存到数据库中
                sourceFileName = string.Empty;
                MessageAlert alert = new MessageAlert("上传成功");
                alert.Show(this);
            }
        }
    }
}
