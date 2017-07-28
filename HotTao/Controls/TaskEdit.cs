using HotTao.Properties;
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
using System.Windows.Forms;

namespace HotTao.Controls
{
    public partial class TaskEdit : Form
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

        /// <summary>
        /// 窗口标题
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }


        public bool isJoinImage { get; set; } = false;


        public int taskid { get; set; }

        public string taskTitle { get; set; }

        public string taskStartTime { get; set; }

        public string taskEndTime { get; set; }


        public List<GoodsTaskModel> hotGoodsText { get; set; }
        public List<UserPidTaskModel> hotPidsText { get; set; }

        private Main hotForm { get; set; }
        private TaskControl hotTask { get; set; }

        private HistoryControl hotHistoryTask { get; set; }



        public int CurrentRowIndex { get; set; }


        public TaskEdit(Main main, TaskControl task)
        {
            InitializeComponent();
            hotForm = main;
            hotTask = task;
        }

        public TaskEdit(Main main, HistoryControl task)
        {
            InitializeComponent();
            hotForm = main;
            hotHistoryTask = task;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TaskEdit_Load(object sender, EventArgs e)
        {

            if (isJoinImage)
            {
                lbTaskName.Text = "商品简述：";
            }

            if (!string.IsNullOrEmpty(Title))
            {
                lbTitle.Text = Title;
                this.Text = Title;
            }
            txtTaskTitle.Text = taskTitle;
            txtStartTime.Text = taskStartTime;
            txtEndTime.Text = taskEndTime;
            if (taskid == 0 && (hotGoodsText.Count() == 0 || hotPidsText.Count() == 0))
            {
                this.Close();
            }
            else
            {
                if (hotGoodsText == null)
                    hotGoodsText = new List<GoodsTaskModel>();
                if (hotPidsText == null)
                    hotPidsText = new List<UserPidTaskModel>();
            }
            if (taskid == 0)
            {
                txtEndTime.Text = DateTime.Now.AddHours(5).ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                txtTaskTitle.ReadOnly = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageAlert alert = new MessageAlert();
            if (!isJoinImage && string.IsNullOrEmpty(txtTaskTitle.Text))
            {
                alert.Message = "请输入任务标题";
                alert.ShowDialog(this);
                txtTaskTitle.Focus();
                return;
            }
            else
            {
                if (txtTaskTitle.Text.Length > 8)
                {
                    alert.Message = "商品简述最多8个字";
                    alert.ShowDialog(this);
                    txtTaskTitle.Focus();
                    return;
                }
            }
            if (string.IsNullOrEmpty(txtStartTime.Text))
            {
                txtStartTime.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtEndTime.Text))
            {
                txtEndTime.Focus();
                return;
            }
            string goodsText = JsonConvert.SerializeObject(hotGoodsText);
            string pidsText = JsonConvert.SerializeObject(hotPidsText);

            TaskPlanModel model = new TaskPlanModel()
            {
                userid = MyUserInfo.currentUserId,
                title = isJoinImage ? "【合成图片转发】" + txtTaskTitle.Text : txtTaskTitle.Text,
                startTime = Convert.ToDateTime(txtStartTime.Text),
                endTime = Convert.ToDateTime(txtEndTime.Text),
                pidsText = pidsText,
                goodsText = goodsText,
                id = taskid,
                status = 0,
                isTpwd = isJoinImage ? 1 : 0
            };
            Loading ld = new Loading();
            ((Action)(delegate ()
            {
                TaskPlanModel data = LogicHotTao.Instance(MyUserInfo.currentUserId).AddUserTaskPlan(model);

                if (data != null)
                {

                    if (isJoinImage)
                    {
                        BuildText(Convert.ToInt32(data.id));
                    }
                    ld.CloseForm();
                    this.BeginInvoke((Action)(delegate ()  //等待结束
                    {
                        if (hotTask != null)
                        {
                            //hotTask.SetTaskView(data, taskid > 0 ? CurrentRowIndex : -1);
                            hotTask.LoadTaskPlanGridView();
                        }
                        txtTaskTitle.Clear();
                        alert.Message = "保存成功";
                        alert.CallBack += () => { this.Close(); };
                        alert.ShowDialog(this);
                    }));
                }
                else
                {
                    ld.CloseForm();
                    this.BeginInvoke((Action)(delegate ()  //等待结束
                    {
                        alert.Message = "保存失败";
                        alert.ShowDialog(this);
                    }));
                }
            })).BeginInvoke(null, null);
            ld.ShowDialog(hotForm);
        }

        /// <summary>
        /// 生成转发
        /// </summary>
        /// <param name="tkid"></param>
        private void BuildText(int tkid)
        {
            string tempText = "[二合一淘口令]";
            string appkey = string.Empty;
            string appsecret = string.Empty;
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
            if (string.IsNullOrEmpty(appkey) && string.IsNullOrEmpty(appsecret))
            {
                appkey = Resources.taobaoappkey;
                appsecret = Resources.taobaoappsecret;
            }

            LogicHotTao.Instance(MyUserInfo.currentUserId).BuildTaskTpwd(MyUserInfo.LoginToken, MyUserInfo.currentUserId, tkid, tempText, appkey, appsecret, (share) => { }, false, isJoinImage);
        }

    }
}
