
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace demo.HttpClient.Attributes.Parameter
{

    public enum JTokenType
    {
        JObject, JArray
    }

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class JsonBodyAttribute : Attribute, IParameterScopeAttribute
    {
        public JsonBodyAttribute()
           : this(null)
        {

        }
        public JsonBodyAttribute(string name)
        {
            this.Name = name;
        }

        public ParameterScope Scope
        {
            get
            {
                return ParameterScope.Json;
            }
        }
        public string Name
        {
            get;
            set;
        }



        public void ProcessParameter(RestRequest requestBuilder, ParameterInfo parameterInfo, object parameterValue)
        {
            requestBuilder.AddJsonBody(parameterValue);
        }



    }
}
