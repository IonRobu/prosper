using System;
using System.Collections.ObjectModel;
using PropertyChanged;
using Prosper.MVVM.Models;
using Transaction = Prosper.MVVM.Models.Transaction;
namespace Prosper.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class StatisticsViewModel
{
	public DateTime? StartDate { get; set; } = DateTime.UtcNow.AddMonths(-1).AddDays(1);

	public DateTime? EndDate { get; set; } = DateTime.UtcNow.AddDays(1);

	public string Test { get; set; }

	public Account Account { get; set; } = new();

	public ObservableCollection<TransactionsSummary> Summary { get; set; } = new();

	public ObservableCollection<Transaction> SpendingList { get; set; } = new();

	public ObservableCollection<Account> Accounts { get; set; } = new();

	public void LoadStaticData()
	{
		var accounts = App.AccountRepo.GetItems()
			.OrderBy(x => x.Name)
			.ToList();
		Accounts.Clear();
		foreach (var item in accounts)
		{
			Accounts.Add(item);
		}
		Accounts.Insert(0, new Account());
	}


	public void GetTransactionsSummary(out string message)
	{
		if (StartDate == null)
		{
			message = "Field 'Start date' is required";
			return;
		}
		if (EndDate == null)
		{
			message = "Field 'End date' is required";
			return;
		}

		var data = App.TransactionsRepo.GetItems()
			.Where(x => x.OperationDate >= StartDate && x.OperationDate <= EndDate)
			.ToList();
		if (Account != null && Account.Id != 0)
		{
			data = data.Where(x => x.AccountId == Account.Id)
				.ToList();
		}

		var result = new List<TransactionsSummary>();
		var GroupedTransactions = data.GroupBy(t => t.OperationDate.Date);

		foreach (var group in GroupedTransactions)
		{
			var transactionSummary = new TransactionsSummary
			{
				TransactionsDate = group.Key,
				TransactionsTotal = group.Sum(t => t.IsIncome ? t.Amount : -t.Amount),
				ShownDate = group.Key.ToString("MM/dd")
			};
			result.Add(transactionSummary);
		}

		result = result.OrderBy(x => x.TransactionsDate).ToList();
		Summary = new ObservableCollection<TransactionsSummary>(result);
		var spendinglist = data.Where(x => x.IsIncome == false);
		SpendingList = new ObservableCollection<Transaction>(spendinglist);

		
		message = null;
	}

	public void ResetTransactionsSummary()
	{
		StartDate = null;
		EndDate = null;
		Account = null;
		Summary.Clear();
	}
}

