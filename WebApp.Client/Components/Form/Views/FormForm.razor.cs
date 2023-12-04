using Core.Common.Models;
using Core.Common.Rules;
using Methodic.Common.Messages;
using Microsoft.AspNetCore.Components;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;
using WebApp.Backend.Validators;

namespace WebApp.Backend.Components.Form.Views;

public partial class FormForm
{
	[Parameter]
	public long Id { get; set; }

	[Parameter]
	public Action OnClosed { get; set; }

	[Inject]
	private FormService FormService { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	[Inject]
	private EnumData EnumData { get; set; }

	[Inject]
	private EnumRule EnumRule { get; set; }

	[Inject]
	private FormModelValidator Validator { get; set; }

	protected override async Task LoadAsync()
	{
		if (Id > 0)
		{
			Model = await FormService.GetFormByIdAsync(Id);
		}
	}

	protected override Task<FormModel> SaveDataAsync()
	{
		return FormService.SaveFormAsync(Model);
	}

	protected override async Task OnEntitySavedAsync(FormModel model)
	{
		OnClosed?.Invoke();
		await base.OnEntitySavedAsync(model);
	}

	//private void OnApplicationTypeChange(EnumApplicationType value)
	//{
	//	Model.ApplicationType = value;
	//	StateHasChanged();
	//}

	//private void OnPersonTypeChange(EnumPersonType value)
	//{
	//	Model.PersonType = value;
	//	StateHasChanged();
	//}

	protected override List<Message> Validate(FormModel model)
	{
		return Validator.PerformValidation(model);
	}
}
