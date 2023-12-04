using Core.Common.Models;
using Core.Common.Models.Enums;
using Core.Common.Rules;
using Methodic.Common.Messages;
using Methodic.Common.Models;
using Microsoft.AspNetCore.Components;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;
using WebApp.Backend.Validators;

namespace WebApp.Backend.Components.Form.Views;

public partial class FieldForm
{
	[Parameter]
	public long Id { get; set; }

	[Parameter]
	public Action<long> OnClosed { get; set; }

	[Inject]
	private FormService FormService { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	[Inject]
	private EnumData EnumData { get; set; }

	[Inject]
	private EnumRule EnumRule { get; set; }

	[Inject]
	private FieldModelValidator Validator { get; set; }

	private List<EnumModel<EnumFieldListType>> FieldListTypes
	{
		get
		{
			return EnumData.FieldListTypeList
				.Where(x => EnumRule.GetFieldListTypes(Model.Type).Contains(x.Id))
				.ToList();
		}
	}

	protected override async Task LoadAsync()
	{
		if (Id > 0)
		{
			Model = await FormService.GetFieldByIdAsync(Id);
		}
	}

	protected override Task<FieldModel> SaveDataAsync()
	{
		return FormService.SaveFieldAsync(Model);
	}

	protected override async Task OnEntitySavedAsync(FieldModel model)
	{
		OnClosed?.Invoke(model.Id);
		await base.OnEntitySavedAsync(model);
	}

	private void OnTypeChange(EnumFieldType value)
	{
		Model.Type = value;
		StateHasChanged();
	}

	private void OnListTypeChange(EnumFieldListType? value)
	{
		Model.ListType = value;
		StateHasChanged();
	}

	protected override List<Message> Validate(FieldModel model)
	{
		return Validator.PerformValidation(model);
	}
}
