using Core.Common.Models;
using Methodic.Common.Messages;
using Microsoft.AspNetCore.Components;
using WebApp.Client.Services;
using WebApp.Client.Validators;

namespace WebApp.Client.Components.Settings.Views;

public partial class AccountForm
{
	[Parameter]
	public long Id { get; set; }

	[Parameter]
	public Action OnClosed { get; set; }

	[Inject]
	private StaticDataService StaticDataService { get; set; }

	[Inject]
	private AccountModelValidator Validator { get; set; }

	protected override async Task LoadAsync()
	{
		if (Id > 0)
		{
			Model = await StaticDataService.GetAccountByIdAsync(Id);
		}
	}

	protected override Task<AccountModel> SaveDataAsync()
	{
		return StaticDataService.SaveAccountAsync(Model);
	}

	protected override async Task OnEntitySavedAsync(AccountModel model)
	{
		OnClosed?.Invoke();
		await base.OnEntitySavedAsync(model);
	}

	protected override List<Message> Validate(AccountModel model)
	{
		return Validator.PerformValidation(model);
	}
}
