using System;
using System.Collections.Generic;
using System.Text;

namespace demo.HttpClient.Attributes.Parameter
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class HttpIgnoreAttribute : Attribute
    {
    }
}
