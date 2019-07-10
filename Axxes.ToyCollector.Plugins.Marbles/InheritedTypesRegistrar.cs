using Axxes.ToyCollector.Core.Contracts.DependencyResolution;
using Axxes.ToyCollector.Core.Models;
using Axxes.ToyCollector.Plugins.Marbles.Models;

namespace Axxes.ToyCollector.Plugins.Marbles
{
    public class InheritedTypesRegistrar : IInheritedTypeRegistrar
    {
        public void RegisterInheritedTypes(IInheritedTypesRegistry registry)
        {
            registry.RegisterInheritedType<Toy, Marble>("Marble");
        }
    }
}