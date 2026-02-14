using Microsoft.Extensions.DependencyInjection;
using MiguelGuedelha.Umbraco.RedirectsManager.Api;
using MiguelGuedelha.Umbraco.RedirectsManager.Manifests;
using MiguelGuedelha.Umbraco.RedirectsManager.Persistence;
using MiguelGuedelha.Umbraco.RedirectsManager.Persistence.EFCore;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Infrastructure.Manifest;
using Umbraco.Extensions;

namespace MiguelGuedelha.Umbraco.RedirectsManager;

public sealed class RedirectsManagerComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddApiCommonModule();
        builder.Services.AddSingleton<IPackageManifestReader, PackageManifestReader>();

        builder.Services.AddControllers(options =>
        {
            var config = builder.Config;
            options.Conventions.Add(new DeliveryVisibilityConvention(config));
        });

        builder.Services.AddUmbracoDbContext<RedirectsManagerDbContext>((_, optionsBuilder, connectionString, providerName) =>
        {
            optionsBuilder.UseRedirectsManagerDbProvider(connectionString, providerName);
        });

        builder.AddNotificationAsyncHandler<UmbracoApplicationStartingNotification, MigrationRunner>();
    }
}