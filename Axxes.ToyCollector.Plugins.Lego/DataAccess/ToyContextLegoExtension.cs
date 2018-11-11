using Axxes.ToyCollector.DataAccess.Contracts.EF;
using Axxes.ToyCollector.Plugins.Lego.DataAccess.EntityMapping;
using Microsoft.EntityFrameworkCore;

namespace Axxes.ToyCollector.Plugins.Lego.DataAccess
{
    public class ToyContextLegoExtension : IExtendToyContext
    {
        public void LoadToyContextExtensions(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LegoSetMapping());
        }
    }
}