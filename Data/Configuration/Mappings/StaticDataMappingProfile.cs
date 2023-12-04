using AutoMapper;
using Core.Common.Models;
using Data.Domain.Static;
using Data.Domain.Business;

namespace Data.Configuration.Mappings;

internal class StaticDataMappingProfile : Profile
{
	public StaticDataMappingProfile()
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
			.ForMember(x => x.Category, opts => opts.Ignore())
			.ForMember(x => x.Card, opts => opts.Ignore())
			.ForMember(x => x.Account, opts => opts.Ignore());
	}
}
