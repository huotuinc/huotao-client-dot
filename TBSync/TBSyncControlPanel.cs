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

namespace TBSync
{
    public partial class TBSyncControlPanel : Form
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


        static string LoginToken;
        static int currentUserId;

        /// <summary>
        /// 登录对象
        /// </summary>
        private LoginWindow lw;
        /// <summary>
        /// 是否已开始同步
        /// </summary>
        private bool isStartAsync = false;
        /// <summary>
        /// 是否登录成功
        /// </summary>
        private bool isLoginSuccess = false;


        private bool IsRefreshLogin { get; set; }

        /// <summary>
        /// 是否已完成
        /// </summary>
        /// <value>true if this instance is completed; otherwise, false.</value>
        private bool isCompleted { get; set; }


        private string loginname = string.Empty;
        private string loginpwd = string.Empty;


        private string cookieJson { get; set; }

        /// <summary>
        /// 同步的商品数量
        /// </summary>
        private int SyncGoodsCount { get; set; }
        /// <summary>
        /// 上次未同步完的商品数量
        /// </summary>
        /// <value>The last not synchronize goods count.</value>
        private int lastNotSyncGoodsCount { get; set; }

        /// <summary>
        /// 服务器最新的商品数据
        /// </summary>
        /// <value>The synchronize goods.</value>
        private SyncGoodsModel syncGoods { get; set; }

