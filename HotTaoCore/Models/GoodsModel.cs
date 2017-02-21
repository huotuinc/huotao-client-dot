using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTaoCore.Models
{
    /// <summary>
    /// 商品实体
    /// </summary>
    public class GoodsModel
    {

        public long rowIndex { get; set; }

        /// <summary>
        /// 商品编号(自增)
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public string goodsId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string goodsName { get; set; }

        /// <summary>
        /// 商品主图地址
        /// </summary>
        public string goodsMainImgUrl { get; set; }

        /// <summary>
        /// 商品详情地址
        /// </summary>
        public string goodsDetailUrl { get; set; }

        /// <summary>
        /// 商品类型
        /// </summary>
        public string goodsType { get; set; }

        /// <summary>
        /// 商品所属，即供应商
        /// </summary>
        public string goodsSupplier { get; set; }

        /// <summary>
        /// 商品销量
        /// </summary>
        public int goodsSalesAmount { get; set; }

        /// <summary>
        /// 商品返佣率
        /// </summary>
        public decimal goodsComsRate { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal goodsPrice { get; set; }

        /// <summary>
        /// 佣金
        /// </summary>
        public decimal goodsCommission { get; set; }

        /// <summary>
        /// 优惠券金额
        /// </summary>
        public decimal couponPrice { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime startTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime endTime { get; set; }

        /// <summary>
        /// 优惠券链接
        /// </summary>
        public string couponUrl { get; set; }

        /// <summary>
        /// 推广链接
        /// </summary>
        public string shareLink { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime updateTime { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime createTime { get; set; }

    }


    public class GoodsTaskModel
    {
        public int id { get; set; }
    }
}
