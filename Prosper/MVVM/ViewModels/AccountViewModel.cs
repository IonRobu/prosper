using Prosper.MVVM.Models;
using System.Collections.ObjectModel;

namespace Prosper.MVVM.ViewModels;

public class AccountViewModel
{
	public Account Account { get; set; } = new();

	public ObservableCollection<Account> Accounts { get; set; }

	public AccountViewModel()
	{
		FillData();
	}

	public string SaveTransactionCategory()
	{
		App.AccountRepo.SaveItem(Account);
		return App.TransactionsRepo.StatusMessage;
	}

	public void FillData()
	{
		var accounts = App.AccountRepo.GetItems()
			.OrderBy(x => x.Name)
			.ToList();
		Accounts = new ObservableCollection<Account>(accounts);
	}
}

