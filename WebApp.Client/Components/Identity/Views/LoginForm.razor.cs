using Microsoft.AspNetCore.Components;
using WebApp.Client.Configuration;
using WebApp.Client.Services;

namespace WebApp.Client.Components.Identity.Views;

public partial class LoginForm
{
	[Parameter]
	public Action OnLoggedIn { get; set; }

	[Parameter]
	public Action OnRecover { get; set; }

	[Inject]
	private IdentityService IdentityService { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	private async Task LoginAsync()
	{
		var result = await IdentityService.LoginAsync(Model);
		if (result?.Token != null)//successfully logged and received token
		{
			OnLoggedIn?.Invoke();
		}
	}
}
