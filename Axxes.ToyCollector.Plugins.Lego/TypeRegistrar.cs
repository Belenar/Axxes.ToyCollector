using Axxes.ToyCollector.Core.Contracts.DependencyResolution;
using Axxes.ToyCollector.DataAccess.Contracts.EF;
using Axxes.ToyCollector.Plugins.Lego.DataAccess;

namespace Axxes.ToyCollector.Plugins.Lego
{
    public class TypeRegistrar : ITypeRegistrar
    {
        public void RegisterServices(ITypeRegistrationContainer container)
        {
            container.RegisterSingleton<IExtendToyContext, ToyContextLegoExtension>(); 
        }
    }
}