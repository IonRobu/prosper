using Core.Common.Models.Enums;
using Methodic.Common.Models;
using Methodic.Common.Util;
using Toolbelt.Blazor.I18nText.Interfaces;

namespace WebApp.Client.Configuration;

public class EnumData : EnumDataBase
{
	private readonly I18n _i18n;

	public EnumData(I18n i18n)
	{
		_i18n = i18n;
	}

	public List<EnumModel<EnumCategoryFrequency>> CategoryFrequencyList => GetEnumModelList<EnumCategoryFrequency>();

	private List<EnumModel<TEnum>> GetEnumModelList<TEnum>()
		where TEnum : Enum
	{
		return GetEnumModelList<TEnum>(x => _i18n.Enums.Get(x));
	}
}
