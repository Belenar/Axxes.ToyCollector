using Axxes.ToyCollector.Core.Contracts.DependencyResolution;
using Axxes.ToyCollector.Core.Contracts.Services;
using Axxes.ToyCollector.Core.Logic.Services;

namespace Axxes.ToyCollector.Core.Logic
{
    public class TypeRegistrar : ITypeRegistrar
    {
        public void RegisterServices(ITypeRegistrationContainer container)
        {
            container.RegisterTransient<IToyCreator, ToyCreator>();
        }
    }
}
