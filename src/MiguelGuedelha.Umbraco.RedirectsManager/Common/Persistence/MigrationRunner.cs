using Microsoft.EntityFrameworkCore;
using MiguelGuedelha.Umbraco.RedirectsManager.Persistence.EFCore;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Common.Persistence;

internal sealed class MigrationRunner : INotificationAsyncHandler<UmbracoApplicationStartingNotification>
{
    private readonly RedirectsManagerDbContext _redirectsDbContext;

    public MigrationRunner(RedirectsManagerDbContext redirectsDbContext)
    {
        _redirectsDbContext = redirectsDbContext;
    }

    public async Task HandleAsync(UmbracoApplicationStartingNotification notification, CancellationToken cancellationToken)
    {
        if (notification.RuntimeLevel < RuntimeLevel.Run)
        {
            return;
        }
        
        var pendingMigrations = await _redirectsDbContext.Database
            .GetPendingMigrationsAsync(cancellationToken: cancellationToken);

        if (pendingMigrations.Any())
        {
            await _redirectsDbContext.Database
                .MigrateAsync(cancellationToken: cancellationToken);
        }
    }
}