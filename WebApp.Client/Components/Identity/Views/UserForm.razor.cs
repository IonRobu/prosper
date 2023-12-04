using Core.Common.Models.Identity;
using Microsoft.AspNetCore.Components;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;

namespace WebApp.Backend.Components.Identity.Views;

public partial class UserForm
{
	[Parameter]
	public long Id { get; set; }

	[Parameter]
	public Action OnClosed { get; set; }

	[Inject]
	private IdentityService IdentityService { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	protected override async Task LoadAsync()
	{
		if (Id > 0)
		{
			Model = await IdentityService.GetUserAsync(Id);
		}
	}

	protected override Task<UserModel> SaveDataAsync()
	{
		return IdentityService.SaveUserAsync(Model);
	}

	protected override async Task OnEntitySavedAsync(UserModel model)
	{
		OnClosed?.Invoke();
		await base.OnEntitySavedAsync(model);
	}
}
