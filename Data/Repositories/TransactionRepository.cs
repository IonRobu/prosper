using AutoMapper;
using Core.Common.Models;
using Core.Common.Queries;
using Data.Domain.Business;
using Core.Repositories;
using Data.Contexts;
using LinqKit;
using Methodic.Common.Messages;
using Methodic.Common.Util;
using Methodic.Data.Repositories.Entities;

namespace Data.Repositories;

internal class TransactionRepository : Repository<TransactionModel, Transaction, int>, ITransactionRepository
{
	public TransactionRepository(
		Context context,
		IMapper mapper,
		Messaging messaging
	) : base(context, mapper, messaging)
	{

	}

	public PageList<TransactionModel> GetCategoryPage(TransactionQueryInfo queryInfo)
	{
		var info = new QueryInfo<Transaction>(queryInfo);
		info.AddSortInfo(nameof(Transaction.Name), x => x.Name);
		if (!string.IsNullOrEmpty(queryInfo.Name))
		{
			info.Filter = info.Filter.And(x => x.Name.Contains(queryInfo.Name));
		}
		return Query()
			.QueryPage<Transaction, int, TransactionModel>(x => Translate(x), info);
	}
}

