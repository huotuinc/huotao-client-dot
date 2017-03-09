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
using HotTaoCore;

namespace HotTao.Controls
{
    public partial class SetUserfilterControl : UserControl
    {
        private Main hotForm { get; set; }

        public SetUserfilterControl(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }


        private void SetUserfilterControl_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MyUserInfo.filterUserGroups))
                txtUserfilter.Text = MyUserInfo.filterUserGroups;
            else
            {
                MyUserInfo.filterUserGroups = loadFilterConfig();
                txtUserfilter.Text = MyUserInfo.filterUserGroups;
            }
        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            MyUserInfo.filterUserGroups = txtUserfilter.Text;
            writeLocalFile(MyUserInfo.filterUserGroups);
            MessageAlert alert = new MessageAlert("保存成功");
            alert.ShowDialog(this);
        }

        /// <summary>
        /// 保存到文件
        /// </summary>
        private void writeLocalFile(string text)
        {
            string filePath = System.IO.Path.Combine(Application.StartupPath, GlobalConfig.dbpath);
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            filePath += ConstConfig.conf_filter;
            if (!File.Exists(filePath))
                File.Create(filePath).Dispose();
            StreamWriter sw = new StreamWriter(@filePath, false);
            sw.Write(text);
            sw.Close();//写入
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string loadFilterConfig()
        {
            try
            {
                string filePath = System.IO.Path.Combine(Application.StartupPath, GlobalConfig.dbpath +ConstConfig.conf_filter);
                if (File.Exists(filePath))
                {
                    FileStream aFile = new FileStream(filePath, FileMode.Open);
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

    }
}
