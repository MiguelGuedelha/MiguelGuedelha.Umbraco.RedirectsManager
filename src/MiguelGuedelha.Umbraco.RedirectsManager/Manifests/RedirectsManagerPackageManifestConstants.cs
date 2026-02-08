using System.Reflection;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Manifests;

internal static class RedirectsManagerPackageManifestConstants
{
    public const string Prefix = "MiguelGuedelha.Umbraco.RedirectsManager";
    public static readonly string PrefixName = "MiguelGuedelha Umbraco RedirectsManager";
    public static readonly string BundleName = "miguel-guedelha-umbraco-redirects-manager";
    public static readonly string BundleFolder = "MiguelGuedelhaUmbracoRedirectsManager";
    public const string Id = "MiguelGuedelha.Umbraco.RedirectsManager";
    public const string Name = "Redirects Manager";
    
    private static readonly Assembly Assembly = typeof(RedirectsManagerPackageManifestConstants).Assembly;
    
    private static readonly string? InformationalVersion = Assembly
        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
        ?.InformationalVersion;

    private static readonly string? NameVersion = Assembly
        .GetName().Version?.ToString();

    public static readonly string Version = InformationalVersion ?? NameVersion ?? "0.0.0";
}