namespace DSRNetSchool.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
{
    private const string migrationProjctPrefix = "DSRNetSchool.Context.Migrations";

    public MainDbContext CreateDbContext(string[] args)
    {
        var provider = (args?[0] ?? $"{DbType.MSSQL}").ToLower();

        var configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.context.json")
             .Build();


        DbContextOptions<MainDbContext> options;
        if (provider.Equals($"{DbType.MSSQL}".ToLower()))
        {
            options = new DbContextOptionsBuilder<MainDbContext>()
                    .UseSqlServer(
                        configuration.GetConnectionString(provider),
                        opts => opts
                            .MigrationsAssembly($"{migrationProjctPrefix}{DbType.MSSQL}")
                    )
                    .Options;
        }
        else
        if (provider.Equals($"{DbType.PostgreSQL}".ToLower()))
        {
            options = new DbContextOptionsBuilder<MainDbContext>()
                    .UseNpgsql(
                        configuration.GetConnectionString(provider),
                        opts => opts
                            .MigrationsAssembly($"{migrationProjctPrefix}{DbType.PostgreSQL}")
                    )
                    .Options;
        }
        else
        {
            throw new Exception($"Unsupported provider: {provider}");
        }

        var dbf = new DbContextFactory(options);
        return dbf.Create();
    }
}
