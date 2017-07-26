using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HOTReuestService.Helper
{
    /// <summary>
    /// 加密帮助类
    /// </summary>
    public class EncryptHelper
    {
        /// <summary>
        /// 
        /// </summary>
        private EncryptHelper() { }
        /// <summary>
        /// 
        /// </summary>
        public static string ENCRYPT_KEY = "chinaswt";

        /// <summary>
        /// 内部签名密钥
        /// </summary>
        public const string AppSecret = "99d0da1165a8d240b29af3f418b8d105";

        #region MD5加密
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(str);
            byte[] result = md5.ComputeHash(data);
            String ret = "";
            for (int i = 0; i < result.Length; i++)
                ret += result[i].ToString("x").PadLeft(2, '0');
            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] MD5Digest(byte[] bytes)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            return md5.ComputeHash(bytes);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5_16(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(str)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string md5DigestAsHex(byte[] bytes)
        {
            string ret = "";
            byte[] result = MD5Digest(bytes);
            for (int i = 0; i < result.Length; i++)//逐字节变为16进制字符，以隔开
            {
                ret += result[i].ToString("x").PadLeft(2, '0');
            }
            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5_8(string str)
        {
            byte[] b = Encoding.UTF8.GetBytes(str);
            b = new MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x").PadLeft(2, '0');

            return ret;
        }
        #endregion

        #region 加密==解密
        /// <summary>
        /// 加密算法
        /// </summary>
        /// <param name="pwdEncrypt">要加密的字符串</param>
        /// <param name="key">密钥  必须8位</param>
        /// <returns></returns>
        public static string Encrypt(string pwdEncrypt, string key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(pwdEncrypt);
            des.Key = ASCIIEncoding.ASCII.GetBytes(key);
            des.IV = ASCIIEncoding.ASCII.GetBytes(key);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder encryptPwd = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                encryptPwd.AppendFormat("{0:X2}", b);
            }
            return encryptPwd.ToString();
        }
        /// <summary>
        /// 解密算法
        /// </summary>
        /// <param name="pwdDecrypt">要解密的字符串</param>
        /// <param name="key">密钥 必须8位</param>
        /// <returns></returns>
        public static string Decrypt(string pwdDecrypt, string key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = new byte[pwdDecrypt.Length / 2];
            for (int x = 0; x < pwdDecrypt.Length / 2; x++)
            {
                try
                {
                    int i = (Convert.ToInt32(pwdDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }
                catch
                {
                    return null;
                }
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(key);
            des.IV = ASCIIEncoding.ASCII.GetBytes(key);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
        #endregion

        #region DES key=n 加密  解密
        /// <summary>
        /// 加密算法 ,密钥key，长度不限
        /// </summary>
        /// <param name="pwdEncrypt"></param>
        /// <param name="key">密钥key，长度不限</param>
        /// <returns></returns>
        public static string Encrypt32(string pwdEncrypt, string key)
        {
            byte[] bytes = ASCIIEncoding.ASCII.GetBytes(key);
            byte[] bytesKey = new byte[8];
            for (int i = 0; i < bytes.Length && i < bytesKey.Length; i++)
            {
                bytesKey[i] = bytes[i];
            }
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Mode = CipherMode.ECB;
            des.Key = bytesKey;
            des.IV = bytesKey;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            byte[] inputByteArray = Encoding.Default.GetBytes(pwdEncrypt);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder encryptPwd = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                encryptPwd.AppendFormat("{0:X2}", b);
            }
            return encryptPwd.ToString();
        }
        /// <summary>
        /// 解密算法
        /// </summary>
        /// <param name="pwdDecrypt">要解密的字符串</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Decrypt32(string pwdDecrypt, string key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = new byte[pwdDecrypt.Length / 2];
            for (int x = 0; x < pwdDecrypt.Length / 2; x++)
            {
                try
                {
                    int i = (Convert.ToInt32(pwdDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }
                catch
                {
                    return null;
                }
            }
            byte[] bytes = ASCIIEncoding.ASCII.GetBytes(key);
            byte[] bytesKey = new byte[8];
            for (int i = 0; i < bytes.Length && i < bytesKey.Length; i++)
            {
                bytesKey[i] = bytes[i];
            }
            des.Mode = CipherMode.ECB;
            des.Key = bytesKey;
            des.IV = bytesKey;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
        #endregion

        #region RSA解密
        /// <summary>
        /// RSA加密算法产生私钥和公钥
        /// </summary>
        /// <param name="xmlKeys">XML格式私钥</param>
        /// <param name="xmlPublicKey">XML格式公钥</param>
        public static void RSAKey(out string xmlKeys, out string xmlPublicKey)
        {
            try
            {
                System.Security.Cryptography.RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                //私钥
                xmlKeys = rsa.ToXmlString(true);
                //公钥
                xmlPublicKey = rsa.ToXmlString(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="publickey"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RSAEncrypt(string publickey, string content)
        {
            publickey = @"<RSAKeyValue><Modulus>5m9m14XH3oqLJ8bNGw9e4rGpXpcktv9MSkHSVFVMjHbfv+SJ5v0ubqQxa5YjLN4vc49z7SVju8s0X4gZ6AzZTn06jzWOgyPRV54Q4I0DCYadWW4Ze3e+BOtwgVU1Og3qHKn8vygoj40J6U85Z/PTJu3hN1m75Zr195ju7g9v4Hk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(publickey);
            cipherbytes = rsa.Encrypt(Encoding.UTF8.GetBytes(content), false);
            return Convert.ToBase64String(cipherbytes);
        }


        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="privatekey"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RSADecrypt(string privatekey, string content)
        {
            //privatekey = @"<RSAKeyValue><Modulus>5m9m14XH3oqLJ8bNGw9e4rGpXpcktv9MSkHSVFVMjHbfv+SJ5v0ubqQxa5YjLN4vc49z7SVju8s0X4gZ6AzZTn06jzWOgyPRV54Q4I0DCYadWW4Ze3e+BOtwgVU1Og3qHKn8vygoj40J6U85Z/PTJu3hN1m75Zr195ju7g9v4Hk=</Modulus><Exponent>AQAB</Exponent><P>/hf2dnK7rNfl3lbqghWcpFdu778hUpIEBixCDL5WiBtpkZdpSw90aERmHJYaW2RGvGRi6zSftLh00KHsPcNUMw==</P><Q>6Cn/jOLrPapDTEp1Fkq+uz++1Do0eeX7HYqi9rY29CqShzCeI7LEYOoSwYuAJ3xA/DuCdQENPSoJ9KFbO4Wsow==</Q><DP>ga1rHIJro8e/yhxjrKYo/nqc5ICQGhrpMNlPkD9n3CjZVPOISkWF7FzUHEzDANeJfkZhcZa21z24aG3rKo5Qnw==</DP><DQ>MNGsCB8rYlMsRZ2ek2pyQwO7h/sZT8y5ilO9wu08Dwnot/7UMiOEQfDWstY3w5XQQHnvC9WFyCfP4h4QBissyw==</DQ><InverseQ>EG02S7SADhH1EVT9DD0Z62Y0uY7gIYvxX/uq+IzKSCwB8M2G7Qv9xgZQaQlLpCaeKbux3Y59hHM+KpamGL19Kg==</InverseQ><D>vmaYHEbPAgOJvaEXQl+t8DQKFT1fudEysTy31LTyXjGu6XiltXXHUuZaa2IPyHgBz0Nd7znwsW/S44iql0Fen1kzKioEL3svANui63O3o5xdDeExVM6zOf1wUUh/oldovPweChyoAdMtUzgvCbJk1sYDJf++Nr0FeNW1RB1XG30=</D></RSAKeyValue>";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(privatekey);
            cipherbytes = rsa.Decrypt(Convert.FromBase64String(content), false);
            return Encoding.UTF8.GetString(cipherbytes);
        }

        #endregion

        /// <summary>
        /// SHA1签名
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string SHA1_Hash(string content)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_sha1_in = UTF8Encoding.Default.GetBytes(content);
            byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
            string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
            str_sha1_out = str_sha1_out.Replace("-", "");
            return str_sha1_out;
        }

    }
}
