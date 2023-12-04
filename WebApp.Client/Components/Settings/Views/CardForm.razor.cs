using Core.Common.Models;
using Methodic.Common.Messages;
using Microsoft.AspNetCore.Components;
using WebApp.Client.Services;
using WebApp.Client.Validators;

namespace WebApp.Client.Components.Settings.Views;

public partial class CardForm
{
	[Parameter]
	public long Id { get; set; }

	[Parameter]
	public Action OnClosed { get; set; }

	[Inject]
	private StaticDataService StaticDataService { get; set; }

	[Inject]
	private CardModelValidator Validator { get; set; }

	protected override async Task LoadAsync()
	{
		if (Id > 0)
		{
			Model = await StaticDataService.GetCardByIdAsync(Id);
		}
	}

	protected override Task<CardModel> SaveDataAsync()
	{
		return StaticDataService.SaveCardAsync(Model);
	}

	protected override async Task OnEntitySavedAsync(CardModel model)
	{
		OnClosed?.Invoke();
		await base.OnEntitySavedAsync(model);
	}

	protected override List<Message> Validate(CardModel model)
	{
		return Validator.PerformValidation(model);
	}
}
