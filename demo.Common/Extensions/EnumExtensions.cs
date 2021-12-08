using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace demo.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            var va = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as System.ComponentModel.DescriptionAttribute;

            return va == null ? value.ToString() : va.Description;
        }
    }
}
