using Core.Common.Models;
using Core.Common.Queries;
using Methodic.Common.Models.Common;
using Microsoft.AspNetCore.Components;
using System.Globalization;
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

	private List<CommonModel<int>> YearList { get; set; } = new();

	private List<CommonModel<int>> MonthList { get; set; } = new();

	private CardModel SelectedCard { get; set; } = new();

	private int? SelectedYear { get; set; }

	private int? SelectedMonth { get; set; }

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
		SetYears();
		SetMonths();
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
		SelectedYear = null;
		SelectedMonth = null;
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

	private void SetYears()
	{
		YearList.Clear();
		var firstYear = DateTime.UtcNow.Year - 5;
		for (int i = firstYear; i < firstYear + 10; i++)
		{
			YearList.Add(new CommonModel<int> { Id = i, Name = i.ToString() });
		}
	}

	private void SetMonths()
	{
		MonthList.Clear();
		var names = DateTimeFormatInfo.CurrentInfo.MonthNames;
		for (int i = 0; i < names.Length - 1; i++)
		{
			MonthList.Add(new CommonModel<int> { Id = i + 1, Name = names[i] });
		}
	}

	private void YearChanged(int? value)
	{
		SelectedYear = value;
		ComputeDates();
	}

	private void MonthChanged(int? value)
	{
		SelectedMonth = value;
		ComputeDates();
	}

	private void ComputeDates()
	{
		if (SelectedYear != null && SelectedMonth != null)
		{
			QueryInfo.MinDate = new DateTime(SelectedYear.Value, SelectedMonth.Value, DateTime.UtcNow.Day);
			QueryInfo.MaxDate = QueryInfo.MinDate.Value.AddDays(7);
		}
		StateHasChanged();
	}
}
