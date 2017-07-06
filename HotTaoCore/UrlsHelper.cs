/*
 * 版权所有:杭州火图科技有限公司
 * 地址:浙江省杭州市滨江区西兴街道阡陌路智慧E谷B幢4楼在地图中查看
 * (c) Copyright Hangzhou Hot Technology Co., Ltd.
 * Floor 4,Block B,Wisdom E Valley,Qianmo Road,Binjiang District
 * 2013-2017. All rights reserved.
 * author guomw
**/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotTaoCore
{
    public class UrlsHelper
    {

        public string Url;
        public string Url2;

        /**
         * @param url 比如 https://uland.taobao.com/coupon/edetail?src=ht_hot&activityId=7d657b63d72c4fa4b8cd6a81ba29256b&itemId=524783861568&pid=mm_33648229_22310325_74082334
         * @return 检测url是否直接是一个二合一地址
         */
        public bool isDirectDiaUrl(string url)
        {
            if (url == null)
                return false;
            return url.Contains("activityId") && url.Contains("itemId");
        }

        private bool isDiaUrl(string url)
        {
            if (isDirectDiaUrl(url))
                return true;
            return url != null && url.Contains("huobanj");
        }

        /**
         * @return 是否支持二合一地址
         */
        public bool isSupportDia()
        {
            return isDiaUrl(Url)
                    || isDiaUrl(Url2);
        }

        /**
         * @return 是否只有一个地址
         */
        public bool isSingleUrlMode()
        {
            return !(!string.IsNullOrEmpty(Url) && !string.IsNullOrEmpty(Url2));
        }

        /// <summary>
        /// 判断是否是商品地址
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool isGoodsLink(string url)
        {
            Uri uri = new Uri(url);
            return uri.Host.Equals("item.taobao.com", StringComparison.CurrentCultureIgnoreCase)
                || uri.Host.Equals("detail.tmall.com", StringComparison.CurrentCultureIgnoreCase);
        }

        /**
         * @return 商品详情页链接
         */
        public string getGoodsUrl()
        {
            if (Url != null && string.IsNullOrEmpty(getCouponId(Url)))
                return Url;
            return Url2;
        }

        /// <summary>
        /// 获取优惠券ID
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string getCouponId(string url)
        {
            string activity_id = "";
            if (url.Contains("activityId") || url.Contains("activity_id"))
            {
                var arr = url.Split(new string[] { "[&?]" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var v in arr)
                {
                    if (v.Contains("activityId"))
                    {
                        activity_id = v.Replace("activityId", "");
                        break;
                    }
                    if (v.Contains("activity_id"))
                    {
                        activity_id = v.Replace("activity_id", "");
                        break;
                    }
                }
            }
            return activity_id;
        }

        public string getGoodsId(string url)
        {
            string goodsId = "";
            var arr = url.Split(new string[] { "[&?]" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var v in arr)
            {
                if (v.Contains("id"))
                {
                    goodsId = v.Replace("id", "");
                    break;
                }
            }
            return goodsId;
        }

    }
}
