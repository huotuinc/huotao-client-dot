using HotTao.Controls;
using HotTaoCore;
using HotTaoCore.Logic;
using HotTaoCore.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
using WwChatHttpCore.HTTP;
using WwChatHttpCore.Objects;
using static HotTaoCore.GlobalConfig;

namespace HotTao
{
    public partial class wxLogin : Form
    {
        NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
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

        private Main hotForm { get; set; }
        public DateTime lastDate { get; set; }
        private HistoryControl historyForm { get; set; }

        /// <summary>
        /// 是否开始任务
        /// </summary>
        public bool isStartTask = false;

        /// <summary>
        /// 是否检查扫描登录状态
        /// </summary>
        private static bool isLoginCheck = false;
        /// <summary>
        /// 微信登录地址，用于刷新登录状态，避免掉线
        /// </summary>
        private string login_redirect_url = string.Empty;
        /// <summary>
        /// 判断是否中断二维码扫描登录
        /// </summary>
        public static bool loginClose = false;

        public bool isCloseWinForm = false;

        /// <summary>
        /// 当前登录微信用户
        /// </summary>
        private WXUser _me;

        /// <summary>
        /// 当前用户的所用联系人
        /// </summary>
        private List<WXUser> contact_all = new List<WXUser>();


        public wxLogin(Main mainWin, HistoryControl history)
        {
            InitializeComponent();
            hotForm = mainWin;
            historyForm = history;
        }
        private void wxLogin_Load(object sender, EventArgs e)
        {
            login_redirect_url = string.Empty;
            isCloseWinForm = false;
            DoLogin();
        }
        /// <summary>
        /// 返回二维码页面
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void linkReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkReturn.Visible = false;
            isStartTask = false;
            isLoginCheck = false;
            loginClose = true;
            DoLogin();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void picClose_Click(object sender, EventArgs e)
        {
            isStartTask = false;
            isLoginCheck = false;
            loginClose = true;
            isCloseWinForm = true;
            this.Hide();
        }

