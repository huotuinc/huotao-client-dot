using HotTao.Controls;
using HotTao.Properties;
using HotTaoCore;
using HotTaoCore.Enums;
using HotTaoCore.Logic;
using HotTaoCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

        // List<WindowInfo> wins { get; set; }

        private void Send()
        {
            //wins = WinApi.GetAllDesktopWindows();
            while (isStartTask)
            {
                if (!isStartTask || MyUserInfo.currentUserId == 0) break;

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
            var taskdata = LogicHotTao.Instance(MyUserInfo.currentUserId).FindUserTaskPlanListByUserId(MyUserInfo.currentUserId, true);
            if (taskdata == null || taskdata.Count() == 0)
            {
                return;
            }

            //获取待执行的任务数据
            taskdata = taskdata.FindAll(item =>
            {
                return item.status == 0 && item.isTpwd == 1 && item.startTime.CompareTo(DateTime.Now) < 0;

            }).OrderBy(x => x.startTime).ToList();

            if (taskdata == null || taskdata.Count() == 0)
            {
                return;
            }
            //排序
            taskdata = taskdata.OrderBy(x => x.startTime).ToList();

            foreach (var item in taskdata)
            {
                if (!isStartTask || MyUserInfo.currentUserId == 0) break;

                if (item.endTime.CompareTo(DateTime.Now) < 0) break;

                textResult.Clear();
                imageResult.Clear();

                int taskid = Convert.ToInt32(item.id);

                List<UserPidTaskModel> lst = JsonConvert.DeserializeObject<List<UserPidTaskModel>>(item.goodsText);
                List<int> ids = new List<int>();
                //如果群数据和商品数据都为空时
                if (lst == null || lst.Count() == 0)
                {
                    if (!isStartTask || MyUserInfo.currentUserId == 0) break;
                    LogicHotTao.Instance(MyUserInfo.currentUserId).UpdateUserTaskPlanExecStatus(taskid, 2);
                    continue;
                }

                lst.ForEach(it =>
                {
                    if (!ids.Contains(it.id))
                        ids.Add(it.id);
                });
                //获取商品数据
                var goodslist = LogicHotTao.Instance(MyUserInfo.currentUserId).FindByUserGoodsList(MyUserInfo.currentUserId, ids);
                if (goodslist == null || goodslist.Count() == 0)
                {
                    if (!isStartTask || MyUserInfo.currentUserId == 0) break;
                    LogicHotTao.Instance(MyUserInfo.currentUserId).UpdateUserTaskPlanExecStatus(taskid, 2);
                    continue;
                }
                //发送商品数据
                var result = SendGoods(goodslist, item, wins);

                if (result)
                {
                    if (!isStartTask || MyUserInfo.currentUserId == 0) break;
                    LogicHotTao.Instance(MyUserInfo.currentUserId).UpdateUserTaskPlanExecStatus(taskid, 2);
                    //每个任务之间，休息一下
                    SleepTask();
                }
                else
                    break;
            }

        }

        private string appkey { get; set; }
        private string appsecret { get; set; }

        /// <summary>
        /// 加载appkey 和 secret
        /// </summary>
        private bool LoadAppkeyAndSecret()
        {
            if (string.IsNullOrEmpty(appkey) || string.IsNullOrEmpty(appsecret))
            {
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
                    return true;
                }
            }
            else
                return true;

            return false;
        }

        /// <summary>
        /// 发送任务商品
        /// </summary>
        /// <param name="goodslist">The goodslist.</param>
        /// <param name="taskid">The taskid.</param>
        /// <param name="lst">The LST.</param>
        private bool SendGoods(List<GoodsModel> goodslist, TaskPlanModel taskModel, List<WindowInfo> wins)
        {
            bool result = false;
            var data = LogicHotTao.Instance(MyUserInfo.currentUserId).FindByUserWechatShareTextList(MyUserInfo.currentUserId);
            if (data == null || data.Count() == 0) return true;
            foreach (var goods in goodslist)
            {
                textResult.Clear();
                imageResult.Clear();

                if (!isStartTask || MyUserInfo.currentUserId == 0)
                {
                    result = false;
                    break;
                }
                if (taskModel.endTime.CompareTo(DateTime.Now) < 0)
                {
                    result = false;
                    break;
                }

                result = true;
                int goodsId = Convert.ToInt32(goods.id);

                var shareData = data.FindAll(share =>
                  {
                      return share.goodsid == goodsId && share.taskid == taskModel.id;
                  });
                if (shareData == null || shareData.Count() == 0)
                    continue;


                //申请高佣金
                ApplyCamp(goods);


                //加载appkey，判断是否存在，如果不存在，则不发商品
                if (LoadAppkeyAndSecret())
                {
                    //发送当前商品时，进行淘口令生产
                    shareData.ForEach(item =>
                    {
                        if (item.status == -1)
                        {
                            bool flag = LogicHotTao.Instance(MyUserInfo.currentUserId).BuildTpwd(MyUserInfo.currentUserId, MyUserInfo.LoginToken, goods, item, appkey, appsecret);
                            if (flag)
                                item.status = 0;
                        }
                    });

                    hotForm.logRuningList.Add(new LogRuningModel()
                    {
                        goodsName = goods.goodsName,
                        goodsid = goods.goodsId,
                        title = goods.goodsId,
                        content = goods.goodsName,
                        logTime = DateTime.Now,
                        logType = LogTypeOpts.商品发送,
                        isError = false,
                        remark = string.Format("[{0}]开始发送商品[{1}]", goods.goodsId, goods.goodsName)
                    });

                    shareData = shareData.FindAll(share => { return share.status == 0; });
                    SendWeChatGroupShareText(shareData, goods, wins);
                    SleepGoods();
                }
            }
            return result;
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
                bool isSendImage = isImageText();
                try
                {
                    using (Stream stream = new FileStream(goods.goodslocatImgPath, FileMode.Open))
                    {
                        image = Image.FromStream(stream);
                    }
                }
                catch (Exception ex)
                {
                    image = null;
                    isSendImage = true;
                    log.Error(ex);
                }

                if (cfgTime != null && cfgTime.enable_sendvideo)
                {
                    //发送视频或GIF图片
                    string videoPath = MyUserInfo.GetVideoFilePath(goods.goodsId);
                    if (!string.IsNullOrEmpty(videoPath))
                    {
                        CopyFileToClipboard(videoPath);
                        SendImage(image, shareData, wins, true, true);
                    }
                }

                if (isSendImage)
                {
                    //复制文件
                    CopyFileToClipboard(goods.goodslocatImgPath);
                    SendImage(image, shareData, wins, true);
                    SendText(shareData, wins, true);
                }
                else
                {
                    SendText(shareData, wins, false);
                    //复制文件
                    CopyFileToClipboard(goods.goodslocatImgPath);
                    SendImage(image, shareData, wins, false);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void CopyFileToClipboard(string path)
        {
            StringCollection sc = new StringCollection();
            sc.Add(path);
            Clipboard.SetFileDropList(sc);
        }


        /// <summary>
        /// 发送图片
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="shareData">The share data.</param>
        /// <param name="wins">The wins.</param>
        private void SendImage(Image image, List<weChatShareTextModel> shareData, List<WindowInfo> wins, bool isImageText, bool sendVideo = false)
        {
            if (image != null)
            {
                // Clipboard.SetImage(image);
                //System.Threading.Thread.Sleep(1000);
                //粘贴图片       
                foreach (var item in shareData)
                {
                    try
                    {
                        if (!isStartTask || MyUserInfo.currentUserId == 0)
                        {
                            //通知
                            sendSmsNotify(item.title, true);
                            break;
                        }

                        //如果当前微信已经发送，则结束本循环
                        if (imageResult.Contains(item.title)) continue;

                        bool b = wins.Exists(win => { return win.szWindowName == item.title; });
                        if (b)
                        {
                            var win = wins.Find(w => { return w.szWindowName == item.title; });
                            WinApi.SetActiveWin(win.hWnd);
                            System.Threading.Thread.Sleep(100);
                            WinApi.Paste(win.hWnd);
                            System.Threading.Thread.Sleep(100);
                            WinApi.Enter(win.hWnd);
                            SleepImage(0.5m);
                            if (!sendVideo && !imageResult.Contains(item.title))
                                imageResult.Add(item.title);

                            if (!isImageText)
                            {
                                //更新修改状态
                                UpdateShareTextStatus(item.id);
                            }
                        }
                        else
                        {
                            //通知
                            sendSmsNotify(item.title, false);
                        }
                    }
                    catch (Exception ex)
                    {
                        //通知
                        sendSmsNotify(item.title, false);

                        if (!sendVideo && !imageResult.Contains(item.title))
                            imageResult.Add(item.title);

                        AddErrorLog(item, 0);

                        if (!isImageText)
                        {
                            //更新修改状态
                            UpdateShareTextStatus(item.id);
                        }
                        log.Error(ex);
                    }
                }
                Clipboard.Clear();
            }
        }


        /// <summary>
        /// 更新分享状态
        /// </summary>
        /// <param name="shareid"></param>
        private void UpdateShareTextStatus(long shareid)
        {
            new System.Threading.Thread(() =>
            {
                LogicHotTao.Instance(MyUserInfo.currentUserId).UpdateUserShareTextStatus(shareid);
            })
            { IsBackground = true }.Start();
        }


        /// <summary>
        /// 申请高佣
        /// </summary>
        /// <param name="goods"></param>
        private void ApplyCamp(GoodsModel goods)
        {
            new System.Threading.Thread(() =>
            {
                try
                {
                    PlanModel model = LogicGoods.Instance.getCommissionPlan(MyUserInfo.LoginToken, goods.goodsDetailUrl);
                    if (model != null && model.campaignType.Equals("1"))
                    {
                        //申请高佣金
                        hotForm.ApplyPlan(goods.goodsId, goods.goodsName, model.planId, model.shopKeeperId, model.commission);
                    }
                }
                catch (System.Threading.ThreadAbortException ex)
                {
                    log.Error(ex);
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            })
            { IsBackground = true }.Start();

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
                    if (!isStartTask || MyUserInfo.currentUserId == 0)
                    {
                        //通知
                        sendSmsNotify(item.title, false);
                        break;
                    }
                    Clipboard.SetText(item.text);
                    //如果当前微信已经发送，则结束本循环
                    if (textResult.Contains(item.title)) continue;

                    bool b = wins.Exists(win => { return win.szWindowName == item.title; });
                    if (b)
                    {
                        var win = wins.Find(w => { return w.szWindowName == item.title; });
                        //设置微信为输入焦点
                        WinApi.SetActiveWin(win.hWnd);
                        System.Threading.Thread.Sleep(400);
                        WinApi.Paste(win.hWnd);
                        System.Threading.Thread.Sleep(300);
                        WinApi.Enter(win.hWnd);
                        SleepImage(0.5m);
                        // Clipboard.Clear();
                        if (!textResult.Contains(item.title))
                            textResult.Add(item.title);

                        if (isImageText)
                        {
                            //更新修改状态
                            UpdateShareTextStatus(item.id);
                        }
                    }
                    else
                    {
                        sendSmsNotify(item.title, false);
                    }
                }
                catch (Exception ex)
                {
                    //通知
                    sendSmsNotify(item.title, false);

                    if (!textResult.Contains(item.title))
                        textResult.Add(item.title);

                    //添加错误日志
                    AddErrorLog(item, 1);
                    if (isImageText)
                    {
                        //更新修改状态
                        UpdateShareTextStatus(item.id);
                    }
                    log.Error(ex);
                }
            }
        }


        /// <summary>
        /// 添加错误日志  
        /// </summary>
        /// <param name="item"></param>
        /// <param name="errorType">0 图片 1 文本</param>
        public void AddErrorLog(weChatShareTextModel item, int errorType)
        {
            new System.Threading.Thread(() =>
            {
                //添加错误日志
                LogicHotTao.Instance(MyUserInfo.currentUserId).AddUserWeChatError(new weChatUserWechatErrorModel()
                {
                    userid = item.userid,
                    title = item.title,
                    shareText = item.text,
                    createtime = DateTime.Now,
                    errorType = errorType
                });
            })
            { IsBackground = true }.Start();
        }






















        /// <summary>
        /// 发送短信通知
        /// </summary>
        /// <param name="weChatTitle">群标题</param>
        public void sendSmsNotify(string weChatTitle, bool isImage)
        {
            string content = string.Format("您好，发单号:{0},群[{1}]{2}发送出问题了，请查看！",
                MyUserInfo.userData.loginName, weChatTitle, isImage ? "图片" : "文案");
            //TODO:待接口发布
            if (cfgTime != null && !string.IsNullOrEmpty(cfgTime.notify_mobile))
            {
                string notify_mobile = cfgTime.notify_mobile;
                new System.Threading.Thread(() =>
                {
                    LogicUser.Instance.sendWarning(MyUserInfo.LoginToken, notify_mobile, content);
                })
                { IsBackground = true }.Start();
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

        private void SleepImage(decimal interval)
        {
            //没发一张图片，暂停休息一下
            if (cfgTime != null)
                System.Threading.Thread.Sleep(cfgTime.hdInterval > 0 ? Convert.ToInt32(cfgTime.hdInterval * 1000) : Convert.ToInt32(interval * 1000));
            else
                System.Threading.Thread.Sleep(Convert.ToInt32(0.5 * 1000));
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
