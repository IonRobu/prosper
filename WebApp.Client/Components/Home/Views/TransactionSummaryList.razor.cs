using Core.Common.Models;
using Core.Common.Queries;
using Methodic.Common.Models.Common;
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

	//public DateTime? StartValue { get; set; } = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(-7);
	//public DateTime? EndValue { get; set; } = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
	public CalendarView View { get; set; } = CalendarView.Decade;
	public TelerikDateRangePicker<DateTime?> PickerRef { get; set; }

	public TransactionSummaryList()
	{
		LazyBinding = true;
		QueryInfo = new TransactionQueryInfo
		{
			MinDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(-7),
			MaxDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day)
		};
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
		if (value == 0)
		{
			return "text-primary";
		}
		return value > 0 ? "text-success" : "text-danger";
	}

	private FontIcon GetIcon(TransactionModel item)
	{
		return item.Category.IsFixed ? FontIcon.Pin : FontIcon.BorderRadius;
	}

	//private void OnChangeHandler(DateRangePickerChangeEventArgs e)
	//{
	//	QueryInfo.MinDate = (DateTime)e.StartValue;
	//	QueryInfo.MaxDate = (DateTime)e.EndValue;
	//	//Console.WriteLine($"e.Target = {e.Target},e.StartValue = {e.StartValue},e.EndValue = {e.EndValue}");
	//	//PickerRef.Close();
	//}

	async Task ViewChangeHandler(CalendarView currView)
	{
		Console.WriteLine($"The user is now looking at the {currView} calendar view");
	}

	private void SetCalendarView(CalendarView value)
	{
		View = value;
		PickerRef.View = value;
		PickerRef.Refresh();
		StateHasChanged();
	}

	//private List<CommonModel<int>> GetWeeksForYear()
	//{
	//	var jan1 = new DateTime(DateTime.Today.Year, 1, 1);
	//	//beware different cultures, see other answers
	//	var startOfFirstWeek = jan1.AddDays(1 - (int)(jan1.DayOfWeek));
	//	var weeks =
	//		Enumerable
	//			.Range(0, 54)
	//			.Select(i => new {
	//				weekStart = startOfFirstWeek.AddDays(i * 7)
	//			})
	//			.TakeWhile(x => x.weekStart.Year <= jan1.Year)
	//			.Select(x => new {
	//				x.weekStart,
	//				weekFinish = x.weekStart.AddDays(6)
	//			})
	//			.SkipWhile(x => x.weekFinish < jan1.AddDays(1))
	//			.Select((x, i) => new CommonModel<int> {
	//				Name = $"{x.weekStart} - {x.weekFinish}",
	//				Id = i + 1
	//			}).ToList();
	//	return weeks;
	//}
}
