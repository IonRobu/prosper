using Core.Common.Models;
using Core.Common.Queries;
using Methodic.Common.Messages;
using Microsoft.AspNetCore.Components;
using WebApp.Client.Services;
using WebApp.Client.Validators;

namespace WebApp.Client.Components.Home.Views;

public partial class TransactionForm
{
	[Parameter]
	public long Id { get; set; }

	[Parameter]
	public Action OnClosed { get; set; }

	[Inject]
	private StaticDataService StaticDataService { get; set; }

	[Inject]
	private TransactionModelValidator Validator { get; set; }

	[Inject]
	private TransactionService TransactionService { get; set; }

	private List<CategoryModel> CategoryList { get; set; } = new();

	private List<CardModel> CardList { get; set; } = new();

	private List<AccountModel> AccountList { get; set; } = new();

	protected override async Task LoadAsync()
	{
		if (Id > 0)
		{
			Model = await TransactionService.GetTransactionByIdAsync(Id);
		}
		CategoryList = (await StaticDataService.GetCategoryPageAsync(new CategoryQueryInfo { PageSize = 0})).Items;
		CardList = (await StaticDataService.GetCardPageAsync(new CardQueryInfo { PageSize = 0 })).Items;
		AccountList = (await StaticDataService.GetAccountPageAsync(new AccountQueryInfo { PageSize = 0 })).Items;
	}

	protected override Task<TransactionModel> SaveDataAsync()
	{
		return TransactionService.SaveTransactionAsync(Model);
	}

	protected override async Task OnEntitySavedAsync(TransactionModel model)
	{
		OnClosed?.Invoke();
		await base.OnEntitySavedAsync(model);
	}

	protected override List<Message> Validate(TransactionModel model)
	{
		return Validator.PerformValidation(model);
	}
}
