using Core.Common.Models;
using Methodic.Common.Messages;
using Microsoft.AspNetCore.Components;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;
using WebApp.Backend.Validators;

namespace WebApp.Backend.Components.StaticData.Views;

public partial class CollectionForm
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
	private CollectionModelValidator Validator { get; set; }

	private List<CollectionTypeModel> TypeList { get; set; } = new();

	protected override async Task LoadAsync()
	{
		if (Id > 0)
		{
			Model = await StaticDataService.GetCollectionByIdAsync(Id);
		}
	}

	protected async override Task OnLoadedAsync()
	{
		TypeList = await StaticDataService.GetCollectionTypeListAsync(new());
		await base.OnLoadedAsync();
	}

	protected override Task<CollectionModel> SaveDataAsync()
	{
		return StaticDataService.SaveCollectionAsync(Model);
	}

	protected override async Task OnEntitySavedAsync(CollectionModel model)
	{
		OnClosed?.Invoke();
		await base.OnEntitySavedAsync(model);
	}

	protected override List<Message> Validate(CollectionModel model)
	{
		return Validator.PerformValidation(model);
	}
}
