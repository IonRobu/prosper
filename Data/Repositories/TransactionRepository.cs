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
using System.Linq;

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
		var info = GetQueryInfo(queryInfo);
		return Query()
			.Include(x => x.Category)
			.Include(x => x.Card)
			.Include(x => x.Account)
			.QueryPage<Transaction, int, TransactionModel>(Translate, info);
	}

	public TransactionStatisticsModel GetStatistics(TransactionQueryInfo queryInfo)
	{
		var info = GetQueryInfo(queryInfo);
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
				.Count(x => !x.IsIncome),
			FilteredIncomeTotal = Query()
				.Where(x => x.IsIncome)
				.Where(info.Filter)
				.Sum(x => x.Amount),
			FilteredExpenseTotal = Query()
				.Where(x => !x.IsIncome)
				.Where(info.Filter)
				.Sum(x => x.Amount),
			FilteredIncomeCount = Query()
				.Where(info.Filter)
				.Count(x => x.IsIncome),
			FilteredExpenseCount = Query()
				.Where(info.Filter)
				.Count(x => !x.IsIncome),
		};
		return model;
	}

	private QueryInfo<Transaction> GetQueryInfo(TransactionQueryInfo queryInfo)
	{
		var info = new QueryInfo<Transaction>(queryInfo);
		info.AddSortInfo(nameof(Transaction.Name), x => x.Name);
		info.AddSortInfo(nameof(Transaction.Amount), x => x.Amount);
		info.AddSortInfo(nameof(Transaction.IsIncome), x => x.IsIncome);
		info.AddSortInfo(nameof(Transaction.OperationDate), x => x.OperationDate);
		if (!string.IsNullOrEmpty(queryInfo.Name))
		{
			info.Filter = info.Filter.And(x => x.Name.Contains(queryInfo.Name));
		}
		if (queryInfo.MinAmount != null)
		{
			info.Filter = info.Filter.And(x => x.Amount >= queryInfo.MinAmount);
		}
		if (queryInfo.MaxAmount != null)
		{
			info.Filter = info.Filter.And(x => x.Amount <= queryInfo.MaxAmount);
		}
		if (queryInfo.MinDate != null)
		{
			info.Filter = info.Filter.And(x => x.OperationDate >= queryInfo.MinDate);
		}
		if (queryInfo.MaxDate != null)
		{
			info.Filter = info.Filter.And(x => x.OperationDate <= queryInfo.MaxDate.Value.AddDays(1));
		}
		if (queryInfo.CategoryId != null)
		{
			info.Filter = info.Filter.And(x => x.CategoryId == queryInfo.CategoryId);
		}
		if (queryInfo.CardId != null)
		{
			info.Filter = info.Filter.And(x => x.CardId == queryInfo.CardId);
		}
		if (queryInfo.AccountId != null)
		{
			info.Filter = info.Filter.And(x => x.AccountId == queryInfo.AccountId);
		}
		return info;
	}
}

