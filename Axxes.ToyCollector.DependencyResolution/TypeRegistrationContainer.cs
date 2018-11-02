using System;
using System.Linq;
using Axxes.ToyCollector.Core.Contracts.DependencyResolution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Axxes.ToyCollector.DependencyResolution
{
    class TypeRegistrationContainer : ITypeRegistrationContainer
    {
        private readonly IServiceCollection _services;

        public TypeRegistrationContainer(IServiceCollection services)
        {
            _services = services;
        }

        void ITypeRegistrationContainer.RegisterSingleton<TContract, TImplementation>()
        {
            _services.AddSingleton(typeof(TContract), typeof(TImplementation));
        }

        void ITypeRegistrationContainer.RegisterPerRequest<TContract, TImplementation>()
        {
            _services.AddScoped(typeof(TContract), typeof(TImplementation));
        }

        void ITypeRegistrationContainer.RegisterTransient<TContract, TImplementation>()
        {
            _services.AddTransient(typeof(TContract), typeof(TImplementation));
        }

        void ITypeRegistrationContainer.RegisterDbContext<TDbContext>()
        {
            var registeringType = typeof(TDbContext);
            if (!typeof(DbContext).IsAssignableFrom(registeringType))
                throw new ArgumentException($"The generic type parameter should inherit from DbContext. {registeringType} does not inherit from DbContext");

            var methods = typeof(EntityFrameworkServiceCollectionExtensions)
                .GetMethods();

            var method = methods.Single(m =>
                m.Name == "AddDbContext" && 
                m.IsStatic && 
                m.IsGenericMethod && 
                m.GetGenericArguments().Length == 1 &&
                m.GetParameters().Length == 4 &&
                m.GetParameters()[1].ParameterType == typeof(Action<DbContextOptionsBuilder>));
            
            var genericMethod = method.MakeGenericMethod(registeringType);

            genericMethod.Invoke(null, new object[] {_services, null, ServiceLifetime.Scoped, ServiceLifetime.Singleton});
        }
    }
}