using Autofac;
using Autofac.Core;
using demo.Common.Dependency;
using demo.Common.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace demo.Common
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder RegisterDependencies(this ContainerBuilder containerBuilder)
        {
            var types = TypeHelper.Instance.FindInheritTypes<IDependency>().Where(x => x.IsClass && !x.IsAbstract).ToArray();

            foreach (var item in types)
            {
                if (item.IsGenericType) continue;
                var registration = containerBuilder.RegisterType(item).PropertiesAutowired( PropertyWiringOptions.AllowCircularDependencies)
                    .As(item.GetRegisterTypes().ToArray());
                if (item.IsInherit<ISingletonDependency>())
                    registration = registration.SingleInstance();
                else if (item.IsInherit<IScopedDependency>())
                    registration = registration.InstancePerLifetimeScope();
                else
                    registration = registration.InstancePerDependency();
            }
            return containerBuilder;
        }



        public static ContainerBuilder RegisterServices(this ContainerBuilder containerBuilder)
        {
            return containerBuilder;
        }
     
    }
}
