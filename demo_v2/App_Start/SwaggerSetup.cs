
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace demo_v2.App_Start
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdApi", Version = "v1" });
                //强制请求头
                //c.OperationFilter<AddRequiredHeaderParameter>("A001");

                //读取全部xml文件
                var basePath = Path.GetDirectoryName(typeof(Startup).Assembly.Location);
                foreach (var file in System.IO.Directory.GetFiles(basePath, "*.xml"))
                {
                    c.IncludeXmlComments(file);
                }
            });
        }
    }

}

