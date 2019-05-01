using System;
using MarketPlaceApi.Models.Entities;

namespace MarketPlaceApi.DTO
{
    public class DeviceDto
    {
        public Guid Id { get; set; }
        public string DeviceIdentifier { get; set; }
        public string IpAddress { get; set; }
        public string Type { get; set; }
        public Guid? ClientId { get; set; }
        public Guid? BuildingId { get; set; }
        public static DeviceDto Map(Device device)
        {
            return new DeviceDto
            {
                Id = device.Id,
                DeviceIdentifier = device.DeviceIdentifier,
                IpAddress = device.IpAddress,
                Type = device.Type,
                ClientId = device.ClientId,
                BuildingId = device.BuildingId
            };
        }
    }
}
