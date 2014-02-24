using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class StringExtensions
    {
        public static string Hash(this string hashString)
        {
            return Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(hashString)));
        }

        public static string SafeSubstring(this string text, int start, int length, bool ellipses = false)
        {

            var returnValue =  text.Length <= start ? ""
                    : text.Length - start <= length ? text.Substring(start)
                    : text.Substring(start, length);

            if (returnValue.Length > (length - start)) returnValue += "...";

            return returnValue;
            
        }
    }
}
