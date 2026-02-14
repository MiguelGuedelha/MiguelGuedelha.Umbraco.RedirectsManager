using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Api.Endpoints.Management;

[ApiVersion(Constants.Api.Versions.V1)]
public sealed class GetTestManagementController : ManagementControllerBase
{
    [HttpGet("test")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    public string Index() => "The endpoint works - management api";
}