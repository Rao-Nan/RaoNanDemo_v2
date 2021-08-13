using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Linq;
using demo.HttpClient.Attributes;
using demo.HttpClient.Attributes.Parameter;

namespace demo.HttpClient
{

    /// <summary>
    /// 执行服务
    /// https://www.cnblogs.com/zhangxiaoyong/p/10771566.html
    /// </summary>
    public class Service
    {
        public static Dictionary<String, String> Namespace = new Dictionary<string, string>();

        /// <summary>
        /// 写入配置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public static void SetConfig(String key, String val)
        {
            Namespace.Add(key, val);
        }


        /// <summary>
        /// 执行方法
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public static TResponse Send<TRequest, TResponse>(TRequest command) where TRequest : IRequest<TResponse>
        {
            var types = command.GetType();
            var client = GetRestClient(types.Namespace);
            var request = GetRequest(command, types);
            IRestResponse<TResponse> response = client.Execute<TResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default(TResponse);
                }
                else
                {
                    throw new Exception(response.StatusCode + ":" + response.Content + (response.ErrorMessage ?? "提交错误"));
                }

            }
        }



        /// <summary>
        /// 获取数据并且转换类型
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponseAs"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public static TResponseAs GetAs<TRequest, TResponseAs>(TRequest command) where TResponseAs : class
        {
            var types = command.GetType();
            var client = GetRestClient(types.Namespace);
            var request = GetRequest(command, types);
            var response = client.Execute<TResponseAs>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default(TResponseAs);
                }
                else
                {
                    throw new Exception(response.StatusCode + ":" + response.Content + (response.ErrorMessage ?? ""));
                }

            }
        }

        /// <summary>
        /// 异步执行不返回
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="command"></param>
        public static void Notification<TRequest>(TRequest command) where TRequest : class
        {
            var types = command.GetType();
            var client = GetRestClient(types.Namespace);
            var request = GetRequest(command, types);
            client.ExecuteAsync(request);
        }

        /// <summary>
        /// 异步执行
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public static async Task<TResponse> SendAsync<TRequest, TResponse>(TRequest command) where TRequest : IRequest<TResponse>
        {
            var types = command.GetType();
            var client = GetRestClient(types.Namespace);
            var request = GetRequest(command, types);
            var response = await client.ExecuteAsync<TResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default(TResponse);
                }
                else
                {
                    throw new Exception(response.StatusCode + ":" + response.Content + (response.ErrorMessage ?? "提交错误"));
                }

            }
        }

        /// <summary>
        /// 异步执行
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public static async Task<TResponse> SendAsync<TRequest, TResponse>(TRequest command, string @namespace) where TRequest : IRequest<TResponse>
        {
            var types = command.GetType();
            var client = GetRestClient(@namespace);
            var request = GetRequest(command, types);
            var response = await client.ExecuteAsync<TResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default(TResponse);
                }
                else
                {
                    throw new Exception(response.StatusCode + ":" + response.Content + (response.ErrorMessage ?? "提交错误"));
                }

            }
        }



        /// <summary>
        /// 初始化客户端
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        private static RestClient GetRestClient(string namespaces)
        {
            if (Namespace.ContainsKey(namespaces))
            {
                return new RestClient(Namespace[namespaces]);
            }
            else
            {
                throw new Exception(namespaces + "没有配置服务器地址");
            }
        }

        /// <summary>
        /// 初始化请求数据
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        private static RestRequest GetRequest(object jsonBody, Type type)
        {
            //var httpMethodAttribute = type.CustomAttributes.FirstOrDefault(t => t is RouteAttribute) as RouteAttribute;
            var route = "";

            var httpMethodAttribute = type.CustomAttributes.FirstOrDefault(t => t is IHttpMethodAttribute) as IHttpMethodAttribute;
            var method = Method.POST;
            if (httpMethodAttribute != null)
            {
                method = httpMethodAttribute.HttpMethod;
            }

            var request = new RestRequest(route, method);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(jsonBody);

            foreach (var item in type.GetProperties())
            {
                //添加QueryParameter
                var queryParameter = item.GetCustomAttributes(typeof(QueryStringAttribute), true).FirstOrDefault() as QueryStringAttribute;
                if (queryParameter != null)
                {
                    var value = "";
                    item.GetValue(value);
                    request.AddQueryParameter(item.Name, value);
                }
            }

            request.RequestFormat = DataFormat.Json;
            return request;
        }
    }
}
