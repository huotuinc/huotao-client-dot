using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iQQ.Net.WebQQCore.Im.Bean;
using iQQ.Net.WebQQCore.Im.Event;
using iQQ.Net.WebQQCore.Util;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace QQLogin
{
    public partial class QQMainControl : UserControl
    {
        private static KQDAL KQ = null;


        public QQMainControl()
        {

            InitializeComponent();
        }





        /// <summary>
        /// 登录成功处理
        /// </summary>
        public event QQNotifyLoginSuccessEventHandler loginSuccessHandler;

        /// <summary>
        /// 关闭QQ监控
        /// </summary>
        public event CloseQQEventHandler CloseQQHandler;

        /// <summary>
        /// 生成商品
        /// </summary>
        public event BuildGoodsEventHandler BuildGoodsHandler;

        /// <summary>
        /// 身份标识
        /// </summary>
        public string IdentificationTag { get; set; }

        /// <summary>
        /// 当前进程
        /// </summary>
        private Process currentProcess { get; set; } = null;

        /// <summary>
        /// 是否显示自动跟发功能,默认true
        /// </summary>
        public bool IsShowAutoSend { get; set; } = true;

        /// <summary>
        /// 是否显示自定义文案功能,默认true
        /// </summary>
        public bool IsShowCustomTemplate { get; set; } = true;

        /// <summary>
        /// 是否显示大牛选单,默认false
        /// </summary>
        public bool IsShowBigCowGoodsCaiji { get; set; } = false;

        /// <summary>
        /// 显示合成图,默认false
        /// </summary>
        public bool IsShowJoinImage { get; set; } = false;

        public QQLogin qqForm;

        private void QQMainControl_Load(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(IdentificationTag))
                IdentificationTag = Guid.NewGuid().ToString();


            ckbAutoSend.Visible = IsShowAutoSend;

            ckbEnableCustomTemplate.Visible = IsShowCustomTemplate;
            label4.Visible = IsShowCustomTemplate;

            ckBigCow.Visible = IsShowBigCowGoodsCaiji;

            ckbEnableJoinImage.Visible = IsShowJoinImage;



            txtStartTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtEndTime.Text = DateTime.Now.AddHours(12).ToString("yyyy-MM-dd HH:mm:ss");

            IintKQAir();
            if (KQ == null)
                KQ = new KQDAL(IdentificationTag);
        }


        public bool EnableBigCow
        {
            get
            {
                return ckBigCow.Checked;
            }
        }

        /// <summary>
        /// 判断是否启用时间配置
        /// </summary>
        public bool EnableTimeConfig
        {
            get
            {
                return ckbEnableSendTime.Checked;
            }
        }

        /// <summary>
        /// 任务开始时间
        /// </summary>
        public DateTime TaskStartTime
        {
            get
            {
                return Convert.ToDateTime(txtStartTime.Text);
            }
        }
        /// <summary>
        /// 任务结束时间
        /// </summary>
        public DateTime TaskEndTime
        {
            get
            {
                return Convert.ToDateTime(txtEndTime.Text);
            }
        }



        /// <summary>
        /// 是否启用合成图
        /// </summary>
        public bool EnableJoinImage
        {
            get
            {
                return ckbEnableJoinImage.Checked;
            }
        }


        /// <summary>
        /// 登录QQ
        /// </summary>
        private void LoginQQ()
        {
            if (qqForm == null)
            {
                qqForm = new QQLogin();
                qqForm.isShowQQGroupList = false;
                qqForm.CloseQQHandler += QqForm_CloseQQHandler;
                qqForm.loginSuccessHandler += QqForm_loginSuccessHandler;
                qqForm.GroupMsgHandler += QqForm_GroupMsgHandler;
                qqForm.GroupLoadSuccessHandler += QqForm_GroupLoadSuccessHandler;
                qqForm.ShowDialog(this);
            }
            else
            {
                CloseEx();
            }
        }


        /// <summary>
        /// qq群加载完成
        /// </summary>
        private void QqForm_GroupLoadSuccessHandler()
        {
            SetContactsView(QQGlobal.client.GetGroupList());
        }


        /// <summary>
        /// 群消息处理
        /// </summary>
        /// <param name="msgContent"></param>
        /// <param name="urls"></param>
        private void QqForm_GroupMsgHandler(long msgCode, long gid, string msgGroupName, string msgContent, string FullMessageContent, List<string> urls)
        {

            QQGroup group = QQGlobal.listenGroups.Find(g => { return g.Gid == gid; });

            //TODO:接收群消息
            QQGroupMessageModel message = new QQGroupMessageModel()
            {
                GroupName = group != null ? group.GetGroupName() : msgGroupName,
                MessageContent = msgContent,
                FullMessageContent = FullMessageContent,
                MessageStatus = 0,
                Code = msgCode
            };
            if (urls != null)
            {
                if (urls.Count() > 0)
                    message.MessageUrl1 = urls[0];
                if (urls.Count() > 1)
                    message.MessageUrl2 = urls[1];
            }
            SetMessageView(message);
            if (BuildGoodsHandler != null)
                MessageHandler(urls, message);
        }


        /// <summary>
        /// 获取QQ号码
        /// </summary>
        /// <returns></returns>
        public string GetQQ()
        {
            return lbQQAccount.Text;
        }

        /// <summary>
        /// 消息处理
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="msgCode"></param>
        /// <param name="msgContent"></param>
        private void MessageHandler(List<string> urls, QQGroupMessageModel message)
        {
            //TODO:
            if (urls != null && urls.Count() > 0)
            {
                bool isAutoSend = ckbAutoSend.Checked;
                bool isEnableCustom = ckbEnableCustomTemplate.Checked;
                new System.Threading.Thread(() =>
                {
                    try
                    {
                        //消息处理回调
                        BuildGoodsHandler?.Invoke(message.Code, message.GroupName, message.MessageContent, message.FullMessageContent, urls, isAutoSend, isEnableCustom, (ret, i, t) =>
                           {
                               string text = "";
                               switch (ret)
                               {
                                   case MessageCallBackType.正在准备:
                                       text = "正在准备";
                                       break;
                                   case MessageCallBackType.开始转链:
                                       text = string.Format("开始转链{0}/{1}", i, t);
                                       break;
                                   case MessageCallBackType.转链完成:
                                       text = string.Format("转链完成");
                                       break;
                                   case MessageCallBackType.开始创建计划:
                                       text = string.Format("创建计划..");
                                       break;
                                   case MessageCallBackType.完成:
                                       text = string.Format("已完成");
                                       break;
                                   case MessageCallBackType.未准备:
                                       text = "未准备";
                                       break;
                                   case MessageCallBackType.失败:
                                       text = "失败";
                                       break;
                                   default:
                                       break;
                               }
                               if (!string.IsNullOrEmpty(text))
                                   SetMesageViewByMessageCode(message.Code, text);
                           });

                    }
                    catch (Exception)
                    {
                        SetMesageViewByMessageCode(message.Code, "已完成");
                    }
                })
                { IsBackground = true }.Start();

            }
        }

        /// <summary>
        /// QQ登录成功回调事件
        /// </summary>
        private void QqForm_loginSuccessHandler()
        {
            LoginType = 1;
            SetBtnEnable(true);
            SetBtnText("注销");
            QQGlobal.client.GetUserFace(QQGlobal.account, (s, e) =>
            {
                if (e.Type == QQActionEventType.EvtOK)
                {
                    SetQQLogo(QQGlobal.account.Face);
                    SetLabelTitle(lbQQAccount, QQGlobal.account.QQ.ToString());
                    SetLabelTitle(lbQQNickName, QQGlobal.account.Nickname);
                }
            });

            LoadingShow();
            //TODO:处理登录成功后的逻辑
            loginSuccessHandler?.Invoke();
        }

        /// <summary>
        /// 点击关闭按钮回调事件
        /// </summary>
        private void QqForm_CloseQQHandler()
        {
            LoginType = 0;
            SetBtnEnable(true);
            SetBtnText("登录");
            //TODO:关闭窗口
            // CloseQQHandler?.Invoke();

            CloseEx();
        }



        private void SetBtnEnable(bool enable)
        {
            if (btnLogoutQQ.InvokeRequired)
            {
                btnLogoutQQ.Invoke(new Action<bool>(SetBtnEnable), new object[] { enable });
            }
            else
            {
                btnLogoutQQ.Enabled = enable;
            }
        }
        private void SetBtnText(string text)
        {
            if (btnLogoutQQ.InvokeRequired)
            {
                btnLogoutQQ.Invoke(new Action<string>(SetBtnText), new object[] { text });
            }
            else
            {
                btnLogoutQQ.Text = text;
            }
        }


        /// <summary>
        /// 关闭窗体
        /// </summary>
        public void CloseEx()
        {
            if (qqForm != null)
            {
                qqForm.Close();
                qqForm = null;
            }
            QQGlobal.Reset();
        }

        private void SetLabelTitle(Label lbControl, string text)
        {
            if (lbControl.InvokeRequired)
            {
                lbControl.Invoke(new Action<Label, string>(SetLabelTitle), new object[] { lbControl, text });
            }
            else
            {
                lbControl.Text = text;
            }
        }

        private void SetQQLogo(Image logo)
        {
            if (picLogo.InvokeRequired)
            {
                picLogo.Invoke(new Action<Image>(SetQQLogo), new object[] { logo });
            }
            else
            {
                picLogo.Image = logo;
            }
        }



        /// <summary>
        /// 显示loading
        /// </summary>
        private void LoadingShow()
        {
            if (this.picLoading.InvokeRequired)
            {
                this.picLoading.Invoke(new Action(LoadingShow));
            }
            else
            {
                picLoading.Visible = true;
            }
        }

        /// <summary>
        /// 加载QQ群通讯录
        /// </summary>
        /// <param name="contact_all">The contact_all.</param>
        public void SetContactsView(List<QQGroup> contact_all)
        {
            if (dgvContact.InvokeRequired)
            {
                this.dgvContact.Invoke(new Action<List<QQGroup>>(SetContactsView), new object[] { contact_all });
            }
            else
            {
                this.dgvContact.Rows.Clear();
                int i = dgvContact.Rows.Count;
                foreach (var user in contact_all)
                {
                    dgvContact.Rows.Add();
                    ++i;

                    dgvContact.Rows[i - 1].Cells["GroupGid"].Value = user.Gid;

                    dgvContact.Rows[i - 1].Cells["GroupTitle"].Value = user.Name;
                    var group = QQGlobal.listenGroups != null ? QQGlobal.listenGroups.Find((g) => { return g.Gid == user.Gid; }) : null;
                    if (group != null)
                    {
                        dgvContact.Rows[i - 1].Cells["GroupStatus"].Value = (group.isListen ? "已监控" : "");
                        dgvContact.Rows[i - 1].Cells["GroupAlias"].Value = group.Alias;
                    }

                    dgvContact.Rows[i - 1].DefaultCellStyle.BackColor = QQGlobal.backColor;
                    dgvContact.Rows[i - 1].DefaultCellStyle.SelectionBackColor = QQGlobal.backColor;
                }
                picLoading.Visible = false;
                new System.Threading.Thread(() =>
                {
                    while (string.IsNullOrEmpty(QQGlobal.account.Nickname)) { }
                    SetLabelTitle(lbQQNickName, QQGlobal.account.Nickname);
                })
                { IsBackground = true }.Start();
            }
        }


        /// <summary>
        /// 加载QQ群通讯录
        /// </summary>
        /// <param name="contact_all">The contact_all.</param>
        public void SetContactsView(List<GroupInfo> contact_all)
        {
            if (dgvContact.InvokeRequired)
            {
                this.dgvContact.Invoke(new Action<List<QQGroup>>(SetContactsView), new object[] { contact_all });
            }
            else
            {
                this.dgvContact.Rows.Clear();
                int i = dgvContact.Rows.Count;
                foreach (var user in contact_all)
                {
                    dgvContact.Rows.Add();
                    ++i;

                    dgvContact.Rows[i - 1].Cells["GroupGid"].Value = user.group_number;

                    dgvContact.Rows[i - 1].Cells["GroupTitle"].Value = user.group_name;
                    var group = QQGlobal.listenGroups != null ? QQGlobal.listenGroups.Find((g) => { return g.Gid.ToString() == user.group_number; }) : null;
                    if (group != null)
                    {
                        dgvContact.Rows[i - 1].Cells["GroupStatus"].Value = (group.isListen ? "已监控" : "");
                        dgvContact.Rows[i - 1].Cells["GroupAlias"].Value = group.Alias;
                    }

                    dgvContact.Rows[i - 1].DefaultCellStyle.BackColor = QQGlobal.backColor;
                    dgvContact.Rows[i - 1].DefaultCellStyle.SelectionBackColor = QQGlobal.backColor;
                }
                picLoading.Visible = false;
            }
        }



        /// <summary>
        /// 加载微信通讯录
        /// </summary>
        /// <param name="contact_all">The contact_all.</param>
        public void SetMessageView(QQGroupMessageModel message)
        {
            if (dgvMessageView.InvokeRequired)
            {
                this.dgvMessageView.Invoke(new Action<QQGroupMessageModel>(SetMessageView), new object[] { message });
            }
            else
            {
                int i = dgvMessageView.Rows.Count;
                dgvMessageView.Rows.Add();
                ++i;
                dgvMessageView.Rows[i - 1].Cells["MessageCode"].Value = message.Code;
                dgvMessageView.Rows[i - 1].Cells["GroupName"].Value = message.GroupName;
                dgvMessageView.Rows[i - 1].Cells["MessageContent"].Value = message.MessageContent;
                dgvMessageView.Rows[i - 1].Cells["FullMessageContent"].Value = message.FullMessageContent;
                dgvMessageView.Rows[i - 1].Cells["MessageUrl1"].Value = message.MessageUrl1;
                dgvMessageView.Rows[i - 1].Cells["MessageUrl2"].Value = message.MessageUrl2;
                dgvMessageView.Rows[i - 1].Cells["MessageStatus"].Value = message.MessageStatus == 0 ? "未处理" : "已完成";
                dgvMessageView.Rows[i - 1].Cells["Status"].Value = 0;

                if (i % 2 == 0)
                {
                    dgvMessageView.Rows[i - 1].DefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
                    dgvMessageView.Rows[i - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 248, 248);
                }
                else
                {
                    dgvMessageView.Rows[i - 1].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
                    dgvMessageView.Rows[i - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 255);
                }
                dgvMessageView.Rows[i - 1].DefaultCellStyle.ForeColor = Color.FromArgb(180, 180, 180);
                dgvMessageView.CurrentCell = dgvMessageView.Rows[dgvMessageView.Rows.Count - 1].Cells[dgvMessageView.CurrentCell.ColumnIndex];
            }
        }

        /// <summary>
        /// 根据消息Codo，修改状态信息
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="msgText"></param>
        public void SetMesageViewByMessageCode(long Code, string msgText)
        {
            if (dgvMessageView.InvokeRequired)
            {
                this.dgvMessageView.Invoke(new Action<long, string>(SetMesageViewByMessageCode), new object[] { Code, msgText });
            }
            else
            {
                foreach (DataGridViewRow row in dgvMessageView.Rows)
                {
                    if (row.Cells["MessageCode"].Value.ToString().Equals(Code.ToString()))
                    {
                        row.Cells["MessageStatus"].Value = msgText;
                        break;
                    }
                }
            }
        }



        /// <summary>
        /// 鼠标进入单元格时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvContact_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            currentRowIndex = e.RowIndex;
            dgvContact.Rows[e.RowIndex].DefaultCellStyle.BackColor = QQGlobal.backColorSelected;
            dgvContact.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = QQGlobal.backColorSelected;
        }

        /// <summary>
        /// 鼠标离开单元格时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvContact_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection cells = this.dgvContact.CurrentRow.Cells;
            if (cells[0].RowIndex != e.RowIndex)
            {
                dgvContact.Rows[e.RowIndex].DefaultCellStyle.BackColor = QQGlobal.backColor;
                dgvContact.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = QQGlobal.backColor;
            }
        }
        /// <summary>
        /// 点击单元格时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvContact_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection cells = this.dgvContact.CurrentRow.Cells;
            foreach (DataGridViewRow row in this.dgvContact.Rows)
            {
                if (row.Cells[0].RowIndex != e.RowIndex)
                {
                    row.DefaultCellStyle.BackColor = QQGlobal.backColor;
                    row.DefaultCellStyle.SelectionBackColor = QQGlobal.backColor;
                }
            }
        }



        /// <summary>
        /// 当前鼠标所在的行索引
        /// </summary>
        private int currentRowIndex { get; set; }
        private void cmsTools_Opening(object sender, CancelEventArgs e)
        {
            if (this.dgvContact.CurrentRow == null)
            {
                e.Cancel = true;
                return;
            }
            DataGridViewCellCollection cells = this.dgvContact.CurrentRow.Cells;
            if (cells == null) e.Cancel = true;
            if (cells[0].RowIndex != currentRowIndex)
                e.Cancel = true;
            else
            {
                long gid = Convert.ToInt64(cells["GroupGid"].Value);
                if (QQGlobal.listenGroups.Exists((g) => { return g.Gid == gid && g.isListen; }))
                    toolAddListen.Text = "移除监控";
                else
                    toolAddListen.Text = "添加监控";
            }
        }
        /// <summary>
        /// 添加监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolAddListen_Click(object sender, EventArgs e)
        {
            if (this.dgvContact.CurrentRow == null) return;

            DataGridViewCellCollection cells = this.dgvContact.CurrentRow.Cells;
            if (cells == null) return;
            long gid = Convert.ToInt64(cells["GroupGid"].Value);
            QQGroup group = null;
            if (LoginType == 2)
            {
                var g = KQ.GetGroupInfo(gid.ToString());
                group = new QQGroup();
                group.Gid = gid;
                group.Name = g.group_name;

            }
            else
                group = QQGlobal.store.GetGroupByGin(gid);

            if (QQGlobal.listenGroups.Exists((g) => { return g.Gid == gid; }))
            {
                QQGlobal.listenGroups.ForEach(item =>
                {
                    if (item.Gid == gid)
                        item.isListen = !item.isListen;
                });

                QQGroup gg = QQGlobal.listenGroups.Find(g => { return g.Gid == gid; });
                cells["GroupTitle"].Value = group.Name;

                if (gg != null)
                {
                    cells["GroupStatus"].Value = (gg.isListen ? "已监控" : "");
                    cells["GroupAlias"].Value = gg.Alias;
                }
            }
            else
            {
                group.isListen = true;
                QQGlobal.listenGroups.Add(group);
                cells["GroupTitle"].Value = group.Name;
                cells["GroupStatus"].Value = "已监控";
            }
        }

        /// <summary>
        /// 修改别名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolsUpdateAlias_Click(object sender, EventArgs e)
        {
            //if (this.dgvContact.CurrentRow == null) return;
            //DataGridViewCellCollection cells = this.dgvContact.CurrentRow.Cells;
            //if (cells == null) return;
            //long gid = (long)cells["GroupGid"].Value;
            //QQGroup group = QQGlobal.listenGroups.Find(g => { return g.Gid == gid; });
            //if (group != null)
            //    cells["GroupTitle"].Value = group.GetGroupName();

            //cells["GroupTitle"].ReadOnly = false;
            ////cells["GroupTitle"].
            //dgvContact.BeginEdit(true);
        }

        /// <summary>
        /// 登录状态0表示为登录 1扫描登录，2酷Q登录
        /// </summary>
        private int LoginType { get; set; } = 0;


        /// <summary>
        /// 注销/登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogoutQQ_Click(object sender, EventArgs e)
        {
            if (LoginType == 0)
            {

                if (loginTypeKQ.Checked)
                {
                    KQ.ClearQQGroupData();
                    StartKQ();
                }
                else
                {
                    btnLogoutQQ.Enabled = false;
                    if (qqForm != null)
                    {
                        CloseEx();
                        picLogo.Image = Properties.Resources.QQ40x40;
                    }
                    LoginQQ();
                }
            }
            else if (LoginType == 1)
            {
                CloseEx();
                ResetStatus();
            }
            else if (LoginType == 2)
            {
                StopKQ();
                ResetStatus();
            }

        }


        private void ResetStatus()
        {
            dgvContact.Rows.Clear();
            dgvMessageView.Rows.Clear();
            QQGlobal.listenGroups.Clear();
            LoginType = 0;
            picLogo.Image = Properties.Resources.QQ40x40;
            btnLogoutQQ.Enabled = true;
            btnLogoutQQ.Text = "登录";
        }

        private void dgvMessageView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection cells = this.dgvMessageView.CurrentRow.Cells;
            if (cells != null && cells["DeteleMessage"].ColumnIndex == e.ColumnIndex)
            {
                this.dgvMessageView.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void cmsToolsResult_Opening(object sender, CancelEventArgs e)
        {
            if (this.dgvMessageView.Rows == null || this.dgvMessageView.Rows.Count == 0 || this.dgvMessageView.CurrentRow == null)
            {
                e.Cancel = true;
                return;
            }
            DataGridViewCellCollection cells = this.dgvMessageView.CurrentRow.Cells;
            if (cells == null) e.Cancel = true;
            if (cells[0].RowIndex != currentRowIndex)
                e.Cancel = true;
            else
            {
                string MessageStatus = cells["MessageStatus"].Value.ToString();
                if (MessageStatus.Equals("未处理") || MessageStatus.Equals("失败"))
                {

                }
                else
                    e.Cancel = true;
            }
        }

        private void dgvMessageView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            currentRowIndex = e.RowIndex;
        }
        /// <summary>
        /// 重新跟发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolReSend_Click(object sender, EventArgs e)
        {
            if (this.dgvMessageView.Rows == null) return;
            DataGridViewCellCollection cells = this.dgvMessageView.Rows[currentRowIndex].Cells;
            if (cells != null)
            {
                string GroupName = cells["GroupName"].Value.ToString();
                string msgContent = cells["MessageContent"].Value.ToString();
                long msgCode = (long)cells["MessageCode"].Value;
                string FullMessageContent = cells["FullMessageContent"].Value.ToString();
                string url = cells["MessageUrl1"].Value.ToString();
                string url2 = cells["MessageUrl2"].Value.ToString();


                var urls = UrlUtils.GetUrls(FullMessageContent);
                if (BuildGoodsHandler != null)
                {
                    QQGroupMessageModel message = new QQGroupMessageModel()
                    {
                        MessageContent = msgContent,
                        Code = msgCode,
                        GroupName = GroupName,
                        MessageUrl1 = url,
                        MessageUrl2 = url2,
                        FullMessageContent = FullMessageContent
                    };
                    MessageHandler(urls, message);
                }
            }

        }
        /// <summary>
        /// 结束单元格编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvContact_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //dgvContact[e.ColumnIndex, e.RowIndex].ReadOnly = true;
                //dgvContact.EndEdit();
                DataGridViewCellCollection cells = dgvContact.Rows[e.RowIndex].Cells;
                if (cells == null) return;

                long gid = Convert.ToInt64(cells["GroupGid"].Value);
                object an = cells["GroupAlias"].Value;
                string aliasName = an == null ? "" : an.ToString();


                QQGroup group = null;
                if (LoginType == 2)
                {
                    var g = KQ.GetGroupInfo(gid.ToString());
                    group = new QQGroup();
                    group.Gid = gid;
                    group.Name = g.group_name;
                    group.Alias = aliasName;

                }
                else
                    group = QQGlobal.store.GetGroupByGin(gid);

                var it = QQGlobal.listenGroups.Find((g) => { return g.Gid == gid; });
                if (it != null)
                {
                    QQGlobal.listenGroups.ForEach(item =>
                    {
                        if (item.Gid == gid)
                            item.Alias = aliasName;
                    });

                    cells["GroupAlias"].Value = aliasName;

                    if (it != null)
                        cells["GroupStatus"].Value = (it.isListen ? "已监控" : "");
                }
                else
                {
                    group.Alias = aliasName;
                    QQGlobal.listenGroups.Add(group);
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void ckbEnableCustomTemplate_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Checked)
                ckbAutoSend.Checked = cb.Checked;
            ckbAutoSend.Enabled = !cb.Checked;
        }
        /// <summary>
        /// 清空数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolClearAll_Click(object sender, EventArgs e)
        {
            dgvMessageView.Rows.Clear();
        }

        /// <summary>
        /// 退出酷Q
        /// </summary>
        private void StopKQ()
        {
            var myProcesses = System.Diagnostics.Process.GetProcessesByName("CQA");
            if (myProcesses.Length > 0)
            {
                foreach (var item in myProcesses)
                {
                    string path = item.MainModule.FileName.Replace("\\CQA.exe", "");

                    var arr = path.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                    if (arr != null && arr[arr.Length - 1].Equals(IdentificationTag))
                    {
                        item.Kill();
                        break;
                    }
                }
            }

            KQ.ClearQQGroupData();

        }

        /// <summary>
        /// 启动酷Q
        /// </summary>
        private void StartKQ()
        {
            try
            {
                StopKQ();
                var path = Application.StartupPath + string.Format(@"\data\tempair\{0}\CQA.exe", IdentificationTag);
                currentProcess = Process.Start(path);

                Timer chekLoginStatus = new Timer();
                chekLoginStatus.Interval = 2000;
                chekLoginStatus.Tick += chekLoginStatus_Tick;
                chekLoginStatus.Start();
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// 检查登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chekLoginStatus_Tick(object sender, EventArgs e)
        {
            var cfg = KQ.GetGroupCofing();
            if (cfg.load_completed == 1)
            {
                lbQQAccount.Text = cfg.login_qq;
                lbQQNickName.Text = cfg.login_name;
                Image face = GetQQFace(cfg.login_qq);
                if (face != null)
                    picLogo.Image = face;
                LoginType = 2;
                SetBtnEnable(true);
                SetBtnText("注销");
                Timer t = sender as Timer;
                t.Stop();

                List<GroupInfo> data = KQ.GetGroupList();
                SetContactsView(data);
                Timer checkGroupMsg = new Timer();
                checkGroupMsg.Interval = 3000;
                checkGroupMsg.Tick += CheckGroupMsg_Tick;
                checkGroupMsg.Start();
            }
        }

        /// <summary>
        /// 监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckGroupMsg_Tick(object sender, EventArgs e)
        {
            Timer t = sender as Timer;
            t.Stop();
            if (LoginType == 2)
            {
                var items = QQGlobal.listenGroups.FindAll((item) => { return item.isListen; });
                List<long> ids = new List<long>();
                foreach (var item in items)
                {
                    ids.Add(item.Gid);
                }
                var msgs = KQ.GetGroupMsgList(ids);
                //删除指定目标以外的数据
                KQ.DeleteQQGroupMsg(ids);
                if (msgs != null)
                {
                    foreach (var msg in msgs)
                    {
                        msg.detail = msg.detail.Replace("&amp;", "&");
                        string msgContent = GetTextReplace(msg.detail);
                        var urls = UrlUtils.GetUrls(msg.detail);
                        QqForm_GroupMsgHandler(msg.id, Convert.ToInt64(msg.group_number), "", msgContent, msg.detail, urls);
                        //删除
                        KQ.DeleteQQGroupMsg(msg.id);
                        System.Threading.Thread.Sleep(500);
                    }
                }
                t.Start();
            }
        }

        public string GetTextReplace(string msg)
        {
            string msgText = StringHelper.FilterText(msg);
            List<string> urls = UrlUtils.GetUrls(msgText);
            if (urls != null)
            {
                foreach (var url in urls)
                {
                    msgText = msgText.Replace(url, "");
                }
            }

            StringBuilder sb = new StringBuilder();
            using (StringReader sr = new StringReader(msgText))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        sb.AppendLine(line);
                    }
                }
            }
            sb.AppendLine("");
            return sb.ToString();
        }


        /// <summary>
        /// 获取QQ头像图像信息
        /// </summary>
        /// <param name="qqNumber">QQ号码</param>
        /// <returns>Image对象</returns>
        public Image GetQQFace(string qqNumber)
        {
            string url = string.Format("http://q.qlogo.cn/headimg_dl?dst_uin={0}&spec=640&img_type=jpg", qqNumber);
            Image img = null;
            try
            {
                //声明WebClient对象
                WebClient client = new WebClient();
                //添加头信息
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                //获数数据流
                Stream streamData = client.OpenRead(url);
                //从流中创建Image
                img = Image.FromStream(streamData);
                //关闭数据流
                streamData.Close();
                //释放内存
                client = null;
            }
            catch
            {

            }

            //反回数据类型
            return img;
        }


        /// <summary>
        /// 注册dll
        /// </summary>
        private void Regsvr32Dll()
        {
            try
            {
                //dll路径
                var path = Application.StartupPath + @"\KQAir\dll";

                if (!Directory.Exists(path)) return;
                //注册文件
                var fileName = path + @"\register.bat";
                if (!File.Exists(fileName)) return;

                Process.Start(fileName);

                new System.Threading.Thread(() =>
                {
                    System.Threading.Thread.Sleep(5000);
                    Directory.Delete(path, true);
                })
                { IsBackground = true }.Start();
            }
            catch (Exception)
            {

            }

        }

        private void lbRegsvr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                //dll路径
                var path = Application.StartupPath + @"\KQAir\dll";
                if (!Directory.Exists(path)) return;
                //help文件
                var fileName = path + @"\help.txt";
                if (!File.Exists(fileName)) return;

                Process.Start(fileName);
                Process.Start(path);
            }
            catch (Exception)
            {

            }
        }

        private void loginTypeKQ_CheckedChanged(object sender, EventArgs e)
        {
            lbRegsvr.Visible = loginTypeKQ.Checked;
        }


        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <returns>BuildDataBase.</returns>
        public void IintKQAir()
        {
            try
            {
                //dll路径
                var path = Application.StartupPath + @"\KQAir";
                string kqpath = System.Environment.CurrentDirectory + "\\data\\tempair\\" + IdentificationTag;
                //复制
                CopyDir(path, kqpath);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="fromDir"></param>
        /// <param name="toDir"></param>
        private void CopyDir(string fromDir, string toDir)
        {
            if (!Directory.Exists(fromDir))
                return;

            if (!Directory.Exists(toDir))
            {
                Directory.CreateDirectory(toDir);
            }

            string[] files = Directory.GetFiles(fromDir);
            foreach (string formFileName in files)
            {
                string fileName = Path.GetFileName(formFileName);
                string toFileName = Path.Combine(toDir, fileName);
                File.Copy(formFileName, toFileName, false);
            }
            string[] fromDirs = Directory.GetDirectories(fromDir);
            foreach (string fromDirName in fromDirs)
            {
                string dirName = Path.GetFileName(fromDirName);
                if (!dirName.Equals("dll"))
                {
                    string toDirName = Path.Combine(toDir, dirName);
                    CopyDir(fromDirName, toDirName);
                }
            }
        }

        private void ckbEnableJoinImage_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            ckbAutoSend.Enabled = !cb.Checked;
            ckbEnableCustomTemplate.Enabled = !cb.Checked;
            ckbEnableCustomTemplate.Checked = false;
            ckbAutoSend.Checked = false;
        }

        private void ckbEnableSendTime_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;

            txtStartTime.Enabled = cb.Checked;
            txtEndTime.Enabled = cb.Checked;
        }
    }
}
