using Core.Configuration.Settings;
using Methodic.Core.Configuration.Settings;

namespace Methodic.Core.Components.Admin;

public class AdminManager : AdminManagerBase
{
	protected override void ConfigureAppSettings()
	{
		ClearAppConfiguration();
		AddAppConfigurationModel<DataSettings>("1.0.8");
		AddAppConfigurationModel<IdentitySettings>("1.0.4");
		AddAppConfigurationModel<DocumentSettings>("1.0.4");
		AddAppConfigurationModel<LoggingSettings>("1.0.3");
		AddAppConfigurationModel<NotificationSettings>("1.0.4");
		SyncAppConfiguration();
	}

	public override AppSettings SetAppSettings(AppSettings appSettings)
	{
		SetSection<DataSettings>(appSettings);
		SetSection<IdentitySettings>(appSettings);
		SetSection<DocumentSettings>(appSettings);
		SetSection<LoggingSettings>(appSettings);
		SetSection<NotificationSettings>(appSettings);
		return appSettings;
	}
}
