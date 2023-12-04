using Core.Common.Models;
using Core.Common.Queries;
using Methodic.Common.Util;
using Methodic.Core.Repositories;

namespace Core.Repositories;

public interface ICategoryRepository : IRepository<CategoryModel, int>
{
	PageList<CategoryModel> GetCategoryPage(CategoryQueryInfo queryInfo);
}
