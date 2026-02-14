using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Security;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Api.Endpoints.Example.WhatsMyName;

[ApiVersion(Constants.Api.Versions.V1)]
[ApiExplorerSettings(GroupName = Constants.Api.Groups.Example)]
public sealed class GetWhatsMyNameController : ManagementControllerBase
{
    private readonly IBackOfficeSecurityAccessor _backOfficeSecurityAccessor;

    public GetWhatsMyNameController(IBackOfficeSecurityAccessor backOfficeSecurityAccessor)
    {
        _backOfficeSecurityAccessor = backOfficeSecurityAccessor;
    }
    
    [HttpGet("whatsMyName")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    public string Index()
    {
        // So we can see a long request in the dashboard with a spinning progress wheel
        Thread.Sleep(2000);

        var currentUser = _backOfficeSecurityAccessor.BackOfficeSecurity?.CurrentUser;
        return currentUser?.Name ?? "I have no idea who you are";
    }
}