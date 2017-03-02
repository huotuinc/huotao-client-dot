using System;
using System.Drawing;
using System.Windows.Forms;
using HotTaoCore.Logic;


namespace HotTao.Controls
{
    public partial class AddKeywordControl : Form
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
        private SetAutoReplyControl hotControl { get; set; }

        public AddKeywordControl(Main main, SetAutoReplyControl control)
        {
            InitializeComponent();
            hotForm = main;
            hotControl = control;
        }


        /// <summary>
        /// 添加关键字
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AddKeywordControl_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Title))
                lbTitle.Text = Title;
        }


        /// <summary>
        /// 窗口标题
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }
        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKeyword.Text))
            {
                txtKeyword.Focus();
                return;
            }
            if (ckbAutoText.Checked)
            {
                if (string.IsNullOrEmpty(txtReplyContent.Text))
                {
                    txtReplyContent.Focus();
                    return;
                }
            }
            int flag = 0;
            int replyType = 0;
            if (ckbAutoText.Checked)
                replyType = 0;
            if (ckbAutoGoods.Checked)
                replyType = 1;


            string keyword = txtKeyword.Text;
            string content = txtReplyContent.Text;

            MessageAlert alert = new MessageAlert();
            Loading ld = new Loading();
            ((Action)(delegate ()
            {



                flag = LogicUser.Instance.AddReplyKeyword(MyUserInfo.LoginToken, keyword, content, replyType, 0) ? 1 : 0;
                ld.CloseForm();
                if (flag > 0)
                    alert.Message = "添加成功";
                else
                    alert.Message = "添加失败，请稍候再试!";
                this.BeginInvoke((Action)(delegate ()
                {
                    alert.ShowDialog(this);
                    if (flag > 0)
                    {
                        hotControl.LoadDgvKeyword();
                        this.Close();
                    }
                }));

            })).BeginInvoke(null, null);
            ld.ShowDialog(hotForm);
        }
    }
}
