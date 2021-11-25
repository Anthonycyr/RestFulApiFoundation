using Microsoft.EntityFrameworkCore;

namespace ApexRocketApi.Models
{
    public class LeadContext : DbContext
    {
        public LeadContext(DbContextOptions<LeadContext> options)
            : base(options)
        {
        }

        public DbSet<Lead> leads { get; set; }
    }
}