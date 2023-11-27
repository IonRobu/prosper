using Prosper.MVVM.Views;
using Prosper.MVVM.Models;
using ProsperDaily.Repositories;

namespace Prosper;

public partial class App : Application

{
	public static BaseRepository<Transaction> TransactionsRepo { get; private set; }

	public static BaseRepository<TransactionCategory> TransactionsCategoryRepo { get; private set; }

	public static BaseRepository<Account> AccountRepo { get; private set; }

	public static BaseRepository<Card> CardRepo { get; private set; }

	public App(
		BaseRepository<Transaction> _TransactionsRepo,
		BaseRepository<TransactionCategory> _TransactionsCategoryRepo,
		BaseRepository<Account> _AccountRepo,
		BaseRepository<Card> _CardRepo
	)
	{
		InitializeComponent();

		TransactionsRepo = _TransactionsRepo;
		TransactionsCategoryRepo = _TransactionsCategoryRepo;
		AccountRepo = _AccountRepo;
		CardRepo = _CardRepo;


		// MainPage = new AppContainer();
		MainPage = new NavigationPage(new AppContainer());
	}
}

