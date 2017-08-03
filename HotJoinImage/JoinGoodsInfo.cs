using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HotJoinImage
{

    public class JoinGoodsInfo
    {
        /// <summary>
        /// 商品标题
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal GoodsPrice { get; set; }

        /// <summary>
        /// 优惠券价格1
        /// </summary>
        public decimal CouponPrice { get; set; }

        /// <summary>
        /// 商品图片地址
        /// </summary>
        public string imagePath { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        public string GoodsIntro { get; set; }
    }

    public class JoinGoodsList
    {
        /// <summary>
        /// 群ID
        /// </summary>
        public int id { get; set; }

        private int _taskId = 0;

        /// <summary>
        /// 商品
        /// </summary>
        public List<CollectionGoods> collectionGoodsList { get; set; } = new List<CollectionGoods>();

        private List<JoinGoodsInfo> _imageList = new List<JoinGoodsInfo>();

        /// <summary>
        /// 任务ID
        /// </summary>
        [JsonIgnore]
        public int TaskId
        {
            get
            {
                return _taskId;
            }

            set
            {
                _taskId = value;
            }
        }
        /// <summary>
        /// 图片地址
        /// </summary>        
        [JsonIgnore]
        public List<JoinGoodsInfo> ImageList
        {
            get
            {
                return _imageList;
            }

            set
            {
                _imageList = value;
            }
        }
    }

    public class CollectionGoods
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public string goodsId { get; set; }
        /// <summary>
        /// 商品标题
        /// </summary>
        public string goodsName { get; set; }
        /// <summary>
        /// 商品金额
        /// </summary>
        public decimal price { get; set; }
        /// <summary>
        /// 优惠券金额
        /// </summary>
        public decimal discountAmount { get; set; }
        /// <summary>
        /// 分享淘口令,弃用
        /// </summary>
        public string shareText { get; set; }
        /// <summary>
        /// 商品推广链接
        /// </summary>
        public string goodsPromotionUrl { get; set; }
        /// <summary>
        /// 商品图片地址
        /// </summary>
        public string goodsPrimaryImg { get; set; }


    }




}
