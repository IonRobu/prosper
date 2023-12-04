using Microsoft.AspNetCore.Components;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;

namespace WebApp.Backend.Components.Identity.Views;

public partial class EmailConfirmDetail
{
	[Parameter]
	public string Token { get; set; }

	[Parameter]
	public string Email { get; set; }

	[Parameter]
	public Action OnPasswordConfirm { get; set; }

	[Inject]
	private AuthService AuthService { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	private bool Succeeded { get; set; }

	protected override async Task OnLoadedAsync()
	{
		Model.Email = Email;
		Model.Token = Token;
		Succeeded = await AuthService.ConfirmEmailAsync(Model);
		await base.OnLoadedAsync();
	}
}
