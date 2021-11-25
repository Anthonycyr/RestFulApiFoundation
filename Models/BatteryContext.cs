using Microsoft.EntityFrameworkCore;

namespace ApexRocketApi.Models
{
    public class BatteryContext : DbContext
    {
        public BatteryContext(DbContextOptions<BatteryContext> options)
            : base(options)
        {
        }

        public DbSet<Battery> batteries { get; set; }
    }
}