using Methodic.Common.Models;

namespace Core.Common.Models;

public class TransactionModel : Model
{
	public int CategoryId { get; set; }

	public int AccountId { get; set; }

	public int CardId { get; set; }

	public string Name { get; set; }

	public decimal Amount { get; set; }

	public bool IsIncome { get; set; }

	public DateTime OperationDate { get; set; } = DateTime.UtcNow;

	public CategoryModel Category { get; set; } = new();

	public AccountModel Account { get; set; } = new();

	public CardModel Card { get; set; } = new();
}