        /// <summary>
        /// 本地未完成同步的商品数据
        /// </summary>
        /// <value>The last not synchronize goods list.</value>
        private List<SyncGoodsList> lastNotSyncGoodsList { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="TBSyncControlPanel"/> class.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public TBSyncControlPanel(string[] args)
        {
            InitializeComponent();
            if (args.Length > 0)
            {
                LoginToken = args[0];
                currentUserId = Convert.ToInt32(args[1]);
            }
            //LoginToken = "1a96e54f-decf-4109-894e-02f54505dd97";
            //currentUserId = 2;
            //如果token或userid为空，则关闭应用
            if (string.IsNullOrEmpty(LoginToken) || currentUserId == 0)
                this.Close();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TBSyncControlPanel_Load(object sender, EventArgs e)
        {
            var data = LogicSyncGoods.In(currentUserId).FindByUserSyncAccount(currentUserId);
            if (data != null)
            {
                txtLoginName.Text = data.loginname;
                txtLoginPwd.Text = data.loginpwd;
            }
        }


        /// <summary>
        /// 设置进度条进度
        /// </summary>
        /// <param name="ipos"></param>
        private void SetPos(int ipos)
        {
            if (SyncGoodsProgress.InvokeRequired)
            {
                this.Invoke(new Action<int>(SetPos), new object[] { ipos });
            }
            else
            {
                this.SyncGoodsProgress.Value = ipos;
            }
        }

        /// <summary>
        /// 点击登录
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLoginTaobao_Click(object sender, EventArgs e)
        {

            if (lw == null || !isLoginSuccess)
            {
                SetbtnLoginTaobaoText("登录淘宝");
                if (!BindTaobao())
                {
                    MessageBox.Show("请输入淘宝账号和密码", "提示");
                    return;
                }
                IsRefreshLogin = false;
                lw = new LoginWindow();
                lw.LoginSuccessHandle += Lw_LoginSuccessHandle;
                lw.SubmitSuccessHandle += Lw_SubmitSuccessHandle;
                lw.LoadSuccessHandle += Lw_LoadSuccessHandle;
                lw.Show();
                SetText("登录中...");

            }
            else if (IsRefreshLogin)
            {
                VerifyCookies();
            }
        }
        /// <summary>
        /// 定向计划申请完成
        /// </summary>
        /// <param name="success">if set to true [success].</param>
        /// <param name="data">The data.</param>
        private void Lw_SubmitSuccessHandle(bool success, SyncGoodsList data)
        {
            if (success)
                SetText(string.Format("{0} 计划申请成功.", data.goodsId));

            LogicSyncGoods.In(currentUserId).DeleteUserSyncGoods(data.goodsId, currentUserId, data.taobaousername);
            isCompleted = true;
        }

        /// <summary>
        /// 登录页面加载完成后
        /// </summary>
        /// <param name="success">if set to true [success].</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void Lw_LoadSuccessHandle(bool success)
        {
            if (success && !string.IsNullOrEmpty(loginname) && !string.IsNullOrEmpty(loginpwd))
            {
                if (lw != null)
                {
                    lw.InputAccount(loginname, loginpwd);
                }
            }
            else
            {
                SetText("自动登录失败，请手动登录...");
            }

        }
        /// <summary>
        /// 显示登录页面
        /// </summary>
        private void loginWindow()
        {
            if (lw.InvokeRequired)
            {
                this.lw.Invoke(new Action(loginWindow), new object[] { });
            }
            else
            {
                lw.Show();
            }
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        private void loginWindowsClose()
        {
            if (lw.InvokeRequired)
            {
                this.lw.Invoke(new Action(loginWindowsClose), new object[] { });
            }
            else
            {
                lw.Close();
                lw = null;
                isLoginSuccess = false;
                isStartAsync = false;
            }
        }

        /// <summary>
        /// 设置最后更新时间
        /// </summary>
        /// <param name="text">The text.</param>
        private void LastSyncTime(string text)
        {
            if (lblastSyncTime.InvokeRequired)
            {
                this.lblastSyncTime.Invoke(new Action<string>(LastSyncTime), new object[] { text });
            }
            else
            {
                lblastSyncTime.Text = text;
            }
        }

        /// <summary>
        /// 设置未同步商品
        /// </summary>
        /// <param name="count">The count.</param>
        private void SetNotSyncGoodsCount(int count)
        {
            if (lbSyncGoodsCount.InvokeRequired)
            {
                this.lbSyncGoodsCount.Invoke(new Action<int>(SetNotSyncGoodsCount), new object[] { count });
            }
            else
            {
                lbSyncGoodsCount.Text = string.Format("剩余{0}件商品未同步", count);
            }
        }

        /// <summary>
        /// 登录成功回调
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void Lw_LoginSuccessHandle(JArray jsons)
        {
            SetText("登录成功!");

            //
            LogicSyncGoods.In(currentUserId).AddUserSyncAccount(new SyncAccountModel()
            {
                loginname = loginname,
                loginpwd = loginpwd,
                userid = currentUserId
            });

            var lastSyncTime = LogicSyncGoods.In(currentUserId).FindByUserLastSyncTime(currentUserId, loginname);
            if (lastSyncTime != null)
                LastSyncTime(lastSyncTime.datetime);
            else
                LastSyncTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));


            cookieJson = JsonConvert.SerializeObject(jsons);
            VerifyCookies();
        }

        /// <summary>
        /// 校验cookie
        /// </summary>
        private void VerifyCookies()
        {
            SetText("正在校验...");
            //绑定淘宝账号
            var result = LogicSyncGoods.Instance.BindTaobao(LoginToken, cookieJson, false);
            if (result.resultCode == 200 || result.resultCode == 510)
            {
                //没有绑定过淘宝，则直接绑定
                if (result.resultCode == 510)
                {
                    new Thread(() =>
                    {
                        LogicSyncGoods.Instance.BindTaobao(LoginToken, cookieJson, true);
                    })
                    { IsBackground = true }.Start();
                }
                //设置按钮文字
                SetbtnLoginTaobaoText("已登录");

                //获取需要同步的数据
                GetSyncGoodsCount();
            }
            else if (result.resultCode == 511)
            {
                SetText("当前登录的阿里妈妈帐号跟火淘助手登录的帐号不匹配!");
                SetText("请使用同一个阿里妈妈账号登录!");
                loginWindowsClose();
            }
            else
            {
                SetText("登录失败，重新登录！请刷新状态!");
                IsRefreshLogin = true;
                //设置按钮文字
                SetbtnLoginTaobaoText("刷新状态");
            }
        }


        /// <summary>
        /// 获取需要同步的商品数量
        /// </summary>
        private void GetSyncGoodsCount()
        {
            new Thread(() =>
            {
                SyncGoodsCount = 0;
                SetText("正在查询同步数量...");

                //获取上传未同步完成的商品数据
                lastNotSyncGoodsList = LogicSyncGoods.In(currentUserId).FindByUserSyncGoodsList(currentUserId, loginname);
                if (lastNotSyncGoodsList != null && lastNotSyncGoodsList.Count() > 0)
                {
                    lastNotSyncGoodsCount = lastNotSyncGoodsList.Count();
                    SetText("上次剩余 " + lastNotSyncGoodsCount + " 条商品未同步!");
                }

                //页面加载完成回调
                SyncGoodsCount = LogicSyncGoods.Instance.GetCountForApplyGoods(LoginToken);
                SetText("查询完成，本次更新 " + SyncGoodsCount + " 条商品!");
                //if (SyncGoodsCount > 0)
                GetSyncGoodsList();
            })
            { IsBackground = true }.Start();
        }
        /// <summary>
        /// 获取需要同步的商品地址列表
        /// </summary>
        private void GetSyncGoodsList()
        {
            new Thread(() =>
            {
                if (SyncGoodsCount > 0)
                {
                    SetText("正在获取同步数据...");
                    //页面加载完成回调
                    syncGoods = LogicSyncGoods.Instance.GetListForApplyGoods(LoginToken);
                    //更新商品入库
                    StorageSyncGoods();
                }

                //确认时间
                LogicSyncGoods.In(currentUserId).GetConfirmForApplyGoods(LoginToken);

                isLoginSuccess = true;
            })
            { IsBackground = true }.Start();
        }


        /// <summary>
        /// 将同步商品存在本地数据库
        /// </summary>
        /// <param name="goods"></param>
        private void StorageSyncGoods()
        {
            if (syncGoods == null) return;

            //同步商品大于0
            if (syncGoods.list != null && syncGoods.list.Count() > 0)
            {
                SetText("准备同步数据...");

                syncGoods.list.ForEach(item =>
                {
                    if (!string.IsNullOrEmpty(item.url) && item.url.Length > 80 && !item.url.Contains("detail.tmall.com") && !item.url.Contains("item.taobao.com"))
                    {
                        item.userid = currentUserId;
                        item.taobaousername = loginname;
                        item.id = LogicSyncGoods.In(currentUserId).AddUserSyncGoods(item);
                    }
                });

                SetText("准备完成!");
            }
        }

        /// <summary>
        /// 开始同步
        /// </summary>
        private void StartSync()
        {
            isStartAsync = true;
            btnAsyncGoods.Text = "暂停同步";
            SetText("启动同步");
            SyncGoodsProgressVisible(true);

            //添加最后更新时间
            LogicSyncGoods.In(currentUserId).AddUserLastSyncTime(new LastSyncTimeModel()
            {
                userid = currentUserId,
                datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                taobaousername = loginname
            });

            lastNotSyncGoodsList = LogicSyncGoods.In(currentUserId).FindByUserSyncGoodsList(currentUserId, loginname);
            if (lastNotSyncGoodsList != null)
                SetNotSyncGoodsCount(lastNotSyncGoodsList.Count());

            var data = lastNotSyncGoodsList;
            int len = data.Count();
            SyncGoodsProgress.Maximum = len;
            new Thread(() =>
            {
                if (lastNotSyncGoodsList != null && lastNotSyncGoodsList.Count() > 0)
                {
                    SetText("开始申请计划...");

                    bool isFinish = true;
                    for (int i = 0; i < len; i++)
                    {
                        isCompleted = false;
                        if (isStartAsync)
                        {
                            if (lw == null)
                                break;
                            if (!string.IsNullOrEmpty(data[i].url))
                            {
                                //申请计划                                
                                lw.GoPlanPage(data[i]);
                                SetPos(i + 1);
                                while (!isCompleted && isStartAsync) { }
                                SetNotSyncGoodsCount(len - (i + 1));
                            }
                        }
                        else
                        {
                            isFinish = false;
                            break;
                        }
                    }

                    if (isFinish)
                    {
                        SyncGoodsProgressVisible(false);
                        SetText("同步完成!");
                    }
                }
            })
            { IsBackground = true }.Start();

        }

        /// <summary>
        /// 文本输出
        /// </summary>
        /// <param name="text"></param>
        public void SetText(string text)
        {
            if (txtMsgTip.InvokeRequired)
            {
                this.txtMsgTip.Invoke(new Action<string>(SetText), new object[] { text });
            }
            else
            {
                txtMsgTip.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + text + "\r\n");
                this.txtMsgTip.Refresh();
                this.txtMsgTip.ScrollToCaret();
            }
        }

