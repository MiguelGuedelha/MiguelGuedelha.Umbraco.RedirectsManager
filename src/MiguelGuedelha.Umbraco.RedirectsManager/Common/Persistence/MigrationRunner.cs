using MiguelGuedelha.Umbraco.RedirectsManager.Common.Persistence.Migrations;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Migrations;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Migrations;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Common.Persistence;

public sealed class MigrationRunner : INotificationHandler<UmbracoApplicationStartingNotification>
{
    private readonly IMigrationPlanExecutor _migrationPlanExecutor;
    private readonly ICoreScopeProvider _coreScopeProvider;
    private readonly IKeyValueService _keyValueService;
    private readonly IRuntimeState _runtimeState;

    public MigrationRunner(
        IMigrationPlanExecutor migrationPlanExecutor, 
        ICoreScopeProvider coreScopeProvider, 
        IKeyValueService keyValueService, 
        IRuntimeState runtimeState)
    {
        _migrationPlanExecutor = migrationPlanExecutor;
        _coreScopeProvider = coreScopeProvider;
        _keyValueService = keyValueService;
        _runtimeState = runtimeState;
    }

    public void Handle(UmbracoApplicationStartingNotification notification)
    {
        if (_runtimeState.Level < RuntimeLevel.Run)
        {
            return;
        }

        var migrationPlan = new MigrationPlan(Constants.Manifest.Id);

        migrationPlan.From(string.Empty)
            .To<AddRedirectsTable>("create-db-table");
    }
}