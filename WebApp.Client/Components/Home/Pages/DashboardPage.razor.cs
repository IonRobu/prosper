using Methodic.Blazor.UI.Configuration;
using Microsoft.AspNetCore.Components;

namespace WebApp.Client.Components.Home.Pages;

public partial class DashboardPage
{
	[Parameter]
	public int Id { get; set; }

	[RouteName]
	public const string RouteTransactionList = "transaction-list";

	[RouteName]
	public const string RouteTransactionForm = "transaction-form";

	public async Task GoToListAsync()
	{
		await Navigation.GoToAsync(RouteTransactionForm);

	}

	public async Task GoToFormAsync(int id)
	{
		await Navigation.GoToAsync(RouteTransactionForm, id);
	}
}