using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Api.Common.Attributes;
using Umbraco.Cms.Core.Features;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Api;

[ApiController]
[Route($"{Constants.Api.ApiName}/api/delivery/v{{version:apiVersion}}")]
[MapToApi(Constants.Api.ApiName)]
[ApiExplorerSettings(GroupName = Constants.Api.Groups.Delivery)]
public abstract class DeliveryControllerBase : ControllerBase, IUmbracoFeature;