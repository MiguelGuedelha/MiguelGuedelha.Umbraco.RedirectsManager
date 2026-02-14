using MiguelGuedelha.Umbraco.RedirectsManager.Persistence.EFCore;
using Umbraco.Cms.Persistence.EFCore.Scoping;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Services;

internal sealed class RedirectsDeliveryService : IRedirectsDeliveryService
{
    private readonly IEFCoreScopeProvider<RedirectsManagerDbContext> _efCoreScopeProvider;

    public RedirectsDeliveryService(IEFCoreScopeProvider<RedirectsManagerDbContext> efCoreScopeProvider)
    {
        _efCoreScopeProvider = efCoreScopeProvider;
    }
    
    
}