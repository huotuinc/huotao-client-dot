using HotTaoCore.Logic;
using HotTaoCore.Models;
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
        static string TaoBaoNo;
        public TBSyncControlPanel(string[] args)
        {
            InitializeComponent();
            if (args.Length > 0)
            {
                LoginToken = args[0];
            }


        }

        private void TBSyncControlPanel_Load(object sender, EventArgs e)
        {

            new Thread(() =>
            {
                for (int i = 1; i <= 500; i++)
                {
                    Thread.Sleep(500);
                    SetPos(100 * i / 500);
                }
            })
            { IsBackground = true }.Start();
            //if (string.IsNullOrEmpty(LoginToken))
            //    this.Close();
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
                this.lbprogress.Text = ipos.ToString() + "%";
                this.SyncGoodsProgress.Value = ipos;
            }
        }


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

        private string loginname = string.Empty;
        private string loginpwd = string.Empty;

        /// <summary>
        /// 同步的商品数量
        /// </summary>
        private int SyncGoodsCount { get; set; }


        private SyncGoodsModel syncGoods { get; set; }


        private void btnLoginTaobao_Click(object sender, EventArgs e)
        {
            if (lw == null || !isLoginSuccess)
            {
                if (string.IsNullOrEmpty(loginname) && string.IsNullOrEmpty(loginpwd))
                {
                    return;
                }
                lw = new LoginWindow();
                lw.LoginSuccessHandle += Lw_LoginSuccessHandle;
                lw.SubmitSuccessHandle += Lw_SubmitSuccessHandle;
                lw.LoadSuccessHandle += Lw_LoadSuccessHandle;
                lw.Show();
                lw.Hide();
            }
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
                Thread.Sleep(1000);
                if (lw != null)
                {
                    lw.InputAccount(loginname, loginpwd);
                    SetText("登录中...");
                }
            }
            else
            {
                if (lw != null)
                {
                    loginWindow();
                }
            }

        }
        /// <summary>
        /// 显示登录页面
        /// </summary>
        private void loginWindow()
        {
            if (lw.InvokeRequired)
            {
                this.Invoke(new Action(loginWindow), new object[] { });
            }
            else
            {
                lw.Show();
            }
        }


        /// <summary>
        /// 定向计划申请完成
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void Lw_SubmitSuccessHandle()
        {
            SetText("计划申请成功");
        }

        /// <summary>
        /// 登录成功回调
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void Lw_LoginSuccessHandle()
        {
            SetText("登录成功!");
            isLoginSuccess = true;
            SetbtnLoginTaobao(false);
            // GetSyncGoodsCount();
        }


        /// <summary>
        /// 获取需要同步的商品数量
        /// </summary>
        private void GetSyncGoodsCount()
        {
            new Thread(() =>
            {
                SyncGoodsCount = 0;
                SetText("正在获取需要同步的商品数量...");
                //页面加载完成回调
                SyncGoodsCount = LogicSyncGoods.Instance.GetCountForApplyGoods(LoginToken, loginname);
                SetText("获取成功，本次需同步 " + SyncGoodsCount + " 条商品!");
                if (SyncGoodsCount > 0)
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
                SetText("正在获取同步的商品数据!");
                //页面加载完成回调
                syncGoods = LogicSyncGoods.Instance.GetListForApplyGoods(LoginToken);

                SetText("平台 更新商品成功，本次共更新 " + SyncGoodsCount + " 条商品!");


            })
            { IsBackground = true }.Start();
        }


        private void StorageSyncGoods(SyncGoodsModel goods)
        {
            if (goods == null) return;

            //同步商品大于o
            if (goods.list != null && goods.list.Count() > 0)
            {

            }
        }



        /// <summary>
        /// 文本输出
        /// </summary>
        /// <param name="text"></param>
        public void SetText(string text)
        {
            if (txtMsgTip.InvokeRequired)
            {
                this.Invoke(new Action<string>(SetText), new object[] { text });
            }
            else
            {
                txtMsgTip.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + text + "\r\n");
                this.txtMsgTip.Refresh();
                this.txtMsgTip.ScrollToCaret();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enabled"></param>
        public void SetbtnLoginTaobao(bool enabled)
        {
            if (btnLoginTaobao.InvokeRequired)
            {
                this.Invoke(new Action<bool>(SetbtnLoginTaobao), new object[] { enabled });
            }
            else
            {
                btnLoginTaobao.Text = "退出登录";
                btnAsyncGoods.Enabled = true;
            }
        }

        private void btnAsyncGoods_Click(object sender, EventArgs e)
        {
            if (!isStartAsync && lw != null)
            {
                isStartAsync = true;
                //lw.GoPlanPage(textBox1.Text);
                btnAsyncGoods.Text = "暂停同步";
                SetText("启动同步");
                SetText("开始申请定向计划");
            }
            else if (isStartAsync)
            {
                isStartAsync = false;
                SetText("停止同步");
                btnAsyncGoods.Text = "开启同步";
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
            if (!string.IsNullOrEmpty(txtLoginName.Text) && !string.IsNullOrEmpty(txtLoginPwd.Text))
            {
                loginname = txtLoginName.Text;
                loginpwd = txtLoginPwd.Text;
                txtLoginName.ReadOnly = true;
                txtLoginPwd.ReadOnly = true;
                new Thread(() =>
                {
                    //页面加载完成回调
                    // LogicSyncGoods.Instance.BindTaobao(LoginToken, loginname, loginpwd, true);
                })
                { IsBackground = true }.Start();

            }
        }
    }
}
