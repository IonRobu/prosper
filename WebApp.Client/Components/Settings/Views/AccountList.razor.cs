using Core.Common.Models;
using Core.Common.Queries;
using Methodic.Common.Util;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor;
using Telerik.Blazor.Components;
using Telerik.DataSource;
using WebApp.Client.Services;

namespace WebApp.Client.Components.Settings.Views;

public partial class AccountList
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

	private AccountQueryInfo QueryInfo { get; set; } = new();

	private TelerikListView<AccountModel> list;

	private bool IsAscending { get; set; } = true;

	private bool IsWindowVisible { get; set; }

	private string SortText => "Name " + (IsAscending ? "descending" : "ascending");

	public AccountList()
	{
		LazyBinding = true;
		SetSortInfo();
	}

	protected async Task ReadItemsAsync(ListViewReadEventArgs args)
	{
		var info = args.Request.GetQueryInfo<AccountQueryInfo>();
		QueryInfo.Page = info.Page;
		QueryInfo.PageSize = info.PageSize;
		await LoadAsync();
		args.Data = Source.Items;
		args.Total = Source.Filtered;
	}

	protected override async Task LoadAsync()
	{
		Source = await StaticDataService.GetAccountPageAsync(QueryInfo);
	}

	private void Edit(AccountModel item = null)
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

	private async Task<bool> DeleteAsync(AccountModel item)
	{
		var confirmed = await Dialogs.ConfirmAsync("Are you sure you want to delete?", "Confirm operation");
		if (confirmed)
		{
			var result = await StaticDataService.DeleteAccountAsync(item);
			RebindGrid();
			StateHasChanged();
			return result;
		}
		return false;
	}
}
