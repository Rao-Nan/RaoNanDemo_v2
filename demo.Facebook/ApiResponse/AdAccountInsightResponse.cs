using System;
using System.Collections.Generic;
using System.Text;

namespace demo.Facebook.ApiResponse
{
    public class AdAccountInsightResponse
    {
        public string account_currency { get; set; }
        public string spend { get; set; }
        public string social_spend { get; set; }
        public string account_id { get; set; }
        public string account_name { get; set; }
        public string ad_id { get; set; }
        public string ad_name { get; set; }
        public string adset_id { get; set; }
        public string adset_name { get; set; }
        public string impressions { get; set; }
        public string clicks { get; set; }
        public string ctr { get; set; }
        public string cpc { get; set; }
        public string cpm { get; set; }
        public string cpp { get; set; }
        public string created_time { get; set; }
        public string date_start { get; set; }
        public string date_stop { get; set; }
    }
}
