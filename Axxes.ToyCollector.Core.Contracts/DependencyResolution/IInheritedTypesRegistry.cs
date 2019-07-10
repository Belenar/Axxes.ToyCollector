namespace Axxes.ToyCollector.Core.Contracts.DependencyResolution
{
    public interface IInheritedTypesRegistry
    {
        void RegisterInheritedType<TParentType, TChildType>(string typeName)
            where TParentType : class, new()
            where TChildType : class, TParentType, new();
    }
}