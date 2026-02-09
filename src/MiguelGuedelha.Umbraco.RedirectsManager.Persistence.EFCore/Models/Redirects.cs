using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Persistence.EFCore.Models;

[EntityTypeConfiguration(typeof(RedirectsTypeConfiguration))]
internal sealed class Redirects
{
    public int Id { get; init; }
    public Guid? SiteId { get; set; }
    public required string OriginUrl { get; set; }
    public required string DestinationType { get; set; }
    public Guid? DestinationId { get; set; }
    public string? DestinationUrl { get; set; }
    public string? Culture { get; set; }
    public bool IsRegex { get; set; }
    public bool IsPermanent { get; set; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; set; }
}

internal sealed class RedirectsTypeConfiguration : IEntityTypeConfiguration<Redirects>
{
    private const string OnlyOneDestinationSetCheck = 
        """
        (destinationId IS NOT NULL AND (destinationUrl IS NULL OR destinationUrl = '')) 
        OR 
        (destinationId IS NULL AND (destinationUrl IS NOT NULL AND destinationUrl <> ''))
        """;
    
    public void Configure(EntityTypeBuilder<Redirects> entity)
    {
        entity.ToTable(Constants.TableName, t =>
        {
            t.HasCheckConstraint("CK_OneDestinationSet", OnlyOneDestinationSetCheck);
        });
            
        entity.HasKey(e => e.Id);
            
        entity.Property(e => e.Id).HasColumnName("id");
            
        entity.Property(e => e.SiteId)
            .HasColumnName("siteId")
            .IsRequired(false);
            
        entity.Property(e => e.OriginUrl)
            .HasColumnName("originUrl")
            .IsRequired();
            
        entity.Property(e => e.DestinationType)
            .HasColumnName("destinationType")
            .IsRequired();
            
        entity.Property(e => e.DestinationId)
            .HasColumnName("destinationId")
            .IsRequired(false);
            
        entity.Property(e => e.DestinationUrl)
            .HasColumnName("destinationUrl")
            .IsRequired(false);
            
        entity.Property(e => e.Culture)
            .HasColumnName("culture")
            .IsRequired(false);
            
        entity.Property(e => e.IsRegex)
            .HasColumnName("isRegex")
            .IsRequired();
            
        entity.Property(e => e.IsPermanent)
            .HasColumnName("isPermanent")
            .IsRequired();
            
        entity.Property(e => e.CreatedAt)
            .HasColumnName("createdAt")
            .IsRequired();
            
        entity.Property(e => e.UpdatedAt)
            .HasColumnName("updatedAt")
            .IsRequired();
    }
}