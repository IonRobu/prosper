using AutoMapper;
using Core.Common.Models;
using Core.Common.Queries;
using Core.Repositories;
using Data.Contexts;
using Data.Domain.Static;
using LinqKit;
using Methodic.Common.Messages;
using Methodic.Common.Util;
using Methodic.Data.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

internal class CategoryRepository : Repository<CategoryModel, Category, int>, ICategoryRepository
{
	public CategoryRepository(
		Context context,
		IMapper mapper,
		Messaging messaging
	) : base(context, mapper, messaging)
	{
		
	}

	public PageList<CategoryModel> GetPage(CategoryQueryInfo queryInfo)
	{
		var info = new QueryInfo<Category>(queryInfo);
		info.AddSortInfo(nameof(Category.Name), x => x.Name);
		info.AddSortInfo(nameof(Category.IsFixed), x => x.IsFixed);
		if (!string.IsNullOrEmpty(queryInfo.Name))
		{
			info.Filter = info.Filter.And(x => EF.Functions.Like(x.Name, $"%{queryInfo.Name}%"));
		}
		if (queryInfo.IsFixed != null)
		{
			info.Filter = info.Filter.And(x => x.IsFixed == queryInfo.IsFixed);
		}
		return Query()
			.QueryPage<Category, int, CategoryModel>(Translate, info);
	}
}

