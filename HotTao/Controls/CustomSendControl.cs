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



        private void CustomSendControl_Load(object sender, EventArgs e)
        {
            if (MyUserInfo.currentUserId > 0)
                ReloadWeChat();
            else
                hotForm.openControl(new LoginControl(hotForm));

        }

        /// <summary>
        /// 加载微信窗口
        /// </summary>
        private void ReloadWeChat()
        {
            lbWeChat.Items.Clear();

            List<WindowInfo> wins = WinApi.GetAllDesktopWindows();
            if (wins == null || wins.Count() == 0)
            {
                return;
            }
            foreach (WindowInfo win in wins)
            {
                lbWeChat.Items.Add(win.szWindowName);
            }
        }

        private List<string> selecctItems = new List<string>();
        private bool Running = false;

        /// <summary>
        /// 开始发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartSend_Click(object sender, EventArgs e)
        {
            if (Running)
            {
                MessageAlert alert = new MessageAlert("正在发送，请稍后...");
                alert.StartPosition = FormStartPosition.CenterScreen;
                alert.Show();
                return;
            }
            List<WindowInfo> wins = WinApi.GetAllDesktopWindows();
            if (wins == null || wins.Count() == 0)
            {
                MessageAlert alert = new MessageAlert("未找到聊天窗口");
                alert.StartPosition = FormStartPosition.CenterScreen;
                alert.Show();
                return;
            }
            selecctItems.Clear();
            foreach (var item in lbWeChat.SelectedItems)
            {
                selecctItems.Add(item.ToString());
            }
            if (selecctItems.Count() == 0)
            {
                MessageAlert alert = new MessageAlert("请选择发送目标");
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
            ShowAlert("正在发送，请稍后...");
            Running = true;
            thread = new System.Threading.Thread(() =>
           {
               try
               {
                   //发送图片
                   SendFile(wins, PicFilePath);

                   //发送文本
                   SendText(wins, sendText);

                   //发送视频文件
                   SendFile(wins, VideoFilePath, true);

                   ShowAlert("发送完成");
                   Running = false;
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


        private void ShowAlert(string text)
        {
            if (this.lbMsg.InvokeRequired)
            {
                this.lbMsg.Invoke(new Action<string>(ShowAlert), new object[] { text });
            }
            else
            {
                this.lbMsg.Text = text;
            }
        }






        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="wins"></param>
        private void SendFile(List<WindowInfo> wins, string path, bool isVideo = false)
        {
            if (string.IsNullOrEmpty(path)) return;

            bool success = false;
            try
            {
                if (isVideo)
                {
                    CopyFileToClipboard(path);
                    success = true;
                }
                else
                {
                    using (Stream stream = new FileStream(path, FileMode.Open))
                    {
                        Image image = Image.FromStream(stream);
                        if (image != null)
                        {
                            Clipboard.SetImage(image);
                            success = true;
                        }
                    }
                }
                if (!success) return;
                //停止1秒
                System.Threading.Thread.Sleep(1000);
                foreach (var win in wins)
                {
                    if (selecctItems.Exists(t => { return win.szWindowName == t; }))
                    {
                        //复制粘贴发送
                        WinApi.SendData(win.hWnd, win.winType == 1);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 发送文本
        /// </summary>
        /// <param name="wins"></param>
        private void SendText(List<WindowInfo> wins, string sendText)
        {
            if (string.IsNullOrEmpty(sendText)) return;
            Clipboard.SetDataObject(sendText);
            //停止1秒
            System.Threading.Thread.Sleep(1000);
            foreach (var win in wins)
            {
                if (selecctItems.Exists(t => { return win.szWindowName == t; }))
                {
                    //复制粘贴发送
                    WinApi.SendData(win.hWnd, win.winType == 1);
                }
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

        /// <summary>
        /// 刷新微信窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lkbRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ReloadWeChat();
        }
        /// <summary>
        /// 全部选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lkbAllSelected_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < lbWeChat.Items.Count; i++)
            {
                lbWeChat.SetSelected(i, true);
            }
        }
    }
}
