using RestSharp;
using RestSharp.Authenticators;
using demo.HttpClient.Attributes;
using demo.HttpClient.Attributes.Parameter;
using demo.HttpClient.Attributes.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace demo.HttpClient
{
    public class HttpClientWrapper
    {
        public static T Proxy<T>()
        {
            var type = typeof(T);
            var baseUrlAttribute = type.GetCustomAttribute<BaseUrlAttribute>();
            if (baseUrlAttribute != null && !Service.Namespace.ContainsKey(type.FullName))
            {
                Service.SetConfig(type.FullName, baseUrlAttribute.Url);
            }
            return DispatchProxy.Create<T, InvokeProxy<T>>();
        }

        public class InvokeProxy<T> : DispatchProxy
        {
            private Type type = null;
            public InvokeProxy()
            {
                type = typeof(T);
            }

            protected override object Invoke(MethodInfo methodInfo, object[] args)
            {
                var url =  Service.Namespace[type.FullName];
                if (url == null)
                {
                    throw new NotSupportedException(string.Format("没获取到对应的url，请检查配置信息:{0}", type.Namespace.ToString()));
                }
                var route = "";
                var routeAttribute = methodInfo.GetCustomAttribute<RouteAttribute>();
                if (routeAttribute != null)
                {
                    route = routeAttribute.Path;
                }

                var method = Method.POST;
                var httpMethodAttribute = methodInfo.GetCustomAttributes().FirstOrDefault(t => t is IHttpMethodAttribute) as IHttpMethodAttribute;
                if (httpMethodAttribute != null)
                {
                    method = httpMethodAttribute.HttpMethod;
                }
                var request = new RestRequest(route, method);
                request.AddHeader("content-type", "application/json");
                //parameters
                var parameters = methodInfo.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    var parametersType = parameters[i];
                    var customAttributes = parametersType.GetCustomAttributes();
                    if (customAttributes.Any(a => a is IParameterScopeAttribute) && !parametersType.IsDefined(typeof(HttpIgnoreAttribute)))
                    {
                        var ScopeAttributes = customAttributes.Where(a => a is IParameterScopeAttribute)
                        .Cast<IParameterScopeAttribute>().ToArray();
                        foreach (var scope in ScopeAttributes)
                        {
                            scope.ProcessParameter(request, parameters[i], args[i]);
                        }
                    }
                    else if(!parametersType.IsDefined(typeof(HttpIgnoreAttribute)))
                    {
                        request.AddParameter(parameters[i].Name, args[i]);
                    }

                }
                request.RequestFormat = DataFormat.Json;
                
                var client = new RestClient(url);
                var _method=client.GetType().GetMethod("Execute", 1, new Type[] { typeof(RestRequest) });
                _method=_method.MakeGenericMethod(methodInfo.ReturnType.GenericTypeArguments);
                var res= _method.Invoke(client, new object[] { request });
                return res;
            }
        }
    }
}
