using Methodic.Common.Queries;
using Methodic.Common.Util;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;
using Telerik.DataSource;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;

namespace WebApp.Backend.Components.StaticData.Views;

public partial class CountryList
{
	[Inject]
	private StaticDataService StaticDataService { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	private UserQueryInfo QueryInfo { get; set; } = new();

	public CountryList()
	{
		LazyBinding = true;
	}

	protected async Task ReadItemsAsync(ListViewReadEventArgs args)
	{
		var info = args.Request.GetQueryInfo<QueryInfo>();
		QueryInfo.SortInfo = info.SortInfo;
		QueryInfo.Page = info.Page;
		QueryInfo.PageSize = info.PageSize;
		await LoadAsync();
		args.Data = Source.Items;
		args.Total = Source.Total;
	}

	protected override async Task LoadAsync()
	{
		Source = await StaticDataService.GetCountryPageAsync(QueryInfo);
	}
}
