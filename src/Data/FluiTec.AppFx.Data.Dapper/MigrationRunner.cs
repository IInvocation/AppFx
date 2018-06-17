using System;
using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace FluiTec.AppFx.Data.Dapper
{
    /// <summary>A migration runner.</summary>
    public class MigrationRunner
    {
        /// <summary>The connection string.</summary>
        protected readonly string ConnectionString;

        /// <summary>The migration assembly.</summary>
        protected readonly Assembly MigrationAssembly;

        /// <summary>The select database.</summary>
        protected readonly Action<IMigrationRunnerBuilder> SelectDatabase;

        /// <summary>Constructor.</summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="connectionString">         The connection string. </param>
        /// <param name="typeInMigrationLibrary">   The type in migration library. </param>
        /// <param name="selectDatabase">           The select database. </param>
        public MigrationRunner(string connectionString, Type typeInMigrationLibrary, Action<IMigrationRunnerBuilder> selectDatabase)
        {
            ConnectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
            MigrationAssembly = typeInMigrationLibrary != null
                ? typeInMigrationLibrary.Assembly
                : throw new ArgumentNullException(nameof(typeInMigrationLibrary));
            SelectDatabase = selectDatabase ?? throw new ArgumentNullException(nameof(selectDatabase));
        }

        /// <summary>Creates the services.</summary>
        /// <returns>The new services.</returns>
        private IServiceProvider CreateServices()
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(r => r
                    .ExecuteAction(SelectDatabase)
                    .WithGlobalConnectionString(ConnectionString)
                    .ScanIn(MigrationAssembly).For.All())
                .AddLogging(l => l.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        /// <summary>Migrate up.</summary>
        public void MigrateUp()
        {
            var serviceProvider = CreateServices();

            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }
    }

    internal static class RunnerHelper
    {
        public static IMigrationRunnerBuilder ExecuteAction(this IMigrationRunnerBuilder builder, Action<IMigrationRunnerBuilder> action)
        {
            action(builder);
            return builder;
        }
    }
}
