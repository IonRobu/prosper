using Methodic.Common.Models;

namespace Core.Common.Models;

public class TransactionStatisticsModel : Model
{
	public DateTime TransactionsDate { get; set; }

	public string ShownDate { get; set; }

	public decimal IncomeTotal { get; set; }

	public decimal ExpenseTotal { get; set; }

	public int IncomeCount { get; set; }

	public int ExpenseCount { get; set; }

	public decimal FilteredIncomeTotal { get; set; }

	public decimal FilteredExpenseTotal { get; set; }

	public decimal NetLossTotal => IncomeTotal - ExpenseTotal;

	public decimal FilteredNetLossTotal => FilteredIncomeTotal - FilteredExpenseTotal;
}

