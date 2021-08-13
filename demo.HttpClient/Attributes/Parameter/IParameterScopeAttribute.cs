using RestSharp;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace demo.HttpClient.Attributes.Parameter
{
    public interface IParameterScopeAttribute
    {
        string Name { get; }
        ParameterScope Scope { get; }

        public void ProcessParameter(RestRequest requestBuilder, ParameterInfo parameterInfo, object parameterValue);
    }

    public enum ParameterScope
    {
        Query = 0,
        Path = 2,
        Header = 3,
        Cookie = 4,
        Form = 5,
        Json = 6,
        RawContent = 7
    }
}
