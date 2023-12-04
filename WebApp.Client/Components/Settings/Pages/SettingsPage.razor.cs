using Methodic.Blazor.UI.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace WebApp.Client.Components.Settings.Pages;

[Authorize]
public partial class SettingsPage
{
	[Parameter]
	public long Id { get; set; }

	[RouteName]
	public const string RouteCategoryList = "category-list";

	[RouteName]
	public const string RouteCategoryForm = "category-form";

	//[RouteName]
	//public const string RouteCollectionTypeList = "collection-type-list";

	//[RouteName]
	//public const string RouteCollectionTypeForm = "collection-type-form";

	//[RouteName]
	//public const string RouteMeasureUnitList = "measure-unit-list";

	//[RouteName]
	//public const string RouteMeasureUnitForm = "measure-unit-form";

	//[RouteName]
	//public const string RouteSpeciesList = "species-list";

	//[RouteName]
	//public const string RouteSpeciesForm = "species-form";

	//[RouteName]
	//public const string RouteCountryList = "country-list";

	//[RouteName]
	//public const string RouteCountyList = "county-list";

	public async Task GoToListAsync(string item)
	{
		var route = "";
		switch (item)
		{
			case "Category":
				route = RouteCategoryList;
				break;
			//case "CollectionType":
			//	route = RouteCollectionTypeList;
			//	break;
			//case "Species":
			//	route = RouteSpeciesList;
			//	break;
			//case "MeasureUnit":
			//	route = RouteMeasureUnitList;
			//	break;
			//case "Country":
			//	route = RouteCountryList;
			//	break;
			//case "County":
			//	route = RouteCountyList;
			//	break;
		}
		await Navigation.GoToAsync(route);
	}

	public async Task GoToFormAsync(string item, long id)
	{
		var route = "";
		switch (item)
		{
			case "Category":
				route = RouteCategoryForm;
				break;
			//case "CollectionType":
			//	route = RouteCollectionTypeForm;
			//	break;
			//case "Species":
			//	route = RouteSpeciesForm;
			//	break;
			//case "MeasureUnit":
			//	route = RouteMeasureUnitForm;
			//	break;
		}
		await Navigation.GoToAsync(route, id);
	}
}