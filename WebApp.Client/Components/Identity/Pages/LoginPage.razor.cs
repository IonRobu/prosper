using Microsoft.AspNetCore.Components;
using WebApp.Client.Components.Home.Pages;
using WebApp.Client.Configuration;

namespace WebApp.Client.Components.Identity.Pages;

public partial class LoginPage
{
	[Inject]
	private I18n I18n { get; set; }

	public async Task GoAsync()
	{
		await Navigation.ClearAsync();
		await Navigation.GoToAsync(RouteIndex, typeof(DashboardPage));
	}
}
