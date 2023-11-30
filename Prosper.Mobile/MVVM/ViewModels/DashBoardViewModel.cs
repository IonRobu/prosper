using System.Collections.ObjectModel;
using Transaction = Prosper.MVVM.Models.Transaction;

namespace Prosper.MVVM.ViewModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class DashBoardViewModel
    {
        public ObservableCollection<Transaction> Transaction { get; set; } = new();

        public decimal Balance { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }

        public DashBoardViewModel()
        {
            FillData();
        }

        public void FillData()
        {
            var transactions = App.TransactionsRepo.GetItems();
            transactions = transactions.OrderByDescending(x => x.OperationDate).ToList();
			Transaction.Clear();
			foreach (var item in transactions)
			{
				Transaction.Add(item);
			}

			Balance = 0;
            Income = 0;
            Expenses = 0;

            foreach(var transaction in Transaction)
            {
                if (transaction.IsIncome)
                {
                    Income += transaction.Amount;
                }
                else
                {
                    Expenses += transaction.Amount;
                }       
            }
            Balance = Income - Expenses;
        }
    }
    
}

