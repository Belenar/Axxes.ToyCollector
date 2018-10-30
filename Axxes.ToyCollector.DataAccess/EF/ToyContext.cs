using Axxes.ToyCollector.Core.Contracts.DataStructures;
using Axxes.ToyCollector.Core.Contracts.DependencyResolution.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Axxes.ToyCollector.DataAccess.EF
{
    public class ToyContext : DbContext
    {
        private readonly DatabaseConnectionStrings _connectionStrings;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionStrings.ToyDbConnection);
        }

        public ToyContext(IOptions<DatabaseConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }

        public DbSet<Toy> Toys { get; set; }
    }
}
