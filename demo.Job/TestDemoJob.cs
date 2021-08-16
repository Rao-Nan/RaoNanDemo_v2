using demo.Service.IService;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Job
{

    public class TestDemoJob : IJob 
    {
        private readonly ILogger<TestDemoJob> _logger;
        private readonly IUserService _userService;

        public TestDemoJob(ILogger<TestDemoJob> logger,IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }


        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(async ()  =>
            {
                _logger.LogInformation("job start");
                var user = await _userService.GetUser();
                Console.WriteLine("name :{0}", user.Name);
                _logger.LogInformation("job stop");
            });
        }

    }
}
