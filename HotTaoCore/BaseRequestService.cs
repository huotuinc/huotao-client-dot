/*
 * 版权所有:杭州火图科技有限公司
 * 地址:浙江省杭州市滨江区西兴街道阡陌路智慧E谷B幢4楼在地图中查看
 * (c) Copyright Hangzhou Hot Technology Co., Ltd.
 * Floor 4,Block B,Wisdom E Valley,Qianmo Road,Binjiang District
 * 2013-2017. All rights reserved.
 * author guomw
**/


using HotCoreUtils.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace HotTaoCore
{


    public class ResultModel
    {
        public int resultCode { get; set; }

        public string resultMsg { get; set; }

        public object data { get; set; }
    }

    /// <summary>
    /// 网络请求
    /// </summary>
    public class BaseRequestService
    {
        /// <summary>
        /// 向服务器发送post请求 返回服务器数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reqName">接口名 /xxx/init</param>
        /// <param name="formFields">The form fields.</param>
        /// <param name="OnError">The on error.</param>
        /// <returns>T.</returns>
        public static T Post<T>(string reqName, Dictionary<string, string> formFields, Action<ResultModel> OnError = null)
        {
            try
            {
                if (formFields == null)
                {
                    formFields = new Dictionary<string, string>();

                }
                formFields["timestamp"] = StringHelper.GetTimeStamp();
                string sign = SignatureHelper.BuildSign(formFields, ApiConst.SecretKey);
                //获取签名
                formFields["signature"] = sign;
                string rawData = PrepareRequestBody(formFields);
                var request = (HttpWebRequest)WebRequest.Create(ApiConst.Url + reqName);
                request.Method = "POST";

                request.ContentType = "application/x-www-form-urlencoded";

                byte[] content = Encoding.UTF8.GetBytes(rawData);
                request.ContentLength = content.Length;
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(content, 0, content.Length);
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream response_stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(response_stream, Encoding.UTF8);
                string respone = sr.ReadToEnd().Trim();
                if (!string.IsNullOrEmpty(respone))
                {
                    ResultModel result = JsonConvert.DeserializeObject<ResultModel>(respone);

                    if (result != null && result.resultCode == 200)
                    {
                        return Resolve<T>(result.data);
                    }
                    else
                        OnError?.Invoke(result);
                }
                return default(T);
            }
            catch (Exception ex)
            {
                ResultModel result = new ResultModel();
                result.resultMsg = "连接服务器失败";
                result.resultCode = 500;
                OnError?.Invoke(result);
                return default(T);
            }
        }


        /// <summary>
        /// 数据解析
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <returns>T.</returns>
        internal static T Resolve<T>(object data)
        {
            if (!string.IsNullOrEmpty(data.ToString()))
            {
                return JsonConvert.DeserializeObject<T>(data.ToString());
            }
            return default(T);
        }
        /// <summary>
        /// 请求参数拼装
        /// </summary>
        /// <param name="formFields">The form fields.</param>
        /// <returns>System.String.</returns>
        internal static string PrepareRequestBody(Dictionary<string, string> formFields)
        {
            var requestBody = new StringBuilder();

            foreach (var item in formFields)
            {
                if (requestBody.Length > 0)
                {
                    requestBody.Append("&");
                }

                requestBody.Append(string.Format("{0}={1}", item.Key, item.Value));
            }

            return requestBody.ToString();
        }
    }
}
