using Core.Common.Models;
using Core.Common.Queries;
using Methodic.Common.Util;
using Methodic.Core.Repositories;

namespace Core.Repositories;

public interface ITransactionRepository : IRepository<TransactionModel, int>
{
	PageList<TransactionModel> GetCategoryPage(TransactionQueryInfo queryInfo);
}
