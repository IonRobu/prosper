using Microsoft.AspNetCore.Components;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;

namespace WebApp.Backend.Components.Identity.Views;

public partial class LoginForm
{
	[Parameter]
	public Action OnLoggedIn { get; set; }

	[Parameter]
	public Action OnRecover { get; set; }

	[Inject]
	private AuthService AuthService { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	private async Task LoginAsync()
	{
		var result = await AuthService.LoginAsync(Model);
		if (result?.Token != null)//successfully logged and received token
		{
			OnLoggedIn?.Invoke();
		}
	}
}
