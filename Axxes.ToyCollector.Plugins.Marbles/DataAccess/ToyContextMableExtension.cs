using Axxes.ToyCollector.Core.Contracts.Database;
using Axxes.ToyCollector.Plugins.Marbles.DataAccess.EntityMapping;
using Microsoft.EntityFrameworkCore;

namespace Axxes.ToyCollector.Plugins.Marbles.DataAccess
{
    public class ToyContextMableExtension : IExtendToyContext
    {
        public void LoadToyContextExtensions(object builder)
        {
            if (builder is ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfiguration(new MarbleMapping());
            }
        }
    }
}