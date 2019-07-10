namespace Axxes.ToyCollector.Core.Contracts.DependencyResolution
{
    public interface ITypeRegistrationContainer
    {
        void RegisterSingleton<TContract, TImplementation>()
            where TImplementation : class, TContract;

        void RegisterPerRequest<TContract, TImplementation>()
            where TImplementation : class, TContract;

        void RegisterTransient<TContract, TImplementation>()
            where TImplementation : class, TContract;

        void RegisterDbContext<TDbContext>()
            where TDbContext : class;
    }
}