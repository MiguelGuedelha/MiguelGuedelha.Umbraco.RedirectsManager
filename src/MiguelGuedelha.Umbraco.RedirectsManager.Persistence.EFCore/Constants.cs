namespace MiguelGuedelha.Umbraco.RedirectsManager.Persistence.EFCore;

internal static class Constants
{
    public const string TableName = "redirectsManager";

    public static class TableProperties
    {
        public static class Id
        {
            public const string ColumnName = "id";
        }
        
        public static class SiteId
        {
            public const string ColumnName = "siteId";
            public const int GlobalValue = -1;
        }
        
        public static class SiteKey
        {
            public const string ColumnName = "siteKey";
            public static readonly Guid GlobalValue = Guid.Empty;
        }

        public static class OriginUrl
        {
            public const string ColumnName = "originUrl";
            public const int MaxLength = 2048;
        }

        public static class DestinationType
        {
            public const string ColumnName = "destinationType";
            public const int MaxLength = 8;
        }

        public static class DestinationId
        {
            public const string ColumnName = "destinationId";
        }

        public static class DestinationKey
        {
            public const string ColumnName = "destinationKey";
        }

        public static class DestinationUrl
        {
            public const string ColumnName = "destinationUrl";
            public const int MaxLength = 2048;
        }

        public static class Query
        {
            public const string ColumnName = "query";
            public const int MaxLength = 2048;
        }

        public static class Culture
        {
            public const string ColumnName = "culture";
            public const int MaxLength = 100;
        }

        public static class IsRegex
        {
            public const string ColumnName = "isRegex";
        }

        public static class IsPermanent
        {
            public const string ColumnName = "isPermanent";
        }

        public static class ForwardQuery
        {
            public const string ColumnName = "forwardQuery";
        }

        public static class CreatedAt
        {
            public const string ColumnName = "createdAt";
        }

        public static class UpdatedAt
        {
            public const string ColumnName = "updatedAt";
        }
    }
}