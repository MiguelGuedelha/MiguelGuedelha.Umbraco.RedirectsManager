using MiguelGuedelha.Umbraco.RedirectsManager.Persistence.EFCore;
using Umbraco.Cms.Persistence.EFCore.Scoping;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Services;

internal sealed class RedirectsManagementService : IRedirectsManagementService
{
    private readonly IEFCoreScopeProvider<RedirectsManagerDbContext> _efCoreScopeProvider;

    public RedirectsManagementService(IEFCoreScopeProvider<RedirectsManagerDbContext> efCoreScopeProvider)
    {
        _efCoreScopeProvider = efCoreScopeProvider;
    }
}