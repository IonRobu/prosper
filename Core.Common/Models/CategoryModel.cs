using Core.Common.Models.Enums;
using Methodic.Common.Models;

namespace Core.Common.Models;

public class CategoryModel : Model
{
	public int Id { get; set; }

	public string Name { get; set; }

	public bool IsFixed { get; set; }

	public EnumCategoryFrequency? Frequency { get; set; }

	public decimal? Amount { get; set; }

	public string Description { get; set; }

	public List<TransactionModel> Transactions { get; set; } = new();
}