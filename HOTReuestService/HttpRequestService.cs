/*
 * 版权所有:杭州火图科技有限公司
 * 地址:浙江省杭州市滨江区西兴街道阡陌路智慧E谷B幢4楼在地图中查看
 * (c) Copyright Hangzhou Hot Technology Co., Ltd.
 * Floor 4,Block B,Wisdom E Valley,Qianmo Road,Binjiang District
 * 2013-2017. All rights reserved.
 * author guomw
**/

using HOTReuestService.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace HOTReuestService
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
    public class HttpRequestService
    {
        static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 得到时间戳unix
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            return ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();
        }

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
                formFields["timestamp"] = GetTimeStamp();
                //获取签名
                formFields["signature"] = SignatureHelper.BuildSign(formFields, ApiDefineConst.SecretKey);
                byte[] request_body = Encoding.UTF8.GetBytes(PrepareRequestBody(formFields));
                var request = CreateRequest(ApiDefineConst.Url + reqName, request_body);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return GetResponse<T>(response, OnError);
                }
            }
            catch (Exception ex)
            {
                log.Error(reqName + " " + ex.ToString());
                ResultModel result = new ResultModel();
                result.resultMsg = "连接服务器失败";
                result.resultCode = 500;
                OnError?.Invoke(result);
                return default(T);
            }
        }

        /// <summary>
        /// HTTPs the post.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="cookies">The cookies.</param>
        /// <returns>System.String.</returns>
        public static string HttpGet(string url, CookieContainer cookies)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                request.Method = "GET";
                request.UserAgent = "User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36";
                request.Accept = "*/*";
                request.CookieContainer = cookies;
                request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
                request.Headers.Add("Accept-Encoding", "gzip,deflate");
                request.Headers.Add("Accept-Language", "zh-Hans-CN,zh-Hans;q=0.5");
                request.Headers.Add(HttpRequestHeader.KeepAlive, "true");
                request.Host = "pub.alimama.com";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream response_stream = response.GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(response_stream, Encoding.UTF8))
                        {
                            return sr.ReadToEnd().Trim();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error(url + " " + ex.ToString());
            }
            return string.Empty;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="formFields"></param>
        /// <param name="cookies"></param>
        /// <returns></returns>
        public static string HttpPost(string url, Dictionary<string, string> formFields, CookieContainer cookies)
        {
            try
            {

                var request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                request.Method = "POST";
                request.UserAgent = "User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36";
                request.Accept = "*/*";
                request.Expect = string.Empty;
                request.CookieContainer = cookies;
                request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
                request.Headers.Add("Accept-Encoding", "gzip,deflate");
                request.Headers.Add("Accept-Language", "zh-Hans-CN,zh-Hans;q=0.5");
                request.Headers.Add(HttpRequestHeader.KeepAlive, "true");
                request.Host = "pub.alimama.com";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                byte[] request_body = Encoding.UTF8.GetBytes(PrepareRequestBody(formFields));
                request.ContentLength = request_body.Length;
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(request_body, 0, request_body.Length);
                }
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream response_stream = response.GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(response_stream, Encoding.UTF8))
                        {
                            return sr.ReadToEnd().Trim();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(url + " " + ex.ToString());
            }
            return string.Empty;
        }


        public static bool Post(string reqName, Dictionary<string, string> formFields, Action<ResultModel> OnError = null)
        {
            try
            {
                if (formFields == null)
                    formFields = new Dictionary<string, string>();
                formFields["timestamp"] = GetTimeStamp();
                //获取签名
                formFields["signature"] = SignatureHelper.BuildSign(formFields, ApiDefineConst.SecretKey);
                byte[] request_body = Encoding.UTF8.GetBytes(PrepareRequestBody(formFields));

                var request = CreateRequest(ApiDefineConst.Url + reqName, request_body);
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
                formFields["timestamp"] = GetTimeStamp();
                //获取签名
                formFields["signature"] = SignatureHelper.BuildSign(formFields, ApiDefineConst.SecretKey);
                byte[] request_body = Encoding.UTF8.GetBytes(PrepareRequestBody(formFields));

                var request = CreateRequest(ApiDefineConst.Url + reqName, request_body);
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


        /// <summary>
        /// 返回Data int
        /// </summary>
        /// <param name="reqName">Name of the req.</param>
        /// <param name="formFields">The form fields.</param>
        /// <param name="OnError">The on error.</param>
        /// <returns>System.String.</returns>
        public static int PostToInt32(string reqName, Dictionary<string, string> formFields, Action<ResultModel> OnError = null)
        {
            try
            {
                if (formFields == null)
                    formFields = new Dictionary<string, string>();
                formFields["timestamp"] = GetTimeStamp();
                //获取签名
                formFields["signature"] = SignatureHelper.BuildSign(formFields, ApiDefineConst.SecretKey);
                byte[] request_body = Encoding.UTF8.GetBytes(PrepareRequestBody(formFields));

                var request = CreateRequest(ApiDefineConst.Url + reqName, request_body);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return GetResponseToInt32(response, OnError);
                }
            }
            catch (Exception ex)
            {
                log.Error(reqName + " " + ex.ToString());
                ResultModel result = new ResultModel();
                result.resultMsg = "连接服务器失败";
                result.resultCode = 500;
                OnError?.Invoke(result);
                return 0;
            }
        }

        protected static HttpWebRequest CreateRequest(string url, byte[] request_body)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
            request.ContentLength = request_body.Length;
            request.KeepAlive = false;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(request_body, 0, request_body.Length);
            }
            return request;
        }

        protected static HttpWebRequest CreateRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Get";
            request.KeepAlive = false;
            request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
            return request;
        }

        protected static T GetResponse<T>(HttpWebResponse response, Action<ResultModel> OnError)
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
                            log.Info(response.ResponseUri.AbsoluteUri +"|"+ respone);
                            OnError?.Invoke(result);
                        }
                    }
                }
            }
            return default(T);
        }

        protected static bool GetResponse(HttpWebResponse response, Action<ResultModel> OnError)
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
                            if (result.data != null && !string.IsNullOrEmpty(result.data.ToString()))
                            {
                                bool success = false;
                                bool.TryParse(result.data.ToString(), out success);
                                return success;
                            }
                            return true;
                        }
                        else
                        {
                            log.Info(response.ResponseUri.AbsoluteUri + "|" + respone);
                            OnError?.Invoke(result);
                        }
                    }
                }
            }
            return false;
        }

        protected static string GetResponseToString(HttpWebResponse response, Action<ResultModel> OnError)
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
                            log.Info(response.ResponseUri.AbsoluteUri + "|" + respone);
                            OnError?.Invoke(result);
                        }
                    }
                }
            }
            return string.Empty;
        }


        protected static int GetResponseToInt32(HttpWebResponse response, Action<ResultModel> OnError)
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
                            if (!string.IsNullOrEmpty(result.data.ToString()))
                                return Convert.ToInt32(result.data.ToString());
                            return 0;
                        }
                        else
                        {
                            log.Info(response.ResponseUri.AbsoluteUri + "|" + respone);
                            OnError?.Invoke(result);
                        }
                    }
                }
            }
            return 0;
        }



        /// <summary>
        /// 获取网络图片数据
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] GetNetWorkImageData(string url)
        {
            try
            {
                url = url.IndexOf("http") < 0 ? "http:" + url : url;
                WebRequest request = WebRequest.Create(url);
                request.Method = "get";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream response_stream = response.GetResponseStream();
                int count = (int)response.ContentLength;
                int offset = 0;
                byte[] buf = new byte[count];
                while (count > 0)  //读取返回数据
                {
                    int n = response_stream.Read(buf, offset, count);
                    if (n == 0) break;
                    count -= n;
                    offset += n;
                }
                return buf;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }


        /// <summary>
        /// 数据解析
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <returns>T.</returns>
        protected internal static T Resolve<T>(object data)
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
        protected internal static string PrepareRequestBody(Dictionary<string, string> formFields)
        {
            var requestBody = new StringBuilder();

            foreach (var item in formFields)
            {
                if (requestBody.Length > 0)
                {
                    requestBody.Append("&");
                }

                requestBody.Append(string.Format("{0}={1}", item.Key, HttpUtility.UrlEncode(item.Value)));
            }

            return requestBody.ToString();
        }
    }
}
