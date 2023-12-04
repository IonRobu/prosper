using Core.Common.Models;
using Core.Common.Models.Enums;
using Methodic.Common.Models.Common;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor;
using Telerik.Blazor.Components;
using Telerik.FontIcons;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;

namespace WebApp.Backend.Components.Form.Views;

public partial class FormStepDetail
{
	[Parameter]
	public long Id { get; set; }

	[Parameter]
	public Action OnClosed { get; set; }

	[CascadingParameter]
	public DialogFactory Dialogs { get; set; }

	[Inject]
	private FormService FormService { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	private List<FieldModel> Fields { get; set; } = new();

	private StepFieldModel StepField { get; set; } = new();

	private List<CommonModel<string>> ExceptionItemList { get; set; } = new();

	private bool _isWindowVisible;

	protected override async Task LoadAsync()
	{
		if (Id > 0)
		{
			Model = await FormService.GetFormStepByIdAsync(Id);
		}
		Fields = await FormService.GetFieldListAsync(new() { PageSize = 0 });
	}

	protected override Task OnLoadedAsync()
	{
		ExceptionItemList.Add(new CommonModel<string> { Id = "N/A", Name = "N/A" });
		ExceptionItemList.Add(new CommonModel<string> { Id = "Yes", Name = "Yes Answer" });
		ExceptionItemList.Add(new CommonModel<string> { Id = "No", Name = "No Answer" });
		return base.OnLoadedAsync();
	}

	private void EditField(StepFieldModel model = null)
	{
		StepField = model != null ?
			model :
			new()
			{
				Field = new(),
				ExceptionValue = ExceptionItemList.Single(x => x.Id == "N/A").Id
			};
		StepField.Step = new FormStepModel { Id = Model.Id };
		_isWindowVisible = true;
		StateHasChanged();
	}

	private async Task<StepFieldModel> SaveStepFieldAsync()
	{
		var result = await FormService.SaveStepFieldAsync(StepField);
		_isWindowVisible = false;
		await LoadAsync();
		StateHasChanged();
		return result;
	}

	private async Task StepFieldDropAsync(GridRowDropEventArgs<StepFieldModel> args)
	{
		var model = args.Item;
		model.Step = new FormStepModel { Id = Model.Id };
		await FormService.SetStepFieldPositionAsync(model, int.Parse(args.DestinationIndex));
		await LoadAsync();
	}

	private FontIcon GetFieldIcon(EnumFieldType type)
	{
		switch (type)
		{
			case EnumFieldType.Question:
				return FontIcon.QuestionCircle;
			case EnumFieldType.Textbox:
				return FontIcon.Textbox;
			case EnumFieldType.Textarea:
				return FontIcon.Textarea;
			case EnumFieldType.DropDown:
				return FontIcon.ListUnordered;
			default:
				return FontIcon.BorderRadius;
		}
	}

	private async Task DeleteAsync(StepFieldModel item)
	{
		var confirmed = await Dialogs.ConfirmAsync(I18n.Text.DeleteItem, I18n.Text.DeleteItemTitle);
		if (confirmed)
		{
			var result = await FormService.DeleteStepFieldAsync(item);
			if (result)
			{
				await LoadAsync();
				StateHasChanged();
			}
		}
	}

	private void OnFieldChanged(long value)
	{
		StepField.Field = Fields.Single(x => x.Id == value);
		StateHasChanged();
	}
}
