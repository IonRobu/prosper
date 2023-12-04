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
using Microsoft.EntityFrameworkCore;

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

	public PageList<TransactionModel> GetPage(TransactionQueryInfo queryInfo)
	{
		var info = new QueryInfo<Transaction>(queryInfo);
		info.AddSortInfo(nameof(Transaction.Name), x => x.Name);
		if (!string.IsNullOrEmpty(queryInfo.Name))
		{
			info.Filter = info.Filter.And(x => x.Name.Contains(queryInfo.Name));
		}
		return Query()
			.Include(x => x.Category)
			.Include(x => x.Card)
			.Include(x => x.Account)
			.QueryPage<Transaction, int, TransactionModel>(Translate, info);
	}

	public TransactionStatisticsModel GetStatistics()
	{
		var model = new TransactionStatisticsModel
		{
			IncomeTotal = Query()
				.Where(x => x.IsIncome)
				.Sum(x => x.Amount),
			ExpenseTotal = Query()
				.Where(x => !x.IsIncome)
				.Sum(x => x.Amount),
			IncomeCount = Query()
				.Count(x => x.IsIncome),
			ExpenseCount = Query()
				.Count(x => !x.IsIncome)
		};
		return model;
	}
}

