using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiguelGuedelha.Umbraco.RedirectsManager.Common;
using MiguelGuedelha.Umbraco.RedirectsManager.Common.Api;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Features.Example.Ping;

[ApiVersion(Constants.Api.Versions.V1)]
[ApiExplorerSettings(GroupName = Constants.Api.Groups.Example)]
public sealed class GetPingController : ManagementControllerBase
{
    [HttpGet("ping")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    public string Index() => "Pong";
}