using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace demo.HttpClient
{
    public interface IRequestHandler<in TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
      
        Task<TResponse> Handle(TRequest request);
    }

    public interface IRequestHandler<in TRequest> : IRequestHandler<TRequest, Unit>
        where TRequest : IRequest<Unit>
    {
    }
}
