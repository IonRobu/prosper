using Core.Common.Models;
using Core.Common.Models.Enums;
using Core.Common.Rules;
using Methodic.Common.Models;
using Methodic.Common.Util.Extensions;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;

namespace WebApp.Backend.Components.Form.Views;

public partial class FieldDetail
{
	[Parameter]
	public long Id { get; set; }

	[Parameter]
	public Action OnClosed { get; set; }

	[Parameter]
	public Action<long> OnEdit { get; set; }

	[CascadingParameter]
	public DialogFactory Dialogs { get; set; }

	[Inject]
	private FormService FormService { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	[Inject]
	private EnumData EnumData { get; set; }

	[Inject]
	private EnumRule EnumRule { get; set; }

	private FieldExplanationModel FieldExplanation { get; set; } = new();

	private bool _isWindowVisible;

	private List<EnumModel<EnumFieldListType>> FieldListTypes
	{
		get
		{
			return EnumData.FieldListTypeList
				.Where(x => EnumRule.GetFieldListTypes(Model.Type).Contains(x.Id))
				.ToList();
		}
	}

	private List<string> ExplanationValues
	{
		get
		{
			return GetExplanationValues();
		}
	}

	protected override async Task LoadAsync()
	{
		if (Id > 0)
		{
			Model = await FormService.GetFieldByIdAsync(Id);
		}
	}

	private void Edit()
	{
		OnEdit?.Invoke(Model.Id);
	}

	private void OnTypeChange(string value)
	{
		FieldExplanation.Value = value;
		StateHasChanged();
	}

	private async Task<FieldExplanationModel> SaveFieldExplanationAsync()
	{
		var result = await FormService.SaveFieldExplanationAsync(FieldExplanation);
		await LoadAsync();
		_isWindowVisible = false;
		return result;
	}

	private void EditFieldExplanation(FieldExplanationModel model = null)
	{
		FieldExplanation = new FieldExplanationModel
		{
			Field = new FieldModel
			{
				Id = Model.Id,
			},
			Id = model!= null ? model.Id : 0,
			Value = model?.Value,
			Explanation = model?.Explanation
		};
		_isWindowVisible = true;
		StateHasChanged();
	}

	private List<string> GetExplanationValues()
	{
		var enumTypeName = $"{Model.ListType.GetType().Namespace}.Enum{Model.ListType}";
		var enumType = typeof(EnumFieldListType).Assembly.GetType(enumTypeName);
		var all = CommonExtensions.GetEnumModelList(enumType);
		var existing = Model.Explanations.Select(x => x.Value).ToList();
		var remaining = all.Except(existing).ToList();
		return remaining;
	}

	private async Task DeleteFieldExplanationAsync(FieldExplanationModel item)
	{
		var confirmed = await Dialogs.ConfirmAsync(I18n.Text.DeleteItem, I18n.Text.DeleteItemTitle);
		if (confirmed)
		{
			var result = await FormService.DeleteFieldExplanationAsync(item);
			if (result)
			{
				await LoadAsync();
				StateHasChanged();
			}
		}
	}
}
