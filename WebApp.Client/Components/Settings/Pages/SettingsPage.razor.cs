using Methodic.Blazor.UI.Configuration;
using Microsoft.AspNetCore.Components;

namespace WebApp.Client.Components.Settings.Pages;

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

	[RouteName]
	public const string RouteAccountList = "account-list";

	[RouteName]
	public const string RouteAccountForm = "account-form";

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
			case "Account":
				route = RouteAccountList;
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
			case "Account":
				route = RouteAccountForm;
				break;
		}
		await Navigation.GoToAsync(route, id);
	}
}