using BC.Data.Configurations;
using BC.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BC.Data
{
    public class BettingContext : DbContext
    {
        public BettingContext(DbContextOptions<BettingContext> options)
           : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EventConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
