using Microsoft.EntityFrameworkCore;
using MiguelGuedelha.Umbraco.RedirectsManager.Common.Persistence.Models;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Common.Persistence;

internal sealed class RedirectsManagerDbContext : DbContext
{
    public RedirectsManagerDbContext(DbContextOptions<RedirectsManagerDbContext> options) 
        : base(options)
    {
    }
        
    public required DbSet<Redirects> Redirects { get; set; }
    public IQueryable<Redirects> RedirectsReadOnly => Redirects.AsNoTracking();
}