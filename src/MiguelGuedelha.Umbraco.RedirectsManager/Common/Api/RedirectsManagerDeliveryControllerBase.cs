using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Api.Common.Attributes;
using Umbraco.Cms.Core.Features;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Common.Api;

[ApiController]
[Route($"delivery/{Constants.Api.ApiName}/api/v{{version:apiVersion}}")]
[MapToApi(Constants.Api.ApiName)]
public abstract class RedirectsManagerDeliveryControllerBase : ControllerBase, IUmbracoFeature;
//TODO: Ensure that any controllers inheriting this only work/are enabled when the Delivery API is also enabled