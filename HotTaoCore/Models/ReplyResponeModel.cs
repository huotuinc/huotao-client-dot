using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTaoCore.Models
{
    public class ReplyResponeModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 任务ID
        /// </summary>
        public int taskid { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int userid { get; set; }
        /// <summary>
        /// 推广群昵称
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 推广内容
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string logo { get; set; }

        public string fileName { get; set; }
    }

    public class ReplyResponeDetailModel : ReplyResponeModel
    {


        public string ItemId { get; set; }

        /// <summary>
        /// 推广PID
        /// </summary>
        public string pid { get; set; }

        /// <summary>
        /// 商品图片
        /// </summary>
        public string goodsMainImgUrl { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string goodsName { get; set; }
        /// <summary>
        /// 推广链接
        /// </summary>
        public string shareLink { get; set; }

        public decimal goodsPrice { get; set; }

        public decimal couponPrice { get; set; }
        /// <summary>
        /// Gets or sets the coupon URL.
        /// </summary>
        /// <value>The coupon URL.</value>
        public string couponUrl { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string goodsSupplier { get; set; }

        /// <summary>
        /// 商品销量
        /// </summary>
        /// <value>The goods sales amount.</value>
        public int goodsSalesAmount { get; set; }
    }
}
