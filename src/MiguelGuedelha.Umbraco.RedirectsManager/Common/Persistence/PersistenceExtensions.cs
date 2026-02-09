using Microsoft.EntityFrameworkCore;
using MiguelGuedelha.Umbraco.RedirectsManager.Persistence.Sqlite;
using MiguelGuedelha.Umbraco.RedirectsManager.Persistence.SqlServer;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Common.Persistence;

internal static class PersistenceExtensions
{
    extension(DbContextOptionsBuilder builder)
    {
        public void UseRedirectsManagerDbProvider(string? connectionString, string? providerName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);
            ArgumentException.ThrowIfNullOrWhiteSpace(providerName);
            
            switch (providerName)
            {
                case global::Umbraco.Cms.Core.Constants.ProviderNames.SQLServer:
                    builder.UseSqlServer(connectionString, options =>
                    {
                        options.MigrationsAssembly(SqlServerPersistence.Assembly);
                    });
                    break;
                case global::Umbraco.Cms.Core.Constants.ProviderNames.SQLLite:
                case "Microsoft.Data.SQLite":
                    builder.UseSqlite(connectionString, options =>
                    {
                        options.MigrationsAssembly(SqlitePersistence.Assembly);
                    });
                    break;
                default:
                    throw new InvalidDataException($"The provider {providerName} is not supported. Manually add the add the UseXXX statement to the options. I.E UseNpgsql()");
            }
        }
    }
}