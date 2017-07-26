using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace update
{
    public partial class CheckUpdate : Form
    {
        public CheckUpdate()
        {
            InitializeComponent();
        }

        private void CheckUpdate_Load(object sender, EventArgs e)
        {
            if (MessageBox.Show("请确保发单高手已退出?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                downLoadZip();
            }
            else
                this.Close();

        }



        private void downLoadZip()
        {
            string url = "http://www.51huotao.com/software/upgrade/latest";
            DownloadFile(url, @"download.zip");
        }
        private void SetMsg(string text)
        {
            if (this.lbMsg.InvokeRequired)
            {
                this.lbMsg.Invoke(new Action<string>(SetMsg), new object[] { text });
            }
            else
            {
                lbMsg.Text = text;

            }
        }



        private void SetLog(string text)
        {
            if (this.txtLog.InvokeRequired)
            {
                this.txtLog.Invoke(new Action<string>(SetLog), new object[] { text });
            }
            else
            {
                txtLog.AppendText(text + "\r\n");
                txtLog.ScrollToCaret();
            }
        }


        private void SetProgMaximum(int total)
        {
            if (this.progressBar1.InvokeRequired)
            {
                this.progressBar1.Invoke(new Action<int>(SetProgMaximum), new object[] { total });
            }
            else
            {

                progressBar1.Maximum = total;

            }
        }

        private void SetProgValue(int total)
        {
            if (this.progressBar1.InvokeRequired)
            {
                this.progressBar1.Invoke(new Action<int>(SetProgValue), new object[] { total });
            }
            else
            {

                progressBar1.Value = total;

            }
        }


        /// <summary>        
        /// c#,.net 下载文件        
        /// </summary>        
        /// <param name="URL">下载文件地址</param>      
        /// <param name="Filename">下载后的存放地址</param>            
        public void DownloadFile(string URL, string filename)
        {
            SetLog("检查网络...");
            new System.Threading.Thread(() =>
            {
                float percent = 0;
                try
                {
                    HttpWebRequest Myrq = (HttpWebRequest)WebRequest.Create(URL);
                    HttpWebResponse myrp = (HttpWebResponse)Myrq.GetResponse();
                    long totalBytes = myrp.ContentLength;
                    SetProgMaximum((int)totalBytes);
                    Stream st = myrp.GetResponseStream();
                    Stream so = new System.IO.FileStream(filename, FileMode.Create);
                    long totalDownloadedByte = 0;
                    byte[] by = new byte[1024];
                    int osize = st.Read(by, 0, (int)by.Length);
                    SetLog("开始下载...");
                    while (osize > 0)
                    {
                        totalDownloadedByte = osize + totalDownloadedByte;
                        Application.DoEvents();
                        so.Write(by, 0, osize);
                        SetProgValue((int)totalDownloadedByte);
                        osize = st.Read(by, 0, (int)by.Length);

                        percent = (float)totalDownloadedByte / (float)totalBytes * 100;
                        SetMsg("当前下载进度" + percent.ToString() + "%");
                        Application.DoEvents(); //必须加注这句代码，否则label1将因为循环执行太快而来不及显示信息
                    }
                    SetMsg("下载完成");
                    SetLog("下载完成,开始解压...");
                    so.Close();
                    st.Close();


                    bool b = UnZip(filename, System.Environment.CurrentDirectory);
                    if (b)
                    {
                        SetLog("更新完成.");
                    }

                }
                catch (System.Exception ex)
                {
                    SetLog("服务器链接失败.请重试!"+ex.Message);
                    if (MessageBox.Show("服务器链接失败，是否重试?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DownloadFile(URL, filename);
                    }
                }
            })
            { IsBackground = true }.Start();
        }




        #region 解压  

        /// <summary>   
        /// 解压功能(解压压缩文件到指定目录)   
        /// </summary>   
        /// <param name="fileToUnZip">待解压的文件</param>   
        /// <param name="zipedFolder">指定解压目标目录</param>   
        /// <param name="password">密码</param>   
        /// <returns>解压结果</returns>   
        public bool UnZip(string fileToUnZip, string zipedFolder, string password)
        {
            bool result = true;
            FileStream fs = null;
            ZipInputStream zipStream = null;
            ZipEntry ent = null;
            string fileName;

            if (!File.Exists(fileToUnZip))
                return false;

            if (!Directory.Exists(zipedFolder))
                Directory.CreateDirectory(zipedFolder);

            try
            {
                zipStream = new ZipInputStream(File.OpenRead(fileToUnZip));
                if (!string.IsNullOrEmpty(password)) zipStream.Password = password;
                while ((ent = zipStream.GetNextEntry()) != null)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(ent.Name))
                        {
                            fileName = Path.Combine(zipedFolder, ent.Name);
                            fileName = fileName.Replace('/', '\\');//change by Mr.HopeGi   

                            if (fileName.EndsWith("\\"))
                            {
                                Directory.CreateDirectory(fileName);
                                continue;
                            }
                            SetLog(string.Format("解压 {0} ...完成", ent.Name));
                            fs = File.Create(fileName);
                            int size = 2048;
                            byte[] data = new byte[size];
                            while (true)
                            {
                                size = zipStream.Read(data, 0, data.Length);
                                if (size > 0)
                                    fs.Write(data, 0, data.Length);
                                else
                                    break;
                            }
                        }
                    }
                    catch (Exception)
                    {


                    }
                }
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
                if (zipStream != null)
                {
                    zipStream.Close();
                    zipStream.Dispose();
                }
                if (ent != null)
                {
                    ent = null;
                }
                GC.Collect();
                GC.Collect(1);
            }
            return result;
        }

        /// <summary>   
        /// 解压功能(解压压缩文件到指定目录)   
        /// </summary>   
        /// <param name="fileToUnZip">待解压的文件</param>   
        /// <param name="zipedFolder">指定解压目标目录</param>   
        /// <returns>解压结果</returns>   
        public bool UnZip(string fileToUnZip, string zipedFolder)
        {
            bool result = UnZip(fileToUnZip, zipedFolder, null);
            return result;
        }

        #endregion












    }

}
