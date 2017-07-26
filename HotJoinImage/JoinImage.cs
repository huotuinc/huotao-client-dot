﻿/*
 * 版权所有:杭州火图科技有限公司
 * 地址:浙江省杭州市滨江区西兴街道阡陌路智慧E谷B幢4楼在地图中查看
 * (c) Copyright Hangzhou Hot Technology Co., Ltd.
 * Floor 4,Block B,Wisdom E Valley,Qianmo Road,Binjiang District
 * 2013-2017. All rights reserved.
 * author guomw
**/


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using ThoughtWorks.QRCode.Codec;

namespace HotJoinImage
{

    /// <summary>
    /// 图片拼接
    /// </summary>
    public class JoinImage
    {
        /// <summary>
        /// 二维码框图
        /// </summary>
        private const string qrcode_base64 = "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cm9vZgAAAAlwcm9vZkNNWUsAOEJJTQQ7AAAAAAItAAAAEAAAAAEAAAAAABJwcmludE91dHB1dE9wdGlvbnMAAAAXAAAAAENwdG5ib29sAAAAAABDbGJyYm9vbAAAAAAAUmdzTWJvb2wAAAAAAENybkNib29sAAAAAABDbnRDYm9vbAAAAAAATGJsc2Jvb2wAAAAAAE5ndHZib29sAAAAAABFbWxEYm9vbAAAAAAASW50cmJvb2wAAAAAAEJja2dPYmpjAAAAAQAAAAAAAFJHQkMAAAADAAAAAFJkICBkb3ViQG/gAAAAAAAAAAAAR3JuIGRvdWJAb+AAAAAAAAAAAABCbCAgZG91YkBv4AAAAAAAAAAAAEJyZFRVbnRGI1JsdAAAAAAAAAAAAAAAAEJsZCBVbnRGI1JsdAAAAAAAAAAAAAAAAFJzbHRVbnRGI1B4bEBSAAAAAAAAAAAACnZlY3RvckRhdGFib29sAQAAAABQZ1BzZW51bQAAAABQZ1BzAAAAAFBnUEMAAAAATGVmdFVudEYjUmx0AAAAAAAAAAAAAAAAVG9wIFVudEYjUmx0AAAAAAAAAAAAAAAAU2NsIFVudEYjUHJjQFkAAAAAAAAAAAAQY3JvcFdoZW5QcmludGluZ2Jvb2wAAAAADmNyb3BSZWN0Qm90dG9tbG9uZwAAAAAAAAAMY3JvcFJlY3RMZWZ0bG9uZwAAAAAAAAANY3JvcFJlY3RSaWdodGxvbmcAAAAAAAAAC2Nyb3BSZWN0VG9wbG9uZwAAAAAAOEJJTQPtAAAAAAAQAEgAAAABAAIASAAAAAEAAjhCSU0EJgAAAAAADgAAAAAAAAAAAAA/gAAAOEJJTQQNAAAAAAAEAAAAHjhCSU0EGQAAAAAABAAAAB44QklNA/MAAAAAAAkAAAAAAAAAAAEAOEJJTScQAAAAAAAKAAEAAAAAAAAAAjhCSU0D9QAAAAAASAAvZmYAAQBsZmYABgAAAAAAAQAvZmYAAQChmZoABgAAAAAAAQAyAAAAAQBaAAAABgAAAAAAAQA1AAAAAQAtAAAABgAAAAAAAThCSU0D+AAAAAAAcAAA/////////////////////////////wPoAAAAAP////////////////////////////8D6AAAAAD/////////////////////////////A+gAAAAA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PSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bWxuczpkYz0iaHR0cDovL3B1cmwub3JnL2RjL2VsZW1lbnRzLzEuMS8iIHhtbG5zOnBob3Rvc2hvcD0iaHR0cDovL25zLmFkb2JlLmNvbS9waG90b3Nob3AvMS4wLyIgeG1wTU06T3JpZ2luYWxEb2N1bWVudElEPSI0QkI0RDc1RjQxRUJBMTI0RkNDRTI2RDgzQzcxMDgzMyIgeG1wTU06RG9jdW1lbnRJRD0ieG1wLmRpZDo0MjRFNEIyQjZBRDExMUU3ODEyMUMxRUIyNTVGNTA4RiIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDo1YzBiY2Y1Ny0yYzM4LTgyNDYtYTE3Ny1mZjI5NjE3NTBmM2UiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENDIDIwMTcgKFdpbmRvd3MpIiB4bXA6Q3JlYXRlRGF0ZT0iMjAxNy0wNy0xOFQxNToxMDoyMCswODowMCIgeG1wOk1vZGlmeURhdGU9IjIwMTctMDctMThUMTU6MTA6NDUrMDg6MDAiIHhtcDpNZXRhZGF0YURhdGU9IjIwMTctMDctMThUMTU6MTA6NDUrMDg6MDAiIGRjOmZvcm1hdD0iaW1hZ2UvanBlZyIgcGhvdG9zaG9wOkNvbG9yTW9kZT0iMyIgcGhvdG9zaG9wOklDQ1Byb2ZpbGU9IiI+DQoJCQk8eG1wTU06RGVyaXZlZEZyb20gc3RSZWY6aW5zdGFuY2VJRD0ieG1wLmlpZDo5MWYyZWE0Ni03NTk1LWM5NGMtYjQzMy1jZDE4NTllM2NkOGIiIHN0UmVmOmRvY3VtZW50SUQ9ImFkb2JlOmRvY2lkOnBob3Rvc2hvcDo5ZThmMTRiMS02YWMyLTExZTctYWM5MC04N2NhYTU4MThmNjUiLz4NCgkJCTx4bXBNTTpIaXN0b3J5Pg0KCQkJCTxyZGY6U2VxPg0KCQkJCQk8cmRmOmxpIHN0RXZ0OmFjdGlvbj0ic2F2ZWQiIHN0RXZ0Omluc3RhbmNlSUQ9InhtcC5paWQ6NWMwYmNmNTctMmMzOC04MjQ2LWExNzctZmYyOTYxNzUwZjNlIiBzdEV2dDp3aGVuPSIyMDE3LTA3LTE4VDE1OjEwOjQ1KzA4OjAwIiBzdEV2dDpzb2Z0d2FyZUFnZW50PSJBZG9iZSBQaG90b3Nob3AgQ0MgMjAxNyAoV2luZG93cykiIHN0RXZ0OmNoYW5nZWQ9Ii8iLz4NCgkJCQk8L3JkZjpTZXE+DQoJCQk8L3htcE1NOkhpc3Rvcnk+DQoJCTwvcmRmOkRlc2NyaXB0aW9uPg0KCTwvcmRmOlJERj4NCjwveDp4bXBtZXRhPg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgPD94cGFja2V0IGVuZD0ndyc/Pv/bAEMAAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQICAgICAgICAgICAwMDAwMDAwMDA//bAEMBAQEBAQEBAQEBAQICAQICAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDA//CABEIAQwBDAMBEQACEQEDEQH/xAAeAAEAAgIDAQEBAAAAAAAAAAAABQcGCAIDBAkBCv/EADUQAAAEBQMCAgkEAwEBAAAAAAIDBAUAAQYHCEAVNSAWERIxMhMUNjcYOAkQUBcZkCE0Iyf/xAAcAQEAAAcBAAAAAAAAAAAAAAAAAQIDBAUGBwj/xABQEQABAwEDBgsDBgkJCQAAAAABAgMEBQARBiExErR1ByBAQROT0zSU1DUIEFEiYXGRMhQJgbFyIxXVJnY4UKHRQmIzlba3gtJDJCW1FncY/8QAVRIAAQMBBAUGBgsLCQkAAAAAARECAwQAIRIFMUFREwYQQGEiBwhxgZEys3WhsUJyIzOT0xR0tcHRUrLSoyQ01DY3IFCQ8JKDlBV24WKCwkO0VWU4/9oADAMBAAIQAxAAAAD++qSXE8a9VPIcZqfTSspfPQyGWoAAAAAAAAAB5LGOJWV96JocY0/yxjK7LrM9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";

