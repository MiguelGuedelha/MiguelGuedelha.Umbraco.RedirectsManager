using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Membership;
using Umbraco.Cms.Core.Security;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Api;

[ApiVersion(RedirectsManagerApiConstants.Versions.V1)]
[ApiExplorerSettings(GroupName = RedirectsManagerApiConstants.GroupName)]
public class RedirectsManagerApiController : RedirectsManagerApiControllerBase
{
    private readonly IBackOfficeSecurityAccessor _backOfficeSecurityAccessor;

    public RedirectsManagerApiController(IBackOfficeSecurityAccessor backOfficeSecurityAccessor)
    {
        _backOfficeSecurityAccessor = backOfficeSecurityAccessor;
    }

    [HttpGet("ping")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    public string Ping() => "Pong";

    [HttpGet("whatsTheTimeMrWolf")]
    [ProducesResponseType(typeof(DateTime), 200)]
    public DateTime WhatsTheTimeMrWolf() => DateTime.Now;

    [HttpGet("whatsMyName")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    public string WhatsMyName()
    {
        // So we can see a long request in the dashboard with a spinning progress wheel
        Thread.Sleep(2000);

        var currentUser = _backOfficeSecurityAccessor.BackOfficeSecurity?.CurrentUser;
        return currentUser?.Name ?? "I have no idea who you are";
    }

    [HttpGet("whoAmI")]
    [ProducesResponseType<IUser>(StatusCodes.Status200OK)]
    public IUser? WhoAmI() => _backOfficeSecurityAccessor.BackOfficeSecurity?.CurrentUser;
}