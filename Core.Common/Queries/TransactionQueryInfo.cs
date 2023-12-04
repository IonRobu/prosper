using Methodic.Common.Util;

namespace Core.Common.Queries;

public class TransactionQueryInfo : QueryInfo
{
	public string Name { get; set; }

	public decimal? MinAmount { get; set; }

	public decimal? MaxAmount { get; set; }

	public DateTime? MinDate { get; set; }

	public DateTime? MaxDate { get; set;}

	public int? CategoryId {  get; set; }

	public int? CardId { get; set; }

	public int? AccountId { get; set; }

	public bool? IsIncome { get; set; }
}
