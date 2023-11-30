using ProsperDaily.Abstractions;
using Humanizer;
using SQLiteNetExtensions.Attributes;

namespace Prosper.MVVM.Models;

public class Transaction : TableData
{
	public int CategoryId { get; set; }

	public int AccountId { get; set; }

	public int CardId { get; set; }

	public string Name { get; set; }
	public decimal Amount { get; set; }
	public bool IsIncome { get; set; }
	public DateTime OperationDate { get; set; } = DateTime.UtcNow;
	public string HumanDate => OperationDate.Humanize();

	[OneToOne(CascadeOperations = CascadeOperation.CascadeRead)]
	public TransactionCategory Category { get; set; }

	[OneToOne(CascadeOperations = CascadeOperation.CascadeRead)]
	public Account Account { get; set; }

	[OneToOne(CascadeOperations = CascadeOperation.CascadeRead)]
	public Card Card { get; set; }
}