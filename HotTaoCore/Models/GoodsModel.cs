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

        public int userid { get; set; }

        public long rowIndex { get; set; }

        /// <summary>
        /// 商品编号(自增)
        /// </summary>
        public long id { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public string goodsId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string goodsName { get; set; }

        /// <summary>
        /// 本地图片路径
        /// </summary>
        /// <value>The goodslocat img path.</value>
        public string goodslocatImgPath { get; set; }

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


        public string couponId { get; set; }

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

        /// <summary>
        /// 商品简介
        /// </summary>
        /// <value>The goods intro.</value>
        public string goodsIntro { get; set; }

    }


    public class GoodsTaskModel
    {
        public int id { get; set; }
    }




    public class GoodsSelectedModel
    {
        public string goodsId { get; set; }


        /// <summary>
        /// 优惠券地址
        /// </summary>
        public string couponUrl { get; set; }

        /// <summary>
        /// 优惠券标题
        /// </summary>
        public string couponName { get; set; }


        public string updateTime { get; set; }

        public string couponId { get; set; }

        public string goodsDetailUrl { get; set; }


        public string goodsIntro { get; set; }

        public decimal goodsPrice { get; set; }

        public string goodsImageUrl { get; set; }

        public int goodsSalesAmount { get; set; }

        /// <summary>
        /// 商品平台
        /// </summary>
        /// <value>The goods supplier.</value>
        public string goodsPlatform { get; set; }

        public decimal couponPrice { get; set; }


        public decimal goodsComsRate { get; set; }

        public string endTime { get; set; }

        public string goodsName { get; set; }


    }



    /// <summary>
    /// 商品采集结果
    /// </summary>
    public class GoodsCollertModel
    {
        /// <summary>
        /// 是否完成
        /// </summary>
        public bool finish { get; set; }


        public List<GoodsCollertUrlsModel> urls { get; set; }
    }


    public class GoodsCollertUrlsModel
    {

        /// <summary>
        /// 商品地址
        /// </summary>
        public string goodsUrl { get; set; }

        /// <summary>
        /// 优惠券地址
        /// </summary>
        public string couponUrl { get; set; }

        /// <summary>
        /// 商品标题
        /// </summary>
        public string goodsName { get; set; }

        /// <summary>
        /// 券后价
        /// </summary>
        public decimal couponAfterPrice { get; set; }
    }



    public class PlanModel
    {
        /// <summary>
        /// 计划id
        /// </summary>
        public string planId;

        /// <summary>
        /// 计划佣金率
        /// </summary>
        public decimal commission;

        /// <summary>
        /// 佣金率定向计划文本
        /// </summary>
        public string goodsPlanText;

        /// <summary>
        /// 申请定向计划URL
        /// </summary>
        public string applyPlanUrl;

        /// <summary>
        /// 计划类型 "1"-通用，"2"-定向
        /// </summary>
        public string campaignType;

        /// <summary>
        /// 店铺id
        /// </summary>
        public string shopKeeperId;
    }

}
