using Methodic.Blazor.UI.Configuration.Localization;
using WebApp.Client.I18nText;

namespace WebApp.Client.Configuration;

public class I18n : II18n
{
	private readonly I18nProvider _i18nProvider;

	//private readonly Lazy<LocalText> _text;
	//public LocalText Text => _text.Value;

	//private readonly Lazy<LocalEnums> _enums;
	//public LocalEnums Enums => _enums.Value;


	private readonly Lazy<LocalTitle> _title;
	public LocalTitle Title => _title.Value;


	//private readonly Lazy<LocalModel> _model;
	//public LocalModel Model => _model.Value;

	//private readonly Lazy<LocalMessage> _message;
	//public LocalMessage Message => _message.Value;


	//private readonly Lazy<LocalLabels> _labels;
	//public LocalLabels Labels => _labels.Value;

	public I18n(I18nProvider i18nProvider)
	{
		_i18nProvider = i18nProvider;
		_title = new Lazy<LocalTitle>(() => _i18nProvider.GetTable<LocalTitle>(), true);
		//_model = new Lazy<LocalModel>(() => _i18nProvider.GetTable<LocalModel>(), true);
		//_enums = new Lazy<LocalEnums>(() => _i18nProvider.GetTable<LocalEnums>(), true);
		//_text = new Lazy<LocalText>(() => _i18nProvider.GetTable<LocalText>(), true);
		//_message = new Lazy<LocalMessage>(() => _i18nProvider.GetTable<LocalMessage>(), true);
		//_labels = new Lazy<LocalLabels>(() => _i18nProvider.GetTable<LocalLabels>(), true);
	}

	public async Task<string> GetCurrentLanguageAsync()
	{
		return await _i18nProvider.GetLanguageAsync();
	}

	public async Task SetCurrentLanguageAsync(string language)
	{
		await _i18nProvider.SetLanguageAsync(language);
	}
}
