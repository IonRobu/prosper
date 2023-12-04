using Methodic.Blazor.UI.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace WebApp.Client.Components.Settings.Pages;

[Authorize]
public partial class SettingsPage
{
	[Parameter]
	public int Id { get; set; }

	[RouteName]
	public const string RouteCategoryList = "category-list";

	[RouteName]
	public const string RouteCategoryForm = "category-form";

	[RouteName]
	public const string RouteCardList = "card-list";

	[RouteName]
	public const string RouteCardForm = "card-form";

	public async Task GoToListAsync(string item)
	{
		var route = "";
		switch (item)
		{
			case "Category":
				route = RouteCategoryList;
				break;
			case "Card":
				route = RouteCardList;
				break;
		}
		await Navigation.GoToAsync(route);
	}

	public async Task GoToFormAsync(string item, int id)
	{
		var route = "";
		switch (item)
		{
			case "Category":
				route = RouteCategoryForm;
				break;
			case "Card":
				route = RouteCardForm;
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