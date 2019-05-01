using System;
using MarketPlaceApi.Models.Entities;

namespace MarketPlaceApi.DTO
{
    public class Trend_EventDto
    {
        public Guid Id { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public TrendDto Trend { get; set; }
        public int? PointCounts { get; set; }
        public int? TimeOutCounts { get; set; }
        public int? ErrorCount { get; set; }
        public string Notifications { get; set; }
        public static Trend_EventDto Map(Trend_Event te)
        {
            return new Trend_EventDto
            {
                Id = te.Id,
                StartDateTime = te.StartDateTime,
                EndDateTime = te.EndDateTime,
                Trend = TrendDto.Map(te.Trend),
                PointCounts = te.PointCounts,
                TimeOutCounts = te.TimeOutCounts,
                ErrorCount = te.ErrorCount,
                Notifications = te.Notifications
            };
        }
    }
}
