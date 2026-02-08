using MiguelGuedelha.Umbraco.RedirectsManager.Common;
using Umbraco.Cms.Core.Manifest;
using Umbraco.Cms.Infrastructure.Manifest;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Features.Manifests;

internal sealed class PackageManifestReader : IPackageManifestReader
{
    public Task<IEnumerable<PackageManifest>> ReadPackageManifestsAsync()
    {
        var extensions = new List<object>
        {
            new
            {
                type = "bundle",
                alias = $"{Constants.Manifest.Prefix}.Bundle",
                name = $"{Constants.Manifest.PrefixName} Bundle",
                js = $"{Constants.Manifest.BundleFolder}/{Constants.Manifest.BundleName}.js"
            }
        };
        
        var manifest = new PackageManifest
        {
            Id = Constants.Manifest.Id,
            Name = Constants.Manifest.Name,
            Version = Constants.Manifest.Version,
            AllowTelemetry = true,
            Extensions = extensions.ToArray()
        };

        return Task.FromResult<IEnumerable<PackageManifest>>([manifest]);
    }
}