using Core.Common.Models;
using Core.Common.Queries;
using Core.Components;
using Methodic.Common.Util;
using Methodic.Core.Services.Impl;

namespace Core.Services.Impl;

internal class TransactionService : Service, ITransactionService
{
	private readonly TransactionComponent _transactionComponent;

	public TransactionService(
		TransactionComponent transactionComponent
	)
	{
		_transactionComponent = transactionComponent;
	}	

	public Result<PageList<TransactionModel>> GetTransactionPage(TransactionQueryInfo queryInfo)
	{
		return _transactionComponent.GetTransactionPage(queryInfo);
	}

	public Result<TransactionModel> GetTransactionById(int id)
	{
		return _transactionComponent.GetTransactionById(id);
	}

	public async Task<Result<TransactionModel>> SaveTransactionAsync(TransactionModel model)
	{
		return await _transactionComponent.SaveTransactionAsync(model);
	}

	public async Task<Result<bool>> DeleteTransactionAsync(TransactionModel model)
	{
		return await _transactionComponent.DeleteTransactionAsync(model);
	}

	public Result<TransactionStatisticsModel> GetStatistics(TransactionQueryInfo queryInfo)
	{
		return _transactionComponent.GetStatistics(queryInfo);
	}

	public Result<List<TransactionSummaryModel>> GetSummary(TransactionQueryInfo queryInfo)
	{
		return _transactionComponent.GetSummary(queryInfo);
	}

	public Result<List<TransactionAnalysisModel>> GetAnalysis()
	{
		return _transactionComponent.GetAnalysis();
	}

	public async Task<Result<bool>> CreateMockTransactionsAsync()
	{
		return await _transactionComponent.CreateMockTransactionsAsync();
	}
}
