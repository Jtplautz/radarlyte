using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RadarLyte.Database.Models;

namespace RadarLyte.Deploying;

public class NorthAmericaContextFactory : IDesignTimeDbContextFactory<NorthAmericaContext> {
    public NorthAmericaContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
                                            .SetBasePath(Directory.GetCurrentDirectory())
                                            .AddJsonFile("appsettings.json")
                                            .Build();

        IServiceCollection services = new ServiceCollection();
        services.AddDbContextPool<NorthAmericaContext>(options =>
        {
            options.EnableSensitiveDataLogging();
            options.ConfigureWarnings(warnings =>
            {
                warnings.Log(RelationalEventId.TransactionCommitted);
                warnings.Log(RelationalEventId.TransactionError);
                warnings.Log((RelationalEventId.CommandExecuting, LogLevel.Information));

                warnings.Log((SqlServerEventId.SavepointsDisabledBecauseOfMARS, LogLevel.Warning));
                warnings.Log((RelationalEventId.MultipleCollectionIncludeWarning, LogLevel.Warning));

                warnings.Throw(RelationalEventId.QueryPossibleUnintendedUseOfEqualsWarning);
            });
            options.UseSqlServer(configuration.GetConnectionString("NorthAmericaContextConnection"), sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure();
                sqlOptions.MigrationsAssembly(typeof(NorthAmericaContext).Assembly.GetName().Name);
            });
        });

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        return serviceProvider.GetService<NorthAmericaContext>();
    }
}