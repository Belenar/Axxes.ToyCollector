using Axxes.ToyCollector.Core.Contracts.Database;
using Axxes.ToyCollector.Plugins.Lego.DataAccess.EntityMapping;
using Microsoft.EntityFrameworkCore;

namespace Axxes.ToyCollector.Plugins.Lego.DataAccess
{
    public class ToyContextLegoExtension : IExtendToyContext
    {
        public void LoadToyContextExtensions(object builder)
        {
            if (builder is ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfiguration(new LegoSetMapping());
            }
        }
    }
}