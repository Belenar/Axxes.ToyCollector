using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Axxes.ToyCollector.Core.Contracts.DependencyResolution;
using Microsoft.Extensions.DependencyInjection;

namespace Axxes.ToyCollector.DependencyResolution
{
    public static class DependencyLoaderExtensions
    {
        /// <summary>
        /// Loads the DLL's and scans their types using Reflection. If a class implementing
        /// <see cref="ITypeRegistrar"/> is found, it is executed, thus adding these types to
        /// the DI container.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to register the types in.</param>
        /// <param name="dllFiles">The paths of all dll files to scan.</param>
        public static void LoadConfiguredTypesFromFiles(
            this IServiceCollection services, IEnumerable<string> dllFiles)
        {
            var container = new TypeRegistrationContainer(services);

            foreach (var dllFile in dllFiles)
            {
                LoadAssembly(container, dllFile);
            }
        }

        private static void LoadAssembly(ITypeRegistrationContainer container, string dllFile)
        {
            var assembly = Assembly.LoadFrom(dllFile);

            var types = assembly.GetTypes();

            foreach (var registrarType in types
                .Where(t => typeof(ITypeRegistrar).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract))       
            {
                RunRegistrar(container, registrarType);
            }
        }

        private static void RunRegistrar(ITypeRegistrationContainer container, Type registrarType)
        {
            var registrar = (ITypeRegistrar)Activator.CreateInstance(registrarType);

            registrar.RegisterServices(container);
        }
    }
}
