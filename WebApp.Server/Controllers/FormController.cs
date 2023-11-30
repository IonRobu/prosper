using Core.Common.Models;
using Core.Common.Util;
using Core.Services;
using Methodic.Common.Util;
using Methodic.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class FormController : ApiController
{
	private IFormService _formService;

	public FormController(IFormService formService)
	{
		_formService = formService;
	}

	[HttpPost(RouteHelper.Form.GetPage)]
	public async Task<ActionResult> GetFormPageAsync([FromBody] QueryInfo info)
	{
		var response = await _formService.GetFormPageAsync(info);
		return Result(response);
	}

	[HttpGet(RouteHelper.Form.GetById)]
	public async Task<ActionResult> GetFormByIdAsync(long id)
	{
		var response = await _formService.GetFormByIdAsync(id);
		return Result(response);
	}

	[HttpPost(RouteHelper.Form.Save)]
	public async Task<ActionResult> SaveFormAsync([FromBody] FormModel model)
	{
		var response = await _formService.SaveFormAsync(model);
		return Result(response);
	}

	[HttpPost(RouteHelper.Form.Delete)]
	public async Task<ActionResult> DeleteFormAsync([FromBody] FormModel model)
	{
		var response = await _formService.DeleteFormAsync(model);
		return Result(response);
	}

	[HttpGet(RouteHelper.Form.GetStepFieldById)]
	public async Task<ActionResult> GetStepFieldByIdAsync(long id)
	{
		var response = await _formService.GetStepFieldByIdAsync(id);
		return Result(response);
	}

	[HttpPost(RouteHelper.Form.SaveStepField)]
	public async Task<ActionResult> SaveStepFieldAsync([FromBody] StepFieldModel model)
	{
		var response = await _formService.SaveStepFieldAsync(model);
		return Result(response);
	}

	[HttpPost(RouteHelper.Form.DeleteStepField)]
	public async Task<ActionResult> DeleteStepFieldAsync([FromBody] StepFieldModel model)
	{
		var response = await _formService.DeleteStepFieldAsync(model);
		return Result(response);
	}

	[HttpPost(RouteHelper.Form.SetStepFieldPosition)]
	public async Task<ActionResult> SetStepFieldPositionAsync([FromBody] StepFieldModel model, int newPosition)
	{
		var response = await _formService.SetStepFieldPositionAsync(model, newPosition);
		return Result(response);
	}

	[HttpGet(RouteHelper.Form.GetStepById)]
	public async Task<ActionResult> GetFormStepByIdAsync(long id)
	{
		var response = await _formService.GetFormStepByIdAsync(id);
		return Result(response);
	}

	[HttpPost(RouteHelper.Form.SaveStep)]
	public async Task<ActionResult> SaveFormStepAsync([FromBody] FormStepModel model)
	{
		var response = await _formService.SaveFormStepAsync(model);
		return Result(response);
	}

	[HttpPost(RouteHelper.Form.DeleteStep)]
	public async Task<ActionResult> DeleteFormStepAsync([FromBody] FormStepModel model)
	{
		var response = await _formService.DeleteFormStepAsync(model);
		return Result(response);
	}

	[HttpPost(RouteHelper.Form.SetStepPosition)]
	public async Task<ActionResult> SetStepPositionAsync([FromBody] FormStepModel model, int newPosition)
	{
		var response = await _formService.SetStepPositionAsync(model, newPosition);
		return Result(response);
	}

	[HttpPost(RouteHelper.Form.GetFieldList)]
	public async Task<ActionResult> GetFieldListAsync([FromBody] QueryInfo info)
	{
		var response = await _formService.GetFieldListAsync(info);
		return Result(response);
	}

	[HttpPost(RouteHelper.Form.GetFieldPage)]
	public async Task<ActionResult> GetFieldPageAsync([FromBody] QueryInfo info)
	{
		var response = await _formService.GetFieldPageAsync(info);
		return Result(response);
	}

	[HttpGet(RouteHelper.Form.GetFieldById)]
	public async Task<ActionResult> GetFieldByIdAsync(long id)
	{
		var response = await _formService.GetFieldByIdAsync(id);
		return Result(response);
	}

	[HttpPost(RouteHelper.Form.SaveField)]
	public async Task<ActionResult> SaveFieldAsync([FromBody] FieldModel model)
	{
		var response = await _formService.SaveFieldAsync(model);
		return Result(response);
	}

	[HttpPost(RouteHelper.Form.DeleteField)]
	public async Task<ActionResult> DeleteFieldAsync([FromBody] FieldModel model)
	{
		var response = await _formService.DeleteFieldAsync(model);
		return Result(response);
	}

	[HttpPost(RouteHelper.Form.SaveFieldExplanation)]
	public async Task<ActionResult> SaveFieldExplanationAsync([FromBody] FieldExplanationModel model)
	{
		var response = await _formService.SaveFieldExplanationAsync(model);
		return Result(response);
	}

	[HttpPost(RouteHelper.Form.DeleteFieldExplanation)]
	public async Task<ActionResult> DeleteFieldExplanationAsync([FromBody] FieldExplanationModel model)
	{
		var response = await _formService.DeleteFieldExplanationAsync(model);
		return Result(response);
	}

	[HttpGet(RouteHelper.Form.GetUsageById)]
	public async Task<ActionResult> GetFormUsageByIdAsync(int id)
	{
		var response = await _formService.GetFormUsageByIdAsync(id);
		return Result(response);
	}

	[HttpPost(RouteHelper.Form.SaveUsage)]
	public async Task<ActionResult> SaveFormUsageAsync([FromBody] FormUsageModel model)
	{
		var response = await _formService.SaveFormUsageAsync(model);
		return Result(response);
	}

	[HttpPost(RouteHelper.Form.DeleteUsage)]
	public async Task<ActionResult> DeleteFormUsageAsync([FromBody] FormUsageModel model)
	{
		var response = await _formService.DeleteFormUsageAsync(model);
		return Result(response);
	}
}