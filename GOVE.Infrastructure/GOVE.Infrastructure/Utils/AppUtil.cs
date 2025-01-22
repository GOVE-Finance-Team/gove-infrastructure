using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using GOVE.Models.Constants;
using System.Text;
using System.Threading.Tasks;

namespace Gove.Infrastructure.Utils;

public static class AppUtil
{
    public static string GetCurrentMethodName([CallerMemberName] string methodName = "") => methodName;
    public static string DecryptString(string strText) => Decrypt(strText, Constants.Passphrase);
    private static string Decrypt(string strText, string sDecrKey)
    {
        byte[] byKey;
        byte[] IV = { 65, 6, 12, 34, 28, 232, 34, 158, 185, 192, 51, 74, 236, 28, 55, 9 };
        byte[] inputByteArray = new byte[strText.Length];
        try
        {
            byKey = System.Text.Encoding.UTF8.GetBytes(sDecrKey.Trim());
            var des = new TripleDESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(strText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.Unicode;

            return encoding.GetString(ms.ToArray());
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
