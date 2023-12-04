using Methodic.Data.Domain.Base;
using Core.Data.Domain.Static;

namespace Core.Core.Data.Domain.Business;

public class Transaction: BusinessEntity<int>
{
	public int CategoryId { get; set; }

	public int AccountId { get; set; }

	public int CardId { get; set; }

	public string Name { get; set; }

	public decimal Amount { get; set; }

	public bool IsIncome { get; set; }

	public DateTime OperationDate { get; set; } = DateTime.UtcNow;

	public Category Category { get; set; } = new();

	public Account Account { get; set; } = new();

	public Card Card { get; set; } = new();
}