using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlaceApi.DTO.Requests
{
    public class UpdateTrendRequest : CreateTrendRequest
    {
        public Guid Id { get; set; }
    }
}
