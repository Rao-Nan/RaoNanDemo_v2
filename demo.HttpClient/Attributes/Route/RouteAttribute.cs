using System;
using System.Collections.Generic;
using System.Text;

namespace demo.HttpClient.Attributes.Route
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RouteAttribute : Attribute
    {
        // Summary:
        //     Initializes a new instance of the System.Web.Http.RouteAttribute class.
        public RouteAttribute()
        {

        }
        // Summary:
        //     Initializes a new instance of the System.Web.Http.RouteAttribute class.
        //
        // Parameters:
        //   template:
        //     The route template describing the URI pattern to match against.
        public RouteAttribute(string path)
        {
            this.Path = path;
        }
        //
        //
        // Returns:
        //     Returns System.String.
        public string Path { get; set; }


    }
}
