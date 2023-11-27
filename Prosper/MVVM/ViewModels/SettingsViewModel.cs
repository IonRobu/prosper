using Prosper.MVVM.Models;
using System.Collections.ObjectModel;

namespace Prosper.MVVM.ViewModels;

public class SettingsViewModel
{
	public TransactionCategory TransactionCategory { get; set; } = new();

	public Account Account { get; set; } = new();

	public Card Card { get; set; } = new();

	public ObservableCollection<TransactionCategory> TransactionCategories { get; set; } = new();

	public ObservableCollection<Account> Accounts { get; set; } = new();

	public ObservableCollection<Card> Cards { get; set; } = new();

	public SettingsViewModel()
	{
		FillData();
	}

	public string SaveTransactionCategory(out bool succeeded)
	{
		if (TransactionCategory.Name == null)
		{
			succeeded = false;
			return "Field 'Name' is required";
		}
		App.TransactionsCategoryRepo.SaveItem(TransactionCategory);
		succeeded = true;
		return App.TransactionsRepo.StatusMessage;
	}

	public string SaveAccount(out bool succeeded)
	{
		if (Account.Name == null)
		{
			succeeded = false;
			return "Field 'Name' is required";
		}
		App.AccountRepo.SaveItem(Account);
		succeeded = true;
		return App.TransactionsRepo.StatusMessage;
	}

	public string SaveCard(out bool succeeded)
	{
		if (Card.Name == null)
		{
			succeeded = false;
			return "Field 'Name' is required";
		}
		if (Card.Number == null)
		{
			succeeded = false;
			return "Field 'Number' is required";
		}
		App.CardRepo.SaveItem(Card);
		succeeded = true;
		return App.TransactionsRepo.StatusMessage;
	}

	public void FillData()
	{
		var transactionCategories = App.TransactionsCategoryRepo.GetItems()
			.OrderBy(x => x.Name)
			.ToList();
		TransactionCategories.Clear();
		foreach (var item in transactionCategories)
		{
			TransactionCategories.Add(item);
		}

		var accounts = App.AccountRepo.GetItems()
			.OrderBy(x => x.Name)
			.ToList();
		Accounts.Clear();
		foreach (var item in accounts)
		{
			Accounts.Add(item);
		}

		var cards = App.CardRepo.GetItems()
			.OrderBy(x => x.Name)
			.ToList();
		Cards.Clear();
		foreach (var item in cards)
		{
			Cards.Add(item);
		}
	}
}

