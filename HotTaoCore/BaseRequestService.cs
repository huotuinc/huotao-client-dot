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
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace HotTaoCore
{


    //public class ResultModel: ResultModel
    //{        
    //}

    /// <summary>
    /// 网络请求
    /// </summary>
    public class BaseRequestService : HttpRequestService
    {
        static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        public static VersionModel CheckUpdate()
        {
            try
            {
                var request = CreateRequest(ApiConst.CheckUpdateUrl);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream response_stream = response.GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(response_stream, Encoding.UTF8))
                        {
                            string respone = sr.ReadToEnd().Trim();
                            if (!string.IsNullOrEmpty(respone))
                            {
                                return Resolve<VersionModel>(respone);
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("CheckUpdate: " + ex.ToString());
                return null;
            }
        }


        /// <summary>
        /// 获取采集js代码
        /// </summary>
        /// <returns></returns>
        public static string GetInjectionJsCode()
        {
            try
            {
                var request = CreateRequest(ApiDefineConst.JsCode);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream response_stream = response.GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(response_stream, Encoding.UTF8))
                        {
                            string respone = sr.ReadToEnd().Trim();
                            if (!string.IsNullOrEmpty(respone))
                            {
                                var result = Resolve<InjectionJsModel>(respone);
                                if (result != null)
                                    return result.code;
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("CheckUpdate: " + ex.ToString());
                return null;
            }
        }





    }
}
