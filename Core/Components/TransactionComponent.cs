using Core.Common.Models;
using Core.Common.Queries;
using Core.Repositories;
using Methodic.Common.Messages;
using Methodic.Common.Util;
using Methodic.Core.Components;
using Methodic.Core.Configuration.Settings;

namespace Core.Components;

internal class TransactionComponent : Component
{
	private readonly ITransactionRepository _transactionRepository;

	public TransactionComponent(
		Messaging messaging, 
		AppSettings appSettings,
		ITransactionRepository transactionRepository
	) : base(messaging, appSettings)
	{
		_transactionRepository = transactionRepository;
	}

	public Result<PageList<TransactionModel>> GetTransactionPage(TransactionQueryInfo queryInfo)
	{
		return Execute<PageList<TransactionModel>>((result) =>
		{
			result.Data = _transactionRepository.GetPage(queryInfo);
		});
	}

	public Result<TransactionModel> GetTransactionById(int id)
	{
		return Execute<TransactionModel>((result) =>
		{
			result.Data = _transactionRepository.GetById(id);
		});
	}

	public async Task<Result<TransactionModel>> SaveTransactionAsync(TransactionModel model)
	{
		return await ExecuteAsync<TransactionModel>(async result =>
		{
			await _transactionRepository.SaveAsync(model);
			result.Data = model;
		});
	}

	public Result<TransactionStatisticsModel> GetStatistics(TransactionQueryInfo queryInfo)
	{
		return Execute<TransactionStatisticsModel>(result =>
		{
			result.Data = _transactionRepository.GetStatistics(queryInfo);
		});
	}
}
