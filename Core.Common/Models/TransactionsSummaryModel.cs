using Methodic.Common.Models;

namespace Core.Common.Models;

public class TransactionsSummaryModel : Model
{
	public DateTime TransactionsDate { get; set; }

	public string ShownDate { get; set; }

	public decimal TransactionsTotal { get; set; }
}

