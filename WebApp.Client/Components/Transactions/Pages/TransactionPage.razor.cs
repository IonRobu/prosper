using Methodic.Blazor.UI.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace WebApp.Client.Components.Transactions.Pages;

[Authorize]
public partial class TransactionPage
{
	[Parameter]
	public int Id { get; set; }

	[RouteName]
	public const string RouteTransactionForm = "transaction-form";

	public async Task GoToListAsync(int id)
	{
		//var route = "";
		//switch (item)
		//{
		//	case "Category":
		//		route = RouteCategoryList;
		//		break;
		//	case "Card":
		//		route = RouteCardList;
		//		break;
		//	case "Account":
		//		route = RouteAccountList;
		//		break;
		//}
		//await Navigation.GoToAsync(route);
	}

	public async Task GoToFormAsync(int id)
	{
		await Navigation.GoToAsync(RouteTransactionForm, id);
	}
}