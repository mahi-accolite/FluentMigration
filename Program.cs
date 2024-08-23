using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Test.Migrations;

namespace Test;

class Program
{
    static void Main()
    {
        using (var serviceProvider = CreateServices())
        using (var scope = serviceProvider.CreateScope())
        {
            UpdateDatabase(scope.ServiceProvider);
        }
    }

    private static ServiceProvider CreateServices()
    {
        return new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(rb =>
                rb.AddSQLite()
                    .WithGlobalConnectionString("Data Source=Mahendra.sqlitedb")
                    .ScanIn(
                        [
                            typeof(AddLogTable).Assembly,
                            typeof(AddUserTables).Assembly,
                            typeof(UpdateUserTable2).Assembly
                        ]
                    )
                    .For.Migrations()
            )
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
    }

    private static void UpdateDatabase(IServiceProvider serviceProvider)
    {
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
        runner.MigrateDown(0);
    }
}
