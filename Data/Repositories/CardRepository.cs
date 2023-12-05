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

internal class CardRepository : Repository<CardModel, Card, int>, ICardRepository
{
	public CardRepository(
		Context context,
		IMapper mapper,
		Messaging messaging
	) : base(context, mapper, messaging)
	{
		
	}

	public PageList<CardModel> GetPage(CardQueryInfo queryInfo)
	{
		var info = new QueryInfo<Card>(queryInfo);
		info.AddSortInfo(nameof(Card.Name), x => x.Name);
		info.AddSortInfo(nameof(Card.Number), x => x.Number);
		if (!string.IsNullOrEmpty(queryInfo.Name))
		{
			info.Filter = info.Filter.And(x => EF.Functions.Like(x.Name, $"%{queryInfo.Name}%"));
		}
		if (!string.IsNullOrEmpty(queryInfo.Number))
		{
			info.Filter = info.Filter.And(x => EF.Functions.Like(x.Number, $"%{queryInfo.Number}%"));
		}
		return Query()
			.QueryPage<Card, int, CardModel>(Translate, info);
	}
}

