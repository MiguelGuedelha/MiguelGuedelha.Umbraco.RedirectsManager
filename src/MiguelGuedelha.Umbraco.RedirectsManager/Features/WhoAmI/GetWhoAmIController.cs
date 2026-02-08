using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiguelGuedelha.Umbraco.RedirectsManager.Common;
using MiguelGuedelha.Umbraco.RedirectsManager.Common.Api;
using Umbraco.Cms.Core.Models.Membership;
using Umbraco.Cms.Core.Security;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Features.WhoAmI;

[ApiVersion(Constants.Api.Versions.V1)]
[ApiExplorerSettings(GroupName = Constants.Api.Groups.Example)]
public sealed class GetWhoAmIController : RedirectsManagerControllerBase
{
    private readonly IBackOfficeSecurityAccessor _backOfficeSecurityAccessor;

    public GetWhoAmIController(IBackOfficeSecurityAccessor backOfficeSecurityAccessor)
    {
        _backOfficeSecurityAccessor = backOfficeSecurityAccessor;
    }
    
    [HttpGet("whoAmI")]
    [ProducesResponseType<IUser>(StatusCodes.Status200OK)]
    public IUser? WhoAmI() => _backOfficeSecurityAccessor.BackOfficeSecurity?.CurrentUser;
}