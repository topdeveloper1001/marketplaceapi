using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlaceApi.DTO.Requests
{
    public class UpdatePointRequest : CreatePointRequest
    {
        public Guid Id { get; set; }
    }
}
