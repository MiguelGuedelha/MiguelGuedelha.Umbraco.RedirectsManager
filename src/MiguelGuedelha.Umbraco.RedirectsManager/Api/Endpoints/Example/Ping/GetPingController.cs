using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Api.Endpoints.Example.Ping;

[ApiVersion(Constants.Api.Versions.V1)]
[ApiExplorerSettings(GroupName = Constants.Api.Groups.Example)]
public sealed class GetPingController : ManagementControllerBase
{
    [HttpGet("ping")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    public string Index() => "Pong";
}