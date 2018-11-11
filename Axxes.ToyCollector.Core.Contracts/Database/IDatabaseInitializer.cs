namespace Axxes.ToyCollector.Core.Contracts.Database
{
    public interface IDatabaseInitializer
    {
        void Initialize(string[] pluginAssemblies);
    }
}
