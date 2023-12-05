using Core.Common.Models;
using Core.Common.Queries;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;
using Telerik.DataSource;
using WebApp.Client.Configuration;
using WebApp.Client.Services;

namespace WebApp.Client.Components.Home.Views;

public partial class TransactionStatisticsView
{
	[Inject]
	private I18n I18n { get; set; }

	[Inject]
	private TransactionService TransactionService { get; set; }

	private TransactionQueryInfo QueryInfo { get; set; } = new();

	private TransactionStatisticsModel Statistics { get; set; } = new();

	protected async Task ReadItemsAsync(ListViewReadEventArgs args)
	{
		var info = args.Request.GetQueryInfo<TransactionQueryInfo>();
		QueryInfo.Page = info.Page;
		QueryInfo.PageSize = info.PageSize;
		//await LoadAsync();
		await GetStatisticsAsync();
		//args.Data = Source.Items;
		//args.Total = Source.Filtered;
	}

	protected override async Task LoadAsync()
	{
		await GetStatisticsAsync();
		// Source = await TransactionService.GetTransactionPageAsync(QueryInfo);
	}

	protected async Task GetStatisticsAsync()
	{
		Statistics = await TransactionService.GetTransactionStatisticsAsync(QueryInfo);
	}

	private string GetAmountCss(decimal value)
	{
		if(value == 0)
		{
			return "text-primary";
		}
		return value > 0 ? "text-success" : "text-danger";
	}
}
