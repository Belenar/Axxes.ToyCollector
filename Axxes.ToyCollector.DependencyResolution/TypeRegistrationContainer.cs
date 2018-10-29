using Autofac;
using Axxes.ToyCollector.Core.Contracts.DependencyResolution;

namespace Axxes.ToyCollector.DependencyResolution
{
    class TypeRegistrationContainer : ITypeRegistrationContainer
    {
        private readonly ContainerBuilder _builder;

        public TypeRegistrationContainer(ContainerBuilder builder)
        {
            _builder = builder;
        }

        public void RegisterSingleton<TContract, TImplementation>() where TImplementation : class, TContract
        {
            _builder
                .RegisterType<TImplementation>()
                .As<TContract>()
                .SingleInstance();
        }

        public void RegisterPerRequest<TContract, TImplementation>() where TImplementation : class, TContract
        {
            _builder
                .RegisterType<TImplementation>()
                .As<TContract>()
                .InstancePerLifetimeScope();
        }

        public void RegisterTransient<TContract, TImplementation>() where TImplementation : class, TContract
        {
            _builder
                .RegisterType<TImplementation>()
                .As<TContract>()
                .InstancePerDependency();
        }
    }
}