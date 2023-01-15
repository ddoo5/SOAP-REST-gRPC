using ConsoleApp1.WcfServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceUI
{
    public class SimpleUI : IService1Callback
    {
        public void UpdateStatistics(StatisticsService statisticsService)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine($"update scripts statistics: {statisticsService.GetHashCode()}");
            Console.WriteLine($"Total: {statisticsService.TotalCount}");
            Console.WriteLine($"Success: {statisticsService.SuccessCount}");
            Console.WriteLine($"Fail: {statisticsService.FailCount}");
        }
    }
}
