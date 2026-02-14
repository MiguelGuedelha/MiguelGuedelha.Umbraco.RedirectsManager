using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Api.Endpoints.Example.WhatsTheTime;

[ApiVersion(Constants.Api.Versions.V1)]
[ApiExplorerSettings(GroupName = Constants.Api.Groups.Example)]
public sealed class GetWhatsTheTimeController : ManagementControllerBase
{
    [HttpGet("whatsTheTimeMrWolf")]
    [ProducesResponseType(typeof(DateTime), 200)]
    public DateTime Index() => DateTime.Now;
}