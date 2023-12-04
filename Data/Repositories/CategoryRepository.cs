using AutoMapper;
using Core.Common.Models;
using Core.Common.Queries;
using Data.Domain.Static;
using Core.Repositories;
using Data.Contexts;
using LinqKit;
using Methodic.Common.Messages;
using Methodic.Common.Util;
using Methodic.Data.Repositories.Entities;

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

	public PageList<CategoryModel> GetCategoryPage(CategoryQueryInfo queryInfo)
	{
		var info = new QueryInfo<Category>(queryInfo);
		info.AddSortInfo(nameof(Category.Name), x => x.Name);
		if (!string.IsNullOrEmpty(queryInfo.Name))
		{
			info.Filter = info.Filter.And(x => x.Name.Contains(queryInfo.Name));
		}
		return Query()
			.QueryPage<Category, int, CategoryModel>(x => Translate(x), info);
	}
}

