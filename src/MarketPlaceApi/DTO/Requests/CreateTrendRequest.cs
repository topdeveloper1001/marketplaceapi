﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlaceApi.DTO.Requests
{
    public class CreateTrendRequest
    {
        public string Name { get; set; }
        public int? Interval { get; set; }
        public string Type { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? TimeOut { get; set; }
        public int? TreadsNumber { get; set; }
    }
}