        /// <summary>
        /// 设置进度条的显示状态
        /// </summary>
        /// <param name="Visible">if set to true [visible].</param>
        private void SyncGoodsProgressVisible(bool Visible)
        {
            if (SyncGoodsProgress.InvokeRequired)
            {
                this.SyncGoodsProgress.Invoke(new Action<bool>(SyncGoodsProgressVisible), new object[] { Visible });
            }
            else
            {
                this.SyncGoodsProgress.Visible = Visible;
            }
        }


        /// <summary>
        /// 设置登录按钮文字为已登录
        /// </summary>
        /// <param name="enabled"></param>
        public void SetbtnLoginTaobaoText(string text)
        {
            if (btnLoginTaobao.InvokeRequired)
            {
                this.btnLoginTaobao.Invoke(new Action<string>(SetbtnLoginTaobaoText), new object[] { text });
            }
            else
            {
                btnLoginTaobao.Text = text;
            }
        }

        private void btnAsyncGoods_Click(object sender, EventArgs e)
        {
            if (isLoginSuccess)
            {
                if (!isStartAsync && lw != null)
                {
                    StartSync();
                }
                else
                {
                    isStartAsync = false;
                    SetText("停止同步");
                    btnAsyncGoods.Text = "开启同步";
                }
            }
            else
            {
                SetText("请先登录淘宝");
            }
        }


        private void pbClose_Click(object sender, EventArgs e)
        {
            if (!isStartAsync)
            {
                if (lw != null)
                {
                    lw.Close();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("正在同步中，请先暂停同步");
            }
        }

        private void pbMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 绑定淘宝账号
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnBindTaobao_Click(object sender, EventArgs e)
        {
            if (!BindTaobao())
                MessageBox.Show("请输入淘宝账号和密码", "提示");
        }


        private bool BindTaobao()
        {
            if (!string.IsNullOrEmpty(txtLoginName.Text) && !string.IsNullOrEmpty(txtLoginPwd.Text))
            {
                loginname = txtLoginName.Text;
                loginpwd = txtLoginPwd.Text;
                txtLoginName.ReadOnly = true;
                txtLoginPwd.ReadOnly = true;
                return true;
            }
            return false;
        }
        static bool isShow = false;
        private void toolsIsShowWindow_Click(object sender, EventArgs e)
        {
            if (lw != null)
            {
                if (!isShow)
                {
                    isShow = true;
                    lw.Show();
                }
                else
                {
                    isShow = false;
                    lw.Hide();
                }
            }
        }
    }
}
