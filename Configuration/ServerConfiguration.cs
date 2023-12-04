using Core.Configuration.Settings;
using Data.Configuration.Extensions;
using Methodic.Core.Configuration.Settings;

namespace Microsoft.Extensions.DependencyInjection;

public static class DefaultProfileExtensions
{
	public static IServiceCollection AddDefaultConfiguration(
		this IServiceCollection services
	)
	{
		// System.Diagnostics.Debugger.Launch();
		var appSettings = new AppSettings();
		services.AddSingleton(appSettings);
		services.AddAdminManager(appSettings);

		services.AddClientCore();

		services.AddClientData();

		var identitySettings = appSettings.GetSection<IdentitySettings>();
		services.AddIdentityClient(identitySettings);

		return services;
	}

	public static IServiceProvider ConfigureDefault(this IServiceProvider provider)
	{
		var appSettings = provider.GetService<AppSettings>();
		var baseSettings = appSettings.AddSection<BaseSettings>();
		baseSettings.IsMultiTenantApp = true;
		baseSettings.IsMultiDatabaseApp = true;

		provider
			.UseScheduler()
			.UseNotifications()
			.UseLogging();

		//var cacheProvider = provider.GetService<CacheProvider>();
		//cacheProvider.ResetAll();

		return provider;
	}
}
