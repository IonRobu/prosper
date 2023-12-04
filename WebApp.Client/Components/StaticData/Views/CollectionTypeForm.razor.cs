using Core.Common.Models;
using Methodic.Common.Messages;
using Microsoft.AspNetCore.Components;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;
using WebApp.Backend.Validators;

namespace WebApp.Backend.Components.StaticData.Views;

public partial class CollectionTypeForm
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
	private CollectionTypeModelValidator Validator { get; set; }

	protected override async Task LoadAsync()
	{
		if (Id > 0)
		{
			Model = await StaticDataService.GetCollectionTypeByIdAsync(Id);
		}
	}

	protected override Task<CollectionTypeModel> SaveDataAsync()
	{
		return StaticDataService.SaveCollectionTypeAsync(Model);
	}

	protected override async Task OnEntitySavedAsync(CollectionTypeModel model)
	{
		OnClosed?.Invoke();
		await base.OnEntitySavedAsync(model);
	}

	protected override List<Message> Validate(CollectionTypeModel model)
	{
		return Validator.PerformValidation(model);
	}
}
