using HotTao.Controls;
using HotTaoCore.Logic;
using HotTaoCore.Models;
using Newtonsoft.Json;
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
using static HotTaoCore.Models.SQLiteEntitysModel;

namespace HotTao
{
    public partial class StartTask : Form
    {
        NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        private Main hotForm { get; set; }

        private HistoryControl historyForm { get; set; }

        private TaskControl taskForm { get; set; }

        public StartTask(Main mainWin, HistoryControl history)
        {
            InitializeComponent();
            hotForm = mainWin;
            historyForm = history;
            loadConfig();
        }

        public StartTask(Main mainWin, TaskControl control)
        {
            InitializeComponent();
            hotForm = mainWin;
            taskForm = control;
            loadConfig();
        }

        private void loadConfig()
        {
            if (hotForm.myConfig == null)
                hotForm.myConfig = new ConfigModel();
            else
            {
                cfgTime = string.IsNullOrEmpty(hotForm.myConfig.send_time_config) ? null : JsonConvert.DeserializeObject<ConfigSendTimeModel>(hotForm.myConfig.send_time_config);

            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            hotForm.winTask = null;
            this.Close();
        }


        Timer startTaskTimer = new Timer();



        public bool isStartTask { get; set; }

        public ConfigSendTimeModel cfgTime { get; set; }

        private void StartTask_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Hide();
        }



        public void OK()
        {
            isStartTask = true;
            if (historyForm != null)
                historyForm.ShowStartButtonText("暂停计划");
            if (taskForm != null)
                taskForm.ShowStartButtonText("暂停计划");
            var t = new System.Threading.Thread(new System.Threading.ThreadStart(Send));
            t.TrySetApartmentState(System.Threading.ApartmentState.STA);
            t.Start();
        }

        /// <summary>
        /// 发送微信图片结果，已发送的微信群
        /// </summary>
        private List<string> imageResult = new List<string>();
        /// <summary>
        /// 发送微信文本结果，已发送的微信群
        /// </summary>
        private List<string> textResult = new List<string>();

        private void Send()
        {
            while (isStartTask)
            {
                textResult.Clear();
                imageResult.Clear();
                StartSend();
                //休息一下
                SleepTask();
            }
        }
        /// <summary>
        /// 开始执行发送
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="image">The image.</param>
        private void StartSend()
        {
            List<WindowInfo> wins = WinApi.GetAllDesktopWindows();
            if (wins == null || wins.Count() == 0)
            {
                return;
            }
            //获取任务数据
            var taskdata = LogicHotTao.Instance.FindByUserTaskPlanList(MyUserInfo.currentUserId);
            if (taskdata == null)
            {
                return;
            }

            //获取待执行的任务数据
            taskdata = taskdata.FindAll(item => { return item.status == 0 && item.isTpwd == 1; }).OrderBy(x => x.startTime).ToList();

            if (taskdata == null)
            {
                return;
            }
            //排序
            taskdata = taskdata.OrderBy(x => x.startTime).ToList();

            foreach (var item in taskdata)
            {

                if (!isStartTask || MyUserInfo.currentUserId == 0) break;

                int taskid = Convert.ToInt32(item.id);

                List<UserPidTaskModel> lst = JsonConvert.DeserializeObject<List<UserPidTaskModel>>(item.goodsText);
                List<int> ids = new List<int>();
                //如果群数据和商品数据都为空时
                if (lst == null)
                {
                    LogicHotTao.Instance.UpdateUserTaskPlanExecStatus(taskid, 2);
                    continue;
                }

                lst.ForEach(it =>
                {
                    if (!ids.Contains(it.id))
                        ids.Add(it.id);
                });
                //获取商品数据
                var goodslist = LogicHotTao.Instance.FindByUserGoodsList(MyUserInfo.currentUserId, ids);
                if (goodslist == null)
                {
                    LogicHotTao.Instance.UpdateUserTaskPlanExecStatus(taskid, 2);
                    continue;
                }
                //发送商品数据
                SendGoods(goodslist, taskid, wins);


                LogicHotTao.Instance.UpdateUserTaskPlanExecStatus(taskid, 2);
                //每个任务之间，休息一下
                SleepTask();
            }

        }

        /// <summary>
        /// 发送任务商品
        /// </summary>
        /// <param name="goodslist">The goodslist.</param>
        /// <param name="taskid">The taskid.</param>
        /// <param name="lst">The LST.</param>
        private void SendGoods(List<GoodsModel> goodslist, int taskid, List<WindowInfo> wins)
        {
            foreach (var goods in goodslist)
            {
                if (!isStartTask || MyUserInfo.currentUserId == 0) break;

                int goodsId = Convert.ToInt32(goods.id);
                var shareData = LogicHotTao.Instance.FindByUserWechatShareTextList(MyUserInfo.currentUserId, taskid, goodsId);
                if (shareData == null)
                    continue;
                SendWeChatGroupShareText(shareData, goods, wins);

                SleepGoods();
            }

        }


