using System;
using MarketPlaceApi.Models.Entities;

namespace MarketPlaceApi.DTO
{
    public class Trend_PointDto
    {
        public int Id { get; set; }
        public TrendDto Trend { get; set; }
        public PointDto Point { get; set; }
        public static Trend_PointDto Map(Trend_Point tp)
        {
            return new Trend_PointDto
            {
                Id = tp.Id,
                Trend = TrendDto.Map(tp.Trend),
                Point = PointDto.Map(tp.Point)
            };
        }
    }
}
