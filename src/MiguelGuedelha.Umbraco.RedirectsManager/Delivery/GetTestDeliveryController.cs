using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiguelGuedelha.Umbraco.RedirectsManager.Common;
using MiguelGuedelha.Umbraco.RedirectsManager.Common.Api;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Delivery;

[ApiVersion(Constants.Api.Versions.V1)]
public sealed class GetTestDeliveryController : DeliveryControllerBase
{
    [HttpGet("test")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    public string Index() => "The endpoint works when Delivery API is enabled only";
}