using Core.Common.Models.Identity;
using Methodic.Common.Messages;
using Microsoft.AspNetCore.Components;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;
using WebApp.Backend.Validators;

namespace WebApp.Backend.Components.Identity.Views;

public partial class PasswordRecoveryForm
{
	[Parameter]
	public Action OnLogin { get; set; }

	[Inject]
	private AuthService AuthService { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	private bool Freeze { get; set; }

	private bool Succeeded { get; set; }

	[Inject]
	private PasswordRecoveryModelValidator PasswordRecoveryModelValidator { get; set; }

	private async Task SaveWithFreezeAsync()
	{
		Freeze = true;
		Succeeded = await SaveAsync();
		Freeze = false;
		if (Succeeded) //successfully logged and received token
		{
			Model = new();
			StateHasChanged();
		}
	}

	protected override async Task<UserModel> SaveDataAsync()
	{
		var result = await AuthService.GetPasswordTokenAsync(Model.Email);
		if (!result)
		{
			return null;
		}
		return new UserModel();
	}

	protected override List<Message> Validate(UserModel model)
	{
		return PasswordRecoveryModelValidator.PerformValidation(model);
	}
}
