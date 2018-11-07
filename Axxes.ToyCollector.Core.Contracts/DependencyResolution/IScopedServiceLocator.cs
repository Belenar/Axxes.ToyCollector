using System;

namespace Axxes.ToyCollector.Core.Contracts.DependencyResolution
{
    public interface IScopedServiceLocator
    {
        object Resolve(Type type);

        object ResolveGenericType(Type genericType, params Type[] genericParameters);
    }
}
