using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WwChatHttpCore.Objects;
using System.IO;
using System.Drawing.Imaging;
using HotTaoCore;
using HotTaoMonitoring.Properties;
using HOTReuestService.Helper;
using System.Diagnostics;
using HotTaoCore.Models;
using HOTReuestService;

namespace HotTaoMonitoring.UserControls
{
    public partial class ListenForm : UserControl
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
            if (mainForm.myInfo != null)
            {
                mainForm.myInfo.Close();
                mainForm.myInfo = null;
            }
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLocation = mainForm.Location;
                mouseOffset = Control.MousePosition;
            }
        }

        private void WinForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (mainForm.myInfo != null)
            {
                mainForm.myInfo.Close();
                mainForm.myInfo = null;
            }
            isMouseDown = false;
        }
        private void WinForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mainForm.myInfo != null)
            {
                mainForm.myInfo.Close();
                mainForm.myInfo = null;
            }
            int _x = 0;
            int _y = 0;
            if (isMouseDown)
            {
                Point pt = Control.MousePosition;
                _x = mouseOffset.X - pt.X;
                _y = mouseOffset.Y - pt.Y;

                mainForm.Location = new Point(FormLocation.X - _x, FormLocation.Y - _y);
            }
        }
        #endregion








        private MainForm mainForm { get; set; }

        /// <summary>
        /// 微信监控的消息数据
        /// </summary>
        public List<WxMessageBodyModel> wxMessageData { get; set; } = new List<WxMessageBodyModel>();
        /// <summary>
        /// 是否显示全部
        /// </summary>
        public bool isShowAll { get; set; }

        /// <summary>
        /// 当前选中的微信群
        /// </summary>
        public string CurrentSelectedWeChat { get; set; }


        public ListenForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
            wxMessageData = new List<WxMessageBodyModel>();
        }

        private void ListenForm_Load(object sender, EventArgs e)
        {
            picWeChatHead.Image = mainForm.myUserImage;
            SetContactsView(mainForm.contact_all);

        }



        /// <summary>
        /// 设置微信监控消息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="msgSendUser"></param>
        /// <param name="nickName"></param>
        /// <param name="content"></param>
        public void SetWxMessageData(WXUser user, string msgSendUser, string nickName, string content, byte[] msgImageData)
        {
            WxMessageBodyModel msg = new WxMessageBodyModel();
            if (!wxMessageData.Exists(item => { return item.MsgSendUser == msgSendUser && item.MsgUserName == user.UserName; }))
            {
                msg = new WxMessageBodyModel()
                {
                    MsgSendUser = msgSendUser,
                    MsgShowName = user.ShowName,
                    MsgText = content,
                    MsgTime = DateTime.Now,
                    NotReadCount = 1,
                    MsgUserName = user.UserName,
                    MsgNickName = nickName,
                    MsgStatus = "未回复",
                    MsgImageData = msgImageData
                };
                wxMessageData.Add(msg);
            }
            else
            {

                wxMessageData.ForEach(data =>
                {
                    if (data.MsgSendUser == msgSendUser && data.MsgUserName == user.UserName)
                    {
                        data.MsgTime = DateTime.Now;
                        data.MsgText = content;
                        data.NotReadCount += 1;
                        data.MsgStatus = "未回复";
                        data.MsgImageData = msgImageData;
                    }
                });

                msg = wxMessageData.Find(m =>
                {
                    return m.MsgSendUser == msgSendUser && m.MsgUserName == user.UserName;
                });
            }
            if (msg != null)
                SetDataContentView(msg);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private void SetDataContentView(WxMessageBodyModel data)
        {
            if (dataContent.InvokeRequired)
            {
                this.dataContent.Invoke(new Action<WxMessageBodyModel>(SetDataContentView), new object[] { data });
            }
            else
            {
                if (mainForm.useredit == null || mainForm.useredit.isHide || (mainForm.useredit.toUserName != data.MsgUserName && mainForm.useredit.toNickName != data.MsgNickName))
                {
                    foreach (DataGridViewRow row in dgvWeChatList.Rows)
                    {
                        if (row.Cells["UserName"].Value.ToString().Equals(data.MsgUserName))
                        {
                            string _MessageReadStatus = row.Cells["MessageReadStatus"].Value.ToString();
                            if (!string.IsNullOrEmpty(_MessageReadStatus))
                            {
                                row.Cells["MessageReadStatus"].Value = Convert.ToInt32(_MessageReadStatus) + 1;
                                break;
                            }
                            else
                            {
                                row.Cells["MessageReadStatus"].Value = 1;
                                break;
                            }
                        }
                    }
                }

                UserEditControl ed = new UserEditControl(mainForm, this);
                string base64 = mainForm.wxlogin.GetIcon(data.MsgSendUser);
                if (!string.IsNullOrEmpty(base64))
                    base64 = "data:image/jpg;base64," + base64;
                string html = string.Empty;
                if (data.MsgImageData == null)
                    html = ed.GetReceiveMsgHtml(data.MsgShowName, data.MsgNickName, data.MsgText, data.MsgTime.ToString("yyyy-MM-dd HH:mm"), base64);
                else
                    html = ed.GetReceiveMsgHtml(data.MsgShowName, data.MsgNickName, data.MsgText, data.MsgTime.ToString("yyyy-MM-dd HH:mm"), base64, "data:image/jpg;base64," + Convert.ToBase64String(data.MsgImageData));

                ed.writeCacheData(data.MsgShowName, data.MsgNickName, html);

                if (string.IsNullOrEmpty(CurrentSelectedWeChat) || data.MsgUserName.Equals(CurrentSelectedWeChat))
                {
                    bool result = false;
                    //合并相同用户消息
                    foreach (DataGridViewRow item in dataContent.Rows)
                    {
                        if (item.Cells["MsgSendUser"].Value.ToString().Equals(data.MsgSendUser) && item.Cells["MsgUserName"].Value.ToString().Equals(data.MsgUserName))
                        {
                            result = true;
                            item.Cells["MsgContent"].Value = data.MsgText.Replace("<br/>", "\r\n");
                            item.Cells["MsgText"].Value = data.MsgText;
                            item.Cells["MsgTime"].Value = data.MsgTime.ToString("dd日 HH:mm");
                            if (mainForm.useredit != null && mainForm.useredit.toUserName == data.MsgUserName && mainForm.useredit.toNickName == data.MsgNickName && !mainForm.useredit.isHide)
                            {
                                item.Cells["NotReadCount"].Value = "0";
                                wxMessageData.ForEach(d =>
                                {
                                    if (d.MsgSendUser == data.MsgSendUser && d.MsgUserName == data.MsgUserName)
                                    {
                                        data.NotReadCount = 0;
                                    }
                                });
                            }
                            else
                            {
                                item.Cells["NotReadCount"].Value = data.NotReadCount;
                                if (data.NotReadCount > 0)
                                {
                                    item.Cells["NotReadCount"].Style.ForeColor = Color.Red;
                                }
                            }
                            item.Cells["MsgStatus"].Value = data.MsgStatus;
                            break;
                        }
                    }
                    if (!result)
                    {

                        int i = dataContent.Rows.Count;
                        dataContent.Rows.Add();
                        ++i;
                        dataContent.Rows[i - 1].Cells["MsgContent"].Value = data.MsgText.Replace("<br/>", "\r\n");
                        dataContent.Rows[i - 1].Cells["MsgUserName"].Value = data.MsgUserName;
                        dataContent.Rows[i - 1].Cells["MsgNickName"].Value = data.MsgNickName;
                        dataContent.Rows[i - 1].Cells["MsgText"].Value = data.MsgText;
                        dataContent.Rows[i - 1].Cells["MsgSendUser"].Value = data.MsgSendUser;
                        dataContent.Rows[i - 1].Cells["MsgShowName"].Value = data.MsgShowName;
                        dataContent.Rows[i - 1].Cells["NotReadCount"].Value = data.NotReadCount;
                        dataContent.Rows[i - 1].Cells["MsgStatus"].Value = data.MsgStatus;
                        dataContent.Rows[i - 1].Cells["MsgTime"].Value = data.MsgTime.ToString("dd日 HH:mm");
                        if (data.NotReadCount > 0)
                            dataContent.Rows[i - 1].Cells["NotReadCount"].Style.ForeColor = Color.Red;
                        else
                            dataContent.Rows[i - 1].Cells["NotReadCount"].Style.ForeColor = ConstConfig.DataGridViewRowForeColor;

                        if (i % 2 == 0)
                        {
                            dataContent.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                            dataContent.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewEvenRowBackColor;
                        }
                        else
                        {
                            dataContent.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;
                            dataContent.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewOddRowBackColor;
                        }
                        dataContent.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                        dataContent.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;
                    }
                }
                if (mainForm.useredit != null && mainForm.useredit.toUserName == data.MsgUserName && mainForm.useredit.toNickName == data.MsgNickName)
                {
                    if (data.MsgImageData == null)
                        mainForm.useredit.ShowReceiveMsg(data.MsgNickName, data.MsgText, data.MsgTime.ToString("yyyy-MM-dd HH:mm"), base64);
                    else
                        mainForm.useredit.ShowReceiveMsg(data.MsgNickName, data.MsgText, data.MsgTime.ToString("yyyy-MM-dd HH:mm"), base64, "data:image/jpg;base64," + Convert.ToBase64String(data.MsgImageData));
                }

            }
        }


        private void SetDataContentView(List<WxMessageBodyModel> datas)
        {
            if (dataContent.InvokeRequired)
            {
                this.dataContent.Invoke(new Action<List<WXUser>>(SetContactsView), new object[] { datas });
            }
            else
            {
                this.dataContent.Rows.Clear();
                int i = dataContent.Rows.Count;

                foreach (var data in datas)
                {
                    dataContent.Rows.Add();
                    ++i;
                    dataContent.Rows[i - 1].Cells["MsgContent"].Value = data.MsgText.Replace("<br/>", "\r\n");
                    dataContent.Rows[i - 1].Cells["MsgUserName"].Value = data.MsgUserName;
                    dataContent.Rows[i - 1].Cells["MsgNickName"].Value = data.MsgNickName;
                    dataContent.Rows[i - 1].Cells["MsgText"].Value = data.MsgText;
                    dataContent.Rows[i - 1].Cells["MsgSendUser"].Value = data.MsgSendUser;
                    dataContent.Rows[i - 1].Cells["MsgShowName"].Value = data.MsgShowName;
                    dataContent.Rows[i - 1].Cells["NotReadCount"].Value = data.NotReadCount;
                    dataContent.Rows[i - 1].Cells["MsgStatus"].Value = data.MsgStatus;
                    dataContent.Rows[i - 1].Cells["MsgTime"].Value = data.MsgTime.ToString("dd日 HH:mm");
                    if (data.NotReadCount > 0)
                        dataContent.Rows[i - 1].Cells["NotReadCount"].Style.ForeColor = Color.Red;
                    else
                        dataContent.Rows[i - 1].Cells["NotReadCount"].Style.ForeColor = ConstConfig.DataGridViewRowForeColor;
                    if (i % 2 == 0)
                    {
                        dataContent.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewEvenRowBackColor;
                        dataContent.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewEvenRowBackColor;
                    }
                    else
                    {
                        dataContent.Rows[i - 1].DefaultCellStyle.BackColor = ConstConfig.DataGridViewOddRowBackColor;
                        dataContent.Rows[i - 1].DefaultCellStyle.SelectionBackColor = ConstConfig.DataGridViewOddRowBackColor;
                    }
                    dataContent.Rows[i - 1].Height = ConstConfig.DataGridViewRowHeight;
                    dataContent.Rows[i - 1].DefaultCellStyle.ForeColor = ConstConfig.DataGridViewRowForeColor;
                }
            }
        }

        public void SetDataContentStatus(int rowIndex, string msgSendUser, string userName)
        {
            foreach (DataGridViewRow item in dataContent.Rows)
            {
                if (item.Cells["MsgUserName"].Value.ToString().Equals(userName) && item.Cells["MsgSendUser"].Value.ToString().Equals(msgSendUser))
                {
                    item.Cells["MsgStatus"].Value = "已回复";
                    break;
                }
            }

            wxMessageData.ForEach(data =>
            {
                if (data.MsgSendUser == msgSendUser && data.MsgUserName == userName)
                {
                    data.MsgStatus = "已回复";
                }
            });
        }


        /// <summary>
        /// 添加通讯录
        /// </summary>
        /// <param name="user">The user.</param>
        public void AddContactsView(WXUser user)
        {
            if (NotListenWeChatData == null) NotListenWeChatData = new List<WXUser>();
            if (ListenWeChatData == null) ListenWeChatData = new List<WXUser>();

            if (!NotListenWeChatData.Exists(item => { return item.UserName == user.UserName; }) && !ListenWeChatData.Exists(item => { return item.UserName == user.UserName; }))
            {
                NotListenWeChatData.Add(user);
                SetContactsView(user);
                //DownLoadWeChatImage(user);
            }
            ListenWeChatData.ForEach(item =>
            {
                if (item.UserName == user.UserName)
                {
                    item.NickName = user.ShowName;
                }
            });

        }

        private static object _loading = new object();

        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="user">The user.</param>
        private void DownLoadWeChatImage(WXUser user)
        {
            new System.Threading.Thread(() =>
            {
                lock (_loading)
                {
                    string fileName = Environment.CurrentDirectory + "\\data\\cacheData\\img";
                    if (!Directory.Exists(fileName))
                        Directory.CreateDirectory(fileName);
                    fileName += "\\" + EncryptHelper.MD5(user.UserName) + ".jpg";
                    //判断文件是否存在
                    if (!File.Exists(fileName))
                    {
                        Image data = mainForm.wxlogin.GetHeadImage(user.UserName);
                        if (data != null)
                        {
                            Bitmap img = new Bitmap(data, 40, 40);
                            img.Save(fileName, ImageFormat.Jpeg);
                            img.Dispose();
                            img = null;
                            SetContactsView(user);
                        }
                    }
                    else
                        SetContactsView(user);

                }
            })
            { IsBackground = true }.Start();

        }

        private string GetWeChatImageFilePath(string UserName)
        {
            return Environment.CurrentDirectory + "\\data\\cacheData\\img\\" + EncryptHelper.MD5(UserName) + ".jpg";
        }


        /// <summary>
        /// 加载微信通讯录
        /// </summary>
        /// <param name="user">The user.</param>
        private void SetContactsView(WXUser user)
        {
            if (NotListenWeChatData == null) NotListenWeChatData = new List<WXUser>();

            if (dgvWeChatList.InvokeRequired)
            {
                this.dgvWeChatList.Invoke(new Action<WXUser>(SetContactsView), new object[] { user });
            }
            else
            {
                bool result = false;
                foreach (DataGridViewRow item in dgvWeChatList.Rows)
                {
                    if (item.Cells["UserName"].Value.ToString().Equals(user.UserName))
                    {
                        result = true;
                        item.Cells["ShowName"].Value = user.ShowName;
                        item.Cells["UserName"].Value = user.UserName;
                        break;
                    }
                }
                if (!IsListenView && !result)
                {
                    int i = dgvWeChatList.Rows.Count;
                    dgvWeChatList.Rows.Add();
                    ++i;
                    dgvWeChatList.Rows[i - 1].Cells["ID"].Value = i;
                    dgvWeChatList.Rows[i - 1].Cells["ShowName"].Value = user.ShowName;
                    dgvWeChatList.Rows[i - 1].Cells["UserName"].Value = user.UserName;

                    dgvWeChatList.Rows[i - 1].Height = 50;
                    dgvWeChatList.Rows[i - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(236, 232, 231);
                }

                if (NotListenWeChatData.Exists(item => { return item.UserName == user.UserName; }))
                    NotListenWeChatData.RemoveAll(u => { return u.UserName == user.UserName; });
                NotListenWeChatData.Add(user);
            }
        }
        /// <summary>
        /// 加载微信通讯录
        /// </summary>
        /// <param name="contact_all">The contact_all.</param>
        public void SetContactsView(List<WXUser> contact_all)
        {
            if (dgvWeChatList.InvokeRequired)
            {
                this.Invoke(new Action<List<WXUser>>(SetContactsView), new object[] { contact_all });
            }
            else
            {
                this.dgvWeChatList.Rows.Clear();
                int i = dgvWeChatList.Rows.Count;
                foreach (var user in contact_all)
                {

                    dgvWeChatList.Rows.Add();
                    ++i;
                    dgvWeChatList.Rows[i - 1].Cells["ID"].Value = i;
                    dgvWeChatList.Rows[i - 1].Cells["ShowName"].Value = user.ShowName;
                    dgvWeChatList.Rows[i - 1].Cells["UserName"].Value = user.UserName;
                    dgvWeChatList.Rows[i - 1].Height = 50;
                    dgvWeChatList.Rows[i - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(236, 232, 231);// ConstConfig.DataGridViewOddRowBackColor;                    
                    dgvWeChatList.Rows[i - 1].Cells["editListen"].Value = IsListenView ? Resources.icon_delete : Resources.icon_add;


                    if (IsListenView)
                    {
                        int count = 0;
                        var data = wxMessageData.FindAll(r => r.MsgUserName == user.UserName && r.NotReadCount > 0 && r.MsgShowName == user.ShowName);
                        if (data != null)
                        {
                            foreach (WxMessageBodyModel item in data)
                            {
                                count += item.NotReadCount;
                            }
                        }
                        dgvWeChatList.Rows[i - 1].Cells["MessageReadStatus"].Value = count > 0 ? count.ToString() : "";

                    }
                }
            }
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolsRefresh_Click(object sender, EventArgs e)
        {
            if (!IsListenView)
            {
                if (mainForm.wxlogin != null)
                {
                    if (NotListenWeChatData == null) NotListenWeChatData = new List<WXUser>();
                    this.dgvWeChatList.Rows.Clear();
                    NotListenWeChatData.Clear();
                    mainForm.wxlogin.ReloadContact();
                }
            }
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var data = !IsListenView ? NotListenWeChatData.FindAll(item => { return item.ShowName.Contains(txtSearch.Text); }) : ListenWeChatData.FindAll(item => { return item.ShowName.Contains(txtSearch.Text); });
            SetContactsView(data);
        }



        /// <summary>
        /// 点击回复按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataContent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection cells = this.dataContent.CurrentRow.Cells;
            if (cells != null)
            {

                string _msgUserName = cells["MsgUserName"].Value.ToString();
                string _msgShowName = cells["MsgShowName"].Value.ToString();
                string _msgNickName = cells["MsgNickName"].Value.ToString();
                string _msgSendUser = cells["MsgSendUser"].Value.ToString();
                string _notReadCount = cells["NotReadCount"].Value.ToString();
                int rowIndex = cells[0].RowIndex;

                int c = 0;
                if (!string.IsNullOrEmpty(_notReadCount))
                    c = Convert.ToInt32(_notReadCount);
                foreach (DataGridViewRow row in dgvWeChatList.Rows)
                {
                    if (row.Cells["UserName"].Value.ToString().Equals(_msgUserName))
                    {
                        string _MessageReadStatus = row.Cells["MessageReadStatus"].Value.ToString();
                        if (!string.IsNullOrEmpty(_MessageReadStatus))
                        {
                            int _c = Convert.ToInt32(_MessageReadStatus) - c;
                            if (_c > 0)
                                row.Cells["MessageReadStatus"].Value = _c;
                            else
                                row.Cells["MessageReadStatus"].Value = "";
                            break;
                        }
                        else
                        {
                            row.Cells["MessageReadStatus"].Value = "";
                            break;
                        }
                    }
                }



                cells["NotReadCount"].Value = 0;
                cells["NotReadCount"].Style.ForeColor = ConstConfig.DataGridViewRowForeColor;
                wxMessageData.ForEach(item =>
                {
                    if (item.MsgUserName == _msgUserName && item.MsgNickName == _msgNickName)
                    {
                        item.NotReadCount = 0;
                    }
                });


                Size size = mainForm.Size;
                if (mainForm.useredit == null)
                {
                    mainForm.useredit = new UserEditControl(mainForm, this);
                    mainForm.useredit.Location = new Point(size.Width, 0);
                    size.Width += mainForm.useredit.Size.Width;
                    mainForm.Size = size;
                    mainForm.Controls.Add(mainForm.useredit);
                    mainForm.useredit.isHide = false;
                }
                else if (mainForm.useredit.toUserName != _msgUserName || mainForm.useredit.toNickName != _msgNickName)
                {

                }
                if (mainForm.useredit.isHide)
                {
                    mainForm.useredit.isHide = true;
                    size.Width += mainForm.useredit.Size.Width; //402
                    mainForm.Size = size;
                }
                mainForm.useredit.toUserName = _msgUserName;
                mainForm.useredit.toShowName = _msgShowName;
                mainForm.useredit.toNickName = _msgNickName;
                mainForm.useredit.MsgSendUser = _msgSendUser;
                mainForm.useredit.isHide = false;
                mainForm.useredit.rowIndex = rowIndex;
                mainForm.useredit.LoadHtml();
                mainForm.useredit.SetTitle(mainForm.useredit.toNickName);
            }
        }

        /// <summary>
        /// 添加/移除监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWeChatList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ListenWeChatData == null)
                ListenWeChatData = new List<WXUser>();
            CurrentSelectedWeChat = string.Empty;
            DataGridViewCellCollection cells = this.dgvWeChatList.CurrentRow.Cells;
            if (cells != null && cells["editListen"].ColumnIndex == e.ColumnIndex)
            {
                string userName = cells["UserName"].Value.ToString();
                if (!IsListenView)
                {
                    if (!ListenWeChatData.Exists(item => { return item.UserName == userName; }))
                    {
                        //将群添加到监控列表
                        ListenWeChatData.Add(new WXUser()
                        {
                            UserName = userName,
                            NickName = cells["ShowName"].Value.ToString()
                        });

                        NotListenWeChatData.RemoveAll(item => { return item.UserName == userName; });
                    }
                }
                else
                {
                    //从监控列表中移除
                    if (ListenWeChatData.Exists(item => { return item.UserName == userName; }))
                    {
                        ListenWeChatData.RemoveAll(item => { return item.UserName == userName; });
                        //将群添加到监控列表
                        NotListenWeChatData.Add(new WXUser()
                        {
                            UserName = userName,
                            NickName = cells["ShowName"].Value.ToString()
                        });
                    }
                }
                dgvWeChatList.Rows.RemoveAt(cells["editListen"].RowIndex);
            }
            else
            {
                if (IsListenView)
                {
                    string showname = cells["ShowName"].Value.ToString();
                    CurrentSelectedWeChat = cells["UserName"].Value.ToString();
                    var data = wxMessageData.FindAll(item =>
                    {
                        return item.MsgUserName == CurrentSelectedWeChat;
                    });
                    SetDataContentView(data);
                    lbMsgTitle.Text = "群 " + showname + " 消息列表";
                }
            }
        }

        /// <summary>
        /// 已监控的微信群
        /// </summary>
        public List<WXUser> ListenWeChatData { get; set; } = new List<WXUser>();

        /// <summary>
        /// 未监控的微信群
        /// </summary>
        public List<WXUser> NotListenWeChatData { get; set; } = new List<WXUser>();

        /// <summary>
        /// 是否在监控页面
        /// </summary>
        public bool IsListenView { get; set; }

        /// <summary>
        /// 微信群列表tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbTabWeChat_Click(object sender, EventArgs e)
        {
            if (IsListenView)
            {
                dgvWeChatList.Rows.Clear();
                CurrentSelectedWeChat = string.Empty;
                dgvWeChatList.ContextMenuStrip = menuStrip;
                lbTabWeChat.BackColor = Color.FromArgb(113, 113, 176);
                lbTabWeChatListen.BackColor = Color.FromArgb(50, 50, 50);
                if (NotListenWeChatData == null) NotListenWeChatData = new List<WXUser>();
                IsListenView = false;
                SetContactsView(NotListenWeChatData);
            }
        }

        /// <summary>
        /// 已监控列表tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbTabWeChatListen_Click(object sender, EventArgs e)
        {
            if (!IsListenView)
            {
                dgvWeChatList.Rows.Clear();
                dgvWeChatList.ContextMenuStrip = menuStrip1;
                lbTabWeChat.BackColor = Color.FromArgb(50, 50, 50);
                lbTabWeChatListen.BackColor = Color.FromArgb(113, 113, 176);
                if (ListenWeChatData == null) ListenWeChatData = new List<WXUser>();
                IsListenView = true;
                SetContactsView(ListenWeChatData);

            }
            CurrentSelectedWeChat = string.Empty;
            lbMsgTitle.Text = "全部 消息列表";
            SetDataContentView(wxMessageData);

        }


        /// <summary>
        /// 关闭个人信息窗口
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void CloseMyInfoForm(object sender, MouseEventArgs e)
        {
            mainForm.CloseMyInfoForm(sender, e);
        }

        /// <summary>
        /// 一键添加监控
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolsAllListen_Click(object sender, EventArgs e)
        {
            NotListenWeChatData.ForEach(data =>
            {

                if (!ListenWeChatData.Exists(item => { return item.UserName == data.UserName; }))
                {
                    //将群添加到监控列表
                    ListenWeChatData.Add(new WXUser()
                    {
                        UserName = data.UserName,
                        NickName = data.NickName
                    });
                }
            });
            NotListenWeChatData.Clear();
            dgvWeChatList.Rows.Clear();
            lbTabWeChatListen_Click(null, null);
        }

        /// <summary>
        /// 一键移除监控
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolsClearListen_Click(object sender, EventArgs e)
        {
            ListenWeChatData.ForEach(data =>
            {
                if (!NotListenWeChatData.Exists(item => { return item.UserName == data.UserName; }))
                {
                    //将群添加到监控列表
                    NotListenWeChatData.Add(new WXUser()
                    {
                        UserName = data.UserName,
                        NickName = data.NickName
                    });
                }
            });
            ListenWeChatData.Clear();
            dgvWeChatList.Rows.Clear();
        }

        /// <summary>
        /// 清除页面所有数据
        /// </summary>
        public void ClearAllData()
        {
            if (wxMessageData != null)
                wxMessageData.Clear();
            if (ListenWeChatData != null)
                ListenWeChatData.Clear();
            if (NotListenWeChatData != null)
                NotListenWeChatData.Clear();

            dataContent.Rows.Clear();
            dgvWeChatList.Rows.Clear();
            CurrentSelectedWeChat = string.Empty;
            if (mainForm.useredit != null)
            {
                HileWinEdit();
            }
        }

        /// <summary>
        /// 隐藏聊天窗口
        /// </summary>
        public void HileWinEdit()
        {
            if (mainForm.useredit != null && !mainForm.useredit.isHide)
            {
                Size size = mainForm.Size;
                size.Width -= mainForm.useredit.Size.Width;
                mainForm.Size = size;
                mainForm.useredit.isHide = true;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                var data = !IsListenView ? NotListenWeChatData.FindAll(item => { return item.ShowName.Contains(txtSearch.Text); }) : ListenWeChatData.FindAll(item => { return item.ShowName.Contains(txtSearch.Text); });
                SetContactsView(data);
            }
        }

        /// <summary>
        /// 我的信息窗口
        /// </summary>
        /// <value>My information.</value>
       // public MyInfoForm myInfo { get; set; }
        private void picWeChatHead_Click(object sender, EventArgs e)
        {
            if (mainForm.myInfo == null)
            {
                RECT rect = new RECT();
                WinApi.GetWindowRect(picWeChatHead.Handle, ref rect);
                mainForm.myInfo = new MyInfoForm(mainForm);
                mainForm.myInfo.Location = new Point(rect.Right - (rect.Right - rect.Left) / 2, rect.Bottom - (rect.Bottom - rect.Top) / 2);
                mainForm.myInfo.SetData(mainForm.myUserNickName, mainForm.myUserImage);
                mainForm.myInfo.Show(this);
            }
            else
            {
                mainForm.myInfo.Close();
                mainForm.myInfo = null;
            }
        }

        private void lbCheckUpdate_Click(object sender, EventArgs e)
        {
            CheckVersion();
        }










        /// <summary>
        /// Checks the version.
        /// </summary>
        private void CheckVersion()
        {
            new System.Threading.Thread(() =>
            {
                int v = this.GetCurrentClientVersion();
                if (v > 0)
                {
                    var version = HotTaoApiService.Instance.CheckVersion(v, ApiDefineConst.CheckUpdateKfUrl);
                    if (version != null)
                        ShowConfirm(version);
                    else
                        ShowAlert();
                }
                else
                    ShowAlert();

            })
            { IsBackground = true }.Start();
        }

        private void ShowConfirm(VersionModel version)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<VersionModel>(ShowConfirm), new object[] { version });
            }
            else
            {
                bool isUpdate = false;
                MessageConfirm cfr = new MessageConfirm("发现新版本，是否马上下载更新?");
                cfr.CallBack += () =>
                {
                    isUpdate = true;
                };
                cfr.StartPosition = FormStartPosition.CenterScreen;
                cfr.ShowDialog();
                if (isUpdate)
                {
                    Process.Start("CheckUpdate.exe");
                    CloseMain();
                }
            }
        }


        private void ShowAlert()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ShowAlert), new object[] { });
            }
            else
            {
                MessageAlert alert = new MessageAlert("当前已是最新版本，无需更新!");
                alert.StartPosition = FormStartPosition.CenterScreen;
                alert.Show();
            }
        }

        public void CloseMain()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(CloseMain), new object[] { });
            }
            else
            {
                mainForm.ApplicationClose();
            }
        }

        /// <summary>
        /// 获取当前版本
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetCurrentClientVersion()
        {
            int v = 0;
            try
            {
                string filePath = System.IO.Path.Combine(Application.StartupPath, GlobalConfig.datapath + ConstConfig.v_version);
                if (File.Exists(filePath))
                {
                    FileStream aFile = new FileStream(filePath, FileMode.Open);
                    StreamReader sr = new StreamReader(aFile);
                    string str = sr.ReadToEnd();
                    sr.Close();
                    sr.Dispose();
                    aFile.Close();
                    aFile.Dispose();
                    int.TryParse(str, out v);
                }
            }
            catch (Exception)
            {

            }
            return v;
        }

















    }
}
