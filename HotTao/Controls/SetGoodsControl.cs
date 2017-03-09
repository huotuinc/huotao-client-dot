using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotTao.Controls
{
    public partial class SetGoodsControl : Form
    {
        private Main hotForm { get; set; }
        public SetGoodsControl(Main mainWin)
        {
            InitializeComponent();
            hotForm = mainWin;
        }
        private void SetGoodsControl_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 显示默认模板
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDefaultTemplate_Click(object sender, EventArgs e)
        {
            txtTempText.Text = MyUserInfo.defaultSendTempateText;
        }

        /// <summary>
        /// 将变量标签插入指定位置
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SetTag_Click(object sender, EventArgs e)
        {
            Label tag = sender as Label;
            string strInsertText = tag.Text;
            int start = txtTempText.SelectionStart;
            txtTempText.Text = txtTempText.Text.Insert(start, strInsertText);
            txtTempText.SelectionStart = start;
            txtTempText.SelectionLength = strInsertText.Length;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
