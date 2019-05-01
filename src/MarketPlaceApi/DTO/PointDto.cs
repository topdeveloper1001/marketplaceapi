using System;
using MarketPlaceApi.Models.Entities;

namespace MarketPlaceApi.DTO
{
    public class PointDto
    {
        public Guid Id { get; set; }
        public DeviceDto Device { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string ObjectType { get; set; }
        public string ObjectId { get; set; }
        public string AssetId { get; set; }
        public bool? Archive { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string AddedBy { get; set; }
        public static PointDto Map(Point point)
        {
            return new PointDto
            {
                Id = point.Id,
                Device = DeviceDto.Map(point.Device),
                Description = point.Description,
                Name = point.Name,
                ObjectType = point.ObjectType,
                ObjectId = point.ObjectId,
                AssetId = point.AssetId,
                Archive = point.Archive,
                LastUpdated = point.LastUpdated,
                AddedBy = point.AddedBy
            };
        }
    }
}
