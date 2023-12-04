using Core.Common.Models;
using Core.Common.Models.Enums;
using Core.Common.Rules;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor;
using Telerik.Blazor.Components;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;

namespace WebApp.Backend.Components.Form.Views;

public partial class FormDetail
{
	[Parameter]
	public long Id { get; set; }

	[Parameter]
	public Action OnClosed { get; set; }

	[Parameter]
	public Action<long> OnEdit { get; set; }

	[Parameter]
	public Action<long> OnStepDetail { get; set; }

	[CascadingParameter]
	public DialogFactory Dialogs { get; set; }

	[Inject]
	private FormService FormService { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	[Inject]
	private EnumRule EnumRule { get; set; }

	[Inject]
	private EnumData EnumData { get; set; }

	private FormStepModel Step { get; set; } = new();

	private FormUsageModel Usage { get; set; } = new();

	public int ActiveTabIndex { get; set; }

	private bool _isStepWindowVisible;

	private bool _isUsageWindowVisible;

	protected override async Task LoadAsync()
	{
		if (Id > 0)
		{
			Model = await FormService.GetFormByIdAsync(Id);
		}
	}

	protected async override Task OnParametersSetAsync()
	{
		if (Id > 0)//todo - solve bug
		{
			Model = await FormService.GetFormByIdAsync(Id);
		}
		await base.OnParametersSetAsync();
	}

	private void Edit()
	{
		OnEdit?.Invoke(Model.Id);
	}

	private void EditStep(FormStepModel selected = null)
	{
		Step = new()
		{
			Name = selected?.Name,
			Code = selected?.Code,
			Description = selected?.Description,
			Form = new FormModel { Id = Model.Id }
		};
		if (selected != null)
		{
			Step.Id = selected.Id;
			Step.Position = selected.Position;
			Step.Type = selected.Type;
		}
		_isStepWindowVisible = true;
		StateHasChanged();
	}

	private async Task SaveStepAsync()
	{
		await FormService.SaveFormStepAsync(Step);
		_isStepWindowVisible = false;
		await LoadAsync();
	}

	private void DetailStep(FormStepModel selected)
	{
		OnStepDetail?.Invoke(selected.Id);
	}

	private void OnStepTypeChange(EnumStepType value)
	{
		Step.Type = value;
		StateHasChanged();
	}

	private async Task StepDropAsync(GridRowDropEventArgs<FormStepModel> args)
	{
		var model = args.Item;
		model.Form = new FormModel { Id = Model.Id };
		await FormService.SetStepPositionAsync(model, int.Parse(args.DestinationIndex));
		await LoadAsync();
	}

	private async Task DeleteAsync(FormStepModel item)
	{
		var confirmed = await Dialogs.ConfirmAsync(I18n.Text.DeleteItem, I18n.Text.DeleteItemTitle);
		if (confirmed)
		{
			var result = await FormService.DeleteFormStepAsync(item);
			if (result)
			{
				await LoadAsync();
				StateHasChanged();
			}
		}
	}

	private void EditUsage(FormUsageModel selected = null)
	{
		Usage = new()
		{
			Form = new FormModel { Id = Model.Id }
		};
		if (selected != null)
		{
			Usage.Id = selected.Id;
			Usage.ApplicationType = selected.ApplicationType;
			Usage.PersonType = selected.PersonType;
		}
		_isUsageWindowVisible = true;
		StateHasChanged();
	}

	private async Task DeleteUsageAsync(FormUsageModel item)
	{
		var confirmed = await Dialogs.ConfirmAsync(I18n.Text.DeleteItem, I18n.Text.DeleteItemTitle);
		if (confirmed)
		{
			var result = await FormService.DeleteFormUsageAsync(item);
			if (result)
			{
				await LoadAsync();
				StateHasChanged();
			}
		}
	}


	private async Task SaveUsageAsync()
	{
		await FormService.SaveFormUsageAsync(Usage);
		_isUsageWindowVisible = false;
		await LoadAsync();
	}
}