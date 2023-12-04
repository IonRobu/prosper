using Microsoft.AspNetCore.Components;
using WebApp.Backend.Configuration;

namespace WebApp.Backend.Components.Identity.Pages;

public partial class EmailConfirmPage
{
	[Parameter]
	[SupplyParameterFromQuery]
	public string Token { get; set; }

	[Parameter]
	[SupplyParameterFromQuery]
	public string Email { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	public async Task GoToPasswordConfirmAsync()
	{
		await Navigation.GoToAsync(RouteIndex, typeof(PasswordConfirmPage));
	}
}
