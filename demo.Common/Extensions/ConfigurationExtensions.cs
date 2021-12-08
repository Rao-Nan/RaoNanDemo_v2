using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace demo.Common.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void Bind(this IConfigurationSection section,object obj) {
            var properties = obj.GetType().GetProperties().Where(x=>x.CanWrite);
            foreach (var property in properties)
            {
                var val=section[property.Name];
                if (!val.IsNullOrWhiteSpace()) {
                    if (property.PropertyType == typeof(string))
                    {
                        property.SetValue(obj, val);
                    }
                    else {
                        var type = property.PropertyType;
                        property.SetValue(obj, Convert.ChangeType(val, type));
                    }
                }
            }
        }
    }
}
