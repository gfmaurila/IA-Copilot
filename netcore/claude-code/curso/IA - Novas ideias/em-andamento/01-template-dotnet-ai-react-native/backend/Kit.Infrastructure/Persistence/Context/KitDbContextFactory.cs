using Kit.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Kit.Infrastructure.Persistence.Context;

/// <summary>
/// Used ONLY by the EF Core tooling (`dotnet ef migrations ...`) to build a
/// DbContext without booting Kit.Api.
///
/// The connection string here is a placeholder that is never used to connect:
/// a migration is generated from the model, not from a live database. `Migrate()`
/// still needs a reachable server; `migrations script` and `migrations add` do not.
/// </summary>
public sealed class KitDbContextFactory : IDesignTimeDbContextFactory<KitDbContext>
{
    public KitDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<KitDbContext>();

        var connectionString = Environment.GetEnvironmentVariable("KIT_DESIGN_CONNECTION")
            ?? "Server=localhost;Port=3306;Database=kit_db;User ID=kit_user;Password=design-time-only;TreatTinyAsBoolean=true;SslMode=Preferred;";

        optionsBuilder.UseMySQL(
            connectionString,
            mysql =>
            {
                mysql.MigrationsAssembly(typeof(KitDbContext).Assembly.FullName);
                mysql.EnableRetryOnFailure(5, TimeSpan.FromSeconds(5), null);
            });

        return new KitDbContext(optionsBuilder.Options);
    }
}