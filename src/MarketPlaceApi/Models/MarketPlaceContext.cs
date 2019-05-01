using Microsoft.EntityFrameworkCore;
using MarketPlaceApi.Models.Entities;

namespace MarketPlaceApi.Models
{
    public class MarketPlaceContext : DbContext
    {
        public MarketPlaceContext(DbContextOptions<MarketPlaceContext> options)
            : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; }

        public DbSet<Point> Points { get; set; }

        public DbSet<Point_Priority> Point_Priorities { get; set; }
        public DbSet<Trend> Trends { get; set; }

        public DbSet<Trend_Event> Trend_Events { get; set; }

        public DbSet<Trend_Point> Trend_Points { get; set; }
    }
}
