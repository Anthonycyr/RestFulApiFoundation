using Microsoft.EntityFrameworkCore;

namespace ApexRocketApi.Models
{
    public class ElevatorContext : DbContext
    {
        public ElevatorContext(DbContextOptions<ElevatorContext> options)
            : base(options)
        {
        }

        public DbSet<Elevator> elevators { get; set; }
    }
}