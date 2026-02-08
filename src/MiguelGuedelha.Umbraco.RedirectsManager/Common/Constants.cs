using System.Reflection;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Common;

internal static class Constants
{
    internal static class Manifest
    {
        public const string BundleName = "miguel-guedelha-umbraco-redirects-manager";
        public const string PackageFolder = "/App_Plugins/MiguelGuedelhaUmbracoRedirectsManager";
        public const string Id = "MiguelGuedelha.Umbraco.RedirectsManager";
        public const string Name = "Miguel Guedelha Umbraco Redirects Manager";
    
        private static readonly Assembly Assembly = typeof(Constants).Assembly;
    
        private static readonly string? InformationalVersion = Assembly
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
            ?.InformationalVersion;

        private static readonly string? NameVersion = Assembly
            .GetName().Version?.ToString();

        public static readonly string Version = InformationalVersion ?? NameVersion ?? "0.0.0";
    }
    
    internal static class Api
    {
        public const string ApiName = "redirectsmanager";
        public const string DocTitle = "Redirects Manager Backoffice API";

        public const string ControllersNamespace = "MiguelGuedelha.Umbraco.RedirectsManager";

        public static class Versions
        {
            public const string V1 = "1.0";
        }
        
        public static class Groups
        {
            public const string Example = "Example";
            public const string Management = "Management";
            public const string Delivery = "Delivery";
        }
    }

    internal static class Persistence
    {
        public const string TableName = "RedirectsManager";
    }
}