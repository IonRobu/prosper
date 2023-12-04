using Core.Common.Models;
using Core.Common.Queries;
using Methodic.Common.Util;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor;
using Telerik.Blazor.Components;
using Telerik.DataSource;
using Toolbelt.Blazor.I18nText.Interfaces;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;

namespace WebApp.Backend.Components.StaticData.Views;

public partial class CollectionList
{
	[Parameter]
	public Action<long> OnDetail { get; set; }

	[Parameter]
	public Action<long> OnEdit { get; set; }

	[Parameter]
	public Action OnAdd { get; set; }

	[CascadingParameter]
	public DialogFactory Dialogs { get; set; }

	[Inject]
	private StaticDataService StaticDataService { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	private CollectionQueryInfo QueryInfo { get; set; } = new();
	private SortInfo SortInfo { get; set; } = new();

	private TelerikListView<CollectionModel> list;

	public CollectionList()
	{
		LazyBinding = true;
	}

	protected async Task ReadItemsAsync(ListViewReadEventArgs args)
	{
		var info = args.Request.GetQueryInfo<CollectionQueryInfo>();
		QueryInfo.Page = info.Page;
		QueryInfo.PageSize = info.PageSize;
		await LoadAsync();
		args.Data = Source.Items;
		args.Total = Source.Filtered;
	}

	protected override async Task LoadAsync()
	{
		Source = await StaticDataService.GetCollectionPageAsync(QueryInfo);
	}

	private void Edit(CollectionModel item)
	{
		OnEdit?.Invoke(item.Id);
	}

	private async Task DeleteAsync(CollectionModel item)
	{
		var confirmed = await Dialogs.ConfirmAsync(I18n.Text.DeleteItem, I18n.Text.DeleteItemTitle);
		if (confirmed)
		{
			var result = await StaticDataService.DeleteCollectionAsync(item);
			if (result)
			{
				list.Rebind();
			}
		}
	}

	private void Form()
	{
		OnAdd?.Invoke();
	}

	private void SetSorter(string field, bool isAscending)
	{
		SortInfo = new SortInfo
		{
			Field = field,
			IsAscending = isAscending
		};
		QueryInfo.SortInfo.Clear();
		QueryInfo.SortInfo.Add(SortInfo);
		list.Rebind();
	}

	private string GetSortLabel(string field, bool isAscending)
	{
		var suffix = isAscending ? "Ascending" : "Descending";
		return I18n.Labels.Get($"CollectionModel_{field.Replace(".", "_")}_{suffix}");
	}

	private void Filter()
	{
		list.Rebind();
	}
	private void ResetFilter()
	{
		QueryInfo.Text = null;
		Filter();
	}
}
