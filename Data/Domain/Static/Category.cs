using Core.Common.Models.Enums;
using Methodic.Data.Domain.Base;

namespace Data.Domain.Static;

public class Category : StaticEntity<int>
{
	public string Description { get; set; }

	public bool IsFixed { get; set; }

	public EnumCategoryFrequency? Frequency { get; set; }

	public decimal? Amount { get; set; }
}