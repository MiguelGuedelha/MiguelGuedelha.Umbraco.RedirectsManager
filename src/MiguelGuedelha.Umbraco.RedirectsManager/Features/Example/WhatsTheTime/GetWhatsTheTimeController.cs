using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MiguelGuedelha.Umbraco.RedirectsManager.Common;
using MiguelGuedelha.Umbraco.RedirectsManager.Common.Api;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Features.Example.WhatsTheTime;

[ApiVersion(Constants.Api.Versions.V1)]
[ApiExplorerSettings(GroupName = Constants.Api.Groups.Example)]
public sealed class GetWhatsTheTimeController : ManagementControllerBase
{
    [HttpGet("whatsTheTimeMrWolf")]
    [ProducesResponseType(typeof(DateTime), 200)]
    public DateTime Index() => DateTime.Now;
}