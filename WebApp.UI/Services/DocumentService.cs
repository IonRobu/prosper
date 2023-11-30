using BlazorDownloadFile;
using Core.Common.Models;
using Core.Common.Models.Enums;
using Core.Common.Util;
using Methodic.Blazor.UI.Configuration;
using Methodic.Blazor.UI.Services;
using System.Net.Mime;

namespace WebApp.Backend.Services;

public class DocumentService : HttpServiceBase
{
	protected override string BaseUrl => "api/document";

	private readonly IBlazorDownloadFileService _blazorDownloadFileService;

	public DocumentService(
		HttpClient client,
		AppSettings appSettings,
		IBlazorDownloadFileService blazorDownloadFileService
	) : base(client, appSettings)
	{
		_blazorDownloadFileService = blazorDownloadFileService;
	}

	public async Task<List<ApplicationFileModel>> GetDocumentsByTypeAsync(string publicId, EnumFileType type)
	{
		var responseContent = await RequestAsync($"{RouteHelper.Document.GetDocumentsByType}?publicId={publicId}", type, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<List<ApplicationFileModel>>();
		return responseContent;
	}

	public async Task<List<ApplicationFileModel>> GetDocumentsByTypesAsync(string publicId, List<EnumFileType> types)
	{
		var responseContent = await RequestAsync($"{RouteHelper.Document.GetDocumentsByTypes}?publicId={publicId}", types, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<List<ApplicationFileModel>>();
		return responseContent;
	}

	public async Task GetDocumentByIdAsync(ApplicationFileModel model)
	{
		var responseContent = await RequestAsync($"{RouteHelper.Document.GetDocumentById}?id={model.Id}", opts =>
		{
			opts.AsPostMethod();
		});
		var content = await responseContent.Content.ReadAsByteArrayAsync();
		var fileName = model.OriginalName ?? $"{model.Type}_{model.PublicId}{model.Extension}";
		await _blazorDownloadFileService.DownloadFile(fileName, content, MediaTypeNames.Application.Octet);
	}

	public async Task<bool> UploadFileAsync(ApplicationFileModel model)
	{
		var result = await RequestAsync(RouteHelper.Document.UploadDocument, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}

	public async Task<bool> UploadFilesAsync(List<ApplicationFileModel> model)
	{
		var result = await RequestAsync(RouteHelper.Document.UploadDocuments, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}

	//public async Task GetDocumentAsync(ApplicationModel model)
	//{
	//	var responseMessage = await RequestAsync($"{RouteHelper.Document.GetDocumentById}?publicId={model.PublicId}", opts =>
	//	{
	//		opts.AsPostMethod();
	//	});
	//	var content = await responseMessage.Content.ReadAsByteArrayAsync();
	//	var fileName = $"Summary_{model.PublicId}.pdf";
	//	await _blazorDownloadFileService.DownloadFile(fileName, content, MediaTypeNames.Application.Octet);
	//}

	//public async Task GetPicDocumentAsync(ApplicationModel model)
	//{
	//	var responseMessage = await RequestAsync($"{RouteHelper.Document.GetPicDocument}?publicId={model.PublicId}", opts =>
	//	{
	//		opts.AsPostMethod();
	//	});
	//	var content = await responseMessage.Content.ReadAsByteArrayAsync();
	//	var fileName = $"PIC_{model.PublicId}.docx";
	//	await _blazorDownloadFileService.DownloadFile(fileName, content, MediaTypeNames.Application.Octet);
	//}

	//public async Task GetPicSignedDocumentAsync(ApplicationModel model)
	//{
	//	var responseMessage = await RequestAsync($"{RouteHelper.Document.GetPicSignedDocument}?publicId={model.PublicId}", opts =>
	//	{
	//		opts.AsPostMethod();
	//	});
	//	var content = await responseMessage.Content.ReadAsByteArrayAsync();
	//	var fileName = $"PIC_{model.PublicId}.pdf";
	//	await _blazorDownloadFileService.DownloadFile(fileName, content, MediaTypeNames.Application.Octet);
	//}

	//public async Task GetCnaPicDocumentAsync(ApplicationModel model)
	//{
	//	var responseMessage = await RequestAsync($"{RouteHelper.Document.GetCnaPicDocument}?publicId={model.PublicId}", opts =>
	//	{
	//		opts.AsPostMethod();
	//	});
	//	var content = await responseMessage.Content.ReadAsByteArrayAsync();
	//	var fileName = $"CNA_PIC_{model.PublicId}.docx";
	//	await _blazorDownloadFileService.DownloadFile(fileName, content, MediaTypeNames.Application.Octet);
	//}

	//public async Task GetCnaPicSignedDocumentAsync(ApplicationModel model)
	//{
	//	var responseMessage = await RequestAsync($"{RouteHelper.Document.GetCnaPicSignedDocument}?publicId={model.PublicId}", opts =>
	//	{
	//		opts.AsPostMethod();
	//	});
	//	var content = await responseMessage.Content.ReadAsByteArrayAsync();
	//	var fileName = $"CNA_PIC_{model.PublicId}.pdf";
	//	await _blazorDownloadFileService.DownloadFile(fileName, content, MediaTypeNames.Application.Octet);
	//}

	//public async Task<bool> UploadPicCnaSignedFileAsync(ApplicationFileModel model)
	//{
	//	var result = await RequestAsync(RouteHelper.Document.UploadPicCnaSignedDocument, model, opts =>
	//	{
	//		opts.AsPostMethod();
	//	})
	//	.ResponseAsync<bool>();
	//	return result;
	//}

	//public async Task GetIrccDocumentAsync(ApplicationModel model)
	//{
	//	var responseContent = await RequestAsync($"{RouteHelper.Document.GetIrccDocument}?publicId={model.PublicId}", opts =>
	//	{
	//		opts.AsPostMethod();
	//	});
	//	var content = await responseContent.Content.ReadAsByteArrayAsync();
	//	var fileName = $"IRCC_{model.PublicId}.pdf";
	//	await _blazorDownloadFileService.DownloadFile(fileName, content, MediaTypeNames.Application.Octet);
	//}

	//public async Task<bool> UploadFileAsync(ApplicationFileModel model)
	//{
	//	var result = await RequestAsync(RouteHelper.Document.UploadDocument, model, opts =>
	//	{
	//		opts.AsPostMethod();
	//	})
	//	.ResponseAsync<bool>();
	//	return result;
	//}


	//public async Task GetMatDocumentAsync(ApplicationModel model)
	//{
	//	var responseContent = await RequestAsync($"{RouteHelper.Document.GetMatDocument}?publicId={model.PublicId}", opts =>
	//	{
	//		opts.AsPostMethod();
	//	});
	//	var content = await responseContent.Content.ReadAsByteArrayAsync();
	//	var fileName = $"MAT_{model.PublicId}.pdf";
	//	await _blazorDownloadFileService.DownloadFile(fileName, content, MediaTypeNames.Application.Octet);
	//}

	//public async Task GetCsvDocumentAsync(ApplicationModel model)
	//{
	//	var responseContent = await RequestAsync($"{RouteHelper.Document.GetCsvDocument}?publicId={model.PublicId}", opts =>
	//	{
	//		opts.AsPostMethod();
	//	});
	//	var content = await responseContent.Content.ReadAsByteArrayAsync();
	//	var fileName = $"Coordinates_{model.PublicId}.csv";
	//	await _blazorDownloadFileService.DownloadFile(fileName, content, MediaTypeNames.Application.Octet);
	//}
}
