using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CSCBlogWebApi_2_0.Infrastructure.Core
{
    public class Secret
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="strPwd">原字符串</param>
        /// <returns>加密后字符串</returns>
        public static string GetMD5(string strPwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bPwd = Encoding.Default.GetBytes(strPwd);    //将输入的密码转换成字节数组
            byte[] bMD5 = md5.ComputeHash(bPwd);        //计算指定字节数组的哈希值
            md5.Clear();    //释放加密服务提供类的所有资源
            StringBuilder sbMD5Pwd = new StringBuilder();
            for (int i = 0; i < bMD5.Length; i++)
            {
                sbMD5Pwd.Append(bMD5[i].ToString());
            }
            return sbMD5Pwd.ToString();
        }

        /// <summary>
        /// use sha1 to encrypt string
        /// </summary>
        public static string SHA1_Encrypt(string Source_String)
        {
            byte[] StrRes = Encoding.Default.GetBytes(Source_String);
            HashAlgorithm iSHA = new SHA1CryptoServiceProvider();
            StrRes = iSHA.ComputeHash(StrRes);
            StringBuilder EnText = new StringBuilder();
            foreach (byte iByte in StrRes)
            {
                EnText.AppendFormat("{0:x2}", iByte);
            }
            return EnText.ToString();
        }
        
    }
}
