using HotTaoCore;
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

namespace HotTaoSquare
{
    public partial class TemplateConfig : FormEx
    {
        public TemplateConfig()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TemplateConfig_Load(object sender, EventArgs e)
        {
            string text = GetTemplateText();
            if (string.IsNullOrEmpty(text))
                MyUserInfo.sendtemplate = MyUserInfo.defaultSendTempateText;
            txtTempText.Text = MyUserInfo.sendtemplate;
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 将变量标签插入指定位置
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SetTag_Click(object sender, EventArgs e)
        {
            Label tag = sender as Label;
            string strInsertText = tag.Text;
            int start = txtTempText.SelectionStart;
            txtTempText.Text = txtTempText.Text.Insert(start, strInsertText);
            txtTempText.SelectionStart = start;
            txtTempText.SelectionLength = strInsertText.Length;
        }
        /// <summary>
        /// 缓存文件路径
        /// </summary>
        private static string cacheFilePath = System.IO.Path.Combine(Application.StartupPath, GlobalConfig.datapath);
        /// <summary>
        /// 文案文件名称
        /// </summary>
        private static string templateFileName = string.Format("{0}/{1}/template_text.tgc", cacheFilePath, MyUserInfo.currentUserId.ToString());

        /// <summary>
        /// 写入配置文件
        /// </summary>
        private void writeTemplate(string text)
        {
            if (!Directory.Exists(cacheFilePath))
                Directory.CreateDirectory(cacheFilePath);
            if (!File.Exists(templateFileName))
                File.Create(templateFileName).Dispose();
            StreamWriter sw = new StreamWriter(@templateFileName, false);
            sw.Write(text);
            sw.Close();//写入
        }

        /// <summary>
        /// 获取文案
        /// </summary>
        /// <returns></returns>
        public string GetTemplateText()
        {
            try
            {
                if (File.Exists(templateFileName))
                {
                    FileStream aFile = new FileStream(templateFileName, FileMode.Open);
                    StreamReader sr = new StreamReader(aFile);
                    string str = sr.ReadToEnd();
                    sr.Close();
                    sr.Dispose();
                    aFile.Close();
                    aFile.Dispose();
                    return str;
                }
                return string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTempText.Text))
            {
                writeTemplate(txtTempText.Text);
                MyUserInfo.sendtemplate = txtTempText.Text;
                lbTipMsg.Visible = true;
            }
            else
                lbTipMsg.Visible = false;
        }
    }
}
