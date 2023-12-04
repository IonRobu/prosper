using Methodic.Blazor.UI.Configuration;
using Methodic.Blazor.UI.Configuration.Localization;
using Methodic.Blazor.UI.Shared.Layout;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApp.Client.I18nText;

namespace WebApp.Client.Configuration.Extensions;

public static class ConfigureExtensions
{
	public static async Task<Navigation> ConfigureAsync(this Navigation navigation)
	{
		await navigation.InitAsync();
		return navigation;
	}

	public static async Task<I18nProvider> ConfigureAsync(this I18nProvider i18nProvider)
	{
		var component = new MxPage();
		//await i18nProvider.AddTableAsync<LocalMessage>(component);
		//await i18nProvider.AddTableAsync<LocalEnums>(component);
		//await i18nProvider.AddTableAsync<LocalLabels>(component);
		//await i18nProvider.AddTableAsync<LocalModel>(component);
		//await i18nProvider.AddTableAsync<LocalText>(component);
		await i18nProvider.AddTableAsync<LocalTitle>(component);

		return i18nProvider;
	}

	public static AppSettings Configure(this AppSettings appSettings, I18n i18nProvider)
	{
		appSettings.SetJsonOptions(new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true,
			ReferenceHandler = ReferenceHandler.Preserve,
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
		});
		return appSettings;
	}
}
