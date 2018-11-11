using System.Collections.Generic;
using Axxes.ToyCollector.Core.Contracts.DependencyResolution.Options;
using Axxes.ToyCollector.Core.Models;
using Axxes.ToyCollector.DataAccess.Contracts.EF;
using Axxes.ToyCollector.DataAccess.EF.EntityMapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Axxes.ToyCollector.DataAccess.EF
{
    public class ToyContext : DbContext
    {
        private readonly IEnumerable<IExtendToyContext> _extensions;
        private readonly DatabaseConnectionStrings _connectionStrings;

        public ToyContext(
            IOptions<DatabaseConnectionStrings> connectionStrings, 
            IEnumerable<IExtendToyContext> extensions)
        {
            _extensions = extensions;
            _connectionStrings = connectionStrings?.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connectionStrings.ToyDbConnection,
                    b => b.MigrationsAssembly("Axxes.ToyCollector.Migrations.EFCore"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ToyMapping());

            foreach (var extension in _extensions)
            {
                extension.LoadToyContextExtensions(modelBuilder);
            }
        }

        public DbSet<Toy> Toys { get; set; }
    }
}
