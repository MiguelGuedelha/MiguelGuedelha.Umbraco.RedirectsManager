using Microsoft.Extensions.DependencyInjection;
using MiguelGuedelha.Umbraco.RedirectsManager.Api;
using MiguelGuedelha.Umbraco.RedirectsManager.Manifests;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Infrastructure.Manifest;

namespace MiguelGuedelha.Umbraco.RedirectsManager;

public sealed class RedirectsManagerComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services
            .AddApi()
            .AddSingleton<IPackageManifestReader, RedirectsManagerPackageManifestReader>();
    }
}