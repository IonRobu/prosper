using Methodic.Common.Models;
using Methodic.Common.Util;

namespace WebApp.UI.Configuration;

public class EnumData : EnumDataBase
{
	//public List<EnumModel<EnumFieldType>> FieldTypeList => GetEnumModelList<EnumFieldType>();

	//public List<EnumModel<EnumFieldListType>> FieldListTypeList => GetEnumModelList<EnumFieldListType>();

	//public List<EnumModel<EnumApplicationType>> ApplicationTypeList => GetEnumModelList<EnumApplicationType>();

	//public List<EnumModel<EnumApplicationStatus>> ApplicationStatusList => GetEnumModelList<EnumApplicationStatus>();

	//public List<EnumModel<EnumStepType>> StepTypeList => GetEnumModelList<EnumStepType>();

	//public List<EnumModel<EnumPersonType>> PersonTypeList => GetEnumModelList<EnumPersonType>();

	//public List<EnumModel<EnumSpeciesType>> SpeciesTypeList => GetEnumModelList<EnumSpeciesType>();


	private List<EnumModel<TEnum>> GetEnumModelList<TEnum>()
		where TEnum : Enum
	{
		return GetEnumModelList<TEnum>(x => x.ToString());
	}
}
