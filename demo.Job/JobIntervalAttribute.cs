using System;
using System.Collections.Generic;
using System.Text;

namespace demo.Job
{
    public class JobIntervalAttribute:Attribute
    {
        public TimeSpan Interval { set; get; }
        public JobIntervalAttribute(int interval) {
            Interval = TimeSpan.FromSeconds(interval);
        }
    }
    public class JobCronAttribute : Attribute
    {
        public string Cron { set; get; }
        public JobCronAttribute(string cron)
        {
            Cron = cron;
        }
    }
}
