using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Configuration;

namespace MiguelGuedelha.Umbraco.RedirectsManager.Common.Api;

public class RedirectsManagerDeliveryVisibilityConvention : IControllerModelConvention
{
    private readonly bool _deliveryApiEnabled;

    private const string DeliveryApiEnabledProperty = $"{(global::Umbraco.Cms.Core.Constants.Configuration.ConfigDeliveryApi)}:Enabled";

    public RedirectsManagerDeliveryVisibilityConvention(IConfiguration configuration)
    {
        _deliveryApiEnabled = configuration.GetValue<bool>(DeliveryApiEnabledProperty);
    }

    public void Apply(ControllerModel controller)
    {
        if (!typeof(RedirectsManagerDeliveryControllerBase).IsAssignableFrom(controller.ControllerType))
        {
            return;
        }

        if (_deliveryApiEnabled)
        {
            return;
        }
        
        controller.ApiExplorer.IsVisible = false;
        controller.Selectors.Clear();
    }
}