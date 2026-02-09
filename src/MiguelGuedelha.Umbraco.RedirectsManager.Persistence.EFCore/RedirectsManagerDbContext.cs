using Microsoft.EntityFrameworkCore;
using MiguelGuedelha.Umbraco.RedirectsManager.Persistence.EFCore.Models;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Persistence.EFCore;

/*
 * Before running migrations for a given DB provider,
 * comment/uncomment the correct connection string and provider in the Test Site project
 * For SQL Server, run the SQL Only launch profile in aspire
 * 
 * Adding SQLite migrations:
 * dotnet ef migrations add <Name> -s MiguelGuedelha.Umbraco.RedirectsManager.TestSite -p MiguelGuedelha.Umbraco.RedirectsManager.Persistence.Sqlite -c RedirectsManagerDbContext
 *
 * Adding SQL Server migrations:
 * dotnet ef migrations add <Name> -s MiguelGuedelha.Umbraco.RedirectsManager.TestSite -p MiguelGuedelha.Umbraco.RedirectsManager.Persistence.SqlServer -c RedirectsManagerDbContext
 */
internal sealed class RedirectsManagerDbContext : DbContext
{
    public RedirectsManagerDbContext(DbContextOptions<RedirectsManagerDbContext> options) 
        : base(options)
    {
    }
        
    public required DbSet<Redirects> Redirects { get; set; }
    public IQueryable<Redirects> RedirectsReadOnly => Redirects.AsNoTracking();
}