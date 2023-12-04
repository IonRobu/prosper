using Core.Common.Models;
using Core.Common.Queries;
using Methodic.Common.Util;
using Methodic.Core.Services;

namespace Core.Services;

public interface IStaticDataService : IService
{
	Result<PageList<CategoryModel>> GetCategoryPage(CategoryQueryInfo queryInfo);

	Result<CategoryModel> GetCategoryById(int id);

	Task<Result<CategoryModel>> SaveCategoryAsync(CategoryModel model);

	Task<Result<bool>> DeleteCategoryAsync(CategoryModel model);

	Result<PageList<CardModel>> GetCardPage(CardQueryInfo queryInfo);

	Result<CardModel> GetCardById(int id);

	Task<Result<CardModel>> SaveCardAsync(CardModel model);

	Task<Result<bool>> DeleteCardAsync(CardModel model);

	Result<PageList<AccountModel>> GetAccountPage(AccountQueryInfo queryInfo);

	Result<AccountModel> GetAccountById(int id);

	Task<Result<AccountModel>> SaveAccountAsync(AccountModel model);

	Task<Result<bool>> DeleteAccountAsync(AccountModel model);
}
