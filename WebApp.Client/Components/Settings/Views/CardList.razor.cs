using Core.Common.Models;
using Core.Common.Queries;
using Methodic.Common.Util;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor;
using Telerik.Blazor.Components;
using Telerik.DataSource;
using WebApp.Client.Services;

namespace WebApp.Client.Components.Settings.Views;

public partial class CardList
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

	private CardQueryInfo QueryInfo { get; set; } = new();

	private TelerikListView<CardModel> list;

	private bool IsAscending { get; set; } = true;

	private bool IsWindowVisible { get; set; }

	public CardList()
	{
		LazyBinding = true;
		SetSortInfo("Name");
	}

	protected async Task ReadItemsAsync(ListViewReadEventArgs args)
	{
		var info = args.Request.GetQueryInfo<CardQueryInfo>();
		QueryInfo.Page = info.Page;
		QueryInfo.PageSize = info.PageSize;
		await LoadAsync();
		args.Data = Source.Items;
		args.Total = Source.Filtered;
	}

	protected override async Task LoadAsync()
	{
		Source = await StaticDataService.GetCardPageAsync(QueryInfo);
	}

	private void Edit(CardModel item = null)
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
		QueryInfo.Number = null;
		RebindGrid();
		StateHasChanged();
	}

	private void SortList(string field)
	{
		IsAscending = !IsAscending;
		SetSortInfo(field);
		RebindGrid();
	}

	private void SetSortInfo(string field)
	{
		QueryInfo.SortInfo.Clear();
		QueryInfo.SortInfo.Add(new SortInfo
		{
			Field = field,
			IsAscending = IsAscending
		});
	}

	private async Task<bool> DeleteAsync(CardModel item)
	{
		var confirmed = await Dialogs.ConfirmAsync("Are you sure you want to delete?", "Confirm operation");
		if (confirmed)
		{
			var result = await StaticDataService.DeleteCardAsync(item);
			RebindGrid();
			StateHasChanged();
			return result;
		}
		return false;
	}
}
