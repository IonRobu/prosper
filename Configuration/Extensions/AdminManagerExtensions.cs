using Methodic.Core.Components.Admin;
using Methodic.Core.Configuration.Settings;

namespace Microsoft.Extensions.DependencyInjection;

public static class AdminManagerExtensions
{
	public static IServiceCollection AddAdminManager(
		this IServiceCollection services,
		AppSettings appSettings
	)
	{
		var manager = new AdminManager();
		manager.Configure();
		services.AddSingleton<IAdminManager>(manager);
		manager.SetAppSettings(appSettings);
		return services;
	}
}
