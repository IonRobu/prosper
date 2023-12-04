using Core.Common.Models;
using Core.Common.Queries;
using Core.Common.Util;
using Core.Services;
using Methodic.Common.Util;
using Methodic.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StaticDataController : ApiController
{
	private readonly IStaticDataService _staticDataService;

	public StaticDataController(
		IStaticDataService staticDataService
	)
	{
		_staticDataService = staticDataService;
	}


	[HttpPost(RouteHelper.StaticData.GetCategoryPage)]
	public ActionResult GetCategoryPage([FromBody] CategoryQueryInfo queryInfo)
	{
		var result = _staticDataService.GetCategoryPage(queryInfo);
		return Result(result);
	}

	[HttpGet(RouteHelper.StaticData.GetCategoryById)]
	public ActionResult GetCategoryById(int id)
	{
		var result = _staticDataService.GetCategoryById(id);
		return Result(result);
	}

	[HttpPost(RouteHelper.StaticData.SaveCategory)]
	public async Task<ActionResult> SaveCategoryAsync(CategoryModel model)
	{
		var result = await _staticDataService.SaveCategoryAsync(model);
		return Result(result);
	}


	[HttpPost(RouteHelper.StaticData.GetCardPage)]
	public ActionResult GetCardPage([FromBody] QueryInfo queryInfo)
	{
		var result = _staticDataService.GetCardPage(queryInfo);
		return Result(result);
	}

	[HttpGet(RouteHelper.StaticData.GetCardById)]
	public ActionResult GetCardById(int id)
	{
		var result = _staticDataService.GetCardById(id);
		return Result(result);
	}

	[HttpPost(RouteHelper.StaticData.SaveCard)]
	public async Task<ActionResult> SaveCardAsync(CardModel model)
	{
		var result = await _staticDataService.SaveCardAsync(model);
		return Result(result);
	}



	[HttpPost(RouteHelper.StaticData.GetAccountPage)]
	public ActionResult GetAccountPage([FromBody] QueryInfo queryInfo)
	{
		var result = _staticDataService.GetAccountPage(queryInfo);
		return Result(result);
	}

	[HttpGet(RouteHelper.StaticData.GetAccountById)]
	public ActionResult GetAccountById(int id)
	{
		var result = _staticDataService.GetAccountById(id);
		return Result(result);
	}

	[HttpPost(RouteHelper.StaticData.SaveAccount)]
	public async Task<ActionResult> SaveAccountAsync(AccountModel model)
	{
		var result = await _staticDataService.SaveAccountAsync(model);
		return Result(result);
	}
}