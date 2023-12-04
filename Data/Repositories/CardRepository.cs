using AutoMapper;
using Core.Common.Models;
using Core.Common.Queries;
using Core.Data.Domain.Static;
using Core.Repositories;
using Data.Contexts;
using LinqKit;
using Methodic.Common.Messages;
using Methodic.Common.Util;
using Methodic.Data.Repositories.Entities;

namespace Data.Repositories;

internal class CardRepository : Repository<CardModel, Card, int>, ICardRepository
{
	public CardRepository(
		Context context,
		IMapper mapper,
		Messaging messaging
	) : base(context, mapper, messaging)
	{
		
	}

	public PageList<CardModel> GetCardPage(CategoryQueryInfo queryInfo)
	{
		var info = new QueryInfo<Card>(queryInfo);
		info.AddSortInfo(nameof(Card.Name), x => x.Name);
		if (!string.IsNullOrEmpty(queryInfo.Name))
		{
			info.Filter = info.Filter.And(x => x.Name.Contains(queryInfo.Name));
		}
		return Query()
			.QueryPage<Card, int, CardModel>(x => Translate(x), info);
	}
}

