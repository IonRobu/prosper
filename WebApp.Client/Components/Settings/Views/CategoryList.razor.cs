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

namespace WebApp.Client.Components.Settings.Views;

public partial class CategoryList
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

	private CategoryQueryInfo QueryInfo { get; set; } = new();

	private TelerikListView<CategoryModel> list;

	private bool IsAscending { get; set; } = true;

	private bool IsWindowVisible { get; set; }

	public List<CommonModel<bool?>> IsFixedOptions { get; set; } = new();

	public CategoryList()
	{
		LazyBinding = true;
		IsFixedOptions = new List<CommonModel<bool?>>
		{
			new CommonModel<bool?> { Name = "", Id = null },
			new CommonModel<bool?> { Name = "Yes", Id = true },
			new CommonModel<bool?> { Name = "No", Id = false }
		};
		SetSortInfo("Name");
	}

	protected async Task ReadItemsAsync(ListViewReadEventArgs args)
	{
		var info = args.Request.GetQueryInfo<CategoryQueryInfo>();
		QueryInfo.Page = info.Page;
		QueryInfo.PageSize = info.PageSize;
		await LoadAsync();
		args.Data = Source.Items;
		args.Total = Source.Filtered;
	}

	protected override async Task LoadAsync()
	{
		Source = await StaticDataService.GetCategoryPageAsync(QueryInfo);
	}

	private void Edit(CategoryModel item = null)
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
		QueryInfo.IsFixed = null;
		RebindGrid();
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

	private async Task<bool> DeleteAsync(CategoryModel item)
	{
		var confirmed = await Dialogs.ConfirmAsync("Are you sure you want to delete?", "Confirm operation");
		if (confirmed)
		{
			var result = await StaticDataService.DeleteCategoryAsync(item);
			RebindGrid();
			StateHasChanged();
			return result;
		}
		return false;
	}

	private string GetTextClass(CategoryModel item)
	{
		return item.IsFixed ? "" : "text-muted";
	}

	private FontIcon GetIcon(CategoryModel item)
	{
		return item.IsFixed ? FontIcon.Pin : FontIcon.BorderRadius;
	}
}
