using HotCoreUtils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
using static Top.Api.Request.WirelessShareTpwdCreateRequest;

namespace HotTaoCore
{
    public class HotTaoApiService
    {
        private const string url = "http://gw.api.taobao.com/router/rest";
        private const string appkey = "23614674";
        private const string appsecret = "30182c9b940e88d983c61aad2a991f7e";

        private static HotTaoApiService _instance = new HotTaoApiService();

        public static HotTaoApiService Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// 物料传播方式获取,输入一个原始的链接，转换得到指定的传播方式，如二维码，淘口令，短连接； 现阶段只支持短链接。
        /// </summary>
        /// <param name="sourceUrl">原始的链接</param>
        /// <returns></returns>
        public string taobao_tbk_spread_get(string sourceUrl)
        {
            try
            {
                ITopClient client = new DefaultTopClient(url, appkey, appsecret);
                TbkSpreadGetRequest req = new TbkSpreadGetRequest();

                List<TbkSpreadGetRequest.TbkSpreadRequestDomain> requests = new List<TbkSpreadGetRequest.TbkSpreadRequestDomain>();

                TbkSpreadGetRequest.TbkSpreadRequestDomain obj3 = new TbkSpreadGetRequest.TbkSpreadRequestDomain();
                requests.Add(obj3);
                obj3.Url = sourceUrl;
                req.Requests_ = requests;

                TbkSpreadGetResponse response = client.Execute(req);
                if (!response.IsError)
                {
                    return response.Results[0].Content;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(string.Format("taobao_tbk_spread_get:{0}，{1}", ex.Message, ex.StackTrace));
            }

            return "";
        }

        /// <summary>
        /// 生产淘口令
        /// </summary>
        /// <param name="logo"></param>
        /// <param name="goodsUrl"></param>
        /// <param name="goodsName"></param>
        /// <returns></returns>
        public string taobao_wireless_share_tpwd_create(string logo, string goodsUrl, string goodsName)
        {
            try
            {
                ITopClient client = new DefaultTopClient(url, appkey, appsecret);
                WirelessShareTpwdCreateRequest req = new WirelessShareTpwdCreateRequest();
                IsvTpwdInfoDomain obj1 = new IsvTpwdInfoDomain();
                obj1.Logo = logo;
                obj1.Text = goodsName;
                obj1.Url = goodsUrl;
                obj1.UserId = 24234234234L;//userid必须填写，我也不知道为什么，不传就报参数错误
                req.TpwdParam_ = obj1;
                WirelessShareTpwdCreateResponse response = client.Execute(req);
                if (!response.IsError)
                {
                    return response.Model;
                }
                LogHelper.Log(string.Format("taobao_wireless_share_tpwd_create:ErrCode:{0},ErrMsg:{1},SubErrCode:{2},SubErrMsg:{3},Body:{4}",
                    response.ErrCode, response.ErrMsg, response.SubErrCode, response.SubErrMsg, response.Body), LogHelperTag.ERROR);
            }
            catch (Exception ex)
            {
                LogHelper.Log(string.Format("taobao_wireless_share_tpwd_create:{0}，{1}", ex.Message, ex.StackTrace));
            }
            return "";
        }
    }
}
