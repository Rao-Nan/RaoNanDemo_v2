using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace demo.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object obj) {
            return JsonConvert.SerializeObject(obj);
        }
        public static T ToObject<T>(this string json)
        {
            if (json.IsNullOrWhiteSpace())
                return default(T);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
