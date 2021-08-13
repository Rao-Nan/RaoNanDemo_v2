using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace demo.HttpClient.Attributes
{
    internal interface IHttpMethodAttribute
    {
        Method HttpMethod { get; }
    }
}
