using HotTaoCore.Logic;
using HotTaoCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HotTaoCore.Models.SQLiteEntitysModel;

namespace HotTao.Controls
{
    public partial class BuildShareText : Form
    {

        #region 移动窗口
        /*
         * 首先将窗体的边框样式修改为None，让窗体没有标题栏
         * 实现这个效果使用了三个事件：鼠标按下、鼠标弹起、鼠标移动
         * 鼠标按下时更改变量isMouseDown标记窗体可以随鼠标的移动而移动
         * 鼠标移动时根据鼠标的移动量更改窗体的location属性，实现窗体移动
         * 鼠标弹起时更改变量isMouseDown标记窗体不可以随鼠标的移动而移动
         */
        private bool isMouseDown = false;
        private Point FormLocation;     //form的location
        private Point mouseOffset;      //鼠标的按下位置
        private void WinForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLocation = this.Location;
                mouseOffset = Control.MousePosition;
            }
        }

        private void WinForm_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
        private void WinForm_MouseMove(object sender, MouseEventArgs e)
        {
            int _x = 0;
            int _y = 0;
            if (isMouseDown)
            {
                Point pt = Control.MousePosition;
                _x = mouseOffset.X - pt.X;
                _y = mouseOffset.Y - pt.Y;

                this.Location = new Point(FormLocation.X - _x, FormLocation.Y - _y);
            }

        }
        #endregion






        private TaskControl taskControl { get; set; }


        private HistoryControl historyControl { get; set; }

        private Main hotForm { get; set; }

        /// <summary>
        /// 任务ID
        /// </summary>
        /// <value>The taskid.</value>
        public int taskid { get; set; }

        private bool BuildStart { get; set; }


        public BuildShareText(Main mainWin, TaskControl control)
        {
            InitializeComponent();
            taskControl = control;
            hotForm = mainWin;

        }
        public BuildShareText(Main mainWin, HistoryControl control)
        {
            InitializeComponent();
            historyControl = control;
            hotForm = mainWin;
        }

        private void BuildShareText_Load(object sender, EventArgs e)
        {
            if (MyUserInfo.currentUserId > 0)
            {
                if (string.IsNullOrEmpty(MyUserInfo.sendtemplate))
                    MyUserInfo.sendtemplate = MyUserInfo.defaultSendTempateText;

                txtTemplateText.Text = MyUserInfo.sendtemplate;
                dgvShareText.MouseWheel += DgvData_MouseWheel;

                loadUserPidGridView();
            }
            else
            {
                this.Close();
            }
        }



        /// </summary>
        public void loadUserPidGridView()
        {
            new Thread(() =>
            {
                //是否自动添加属性字段
                this.dgvShareText.AutoGenerateColumns = false;
                this.dgvShareText.Rows.Clear();
                var data = LogicHotTao.Instance(MyUserInfo.currentUserId).FindByUserWechatShareTextList(MyUserInfo.currentUserId, taskid);
                if (data != null)
                {
                    SetView(data);
                }
            })
            { IsBackground = true }.Start();

        }
        public void SetView(List<weChatShareTextModel> data)
        {
            if (dgvShareText.InvokeRequired)
            {
                this.Invoke(new Action<List<weChatShareTextModel>>(SetView), new object[] { data });
            }
            else
            {
                int i = dgvShareText.Rows.Count;
                for (int j = 0; j < data.Count(); j++)
                {
                    dgvShareText.Rows.Add();
                    ++i;
                    dgvShareText.Rows[i - 1].Cells["sharetitle"].Value = data[j].title.ToString();
                    dgvShareText.Rows[i - 1].Cells["tpwd"].Value = data[j].tpwd.ToString();
                    dgvShareText.Rows[i - 1].Cells["shareText"].Value = data[j].text.ToString();

                    if (i % 2 == 0)
                    {
                        dgvShareText.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                        dgvShareText.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewEvenRowBackColor;
                    }
                    else
                    {
                        dgvShareText.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;
                        dgvShareText.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewOddRowBackColor;
                    }
                    dgvShareText.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                    dgvShareText.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;
                }
            }
        }

        /// <summary>
        /// 添加时调用
        /// </summary>
        /// <param name="model">The model.</param>
        public void SetView(weChatShareTextModel model)
        {
            if (dgvShareText.InvokeRequired)
            {
                this.Invoke(new Action<weChatShareTextModel>(SetView), new object[] { model });
            }
            else
            {
                int i = dgvShareText.Rows.Count;
                dgvShareText.Rows.Add();
                ++i;
                dgvShareText.Rows[i - 1].Cells["sharetitle"].Value = model.title;
                dgvShareText.Rows[i - 1].Cells["tpwd"].Value = model.tpwd.ToString();
                dgvShareText.Rows[i - 1].Cells["shareText"].Value = model.text.ToString();
                if (i % 2 == 0)
                {
                    dgvShareText.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                    dgvShareText.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewEvenRowBackColor;
                }
                else
                {
                    dgvShareText.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;
                    dgvShareText.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewOddRowBackColor;
                }
                dgvShareText.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                dgvShareText.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;

                dgvShareText.CurrentCell = dgvShareText.Rows[dgvShareText.Rows.Count - 1].Cells[dgvShareText.CurrentCell.ColumnIndex];
            }
        }

        /// <summary>
        /// 鼠标滚动事件
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void DgvData_MouseWheel(object sender, MouseEventArgs e)
        {
            DataGridView dataGridView1 = sender as DataGridView;
            try
            {
                if (dataGridView1.CurrentCell != null)
                {
                    DataGridViewCell dvc = dataGridView1.CurrentCell;
                    int ri = dvc.RowIndex;
                    int ci = dvc.ColumnIndex;
                    int c = 0;
                    if (e.Delta > 0)//向上
                    {
                        if (ri - 3 > 0)
                            c = 3;
                        else if (ri > 0)
                            c = 1;
                        if (c > 0)
                        {
                            dvc = dataGridView1.Rows[ri - c].Cells[ci];
                            dataGridView1.CurrentCell = dvc;

                        }
                    }
                    else
                    {
                        if (ri < dataGridView1.Rows.Count - 3)
                            c = 3;
                        else if (ri < dataGridView1.Rows.Count - 1)
                            c = 1;
                        if (c > 0)
                        {
                            dvc = dataGridView1.Rows[ri + c].Cells[ci];
                            dataGridView1.CurrentCell = dvc;
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }


        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pbClose_Click(object sender, EventArgs e)
        {
            if (!BuildStart)
                this.Close();
            else
            {
                MessageAlert alert = new MessageAlert("正在生成发送内容，请稍后!");
                alert.ShowDialog(this);

            }
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
            int start = txtTemplateText.SelectionStart;
            txtTemplateText.Text = txtTemplateText.Text.Insert(start, strInsertText);
            txtTemplateText.SelectionStart = start;
            txtTemplateText.SelectionLength = strInsertText.Length;
        }

        /// <summary>
        /// 生成分享内容
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnBuildShareText_Click(object sender, EventArgs e)
        {
            if (BuildStart)
                return;
            BuildStart = true;
            string tempText = txtTemplateText.Text;
            this.dgvShareText.Rows.Clear();

            new Thread(() =>
            {
                string appkey = string.Empty, appsecret = string.Empty;

                if (hotForm.myConfig == null)
                    hotForm.myConfig = new ConfigModel();
                else
                {
                    ConfigSendTimeModel cfgTime = string.IsNullOrEmpty(hotForm.myConfig.send_time_config) ? null : JsonConvert.DeserializeObject<ConfigSendTimeModel>(hotForm.myConfig.send_time_config);
                    if (cfgTime != null)
                    {
                        appkey = cfgTime.appkey;
                        appsecret = cfgTime.appsecret;
                    }
                }
                LogicHotTao.Instance(MyUserInfo.currentUserId).BuildTaskTpwd(MyUserInfo.LoginToken, MyUserInfo.currentUserId, taskid, tempText, appkey, appsecret, (share) =>
                  {
                      SetView(share);
                  });
                if (taskControl != null)
                    taskControl.LoadTaskPlanGridView();
                if (historyControl != null)
                    historyControl.LoadTaskPlanGridView();
                BuildStart = false;
                ShowAlert("生成完成");

            })
            { IsBackground = true }.Start();

        }

        private void ShowAlert(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(ShowAlert), new object[] { text });
            }
            else
            {
                MessageAlert alert = new MessageAlert(text);
                alert.ShowDialog(this);
            }
        }
    }
}
