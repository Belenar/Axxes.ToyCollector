using Axxes.ToyCollector.Plugins.Lego.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Axxes.ToyCollector.Plugins.Lego.DataAccess.EntityMapping
{
    public class LegoSetMapping : IEntityTypeConfiguration<LegoSet>
    {
        public void Configure(EntityTypeBuilder<LegoSet> builder)
        {
            builder
                .Property(t => t.SetNumber)
                .HasMaxLength(15)
                .HasColumnType("varchar(15)");

            builder
                .Property(t => t.FinishedBuildDate)
                .HasColumnType("date");
        }
    }
}