using System;
using MarketPlaceApi.Models.Entities;

namespace MarketPlaceApi.DTO
{
    public class Point_PriorityDto
    {
        public int Id { get; set; }
        public PointDto Point { get; set; }
        public int OrderId { get; set; }
        public string Description { get; set; }
        public static Point_PriorityDto Map(Point_Priority pp)
        {
            return new Point_PriorityDto
            {
                Id = pp.Id,
                Point = PointDto.Map(pp.Point),
                OrderId = pp.OrderId,
                Description = pp.Description
            };
        }
    }
}
