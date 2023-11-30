using Core.Common.Models;
using Methodic.Common.Messages;
using Microsoft.AspNetCore.Components;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;
using WebApp.Backend.Validators;

namespace WebApp.Backend.Components.StaticData.Views;

public partial class MeasureUnitForm
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
	private MeasureUnitModelValidator Validator { get; set; }

	protected override async Task LoadAsync()
	{
		if (Id > 0)
		{
			Model = await StaticDataService.GetMeasureUnitByIdAsync(Id);
		}
	}

	protected override Task<MeasureUnitModel> SaveDataAsync()
	{
		return StaticDataService.SaveMeasureUnitAsync(Model);
	}

	protected override async Task OnEntitySavedAsync(MeasureUnitModel model)
	{
		OnClosed?.Invoke();
		await base.OnEntitySavedAsync(model);
	}

	protected override List<Message> Validate(MeasureUnitModel model)
	{
		return Validator.PerformValidation(model);
	}
}
