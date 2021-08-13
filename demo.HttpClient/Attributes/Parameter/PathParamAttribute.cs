using RestSharp;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace demo.HttpClient.Attributes.Parameter
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class PathParamAttribute : Attribute, IParameterScopeAttribute
    {
        public PathParamAttribute()
        {

        }
        public PathParamAttribute(string name)
        {
            this.Name = name;
        }

        public ParameterScope Scope
        {
            get
            {
                return ParameterScope.Path;
            }
        }
        public string Name
        {
            get;
            set;
        }

        internal string[] PathParamNamesFilter { get; set; }


        public void ProcessParameter(RestRequest requestBuilder, ParameterInfo parameterInfo, object parameterValue)
        {
            requestBuilder.AddUrlSegment(this.Name ?? parameterInfo.Name, parameterValue);
            
        }
    }
}
