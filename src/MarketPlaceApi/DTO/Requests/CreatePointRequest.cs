using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlaceApi.DTO.Requests
{
    public class CreatePointRequest
    {
        public UpdateDeviceRequest Device { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string ObjectType { get; set; }
        public string ObjectId { get; set; }
        public string AssetId { get; set; }
        public bool? Archive { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string AddedBy { get; set; }
    }
}