        /// <summary>
        /// 将商品发送到相应的群
        /// </summary>
        /// <param name="shareData">The share data.</param>
        /// <param name="goods">The goods.</param>
        /// <param name="lst">The LST.</param>
        private void SendWeChatGroupShareText(List<weChatShareTextModel> shareData, GoodsModel goods, List<WindowInfo> wins)
        {
            try
            {
                Image image = null;
                using (Stream stream = new FileStream(goods.goodslocatImgPath, FileMode.Open))
                {
                    image = Image.FromStream(stream);
                }
                if (isImageText())
                {
                    SendImage(image, shareData, wins, true);
                    SendText(shareData, wins, true);
                }
                else
                {
                    SendText(shareData, wins, false);
                    SendImage(image, shareData, wins, false);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        /// <summary>
        /// 发送图片
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="shareData">The share data.</param>
        /// <param name="wins">The wins.</param>
        private void SendImage(Image image, List<weChatShareTextModel> shareData, List<WindowInfo> wins, bool isImageText)
        {
            if (image != null)
            {
                Clipboard.SetImage(image);
                System.Threading.Thread.Sleep(1000);
                //粘贴图片       
                foreach (var item in shareData)
                {
                    try
                    {
                        //如果当前微信已经发送，则结束本循环
                        if (imageResult.Contains(item.title)) continue;

                        if (!isStartTask || MyUserInfo.currentUserId == 0) break;
                        bool b = wins.Exists(win => { return win.szWindowName == item.title; });
                        if (b)
                        {
                            var win = wins.Find(w => { return w.szWindowName == item.title; });
                            WinApi.SetActiveWin(win.hWnd);
                            WinApi.Paste(win.hWnd);
                            WinApi.Enter(win.hWnd);

                            if (!imageResult.Contains(item.title))
                                textResult.Add(item.title);

                            if (!isImageText)
                            {
                                //更新修改状态
                                LogicHotTao.Instance.UpdateUserShareTextStatus(item.id);
                            }                            
                        }
                    }
                    catch (Exception ex)
                    {
                        if (!imageResult.Contains(item.title))
                            textResult.Add(item.title);

                        if (!isImageText)
                        {
                            //更新修改状态
                            LogicHotTao.Instance.UpdateUserShareTextStatus(item.id);
                        }
                        log.Error(ex);
                    }
                }
                Clipboard.Clear();
            }
        }


        /// <summary>
        /// 发送文本
        /// </summary>
        /// <param name="shareData">The share data.</param>
        /// <param name="wins">The wins.</param>
        private void SendText(List<weChatShareTextModel> shareData, List<WindowInfo> wins, bool isImageText)
        {
            foreach (var item in shareData)
            {
                try
                {
                    //如果当前微信已经发送，则结束本循环
                    if (textResult.Contains(item.title)) continue;

                    if (!isStartTask || MyUserInfo.currentUserId == 0) break;
                    bool b = wins.Exists(win => { return win.szWindowName == item.title; });
                    if (b)
                    {
                        var win = wins.Find(w => { return w.szWindowName == item.title; });
                        Clipboard.SetDataObject(item.text, false);
                        //设置微信为输入焦点
                        WinApi.SetActiveWin(win.hWnd);
                        WinApi.Paste(win.hWnd);
                        WinApi.InputStr(win.hWnd, item.text);
                        WinApi.Enter(win.hWnd);
                        Clipboard.Clear();

                        if (!textResult.Contains(item.title))
                            textResult.Add(item.title);

                        if (isImageText)
                        {
                            //更新修改状态
                            LogicHotTao.Instance.UpdateUserShareTextStatus(item.id);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (!textResult.Contains(item.title))
                        textResult.Add(item.title);

                    //添加错误日志
                    LogicHotTao.Instance.AddUserWeChatError(new weChatUserWechatErrorModel()
                    {
                        userid = item.userid,
                        title = item.title,
                        shareText = item.text,
                        createtime = DateTime.Now
                    });
                    if (isImageText)
                    {
                        //更新修改状态
                        LogicHotTao.Instance.UpdateUserShareTextStatus(item.id);
                    }
                    log.Error(ex);
                }
            }
        }

        /// <summary>
        /// 暂停休息一下
        /// </summary>
        private void SleepTask()
        {
            //完成一个任务，暂停休息一下
            if (cfgTime != null)
                System.Threading.Thread.Sleep(cfgTime.taskinterval > 0 ? cfgTime.taskinterval * 1000 : 60 * 1000);
            else
                System.Threading.Thread.Sleep(60 * 1000);
        }

        private void SleepImage(int interval)
        {
            //没发一张图片，暂停休息一下
            if (cfgTime != null)
                System.Threading.Thread.Sleep(cfgTime.handleInterval > 0 ? cfgTime.handleInterval * 1000 : interval * 1000);
            else
                System.Threading.Thread.Sleep(2 * 1000);
        }


        private void SleepGoods()
        {
            //每发一个商品，暂停休息一下
            if (cfgTime != null)
                System.Threading.Thread.Sleep(cfgTime.goodsinterval > 0 ? cfgTime.goodsinterval * 1000 : 60 * 1000);
            else
                System.Threading.Thread.Sleep(40 * 1000);
        }

        /// <summary>
        /// 是否先图后文
        /// </summary>
        /// <returns>true if [is image text]; otherwise, false.</returns>
        private bool isImageText()
        {
            if (cfgTime != null)
                return cfgTime.imagetextsort == 0;
            return true;
        }
    }
}
