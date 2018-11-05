using Axxes.ToyCollector.Core.Contracts.DependencyResolution;
using Axxes.ToyCollector.DataAccess.Contracts.EF;
using Axxes.ToyCollector.Plugins.Marbles.DataAccess;

namespace Axxes.ToyCollector.Plugins.Marbles
{
    public class TypeRegistrar : ITypeRegistrar
    {
        public void RegisterServices(ITypeRegistrationContainer container)
        {
            container.RegisterSingleton<IExtendToyContext, ToyContextMableExtension>();
        }
    }
}