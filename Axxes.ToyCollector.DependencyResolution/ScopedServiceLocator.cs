using System;
using Axxes.ToyCollector.Core.Contracts.DependencyResolution;

namespace Axxes.ToyCollector.DependencyResolution
{
    public class ScopedServiceLocator : IScopedServiceLocator
    {
        private readonly IServiceProvider _provider;

        public ScopedServiceLocator(IServiceProvider provider)
        {
            _provider = provider;
        }

        public object Resolve(Type type)
        {
            return _provider.GetService(type);
        }

        public object ResolveGenericType(Type genericType, params Type[] genericParameters)
        {
            var genericInterfaceType = genericType.MakeGenericType(genericParameters);

            return Resolve(genericInterfaceType);
        }
    }
}
