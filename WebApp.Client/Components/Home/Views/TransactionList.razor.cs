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

public partial class TransactionList
{
	[Parameter]
	public Action<int> OnDetail { get; set; }

	[Parameter]
	public Action<int> OnEdit { get; set; }

	[Parameter]
	public Action OnAdd { get; set; }

	[CascadingParameter]
	public DialogFactory Dialogs { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	[Inject]
	private StaticDataService StaticDataService { get; set; }

	[Inject]
	private TransactionService TransactionService { get; set; }

	private TransactionQueryInfo QueryInfo { get; set; } = new();

	private TransactionStatisticsModel Statistics { get; set; } = new();

	private List<CategoryModel> CategoryList { get; set; } = new();

	private List<CardModel> CardList { get; set; } = new();

	private List<AccountModel> AccountList { get; set; } = new();

	private CategoryModel SelectedCategory { get; set; } = new();

	private CardModel SelectedCard { get; set; } = new();

	private TelerikListView<TransactionModel> list;

	private bool IsAscending { get; set; } = true;

	private bool IsWindowVisible { get; set; }

	private string SortText => "Name " + (IsAscending ? "descending" : "ascending");

	public TransactionList()
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
		await GetStatisticsAsync();
		args.Data = Source.Items;
		args.Total = Source.Filtered;
	}

	protected override async Task LoadAsync()
	{
		Source = await TransactionService.GetTransactionPageAsync(QueryInfo);
		CategoryList = (await StaticDataService.GetCategoryPageAsync(new CategoryQueryInfo { PageSize = 0 })).Items;
		CardList = (await StaticDataService.GetCardPageAsync(new CardQueryInfo { PageSize = 0 })).Items;
		AccountList = (await StaticDataService.GetAccountPageAsync(new AccountQueryInfo { PageSize = 0 })).Items;
	}

	protected async Task GetStatisticsAsync()
	{
		Statistics = await TransactionService.GetTransactionStatisticsAsync(QueryInfo);
	}

	private void Edit(TransactionModel item = null)
	{
		if (item == null)
		{
			OnAdd?.Invoke();
		}
		else
		{
			OnEdit?.Invoke(item.Id);
		}
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
		SelectedCategory = new();
		SelectedCard = new();
		RebindGrid();
	}

	private void SortList()
	{
		IsAscending = !IsAscending;
		SetSortInfo();
		RebindGrid();
	}

	private void SetSortInfo()
	{
		QueryInfo.SortInfo.Clear();
		QueryInfo.SortInfo.Add(new SortInfo
		{
			Field = "Name",
			IsAscending = IsAscending
		});
	}

	private async Task<bool> DeleteAsync(TransactionModel item)
	{
		var confirmed = await Dialogs.ConfirmAsync("Are you sure you want to delete?", "Confirm operation");
		if (confirmed)
		{
			var result = await TransactionService.DeleteTransactionAsync(item);
			RebindGrid();
			StateHasChanged();
			return result;
		}
		return false;
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

	private void OnCategoryChange(int? value)
	{
		QueryInfo.CategoryId = value;
		SelectedCategory = CategoryList.Single(x => x.Id == value);
		Model.Amount = SelectedCategory.IsFixed ? SelectedCategory.Amount.GetValueOrDefault() : 0;
	}

	private void OnCardChange(int? value)
	{
		QueryInfo.CardId = value;
		SelectedCard = CardList.Single(x => x.Id == value);
	}

	private FontIcon GetIcon(CategoryModel item)
	{
		return item.IsFixed ? FontIcon.Pin : FontIcon.BorderRadius;
	}
}
