using Microsoft.Extensions.DependencyInjection;

namespace Utilities.Configuration;

public static class ConfigurationServiceRegistration
{
	public static IServiceCollection AddConfigurationServices(this IServiceCollection services)
	{
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
		return services;
	}
}