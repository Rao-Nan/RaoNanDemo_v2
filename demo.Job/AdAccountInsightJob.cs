using Autofac;
using demo.Common.Dependency;
using demo.Service.IService;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Job
{

    public class AdAccountInsightJob : JobBase, IJob
    {
        private readonly ILogger<AdAccountInsightJob> _logger;
        private readonly IUserService _userService;

        public AdAccountInsightJob(IUserService userService, ILogger<AdAccountInsightJob> logger, ILifetimeScope lifetimeScope) : base(lifetimeScope)
        {
            _logger = logger;
            _userService = userService;
        }


        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(async () =>
            {
                _logger.LogError("job strat");
                await Task.CompletedTask;
            });
        }

    }
}
