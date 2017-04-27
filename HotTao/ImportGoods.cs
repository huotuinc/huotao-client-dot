using HotCoreUtils.Helper;
using HotTao.Controls;
using HotTaoCore;
using HotTaoCore.Logic;
using HotTaoCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotTao
{
    public partial class ImportGoods : Form
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

        private bool ImportStart { get; set; }

        /// <summary>
        /// 导入类型 pid,goods
        /// </summary>
        /// <value>The type of the import.</value>
        public string ImportType { get; set; }


        /// <summary>
        /// 任务界面视图
        /// </summary>
        /// <value>The task control.</value>
        public TaskControl taskControl { get; set; }

        public ImportGoods(TaskControl control)
        {
            InitializeComponent();
            taskControl = control;
        }
        private void ImportGoods_Load(object sender, EventArgs e)
        {
            ImportStart = false;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            if (!ImportStart)
                this.Close();
            else
            {
                bool isOk = false;
                MessageConfirm alert = new MessageConfirm(ImportType == "goods" ? "正在导入商品，确认退出吗?" : "正在导入PID，确认退出吗?");
                alert.CallBack += () => { isOk = true; };
                alert.ShowDialog(this);
                if (isOk)
                    this.Close();
            }
        }
        private bool is2007 = true;
        /// <summary>
        /// 选择商品
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            if (this.uploadFile.ShowDialog() == DialogResult.OK)
            {
                string ext = this.uploadFile.SafeFileName.Split('.')[1];
                if (ext == "xls")
                    is2007 = false;
                this.txtpath.Text = this.uploadFile.FileName;
            }
        }

        /// <summary>
        /// 开始导入
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnStartImport_Click(object sender, EventArgs e)
        {
            if (ImportStart)
                return;
            ImportStart = true;
            string filePath = this.txtpath.Text;
            new Thread(() =>
            {
                if (File.Exists(filePath))
                {
                    try
                    {
                        if (ImportType == "pid")
                            ImportPidData(filePath);
                        else if (ImportType == "goods")
                            ImportGoodsData(filePath);
                    }
                    catch (Exception ex)
                    {
                        ImportStart = false;
                        SetText(ex.Message);
                    }
                }
                else
                {
                    ImportStart = false;
                    SetText("数据源不存在");
                }
            })
            { IsBackground = true }.Start();
        }


        private void SetText(string text)
        {
            if (this.rtbMsg.InvokeRequired)
            {
                this.Invoke(new Action<string>(SetText), new object[] { text });
            }
            else
            {
                this.rtbMsg.AppendText(">>>" + DateTime.Now.ToString("HH:mm:ss") + " " + text + "\r\n");
                this.rtbMsg.Refresh();
                this.rtbMsg.ScrollToCaret();
            }
        }

        private void lktemplate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\template");
        }

        private void ImportPidData(string filePath)
        {
            DataTable dt = is2007 ? ExcelHelper.ImportExcel2007toDt(filePath) : ExcelHelper.ImportExcel2003toDt(filePath);
            if (dt != null)
            {
                try
                {
                    List<UserPidModel> data = new List<UserPidModel>();
                    foreach (DataRow row in dt.Rows)
                    {
                        var model = new SQLiteEntitysModel.weChatGroupModel()
                        {
                            title = row[0].ToString(),
                            pid = row[1].ToString(),
                            userid = MyUserInfo.currentUserId
                        };
                        int flag = LogicHotTao.Instance(MyUserInfo.currentUserId).AddUserWeChatGroup(model);
                        if (flag > 0)
                            SetText("微信群：" + model.title + "导入成功...");
                        else
                            SetText("微信群：" + model.title + "导入失败...");
                    }
                }
                catch (Exception ex)
                {
                    SetText(ex.Message);
                }
                ImportStart = false;                
                SetText("数据导入完成");
                taskControl.loadUserPidGridView();
            }
        }



        private void ImportGoodsData(string filePath)
        {
            DataTable dt = is2007 ? ExcelHelper.ImportExcel2007toDt(filePath) : ExcelHelper.ImportExcel2003toDt(filePath);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        GoodsModel goods = new GoodsModel()
                        {
                            userid = MyUserInfo.currentUserId,
                            goodsId = row["商品id"].ToString(),
                            goodsName = row["商品名称"].ToString(),
                            goodsIntro = row["商品简介"].ToString(),
                            goodsMainImgUrl = row["商品主图"].ToString(),
                            goodsDetailUrl = row["商品详情页链接地址"].ToString(),
                            goodsSupplier = row["平台类型"].ToString(),
                            goodsComsRate = Convert.ToDecimal(row["收入比率(%)"].ToString()),
                            goodsPrice = Convert.ToDecimal(row["商品价格"].ToString()),
                            goodsSalesAmount = Convert.ToInt32(row["商品月销量"].ToString()),
                            endTime = Convert.ToDateTime(row["优惠券结束时间"].ToString()),
                            couponUrl = row["优惠券链接"].ToString(),
                            couponId = row["优惠券id"].ToString(),
                            couponPrice = Convert.ToDecimal(row["优惠券面额(单位元)"].ToString())
                        };

                        string fileName = Environment.CurrentDirectory + "\\temp\\img\\" + MyUserInfo.currentUserId;

                        if (!Directory.Exists(fileName))
                            Directory.CreateDirectory(fileName);
                        fileName += "\\" + EncryptHelper.MD5(goods.goodsId) + ".jpg";
                        //判断文件是否存在
                        if (!File.Exists(fileName))
                        {
                            downloadGoodsImage(fileName, goods.goodsMainImgUrl, goods.goodsId);
                            //byte[] data = BaseRequestService.GetNetWorkImageData(goods.goodsMainImgUrl);
                            //if (data != null)
                            //{
                            //    MemoryStream ms = new MemoryStream(data);
                            //    Bitmap img = new Bitmap(ms);
                            //    img.Save(fileName, ImageFormat.Jpeg);
                            //    ms.Dispose();
                            //    ms = null;
                            //    img.Dispose();
                            //    img = null;
                            //}
                            //else continue;
                        }
                        goods.goodslocatImgPath = fileName;
                        if (LogicHotTao.Instance(MyUserInfo.currentUserId).AddUserGoods(goods) > 0)
                            SetText("商品：" + goods.goodsId.ToString() + "导入成功...");
                        else
                            SetText("商品：" + goods.goodsId.ToString() + "导入失败...");
                    }
                    catch (Exception ex)
                    {
                        SetText(ex.Message);
                    }
                }
                ImportStart = false;                
                SetText("数据导入完成");
                taskControl.LoadGoodsGridView();
            }
        }


        /// <summary>
        /// 下载商品图片
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="goodsImageUrl">The goods image URL.</param>
        private void downloadGoodsImage(string fileName, string goodsImageUrl, string goodsid)
        {
            new Thread(() =>
            {
                try
                {
                    string _goodsid = goodsid;
                    byte[] data = BaseRequestService.GetNetWorkImageData(goodsImageUrl);
                    if (data == null)
                    {
                        Thread.Sleep(1000);
                        data = BaseRequestService.GetNetWorkImageData(goodsImageUrl);
                    }
                    if (data != null)
                    {
                        MemoryStream ms = new MemoryStream(data);
                        Bitmap img = new Bitmap(ms);
                        img.Save(fileName, ImageFormat.Jpeg);
                        ms.Dispose();
                        ms = null;
                        img.Dispose();
                        img = null;
                    }
                    else
                    {
                        log.Info("网络图片地址：" + goodsImageUrl);
                        //_goodsid
                    }

                }
                catch (Exception ex)
                {

                    log.Error("downloadGoodsImage:" + ex.ToString());
                }
            })
            { IsBackground = true }.Start();
        }
    }
}
