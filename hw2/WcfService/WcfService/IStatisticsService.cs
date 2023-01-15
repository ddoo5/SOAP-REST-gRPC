using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfService
{
    public interface IStatisticsService
    {
        int SuccessCount { get; set; }
        int FailCount { get; set; }
        int TotalCount { get; set; }
    }
}
