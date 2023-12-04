using Core.Common.Models;
using Core.Common.Queries;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor;
using Telerik.Blazor.Components;
using Telerik.DataSource;
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
	private StaticDataService StaticDataService { get; set; }

	[Inject]
	private TransactionService TransactionService { get; set; }



	//[Inject]
	//private EnumData EnumData { get; set; }

	private TransactionQueryInfo QueryInfo { get; set; } = new();

	private TelerikGrid<TransactionModel> list;

	public TransactionList()
	{
		LazyBinding = true;
	}

	protected async Task ReadItemsAsync(GridReadEventArgs args)
	{
		var info = args.Request.GetQueryInfo<TransactionQueryInfo>();
		QueryInfo.SortInfo = info.SortInfo;
		QueryInfo.Page = info.Page;
		QueryInfo.PageSize = info.PageSize;
		await LoadAsync();
		args.Data = Source.Items;
		args.Total = Source.Filtered;
	}

	protected override async Task LoadAsync()
	{
		Source = await TransactionService.GetTransactionPageAsync(QueryInfo);
	}

	private void Edit(TransactionModel item)
	{
		OnEdit?.Invoke(item.Id);
	}

	protected void ApplyFilter()
	{
		list.Rebind();
	}

	private void ResetFilter()
	{
		QueryInfo.Name = null;
		//QueryInfo.Type = null;
		//QueryInfo.Phylum = null;
		ApplyFilter();
	}

	private void Form()
	{
		OnAdd?.Invoke();
	}
}
