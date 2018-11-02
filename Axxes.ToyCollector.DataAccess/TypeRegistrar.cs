using Axxes.ToyCollector.Core.Contracts.Database;
using Axxes.ToyCollector.Core.Contracts.DependencyResolution;
using Axxes.ToyCollector.Core.Contracts.Repositories;
using Axxes.ToyCollector.DataAccess.Database;
using Axxes.ToyCollector.DataAccess.EF;
using Axxes.ToyCollector.DataAccess.Repositories;

namespace Axxes.ToyCollector.DataAccess
{
    public class TypeRegistrar : ITypeRegistrar
    {
        public void RegisterServices(ITypeRegistrationContainer container)
        {
            container.RegisterDbContext<ToyContext>();
            container.RegisterPerRequest<IToyRepository, ToyRepository>();
            container.RegisterSingleton<IDatabaseInitializer, DatabaseInitializer>(); 
        }
    }
}