using Core.Common.Models;
using Core.Common.Models.Enums;
using Core.Common.Util;
using Core.Services;
using Methodic.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace WebApi.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DocumentController : ApiController
{
	private IDocumentService _documentService;

	public DocumentController(
		IDocumentService documentService
	)
	{
		_documentService = documentService;
	}

	[HttpPost(RouteHelper.Document.GetDocumentsByType)]
	public ActionResult GetDocuments(string publicId, EnumFileType type, bool withContent = false)
	{
		var response = _documentService.GetDocuments(publicId, type, withContent);
		//var result = File(response.Data.Content, MediaTypeNames.Application.Octet, response.Data.Name);
		return Result(response);
	}

	[HttpPost(RouteHelper.Document.GetDocumentsByTypes)]
	public ActionResult GetDocuments(string publicId, List<EnumFileType> types, bool withContent = false)
	{
		var response = _documentService.GetDocuments(publicId, types, withContent);
		return Result(response);
	}

	[HttpPost(RouteHelper.Document.GetDocumentById)]
	public FileContentResult GetDocumentByIdAsync(long id)
	{
		var response = _documentService.GetDocumentById(id);
		var result = File(response.Data.Content, MediaTypeNames.Application.Octet, response.Data.Name);
		return result;
	}

	[HttpPost(RouteHelper.Document.UploadDocument)]
	public async Task<ActionResult> UploadDocumentAsync(ApplicationFileModel model)
	{
		var response = await _documentService.UploadDocumentAsync(model);
		return Result(response);
	}

	[HttpPost(RouteHelper.Document.UploadDocuments)]
	public async Task<ActionResult> UploadDocumentsAsync(List<ApplicationFileModel> model)
	{
		var response = await _documentService.UploadDocumentsAsync(model);
		return Result(response);
	}

	//[HttpPost(RouteHelper.Document.GetSummaryDocument)]
	//public FileContentResult GetSummaryDocument(string publicId)
	//{
	//	var response = _documentService.GetSummaryDocument(publicId);
	//	var result = File(response.Data.Content, MediaTypeNames.Application.Octet, response.Data.Name);
	//	return result;
	//}

	//[HttpPost(RouteHelper.Document.GetPicDocument)]
	//public FileContentResult GetPicDocumentAsync(string publicId)
	//{
	//	var response = _documentService.GetPicDocument(publicId);
	//	var result = File(response.Data.Content, MediaTypeNames.Application.Octet, response.Data.Name);
	//	return result;
	//}

	//[HttpPost(RouteHelper.Document.UploadPicSignedDocument)]
	//public async Task<ActionResult> UploadPicSignedDocumentAsync(ApplicationFileModel model)
	//{
	//	var response = await _applicationService.UploadPicSignedDocumentAsync(model);
	//	return Result(response);
	//}

	//[HttpPost(RouteHelper.Document.GetPicSignedDocument)]
	//public FileContentResult GetPicSignedDocumentAsync(string publicId)
	//{
	//	var response = _documentService.GetPicSignedDocument(publicId);
	//	var result = File(response.Data.Content, MediaTypeNames.Application.Octet, response.Data.Name);
	//	return result;
	//}


	//[HttpPost(RouteHelper.Document.GetCnaPicDocument)]
	//public FileContentResult GetCnaPicDocumentAsync(string publicId)
	//{
	//	var response = _documentService.GetPicCnaDocument(publicId);
	//	var result = File(response.Data.Content, MediaTypeNames.Application.Octet, response.Data.Name);
	//	return result;
	//}

	//[HttpPost(RouteHelper.Document.UploadPicCnaSignedDocument)]
	//public async Task<ActionResult> UploadPicCnaSignedDocumentAsync(ApplicationFileModel model)
	//{
	//	var response = await _applicationService.UploadPicCnaSignedDocumentAsync(model);
	//	return Result(response);
	//}

	//[HttpPost(RouteHelper.Document.GetCnaPicSignedDocument)]
	//public FileContentResult GetCnaPicSignedDocumentAsync(string publicId)
	//{
	//	var response = _documentService.GetPicCnaSignedDocument(publicId);
	//	var result = File(response.Data.Content, MediaTypeNames.Application.Octet, response.Data.Name);
	//	return result;
	//}

	//[HttpPost(RouteHelper.Document.UploadMatDocument)]
	//public async Task<ActionResult> UploadMatDocumentAsync(ApplicationFileModel model)
	//{
	//	var response = await _applicationService.UploadMatDocumentAsync(model);
	//	return Result(response);
	//}

	//[HttpPost(RouteHelper.Document.GetMatDocument)]
	//public FileContentResult GetMatDocumentAsync(string publicId)
	//{
	//	var response = _documentService.GetMatDocument(publicId);
	//	var result = File(response.Data.Content, MediaTypeNames.Application.Octet, response.Data.Name);
	//	return result;
	//}

	//[HttpPost(RouteHelper.Document.UploadIrccDocument)]
	//public async Task<ActionResult> UploadIrccDocumentAsync(ApplicationFileModel model)
	//{
	//	var response = await _applicationService.UploadIrccDocumentAsync(model);
	//	return Result(response);
	//}

	//[HttpPost(RouteHelper.Document.GetIrccDocument)]
	//public FileContentResult GetIrccDocumentAsync(string publicId)
	//{
	//	var response = _documentService.GetIrccDocument(publicId);
	//	var result = File(response.Data.Content, MediaTypeNames.Application.Octet, response.Data.Name);
	//	return result;
	//}

	//[HttpPost(RouteHelper.Document.GetCsvDocument)]
	//public FileContentResult GetCsvDocumentAsync(string publicId)
	//{
	//	var response = _documentService.GetCsvDocument(publicId);
	//	var result = File(response.Data.Content, MediaTypeNames.Application.Octet, response.Data.Name);
	//	return result;
	//}

	//[HttpPost(RouteHelper.Document.UploadOtherDocuments)]
	//public async Task<ActionResult> UploadOtherDocumentsAsync([FromBody] ApplicationFileModel[] model)
	//{
	//	var response = await _documentService.UploadOtherDocumentsAsync(model);
	//	return Result(response);
	//}
}