using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlaceApi.Models.Entities
{
    public class Device
    {
        public Guid Id { get; set; }
        public string DeviceIdentifier { get; set; }
        public string IpAddress { get; set; }
        public string Type { get; set; }
        public Guid? ClientId { get; set; }
        public Guid? BuildingId { get; set; }
    }
}
