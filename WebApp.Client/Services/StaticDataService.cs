using Core.Common.Models;
using Core.Common.Queries;
using Core.Common.Util;
using Methodic.Blazor.UI.Configuration;
using Methodic.Blazor.UI.Services;
using Methodic.Common.Util;

namespace WebApp.Client.Services;

public class StaticDataService : HttpServiceBase
{
	protected override string BaseUrl => "api/staticdata";

	public StaticDataService(
		HttpClient client,
		AppSettings appSettings
	) : base(client, appSettings)
	{

	}

	public async Task<PageList<CategoryModel>> GetCategoryPageAsync(CategoryQueryInfo queryInfo)
	{
		var result = await RequestAsync(RouteHelper.StaticData.GetCategoryPage, queryInfo, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<PageList<CategoryModel>>();
		return result;
	}

	public async Task<CategoryModel> GetCategoryByIdAsync(long id)
	{
		var result = await RequestAsync($"{RouteHelper.StaticData.GetCategoryById}?id={id}", opts =>
		{
			opts.AsGetMethod();
		})
		.ResponseAsync<CategoryModel>();
		return result;
	}

	public async Task<CategoryModel> SaveCategoryAsync(CategoryModel model)
	{
		var result = await RequestAsync(RouteHelper.StaticData.SaveCategory, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<CategoryModel>();
		return result;
	}

	//public async Task<bool> DeleteCollectionAsync(CollectionModel model)
	//{
	//	var result = await RequestAsync(RouteHelper.StaticData.DeleteCollection, model, opts =>
	//	{
	//		opts.AsPostMethod();
	//	})
	//	.ResponseAsync<bool>();
	//	return result;
	//}

	public async Task<PageList<CardModel>> GetCardPageAsync(CardQueryInfo queryInfo)
	{
		var result = await RequestAsync(RouteHelper.StaticData.GetCardPage, queryInfo, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<PageList<CardModel>>();
		return result;
	}

	public async Task<CardModel> GetCardByIdAsync(long id)
	{
		var result = await RequestAsync($"{RouteHelper.StaticData.GetCardById}?id={id}", opts =>
		{
			opts.AsGetMethod();
		})
		.ResponseAsync<CardModel>();
		return result;
	}

	public async Task<CardModel> SaveCardAsync(CardModel model)
	{
		var result = await RequestAsync(RouteHelper.StaticData.SaveCard, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<CardModel>();
		return result;
	}

	public async Task<PageList<AccountModel>> GetAccountPageAsync(AccountQueryInfo queryInfo)
	{
		var result = await RequestAsync(RouteHelper.StaticData.GetAccountPage, queryInfo, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<PageList<AccountModel>>();
		return result;
	}

	public async Task<AccountModel> GetAccountByIdAsync(long id)
	{
		var result = await RequestAsync($"{RouteHelper.StaticData.GetAccountById}?id={id}", opts =>
		{
			opts.AsGetMethod();
		})
		.ResponseAsync<AccountModel>();
		return result;
	}

	public async Task<AccountModel> SaveAccountAsync(AccountModel model)
	{
		var result = await RequestAsync(RouteHelper.StaticData.SaveAccount, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<AccountModel>();
		return result;
	}
}