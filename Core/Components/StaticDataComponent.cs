using Core.Common.Models;
using Core.Common.Queries;
using Core.Repositories;
using Methodic.Common.Messages;
using Methodic.Common.Util;
using Methodic.Core.Components;
using Methodic.Core.Configuration.Settings;

namespace Core.Components;

internal class StaticDataComponent : Component
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly ICardRepository _cardRepository;
	private readonly IAccountRepository _accountRepository;

	public StaticDataComponent(
		Messaging messaging, 
		AppSettings appSettings,
		ICategoryRepository categoryRepository,
		ICardRepository cardRepository,
		IAccountRepository accountRepository
	) : base(messaging, appSettings)
	{
		_categoryRepository = categoryRepository;
		_cardRepository = cardRepository;
		_accountRepository = accountRepository;
	}

	public Result<PageList<CategoryModel>> GetCategoryPage(CategoryQueryInfo queryInfo)
	{
		return Execute<PageList<CategoryModel>>((result) =>
		{
			result.Data = _categoryRepository.GetPage(queryInfo);
		});
	}

	public Result<CategoryModel> GetCategoryById(int id)
	{
		return Execute<CategoryModel>((result) =>
		{
			result.Data = _categoryRepository.GetById(id);
		});
	}

	public async Task<Result<CategoryModel>> SaveCategoryAsync(CategoryModel model)
	{
		return await ExecuteAsync<CategoryModel>(async result =>
		{
			await _categoryRepository.SaveAsync(model);
			result.Data = model;
		});
	}

	public async Task<Result<bool>> DeleteCategoryAsync(CategoryModel model)
	{
		return await ExecuteAsync<bool>(async result =>
		{
			result.Data = await _categoryRepository.DeleteAsync(model);
		});
	}


	public Result<PageList<CardModel>> GetCardPage(QueryInfo queryInfo)
	{
		return Execute<PageList<CardModel>>((result) =>
		{
			result.Data = _cardRepository.GetPage(queryInfo);
		});
	}

	public Result<CardModel> GetCardById(int id)
	{
		return Execute<CardModel>((result) =>
		{
			result.Data = _cardRepository.GetById(id);
		});
	}

	public async Task<Result<CardModel>> SaveCardAsync(CardModel model)
	{
		return await ExecuteAsync<CardModel>(async result =>
		{
			await _cardRepository.SaveAsync(model);
			result.Data = model;
		});
	}


	public Result<PageList<AccountModel>> GetAccountPage(QueryInfo queryInfo)
	{
		return Execute<PageList<AccountModel>>((result) =>
		{
			result.Data = _accountRepository.GetPage(queryInfo);
		});
	}

	public Result<AccountModel> GetAccountById(int id)
	{
		return Execute<AccountModel>((result) =>
		{
			result.Data = _accountRepository.GetById(id);
		});
	}

	public async Task<Result<AccountModel>> SaveAccountAsync(AccountModel model)
	{
		return await ExecuteAsync<AccountModel>(async result =>
		{
			await _accountRepository.SaveAsync(model);
			result.Data = model;
		});
	}
}
