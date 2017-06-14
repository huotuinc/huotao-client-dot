using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections.Specialized;

namespace HotTao.Controls
{
    public partial class CustomSendControl : UserControl
    {

        private Main hotForm { get; set; }

        public CustomSendControl(Main form)
        {
            InitializeComponent();
            this.hotForm = form;
        }


        private static string ext { get; set; }
        private string sourceFileName { get; set; }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Tag.ToString().Equals("pic"))
            {
                if (this.openFileImage.ShowDialog() == DialogResult.OK)
                {
                    txtPicPath.Text = openFileImage.FileName;
                }
                this.openFileImage.Dispose();
            }
            else
            {
                if (this.openFileVideo.ShowDialog() == DialogResult.OK)
                {
                    var ret = this.openFileVideo.SafeFileName.Split('.');
                    ext = ret[ret.Length - 1];
                    using (Stream stream = this.openFileVideo.OpenFile())
                    {
                        long v = stream.Length / 1024 / 1024;
                        if (v < 20)
                        {
                            this.txtVideoPath.Text = this.openFileVideo.FileName;
                        }
                        else
                        {
                            MessageAlert alert = new MessageAlert("视频文件最大不能超过20M");
                            alert.Show();
                        }
                    }
                }
                this.openFileVideo.Dispose();
            }
        }


        private System.Threading.Thread thread { get; set; }

        /// <summary>
        /// 开始发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartSend_Click(object sender, EventArgs e)
        {
            List<WindowInfo> wins = WinApi.GetAllDesktopWindows();
            if (wins == null || wins.Count() == 0)
            {
                MessageAlert alert = new MessageAlert("未找到微信聊天窗口");
                alert.StartPosition = FormStartPosition.CenterScreen;
                alert.Show();
                return;
            }

            string PicFilePath = txtPicPath.Text;
            string VideoFilePath = txtVideoPath.Text;
            string sendText = txtTempText.Text;

            if (thread != null)
            {
                thread.Abort();
                thread = null;
            }
            thread = new System.Threading.Thread(() =>
           {
               try
               {

                   //发送图片
                   SendFile(wins, PicFilePath);

                   //发送文本
                   SendText(wins, sendText);

                   //发送视频文件
                   SendFile(wins, VideoFilePath);
               }
               catch (System.Threading.ThreadAbortException)
               {
               }
               catch (Exception ex)
               {

               }
           });
            thread.IsBackground = true;
            thread.TrySetApartmentState(System.Threading.ApartmentState.STA);
            thread.Start();
        }

        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="wins"></param>
        private void SendFile(List<WindowInfo> wins, string path)
        {
            if (string.IsNullOrEmpty(path)) return;
            //复制文件
            CopyFileToClipboard(path);
            //停止1秒
            System.Threading.Thread.Sleep(1000);

            foreach (var win in wins)
            {
                WinApi.SetActiveWin(win.hWnd);
                System.Threading.Thread.Sleep(400);
                WinApi.Paste(win.hWnd);
                System.Threading.Thread.Sleep(400);
                WinApi.Enter(win.hWnd);
                System.Threading.Thread.Sleep(400);
            }
        }

        /// <summary>
        /// 发送文本
        /// </summary>
        /// <param name="wins"></param>
        private void SendText(List<WindowInfo> wins, string sendText)
        {
            if (string.IsNullOrEmpty(sendText)) return;
            Clipboard.SetText(sendText);
            //停止1秒
            System.Threading.Thread.Sleep(1000);
            foreach (var win in wins)
            {
                WinApi.SetActiveWin(win.hWnd);
                System.Threading.Thread.Sleep(400);
                WinApi.Paste(win.hWnd);
                System.Threading.Thread.Sleep(300);
                WinApi.Enter(win.hWnd);
                System.Threading.Thread.Sleep(400);
            }
        }



        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="path"></param>
        private void CopyFileToClipboard(string path)
        {
            StringCollection sc = new StringCollection();
            sc.Add(path);
            Clipboard.SetFileDropList(sc);
        }
    }
}
