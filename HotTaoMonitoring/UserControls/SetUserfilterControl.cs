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

namespace HotTaoMonitoring.UserControls
{
    public partial class SetUserfilterControl : UserControl
    {
        private MainForm mainForm { get; set; }
        public SetUserfilterControl(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MyUserInfo.filterUserGroups = txtUserfilter.Text;
            writeLocalFile(MyUserInfo.filterUserGroups);
            MessageBox.Show("保存成功", "提示");
        }

        public const string conf_filter = "/conf_filter.ini";
        /// <summary>
        /// 保存到文件
        /// </summary>
        private void writeLocalFile(string text)
        {
            string filePath = System.IO.Path.Combine(Application.StartupPath, "/data/" + MyUserInfo.currentUserId);
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            filePath += conf_filter;
            if (!File.Exists(filePath))
                File.Create(filePath).Dispose();
            StreamWriter sw = new StreamWriter(@filePath, false);
            sw.Write(text);
            sw.Close();//写入
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
        /// 
        /// </summary>
        /// <returns></returns>
        public string loadFilterConfig()
        {
            try
            {
                string filePath = System.IO.Path.Combine(Application.StartupPath, "/data/" + MyUserInfo.currentUserId + conf_filter);
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
