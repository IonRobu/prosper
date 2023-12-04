using Core.Common.Models;
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

	protected override async Task LoadAsync()
	{
		if (Id > 0)
		{
			Model = await TransactionService.GetTransactionByIdAsync(Id);
		}
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
