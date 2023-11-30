using Core.Common.Models;
using Core.Common.Queries;
using Core.Common.Util;
using Core.Services;
using Methodic.Common.Util;
using Methodic.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ApplicationController : ApiController
{
	private IApplicationService _applicationService; 
	private IFormService _formService;

	public ApplicationController(
		IApplicationService applicationService,
		IFormService formService
	)
	{
		_applicationService = applicationService;
		_formService = formService;
	}


	[HttpPost(RouteHelper.Application.GetPage)]
	public async Task<ActionResult> GetApplicationPageAsync([FromBody] ApplicationQueryInfo info)
	{
		var response = await _applicationService.GetApplicationPageAsync(info);
		return Result(response);
	}

	[HttpGet(RouteHelper.Application.GetById)]
	public async Task<ActionResult> GetApplicationByIdAsync(long id)
	{
		var response = await _applicationService.GetApplicationByIdAsync(id);
		return Result(response);
	}

	[HttpGet(RouteHelper.Application.GetByPublicId)]
	public async Task<ActionResult> GetApplicationByPublicIdAsync(string publicId)
	{
		var response = await _applicationService.GetApplicationByPublicIdAsync(publicId);
		return Result(response);
	}

	[HttpPost(RouteHelper.Application.Save)]
	public async Task<ActionResult> SaveApplicationAsync([FromBody] ApplicationModel model)
	{
		var response = await _applicationService.SaveApplicationAsync(model);
		return Result(response);
	}

	[HttpPost(RouteHelper.Application.CheckCode)]
	public async Task<ActionResult> CheckConfirmationCodeAsync(long id, [FromBody] long? code)
	{
		var response = await _applicationService.CheckConfirmationCodeAsync(id, code);
		return Result(response);
	}

	[HttpPost(RouteHelper.Application.RegenerateCode)]
	public async Task<ActionResult> RegenerateConfirmationCodeAsync(long id)
	{
		var response = await _applicationService.RegenerateConfirmationCodeAsync(id);
		return Result(response);
	}

	[HttpPost(RouteHelper.Application.GetSolicitantPage)]
	public async Task<ActionResult> GetSolicitantPageAsync([FromBody] QueryInfo info)
	{
		var response = await _applicationService.GetSolicitantPageAsync(info);
		return Result(response);
	}

	[HttpGet(RouteHelper.Application.GetSolicitantById)]
	public async Task<ActionResult> GetSolicitantByIdAsync(long id)
	{
		var response = await _applicationService.GetSolicitantByIdAsync(id);
		return Result(response);
	}

	[HttpPost(RouteHelper.Application.SaveSolicitant)]
	public async Task<ActionResult> SaveSolicitantAsync([FromBody] SolicitantModel model)
	{
		var response = await _applicationService.SaveSolicitantAsync(model);
		return Result(response);
	}

	[HttpGet(RouteHelper.Form.GetStepById)]
	public async Task<ActionResult> GetFormStepByIdAsync(long id)
	{
		var response = await _formService.GetFormStepByIdAsync(id);
		return Result(response);
	}

	[HttpPost(RouteHelper.Application.SaveExtraData)]
	public async Task<ActionResult> SaveApplicationExtraDataAsync([FromBody] ApplicationExtraDataModel model)
	{
		var response = await _applicationService.SaveApplicationExtraDataAsync(model);
		return Result(response);
	}

	[HttpPost(RouteHelper.Application.SetStepPosition)]
	public async Task<ActionResult> SetStepPositionAsync(long id, [FromBody] int stepPosition)
	{
		var response = await _applicationService.SetStepPositionAsync(id, stepPosition);
		return Result(response);
	}

	[HttpPost(RouteHelper.Application.Approve)]
	public async Task<ActionResult> ApproveAsync(string publicId)
	{
		var response = await _applicationService.ApproveApplicationAsync(publicId);
		return Result(response);
	}

	[HttpPost(RouteHelper.Application.Reject)]
	public async Task<ActionResult> RejectAsync(string publicId)
	{
		var response = await _applicationService.RejectApplicationAsync(publicId);
		return Result(response);
	}

	[HttpPost(RouteHelper.Application.Validate)]
	public async Task<ActionResult> ValidateAsync(string publicId)
	{
		var response = await _applicationService.ValidateApplicationAsync(publicId);
		return Result(response);
	}

	[HttpPost(RouteHelper.Application.RequestExtraData)]
	public async Task<ActionResult> RequestExtraDataAsync(string publicId)
	{
		var response = await _applicationService.RequestExtraDataApplicationAsync(publicId);
		return Result(response);
	}

	//[HttpPost(RouteHelper.Application.RequestExtraDataAsync)]
	//public async Task<ActionResult> RequestExtraDataAsync(long id)
	//{
	//	var response = await _applicationService.RequestExtraDataAsync(id);
	//	return Result(response);
	//}

	[HttpPost(RouteHelper.Application.CompleteExtraData)]
	public async Task<ActionResult> CompleteExtraDataAsync(string publicId)
	{
		var response = await _applicationService.CompleteExtraDataApplicationAsync(publicId);
		return Result(response);
	}

	[HttpPost(RouteHelper.Application.SaveRequest)]
	public async Task<ActionResult> SaveApplicationRequestAsync([FromBody] ApplicationRequestModel model)
	{
		var response = await _applicationService.SaveApplicationRequestAsync(model);
		return Result(response);
	}

	[HttpPost(RouteHelper.Application.SaveRequestResource)]
	public async Task<ActionResult> SaveApplicationRequestResourceAsync([FromBody] ApplicationRequestResourceModel model)
	{
		var response = await _applicationService.SaveApplicationRequestResourceAsync(model);
		return Result(response);
	}

	[HttpGet(RouteHelper.Application.GetRequestById)]
	public async Task<ActionResult> GetApplicationRequestByIdAsync(long id)
	{
		var response = await _applicationService.GetApplicationRequestByIdAsync(id);
		return Result(response);
	}

	[HttpGet(RouteHelper.Application.GetRequestsByApplicationId)]
	public async Task<ActionResult> GetApplicationRequestsByApplicationIdAsync(long id)
	{
		var response = await _applicationService.GetApplicationRequestsByApplicationIdAsync(id);
		return Result(response);
	}

	[HttpPost(RouteHelper.Application.DeleteRequest)]
	public async Task<ActionResult> DeleteApplicationRequestAsync([FromBody] ApplicationRequestModel model)
	{
		var response = await _applicationService.DeleteApplicationRequestAsync(model);
		return Result(response);
	}

	[HttpPost(RouteHelper.Application.DeleteRequestResource)]
	public async Task<ActionResult> DeleteApplicationRequestResourceAsync([FromBody] ApplicationRequestResourceModel model)
	{
		var response = await _applicationService.DeleteApplicationRequestResourceAsync(model);
		return Result(response);
	}
}