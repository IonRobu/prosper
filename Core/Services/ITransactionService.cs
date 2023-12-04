using Core.Common.Models;
using Core.Common.Queries;
using Methodic.Common.Util;
using Methodic.Core.Services;

namespace Core.Services;

public interface ITransactionService : IService
{
	Result<PageList<TransactionModel>> GetTransactionPage(TransactionQueryInfo queryInfo);

	Result<TransactionModel> GetTransactionById(int id);

	Task<Result<TransactionModel>> SaveTransactionAsync(TransactionModel model);

	Result<TransactionStatisticsModel> GetStatistics(TransactionQueryInfo queryInfo);
}
