using Axxes.ToyCollector.Core.Contracts.Database;
using Axxes.ToyCollector.Core.Contracts.DependencyResolution;
using Axxes.ToyCollector.Core.Contracts.Services;
using Axxes.ToyCollector.Plugins.Lego.DataAccess;
using Axxes.ToyCollector.Plugins.Lego.Logic;
using Axxes.ToyCollector.Plugins.Lego.Models;

namespace Axxes.ToyCollector.Plugins.Lego
{
    public class TypeRegistrar : ITypeRegistrar
    {
        public void RegisterServices(ITypeRegistrationContainer container)
        {
            container.RegisterTransient<IToyCreatorCustomLogic<LegoSet>, LegoSetCreatorCustomLogic>();
            container.RegisterSingleton<IExtendToyContext, ToyContextLegoExtension>(); 
        }
    }
}