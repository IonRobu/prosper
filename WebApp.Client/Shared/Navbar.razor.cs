using Methodic.Blazor.UI.Configuration;
using Microsoft.AspNetCore.Components;
using WebApp.Client.Components.Identity.Pages;
using WebApp.Client.Configuration;
using WebApp.Client.Services;

namespace WebApp.Client.Shared;

public partial class Navbar
{
	[Inject]
	private IdentityService IdentityService { get; set; }

	[Inject]
	private Navigation Navigation { get; set; }

	[Inject]
	private ProfileData ProfileData { get; set; }

	protected async override Task OnInitializedAsync()
	{
		await ProfileData.InitAsync();
		await base.OnInitializedAsync();
	}

	private async Task SignOutAsync()
	{
		await IdentityService.LogoutAsync();
		await Navigation.ClearAsync();
		await Navigation.GoToAsync(LoginPage.RouteIndex, typeof(LoginPage));
	}
}
