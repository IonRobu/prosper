using Methodic.Common.Messages;
using Methodic.Common.Models.Identity;
using Microsoft.AspNetCore.Components;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;
using WebApp.Backend.Validators;

namespace WebApp.Backend.Components.Identity.Views;

public partial class PasswordChangeForm
{
	[Parameter]
	public Action OnLoggedIn { get; set; }

	[Inject]
	private IdentityService IdentityService { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	[Inject]
	private PasswordChangeModelValidator PasswordChangeModelValidator { get; set; }

	private bool Freeze { get; set; }

	protected override async Task<PasswordModel> SaveDataAsync()
	{
		var result = await IdentityService.ChangePasswordAsync(Model);
		if (result)
		{
			Model = new();
			StateHasChanged();
		}
		return result ? Model : null;
	}

	protected override List<Message> Validate(PasswordModel model)
	{
		return PasswordChangeModelValidator.PerformValidation(model);
	}
}
