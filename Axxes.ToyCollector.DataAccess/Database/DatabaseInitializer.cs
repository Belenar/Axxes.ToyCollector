using System;
using Axxes.ToyCollector.Core.Contracts.Database;
using Axxes.ToyCollector.Core.Contracts.DependencyResolution.Options;
using Axxes.ToyCollector.DataAccess.ModuleMigrations;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Axxes.ToyCollector.DataAccess.Database
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly DatabaseConnectionStrings _dbConnectionStrings;
        private bool _isInitialized;

        public DatabaseInitializer(IOptions<DatabaseConnectionStrings> dbConnectionStringsOptions)
        {
            _dbConnectionStrings = dbConnectionStringsOptions.Value;
        }

        public void Initialize(string [] pluginAssemblies)
        {
            if (!_isInitialized)
            {
                _isInitialized = true;
                // Use FluentMigrator to upgrade the DB
                RunFluentMigratorMigrations(pluginAssemblies); 
            }
        }

        private void RunFluentMigratorMigrations(string[] pluginAssemblies)
        {
            var serviceProvider = CreateServices(pluginAssemblies);

            // Put the database update into a scope to ensure
            // that all resources will be disposed.
            if (pluginAssemblies != null)
                using (var scope = serviceProvider.CreateScope())
                {
                    UpdateDatabase(scope.ServiceProvider);
                }
        }

        /// <summary>
        /// Configure the dependency injection services
        /// </summary>
        /// <param name="assemblies"></param>
        private IServiceProvider CreateServices(string[] pluginAssemblies)
        {
            return new ServiceCollection()
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Add SQLite support to FluentMigrator
                    .AddSqlServer()
                    // Set the connection string
                    .WithGlobalConnectionString(_dbConnectionStrings.ToyDbConnection)
                    // Add migrations from the plugin assemblies
                    .ScanMigrations(pluginAssemblies))
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                // Build the service provider
                .BuildServiceProvider(false);
        }

        /// <summary>
        /// Update the database
        /// </summary>
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();
        }


    }
}
