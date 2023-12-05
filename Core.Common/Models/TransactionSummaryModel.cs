using Methodic.Common.Models;

namespace Core.Common.Models;

public class TransactionSummaryModel : Model
{
	public string Category { get; set; }

	public decimal IncomeTotal { get; set; }

	public decimal ExpenseTotal { get; set; }

	public int IncomeCount { get; set; }

	public int ExpenseCount { get; set; }

	public decimal NetLossTotal => IncomeTotal - ExpenseTotal;

	public int TotalTransactions => IncomeCount + ExpenseCount;
}

