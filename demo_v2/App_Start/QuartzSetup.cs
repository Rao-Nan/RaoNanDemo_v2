using demo.Job;
using Microsoft.AspNetCore.Builder;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_v2.App_Start
{
    public static class QuartzSetup
    {
        public static void InitJob(this IApplicationBuilder app, IScheduler scheduler)
        {
            JobService.QuartzAdd<TestDemoJob>(scheduler, "0/30 * * * * ?");
        }
            
    }
}
