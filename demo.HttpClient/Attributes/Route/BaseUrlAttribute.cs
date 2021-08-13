using System;
using System.Collections.Generic;
using System.Text;

namespace demo.HttpClient.Attributes.Route
{

    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, AllowMultiple = false)]
    public class BaseUrlAttribute : Attribute
    {
        // Summary:
        //     Initializes a new instance of the System.Web.Http.RouteAttribute class.
        public BaseUrlAttribute()
        {

        }
        // Summary:
        //     Initializes a new instance of the System.Web.Http.RouteAttribute class.
        //
        // Parameters:
        //   template:
        //     The route template describing the URI pattern to match against.
        public BaseUrlAttribute(string url)
        {
            this.Url = url;
        }
        //
        //
        // Returns:
        //     Returns System.String.
        public string Url { get; set; }


    }
}
