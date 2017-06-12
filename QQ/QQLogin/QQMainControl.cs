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

namespace QQLogin
{
    public partial class QQMainControl : UserControl
    {

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


        public QQLogin qqForm;

        private void QQMainControl_Load(object sender, EventArgs e)
        {
            if (qqForm == null)
            {
                LoginQQ();
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
        private void QqForm_GroupMsgHandler(long msgCode, string msgGroupName, string msgContent, List<string> urls)
        {
            //TODO:接收群消息
            QQGroupMessageModel message = new QQGroupMessageModel()
            {
                GroupName = msgGroupName,
                MessageContent = msgContent.Replace('"', ' ').Replace(" ", " "),
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

            MessageHandler(urls, msgCode, msgContent);
        }

        /// <summary>
        /// 消息处理
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="msgCode"></param>
        /// <param name="msgContent"></param>
        private void MessageHandler(List<string> urls, long msgCode, string msgContent)
        {
            //TODO:
            if (urls != null && urls.Count() > 0)
            {
                bool isAutoSend = ckbAutoSend.Checked;
                new System.Threading.Thread(() =>
                {
                    try
                    {
                        long code = msgCode;
                        //消息处理回调
                        BuildGoodsHandler?.Invoke(code, msgContent.Replace('"', ' '), urls, isAutoSend, (ret, i, t) =>
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
                                default:
                                    break;
                            }
                            if (!string.IsNullOrEmpty(text))
                                SetMesageViewByMessageCode(msgCode, text);
                        });

                    }
                    catch (Exception)
                    {
                        SetMesageViewByMessageCode(msgCode, "已完成");
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
            //TODO:关闭窗口
            CloseQQHandler?.Invoke();
        }


        /// <summary>
        /// 关闭窗体
        /// </summary>
        public void CloseEx()
        {
            qqForm.Close();
            qqForm = null;
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
        /// 加载微信通讯录
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
                    if (QQGlobal.listenGroups.Exists((g) => { return g.Gid == user.Gid; }))
                        dgvContact.Rows[i - 1].Cells["GroupTitle"].Value = user.Name + "(已监控)";
                    else
                        dgvContact.Rows[i - 1].Cells["GroupTitle"].Value = user.Name;

                    dgvContact.Rows[i - 1].DefaultCellStyle.BackColor = QQGlobal.backColor;
                    dgvContact.Rows[i - 1].DefaultCellStyle.SelectionBackColor = QQGlobal.backColor;
                }
                picLoading.Visible = false;
                btnLogoutQQ.Visible = true;
                new System.Threading.Thread(() =>
                {
                    while (string.IsNullOrEmpty(QQGlobal.account.Nickname)) { }
                    SetLabelTitle(lbQQNickName, QQGlobal.account.Nickname);
                })
                { IsBackground = true }.Start();
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
            DataGridViewCellCollection cells = this.dgvContact.CurrentRow.Cells;
            if (cells == null) e.Cancel = true;
            if (cells[0].RowIndex != currentRowIndex)
                e.Cancel = true;
            else
            {
                long gid = (long)cells["GroupGid"].Value;
                if (QQGlobal.listenGroups.Exists((g) => { return g.Gid == gid; }))
                    toolAddListen.Text = "移除监控";
                else
                    toolAddListen.Text = "添加监控";
            }
        }

        private void toolAddListen_Click(object sender, EventArgs e)
        {
            DataGridViewCellCollection cells = this.dgvContact.CurrentRow.Cells;
            if (cells == null) return;
            long gid = (long)cells["GroupGid"].Value;
            QQGroup group = QQGlobal.store.GetGroupByGin(gid);
            if (QQGlobal.listenGroups.Exists((g) => { return g.Gid == gid; }))
            {
                QQGlobal.listenGroups.Remove(group);
                cells["GroupTitle"].Value = group.Name;
            }
            else
            {
                QQGlobal.listenGroups.Add(group);
                cells["GroupTitle"].Value += "(已监控)";
            }
        }
        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogoutQQ_Click(object sender, EventArgs e)
        {
            CloseEx();
            btnLogoutQQ.Visible = false;
            picLogo.Image = Properties.Resources.QQ40x40;
            LoginQQ();
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
            DataGridViewCellCollection cells = this.dgvMessageView.CurrentRow.Cells;
            if (cells == null) e.Cancel = true;
            if (cells[0].RowIndex != currentRowIndex)
                e.Cancel = true;
            else
            {
                string MessageStatus = cells["MessageStatus"].Value.ToString();
                if (!MessageStatus.Equals("未处理"))
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
            DataGridViewCellCollection cells = this.dgvMessageView.Rows[currentRowIndex].Cells;
            if (cells != null)
            {
                string msgContent = cells["MessageContent"].Value.ToString();
                long msgCode = (long)cells["MessageCode"].Value;
                var urls = UrlUtils.GetUrls(msgContent);
                MessageHandler(urls, msgCode, msgContent);
            }

        }
    }
}
