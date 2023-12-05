using AutoMapper;
using Core.Common.Models;
using Core.Common.Queries;
using Data.Domain.Static;
using Core.Repositories;
using Data.Contexts;
using LinqKit;
using Methodic.Common.Messages;
using Methodic.Common.Util;
using Methodic.Data.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

internal class AccountRepository : Repository<AccountModel, Account, int>, IAccountRepository
{
	public AccountRepository(
		Context context,
		IMapper mapper,
		Messaging messaging
	) : base(context, mapper, messaging)
	{

	}

	public PageList<AccountModel> GetPage(AccountQueryInfo queryInfo)
	{
		var info = new QueryInfo<Account>(queryInfo);
		info.AddSortInfo(nameof(Account.Name), x => x.Name);
		if (!string.IsNullOrEmpty(queryInfo.Name))
		{
			info.Filter = info.Filter.And(x => EF.Functions.Like(x.Name, $"%{queryInfo.Name}%"));
		}
		return Query()
			.QueryPage<Account, int, AccountModel>(Translate, info);
	}
}

