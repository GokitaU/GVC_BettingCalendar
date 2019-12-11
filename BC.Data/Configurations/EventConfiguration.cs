using BC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BC.Data.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.OddsForFirstTeam)
                   .IsRequired();

            builder.Property(a => a.OddsForDraw)
                   .IsRequired();

            builder.Property(a => a.OddsForSecondTeam)
                   .IsRequired();

            builder.Property(a => a.EventStartDate)
                   .IsRequired();
        }
    }
}
