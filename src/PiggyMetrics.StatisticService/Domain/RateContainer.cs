using System;
using System.Collections.Generic;
using System.Text;

namespace PiggyMetrics.StatisticService.Domain
{
    public class RateContainer
    {
        public string date { get; set; }
        public Dictionary<string, double> rates {get;set;}
    }
}
