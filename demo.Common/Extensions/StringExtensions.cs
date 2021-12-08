using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace demo.Common.Extensions
{
    public static class StringExtensions
    {


        public static string ToMd5(this string content,Encoding encoding=null) {
            encoding = encoding ?? Encoding.UTF8;
            using (var md5 = MD5.Create()) {
                var bytes = md5.ComputeHash(encoding.GetBytes(content));
                return string.Join("",bytes.Select(x=>x.ToString("x2")));
            }
        }
        public static bool IsNullOrWhiteSpace(this string content)
        {
            return string.IsNullOrWhiteSpace(content);
        }
        public static bool HasValue(this string content)
        {
            return !string.IsNullOrWhiteSpace(content);
        }
        public static bool IsNullOrEmpty(this string content)
        {
            return string.IsNullOrEmpty(content);
        }
        public static string ToCamel(this string content) {
            var match = Regex.Match(content, @"_(\w*)*");
            while (match.Success)
            {
                var item = match.Value;
                while (item.IndexOf('_') >= 0)
                {
                    string newUpper = item.Substring(item.IndexOf('_'), 2);
                    item = item.Replace(newUpper, newUpper.Trim('_').ToUpper());
                    content = content.Replace(newUpper, newUpper.Trim('_').ToUpper());
                }
                match = match.NextMatch();
            }
            return content[0].ToString().ToLower() + content.Substring(1);
        }
    }
}
