using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace demo.Job
{
    public static class JobService
    {




        public static void QuartzAdd<TJob>(IScheduler scheduler, string cron) where TJob : IJob
        {
            ITrigger trigger = TriggerBuilder.Create()
                           .StartNow()
                           .WithCronSchedule(cron)
                           .Build();
           
            //创建作业实例
            var jobDetail = JobBuilder.Create<TJob>()
                            .WithIdentity(typeof(TJob).Name, typeof(TJob).Name)
                            .Build();

            scheduler.ScheduleJob(jobDetail, trigger);
        }


        public static void AddQuartz(this IServiceCollection services)
        {
            services.AddSingleton(provider =>
            {
                var schedulerFactory = new StdSchedulerFactory();
                var scheduler = schedulerFactory.GetScheduler().Result;
                scheduler.JobFactory = provider.GetService<IJobFactory>();
                return scheduler;
            });
        }



    }
}
