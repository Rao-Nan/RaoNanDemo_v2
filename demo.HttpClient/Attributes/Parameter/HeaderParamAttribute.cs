using RestSharp;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace demo.HttpClient.Attributes.Parameter
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class HeaderParamAttribute : Attribute, IParameterScopeAttribute
    {
        public HeaderParamAttribute()
        {

        }
        public HeaderParamAttribute(string name)
        {
            this.Name = name;
        }

        public ParameterScope Scope
        {
            get
            {
                return ParameterScope.Header;
            }
        }
        public string Name
        {
            get;
            set;
        }



        public void ProcessParameter(RestRequest requestBuilder, ParameterInfo parameterInfo, object parameterValue)
        {
            if ((this.Name ?? parameterInfo.Name).Equals("authorization"))
            {
                parameterValue = "Bearer " + parameterValue;
            }
            requestBuilder.AddHeader(this.Name ?? parameterInfo.Name, parameterValue?.ToString());
            
        }
    }
}
