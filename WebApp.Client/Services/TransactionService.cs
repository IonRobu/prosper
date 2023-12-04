﻿using Core.Common.Models;
using Core.Common.Queries;
using Core.Common.Util;
using Methodic.Blazor.UI.Configuration;
using Methodic.Blazor.UI.Services;
using Methodic.Common.Util;

namespace WebApp.Client.Services;

public class TransactionService : HttpServiceBase
{
	protected override string BaseUrl => "api/transaction";

	public TransactionService(
		HttpClient client,
		AppSettings appSettings
	) : base(client, appSettings)
	{

	}

	public async Task<PageList<TransactionModel>> GetTransactionPageAsync(TransactionQueryInfo queryInfo)
	{
		var result = await RequestAsync(RouteHelper.Transaction.GetPage, queryInfo, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<PageList<TransactionModel>>();
		return result;
	}

	public async Task<TransactionModel> GetTransactionByIdAsync(long id)
	{
		var result = await RequestAsync($"{RouteHelper.Transaction.GetById}?id={id}", opts =>
		{
			opts.AsGetMethod();
		})
		.ResponseAsync<TransactionModel>();
		return result;
	}

	public async Task<TransactionModel> SaveTransactionAsync(TransactionModel model)
	{
		var result = await RequestAsync(RouteHelper.Transaction.Save, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<TransactionModel>();
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
}