        /// <summary>
        /// 多图垂直拼接
        /// </summary>
        /// <param name="imageList"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        private static Image GetJoinImage(List<Image> imageList, int w)
        {
            try
            {
                //图片列表
                if (imageList.Count <= 0)
                    return null;

                //纵向拼接
                int height = 0;
                //计算总长度
                foreach (Image i in imageList)
                {
                    height += i.Height;
                }
                //宽度不变
                int width = w;
                //构造最终的图片白板
                Bitmap tableChartImage = new Bitmap(width, height);
                Graphics graph = Graphics.FromImage(tableChartImage);
                //初始化这个大图
                graph.DrawImage(tableChartImage, width, height);
                //初始化当前宽
                int currentHeight = 0;
                foreach (Image i in imageList)
                {
                    //拼图
                    graph.DrawImage(i, 0, currentHeight);
                    //拼接改图后，当前宽度
                    currentHeight += i.Height;
                }

                graph.Dispose();
                return tableChartImage;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取拼接图片
        /// </summary>
        /// <param name="imageList"></param>        
        /// <param name="w"></param>        
        /// <param name="qrCodeUrl">二维码内容</param>
        /// <returns></returns>
        public static Image GetJoinImage(List<JoinGoodsInfo> imageList, int w, string qrCodeUrl, string desc = "今日爆款")
        {
            if (string.IsNullOrEmpty(desc))
                desc = "今日爆款";
            List<Image> list = new List<Image>();
            int len = imageList.Count();
            foreach (var item in imageList)
            {
                try
                {
                    Image goodsImage = null;
                    using (Stream stream = new FileStream(item.imagePath, FileMode.Open))
                    {
                        goodsImage = Image.FromStream(stream);
                    }

                    int leftX = 350;
                    //构造最终的图片白板
                    Bitmap tableChartImage = new Bitmap(w, 320);
                    Graphics graph = Graphics.FromImage(tableChartImage);
                    //设置白底
                    graph.FillRectangle(Brushes.White, new Rectangle(0, 0, tableChartImage.Width, tableChartImage.Height));
                    var _goodsImage = KiResizeImage(goodsImage, 310, 310);
                    graph.DrawImage(_goodsImage, 5, 5);
                    if (item.GoodsName.Length > 20)
                    {
                        string t = item.GoodsName.Substring(0, 18);
                        //绘制商品标题Begin                 
                        graph.DrawString(t, new Font("微软雅黑", 18), new SolidBrush(Color.Black), leftX, 20);

                        if (item.GoodsName.Length > 36)
                            t = item.GoodsName.Substring(18, 17);
                        else
                            t = item.GoodsName.Substring(18);
                        graph.DrawString(t, new Font("微软雅黑", 18), new SolidBrush(Color.Black), leftX, 60);
                    }
                    else
                    {
                        graph.DrawString(item.GoodsName, new Font("微软雅黑", 18), new SolidBrush(Color.Black), leftX, 50);
                    }

                    //绘制券后价
                    graph.DrawString("优惠券", new Font("微软雅黑", 16), new SolidBrush(Color.Gray), leftX, 110);
                    //绘制优惠券
                    graph.DrawString("￥" + (item.CouponPrice).ToString("f0"), new Font("微软雅黑", 18), new SolidBrush(Color.Red), leftX + 65, 110);

                    //绘制券后价
                    graph.DrawString("券后价", new Font("微软雅黑", 16), new SolidBrush(Color.Gray), leftX, 160);
                    //绘制美元符号
                    graph.DrawString("￥", new Font("微软雅黑", 16), new SolidBrush(Color.Red), leftX + 65, 160);

                    //绘制券后价
                    graph.DrawString((item.GoodsPrice - item.CouponPrice).ToString("f2"), new Font("微软雅黑", 26), new SolidBrush(Color.Red), leftX + 90, 146);


                    list.Add(tableChartImage);
                    graph.Dispose();
                }
                catch (Exception)
                {

                }
            }


            //构造最终的图片白板
            Bitmap qrBit = new Bitmap(w, 268);
            Graphics graph2 = Graphics.FromImage(qrBit);
            //设置白底
            graph2.FillRectangle(Brushes.White, new Rectangle(0, 0, qrBit.Width, qrBit.Height));

            var r = BuildQrCode(qrCodeUrl);
            //今日爆款
            graph2.DrawString(desc, new Font("微软雅黑", 30), new SolidBrush(Color.Red), 410 / 2 - (30 * desc.Length) / 2, 70);

            graph2.DrawString("长按识别二维码领券下单", new Font("微软雅黑", 16), new SolidBrush(Color.Gray), 410 / 2 - (16 * 10) / 2, 140);

            graph2.DrawImage(r, (800 - r.Width) - 10, 0);
            list.Add(qrBit);
            graph2.Dispose();

            return GetJoinImage(list, w);
        }

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static Image BuildQrCode(string url)
        {
            Bitmap qrImage = new Bitmap(GetQrCodeBtimap());
            Graphics graph = Graphics.FromImage(qrImage);
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 9;
            qrCodeEncoder.QRCodeVersion = 8;//默认为8
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
            var img = qrCodeEncoder.Encode(url);
            var newImg = KiResizeImage(img, 220, 220);
            graph.DrawImage(newImg, 24, 20);
            graph.Dispose();
            return qrImage;

        }
        /// <summary>  
        /// Resize图片  
        /// </summary>  
        /// <param name="bmp">原始Bitmap  
        /// <param name="newW">新的宽度  
        /// <param name="newH">新的高度  
        /// <param name="Mode">保留着，暂时未用  
        /// <returns>处理以后的图片</returns>  
        private static System.Drawing.Image KiResizeImage(System.Drawing.Image bmp, int newW, int newH)
        {
            try
            {
                System.Drawing.Image b = new System.Drawing.Bitmap(newW, newH);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(b);
                // 插值算法的质量  
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new System.Drawing.Rectangle(0, 0, newW, newH), new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 获取二维码模板图片
        /// </summary>
        /// <returns></returns>
        private static Bitmap GetQrCodeBtimap()
        {
            byte[] b = Convert.FromBase64String(qrcode_base64);
            MemoryStream ms = new MemoryStream(b);
            Bitmap bitmap = new Bitmap(ms);
            return bitmap;
        }

    }
}