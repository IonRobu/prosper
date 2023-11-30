using Core.Common.Models;
using Core.Common.Queries;
using Core.Common.Util;
using Methodic.Blazor.UI.Configuration;
using Methodic.Blazor.UI.Services;
using Methodic.Common.Util;

namespace WebApp.Backend.Services;

public class StaticDataService : HttpServiceBase
{
	protected override string BaseUrl => "api/staticdata";

	public StaticDataService(
		HttpClient client,
		AppSettings appSettings
	) : base(client, appSettings)
	{

	}

	public async Task<PageList<CollectionModel>> GetCollectionPageAsync(CollectionQueryInfo queryInfo)
	{
		var result = await RequestAsync(RouteHelper.StaticData.GetCollectionPage, queryInfo, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<PageList<CollectionModel>>();
		return result;
	}

	public async Task<CollectionModel> GetCollectionByIdAsync(long id)
	{
		var result = await RequestAsync($"{RouteHelper.StaticData.GetCollectionById}?id={id}", opts =>
		{
			opts.AsGetMethod();
		})
		.ResponseAsync<CollectionModel>();
		return result;
	}

	public async Task<CollectionModel> SaveCollectionAsync(CollectionModel model)
	{
		var result = await RequestAsync(RouteHelper.StaticData.SaveCollection, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<CollectionModel>();
		return result;
	}

	public async Task<bool> DeleteCollectionAsync(CollectionModel model)
	{
		var result = await RequestAsync(RouteHelper.StaticData.DeleteCollection, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}

	public async Task<PageList<CollectionTypeModel>> GetCollectionTypePageAsync(QueryInfo queryInfo)
	{
		var result = await RequestAsync(RouteHelper.StaticData.GetCollectionTypePage, queryInfo, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<PageList<CollectionTypeModel>>();
		return result;
	}

	public async Task<List<CollectionTypeModel>> GetCollectionTypeListAsync(QueryInfo queryInfo)
	{
		var result = await RequestAsync(RouteHelper.StaticData.GetCollectionTypeList, queryInfo, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<List<CollectionTypeModel>>();
		return result;
	}

	public async Task<CollectionTypeModel> GetCollectionTypeByIdAsync(long id)
	{
		var result = await RequestAsync($"{RouteHelper.StaticData.GetCollectionTypeById}?id={id}", opts =>
		{
			opts.AsGetMethod();
		})
		.ResponseAsync<CollectionTypeModel>();
		return result;
	}

	public async Task<CollectionTypeModel> SaveCollectionTypeAsync(CollectionTypeModel model)
	{
		var result = await RequestAsync(RouteHelper.StaticData.SaveCollectionType, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<CollectionTypeModel>();
		return result;
	}

	public async Task<bool> DeleteCollectionTypeAsync(CollectionTypeModel model)
	{
		var result = await RequestAsync(RouteHelper.StaticData.DeleteCollectionType, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}

	public async Task<PageList<SpeciesModel>> GetSpeciesPageAsync(SpeciesQueryInfo queryInfo)
	{
		var result = await RequestAsync(RouteHelper.StaticData.GetSpeciesPage, queryInfo, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<PageList<SpeciesModel>>();
		return result;
	}

	public async Task<SpeciesModel> GetSpeciesByIdAsync(long id)
	{
		var result = await RequestAsync($"{RouteHelper.StaticData.GetSpeciesById}?id={id}", opts =>
		{
			opts.AsGetMethod();
		})
		.ResponseAsync<SpeciesModel>();
		return result;
	}

	public async Task<SpeciesModel> SaveSpeciesAsync(SpeciesModel model)
	{
		var result = await RequestAsync(RouteHelper.StaticData.SaveSpecies, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<SpeciesModel>();
		return result;
	}

	public async Task<PageList<MeasureUnitModel>> GetMeasureUnitPageAsync(QueryInfo queryInfo)
	{
		var result = await RequestAsync(RouteHelper.StaticData.GetMeasureUnitPage, queryInfo, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<PageList<MeasureUnitModel>>();
		return result;
	}

	public async Task<MeasureUnitModel> GetMeasureUnitByIdAsync(long id)
	{
		var result = await RequestAsync($"{RouteHelper.StaticData.GetMeasureUnitById}?id={id}", opts =>
		{
			opts.AsGetMethod();
		})
		.ResponseAsync<MeasureUnitModel>();
		return result;
	}

	public async Task<MeasureUnitModel> SaveMeasureUnitAsync(MeasureUnitModel model)
	{
		var result = await RequestAsync(RouteHelper.StaticData.SaveMeasureUnit, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<MeasureUnitModel>();
		return result;
	}

	public async Task<PageList<CountryModel>> GetCountryPageAsync(QueryInfo queryInfo)
	{
		var result = await RequestAsync(RouteHelper.StaticData.GetCountryPage, queryInfo, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<PageList<CountryModel>>();
		return result;
	}

	public async Task<PageList<CountyModel>> GetCountyPageAsync(QueryInfo queryInfo)
	{
		var result = await RequestAsync(RouteHelper.StaticData.GetCountyPage, queryInfo, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<PageList<CountyModel>>();
		return result;
	}
}