using Microsoft.EntityFrameworkCore;
using MiguelGuedelha.Umbraco.RedirectsManager.Persistence.EFCore.Models;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Persistence.EFCore;

internal sealed class RedirectsManagerDbContext : DbContext
{
    public RedirectsManagerDbContext(DbContextOptions<RedirectsManagerDbContext> options) 
        : base(options)
    {
    }
        
    public required DbSet<Redirects> Redirects { get; set; }
    public IQueryable<Redirects> RedirectsReadOnly => Redirects.AsNoTracking();
}