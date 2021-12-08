using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace demo.Job
{
    public abstract class JobBase
    {
        private readonly ILifetimeScope _lifetimeScope;
        public JobBase(ILifetimeScope lifetimeScope) { 
            _lifetimeScope = lifetimeScope;
            _lifetimeScope.InjectProperties(this);
        }
        protected T Resolve<T>() => _lifetimeScope.Resolve<T>();
    }
}
