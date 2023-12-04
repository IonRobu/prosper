using Core.Common.Models;
using Microsoft.AspNetCore.Components;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;
using WebApp.Backend.Validators;

namespace WebApp.Backend.Components.StaticData.Views;

public partial class SpeciesForm
{
	[Parameter]
	public long Id { get; set; }

	[Parameter]
	public Action OnClosed { get; set; }

	[Inject]
	private StaticDataService StaticDataService { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	[Inject]
	private FormModelValidator Validator { get; set; }

	protected override async Task LoadAsync()
	{
		if (Id > 0)
		{
			Model = await StaticDataService.GetSpeciesByIdAsync(Id);
		}
	}

	protected override Task<SpeciesModel> SaveDataAsync()
	{
		return StaticDataService.SaveSpeciesAsync(Model);
	}

	protected override async Task OnEntitySavedAsync(SpeciesModel model)
	{
		OnClosed?.Invoke();
		await base.OnEntitySavedAsync(model);
	}

	//protected override List<Message> Validate(FormModel model)
	//{
	//	return Validator.PerformValidation(model);
	//}
}
