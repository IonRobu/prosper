using Methodic.Common.Messages;
using Methodic.Common.Models.Identity;
using Microsoft.AspNetCore.Components;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;
using WebApp.Backend.Validators;

namespace WebApp.Backend.Components.Identity.Views;

public partial class PasswordConfirmForm
{
	[Parameter]
	public string Token { get; set; }

	[Parameter]
	public string Email { get; set; }

	[Parameter]
	public Action OnLogin { get; set; }

	[Inject]
	private AuthService AuthService { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	private bool Freeze { get; set; }

	private bool Succeeded { get; set; }

	[Inject]
	private PasswordResetModelValidator PasswordResetModelValidator { get; set; }

	private async Task SaveWithFreezeAsync()
	{
		Model.Email = Email;
		Model.Token = Token;
		Freeze = true;
		Succeeded = await SaveAsync();
		Freeze = false;
		if (Succeeded)//successfully logged and received token
		{
			Model = new();
			StateHasChanged();
		}
	}

	protected override async Task<PasswordModel> SaveDataAsync()
	{
		var result = await AuthService.ConfirmPasswordAsync(Model);
		if (!result)
		{
			return null;
		}
		return new PasswordModel();
	}

	protected override List<Message> Validate(PasswordModel model)
	{
		return PasswordResetModelValidator.PerformValidation(model);
	}
}
