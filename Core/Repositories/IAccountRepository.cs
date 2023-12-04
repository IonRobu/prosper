using Core.Common.Models;
using Core.Common.Queries;
using Methodic.Common.Util;
using Methodic.Core.Repositories;

namespace Core.Repositories;

public interface IAccountRepository : IRepository<AccountModel, int>
{
	PageList<AccountModel> GetCardPage(AccountQueryInfo queryInfo);
}
