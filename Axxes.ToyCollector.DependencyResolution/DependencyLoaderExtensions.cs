using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Axxes.ToyCollector.Core.Contracts.DependencyResolution;
using Microsoft.Extensions.DependencyInjection;

namespace Axxes.ToyCollector.DependencyResolution
{
    public static class DependencyLoaderExtensions
    {
        /// <summary>
        /// Scans the directory for DLL's and loads them. If a class implementing
        /// <see cref="ITypeRegistrar"/> is found, it is executed, thus adding these types to
        /// the DI container.
        /// </summary>
        /// <param name="serviceCollection">The <see cref="IServiceCollection"/> to register the types in.</param>
        /// <param name="directory">The directory to scan.</param>
        public static void LoadConfiguredTypesFromDir(this IServiceCollection serviceCollection, string directory)
        {
            var container = new TypeRegistrationContainer(serviceCollection);

            var dllFiles = Directory.GetFiles(directory, "Axxes.ToyCollector.*.dll", SearchOption.AllDirectories);

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
