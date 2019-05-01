using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlaceApi.Models.Entities
{
    public class Trend_Point
    {
        public int Id { get; set; }
        public Trend Trend { get; set; }
        public Point Point { get; set; }
    }
}
