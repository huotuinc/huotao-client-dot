using HotTao.Controls;
using HotTaoCore.Logic;
using HotTaoCore.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using WwChatHttpCore.HTTP;
using WwChatHttpCore.Objects;
using static HotTaoCore.GlobalConfig;
using static HotTaoCore.Models.SQLiteEntitysModel;

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
        public HistoryControl historyForm { get; set; }


        public TaskControl taskForm { get; set; }

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
        public List<WXUser> contact_all = new List<WXUser>();



        public wxLogin(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }

        public wxLogin(Main mainWin, HistoryControl control)
        {
            InitializeComponent();
            hotForm = mainWin;
            historyForm = control;
        }

        public wxLogin(Main mainWin, TaskControl control)
        {
            InitializeComponent();
            hotForm = mainWin;
            taskForm = control;
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
            if (isLoginCheck)
                loginClose = true;
            else
                loginClose = false;
            isStartTask = false;
            isLoginCheck = false;

            isCloseWinForm = true;
            this.Hide();
        }


        public wxContacts wxcontactsForm { get; set; }

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
                                wxcontactsForm = new wxContacts(this, headImg);
                                wxcontactsForm.Show();
                                this.Hide();
                            });
                            isStartTask = true;
                            if (historyForm != null)
                                historyForm.ShowStartButtonText("暂停计划");
                            if (taskForm != null)
                                taskForm.ShowStartButtonText("暂停计划");


                            break;
                        }
                    }
                    loginClose = false;
                    if (isLoginCheck)
                    {
                        isLoginCheck = false;
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
            //isStartTask = false;
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
                //isStartTask = true;
            }
            //执行任务转发
            //ExcuteTask();

            //执行本地任务转发
            Send();

            string sync_flag = "";
            JObject sync_result;
            while (true)
            {
                if (isCloseWinForm) break;

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

                        //判断是否掉线
                        if (sync_result["BaseResponse"]["Ret"].ToObject<int>() > 0)
                        {
                            isStartTask = false;
                            isLoginCheck = false;
                            isCloseWinForm = true;

                            if (historyForm != null)
                                historyForm.ShowStartButtonText("启动计划");
                            if (taskForm != null)
                                taskForm.ShowStartButtonText("启动计划");

                            if (wxcontactsForm != null)
                                CloseMyContact();

                            hotForm.AlertTip("微信掉线，请重新授权登录");
                            break;
                        }
                        if (sync_result["AddMsgCount"] != null && sync_result["AddMsgCount"].ToString() != "0")
                        {
                            foreach (JObject m in sync_result["AddMsgList"])
                            {
                                SyncMsgHandle(wxs, m);
                            }
                        }
                    }
                }
                Thread.Sleep(2000);
            }
        }


        /// <summary>
        /// 重新加载联系人
        /// </summary>
        public void ReloadContact()
        {
            new Thread(() =>
            {
                WXService wxs = new WXService();
                JObject contact_result = wxs.GetContact(); //通讯录
                if (contact_result != null)
                {
                    LoadMyContact(contact_result);
                }
            })
            { IsBackground = true }.Start();

        }



        private void CloseMyContact()
        {
            if (this.wxcontactsForm.InvokeRequired)
            {
                this.wxcontactsForm.Invoke(new Action(CloseMyContact), new object[] { });
            }
            else
            {
                wxcontactsForm.Close();
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

            if (wxcontactsForm != null)
                wxcontactsForm.SetTitle(_me.ShowName);

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
                if (wxcontactsForm != null)
                    wxcontactsForm.SetContactsView(user);
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
                {
                    contact_all.Add(user);
                    if (wxcontactsForm != null)
                        wxcontactsForm.SetContactsView(user);
                }
                else
                {
                    contact_all.ForEach(item =>
                    {
                        if (item.UserName == user.UserName)
                        {
                            item.NickName = user.NickName;
                            if (wxcontactsForm != null)
                                wxcontactsForm.SetContactsView(user);
                        }
                    });
                }
            }
        }





        /// <summary>
        /// 消息同步操作
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="m">The m.</param>
        private void SyncMsgHandle(WXService service, JObject m)
        {
            //用户退出或任务停止时
            if (MyUserInfo.currentUserId == 0) return;

            //自己发消息时，from为自己的id，否则为群id
            string from = m["FromUserName"].ToString();
            //不是自己发消息时，to为自己的id,否则为群id
            string to = m["ToUserName"].ToString();

            //判断发送方不是本人,且目标是群聊
            if (_me.UserName == to && from.Contains("@@"))
            {
                string content = m["Content"].ToString();
                int msgtype = 0;
                int.TryParse(m["MsgType"].ToString(), out msgtype);
                //获取当前群信息
                WXUser user = contact_all.Find((WXUser obj) => { return obj.UserName == from; });
                if (user == null) return;

                string nickName = string.Empty, msgSendUser = string.Empty, messageContent = string.Empty;
                switch (msgtype)
                {
                    case (int)WxMsgType.文本消息:
                        //获取发送者标识id;
                        msgSendUser = content.Split(':')[0];
                        messageContent = content.Split(':')[1];
                        //获取当前发送方的昵称
                        nickName = GetCurrentMessageUserNickName(service, msgSendUser, user.UserName);

                        //SendLog(user.ShowName + ":[" + nickName + "]发了一条消息:" + messageContent);

                        //自动回复
                        AutoReplyChatroom(service, user.ShowName, from, messageContent, nickName);
                        //自动踢人
                        RemoveChatroom(service, user, msgSendUser, from, nickName, msgtype, messageContent);
                        break;
                    case (int)WxMsgType.图片消息:
                    case (int)WxMsgType.分享链接:
                    case (int)WxMsgType.共享名片:
                        //获取发送者标识id;
                        msgSendUser = content.Split(':')[0];
                        //获取当前发送方的昵称
                        nickName = GetCurrentMessageUserNickName(service, msgSendUser, user.UserName);



                        //if (msgtype == (int)WxMsgType.图片消息)
                        //    SendLog(user.ShowName + ":[" + nickName + "]发了一张图片");
                        //else if (msgtype == (int)WxMsgType.分享链接)
                        //    SendLog(user.ShowName + ":[" + nickName + "]分享了一条链接");
                        //else if (msgtype == (int)WxMsgType.共享名片)
                        //    SendLog(user.ShowName + ":[" + nickName + "]共享了一张名片");
                        //自动踢人
                        RemoveChatroom(service, user, msgSendUser, from, nickName, msgtype, messageContent);
                        break;
                    case (int)WxMsgType.系统消息:

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
        private string GetCurrentMessageUserNickName(WXService service, string CurrentMsgSendUserId, string groupUserName)
        {
            //根据群用户ID，获取用户信息
            try
            {
                JObject contact_result = service.GetChatRoomContactList(groupUserName);
                if (contact_result == null) return null;
                var ContactList = contact_result["ContactList"];
                if (ContactList == null || ContactList.Count() == 0) return null;

                var memberList = ContactList[0]["MemberList"];
                if (memberList == null || memberList.Count() == 0) return null;
                string nickName = string.Empty;
                foreach (var item in memberList)
                {
                    if (item["UserName"].ToString() == CurrentMsgSendUserId)
                    {
                        nickName = item["NickName"].ToString();
                        break;
                    }
                }
                return nickName;
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

            //是否过滤当前用户操作
            if (!string.IsNullOrEmpty(nickName) && !string.IsNullOrEmpty(MyUserInfo.filterUserGroups))
            {
                bool isExist = MyUserInfo.filterUserGroups.Contains("[" + nickName + "]");
                if (isExist)
                    return;
            }



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

        private Dictionary<string, int> _chatKey = new Dictionary<string, int>();

        /// <summary>
        /// 将目标移除群聊(当前用户必须是群主)
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="to">To.</param>
        /// <param name="from">From.</param>
        private void RemoveChatroom(WXService service, WXUser user, string to, string from, string nickName, int msgtype, string messageContent)
        {
            if (MyUserInfo.currentUserId == 0) return;

            //是否过滤当前用户操作
            if (!string.IsNullOrEmpty(nickName) && !string.IsNullOrEmpty(MyUserInfo.filterUserGroups))
            {
                bool isExist = MyUserInfo.filterUserGroups.Contains("[" + nickName + "]");
                if (isExist)
                    return;
            }

            if (user == null) return;
            if (user.IsOwner == 1)
            {
                if (hotForm.myConfig != null && hotForm.myConfig.enable_autoremove == 1 && weChatGroupList != null && weChatGroupList.Count() > 0)
                {
                    //获取踢人条件配置
                    ConfigWhereModel cfgWhere = string.IsNullOrEmpty(hotForm.myConfig.where_config) ? null : JsonConvert.DeserializeObject<ConfigWhereModel>(hotForm.myConfig.where_config);
                    if (cfgWhere == null || string.IsNullOrEmpty(cfgWhere.auto_remove_user_where)) return;
                    AutoRemoveUserWhereModel auto_remove = JsonConvert.DeserializeObject<AutoRemoveUserWhereModel>(cfgWhere.auto_remove_user_where);
                    if (auto_remove == null) return;

                    bool isRemoveRoomUser = false;

                    switch (msgtype)
                    {
                        case (int)WxMsgType.文本消息:
                            if (auto_remove.enable_share_link == 1)
                            {
                                Regex regex = new Regex("<br/>");
                                messageContent = regex.Replace(messageContent, "");
                                isRemoveRoomUser = auto_remove.send_text_lenght <= messageContent.Length;
                                //如果为false，则判断内容里是否包含连接
                                if (!isRemoveRoomUser)
                                {
                                    //TODO:判断消息体中是否包含网址                 
                                }
                            }
                            break;
                        case (int)WxMsgType.图片消息:
                            isRemoveRoomUser = IsRemoveRoomUserToSendImageType(service, nickName, from, auto_remove, to);
                            break;
                        case (int)WxMsgType.共享名片:
                            isRemoveRoomUser = auto_remove.enable_share_card == 1;
                            break;
                        case (int)WxMsgType.分享链接:
                            isRemoveRoomUser = auto_remove.enable_share_link == 1;
                            break;
                        default:
                            break;
                    }
                    if (!isRemoveRoomUser) return;

                    //查找回复目标群是否存在
                    bool b = weChatGroupList.Exists((group) => { return group.handleType == 1 && group.wechattitle == user.ShowName; });
                    if (!b) return;
                    //TODO:踢人操作
                    service.DeleteChatroom(from, to);
                    //移除后，通知微信群
                    if (!string.IsNullOrEmpty(nickName))
                        service.SendMsg("【" + nickName + "】已被管理员移除群", _me.UserName, from, 1);
                }
            }
        }



        /// <summary>
        /// 发送图片消息是否踢出群
        /// </summary>
        /// <param name="auto_remove"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private bool IsRemoveRoomUserToSendImageType(WXService service, string nickName, string from, AutoRemoveUserWhereModel auto_remove, string to)
        {
            bool isRemoveRoomUser = false;
            if (auto_remove == null) return isRemoveRoomUser;

            if (auto_remove.enable_send_image == 1)
            {
                isRemoveRoomUser = auto_remove.send_image_count <= 1;
                if (!isRemoveRoomUser)
                {
                    int count = 1;
                    if (!_chatKey.ContainsKey(to))
                        _chatKey.Add(to, 1);
                    else
                    {
                        int c = count = _chatKey[to];
                        if (auto_remove.send_image_count > c + 1)
                        {
                            _chatKey[to] = c + 1;
                            count += 1;
                        }
                        else
                            isRemoveRoomUser = true;
                    }

                    if (!isRemoveRoomUser && count >= auto_remove.send_image_count - 1)
                        service.SendMsg("@" + nickName + " 请撤回内容，如有下次，直接踢出群！谢谢配合。", _me.UserName, from, 1);

                }
            }
            return isRemoveRoomUser;
        }





        /// <summary>
        /// 执行网络任务数据
        /// </summary>
        private void ExcuteTask()
        {
            new Thread(() =>
            {
                int handleTimeout = 2000, sendGoodsTimeout = 40 * 1000, imageTextSort = 0, taskTimeout = 30 * 1000;

                if (hotForm.myConfig != null)
                {
                    //获取操作时间间隔配置
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
                    if (isCloseWinForm) break;
                    if (MyUserInfo.currentUserId == 0 || !isStartTask)
                    {
                        //如果当前没有获取到执行任务数据，则暂停1分钟重新获取
                        System.Threading.Thread.Sleep(taskTimeout);
                        WXService wxs = new WXService();
                        continue;
                    }
                    //获取要执行的数据
                    //数据数量=任务的商品数量*任务的群数
                    //数据顺序：根据商品排序
                    List<ReplyResponeModel> lst = isStartTask ? LogicTaskPlan.Instance.GetSoonExecuteTaskplan(MyUserInfo.LoginToken) : null;
                    if (lst != null && lst.Count() > 0)
                    {
                        int taskid = lst[0].taskid;
                        int len = lst.Count() - 1;
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
                                WXService wxs = new WXService();
                                Send(wxs, item, user, handleTimeout, imageTextSort);

                                if (lst.IndexOf(item) != len)
                                    System.Threading.Thread.Sleep(sendGoodsTimeout);//每发完一次图文，需要等待n秒，才执行下一个操作
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
                        WXService wxs = new WXService();
                    }
                }
            })
            { IsBackground = true }.Start();
        }


        /// <summary>
        /// 商品图片缓存
        /// </summary>
        private Dictionary<int, string> _goodsImageCache = new Dictionary<int, string>();

        /// <summary>
        /// 开始发送
        /// </summary>
        /// <param name="wxs">The WXS.</param>
        /// <param name="item">The item.</param>
        /// <param name="to">To.</param>
        /// <param name="handleTimeout">操作间隔</param>
        /// <param name="imageTextSort">图文发送顺序，0是先图后文</param>
        private void Send(WXService wxs, ReplyResponeModel item, WXUser user, int handleTimeout, int imageTextSort)
        {

            string mediaid = string.Empty;
            if (_goodsImageCache.ContainsKey(item.goodsid))
                _goodsImageCache.TryGetValue(item.goodsid, out mediaid);

            string to = user.UserName;
            //发送图片给指定用户
            try
            {
                if (imageTextSort == 0)//先发图片，后发文本
                {
                    if (string.IsNullOrEmpty(mediaid))
                        mediaid = wxs.GetImageMediaId(to, item.logo);
                    if (!string.IsNullOrEmpty(mediaid))
                    {
                        _goodsImageCache[item.goodsid] = mediaid;
                        wxs.SendPic(mediaid, _me.UserName, to);

                        //发完图片后，间隔2秒再发文本
                        System.Threading.Thread.Sleep(handleTimeout);
                    }
                    if (!string.IsNullOrEmpty(item.text))
                        wxs.SendMsg(item.text, _me.UserName, to, 1);
                }
                else //先发文字，后发图片
                {
                    if (!string.IsNullOrEmpty(item.text))
                    {
                        wxs.SendMsg(item.text, _me.UserName, to, 1);
                        //发完文本后，间隔2秒再发图片
                        System.Threading.Thread.Sleep(handleTimeout);
                    }

                    if (string.IsNullOrEmpty(mediaid))
                        mediaid = wxs.GetImageMediaId(to, item.logo);
                    if (!string.IsNullOrEmpty(mediaid))
                    {
                        _goodsImageCache[item.goodsid] = mediaid;
                        wxs.SendPic(mediaid, _me.UserName, to);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }




        /// <summary>
        /// 检查主动发送消息
        /// </summary>
        public void CheckActiveSendMessage()
        {
            new Thread(() =>
            {
                if (isCloseWinForm)
                    return;
                if (MyUserInfo.currentUserId == 0)
                    return;
                if (MyUserInfo.SendMessageStatus == 1 && !string.IsNullOrEmpty(MyUserInfo.SendMessageText) && MyUserInfo.currentUserId > 0)
                {
                    //回复微信群列表
                    weChatGroupList = LogicUser.Instance.GetUserReplyWeChatList(MyUserInfo.LoginToken, -1);
                    //回复关键字
                    keyList = LogicUser.Instance.GetUserReplyKeywordList(MyUserInfo.LoginToken);

                    WXService wxs = new WXService();
                    if (weChatGroupList != null && weChatGroupList.Count() > 0)
                    {
                        var data = weChatGroupList.FindAll((item) =>
                          {
                              return item.handleType == 0;
                          });
                        foreach (var item in data)
                        {
                            WXUser user = contact_all.Find((WXUser obj) => { return obj.ShowName.Contains(item.wechattitle); });
                            if (user == null) continue;
                            if (!string.IsNullOrEmpty(MyUserInfo.SendMessageText))
                            {
                                wxs.SendMsg(MyUserInfo.SendMessageText, _me.UserName, user.UserName, 1);
                                //                                SendLog(user.ShowName + ":主动文字发送完成");
                            }
                            System.Threading.Thread.Sleep(2000);
                        }
                    }
                    MyUserInfo.SendMessageStatus = 2;
                }
            })
            { IsBackground = true }.Start();
        }


































        /// <summary>
        /// 执行本地任务数据
        /// </summary>
        private void Send()
        {
            new Thread(() =>
            {
                loadConfig();
                while (true)
                {
                    if (isCloseWinForm) break;
                    if (MyUserInfo.currentUserId == 0 || !isStartTask)
                    {
                        //如果当前没有获取到执行任务数据，则暂停1分钟重新获取
                        System.Threading.Thread.Sleep(60 * 1000);
                        WXService wxs = new WXService();
                        continue;
                    }
                    if (contact_all != null && contact_all.Count() > 0)
                    {
                        StartSend();
                    }
                    else
                        System.Threading.Thread.Sleep(10 * 1000);
                }
            })
            { IsBackground = true }.Start();
        }


        /// <summary>
        /// 开始执行发送
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="image">The image.</param>
        private void StartSend()
        {
            //获取任务数据
            var taskdata = LogicHotTao.Instance(MyUserInfo.currentUserId).FindByUserTaskPlanList(MyUserInfo.currentUserId);
            if (taskdata == null || taskdata.Count() == 0)
            { //休息一下
                SleepTask();
                WXService wxs = new WXService();
                return;
            }

            //获取待执行的任务数据
            taskdata = taskdata.FindAll(item => { return item.status == 0 && item.isTpwd == 1; }).OrderBy(x => x.startTime).ToList();

            if (taskdata == null || taskdata.Count() == 0)
            {
                //休息一下
                SleepTask();
                WXService wxs = new WXService();
                return;
            }
            //排序
            taskdata = taskdata.OrderBy(x => x.startTime).ToList();
            foreach (var item in taskdata)
            {
                WXService wxs = new WXService();
                if (!isStartTask || MyUserInfo.currentUserId == 0) break;
                int taskid = Convert.ToInt32(item.id);

                List<UserPidTaskModel> lst = JsonConvert.DeserializeObject<List<UserPidTaskModel>>(item.goodsText);
                List<int> ids = new List<int>();
                //如果群数据和商品数据都为空时
                if (lst == null || lst.Count() == 0)
                {
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
                    LogicHotTao.Instance(MyUserInfo.currentUserId).UpdateUserTaskPlanExecStatus(taskid, 2);
                    continue;
                }
                //发送商品数据
                var result = SendGoods(goodslist, taskid);
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

        /// <summary>
        /// 发送任务商品
        /// </summary>
        /// <param name="goodslist">The goodslist.</param>
        /// <param name="taskid">The taskid.</param>
        /// <param name="lst">The LST.</param>
        private bool SendGoods(List<GoodsModel> goodslist, int taskid)
        {
            bool result = false;
            var data = LogicHotTao.Instance(MyUserInfo.currentUserId).FindByUserWechatShareTextList(MyUserInfo.currentUserId);
            if (data == null) return true;
            foreach (var goods in goodslist)
            {
                WXService wxs = new WXService();
                if (!isStartTask || MyUserInfo.currentUserId == 0)
                {
                    result = false;
                    break;
                }
                result = true;
                int goodsId = Convert.ToInt32(goods.id);

                var shareData = data.FindAll(share =>
                {
                    return share.goodsid == goodsId && share.taskid == taskid;
                });
                if (shareData == null || shareData.Count() == 0)
                    continue;
                result = SendWeChatGroupShareText(shareData, goods);
                if (!result)
                    break;
            }
            return result;

        }

        /// <summary>
        /// 将商品发送到相应的群
        /// </summary>
        /// <param name="shareData">The share data.</param>
        /// <param name="goods">The goods.</param>
        /// <param name="lst">The LST.</param>
        private bool SendWeChatGroupShareText(List<weChatShareTextModel> shareData, GoodsModel goods)
        {
            bool flag = false;
            foreach (var item in shareData)
            {
                WXService wxs = new WXService();

                if (!isStartTask || MyUserInfo.currentUserId == 0)
                {
                    flag = false;
                    break;
                }
                flag = true;

                WXUser user = contact_all.Find((WXUser obj) => { return obj.ShowName.Contains(item.title); });
                if (user == null) continue;

                string to = user.UserName;


                string mediaid = string.Empty;
                if (_goodsImageCache.ContainsKey(item.goodsid))
                    _goodsImageCache.TryGetValue(item.goodsid, out mediaid);

                //发送图片给指定用户
                try
                {
                    if (isImageText())//先发图片，后发文本
                    {
                        if (string.IsNullOrEmpty(mediaid))
                            mediaid = wxs.GetImageMediaId(to, goods.goodsMainImgUrl);
                        if (!string.IsNullOrEmpty(mediaid))
                        {
                            _goodsImageCache[item.goodsid] = mediaid;
                            bool result = wxs.SendPic(mediaid, _me.UserName, to);
                            if (result)
                                SendLog(user.ShowName + ":图片发送完成");
                            else
                                SendLog(user.ShowName + ":图片发送失败");
                            //发完图片后，间隔n秒再发文本
                            SleepImage(1);
                        }
                        else
                        {
                            SendLog(user.ShowName + ":图片发送失败");
                        }

                        if (!string.IsNullOrEmpty(item.text))
                        {
                            bool result = wxs.SendMsg(item.text, _me.UserName, to, 1);
                            if (result)
                                SendLog(user.ShowName + ":文字发送完成");
                            else
                                SendLog(user.ShowName + ":文字发送失败");
                        }
                        else
                        {
                            SendLog(user.ShowName + ":文字发送失败");
                        }

                    }
                    else //先发文字，后发图片
                    {
                        if (!string.IsNullOrEmpty(item.text))
                        {
                            bool result = wxs.SendMsg(item.text, _me.UserName, to, 1);
                            if (result)
                                SendLog(user.ShowName + ":文字发送完成");
                            else
                                SendLog(user.ShowName + ":文字发送失败");

                            //发完文本后，间隔n秒再发图片
                            SleepImage(1);
                        }
                        else
                        {
                            SendLog(user.ShowName + ":文字发送失败");
                        }

                        if (string.IsNullOrEmpty(mediaid))
                            mediaid = wxs.GetImageMediaId(to, goods.goodsMainImgUrl);
                        if (!string.IsNullOrEmpty(mediaid))
                        {
                            _goodsImageCache[item.goodsid] = mediaid;
                            bool result = wxs.SendPic(mediaid, _me.UserName, to);
                            if (result)
                                SendLog(user.ShowName + ":图片发送完成");
                            else
                                SendLog(user.ShowName + ":图片发送失败");
                        }
                        else
                        {
                            SendLog(user.ShowName + ":图片发送失败");
                        }
                    }
                    //更新修改状态
                    UpdateShareTextStatus(item.id);

                    SleepGoods();
                }
                catch (Exception ex)
                {
                    AddErrorLog(item, 0);
                    log.Error(ex);
                }
            }
            return flag;
        }


        private void SendLog(string text)
        {
            try
            {
                if (wxcontactsForm != null)
                    wxcontactsForm.SetLog(text);
            }
            catch (Exception ex)
            {
                log.Error(ex);
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

        public ConfigSendTimeModel cfgTime { get; set; }

        private void loadConfig()
        {
            if (hotForm.myConfig == null)
                hotForm.myConfig = new ConfigModel();
            else
            {
                cfgTime = string.IsNullOrEmpty(hotForm.myConfig.send_time_config) ? null : JsonConvert.DeserializeObject<ConfigSendTimeModel>(hotForm.myConfig.send_time_config);

            }
        }



        /// <summary>
        /// 任务之间的间隔
        /// </summary>
        private void SleepTask()
        {
            //完成一个任务，暂停休息一下
            if (cfgTime != null)
                System.Threading.Thread.Sleep(cfgTime.taskinterval > 0 ? cfgTime.taskinterval * 1000 : 60 * 1000);
            else
                System.Threading.Thread.Sleep(60 * 1000);
        }
        /// <summary>
        /// 图文间隔
        /// </summary>
        /// <param name="interval">The interval.</param>
        private void SleepImage(int interval)
        {
            //没发一张图片，暂停休息一下
            if (cfgTime != null)
                System.Threading.Thread.Sleep(cfgTime.hdInterval > 0 ? Convert.ToInt32(cfgTime.hdInterval * 1000) : interval * 1000);
            else
                System.Threading.Thread.Sleep(2 * 1000);
        }

        /// <summary>
        ///商品间隔
        /// </summary>
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

        private void wxLogin_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
