using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlaceApi.Models.Entities
{
    public class Trend_Event
    {
        public Guid Id { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public Trend Trend { get; set; }
        public int? PointCounts { get; set; }
        public int? TimeOutCounts { get; set; }
        public int? ErrorCount { get; set; }
        public string Notifications { get; set; }

    }
}
