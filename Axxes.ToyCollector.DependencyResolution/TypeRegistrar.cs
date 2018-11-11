using Axxes.ToyCollector.Core.Contracts.DependencyResolution;

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
