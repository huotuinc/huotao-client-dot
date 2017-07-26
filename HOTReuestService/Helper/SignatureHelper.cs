using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HOTReuestService.Helper
{
    /// <summary>
    /// 数据通讯签名管理人
    /// </summary>
    public class SignatureHelper
    {
        private SignatureHelper()
        { }

        #region 验证签名
        /// <summary>
        /// 获取返回时的签名验证结果（用xxx=xxx&aaa=bbb连接，salt加在尾部，32位md5）
        /// </summary>
        /// <param name="inputPara"></param>
        /// <param name="sign"></param>
        /// <param name="salt"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static bool VerifySign(SortedDictionary<string, string> inputPara, string sign, string salt, BuildSettingModel setting)
        {
            if (setting == null)
            {
                setting = new BuildSettingModel()
                {
                    JoinFormat = PreSignStrJoinFormatOptions.UrlParameter,
                    EcryptType = EncryptTypeOptions.MD5_32,
                    SaltPosition = SaltAppendPositionOptions.Suffix
                };
            }

            //获取待签名字符串
            string preSignStr = GetPreSignStr(inputPara, setting, salt);

            string localSign = GetSign(preSignStr, setting);
            if (localSign.Equals(sign, StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取返回时的签名验证结果（用xxx=xxx&aaa=bbb连接，salt加在尾部，32位md5）
        /// </summary>
        /// <param name="inputPara">通知返回参数数组</param>
        /// <param name="sign">对比的签名结果</param>
        /// <returns>签名验证结果</returns>
        public static bool VerifySign(SortedDictionary<string, string> inputPara, string sign, string salt)
        {
            return VerifySign(inputPara, sign, salt, null);
        }
        #endregion

        #region 生成签名
        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="inputPara">字典</param>
        /// <param name="secrect">秘钥</param>
        /// <param name="setting">生成的设置</param>
        /// <returns></returns>
        public static string BuildSign(SortedDictionary<string, string> inputPara, string secrect, BuildSettingModel setting)
        {
            if (setting == null)
            {
                setting = new BuildSettingModel()
                {
                    JoinFormat = PreSignStrJoinFormatOptions.UrlParameter,
                    EcryptType = EncryptTypeOptions.MD5_UTF8_32,
                    SaltPosition = SaltAppendPositionOptions.Suffix
                };
            }

            //获取待签名字符串
            string preSignStr = GetPreSignStr(inputPara, setting, secrect);
            //LogHelper.Log("加密的字符串->:" + preSignStr);
            //生成sign
            return GetSign(preSignStr, setting);
        }

        /// <summary>
        /// 生成签名（用xxx=xxx&amp;aaa=bbb连接，salt加在尾部，32位md5）
        /// </summary>
        /// <param name="inputPara"></param>
        /// <param name="secrect">Secrect</param>
        /// <returns></returns>
        public static string BuildSign(SortedDictionary<string, string> inputPara, string secrect)
        {
            return BuildSign(inputPara, secrect, null);
        }

        /// <summary>
        /// 生成带签名的参数串
        /// </summary>
        /// <param name="inputPara"></param>
        /// <param name="secrect">Secrect</param>
        /// <returns></returns>
        public static string BuildSignStr(Dictionary<string, string> inputPara, string secrect)
        {
            SortedDictionary<string, string> sortedInputPara = Convert(inputPara);
            BuildSettingModel setting = new BuildSettingModel()
            {
                JoinFormat = PreSignStrJoinFormatOptions.UrlParameter,
                EcryptType = EncryptTypeOptions.MD5_UTF8_32,
                SaltPosition = SaltAppendPositionOptions.Suffix
            };

            //获取待签名字符串
            string preSignStr = GetPreSignStr(sortedInputPara, setting, secrect);

            //生成sign
            return GetPreSignStr(sortedInputPara, setting) + "&sign=" + GetSign(preSignStr, setting);
        }


        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="inputPara">字典</param>
        /// <param name="secrect">秘钥</param>
        /// <param name="setting">生成的设置</param>
        /// <returns></returns>
        public static string BuildSign(Dictionary<string, string> inputPara, string secrect, BuildSettingModel setting)
        {
            SortedDictionary<string, string> sortedInputPara = Convert(inputPara);
            return BuildSign(sortedInputPara, secrect, setting);
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="coll"></param>
        /// <param name="secrect"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static string BuildSign(NameValueCollection coll, string secrect, BuildSettingModel setting)
        {
            SortedDictionary<string, string> inputPara = new SortedDictionary<string, string>();
            foreach (string s in coll.AllKeys)
            {
                if (!inputPara.ContainsKey(s))
                {
                    inputPara.Add(s, coll[s]);
                }
            }
            return BuildSign(inputPara, secrect, setting);
        }

        /// <summary>
        /// 生成签名（用xxx=xxx&amp;aaa=bbb连接，salt加在尾部，32位md5_utf8）
        /// </summary>
        /// <param name="inputPara"></param>
        /// <param name="secrect"></param>
        /// <returns></returns>
        public static string BuildSign(Dictionary<string, string> inputPara, string secrect)
        {
            SortedDictionary<string, string> sortedInputPara = Convert(inputPara);
            return BuildSign(sortedInputPara, secrect, null);
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="coll"></param>
        /// <param name="secrect"></param>
        /// <returns></returns>
        public static string BuildSign(NameValueCollection coll, string secrect)
        {
            SortedDictionary<string, string> inputPara = new SortedDictionary<string, string>();
            foreach (string s in coll.AllKeys)
            {
                if (!inputPara.ContainsKey(s))
                {
                    inputPara.Add(s, coll[s]);
                }
            }
            return BuildSign(inputPara, secrect);
        }
        #endregion

        #region 私有方法
        private static SortedDictionary<string, string> Convert(Dictionary<string, string> inputPara)
        {
            SortedDictionary<string, string> dicTemp = new SortedDictionary<string, string>();
            foreach (KeyValuePair<string, string> kp in inputPara)
            {
                dicTemp.Add(kp.Key, kp.Value);
            }
            return dicTemp;
        }

        private static string GetSign(string preSignStr, BuildSettingModel setting)
        {
            string sign = "";
            switch (setting.EcryptType)
            {
                case EncryptTypeOptions.MD5_16:
                    sign = EncryptHelper.MD5_8(preSignStr);
                    break;

                case EncryptTypeOptions.MD5_32:
                    sign = EncryptHelper.MD5(preSignStr);
                    break;

                case EncryptTypeOptions.MD5_UTF8_32:
                    sign = EncryptHelper.MD5_8(preSignStr);
                    break;

                default:
                    sign = EncryptHelper.MD5(preSignStr);
                    break;
            }
            return sign;
        }

        private static string GetPreSignStr(SortedDictionary<string, string> inputPara, BuildSettingModel setting, string salt)
        {
            //过滤空值、sign与sign_type参数
            Dictionary<string, string> sPara = FilterPara(inputPara);

            //根据连接方式设置
            string preSignStr = "";
            switch (setting.JoinFormat)
            {
                case PreSignStrJoinFormatOptions.None:
                    preSignStr = CreateSeamlessString(sPara);
                    break;

                case PreSignStrJoinFormatOptions.UrlParameter:
                    preSignStr = CreateLinkString(sPara);
                    break;

                default:
                    preSignStr = CreateLinkString(sPara);
                    break;
            }

            //秘钥位置
            switch (setting.SaltPosition)
            {
                case SaltAppendPositionOptions.Prefix:
                    preSignStr = salt + preSignStr;
                    break;

                case SaltAppendPositionOptions.Suffix:
                    preSignStr = preSignStr + salt;
                    break;
                case SaltAppendPositionOptions.ALL:
                    preSignStr = salt + preSignStr + salt;
                    break;
                default:
                    preSignStr = preSignStr + salt;
                    break;
            }
            return preSignStr;
        }


        private static string GetPreSignStr(SortedDictionary<string, string> inputPara, BuildSettingModel setting)
        {
            //过滤空值、sign与sign_type参数
            Dictionary<string, string> sPara = FilterPara(inputPara);

            //根据连接方式设置
            string preSignStr = "";
            switch (setting.JoinFormat)
            {
                case PreSignStrJoinFormatOptions.None:
                    preSignStr = CreateSeamlessString(sPara);
                    break;

                case PreSignStrJoinFormatOptions.UrlParameter:
                    preSignStr = CreateLinkString(sPara);
                    break;

                default:
                    preSignStr = CreateLinkString(sPara);
                    break;
            }
            return preSignStr;
        }

        /// <summary>
        /// 签名字符串
        /// </summary>
        /// <param name="prestr">需要签名的字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="_input_charset">编码格式</param>
        /// <returns>签名结果</returns>
        private static string Sign(string prestr, string key, string _input_charset)
        {
            StringBuilder sb = new StringBuilder(32);

            prestr = prestr + key;

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(prestr));
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }

            return sb.ToString();
        }

        /// <summary>
        /// 除去数组中的空值和签名参数并以字母a到z的顺序排序
        /// </summary>
        /// <param name="dicArrayPre">过滤前的参数组</param>
        /// <returns>过滤后的参数组</returns>
        private static Dictionary<string, string> FilterPara(SortedDictionary<string, string> dicArrayPre)
        {
            Dictionary<string, string> dicArray = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> temp in dicArrayPre)
            {
                if (temp.Key.ToLower() != "sign" && temp.Key.ToLower() != "sign_type" && temp.Value != "" && temp.Value != null)
                {
                    dicArray.Add(temp.Key, temp.Value);
                }
            }

            return dicArray;
        }

        /// <summary>
        /// 把数组所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串
        /// </summary>
        /// <param name="sArray">需要拼接的数组</param>
        /// <returns>拼接完成以后的字符串</returns>
        private static string CreateLinkString(Dictionary<string, string> dicArray)
        {
            StringBuilder prestr = new StringBuilder();
            foreach (KeyValuePair<string, string> temp in dicArray)
            {
                prestr.Append(temp.Key + "=" + temp.Value + "&");
            }

            //去掉最後一個&字符
            int nLen = prestr.Length;
            prestr.Remove(nLen - 1, 1);

            return prestr.ToString();
        }

        /// <summary>
        /// 把数组所有元素，按照“参数+参数值”的无间隔符的模式接成字符串
        /// </summary>
        /// <param name="dicArray">需要拼接的数组</param>
        /// <returns>拼接完成以后的字符串</returns>
        private static string CreateSeamlessString(Dictionary<string, string> dicArray)
        {
            StringBuilder prestr = new StringBuilder();
            foreach (KeyValuePair<string, string> temp in dicArray)
            {
                prestr.Append(temp.Key + temp.Value);
            }
            return prestr.ToString();
        }
        #endregion

        #region 子类
        /// <summary>
        /// 生成条件选项
        /// </summary>
        public class BuildSettingModel
        {
            public PreSignStrJoinFormatOptions JoinFormat { get; set; }
            public SaltAppendPositionOptions SaltPosition { get; set; }
            public EncryptTypeOptions EcryptType { get; set; }
        }

        /// <summary>
        /// presign字符串连接方式
        /// </summary>
        public enum PreSignStrJoinFormatOptions
        {
            /// <summary>
            /// 例：orderid2015amount30
            /// </summary>
            None = 0,
            /// <summary>
            /// 例：orderid=2015&amount=30
            /// </summary>
            UrlParameter = 1
        }

        /// <summary>
        /// key加的位置
        /// </summary>
        public enum SaltAppendPositionOptions
        {
            /// <summary>
            /// 前缀
            /// </summary>
            Prefix = 0,
            /// <summary>
            /// 后缀
            /// </summary>
            Suffix = 1,
            /// <summary>
            /// 前后都加
            /// </summary>
            ALL = 2
        }

        /// <summary>
        /// 加密方式
        /// </summary>
        public enum EncryptTypeOptions
        {
            MD5_16 = 0,
            MD5_32 = 1,
            /// <summary>
            /// JAVA交互必须用这个
            /// </summary>
            MD5_UTF8_32 = 2
        }
        #endregion
    }
}
