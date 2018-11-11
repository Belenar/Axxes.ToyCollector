using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Axxes.ToyCollector.DataAccess.EF;
using FluentMigrator.Runner;

namespace Axxes.ToyCollector.DataAccess.ModuleMigrations
{
    public static class MigrationRunnerExtensions
    {
        public static IMigrationRunnerBuilder ScanMigrations(this IMigrationRunnerBuilder builder,
            string[] pluginAssemblies)
        {
            // Core migrations
            var allFixedAssemblies = new[] { typeof(ToyContext).Assembly };

            // The plugins
            var allPluginAssemblies = pluginAssemblies.Select(Assembly.LoadFrom);

            var allMigrationAssemblies = allFixedAssemblies
                .Union(allPluginAssemblies)
                .ToArray();

            builder.ScanIn(allMigrationAssemblies).For.Migrations();

            return builder;
        }
    }
}
