using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Infrastructure.Manifest;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Manifests;

public class RedirectsManagerPackageManifestComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.AddSingleton<IPackageManifestReader, RedirectsManagerPackageManifestReader>();
    }
}