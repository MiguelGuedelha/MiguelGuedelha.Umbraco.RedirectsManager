using Microsoft.Extensions.DependencyInjection;
using MiguelGuedelha.Umbraco.RedirectsManager.Common.Api;
using MiguelGuedelha.Umbraco.RedirectsManager.Common.Persistence;
using MiguelGuedelha.Umbraco.RedirectsManager.Features.Manifests;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Infrastructure.Manifest;

namespace MiguelGuedelha.Umbraco.RedirectsManager;

public sealed class RedirectsManagerComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddRedirectsManagerOpenApi();
        builder.Services.AddSingleton<IPackageManifestReader, PackageManifestReader>();

        builder.Services.AddControllers(options =>
        {
            var config = builder.Config;
            options.Conventions.Add(new RedirectsManagerDeliveryVisibilityConvention(config));
        });
        
        builder.AddNotificationAsyncHandler<UmbracoApplicationStartingNotification, MigrationRunner>();
    }
}