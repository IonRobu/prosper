using Core.Common.Models;
using Core.Common.Models.Enums;
using Methodic.Common.Messages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Telerik.Blazor;
using Toolbelt.Blazor.I18nText.Interfaces;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;

namespace WebApp.Backend.Components.Application.Views;

public partial class ApplicationDetail
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
	private ApplicationService ApplicationService { get; set; }

	[Inject]
	private DocumentService DocumentService { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	private ApplicationStepModel Step { get; set; } = new();

	private ApplicationExtraDataModel ExtraData { get; set; } = new();

	private List<ApplicationFileModel> Files { get; set; } = new();

	private bool _isWindowVisible;

	protected override async Task LoadAsync()
	{
		if (Id > 0)
		{
			Model = await ApplicationService.GetApplicationByIdAsync(Id);
			await GetFilesAsync();
			StateHasChanged();
		}
	}

	private async Task GetFilesAsync()
	{
		var fileTypes = new List<EnumFileType>
		{
			EnumFileType.Summary,
			EnumFileType.Csv,
			EnumFileType.Pic,
			EnumFileType.Others
		};
		//if (new[] { EnumApplicationStatus.Validated, EnumApplicationStatus.Approved }.Contains(Model.Status))
		//{
		//	fileTypes.Add(EnumFileType.Pic);
		//}
		if (Model.PicFileUploaded)
		{
			fileTypes.Add(EnumFileType.PicSigned);
		}
		if (Model.MatFileUploaded)
		{
			fileTypes.Add(EnumFileType.Mat);
		}
		if (Model.IrccFileUploaded)
		{
			fileTypes.Add(EnumFileType.Ircc);
		}
		Files = await DocumentService.GetDocumentsByTypesAsync(Model.PublicId, fileTypes);
		await base.OnLoadedAsync();
	}

	private async Task GetDocumentAsync(ApplicationFileModel model)
	{
		await DocumentService.GetDocumentByIdAsync(model);
	}

	//private async Task DownloadSummaryFileAsync()
	//{
	//	await DocumentService.GetSummaryDocumentAsync(Model);
	//	StateHasChanged();
	//}

	//private async Task DownloadPicFileAsync()
	//{
	//	await DocumentService.GetPicDocumentAsync(Model);
	//	StateHasChanged();
	//}

	//private async Task DownloadPicSignedFileAsync()
	//{
	//	await DocumentService.GetPicSignedDocumentAsync(Model);
	//	StateHasChanged();
	//}

	//private async Task DownloadCnaPicSignedFileAsync()
	//{
	//	await DocumentService.GetCnaPicSignedDocumentAsync(Model);
	//	StateHasChanged();
	//}

	//private async Task DownloadCnaPicFileAsync()
	//{
	//	await DocumentService.GetCnaPicDocumentAsync(Model);
	//	StateHasChanged();
	//}

	//private async Task DownloadIrccFileAsync()
	//{
	//	await DocumentService.GetIrccDocumentAsync(Model);
	//	StateHasChanged();
	//}

	//private async Task DownloadMatFileAsync()
	//{
	//	await DocumentService.GetMatDocumentAsync(Model);
	//	StateHasChanged();
	//}

	//private async Task DownloadCsvFileAsync()
	//{
	//	await DocumentService.GetCsvDocumentAsync(Model);
	//	StateHasChanged();
	//}

	private string GetStatusTag(ApplicationModel item)
	{
		switch (item.Status)
		{
			case EnumApplicationStatus.Created:
				return "badge bg-primary";
			case EnumApplicationStatus.InWork:
				return "badge bg-secondary";
			case EnumApplicationStatus.Completed:
				return "badge bg-info";
			case EnumApplicationStatus.ExtraDataRequested:
				return "badge bg-warning";
			case EnumApplicationStatus.Rejected:
				return "badge bg-danger";
			case EnumApplicationStatus.Approved:
			case EnumApplicationStatus.Validated:
				return "badge bg-success";
			default:
				return "badge bg-secondary";
		}
	}

	private void AddExtraData(ApplicationStepModel step)
	{
		Step = step;
		ExtraData = new()
		{
			Status = EnumApplicationExtraDataStatus.Created,
			StepPosition = step.Position,
			Application = new()
			{
				Id = Model.Id
			}
		};
		_isWindowVisible = true;
		StateHasChanged();
	}

	private async Task<ApplicationExtraDataModel> SaveExtraDataAsync()
	{
		ExtraData.Application = Model;
		var result = await ApplicationService.SaveApplicationExtraDataAsync(ExtraData);
		await LoadAsync();
		_isWindowVisible = false;
		return result;
	}

	private async Task<bool> RequestExtraDataAsync()
	{
		var confirmed = await Dialogs.ConfirmAsync($"Your application status will be changed to {I18n.Enums.Get(EnumApplicationStatus.ExtraDataRequested)}. Are you sure?", "Application detail");
		if (confirmed)
		{
			var result = await ApplicationService.RequestApplicationExtraDataAsync(Model.PublicId);
			await LoadAsync();
			_isWindowVisible = false;
			StateHasChanged();
			return result;
		}
		return false;
	}

	private async Task SetStatusAsync(EnumApplicationStatus status)
	{
		var confirmed = await Dialogs.ConfirmAsync($"Your application status will be changed to {I18n.Enums.Get(status)}. Are you sure?", "Application detail");
		if (confirmed)
		{
			var result = false;
			switch (status)
			{
				case EnumApplicationStatus.Approved:
					result = await ApplicationService.ApproveApplicationAsync(Model.PublicId);
					break;
				case EnumApplicationStatus.Rejected:
					result = await ApplicationService.RejectApplicationAsync(Model.PublicId);
					break;
				case EnumApplicationStatus.Validated:
					result = await ApplicationService.ValidateApplicationAsync(Model.PublicId);
					break;
					//case EnumApplicationStatus.c:
					//	result = await ApplicationService.ApproveApplicationAsync(Model.PublicId);
					//	break;
			}

			if (result)
			{
				await LoadAsync();
			}
		}
	}

	private string GetValueOrDefault(string value)
	{
		if (!string.IsNullOrEmpty(value))
		{
			return value;
		}
		return "-";
	}

	public bool CanBeApproved()
	{
		return Model.Status == EnumApplicationStatus.Validated && !Model.ExtraData.Any(x => x.Status != EnumApplicationExtraDataStatus.Solved);
	}

	public bool CanBeRejected()
	{
		return Model.Status != EnumApplicationStatus.Approved;
	}

	public bool CanBeValidated()
	{
		return Model.Status == EnumApplicationStatus.Completed && !Model.ExtraData.Any(x => x.Status != EnumApplicationExtraDataStatus.Solved);
	}

	public bool CanAddExtraData()
	{
		return new[] {
			EnumApplicationStatus.Completed,
			EnumApplicationStatus.ExtraDataRequested,
			EnumApplicationStatus.Validated
		}.Contains(Model.Status);
	}

	public bool ShouldSendExtraData()
	{
		return Model.ExtraData.Any(x => x.Status == EnumApplicationExtraDataStatus.Created);
	}

	private async Task OnInputFileChangeAsync(InputFileChangeEventArgs e, EnumFileType fileType)
	{
		var confirmed = await Dialogs.ConfirmAsync($"Are you sure you want to upload {I18n.Enums.Get(fileType)} file?", "Application detail");
		if (confirmed)
		{
			var file = e.GetMultipleFiles()[0];
			using var fileContent = new StreamContent(file.OpenReadStream(1024 * 1024 * 10));//10 mb; todo: parameterize
			var model = new ApplicationFileModel
			{
				Content = await fileContent.ReadAsByteArrayAsync(),
				PublicId = Model.PublicId,
				Type = fileType
			};
			var result = await DocumentService.UploadFileAsync(model);
			//switch (fileType)
			//{
			//	case EnumFileType.PicCnaSigned:
			//		result = 
			//		break;
			//	case EnumFileType.Ircc:
			//		result = await DocumentService.UploadIrccFileAsync(model);
			//		break;
			//		//case EnumFileType.Others:
			//		//	result = await DocumentService.UploadPicFileAsync(model);
			//		//	break;
			//}

			if (result)
			{
				var message = new Message
				{
					Body = $"File {I18n.Enums.Get(fileType)} was uploaded"
				};
				Notify(message);
				await LoadAsync();
			}
		}
	}
}