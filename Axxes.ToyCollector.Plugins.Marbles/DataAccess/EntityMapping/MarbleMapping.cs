using Axxes.ToyCollector.Plugins.Marbles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Axxes.ToyCollector.Plugins.Marbles.DataAccess.EntityMapping
{
    public class MarbleMapping : IEntityTypeConfiguration<Marble>
    {
        public void Configure(EntityTypeBuilder<Marble> builder)
        {
            builder
                .Property(t => t.SeeThrough)
                .HasColumnName("Transparent");
        }
    }
}