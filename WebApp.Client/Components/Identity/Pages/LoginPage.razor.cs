using Microsoft.AspNetCore.Components;
using WebApp.Backend.Components.Home.Pages;
using WebApp.Backend.Configuration;

namespace WebApp.Backend.Components.Identity.Pages;

public partial class LoginPage
{
	[Inject]
	private I18n I18n { get; set; }

	public async Task GoAsync()
	{
		await Navigation.ClearAsync();
		await Navigation.GoToAsync(RouteIndex, typeof(IndexPage));
	}

	public async Task GoToRecoverAsync()
	{
		await Navigation.GoToAsync(RouteIndex, typeof(PasswordRecoveryPage));
	}
}
