using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Api.Common.Attributes;
using Umbraco.Cms.Web.Common.Authorization;
using Umbraco.Cms.Web.Common.Routing;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Common.Api;

[ApiController]
[BackOfficeRoute($"umbraco/{Constants.Api.ApiName}/api/v{{version:apiVersion}}")]
[Authorize(Policy = AuthorizationPolicies.SectionAccessContent)]
[MapToApi(Constants.Api.ApiName)]
public abstract class RedirectsManagerManagementControllerBase : ControllerBase;