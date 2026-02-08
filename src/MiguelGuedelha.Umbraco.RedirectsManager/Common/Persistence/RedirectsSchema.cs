using NPoco;
using Umbraco.Cms.Infrastructure.Persistence.DatabaseAnnotations;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Common.Persistence;

[TableName(Constants.Persistence.TableName)]
[PrimaryKey("Id", AutoIncrement = true)]
[ExplicitColumns]
internal sealed class RedirectsSchema
{
    [PrimaryKeyColumn(AutoIncrement = true, IdentitySeed = 1)]
    [Column(nameof(Id))]
    public int Id { get; set; }
    
    [Column(nameof(SiteId))]
    public Guid? SiteId { get; set; }
    
    [Column(nameof(OriginPath))]
    public required string OriginPath { get; set; }
    
    [Column(nameof(DestinationId))]
    public Guid? DestinationId { get; set; }
    
    [Column(nameof(DestinationLocation))]
    [SpecialDbType(SpecialDbTypes.NVARCHARMAX)]
    //Could be really long URL so better off letting it be as long as possible
    public string? DestinationLocation { get; set; }
}