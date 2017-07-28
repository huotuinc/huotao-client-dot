using HOTReuestService;
using HOTReuestService.Helper;
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
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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


        public StartTask(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
            historyForm = null;
            taskForm = null;
            loadConfig();
        }

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
        /// 通知
        /// </summary>
        private Dictionary<string, DateTime> notifyMap { get; set; } = new Dictionary<string, DateTime>();


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
                //通知
                //sendEmailNOtify("发单失败，请检查发单微信是否掉线!");
                HotJavaApi.SendUserNotice(MyUserInfo.LoginToken, WeChatTemplateMessageSceneType.微信离线);
                return;
            }
            //获取任务数据
            var taskdata = LogicHotTao.Instance(MyUserInfo.currentUserId).FindUserTaskPlanListByUserId(true);
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
                var goodslist = LogicHotTao.Instance(MyUserInfo.currentUserId).FindByUserGoodsList(ids);

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
            var data = LogicHotTao.Instance(MyUserInfo.currentUserId).FindByUserWechatShareTextList(Convert.ToInt32(taskModel.id));
            if (data == null || data.Count() == 0) return true;

            if (taskModel.title.Contains("【合成图片转发】"))
            {
                List<weChatShareTextModel> newdata = new List<weChatShareTextModel>();
                foreach (var item in data)
                {
                    if (item.taskid == taskModel.id)
                    {
                        if (!newdata.Exists(r => { return r.field3.Equals(item.field3); }))
                            newdata.Add(item);
                    }
                }
                SendImage(null, newdata, wins, true, false, true);
                result = true;

                foreach (var goods in goodslist)
                {
                    //申请高佣金
                    ApplyCamp(goods);
                    System.Threading.Thread.Sleep(1000);
                }
            }
            else
            {
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
                        shareData.ForEach(item =>
                        {
                            if (item.status == -1)
                            {

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
                        SendWeChatGroupShareText(shareData, goods, wins, taskModel);
                        SleepGoods();
                    }
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
        private void SendWeChatGroupShareText(List<weChatShareTextModel> shareData, GoodsModel goods, List<WindowInfo> wins, TaskPlanModel taskModel)
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
                    //isSendImage = true;
                    log.Error(ex);
                }

                wins = WinApi.GetAllDesktopWindows();
                if (wins == null || wins.Count() == 0)
                {
                    HotJavaApi.SendUserNotice(MyUserInfo.LoginToken, WeChatTemplateMessageSceneType.微信离线);
                }

                if (isSendImage)
                {
                    //复制文件                    
                    if (image != null)
                        SendImage(image, shareData, wins, true);
                    SendText(shareData, wins, true, goods);
                }
                else
                {
                    SendText(shareData, wins, false, goods);
                    //复制文件                    
                    if (image != null)
                        SendImage(image, shareData, wins, false);
                }

                //发完图文后，发送视频或动态,优先短视频
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
        private void SendImage(Image image, List<weChatShareTextModel> shareData, List<WindowInfo> wins, bool isImageText, bool sendVideo = false, bool isJoinImage = false)
        {
            string path = System.Environment.CurrentDirectory + "\\temp\\joinimage";
            if (!isJoinImage)
            {
                if (image == null)
                {
                    return;
                }
                if (!sendVideo)
                    Clipboard.SetImage(image);
            }
            else
            {
                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);
            }
            //粘贴图片       
            foreach (var item in shareData)
            {
                try
                {

                    if (isJoinImage)
                    {
                        try
                        {
                            string fileName = EncryptHelper.MD5(item.taskid.ToString() + item.field3);

                            if (File.Exists(string.Format("{0}\\{1}.jpg", path, fileName)))
                            {
                                using (Stream stream = new FileStream(string.Format("{0}\\{1}.jpg", path, fileName), FileMode.Open))
                                {
                                    image = Image.FromStream(stream);
                                }
                                Clipboard.SetImage(image);
                            }
                            else
                            {
                                log.Info(string.Format("商品图片不存在，群[{0}]未发送", item.title));
                                continue;

                            }
                        }
                        catch (Exception)
                        {
                            //通知
                            SendNotify(item.title);
                            continue;
                        }
                    }





                    if (!isStartTask || MyUserInfo.currentUserId == 0)
                    {
                        break;
                    }

                    //如果当前微信已经发送，则结束本循环
                    if (imageResult.Contains(item.title))
                    {
                        continue;
                    }

                    wins = WinApi.GetAllDesktopWindows();
                    if (wins == null || wins.Count() == 0)
                    {
                        continue;
                    }

                    bool b = wins.Exists(win => { return win.szWindowName == item.title; });
                    if (b)
                    {
                        var win = wins.Find(w => { return w.szWindowName == item.title; });
                        if (sendVideo && win.winType == 1)
                        {

                        }
                        else
                        {
                            WinApi.SetActiveWin(win.hWnd);
                            System.Threading.Thread.Sleep(100);
                            WinApi.Paste(win.hWnd);
                            System.Threading.Thread.Sleep(100);
                            WinApi.Enter(win.hWnd, win.winType == 1);
                            SleepImage(0.5m);
                            if (!sendVideo && !imageResult.Contains(item.title))
                                imageResult.Add(item.title);
                        }

                        if (!isImageText)
                        {
                            //更新修改状态
                            UpdateShareTextStatus(item.id);
                        }
                    }
                    else
                    {
                        //通知
                        SendNotify(item.title);
                    }
                }
                catch (Exception ex)
                {
                    //通知
                    SendNotify(item.title);

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
        /// <summary>
        /// 群异常通知
        /// </summary>
        /// <param name="title"></param>
        private void SendNotify(string title)
        {

            if (notifyMap.ContainsKey(title))
            {
                DateTime nowDt = DateTime.Now;
                notifyMap.TryGetValue(title, out nowDt);
                if (nowDt.AddMinutes(30).CompareTo(DateTime.Now) < 0)
                {
                    notifyMap[title] = DateTime.Now;
                    HotJavaApi.SendUserNotice(MyUserInfo.LoginToken, WeChatTemplateMessageSceneType.群异常, title);
                }
            }
            else
            {
                notifyMap[title] = DateTime.Now;
                HotJavaApi.SendUserNotice(MyUserInfo.LoginToken, WeChatTemplateMessageSceneType.群异常, title);
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
                    hotForm.ApplyPlan(goods.goodsId, goods.goodsName, goods.goodsDetailUrl);
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
        private void SendText(List<weChatShareTextModel> shareData, List<WindowInfo> wins, bool isImageText, GoodsModel goods)
        {
            bool isLogin = true;
            foreach (var item in shareData)
            {
                try
                {

                    Tuple<string, string> resultTuple = TaobaoHelper.GetGaoYongToken(goods.goodsDetailUrl, goods.goodsId, item.tpwd,MyUserInfo.GetTbToken(),MyUserInfo.cookies, out isLogin);
                    if (resultTuple != null)
                    {
                        if (!isLogin)
                        {
                            hotForm.SendNotify();
                            System.Threading.Thread.Sleep(5000);
                            break;
                        }
                        item.status = 0;
                        if (item.text.Contains("[二合一淘口令]"))
                            item.text = item.text.Replace("[二合一淘口令]", resultTuple.Item1);
                        else
                            item.text += "复制这条信息，打开『手机淘宝』" + resultTuple.Item1 + "领券下单即可抢购宝贝";

                        if (item.text.Contains("[短链接]"))
                            item.text = item.text.Replace("[短链接]", resultTuple.Item2);
                        LogicHotTao.Instance(MyUserInfo.currentUserId).UpdateUserShareTextStatus(item.id, item.text, resultTuple.Item1);
                    }
                    else
                    {
                        bool flag = LogicHotTao.Instance(MyUserInfo.currentUserId).BuildTpwd(MyUserInfo.currentUserId, MyUserInfo.LoginToken, goods, item, appkey, appsecret);
                        if (!flag)
                            continue;
                    }



                    if (!isStartTask || MyUserInfo.currentUserId == 0)
                    {
                        break;
                    }
                    ClipboardObjectData(item.text);
                    //如果当前微信已经发送，则结束本循环
                    if (textResult.Contains(item.title))
                    {
                        continue;
                    }
                    wins = WinApi.GetAllDesktopWindows();
                    if (wins == null || wins.Count() == 0)
                    {
                        //HotJavaApi.SendUserNotice(MyUserInfo.LoginToken, WeChatTemplateMessageSceneType.微信离线);
                        continue;
                    }

                    bool b = wins.Exists(win => { return win.szWindowName == item.title; });
                    if (b)
                    {
                        var win = wins.Find(w => { return w.szWindowName == item.title; });
                        //设置微信为输入焦点
                        WinApi.SetActiveWin(win.hWnd);
                        System.Threading.Thread.Sleep(400);
                        WinApi.Paste(win.hWnd);
                        System.Threading.Thread.Sleep(300);
                        WinApi.Enter(win.hWnd, win.winType == 1);
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
                        //通知
                        SendNotify(item.title);
                    }
                }
                catch (Exception ex)
                {
                    //通知                    
                    SendNotify(item.title);

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
        /// 复制内容
        /// </summary>
        /// <param name="text"></param>
        /// <param name="count"></param>
        /// <param name="totalCount"></param>
        private void ClipboardObjectData(string text, int count = 1, int totalCount = 5)
        {
            try
            {
                Clipboard.Clear();
                Clipboard.SetDataObject(text, false, 5, 1000);
            }
            catch (Exception)
            {
                if (totalCount >= count)
                {
                    System.Threading.Thread.Sleep(1000);
                    ClipboardObjectData(text, count, totalCount);
                    count++;
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
