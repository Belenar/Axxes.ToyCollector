namespace Axxes.ToyCollector.Core.Contracts.DependencyResolution
{
    public interface IInheritedTypeRegistrar
    {
        void RegisterInheritedTypes(IInheritedTypesRegistry registry);
    }
}