using demo.HttpClient.Attributes.Parameter;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace demo.HttpClient
{
    public class ParameterDescription
    {
        internal ParameterDescription()
        {
        }

        public string ParameterNmae { get; set; }
        public string ParameterValue { get; set; }
        public IParameterScopeAttribute[] ScopeAttributes { get; internal set; }
    }
}
