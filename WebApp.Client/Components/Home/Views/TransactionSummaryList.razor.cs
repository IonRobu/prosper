using Core.Common.Models;
using Core.Common.Queries;
using Methodic.Common.Util;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor;
using Telerik.Blazor.Components;
using Telerik.DataSource;
using Telerik.FontIcons;
using WebApp.Client.Configuration;
using WebApp.Client.Services;

namespace WebApp.Client.Components.Home.Views;

public partial class TransactionSummaryList
{
	[Inject]
	private I18n I18n { get; set; }

	[Inject]
	private StaticDataService StaticDataService { get; set; }

	[Inject]
	private TransactionService TransactionService { get; set; }

	private TransactionQueryInfo QueryInfo { get; set; } = new();


	private TelerikListView<TransactionSummaryModel> list;

	private bool IsAscending { get; set; } = true;

	private bool IsWindowVisible { get; set; }

	private string SortText => "Name " + (IsAscending ? "descending" : "ascending");

	public TransactionSummaryList()
	{
		LazyBinding = true;
		SetSortInfo();
	}

	protected async Task ReadItemsAsync(ListViewReadEventArgs args)
	{
		var info = args.Request.GetQueryInfo<TransactionQueryInfo>();
		QueryInfo.Page = info.Page;
		QueryInfo.PageSize = info.PageSize;
		await LoadAsync();
		args.Data = Source;
	}

	protected override async Task LoadAsync()
	{
		Source = await TransactionService.GetTransactionSummaryAsync(QueryInfo);
	}

	protected void RebindGrid()
	{
		list.Rebind();
	}

	protected void ShowFilter()
	{
		IsWindowVisible = true;
		StateHasChanged();
	}

	protected void ApplyFilter()
	{
		IsWindowVisible = false;
		RebindGrid();
		StateHasChanged();
	}

	private void ResetFilter()
	{
		QueryInfo.Name = null;
		RebindGrid();
	}

	private void SortList()
	{
		IsAscending = !IsAscending;
		SetSortInfo();
		RebindGrid();
		StateHasChanged();
	}

	private void SetSortInfo()
	{
		QueryInfo.SortInfo.Clear();
		QueryInfo.SortInfo.Add(new SortInfo
		{
			Field = "CategoryName",
			IsAscending = IsAscending
		});
	}

	private string GetAmountText(TransactionModel item)
	{
		return item.IsIncome ? $"{item.Amount.ToString("#0.00")}" : $"-{item.Amount.ToString("#0.00")}";
	}

	private string GetAmountCss(TransactionModel item)
	{
		return item.IsIncome ? "text-success" : "text-danger";
	}
	private string GetAmountCss(decimal value)
	{
		if(value == 0)
		{
			return "text-primary";
		}
		return value > 0 ? "text-success" : "text-danger";
	}

	private FontIcon GetIcon(TransactionModel item)
	{
		return item.Category.IsFixed ? FontIcon.Pin : FontIcon.BorderRadius;
	}
}
