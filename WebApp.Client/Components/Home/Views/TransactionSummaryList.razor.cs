using Core.Common.Models;
using Core.Common.Queries;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;
using Telerik.DataSource;
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

	private bool IsWindowVisible { get; set; }

	private List<CardModel> CardList { get; set; } = new();

	private List<AccountModel> AccountList { get; set; } = new();

	private CardModel SelectedCard { get; set; } = new();

	public TransactionSummaryList()
	{
		LazyBinding = true;
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
		CardList = (await StaticDataService.GetCardPageAsync(new CardQueryInfo { PageSize = 0 })).Items;
		AccountList = (await StaticDataService.GetAccountPageAsync(new AccountQueryInfo { PageSize = 0 })).Items;
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
		QueryInfo.MinDate = null;
		QueryInfo.MaxDate = null;
		QueryInfo.CategoryId = null;
		QueryInfo.CardId = null;
		QueryInfo.AccountId = null;
		SelectedCard = new();
		RebindGrid();
	}

	private string GetAmountCss(decimal value)
	{
		if (value == 0)
		{
			return "text-primary";
		}
		return value > 0 ? "text-success" : "text-danger";
	}

	private void OnCardChange(int? value)
	{
		QueryInfo.CardId = value;
		SelectedCard = CardList.Single(x => x.Id == value);
	}
}
