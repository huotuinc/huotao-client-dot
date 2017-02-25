using HotTao.Controls;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WwChatHttpCore.HTTP;
using WwChatHttpCore.Objects;

namespace HotTao
{
    public partial class wxLogin : Form
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

        private Main hotForm { get; set; }

        private HistoryControl historyForm { get; set; }

        public wxLogin(Main mainWin, HistoryControl history)
        {
            InitializeComponent();
            hotForm = mainWin;
            historyForm = history;
        }
        private void wxLogin_Load(object sender, EventArgs e)
        {
            DoLogin();
        }
        private void linkReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkReturn.Visible = false;
            DoLogin();
        }
        private void picClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void DoLogin()
        {
            picQRCode.Image = null;
            picQRCode.SizeMode = PictureBoxSizeMode.Zoom;
            lblTip.Text = "手机微信扫一扫以登录";
            lblTip.Width = 200;
            ((Action)(delegate ()
            {
                //异步加载二维码
                LoginService ls = new LoginService();
                Image qrcode = ls.GetQRCode();
                if (qrcode != null)
                {
                    this.BeginInvoke((Action)delegate ()
                    {
                        picQRCode.Image = qrcode;
                    });

                    object login_result = null;
                    Image headImg = null;
                    while (true)  //循环判断手机扫面二维码结果
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

                            //打开主界面
                            this.BeginInvoke((Action)delegate ()
                            {
                                this.Hide();
                                historyForm.ShowStartButtonText("暂停任务");
                            });
                            break;
                        }
                    }                    
                    DoMainLogic();
                }
            })).BeginInvoke(null, null);
        }

        /// <summary>
        /// 退出微信
        /// </summary>
        public void CloseWx()
        {
            Close();
        }

        private void wxLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            historyForm.ShowStartButtonText("启动计划");
        }


        /// <summary>
        /// 当前登录微信用户
        /// </summary>
        private WXUser _me;

        private List<object> _contact_all = new List<object>();
        List<object> contact_all = new List<object>();
        public void DoMainLogic()
        {
            WXService wxs = new WXService();
            JObject init_result = wxs.WxInit();  //初始化
            contact_all = new List<object>();

            if (init_result != null)
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
            }

            JObject contact_result = wxs.GetContact(); //通讯录
            if (contact_result != null)
            {
                foreach (JObject contact in contact_result["MemberList"])  //完整好友名单
                {
                    //if (contact["UserName"].ToString().Contains("@") && !contact["UserName"].ToString().Contains("@@") && contact["VerifyFlag"].ToString() == "0")
                    //{
                    //    WXUser user = new WXUser();
                    //    user.UserName = contact["UserName"].ToString();
                    //    user.City = contact["City"].ToString();
                    //    user.HeadImgUrl = contact["HeadImgUrl"].ToString();
                    //    user.NickName = contact["NickName"].ToString();
                    //    user.Province = contact["Province"].ToString();
                    //    user.PYQuanPin = contact["PYQuanPin"].ToString();
                    //    user.RemarkName = contact["RemarkName"].ToString();
                    //    user.RemarkPYQuanPin = contact["RemarkPYQuanPin"].ToString();
                    //    user.Sex = contact["Sex"].ToString();
                    //    user.Signature = contact["Signature"].ToString();
                    //    user.IsOwner = Convert.ToInt32(contact["IsOwner"].ToString());
                    //    contact_all.Add(user);
                    //}
                    //只监控群
                    if (contact["UserName"].ToString().Contains("@@"))
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
            }

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
                    //if (sync_result != null)
                    //{
                    //    if (sync_result["AddMsgCount"] != null && sync_result["AddMsgCount"].ToString() != "0")
                    //    {
                    //        foreach (JObject m in sync_result["AddMsgList"])
                    //        {
                    //            string from = m["FromUserName"].ToString();
                    //            string to = m["ToUserName"].ToString();
                    //            string content = m["Content"].ToString();
                    //            string type = m["MsgType"].ToString();
                    //            if (type == "10000")
                    //            {
                    //                if (content.Contains("开启了朋友验证") || content.Contains("消息已发出，但被对方拒收"))
                    //                {
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                }
                System.Threading.Thread.Sleep(10);
            }
        }
    }
}
