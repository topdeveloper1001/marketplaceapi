using System;
using MarketPlaceApi.Models.Entities;

namespace MarketPlaceApi.DTO
{
    public class TrendDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Interval { get; set; }
        public string Type { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? TimeOut { get; set; }
        public int? TreadsNumber { get; set; }
        public static TrendDto Map(Trend trend)
        {
            return new TrendDto
            {
                Id = trend.Id,
                Name = trend.Name,
                Interval = trend.Interval,
                Type = trend.Type,
                DateCreated = trend.DateCreated,
                TimeOut = trend.TimeOut,
                TreadsNumber = trend.TreadsNumber
            };
        }
    }
}
