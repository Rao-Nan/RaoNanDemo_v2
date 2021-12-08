using Autofac;
using demo.Common.Dependency;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace demo.Job
{
    public class JobBaseService :IHostedService
    {
        private readonly ILogger<JobBaseService> _logger;
        private readonly IHostApplicationLifetime _applicationLifetime;
        public JobBaseService(IHostApplicationLifetime applicationLifetime,
            ILogger<JobBaseService> logger) {
            _applicationLifetime = applicationLifetime;
            _logger = logger;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _applicationLifetime.ApplicationStarted.Register(RegisterJob);
            return Task.CompletedTask;
        }

        private void RegisterJob()
        {
            var jobTypes=TypeHelper.Instance.FindInheritTypes<JobBase>();
            foreach (var type in jobTypes)
            {
                var cron=GetCron(type);
                var expressionType = typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(type,typeof(Task)));
                var methodParameters = new Type[] {expressionType, typeof(string),typeof(TimeZoneInfo), typeof(string)};


                //start job

            }
        }

        private string GetCron(Type type)
        {

            var jobCronAttribute = type.GetCustomAttribute<JobCronAttribute>();
            if (jobCronAttribute != null) return jobCronAttribute.Cron;
            var jobIntervalAttribute = type.GetCustomAttribute<JobIntervalAttribute>();
            var jobInterval = jobIntervalAttribute?.Interval ?? TimeSpan.FromSeconds(5);
            return  CreateCron(jobInterval);
        }

        private string CreateCron(TimeSpan jobInterval)
        {
            var s = jobInterval.Seconds > 0 ? $"*/{jobInterval.Seconds}" : "*";
            var m = jobInterval.Minutes > 0 ? $"*/{jobInterval.Minutes}" : "*";
            var h = jobInterval.Hours > 0 ? $"*/{jobInterval.Hours}" : "*";
            var d = jobInterval.Days > 0 ? $"*/{jobInterval.Days}" : "*";
            return $"{s} {m} {h} {d} * ?";
        }

        public Task Execute()
        {
            _logger.LogInformation(DateTime.Now.ToString());
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("StopAsync:" + DateTime.Now.ToString());
            return Task.CompletedTask;
        }
    }

}