        /// <summary>
        /// 微信登录
        /// </summary>
        private void DoLogin()
        {
            picQRCode.Image = Properties.Resources.loading;
            picQRCode.SizeMode = PictureBoxSizeMode.CenterImage;
            lblTip.Text = "手机微信扫一扫以登录";
            lblTip.Width = 200;
            ((Action)(delegate ()
            {
                //异步加载二维码
                LoginService ls = new LoginService();
                //等待[判断手机扫面二维码结果]操作结束
                while (loginClose) { }
                Image qrcode = ls.GetQRCode();
                if (qrcode != null)
                {
                    this.BeginInvoke((Action)delegate ()
                    {
                        picQRCode.SizeMode = PictureBoxSizeMode.Zoom;
                        picQRCode.Image = qrcode;
                    });
                    object login_result = null;
                    Image headImg = null;
                    isLoginCheck = true;
                    while (isLoginCheck)  //循环判断手机扫面二维码结果
                    {
                        login_result = ls.LoginCheck();
                        if (login_result is Image) //已扫描 未登录
                        {
                            this.BeginInvoke((Action)delegate ()
                            {
                                lblTip.Text = "请点击手机上登录按钮";
                                picQRCode.SizeMode = PictureBoxSizeMode.CenterImage;  //显示头像
                                picQRCode.Image = login_result as Image;
                                linkReturn.Visible = true;
                                headImg = login_result as Image;
                            });
                        }
                        if (login_result is string)  //已完成登录
                        {
                            //访问登录跳转URL
                            ls.GetSidUid(login_result as string);

                            login_redirect_url = login_result.ToString();

                            //打开主界面
                            this.BeginInvoke((Action)delegate ()
                                {
                                    this.Hide();
                                    historyForm.ShowStartButtonText("暂停任务");
                                });
                            break;
                        }
                    }
                    loginClose = false;
                    if (isLoginCheck)
                    {
                        lastDate = DateTime.Now;
                        DoMainLogic();
                    }
                }
            })).BeginInvoke(null, null);

            LoadAutoHandleData();
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void StopWx()
        {
            isStartTask = false;
        }
        /// <summary>
        /// 启用
        /// </summary>
        public void StartWx()
        {
            isStartTask = true;
            LoadAutoHandleData();
        }
        /// <summary>
        /// 显示登录
        /// </summary>
        public void ShowWx()
        {
            isCloseWinForm = false;
            this.Show();
            DoLogin();
        }
        /// <summary>
        /// 微信登录初始化及同步操作
        /// </summary>
        public void DoMainLogic()
        {
            isStartTask = false;
            WXService wxs = new WXService();
            JObject init_result = wxs.WxInit();  //初始化
            contact_all.Clear();
            if (init_result != null)
            {
                InitCurrentUserData(init_result);
            }
            else return;
            JObject contact_result = wxs.GetContact(); //通讯录
            if (contact_result != null)
            {
                LoadMyContact(contact_result);
                isStartTask = true;
            }
            ExcuteTask();
            string sync_flag = "";
            JObject sync_result;
            while (true)
            {
                sync_flag = wxs.WxSyncCheck();  //同步检查
                if (sync_flag == null)
                {
                    continue;
                }
                //这里应该判断 sync_flag中selector的值
                else //有消息
                {
                    sync_result = wxs.WxSync();  //进行同步

                    //在此次进行判断自动回复或踢人操作
                    if (sync_result != null)
                    {
                        if (sync_result["AddMsgCount"] != null && sync_result["AddMsgCount"].ToString() != "0")
                        {
                            foreach (JObject m in sync_result["AddMsgList"])
                            {
                                SyncMsgHandle(wxs, m, sync_result);
                            }
                        }
                    }
                }
                System.Threading.Thread.Sleep(10);
            }
        }


        /// <summary>
        /// 初始化当前用户数据
        /// </summary>
        /// <param name="init_result">The init_result.</param>
        private void InitCurrentUserData(JObject init_result)
        {
            _me = new WXUser();
            _me.UserName = init_result["User"]["UserName"].ToString();
            _me.City = "";
            _me.HeadImgUrl = init_result["User"]["HeadImgUrl"].ToString();
            _me.NickName = init_result["User"]["NickName"].ToString();
            _me.Province = "";
            _me.PYQuanPin = init_result["User"]["PYQuanPin"].ToString();
            _me.RemarkName = init_result["User"]["RemarkName"].ToString();
            _me.RemarkPYQuanPin = init_result["User"]["RemarkPYQuanPin"].ToString();
            _me.Sex = init_result["User"]["Sex"].ToString();
            _me.Signature = init_result["User"]["Signature"].ToString();


            foreach (JObject contact in init_result["ContactList"])  //部分好友名单
            {
                WXUser user = new WXUser();
                user.UserName = contact["UserName"].ToString();
                user.City = contact["City"].ToString();
                user.HeadImgUrl = contact["HeadImgUrl"].ToString();
                user.NickName = contact["NickName"].ToString();
                user.Province = contact["Province"].ToString();
                user.PYQuanPin = contact["PYQuanPin"].ToString();
                user.RemarkName = contact["RemarkName"].ToString();
                user.RemarkPYQuanPin = contact["RemarkPYQuanPin"].ToString();
                user.Sex = contact["Sex"].ToString();
                user.Signature = contact["Signature"].ToString();
                user.IsOwner = Convert.ToInt32(contact["IsOwner"].ToString());
                contact_all.Add(user);
            }

        }


        /// <summary>
        /// 加载我的通讯录
        /// </summary>
        /// <param name="contact_result">The contact_result.</param>
        private void LoadMyContact(JObject contact_result)
        {
            foreach (JObject contact in contact_result["MemberList"])  //完整好友名单
            {
                WXUser user = new WXUser();
                user.UserName = contact["UserName"].ToString();
                user.City = contact["City"].ToString();
                user.HeadImgUrl = contact["HeadImgUrl"].ToString();
                user.NickName = contact["NickName"].ToString();
                user.Province = contact["Province"].ToString();
                user.PYQuanPin = contact["PYQuanPin"].ToString();
                user.RemarkName = contact["RemarkName"].ToString();
                user.RemarkPYQuanPin = contact["RemarkPYQuanPin"].ToString();
                user.Sex = contact["Sex"].ToString();
                user.Signature = contact["Signature"].ToString();
                user.IsOwner = Convert.ToInt32(contact["IsOwner"].ToString());
                //判断是否存在重复
                if (!contact_all.Exists((item) => { return item.UserName == user.UserName; }))
                    contact_all.Add(user);
            }
        }





        /// <summary>
        /// 消息同步操作
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="m">The m.</param>
        private void SyncMsgHandle(WXService service, JObject m, JObject sync_result)
        {
            if (MyUserInfo.currentUserId == 0) return;
            //自己发消息时，from为自己的id，否则为群id
            string from = m["FromUserName"].ToString();
            //不是自己发消息时，to为自己的id,否则为群id
            string to = m["ToUserName"].ToString();
            string content = m["Content"].ToString();

            int msgtype = 0;
            int.TryParse(m["MsgType"].ToString(), out msgtype);
            //判断发送方不是本人,且目标是群聊
            if (_me.UserName == to && from.Contains("@@"))
            {
                //获取发送者标识id;
                var msgSendUser = content.Split(':')[0];
                //获取当前群信息
                WXUser user = contact_all.Find((WXUser obj) =>
                {
                    return obj.UserName == from;
                });
                if (user == null) return;
                string nickName = GetCurrentMessageUserNickName(service, msgSendUser);
                switch (msgtype)
                {
                    case (int)WxMsgType.文本消息:
                        //自动回复
                        AutoReplyChatroom(service, user.ShowName, from, content, nickName);
                        //RemoveChatroom(service, user, from, to);
                        break;
                    case (int)WxMsgType.图片消息:
                    case (int)WxMsgType.分享链接:
                    case (int)WxMsgType.共享名片:
                        RemoveChatroom(service, user, msgSendUser, from, nickName);
                        break;
                    default:
                        break;
                }
            }
        }


        /// <summary>
        /// 获取当前发消息人的昵称
        /// </summary>
        /// <param name="CurrentMsgSendUserId">The current MSG send user identifier.</param>
        /// <param name="memberlist_result">The memberlist_result.</param>
        /// <returns>System.String.</returns>
        private string GetCurrentMessageUserNickName(WXService service, string CurrentMsgSendUserId)
        {
            //根据群用户ID，获取用户信息
            try
            {
                JObject contact_result = service.GetChatRoomContactList(CurrentMsgSendUserId);
                if (contact_result == null) return null;
                var ContactList = contact_result["ContactList"];
                if (ContactList == null || ContactList.Count() == 0) return null;
                return ContactList[0]["NickName"].ToString();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return string.Empty;
            }
        }

        /// <summary>
        /// 回复关键字列表
        /// </summary>
        private static List<WxAutoReplyKeywordModel> keyList = null;
        /// <summary>
        /// 回复微信群列表
        /// </summary>
        private static List<WxAutoReplyModel> weChatGroupList = null;
        /// <summary>
        /// 获取自动操作数据
        /// </summary>
        public void LoadAutoHandleData()
        {
            ((Action)(delegate ()
            {
                //回复微信群列表
                weChatGroupList = LogicUser.Instance.GetUserReplyWeChatList(MyUserInfo.LoginToken, -1);
                //回复关键字
                keyList = LogicUser.Instance.GetUserReplyKeywordList(MyUserInfo.LoginToken);
            })).BeginInvoke(null, null);

        }


        /// <summary>
        /// 自动回复群聊
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="ShowName">群标题</param>
        /// <param name="to"></param>
        /// <param name="content">The content.</param>
        private void AutoReplyChatroom(WXService service, string ShowName, string to, string content, string nickName)
        {
            if (MyUserInfo.currentUserId == 0) return;

            //判断是否自动回复
            if (hotForm.myConfig != null && hotForm.myConfig.enable_autoreply == 1 && weChatGroupList != null && weChatGroupList.Count() > 0)
            {
                //查找回复目标群是否存在
                bool b = weChatGroupList.Exists((group) => { return group.handleType == 0 && group.wechattitle == ShowName; });
                if (!b) return;

                //查找回复关键字是否存在
                var keyword = keyList.Find((keys) => { return content.Contains(keys.replyKeyword); });
                if (keyword == null) return;

                if (keyword.replyType == 0 && !string.IsNullOrEmpty(keyword.replyContent))
                {
                    if (!string.IsNullOrEmpty(nickName))
                        service.SendMsg("@" + nickName + " " + keyword.replyContent, _me.UserName, to, 1);
                    else
                        service.SendMsg(keyword.replyContent, _me.UserName, to, 1);
                }
            }
        }

        /// <summary>
        /// 将目标移除群聊(当前用户必须是群主)
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="to">To.</param>
        /// <param name="from">From.</param>
        private void RemoveChatroom(WXService service, WXUser user, string to, string from, string nickName)
        {
            if (MyUserInfo.currentUserId == 0) return;
            if (user == null) return;
            if (user.IsOwner == 1)
            {
                if (hotForm.myConfig != null && hotForm.myConfig.enable_autoremove == 1 && weChatGroupList != null && weChatGroupList.Count() > 00)
                {
                    //查找回复目标群是否存在
                    bool b = weChatGroupList.Exists((group) => { return group.handleType == 1 && group.wechattitle == user.ShowName; });
                    if (!b) return;
                    //TODO:踢人操作
                    service.DeleteChatroom(from, to);
                    //
                    if (!string.IsNullOrEmpty(nickName))
                        service.SendMsg("【" + nickName + "】已被管理员移除群", _me.UserName, from, 1);
                }
            }
        }






        /// <summary>
        /// 执行任务
        /// </summary>
        private void ExcuteTask()
        {
            new Thread(() =>
            {
                int handleTimeout = 2000, sendGoodsTimeout = 40 * 1000, imageTextSort = 0, taskTimeout = 30 * 1000;

                if (hotForm.myConfig != null)
                {
                    ConfigSendTimeModel cfgTime = string.IsNullOrEmpty(hotForm.myConfig.send_time_config) ? null : JsonConvert.DeserializeObject<ConfigSendTimeModel>(hotForm.myConfig.send_time_config);
                    if (cfgTime != null)
                    {
                        handleTimeout = cfgTime.handleInterval * 1000;
                        sendGoodsTimeout = cfgTime.goodsinterval * 1000;
                        imageTextSort = cfgTime.imagetextsort;
                        taskTimeout = cfgTime.taskinterval * 1000;
                    }
                }
                //获取执行的任务
                while (true)
                {
                    if (MyUserInfo.currentUserId == 0 || !isStartTask) continue;
                    WXService wxs = new WXService();
                    //获取要执行的数据
                    List<ReplyResponeModel> lst = isStartTask ? LogicTaskPlan.Instance.GetSoonExecuteTaskplan(MyUserInfo.LoginToken) : null;
                    if (lst != null && lst.Count() > 0)
                    {
                        int taskid = lst[0].taskid;
                        foreach (var item in lst)
                        {
                            if (!isStartTask || MyUserInfo.currentUserId == 0)
                                break;
                            int dataid = item.id;
                            ((Action)(delegate ()
                            {
                                //更新执行状态
                                LogicTaskPlan.Instance.UpdateExecuteTaskFinished(MyUserInfo.LoginToken, dataid);
                            })).BeginInvoke(null, null);

                            WXUser user = contact_all.Find((WXUser obj) => { return obj.ShowName.Contains(item.title); });
                            if (user != null)
                            {
                                Send(wxs, item, user.UserName, handleTimeout, imageTextSort);
                                //每个商品
                                System.Threading.Thread.Sleep(sendGoodsTimeout);
                            }
                        }
                        if (isStartTask && MyUserInfo.currentUserId > 0)
                        {
                            //更新任务状态
                            LogicTaskPlan.Instance.UpdateTaskFinished(MyUserInfo.LoginToken, taskid);
                        }
                        //执行任务数据间隔
                        System.Threading.Thread.Sleep(taskTimeout);
                    }
                    else
                    {
                        //如果当前没有获取到执行任务数据，则暂停1分钟重新获取
                        System.Threading.Thread.Sleep(60 * 1000);
                    }
                }
            })
            { IsBackground = true }.Start();
        }


        /// <summary>
        /// 开始发送
        /// </summary>
        /// <param name="wxs">The WXS.</param>
        /// <param name="item">The item.</param>
        /// <param name="to">To.</param>
        /// <param name="handleTimeout">操作间隔</param>
        /// <param name="imageTextSort">图文发送顺序，0是先图后文</param>
        private void Send(WXService wxs, ReplyResponeModel item, string to, int handleTimeout, int imageTextSort)
        {
            //发送图片给指定用户
            try
            {
                if (imageTextSort == 0)
                {
                    wxs.SendImageToUserName(to, item.logo);
                    //发完图片后，间隔2秒再发文本
                    System.Threading.Thread.Sleep(handleTimeout);
                    if (!string.IsNullOrEmpty(item.text))
                        wxs.SendMsg(item.text, _me.UserName, to, 1);
                }
                else
                {
                    if (!string.IsNullOrEmpty(item.text))
                        wxs.SendMsg(item.text, _me.UserName, to, 1);
                    //发完文本后，间隔2秒再发图片
                    System.Threading.Thread.Sleep(handleTimeout);
                    wxs.SendImageToUserName(to, item.logo);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
    }
}
