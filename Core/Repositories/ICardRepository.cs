using Core.Common.Models;
using Core.Common.Queries;
using Methodic.Common.Util;
using Methodic.Core.Repositories;

namespace Core.Repositories;

public interface ICardRepository : IRepository<CardModel, int>
{
	PageList<CardModel> GetPage(CardQueryInfo queryInfo);
}
