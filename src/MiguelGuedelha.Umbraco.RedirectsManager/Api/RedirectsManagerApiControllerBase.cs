using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Api.Common.Attributes;
using Umbraco.Cms.Web.Common.Authorization;
using Umbraco.Cms.Web.Common.Routing;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Api;

[ApiController]
[BackOfficeRoute($"{RedirectsManagerApiConstants.ApiName}/api/v{{version:apiVersion}}")]
[Authorize(Policy = AuthorizationPolicies.SectionAccessContent)]
[MapToApi(RedirectsManagerApiConstants.ApiName)]
public class RedirectsManagerApiControllerBase : ControllerBase
{
}