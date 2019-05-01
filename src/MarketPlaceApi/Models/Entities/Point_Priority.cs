using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlaceApi.Models.Entities
{
    public class Point_Priority
    {
        public int Id { get; set; }
        public Point Point { get; set; }
        public int OrderId { get; set; }
        public string Description { get; set; }
    }
}
