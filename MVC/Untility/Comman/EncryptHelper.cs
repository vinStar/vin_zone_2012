using System;
using System.Text;
using System.Security.Cryptography;

namespace Common
{
    public abstract class EncryptHelper
    {

        #region MD5加密

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Md5Desrypt(object Text)
        {
            if (Text != null)
            {
                MD5 md5 = MD5.Create();
                byte[] pwdData = Encoding.Default.GetBytes(Text.ToString());
                byte[] md5data = md5.ComputeHash(pwdData);
                return BitConverter.ToString(md5data).Replace("-", "");
            }
            else
                return "";
        }

        #endregion

        #region DESEncrypt

        #region ========DES加密========

        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string DesEncrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(Text);
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        #endregion

        #region ========Des解密========
        /// <summary> 
        /// 解密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string DesDecrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = Text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }

        #endregion

        #endregion

        #region Base64加密

        /// <summary>
        /// 加密为64位编码格式
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Base64Encrypt(string Text)
        {
            try
            {
                byte[] chars = Encoding.Default.GetBytes(Text);
                return Convert.ToBase64String(chars);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 解密64位编码格式的信息
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Base64DeEncrypt(string Text)
        {
            try
            {
                return Encoding.Default.GetString(Convert.FromBase64String(Text));
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        #endregion
    }
}
