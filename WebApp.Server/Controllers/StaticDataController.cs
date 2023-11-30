using Core.Common.Models;
using Core.Common.Queries;
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
public class StaticDataController : ApiController
{
	private readonly IStaticDataService _staticDataService;

	public StaticDataController(
		IStaticDataService staticDataService
	)
	{
		_staticDataService = staticDataService;
	}

	[HttpGet(RouteHelper.StaticData.GetCountryList)]
	public ActionResult GetCountryList(string search)
	{
		var result = _staticDataService.GetCountryList(search);
		return Result(result);
	}

	[HttpPost(RouteHelper.StaticData.GetCountryPage)]
	public ActionResult GetCountryPage([FromBody] CountryQueryInfo queryInfo)
	{
		var result = _staticDataService.GetCountryPage(queryInfo);
		return Result(result);
	}

	[HttpGet(RouteHelper.StaticData.GetCountyList)]
	public ActionResult GetCountyList(string search)
	{
		var result = _staticDataService.GetCountyList(search);
		return Result(result);
	}

	[HttpPost(RouteHelper.StaticData.GetCountyPage)]
	public ActionResult GetCountyPage([FromBody] CountyQueryInfo queryInfo)
	{
		var result = _staticDataService.GetCountyPage(queryInfo);
		return Result(result);
	}

	//[HttpGet(RouteHelper.StaticData.GetSpeciesList)]
	//public ActionResult GetSpeciesList(string search)
	//{
	//	var result = _staticDataService.GetSpeciesList(search);
	//	return Result(result);
	//}

	[HttpPost(RouteHelper.StaticData.GetSpeciesPage)]
	public ActionResult GetSpeciesPage([FromBody] SpeciesQueryInfo queryInfo)
	{
		var result = _staticDataService.GetSpeciesPage(queryInfo);
		return Result(result);
	}

	[HttpGet(RouteHelper.StaticData.GetSpeciesById)]
	public ActionResult GetSpeciesById(long id)
	{
		var result = _staticDataService.GetSpeciesById(id);
		return Result(result);
	}

	[HttpPost(RouteHelper.StaticData.SaveSpecies)]
	public async Task<ActionResult> SaveSpeciesAsync(SpeciesModel model)
	{
		var result = await _staticDataService.SaveSpeciesAsync(model);
		return Result(result);
	}

	[HttpPost(RouteHelper.StaticData.GetCollectionPage)]
	public ActionResult GetCollectionPage([FromBody] CollectionQueryInfo queryInfo)
	{
		var result = _staticDataService.GetCollectionPage(queryInfo);
		return Result(result);
	}

	[HttpGet(RouteHelper.StaticData.GetCollectionList)]
	public ActionResult GetCollectionList()
	{
		var result = _staticDataService.GetCollectionList();
		return Result(result);
	}

	[HttpGet(RouteHelper.StaticData.GetCollectionById)]
	public ActionResult GetCollectionById(int id)
	{
		var result = _staticDataService.GetCollectionById(id);
		return Result(result);
	}

	[HttpPost(RouteHelper.StaticData.SaveCollection)]
	public async Task<ActionResult> SaveCollectionAsync(CollectionModel model)
	{
		var result = await _staticDataService.SaveCollectionAsync(model);
		return Result(result);
	}

	[HttpPost(RouteHelper.StaticData.DeleteCollection)]
	public async Task<ActionResult> DeleteCollectionAsync(CollectionModel model)
	{
		var result = await _staticDataService.DeleteCollectionAsync(model);
		return Result(result);
	}

	[HttpPost(RouteHelper.StaticData.GetCollectionTypePage)]
	public ActionResult GetCollectionTypePage([FromBody] QueryInfo queryInfo)
	{
		var result = _staticDataService.GetCollectionTypePage(queryInfo);
		return Result(result);
	}

	[HttpPost(RouteHelper.StaticData.GetCollectionTypeList)]
	public ActionResult GetCollectionTypeList()
	{
		var result = _staticDataService.GetCollectionTypeList();
		return Result(result);
	}

	[HttpGet(RouteHelper.StaticData.GetCollectionTypeById)]
	public ActionResult GetCollectionTypeById(int id)
	{
		var result = _staticDataService.GetCollectionTypeById(id);
		return Result(result);
	}

	[HttpPost(RouteHelper.StaticData.SaveCollectionType)]
	public async Task<ActionResult> SaveCollectionTypeAsync(CollectionTypeModel model)
	{
		var result = await _staticDataService.SaveCollectionTypeAsync(model);
		return Result(result);
	}

	[HttpPost(RouteHelper.StaticData.DeleteCollectionType)]
	public async Task<ActionResult> DeleteCollectionTypeAsync(CollectionTypeModel model)
	{
		var result = await _staticDataService.DeleteCollectionTypeAsync(model);
		return Result(result);
	}

	[HttpGet(RouteHelper.StaticData.GetMeasureUnitList)]
	public ActionResult GetMeasureUnitList()
	{
		var result = _staticDataService.GetMeasureUnitList();
		return Result(result);
	}

	[HttpPost(RouteHelper.StaticData.GetMeasureUnitPage)]
	public ActionResult GetMeasureUnitPage([FromBody] QueryInfo queryInfo)
	{
		var result = _staticDataService.GetMeasureUnitPage(queryInfo);
		return Result(result);
	}

	[HttpGet(RouteHelper.StaticData.GetMeasureUnitById)]
	public ActionResult GetMeasureUnitById(int id)
	{
		var result = _staticDataService.GetMeasureUnitById(id);
		return Result(result);
	}

	[HttpPost(RouteHelper.StaticData.SaveMeasureUnit)]
	public async Task<ActionResult> SaveMeasureUnitAsync(MeasureUnitModel model)
	{
		var result = await _staticDataService.SaveMeasureUnitAsync(model);
		return Result(result);
	}

	[HttpGet(RouteHelper.StaticData.GetPersonTypeList)]
	public ActionResult GetPersonTypeList()
	{
		var result = _staticDataService.GetPersonTypeList();
		return Result(result);
	}

	[HttpGet(RouteHelper.StaticData.GetOrganizationTypeList)]
	public ActionResult GetOrganizationTypeList()
	{
		var result = _staticDataService.GetOrganizationTypeList();
		return Result(result);
	}

	[HttpGet(RouteHelper.StaticData.GetResourceUsageList)]
	public ActionResult GetResourceUsageList()
	{
		var result = _staticDataService.GetResourceUsageList();
		return Result(result);
	}

	[HttpGet(RouteHelper.StaticData.GetUsageTypeList)]
	public ActionResult GetUsageTypeList()
	{
		var result = _staticDataService.GetUsageTypeList();
		return Result(result);
	}
}