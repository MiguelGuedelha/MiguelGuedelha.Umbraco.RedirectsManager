using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Api.Common.Attributes;
using Umbraco.Cms.Api.Common.Filters;
using Umbraco.Cms.Core.Features;
using Umbraco.Cms.Web.Common.Authorization;
using Umbraco.Cms.Web.Common.Routing;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Common.Api;

[ApiController]
[JsonOptionsName(global::Umbraco.Cms.Core.Constants.JsonOptionsNames.DeliveryApi)]
[Route($"delivery/{Constants.Api.ApiName}/api/v{{version:apiVersion}}")]
[Authorize(Policy = AuthorizationPolicies.UmbracoFeatureEnabled)]
[MapToApi(Constants.Api.ApiName)]
public abstract class RedirectsManagerDeliveryControllerBase : ControllerBase, IUmbracoFeature;
//TODO: Ensure that any controllers inheriting this only work/are enabled when the Delivery API is enabled