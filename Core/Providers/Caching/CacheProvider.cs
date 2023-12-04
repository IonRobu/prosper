using Coravel.Cache.Interfaces;
using Core.Common.Models;
using Core.Repositories;
using Methodic.Core.Providers.Caching;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Core.Providers.Caching;

public class CacheProvider : Methodic.Core.Providers.Caching.CacheProvider
{
	private readonly IServiceScopeFactory _factory;

	public CacheProvider(
		ICache cache,
		IServiceScopeFactory factory
	) : base(cache)
	{
		_factory = factory;
	}

	[Cache]
	public List<CountryModel> CountryList()
	{
		return GetList(() =>
		{
			using (var scope = _factory.CreateScope())
			{
				var repository = scope.ServiceProvider.GetService<ICountryRepository>();
				return repository.GetList();
			}
		});
	}

	[Cache]
	public List<CountyModel> CountyList()
	{
		return GetList(() =>
		{
			using (var scope = _factory.CreateScope())
			{
				var repository = scope.ServiceProvider.GetService<ICountyRepository>();
				return repository.GetList();
			}
		});
	}

	//[Cache]
	//public List<SpeciesModel> SpeciesList()
	//{
	//	return GetList(() =>
	//	{
	//		using (var scope = _factory.CreateScope())
	//		{
	//			var repository = scope.ServiceProvider.GetService<ISpeciesRepository>();
	//			return repository.GetList();
	//		}
	//	});
	//}

	[Cache]
	public List<CollectionModel> CollectionList()
	{
		return GetList(() =>
		{
			using (var scope = _factory.CreateScope())
			{
				var repository = scope.ServiceProvider.GetService<ICollectionRepository>();
				return repository.GetList();
			}
		});
	}

	[Cache]
	public List<CollectionTypeModel> CollectionTypeList()
	{
		return GetList(() =>
		{
			using (var scope = _factory.CreateScope())
			{
				var repository = scope.ServiceProvider.GetService<ICollectionTypeRepository>();
				return repository.GetList();
			}
		});
	}

	[Cache]
	public List<MeasureUnitModel> MeasureUnitList()
	{
		return GetList(() =>
		{
			using (var scope = _factory.CreateScope())
			{
				var repository = scope.ServiceProvider.GetService<IMeasureUnitRepository>();
				return repository.GetList();
			}
		});
	}

	[Cache]
	public List<PersonTypeModel> PersonTypeList()
	{
		return GetList(() =>
		{
			using (var scope = _factory.CreateScope())
			{
				var repository = scope.ServiceProvider.GetService<IPersonTypeRepository>();
				return repository.GetList();
			}
		});
	}

	[Cache]
	public List<OrganizationTypeModel> OrganizationTypeList()
	{
		return GetList(() =>
		{
			using (var scope = _factory.CreateScope())
			{
				var repository = scope.ServiceProvider.GetService<IOrganizationTypeRepository>();
				return repository.GetList();
			}
		});
	}

	[Cache]
	public List<ResourceUsageModel> ResourceUsageList()
	{
		return GetList(() =>
		{
			using (var scope = _factory.CreateScope())
			{
				var repository = scope.ServiceProvider.GetService<IResourceUsageRepository>();
				return repository.GetList();
			}
		});
	}

	[Cache]
	public List<UsageTypeModel> UsageTypeList()
	{
		return GetList(() =>
		{
			using (var scope = _factory.CreateScope())
			{
				var repository = scope.ServiceProvider.GetService<IUsageTypeRepository>();
				return repository.GetList();
			}
		});
	}
}