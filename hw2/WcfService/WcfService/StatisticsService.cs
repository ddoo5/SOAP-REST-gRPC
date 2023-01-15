using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService
{
    public class StatisticsService : IStatisticsService
    {
        public int SuccessCount { get; set; }
        public int FailCount { get; set; }
        public int TotalCount { get; set; }
    }
}