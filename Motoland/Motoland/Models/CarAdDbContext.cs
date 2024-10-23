using Microsoft.EntityFrameworkCore;
using Motoland.Models;

namespace CarAdApp.Data
{
    public class CarAdDbContext : DbContext
    {
        public CarAdDbContext(DbContextOptions<CarAdDbContext> options) : base(options)
        {
        }

        // DbSet для таблицы CarAd
        public DbSet<CarAd> CarAds { get; set; }
    }
}
