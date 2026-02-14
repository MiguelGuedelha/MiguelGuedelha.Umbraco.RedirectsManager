using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiguelGuedelha.Umbraco.RedirectsManager.Persistence.EFCore.Converters;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Persistence.EFCore.Models;

[EntityTypeConfiguration(typeof(RedirectsTypeConfiguration))]
internal sealed class Redirects
{
    public int Id { get; init; }
    public required int SiteId { get; set; }
    public required Guid SiteKey { get; set; }
    public required string OriginUrl { get; set; }
    public required DestinationType DestinationType { get; set; }
    public int? DestinationId { get; set; }
    public Guid? DestinationKey { get; set; }
    public string? DestinationUrl { get; set; }
    public string? Query { get; set; }
    public string? Culture { get; set; }
    public required bool IsRegex { get; set; }
    public required bool IsPermanent { get; set; }
    public required bool ForwardQuery { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
}

internal sealed class RedirectsTypeConfiguration : IEntityTypeConfiguration<Redirects>
{
    public void Configure(EntityTypeBuilder<Redirects> entity)
    {
        entity.ToTable(Constants.TableName, t =>
        {
            t.HasCheckConstraint("CK_OneDestinationSet", OnlyOneDestinationSetCheck);
            t.HasCheckConstraint("CK_GlobalOrScopedSiteSet", GlobalOrScopedSiteSetCheck);
        });

        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id)
            .HasColumnName(Constants.TableProperties.Id.ColumnName)
            .IsRequired();
        
        entity.Property(e => e.SiteId)
            .HasColumnName(Constants.TableProperties.SiteId.ColumnName)
            .HasDefaultValue(Constants.TableProperties.SiteId.GlobalValue)
            .IsRequired();
            
        entity.Property(e => e.SiteKey)
            .HasColumnName(Constants.TableProperties.SiteKey.ColumnName)
            .HasDefaultValue(Constants.TableProperties.SiteKey.GlobalValue)
            .IsRequired();
            
        entity.Property(e => e.OriginUrl)
            .HasColumnName(Constants.TableProperties.OriginUrl.ColumnName)
            .HasMaxLength(Constants.TableProperties.OriginUrl.MaxLength)
            .IsRequired();
            
        entity.Property(e => e.DestinationType)
            .HasColumnName(Constants.TableProperties.DestinationType.ColumnName)
            .HasConversion<string>()
            .HasMaxLength(Constants.TableProperties.DestinationType.MaxLength)
            .IsRequired();
            
        entity.Property(e => e.DestinationId)
            .HasColumnName(Constants.TableProperties.DestinationId.ColumnName)
            .IsRequired(false);
        
        entity.Property(e => e.DestinationKey)
            .HasColumnName(Constants.TableProperties.DestinationKey.ColumnName)
            .IsRequired(false);
            
        entity.Property(e => e.DestinationUrl)
            .HasColumnName(Constants.TableProperties.DestinationUrl.ColumnName)
            .HasMaxLength(Constants.TableProperties.DestinationUrl.MaxLength)
            .IsRequired(false);

        entity.Property(e => e.Query)
            .HasColumnName(Constants.TableProperties.Query.ColumnName)
            .HasMaxLength(Constants.TableProperties.Query.MaxLength)
            .IsRequired(false);
            
        entity.Property(e => e.Culture)
            .HasColumnName(Constants.TableProperties.Culture.ColumnName)
            .HasMaxLength(Constants.TableProperties.Culture.MaxLength)
            .IsRequired(false);
            
        entity.Property(e => e.IsRegex)
            .HasColumnName(Constants.TableProperties.IsRegex.ColumnName)
            .IsRequired();
            
        entity.Property(e => e.IsPermanent)
            .HasColumnName(Constants.TableProperties.IsPermanent.ColumnName)
            .IsRequired();

        entity.Property(e => e.ForwardQuery)
            .HasColumnName(Constants.TableProperties.ForwardQuery.ColumnName)
            .IsRequired();
            
        entity.Property(e => e.CreatedAt)
            .HasColumnName(Constants.TableProperties.CreatedAt.ColumnName)
            .HasConversion<DateTimeUtcConverter>()
            .IsRequired();
            
        entity.Property(e => e.UpdatedAt)
            .HasColumnName(Constants.TableProperties.UpdatedAt.ColumnName)
            .HasConversion<DateTimeUtcConverter>()
            .IsRequired();

        entity.HasIndex(x => new { x.SiteId, x.OriginUrl }).IsUnique();
        
        entity.HasIndex(x => new { x.DestinationId});
    }
    
    private const string OnlyOneDestinationSetCheck = 
        $"""
         (
             {Constants.TableProperties.DestinationId.ColumnName} IS NOT NULL 
             AND 
             (
                 {Constants.TableProperties.DestinationUrl.ColumnName} IS NULL 
                 OR 
                 {Constants.TableProperties.DestinationUrl.ColumnName} = ''
             )
         ) 
         OR 
         (
             {Constants.TableProperties.DestinationId.ColumnName} IS NULL 
             AND 
             (
                 {Constants.TableProperties.DestinationUrl.ColumnName} IS NOT NULL 
                 AND 
                 {Constants.TableProperties.DestinationUrl.ColumnName} <> ''
             )
         )
         """;

    private static readonly string GlobalOrScopedSiteSetCheck =
        $"""
         (
             siteId = {Constants.TableProperties.SiteId.GlobalValue} 
             AND
             siteKey = '{Constants.TableProperties.SiteKey.GlobalValue}'
         )
         OR
         (
             siteId > {Constants.TableProperties.SiteId.GlobalValue} 
             AND 
             siteKey <> '{Constants.TableProperties.SiteKey.GlobalValue}'
         )
         """;
}