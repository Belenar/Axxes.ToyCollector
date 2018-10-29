namespace Axxes.ToyCollector.Core.Contracts.DependencyResolution
{
    public interface ITypeRegistrar
    {
        void RegisterServices(ITypeRegistrationContainer container);
    }
}