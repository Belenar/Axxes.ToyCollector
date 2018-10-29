using Axxes.ToyCollector.Core.Contracts.DependencyResolution;
using Axxes.ToyCollector.Core.Contracts.Repositories;
using Axxes.ToyCollector.DataAccess.Repositories;

namespace Axxes.ToyCollector.DataAccess
{
    public class TypeRegistrar : ITypeRegistrar
    {
        public void RegisterServices(ITypeRegistrationContainer container)
        {
            container.RegisterPerRequest<IToyRepository, ToyRepository>();
        }
    }
}