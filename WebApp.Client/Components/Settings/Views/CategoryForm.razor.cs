using Core.Common.Models;
using Methodic.Common.Messages;
using Microsoft.AspNetCore.Components;
using WebApp.Client.Configuration;
using WebApp.Client.Services;
using WebApp.Client.Validators;

namespace WebApp.Client.Components.Settings.Views;

public partial class CategoryForm
{
	[Parameter]
	public long Id { get; set; }

	[Parameter]
	public Action OnClosed { get; set; }

	[Inject]
	private StaticDataService StaticDataService { get; set; }

	[Inject]
	private CategoryModelValidator Validator { get; set; }

	[Inject]
	private EnumData EnumData { get; set; }

	protected override async Task LoadAsync()
	{
		if (Id > 0)
		{
			Model = await StaticDataService.GetCategoryByIdAsync(Id);
		}
	}

	protected override Task<CategoryModel> SaveDataAsync()
	{
		return StaticDataService.SaveCategoryAsync(Model);
	}

	protected override async Task OnEntitySavedAsync(CategoryModel model)
	{
		OnClosed?.Invoke();
		await base.OnEntitySavedAsync(model);
	}

	protected override List<Message> Validate(CategoryModel model)
	{
		return Validator.PerformValidation(model);
	}

	protected override Task<bool> OnEntityUpdatingAsync(CategoryModel model)
	{
		if (!model.IsFixed)
		{
			model.Frequency = null;
			model.Amount = null;
		}
		return base.OnEntityUpdatingAsync(model);
	}
}
