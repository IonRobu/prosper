using Methodic.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class StaticDataController : ApiController
{
	//private readonly IStaticDataService _staticDataService;

	//public StaticDataController(
	//	IStaticDataService staticDataService
	//)
	//{
	//	_staticDataService = staticDataService;
	//}

	

	//[HttpPost(RouteHelper.StaticData.GetSpeciesPage)]
	//public ActionResult GetSpeciesPage([FromBody] SpeciesQueryInfo queryInfo)
	//{
	//	var result = _staticDataService.GetSpeciesPage(queryInfo);
	//	return Result(result);
	//}

	//[HttpGet(RouteHelper.StaticData.GetSpeciesById)]
	//public ActionResult GetSpeciesById(long id)
	//{
	//	var result = _staticDataService.GetSpeciesById(id);
	//	return Result(result);
	//}

	//[HttpPost(RouteHelper.StaticData.SaveSpecies)]
	//public async Task<ActionResult> SaveSpeciesAsync(SpeciesModel model)
	//{
	//	var result = await _staticDataService.SaveSpeciesAsync(model);
	//	return Result(result);
	//}
}