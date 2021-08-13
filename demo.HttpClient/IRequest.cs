using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace demo.HttpClient
{
    /// <summary>
    /// 代表无需返回值的请求
    /// </summary>
    public interface IRequest : IRequest<Unit> { }

    /// <summary>
    /// 代表有返回值的请求
    /// </summary>
    /// <typeparam name="TResponse">Response type</typeparam>
    public interface IRequest<out TResponse> : IBaseRequest { }

    /// <summary>
    /// Allows for generic type constraints of objects implementing IRequest or IRequest{TResponse}
    /// </summary>
    public interface IBaseRequest { }


    public struct Unit
    {
        
    }
}
