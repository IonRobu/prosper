namespace Methodic.Blazor.UI.Configuration.Admin;

public static class AdminConfiguratorExtensions
{
	public static AdminConfigurator Configure(this AdminConfigurator adminConfigurator)
	{
		adminConfigurator
			.AddSection("DataSettings")
			.AddSection("IdentitySettings")
			.AddSection("DocumentSettings")
			.AddSection("LoggingSettings")
			.AddSection("NotificationSettings")
			.AddSection("GeneralSettings");
		return adminConfigurator;
	}
}
