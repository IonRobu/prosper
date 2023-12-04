using Data.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Configuration.Extensions;

public static class ServicesConfigurationExtensions
{
	public static IServiceCollection AddClientData(this IServiceCollection services)
	{
		services.AddData();

		services.AddScoped<Context>();

		return services;
	}
}
