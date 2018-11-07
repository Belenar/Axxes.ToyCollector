using Axxes.ToyCollector.Core.Contracts.DependencyResolution;
using Axxes.ToyCollector.Core.Contracts.Services;

namespace Axxes.ToyCollector.DependencyResolution
{
    public class TypeRegistrar : ITypeRegistrar
    {
        public void RegisterServices(ITypeRegistrationContainer container)
        {
            container.RegisterTransient<IScopedServiceLocator, ScopedServiceLocator>();
        }
    }
}
