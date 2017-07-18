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
    }

}
