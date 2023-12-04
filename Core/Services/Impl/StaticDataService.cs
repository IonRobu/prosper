using Core.Common.Models;
using Core.Common.Queries;
using Core.Components;
using Methodic.Common.Util;
using Methodic.Core.Services.Impl;

namespace Core.Services.Impl;

internal class StaticDataService : Service, IStaticDataService
{
	private readonly StaticDataComponent _staticDataComponent;

	public StaticDataService(
		StaticDataComponent staticDataComponent
	)
	{
		_staticDataComponent = staticDataComponent;
	}	

	public Result<PageList<CategoryModel>> GetCategoryPage(CategoryQueryInfo queryInfo)
	{
		return _staticDataComponent.GetCategoryPage(queryInfo);
	}

	public Result<CategoryModel> GetCategoryById(int id)
	{
		return _staticDataComponent.GetCategoryById(id);
	}

	public async Task<Result<CategoryModel>> SaveCategoryAsync(CategoryModel model)
	{
		return await _staticDataComponent.SaveCategoryAsync(model);
	}

	public async Task<Result<bool>> DeleteCategoryAsync(CategoryModel model)
	{
		return await _staticDataComponent.DeleteCategoryAsync(model);
	}


	public Result<PageList<CardModel>> GetCardPage(CardQueryInfo queryInfo)
	{
		return _staticDataComponent.GetCardPage(queryInfo);
	}

	public Result<CardModel> GetCardById(int id)
	{
		return _staticDataComponent.GetCardById(id);
	}

	public async Task<Result<CardModel>> SaveCardAsync(CardModel model)
	{
		return await _staticDataComponent.SaveCardAsync(model);
	}

	public async Task<Result<bool>> DeleteCardAsync(CardModel model)
	{
		return await _staticDataComponent.DeleteCardAsync(model);
	}


	public Result<PageList<AccountModel>> GetAccountPage(AccountQueryInfo queryInfo)
	{
		return _staticDataComponent.GetAccountPage(queryInfo);
	}

	public Result<AccountModel> GetAccountById(int id)
	{
		return _staticDataComponent.GetAccountById(id);
	}

	public async Task<Result<AccountModel>> SaveAccountAsync(AccountModel model)
	{
		return await _staticDataComponent.SaveAccountAsync(model);
	}

	public async Task<Result<bool>> DeleteAccountAsync(AccountModel model)
	{
		return await _staticDataComponent.DeleteAccountAsync(model);
	}
}
