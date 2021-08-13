using RestSharp;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace demo.HttpClient.Attributes.Parameter
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class QueryStringAttribute : Attribute, IParameterScopeAttribute
    {
        public QueryStringAttribute()
        {

        }
        public QueryStringAttribute(string name)
        {
            this.Name = name;
        }

        public ParameterScope Scope
        {
            get
            {
                return ParameterScope.Query;
            }
        }
        public string Name
        {
            get;
            set;
        }

        public void ProcessParameter(RestRequest requestBuilder, ParameterInfo parameterInfo, object parameterValue)
        {
            requestBuilder.AddQueryParameter(parameterInfo.Name, parameterValue?.ToString());
        }

    }
}
