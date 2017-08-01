using HOTReuestService.Helper;
using HotTaoCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Top.Api;
using Top.Api.Domain;
using Top.Api.Request;
using Top.Api.Response;
using static Top.Api.Request.WirelessShareTpwdCreateRequest;

namespace HotTaoCore
{
    public class HotTaoApiService
    {
        private const string url = "http://gw.api.taobao.com/router/rest";
        private const string appkey = "";
        private const string appsecret = "";

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
        public string taobao_tbk_spread_get(string sourceUrl, string _appkey, string _appsecret)
        {
            try
            {
                ITopClient client = new DefaultTopClient(url, string.IsNullOrEmpty(_appkey) ? appkey : _appkey, string.IsNullOrEmpty(_appsecret) ? appsecret : _appsecret);
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
        public string taobao_wireless_share_tpwd_create(string logo, string goodsUrl, string goodsName, string _appkey, string _appsecret)
        {
            try
            {
                ITopClient client = new DefaultTopClient(url, string.IsNullOrEmpty(_appkey) ? appkey : _appkey, string.IsNullOrEmpty(_appsecret) ? appsecret : _appsecret);
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


        /// <summary>
        /// 生成短链
        /// </summary>
        /// <param name="loginToken">The login token.</param>
        /// <param name="taoCode">淘口令</param>
        /// <param name="url">推广链</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="goodsImageUrl">商品图片.</param>
        /// <returns>System.String.</returns>
        public string buildShortUrl(string loginToken, string taoCode, string url, string goodsName, string goodsImageUrl)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["taoCode"] = taoCode;
            data["url"] = url;
            data["goodsName"] = goodsName;
            data["goodsImageUrl"] = goodsImageUrl;
            return BaseRequestService.PostToString(ApiConst.buildShortUrl, data);
        }

        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="version">The version.</param>
        /// <returns>VersionModel.</returns>
        public VersionModel CheckVersion(int v, string url)
        {
            var result = BaseRequestService.CheckUpdate(url);
            //服务器版本号，大于本地版本号,则更新
            if (result != null && result.version > v)
            {
                return result;
            }
            return null;
        }





        public GoodsSelectedModel GetGoodsInfo(string goodsId)
        {
            ITopClient client = new DefaultTopClient(url, appkey, appsecret);
            TbkItemInfoGetRequest req = new TbkItemInfoGetRequest();
            req.Fields = "num_iid,title,pict_url,small_images,reserve_price,zk_final_price,user_type,provcity,item_url";
            req.Platform = 1L;
            req.NumIids = goodsId;
            TbkItemInfoGetResponse rsp = client.Execute(req);
            if (!rsp.IsError)
            {
                List<NTbkItem> data = rsp.Results;
                if (data != null && data.Count() > 0)
                {
                    NTbkItem item = data[0];
                    GoodsSelectedModel model = new GoodsSelectedModel()
                    {
                        goodsId = item.NumIid.ToString(),
                        goodsName = item.Title,
                        goodsPrice = Convert.ToDecimal(item.ZkFinalPrice),
                        goodsDetailUrl = item.ItemUrl,
                        goodsImageUrl = item.PictUrl,
                        goodsSalesAmount = Convert.ToInt32(item.Volume),
                    };
                    return model;
                }
            }
            return null;
        }

    }
}
