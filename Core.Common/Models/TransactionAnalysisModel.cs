using Methodic.Common.Models;

namespace Core.Common.Models;

public class TransactionAnalysisModel : Model
{
	public int Year { get; set; }

	public decimal TotalAmount { get; set; }
}