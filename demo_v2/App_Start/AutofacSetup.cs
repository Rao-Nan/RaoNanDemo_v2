using Autofac;
using demo.Common;
using System;
using System.IO;
using System.Reflection;

namespace demo_v2.App_Start
{
    public class AutofacSetup : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var basePath = AppContext.BaseDirectory;
            //RegisterDependencies
            builder.RegisterDependencies();



            #region 服务注入

            var servicesDllFile = Path.Combine(basePath, "demo.Service.dll");
            var repositoryDllFile = Path.Combine(basePath, "demo.Repository.dll");
            var jobDllFile = Path.Combine(basePath, "demo.Job.dll");

            if (!(File.Exists(servicesDllFile)) || !(File.Exists(repositoryDllFile)))
            {
                var msg = "Service.dll 或者 Repository.dll 丢失，请检查 bin 文件夹.";
                throw new Exception(msg);
            }


            // 获取 Repository.dll 程序集服务，并注册
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository)
                      .AsImplementedInterfaces()
                      .InstancePerDependency();

            // 获取 Service.dll 程序集服务，并注册
            var assemblysServices = Assembly.LoadFrom(servicesDllFile);
            builder.RegisterAssemblyTypes(assemblysServices)
                      .AsImplementedInterfaces()
                      .InstancePerDependency();


            #endregion
        }
    }
}