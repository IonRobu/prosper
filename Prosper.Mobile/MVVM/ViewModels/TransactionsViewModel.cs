using Prosper.MVVM.Models;
using System.Collections.ObjectModel;
using Transaction = Prosper.MVVM.Models.Transaction;

namespace Prosper.MVVM.ViewModels
{
	public class TransactionsViewModel
	{
		public Transaction Transaction { get; set; } = new Transaction();

		public ObservableCollection<TransactionCategory> Categories { get; set; } = new ();

		public ObservableCollection<Account> Accounts { get; set; } = new();

		public ObservableCollection<Card> Cards { get; set; } = new();

		public TransactionsViewModel()
		{
			FillData();
		}

		public string SaveTransaction()
		{
			App.TransactionsRepo.SaveItem(Transaction);
			return App.TransactionsRepo.StatusMessage;
		}

		public void FillData()
		{
			var transactionCategories = App.TransactionsCategoryRepo.GetItems()
			.OrderBy(x => x.Name)
			.ToList();
			Categories.Clear();
			foreach (var item in transactionCategories)
			{
				Categories.Add(item);
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
}

