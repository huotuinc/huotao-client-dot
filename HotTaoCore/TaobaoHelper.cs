/*
 * 版权所有:杭州火图科技有限公司
 * 地址:浙江省杭州市滨江区西兴街道阡陌路智慧E谷B幢4楼在地图中查看
 * (c) Copyright Hangzhou Hot Technology Co., Ltd.
 * Floor 4,Block B,Wisdom E Valley,Qianmo Road,Binjiang District
 * 2013-2017. All rights reserved.
 * author guomw
**/


using HOTReuestService;
using HotTaoCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace HotTaoCore
{
    public static class TaobaoHelper
    {
        private static Dictionary<string, Tuple<string, string>> tokenDict = new Dictionary<string, Tuple<string, string>>();


        /// <summary>
        /// 获取高佣活动和营销计划的淘口令
        /// </summary>
        /// <param name="goodsUrl"></param>
        /// <param name="goodsId"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static Tuple<string, string> GetGaoYongToken(string goodsUrl, string goodsId, string pid, string tbToken, CookieCollection cookies, out bool isLogin)
        {

            Tuple<string, string> resultTuple = null;
            //PID  mm_aaaa_bbbb_cccc
            //aaaa:memberid
            //bbbb:siteid
            //ccc:adzoneid
            isLogin = true;
            string dictKey = string.Format("{0}_{1}", pid, goodsId);
            //判断同商品相同的推广位，是否已经申请过淘口令
            if (tokenDict.ContainsKey(dictKey))
            {
                string _token = string.Empty;
                tokenDict.TryGetValue(dictKey, out resultTuple);
                return resultTuple;
            }
            var pids = pid.Replace("mm_", "").Split('_');

            if (pids.Length != 3) return resultTuple;

            string adzoneid = pids[2];
            string siteid = pids[1];
            string searchUrl = string.Format("http://pub.alimama.com/items/search.json?q={0}&_t={1}&auctionTag=&perPageSize=40&shopTag=&t={1}&_tb_token_={2}&pvid=", HttpUtility.UrlEncode(goodsUrl), getClientMsgId(), tbToken);
            CookieContainer cookiesContainer = new CookieContainer();
            cookiesContainer.Add(cookies);
            string content = HttpRequestService.HttpGet(searchUrl, cookiesContainer);
            decimal tkRate = 0;
            decimal eventRate = 0;
            bool tkMktStatus = false;
            bool resultOk = false;
            if (!string.IsNullOrEmpty(content))
            {
                try
                {
                    TaobaoSearchResultModel searchResult = JsonConvert.DeserializeObject<TaobaoSearchResultModel>(content);
                    if (searchResult != null && searchResult.ok && searchResult.data.pageList != null)
                    {
                        //通用计划
                        tkRate = searchResult.data.pageList[0].tkRate;

                        if (!string.IsNullOrEmpty(searchResult.data.pageList[0].eventRate))
                            eventRate = Convert.ToDecimal(searchResult.data.pageList[0].eventRate);

                        if (!string.IsNullOrEmpty(searchResult.data.pageList[0].tkMktStatus))
                            tkMktStatus = Convert.ToInt32(searchResult.data.pageList[0].tkMktStatus) == 1;
                        resultOk = true;
                    }
                }
                catch (Exception)
                {

                }
            }
            if (resultOk)
            {
                //判断是否是营销计划
                if (tkMktStatus && tkRate > eventRate)
                {
                    //开始申请营销计划佣金
                    string url = string.Format("http://pub.alimama.com/common/code/getAuctionCode.json?auctionid={0}&adzoneid={1}&siteid={2}&scenes=1&t={3}&_tb_token_={4}&pvid=", goodsId, adzoneid, siteid, getClientMsgId(), tbToken);
                    resultTuple = GetGaoyong(url, cookies);
                    if (resultTuple != null)
                    {
                        tokenDict[dictKey] = resultTuple;
                        return resultTuple;
                    }
                }
                else //判断是否有高佣金
                {
                    //获取更多定向计划数据
                    string url = string.Format("http://pub.alimama.com/pubauc/getCommonCampaignByItemId.json?itemId={0}&t={1}&_tb_token_={2}&pvid=", goodsId, getClientMsgId(), tbToken);
                    cookiesContainer = null;
                    cookiesContainer = new CookieContainer();
                    cookiesContainer.Add(cookies);
                    content = HttpRequestService.HttpGet(url, cookiesContainer);
                    if (content.Contains("html"))
                    {
                        isLogin = false;
                        resultTuple = new Tuple<string, string>("", "");
                        return resultTuple;
                    }
                    else
                    {
                        try
                        {
                            TaobaoCommonCampaignItemsModel items = JsonConvert.DeserializeObject<TaobaoCommonCampaignItemsModel>(content);
                            if (items != null && items.ok && items.data != null && items.data.Count > 0)
                            {
                                //过滤人工审核的佣金计划
                                var data = items.data.FindAll(r => r.manualAudit == 0);
                                var listData = data.OrderByDescending(r => r.commissionRate).ToList();
                                TaobaoCommonItem item = listData[0];
                                //如果定向佣金大于通用和高佣活动的佣金
                                if (tkRate < item.commissionRate && eventRate < item.commissionRate)
                                {
                                    tkRate = 0;
                                    eventRate = 0;
                                }
                            }
                        }
                        catch (Exception) { }
                        //如果高佣活动佣金大于通用佣金
                        if (eventRate > tkRate)
                        {
                            //开始申请高佣活动
                            url = string.Format("http://pub.alimama.com/common/code/getAuctionCode.json?auctionid={0}&adzoneid={1}&siteid={2}&scenes=3&channel=tk_qqhd&t={3}&_tb_token_={4}&pvid=", goodsId, adzoneid, siteid, getClientMsgId(), tbToken);
                            resultTuple = GetGaoyong(url, cookies);
                            if (resultTuple != null)
                            {
                                tokenDict[dictKey] = resultTuple;
                                return resultTuple;
                            }
                        }
                    }
                }
            }
            isLogin = false;
            resultTuple = new Tuple<string, string>("", "");
            return resultTuple;
        }
        /// <summary>
        /// 申请高佣活动/营销计划
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static Tuple<string, string> GetGaoyong(string url, CookieCollection cookies)
        {
            Tuple<string, string> result = null;
            CookieContainer cookiesContainer = new CookieContainer();
            cookiesContainer.Add(cookies);
            string content = HttpRequestService.HttpGet(url, cookiesContainer);
            AuctionCodeModel searchResult = JsonConvert.DeserializeObject<AuctionCodeModel>(content);
            if (searchResult != null && searchResult.ok && searchResult.data != null)
            {
                string token = string.IsNullOrEmpty(searchResult.data.couponLinkTaoToken) ? searchResult.data.taoToken : searchResult.data.couponLinkTaoToken;
                string link = string.IsNullOrEmpty(searchResult.data.couponShortLinkUrl) ? searchResult.data.shortLinkUrl : searchResult.data.couponShortLinkUrl;
                result = new Tuple<string, string>(token, link);
            }
            return result;
        }

        /// <summary>
        /// 获取随机时间戳
        /// </summary>
        /// <returns>System.Int64.</returns>
        public static double getClientMsgId()
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (DateTime.Now - startTime).TotalMilliseconds;
        }

    }
}
