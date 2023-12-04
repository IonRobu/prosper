using AutoMapper;
using Core.Common.Models;
using Data.Domain.Static;
using Data.Domain.Business;

namespace Data.Configuration.Mappings;

internal class MappingProfile : Profile
{
	public MappingProfile()
	{
		Map();
	}

	private void Map()
	{
		CreateMap<Category, CategoryModel>(MemberList.Source);
		CreateMap<CategoryModel, Category>(MemberList.Source);

		CreateMap<Card, CardModel>(MemberList.Source);
		CreateMap<CardModel, Card>(MemberList.Source);

		CreateMap<Account, AccountModel>(MemberList.Source);
		CreateMap<AccountModel, Account>(MemberList.Source);

		CreateMap<Transaction, TransactionModel>(MemberList.Source);
		CreateMap<TransactionModel, Transaction>(MemberList.Source)
			.ForPath(x => x.Category, opts => opts.Ignore())//??? not ignoring
			.ForPath(x => x.Card, opts => opts.Ignore())
			.ForPath(x => x.Account, opts => opts.Ignore())
			.AfterMap((src, dest) => {
				dest.Category = null;
				dest.Card = null;
				dest.Account = null;
			});
	}
}
