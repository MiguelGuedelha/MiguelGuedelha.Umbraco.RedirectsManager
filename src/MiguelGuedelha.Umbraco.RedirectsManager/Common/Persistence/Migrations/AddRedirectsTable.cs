using Microsoft.Extensions.Logging;
using Umbraco.Cms.Infrastructure.Migrations;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Common.Persistence.Migrations;

public class AddRedirectsTable : AsyncMigrationBase
{
    public AddRedirectsTable(IMigrationContext context) : base(context)
    {
    }

    protected override Task MigrateAsync()
    {
        if (Logger.IsEnabled(LogLevel.Debug))
        {
            Logger.LogDebug("Running migration {MigrationStep}", "AddCommentsTable");
        }

        // Lots of methods available in the MigrationBase class - discover with this.
        if (!TableExists(Constants.Persistence.TableName))
        {
            Create.Table<RedirectsSchema>().Do();
        }
        else
        {
            if (Logger.IsEnabled(LogLevel.Debug))
            {
                Logger.LogDebug("The database table {DbTable} already exists, skipping", Constants.Persistence.TableName);
            }
        }

        return Task.CompletedTask;
    }
}