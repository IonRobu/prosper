using Core.Common.Models;
using Core.Common.Queries;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor;
using Telerik.Blazor.Components;
using Telerik.DataSource;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;

namespace WebApp.Backend.Components.StaticData.Views;

public partial class SpeciesList
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

	[Inject]
	private EnumData EnumData { get; set; }

	private SpeciesQueryInfo QueryInfo { get; set; } = new();

	private TelerikGrid<SpeciesModel> list;

	public SpeciesList()
	{
		LazyBinding = true;
	}

	protected async Task ReadItemsAsync(GridReadEventArgs args)
	{
		var info = args.Request.GetQueryInfo<SpeciesQueryInfo>();
		QueryInfo.SortInfo = info.SortInfo;
		QueryInfo.Page = info.Page;
		QueryInfo.PageSize = info.PageSize;
		await LoadAsync();
		args.Data = Source.Items;
		args.Total = Source.Filtered;
	}

	protected override async Task LoadAsync()
	{
		Source = await StaticDataService.GetSpeciesPageAsync(QueryInfo);
	}

	private void Edit(SpeciesModel item)
	{
		OnEdit?.Invoke(item.Id);
	}

	protected void FilterSpecies()
	{
		list.Rebind();
	}

	private void ResetFilter()
	{
		QueryInfo.Taxon = null;
		QueryInfo.Type = null;
		QueryInfo.Phylum = null;
		FilterSpecies();
	}

	private void Form()
	{
		OnAdd?.Invoke();
	}
}
