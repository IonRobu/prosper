using Core.Common.Models;
using Core.Common.Queries;
using Methodic.Common.Util;
using Methodic.Core.Repositories;

namespace Core.Repositories;

public interface ITransactionRepository : IRepository<TransactionModel, int>
{
	PageList<TransactionModel> GetPage(TransactionQueryInfo queryInfo);

	TransactionStatisticsModel GetStatistics(TransactionQueryInfo queryInfo);

	List<TransactionSummaryModel> GetSummary(TransactionQueryInfo queryInfo);

	List<TransactionAnalysisModel> GetAnalysis();
}
