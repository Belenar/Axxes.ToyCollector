using Axxes.ToyCollector.Core.Contracts.DependencyResolution;
using Axxes.ToyCollector.Core.Models;
using Axxes.ToyCollector.Plugins.Lego.Models;

namespace Axxes.ToyCollector.Plugins.Lego
{
    public class InheritedTypesRegistrar : IInheritedTypeRegistrar
    {
        public void RegisterInheritedTypes(IInheritedTypesRegistry registry)
        {
            registry.RegisterInheritedType<Toy, LegoSet>("LegoSet");
        }
    }
}