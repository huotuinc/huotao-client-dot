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
using System.Net.Http;
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
        static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        private static readonly HttpClientHandler clientHandler = new HttpClientHandler();
        /// <summary>
        /// HTTP请求发送者
        /// </summary>
        private static readonly HttpClient client = new HttpClient(clientHandler);

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
                    formFields = new Dictionary<string, string>();
                formFields["timestamp"] = StringHelper.GetTimeStamp();
                //获取签名
                formFields["signature"] = SignatureHelper.BuildSign(formFields, ApiConst.SecretKey);
                byte[] request_body = Encoding.UTF8.GetBytes(PrepareRequestBody(formFields));
                var request = CreateRequest(ApiConst.Url + reqName, request_body);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return GetResponse<T>(response, OnError);
                }
            }
            catch (Exception ex)
            {
                log.Error(reqName +" "+ ex.ToString());
                ResultModel result = new ResultModel();
                result.resultMsg = "连接服务器失败";
                result.resultCode = 500;
                OnError?.Invoke(result);
                return default(T);
            }
        }

        public static bool Post(string reqName, Dictionary<string, string> formFields, Action<ResultModel> OnError = null)
        {
            try
            {
                if (formFields == null)
                    formFields = new Dictionary<string, string>();
                formFields["timestamp"] = StringHelper.GetTimeStamp();
                //获取签名
                formFields["signature"] = SignatureHelper.BuildSign(formFields, ApiConst.SecretKey);
                byte[] request_body = Encoding.UTF8.GetBytes(PrepareRequestBody(formFields));

                var request = CreateRequest(ApiConst.Url + reqName, request_body);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return GetResponse(response, OnError);
                }
            }
            catch (Exception ex)
            {
                log.Error(reqName + " " + ex.ToString());
                ResultModel result = new ResultModel();
                result.resultMsg = "连接服务器失败";
                result.resultCode = 500;
                OnError?.Invoke(result);
                return false;
            }
        }

        /// <summary>
        /// 返回Data string
        /// </summary>
        /// <param name="reqName">Name of the req.</param>
        /// <param name="formFields">The form fields.</param>
        /// <param name="OnError">The on error.</param>
        /// <returns>System.String.</returns>
        public static string PostToString(string reqName, Dictionary<string, string> formFields, Action<ResultModel> OnError = null)
        {
            try
            {
                if (formFields == null)
                    formFields = new Dictionary<string, string>();
                formFields["timestamp"] = StringHelper.GetTimeStamp();
                //获取签名
                formFields["signature"] = SignatureHelper.BuildSign(formFields, ApiConst.SecretKey);
                byte[] request_body = Encoding.UTF8.GetBytes(PrepareRequestBody(formFields));

                var request = CreateRequest(ApiConst.Url + reqName, request_body);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return GetResponseToString(response, OnError);
                }
            }
            catch (Exception ex)
            {
                log.Error(reqName + " " + ex.ToString());
                ResultModel result = new ResultModel();
                result.resultMsg = "连接服务器失败";
                result.resultCode = 500;
                OnError?.Invoke(result);
                return "";
            }
        }


        private static HttpWebRequest CreateRequest(string url, byte[] request_body)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
            request.ContentLength = request_body.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(request_body, 0, request_body.Length);
            }
            return request;
        }


        private static T GetResponse<T>(HttpWebResponse response, Action<ResultModel> OnError)
        {
            using (Stream response_stream = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(response_stream, Encoding.UTF8))
                {
                    string respone = sr.ReadToEnd().Trim();
                    if (!string.IsNullOrEmpty(respone))
                    {
                        ResultModel result = JsonConvert.DeserializeObject<ResultModel>(respone);
                        if (result != null && result.resultCode == 200)
                        {
                            if (result.data != null)
                                return Resolve<T>(result.data);
                        }
                        else
                        {
                            log.Debug(respone);
                            OnError?.Invoke(result);
                        }
                    }
                }
            }
            return default(T);
        }

        private static bool GetResponse(HttpWebResponse response, Action<ResultModel> OnError)
        {
            using (Stream response_stream = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(response_stream, Encoding.UTF8))
                {
                    string respone = sr.ReadToEnd().Trim();
                    if (!string.IsNullOrEmpty(respone))
                    {
                        ResultModel result = JsonConvert.DeserializeObject<ResultModel>(respone);
                        if (result != null && result.resultCode == 200)
                        {
                            return true;
                        }
                        else
                        {
                            log.Debug(respone);
                            OnError?.Invoke(result);
                        }
                    }
                }
            }
            return false;
        }

        private static string GetResponseToString(HttpWebResponse response, Action<ResultModel> OnError)
        {
            using (Stream response_stream = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(response_stream, Encoding.UTF8))
                {
                    string respone = sr.ReadToEnd().Trim();
                    if (!string.IsNullOrEmpty(respone))
                    {
                        ResultModel result = JsonConvert.DeserializeObject<ResultModel>(respone);
                        if (result != null && result.resultCode == 200)
                        {
                            return result.data.ToString();
                        }
                        else
                        {
                            log.Debug(respone);
                            OnError?.Invoke(result);
                        }
                    }
                }
            }
            return string.Empty;
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
