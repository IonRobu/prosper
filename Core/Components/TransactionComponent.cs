using Core.Common.Models;
using Core.Common.Queries;
using Core.Repositories;
using Methodic.Common.Messages;
using Methodic.Common.Util;
using Methodic.Core.Components;
using Methodic.Core.Configuration.Settings;
using System;

namespace Core.Components;

internal class TransactionComponent : Component
{
	private readonly ITransactionRepository _transactionRepository;
	private readonly ICategoryRepository _categoryRepository;
	private readonly ICardRepository _cardRepository;
	private readonly IAccountRepository _accountRepository;

	private static Random random = new();
	private List<CategoryModel> CategoryList = new();
	private List<CardModel> CardList = new();
	private List<AccountModel> AccountList = new();


	public TransactionComponent(
		Messaging messaging,
		AppSettings appSettings,
		ITransactionRepository transactionRepository,
		ICategoryRepository categoryRepository,
		ICardRepository cardRepository,
		IAccountRepository accountRepository
	) : base(messaging, appSettings)
	{
		_transactionRepository = transactionRepository;
		_categoryRepository = categoryRepository;
		_cardRepository = cardRepository;
		_accountRepository = accountRepository;
		CategoryList = _categoryRepository.GetList();
		CardList = _cardRepository.GetList();
		AccountList = _accountRepository.GetList();
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

	public async Task<Result<bool>> DeleteTransactionAsync(TransactionModel model)
	{
		return await ExecuteAsync<bool>(async result =>
		{
			result.Data = await _transactionRepository.DeleteAsync(model);
		});
	}

	public Result<TransactionStatisticsModel> GetStatistics(TransactionQueryInfo queryInfo)
	{
		return Execute<TransactionStatisticsModel>(result =>
		{
			result.Data = _transactionRepository.GetStatistics(queryInfo);
		});
	}

	public Result<List<TransactionSummaryModel>> GetSummary(TransactionQueryInfo queryInfo)
	{
		return Execute<List<TransactionSummaryModel>>(result =>
		{
			result.Data = _transactionRepository.GetSummary(queryInfo);
		});
	}

	public Result<List<TransactionAnalysisModel>> GetAnalysis()
	{
		return Execute<List<TransactionAnalysisModel>>(result =>
		{
			result.Data = _transactionRepository.GetAnalysis();
		});
	}

	public async Task<Result<bool>> CreateMockTransactionsAsync()
	{
		return await ExecuteAsync<bool>(async result =>
		{
			var items = new List<TransactionModel>();
			for (int i = 0; i < 2000; i++)
			{
				items.Add(CreateMockTransaction());
			}
			await _transactionRepository.SaveAsync(items);
			result.Data = true;
		});
	}

	private TransactionModel CreateMockTransaction()
	{		
		var model = new TransactionModel
		{
			CategoryId = CategoryList[GetRandomInt(0, CategoryList.Count - 1)].Id,
			CardId = CardList[GetRandomInt(0, CardList.Count - 1)].Id,
			AccountId = AccountList[GetRandomInt(0, AccountList.Count - 1)].Id,
			Name = RandomString(15),
			IsIncome = GetRandomBool(),
			Amount = GetRandomDecimal(1, 3500),
			OperationDate = GetRandomDateTime(DateTime.UtcNow.AddYears(-2), DateTime.UtcNow.AddYears(2))
		};
		return model;
	}

	private static int GetRandomInt(int min, int max)
	{
		return random.Next(min, max);
	}

	public static decimal GetRandomDecimal(int min, int max)
	{
		var value = (random.NextDouble() * Math.Abs(max - min)) + min;
		return (decimal)value;
	}

	public static string RandomString(int length)
	{
		const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		return new string(Enumerable.Repeat(chars, length)
			.Select(s => s[random.Next(s.Length)]).ToArray());
	}

	private static bool GetRandomBool()
	{
		return random.Next(2) == 0;
	}

	private static DateTime GetRandomDateTime(DateTime startDate, DateTime endDate)
	{
		var timeSpan = endDate - startDate;
		var newSpan = new TimeSpan(0, random.Next(0, (int)timeSpan.TotalMinutes), 0);
		var newDate = startDate + newSpan;
		return newDate;
	}


}
