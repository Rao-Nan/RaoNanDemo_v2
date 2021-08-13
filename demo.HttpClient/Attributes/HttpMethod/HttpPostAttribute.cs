﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace demo.HttpClient.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class HttpPostAttribute : Attribute, IHttpMethodAttribute
    {
        public Method HttpMethod
        {
            get
            {
                return Method.POST;
            }
        }
    }
}
