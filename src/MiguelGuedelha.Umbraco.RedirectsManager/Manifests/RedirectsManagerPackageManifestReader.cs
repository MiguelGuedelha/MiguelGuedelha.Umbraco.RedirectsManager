using Umbraco.Cms.Core.Manifest;
using Umbraco.Cms.Infrastructure.Manifest;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Manifests;

public class RedirectsManagerPackageManifestReader : IPackageManifestReader
{
    public Task<IEnumerable<PackageManifest>> ReadPackageManifestsAsync()
    {
        var extensions = new List<object>
        {
            new
            {
                type = "bundle",
                alias = $"{RedirectsManagerPackageManifestConstants.Prefix}.Bundle",
                name = $"{RedirectsManagerPackageManifestConstants.PrefixName} Bundle",
                js = $"/App_Plugins/{RedirectsManagerPackageManifestConstants.BundleFolder}/{RedirectsManagerPackageManifestConstants.BundleName}.js"
            }
        };
        
        var manifest = new PackageManifest
        {
            Id = RedirectsManagerPackageManifestConstants.Id,
            Name = RedirectsManagerPackageManifestConstants.Name,
            Version = RedirectsManagerPackageManifestConstants.Version,
            AllowTelemetry = true,
            Extensions = extensions.ToArray()
        };

        return Task.FromResult<IEnumerable<PackageManifest>>([manifest]);
    }
}